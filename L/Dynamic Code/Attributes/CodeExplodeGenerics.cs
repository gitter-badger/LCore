﻿using System;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class CodeExplodeGenerics : CodeExplodeMember
        {
        public CodeExplodeGenerics(string Name = "", string Comments = "", int MaximumGeneric = CodeExplode_ExplodeLogic.ExplodeCount)
            : base(Name, Comments)
            {
            this.MaximumGeneric = MaximumGeneric;
            }

        private List<List<string>> _Replacements;
        public int MaximumGeneric;

        public const string NoArgumentsToken = "/**/";
        public const string MethodActionToken = "/*MA*/";
        public const string MethodFuncToken = "/*MF*/";
        public const string ArgumentToken = "/*A*/";
        public const string ArgumentTokenCommaBefore = "/*,A*/";
        public const string ArgumentTokenCommaAfter = "/*A,*/";
        public const string GenericActionToken = "/*GA*/";
        public const string GenericActionTokenCommaBefore = "/*,GA*/";
        public const string GenericActionTokenCommaAfter = "/*GA,*/";
        public const string ArgumentToken_Layer2 = "/*X2A*/";
        public const string GenericActionToken_Layer2 = "/*X2GA*/";
        public const string GenericFuncToken_Layer2 = "/*X2GF*/";
        public const string SubtractGenericType_Layer2 = "/*X2-TI*/";
        public const string SubtractArgumentType_Layer2 = "/*X2-OI*/";
        public const string GenericActionTokenI = "/*IGA*/";
        public const string GenericFuncToken = "/*GF*/";
        public const string GenericFuncTokenCommaBefore = "/*,GF*/";
        public const string GenericFuncTokenCommaAfter = "/*GF,*/";
        public const string GenericFuncTokenI = "/*IGF*/";
        public static string[] SubtractGenericType = new string[16].CollectI((i, s) => $"/*-T{i + 1}*/");
        public static string[] SubtractArgumentType = new string[16].CollectI((i, s) => $"/*-O{i + 1}*/");

        public static Func<string, bool> ContainsMultiLevelTokens = In => In.ContainsAny(Logic.Def.ArrayExt.List(
            GenericActionToken_Layer2,
            GenericFuncToken_Layer2,
            SubtractGenericType_Layer2,
            SubtractArgumentType_Layer2)());
        public static Func<string, string> RemoveGenericComments = In =>
        {
            Logic.Def.ArrayExt.Array(
                MethodActionToken, MethodFuncToken,
                NoArgumentsToken, ArgumentToken,
                ArgumentTokenCommaAfter, ArgumentTokenCommaBefore,
                GenericActionToken, GenericActionTokenCommaAfter,
                GenericActionTokenCommaBefore, GenericActionTokenI,
                GenericFuncToken, GenericFuncTokenCommaAfter,
                GenericFuncTokenCommaBefore, GenericFuncTokenI,
                ArgumentToken_Layer2,
                GenericActionToken_Layer2,
                GenericFuncToken_Layer2,
                SubtractGenericType_Layer2,
                SubtractArgumentType_Layer2
            )()
            .Add(SubtractGenericType)
            .Add(SubtractArgumentType)
                      .Each(s => { In = In.ReplaceAll(s, ""); });
            return In;
        };
        #region GetLevel2Replacements

        public static Func<List<List<string>>> GetLevel2Replacements = () =>
        {
            List<List<string>> Out = new List<List<string>>
            {
            CodeReplacements_GenericParams(GenericActionToken_Layer2, ""),
            CodeReplacements_GenericParamsOutput(GenericFuncToken_Layer2, "U", ""),
            CodeReplacements_Args(ArgumentToken_Layer2, "", ""),
            CodeReplacements_GenericParams(MethodActionToken, ""),
            CodeReplacements_GenericParamsOutput(MethodFuncToken, "U", "")
            };
            Out.AddRange(Logic_CodeReplacements(new Type[] { }));
            return Out;
        };
        #endregion
        #region CodeReplacements_FieldToMethod
        public static Func<string, List<List<string>>> CodeReplacements_FieldToMethod = Name =>
        {
            List<List<string>> Out = new List<List<string>>();
            string Search = $"{Name} = (";
            string Replace = $"{Name}()\r\n{{\r\n return (";
            Out.Add(Logic.Def.ArrayExt.List(Search, Replace)());
            string Search2 = $"{Name}{MethodActionToken} = (";
            string Replace2 = $"{Name}{MethodActionToken}()\r\n{{\r\n return (";
            Out.Add(Logic.Def.ArrayExt.List(Search2, Replace2)());
            string Search3 = $"{Name}{MethodFuncToken} = (";
            string Replace3 = $"{Name}{MethodFuncToken}()\r\n{{\r\n return (";
            Out.Add(Logic.Def.ArrayExt.List(Search3, Replace3)());
            return Out;
        };
        #endregion
        #region CodeReplacements_GenericParams
        public static Func<string, string, List<string>> CodeReplacements_GenericParams = L.F<string, string, List<string>>((PreStr, PostStr) =>
        {
            bool PrefixComma = PreStr.Contains(GenericActionTokenCommaBefore) || PreStr == GenericActionTokenCommaBefore;
            bool SuffixComma = PreStr.Contains(GenericActionTokenCommaAfter) || PreStr == GenericActionTokenCommaAfter;
            bool IncludeBraces = !PrefixComma && !SuffixComma;
            bool PrefixI = PreStr.Contains(GenericActionTokenI) || PreStr == GenericActionTokenI;
            int i = 0;
            return L.F(() =>
            {
                string Generics = "";
                if (i > 0)
                    {
                    Generics = (IncludeBraces ? "<" : "") +
                        new string[i].CollectI((i2, s) => $"T{i2 + 1}").Combine(", ")
                        + (IncludeBraces ? ">" : "");
                    }
                i++;
                return (PrefixComma && i > 1 ? ", " : "") +
                    (PrefixI && i > 2 ? (i - 1).ToString() : "") + PreStr + Generics + PostStr +
                    (SuffixComma && i > 1 ? ", " : "");
            }).Collect((uint)CodeExplode_ExplodeLogic.ExplodeCount)();
        });
        #endregion
        #region CodeReplacements_GenericParamsOutput
        public static Func<string, string, string, List<string>> CodeReplacements_GenericParamsOutput = L.F<string, string, string, List<string>>((PreStr, OutputType, PostStr) =>
        {
            bool PrefixComma = PreStr.Contains(GenericFuncTokenCommaBefore) || PreStr == GenericFuncTokenCommaBefore;
            bool SuffixComma = PreStr.Contains(GenericFuncTokenCommaAfter) || PreStr == GenericFuncTokenCommaAfter;
            bool IncludeBraces = !PrefixComma && !SuffixComma;
            bool PrefixI = PreStr.Contains(GenericFuncTokenI) || PreStr == GenericFuncTokenI;
            int i = 0;
            return L.F(() =>
            {
                string Generics;
                if (i > 0)
                    {
                    Generics = (IncludeBraces ? "<" : "") +
                        new string[i + 1].CollectI((i2, s) => i2 - 1 == i - 1 ? OutputType : $"T{i2 + 1}").Combine(", ")
                        + (OutputType.IsEmpty() ? ", " : (IncludeBraces ? ">" : ""));
                    }
                else
                    Generics = (IncludeBraces ? "<" : "") + OutputType + (OutputType.IsEmpty() ? "" : (IncludeBraces ? ">" : ""));
                i++;
                return (PrefixComma && i > 1 ? ", " : "") +
                    (PrefixI && i > 2 ? (i - 1).ToString() : "")
                    + PreStr + Generics +
                     (SuffixComma && i > 1 ? ", " : "");
            }).Collect((uint)CodeExplode_ExplodeLogic.ExplodeCount)();
        });
        #endregion
        #region CodeReplacements_Args
        public static Func<string, string, string, List<string>> CodeReplacements_Args = (PreArgs, PostArgs, EndStr) =>
        {
            bool PrefixComma = PreArgs.Contains(ArgumentTokenCommaBefore) || PreArgs == ArgumentTokenCommaBefore;
            bool SuffixComma = PreArgs.Contains(ArgumentTokenCommaAfter) || PreArgs == ArgumentTokenCommaAfter;
            int i = 0;
            return L.F(() =>
            {
                string Out;
                if (i > 0)
                    {
                    Out = (!PreArgs.IsEmpty() ? PreArgs + (PreArgs != "(" &&
                        PreArgs != $"({ArgumentToken}" &&
                        PreArgs != ArgumentToken &&
                        PreArgs != ArgumentTokenCommaAfter &&
                        PreArgs != ArgumentTokenCommaBefore &&
                        PreArgs != ArgumentToken_Layer2 ?
                        ", " : "") : "") +
                        new string[i].CollectI((i2, s) => $"o{i2 + 1}").Combine(", ")
                        + (!PostArgs.IsEmpty() ? (PostArgs != ")" && PostArgs != $"{ArgumentToken})" &&
                        PostArgs != ArgumentToken &&
                        PostArgs != ArgumentTokenCommaAfter &&
                        PostArgs != ArgumentToken_Layer2 &&
                        PostArgs != ArgumentTokenCommaBefore ? ", " : "") + PostArgs : "") + EndStr;
                    }
                else
                    {
                    if (!PreArgs.IsEmpty() &&
                        !PostArgs.IsEmpty() &&
                        PreArgs != "(" &&
                        PreArgs != $"({ArgumentToken}" &&
                        PreArgs != ArgumentToken &&
                        PreArgs != ArgumentTokenCommaAfter &&
                        PreArgs != ArgumentTokenCommaBefore &&
                        PreArgs != ArgumentToken_Layer2 &&
                        PostArgs != ")" &&
                        PostArgs != $"{ArgumentToken})" &&
                        PostArgs != ArgumentToken &&
                        PostArgs != ArgumentToken_Layer2 &&
                        PostArgs != ArgumentTokenCommaAfter &&
                        PostArgs != ArgumentTokenCommaBefore)
                        {
                        Out = $"{PreArgs}, {PostArgs}{EndStr}";
                        }
                    else
                        {
                        Out = $"{PreArgs}{PostArgs}{EndStr}";
                        }
                    }
                i++;
                return
                     (PrefixComma && i > 1 ? ", " : "")
                    + Out +
                     (SuffixComma && i > 1 ? ", " : "");
            }).Collect((uint)CodeExplode_ExplodeLogic.ExplodeCount)();
        };
        #endregion
        #region Logic_CodeReplacements
        public static Func<Type[], List<List<string>>> Logic_CodeReplacements = L.F<Type[], List<List<string>>>(OutputParams =>
        {
        List<List<string>> Out = new List<List<string>>
            {
            CodeReplacements_GenericParams(MethodActionToken, "("),
            CodeReplacements_GenericParams(MethodActionToken, " = ("),
            CodeReplacements_GenericParams(GenericActionToken, ""),
            CodeReplacements_GenericParams(GenericActionTokenCommaBefore, ""),
            CodeReplacements_GenericParams(GenericActionTokenCommaAfter, ""),
            CodeReplacements_GenericParams(GenericActionTokenI, ""),
            CodeReplacements_GenericParamsOutput(MethodFuncToken, "U", "("),
            CodeReplacements_GenericParamsOutput(MethodFuncToken, "U", " = ("),
            CodeReplacements_GenericParamsOutput(GenericFuncToken, "U", ""),
            CodeReplacements_GenericParamsOutput(GenericFuncTokenCommaBefore, "U", ""),
            CodeReplacements_GenericParamsOutput(GenericFuncTokenCommaAfter, "U", ""),
            CodeReplacements_GenericParamsOutput(GenericFuncTokenI, "U", ""),
            CodeReplacements_GenericParams("Action", "]"),
            CodeReplacements_GenericParams("Action", ">"),
            CodeReplacements_GenericParams("Action", ",")
            };
        OutputParams.Each(output =>
            {
                Out.Add(CodeReplacements_GenericParamsOutput("Func", output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput("Func", output.FullName, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncToken, output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncToken, output.FullName, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncTokenCommaBefore, output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncTokenCommaBefore, output.FullName, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncTokenCommaAfter, output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncTokenCommaAfter, output.FullName, ""));
            });
            Out.Add(CodeReplacements_GenericParamsOutput("Func", "U", ""));
            Out.Add(CodeReplacements_Args("(", ")", " =>"));
            Out.Add(CodeReplacements_Args("(", ")", ";"));
            Out.Add(CodeReplacements_Args(ArgumentToken, "", ""));
            Out.Add(CodeReplacements_Args(ArgumentTokenCommaAfter, "", ""));
            Out.Add(CodeReplacements_Args(ArgumentTokenCommaBefore, "", ""));
            return Out;
        }).Cache("CodeExplode_ExplodeLogic_CodeReplacements");
        #endregion

        public virtual List<List<string>> Replacements
            {
            get
                {
                if (this._Replacements == null)
                    {
                    this._Replacements = new List<List<string>>();
                    this._Replacements.AddRange(Logic_CodeReplacements(new[] { typeof(bool) }));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName + MethodActionToken));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName + MethodFuncToken));
                    this._Replacements.Add(CodeReplacements_GenericParams("[MethodName]", "()\r\n"));
                    this._Replacements.Add(CodeReplacements_GenericParams($"[MethodName]{MethodActionToken}", "()\r\n"));
                    this._Replacements.Add(CodeReplacements_GenericParamsOutput($"[MethodName]{MethodFuncToken}", "U", "()\r\n"));
                    }

                this._Replacements = this.Cutoff(this._Replacements);

                return this._Replacements;
                }
            }
        protected List<List<string>> Cutoff(List<List<string>> Replacements)
            {
            return Replacements.Collect(l => l.Count > this.MaximumGeneric ? l.First(this.MaximumGeneric) : l);

            }
        }
    }