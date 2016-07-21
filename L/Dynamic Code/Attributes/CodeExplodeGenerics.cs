using System;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class CodeExplodeGenerics : CodeExplodeMember
        {
        public CodeExplodeGenerics(string Name = "", string Comments = "", uint MaximumGeneric = CodeExplodeLogic.ExplodeCount)
            : base(Name, Comments)
            {
            this._MaximumGeneric = MaximumGeneric;
            }

        private List<List<string>> _Replacements;
        private readonly uint _MaximumGeneric;

        public const string NoArgumentsToken = "/**/";

        public const string MethodActionToken = "/*MA*/";

        public const string MethodFuncToken = "/*MF*/";

        public const string ArgumentToken = "/*A*/";
        public const string ArgumentTokenCommaBefore = "/*,A*/";
        public const string ArgumentTokenCommaAfter = "/*A,*/";

        public const string GenericActionToken = "/*GA*/";
        public const string GenericActionTokenCommaBefore = "/*,GA*/";
        public const string GenericActionTokenCommaAfter = "/*GA,*/";

        public const string ArgumentTokenLayer2 = "/*X2A*/";
        public const string GenericActionTokenLayer2 = "/*X2GA*/";
        public const string GenericFuncTokenLayer2 = "/*X2GF*/";
        public const string SubtractGenericTypeLayer2 = "/*X2-TI*/";
        public const string SubtractArgumentTypeLayer2 = "/*X2-OI*/";

        public const string GenericActionTokenI = "/*IGA*/";

        public const string GenericFuncToken = "/*GF*/";
        public const string GenericFuncTokenCommaBefore = "/*,GF*/";
        public const string GenericFuncTokenCommaAfter = "/*GF,*/";
        public const string GenericFuncTokenI = "/*IGF*/";

        public static readonly string[] SubtractGenericType = new string[16].Collect((i, Str) => $"/*-T{i + 1}*/");
        public static readonly string[] SubtractArgumentType = new string[16].Collect((i, Str) => $"/*-O{i + 1}*/");

        public static readonly Func<string, bool> ContainsMultiLevelTokens = In => In.ContainsAny(L.List.ToList(
            GenericActionTokenLayer2,
            GenericFuncTokenLayer2,
            SubtractGenericTypeLayer2,
            SubtractArgumentTypeLayer2)());
        public static readonly Func<string, string> RemoveGenericComments = In =>
        {
            L.Ary.Array(
                MethodActionToken, MethodFuncToken,
                NoArgumentsToken, ArgumentToken,
                ArgumentTokenCommaAfter, ArgumentTokenCommaBefore,
                GenericActionToken, GenericActionTokenCommaAfter,
                GenericActionTokenCommaBefore, GenericActionTokenI,
                GenericFuncToken, GenericFuncTokenCommaAfter,
                GenericFuncTokenCommaBefore, GenericFuncTokenI,
                ArgumentTokenLayer2,
                GenericActionTokenLayer2,
                GenericFuncTokenLayer2,
                SubtractGenericTypeLayer2,
                SubtractArgumentTypeLayer2
            )()
            .Add(SubtractGenericType)
            .Add(SubtractArgumentType)
                      .Each(Str => { In = In.ReplaceAll(Str, ""); });
            return In;
        };
        #region GetLevel2Replacements

        public static readonly Func<List<List<string>>> GetLevel2Replacements = () =>
        {
            var Out = new List<List<string>>
            {
            CodeReplacementsGenericParams(GenericActionTokenLayer2, ""),
            CodeReplacementsGenericParamsOutput(GenericFuncTokenLayer2, "U", ""),
            CodeReplacementsArgs(ArgumentTokenLayer2, "", ""),
            CodeReplacementsGenericParams(MethodActionToken, ""),
            CodeReplacementsGenericParamsOutput(MethodFuncToken, "U", "")
            };
            Out.AddRange(LogicCodeReplacements(new Type[] { }));
            return Out;
        };
        #endregion
        #region CodeReplacements_FieldToMethod
        public static Func<string, List<List<string>>> CodeReplacementsFieldToMethod = Name =>
        {
            var Out = new List<List<string>>();
            string Search = $"{Name} = (";
            string Replace = $"{Name}()\r\n{{\r\n return (";
            Out.Add(L.List.ToList(Search, Replace)());
            string Search2 = $"{Name}{MethodActionToken} = (";
            string Replace2 = $"{Name}{MethodActionToken}()\r\n{{\r\n return (";
            Out.Add(L.List.ToList(Search2, Replace2)());
            string Search3 = $"{Name}{MethodFuncToken} = (";
            string Replace3 = $"{Name}{MethodFuncToken}()\r\n{{\r\n return (";
            Out.Add(L.List.ToList(Search3, Replace3)());
            return Out;
        };
        #endregion
        #region CodeReplacements_GenericParams
        public static readonly Func<string, string, List<string>> CodeReplacementsGenericParams = L.F<string, string, List<string>>((PreStr, PostStr) =>
        {
            bool PrefixComma = PreStr.Contains(GenericActionTokenCommaBefore) || PreStr == GenericActionTokenCommaBefore;
            bool SuffixComma = PreStr.Contains(GenericActionTokenCommaAfter) || PreStr == GenericActionTokenCommaAfter;
            bool IncludeBraces = !PrefixComma && !SuffixComma;
            bool PrefixI = PreStr.Contains(GenericActionTokenI) || PreStr == GenericActionTokenI;
            int Index = 0;
            return L.F(() =>
            {
                string Generics = "";
                if (Index > 0)
                    {
                    Generics = (IncludeBraces ? "<" : "") +
                        new string[Index].Collect((i2, Str) => $"T{i2 + 1}").Combine(", ")
                        + (IncludeBraces ? ">" : "");
                    }
                Index++;
                return (PrefixComma && Index > 1 ? ", " : "") +
                    (PrefixI && Index > 2 ? (Index - 1).ToString() : "") + PreStr + Generics + PostStr +
                    (SuffixComma && Index > 1 ? ", " : "");
            }).Collect((uint)CodeExplodeLogic.ExplodeCount)();
        });
        #endregion
        #region CodeReplacements_GenericParamsOutput
        public static readonly Func<string, string, string, List<string>> CodeReplacementsGenericParamsOutput = L.F<string, string, string, List<string>>((PreStr, OutputType, PostStr) =>
        {
            bool PrefixComma = PreStr.Contains(GenericFuncTokenCommaBefore) || PreStr == GenericFuncTokenCommaBefore;
            bool SuffixComma = PreStr.Contains(GenericFuncTokenCommaAfter) || PreStr == GenericFuncTokenCommaAfter;
            bool IncludeBraces = !PrefixComma && !SuffixComma;
            bool PrefixI = PreStr.Contains(GenericFuncTokenI) || PreStr == GenericFuncTokenI;
            int Index = 0;
            return L.F(() =>
            {
                string Generics;
                if (Index > 0)
                    {
                    Generics = (IncludeBraces ? "<" : "") +
                        new string[Index + 1].Collect((i2, Str) => i2 - 1 == Index - 1 ? OutputType : $"T{i2 + 1}").Combine(", ")
                        + (OutputType.IsEmpty() ? ", " : (IncludeBraces ? ">" : ""));
                    }
                else
                    Generics = (IncludeBraces ? "<" : "") + OutputType + (OutputType.IsEmpty() ? "" : (IncludeBraces ? ">" : ""));
                Index++;
                return (PrefixComma && Index > 1 ? ", " : "") +
                    (PrefixI && Index > 2 ? (Index - 1).ToString() : "")
                    + PreStr + Generics +
                     (SuffixComma && Index > 1 ? ", " : "");
            }).Collect((uint)CodeExplodeLogic.ExplodeCount)();
        });
        #endregion
        #region CodeReplacements_Args

        protected static readonly Func<string, string, string, List<string>> CodeReplacementsArgs = (PreArgs, PostArgs, EndStr) =>
        {
            bool PrefixComma = PreArgs.Contains(ArgumentTokenCommaBefore) || PreArgs == ArgumentTokenCommaBefore;
            bool SuffixComma = PreArgs.Contains(ArgumentTokenCommaAfter) || PreArgs == ArgumentTokenCommaAfter;
            int Index = 0;
            return L.F(() =>
            {
                string Out;
                if (Index > 0)
                    {
                    Out = (!PreArgs.IsEmpty() ? PreArgs + (PreArgs != "(" &&
                        PreArgs != $"({ArgumentToken}" &&
                        PreArgs != ArgumentToken &&
                        PreArgs != ArgumentTokenCommaAfter &&
                        PreArgs != ArgumentTokenCommaBefore &&
                        PreArgs != ArgumentTokenLayer2 ?
                        ", " : "") : "") +
                        new string[Index].Collect((i2, Str) => $"o{i2 + 1}").Combine(", ")
                        + (!PostArgs.IsEmpty() ? (PostArgs != ")" && PostArgs != $"{ArgumentToken})" &&
                        PostArgs != ArgumentToken &&
                        PostArgs != ArgumentTokenCommaAfter &&
                        PostArgs != ArgumentTokenLayer2 &&
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
                        PreArgs != ArgumentTokenLayer2 &&
                        PostArgs != ")" &&
                        PostArgs != $"{ArgumentToken})" &&
                        PostArgs != ArgumentToken &&
                        PostArgs != ArgumentTokenLayer2 &&
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
                Index++;
                return
                     (PrefixComma && Index > 1 ? ", " : "")
                    + Out +
                     (SuffixComma && Index > 1 ? ", " : "");
            }).Collect((uint)CodeExplodeLogic.ExplodeCount)();
        };
        #endregion
        #region Logic_CodeReplacements
        public static readonly Func<Type[], List<List<string>>> LogicCodeReplacements = L.F<Type[], List<List<string>>>(OutputParams =>
        {
            var Out = new List<List<string>>
            {
            CodeReplacementsGenericParams(MethodActionToken, "("),
            CodeReplacementsGenericParams(MethodActionToken, " = ("),
            CodeReplacementsGenericParams(GenericActionToken, ""),
            CodeReplacementsGenericParams(GenericActionTokenCommaBefore, ""),
            CodeReplacementsGenericParams(GenericActionTokenCommaAfter, ""),
            CodeReplacementsGenericParams(GenericActionTokenI, ""),
            CodeReplacementsGenericParamsOutput(MethodFuncToken, "U", "("),
            CodeReplacementsGenericParamsOutput(MethodFuncToken, "U", " = ("),
            CodeReplacementsGenericParamsOutput(GenericFuncToken, "U", ""),
            CodeReplacementsGenericParamsOutput(GenericFuncTokenCommaBefore, "U", ""),
            CodeReplacementsGenericParamsOutput(GenericFuncTokenCommaAfter, "U", ""),
            CodeReplacementsGenericParamsOutput(GenericFuncTokenI, "U", ""),
            CodeReplacementsGenericParams("Action", "]"),
            CodeReplacementsGenericParams("Action", ">"),
            CodeReplacementsGenericParams("Action", ",")
            };
            OutputParams.Each(Output =>
                {
                    Out.Add(CodeReplacementsGenericParamsOutput("Func", Output.Name, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput("Func", Output.FullName, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput(GenericFuncToken, Output.Name, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput(GenericFuncToken, Output.FullName, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput(GenericFuncTokenCommaBefore, Output.Name, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput(GenericFuncTokenCommaBefore, Output.FullName, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput(GenericFuncTokenCommaAfter, Output.Name, ""));
                    Out.Add(CodeReplacementsGenericParamsOutput(GenericFuncTokenCommaAfter, Output.FullName, ""));
                });
            Out.Add(CodeReplacementsGenericParamsOutput("Func", "U", ""));
            Out.Add(CodeReplacementsArgs("(", ")", " =>"));
            Out.Add(CodeReplacementsArgs("(", ")", ";"));
            Out.Add(CodeReplacementsArgs(ArgumentToken, "", ""));
            Out.Add(CodeReplacementsArgs(ArgumentTokenCommaAfter, "", ""));
            Out.Add(CodeReplacementsArgs(ArgumentTokenCommaBefore, "", ""));
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
                    this._Replacements.AddRange(LogicCodeReplacements(new[] { typeof(bool) }));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName + MethodActionToken));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName + MethodFuncToken));
                    this._Replacements.Add(CodeReplacementsGenericParams("[MethodName]", "()\r\n"));
                    this._Replacements.Add(CodeReplacementsGenericParams($"[MethodName]{MethodActionToken}", "()\r\n"));
                    this._Replacements.Add(CodeReplacementsGenericParamsOutput($"[MethodName]{MethodFuncToken}", "U", "()\r\n"));
                    }

                this._Replacements = this.Cutoff(this._Replacements);

                return this._Replacements;
                }
            }
        protected List<List<string>> Cutoff(List<List<string>> Replacements)
            {
            return Replacements.Collect(Replacement => 
                Replacement.Count > this._MaximumGeneric 
                ? Replacement.First(this._MaximumGeneric) 
                : Replacement);
            }
        }
    }