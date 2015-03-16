using System;
using System.Collections.Generic;
using System.Text;

namespace LCore.Dynamic
    {
    public class CodeExplodeGenerics : CodeExplodeMember
        {
        public CodeExplodeGenerics(String Name = "", String Comments = "", int MaximumGeneric = CodeExplode_ExplodeLogic.ExplodeCount)
            : base(Name, Comments)
            {
            this.MaximumGeneric = MaximumGeneric;
            }

        private List<List<string>> _Replacements = null;
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
        public static String[] SubtractGenericType = new String[16].CollectI((i, s) => { return "/*-T" + (i + 1) + "*/"; });
        public static String[] SubtractArgumentType = new String[16].CollectI((i, s) => { return "/*-O" + (i + 1) + "*/"; });

        public static Func<String, Boolean> ContainsMultiLevelTokens = (In) =>
        {
            return In.ContainsAny(L.List<String>(
                GenericActionToken_Layer2,
                GenericFuncToken_Layer2,
                SubtractGenericType_Layer2,
                SubtractArgumentType_Layer2)());
        };
        public static Func<String, String> RemoveGenericComments = (In) =>
        {
            L.Array<String>(
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
            .Add(CodeExplodeGenerics.SubtractGenericType)
            .Add(CodeExplodeGenerics.SubtractArgumentType)
                      .Each((s) => { In = In.ReplaceAll(s, ""); });
            return In;
        };
        #region GetLevel2Replacements

        public static Func<List<List<String>>> GetLevel2Replacements = () =>
        {
            List<List<String>> Out = new List<List<String>>();
            Out.Add(CodeReplacements_GenericParams(GenericActionToken_Layer2, ""));
            Out.Add(CodeReplacements_GenericParamsOutput(GenericFuncToken_Layer2, "U", ""));
            Out.Add(CodeReplacements_Args(ArgumentToken_Layer2, "", ""));
            Out.Add(CodeReplacements_GenericParams(MethodActionToken, ""));
            Out.Add(CodeReplacements_GenericParamsOutput(MethodFuncToken, "U", ""));
            Out.AddRange(Logic_CodeReplacements(new Type[] { }));
            return Out;
        };
        #endregion
        #region CodeReplacements_FieldToMethod
        public static Func<String, List<List<String>>> CodeReplacements_FieldToMethod = (Name) =>
        {
            List<List<String>> Out = new List<List<String>>();
            String Search = Name + " = (";
            String Replace = Name + "()\r\n{\r\n return (";
            Out.Add(L.List(Search, Replace)());
            String Search2 = Name + MethodActionToken + " = (";
            String Replace2 = Name + MethodActionToken + "()\r\n{\r\n return (";
            Out.Add(L.List(Search2, Replace2)());
            String Search3 = Name + MethodFuncToken + " = (";
            String Replace3 = Name + MethodFuncToken + "()\r\n{\r\n return (";
            Out.Add(L.List(Search3, Replace3)());
            return Out;
        };
        #endregion
        #region CodeReplacements_GenericParams
        public static Func<String, String, List<String>> CodeReplacements_GenericParams = L.F<String, String, List<String>>((PreStr, PostStr) =>
        {
            Boolean PrefixComma = PreStr.Contains(GenericActionTokenCommaBefore) || PreStr == GenericActionTokenCommaBefore;
            Boolean SuffixComma = PreStr.Contains(GenericActionTokenCommaAfter) || PreStr == GenericActionTokenCommaAfter;
            Boolean IncludeBraces = !PrefixComma && !SuffixComma;
            Boolean PrefixI = PreStr.Contains(GenericActionTokenI) || PreStr == GenericActionTokenI;
            int i = 0;
            return L.F<String>(() =>
            {
                String Generics = "";
                if (i > 0)
                    {
                    Generics = (IncludeBraces ? "<" : "") +
                        new String[i].CollectI((i2, s) => { return "T" + (i2 + 1); }).Combine(", ")
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
        public static Func<String, String, String, List<String>> CodeReplacements_GenericParamsOutput = L.F<String, String, String, List<String>>((PreStr, OutputType, PostStr) =>
        {
            Boolean PrefixComma = PreStr.Contains(GenericFuncTokenCommaBefore) || PreStr == GenericFuncTokenCommaBefore;
            Boolean SuffixComma = PreStr.Contains(GenericFuncTokenCommaAfter) || PreStr == GenericFuncTokenCommaAfter;
            Boolean IncludeBraces = !PrefixComma && !SuffixComma;
            Boolean PrefixI = PreStr.Contains(GenericFuncTokenI) || PreStr == GenericFuncTokenI;
            int i = 0;
            return L.F<String>(() =>
            {
                String Generics = "";
                if (i > 0)
                    {
                    Generics = (IncludeBraces ? "<" : "") +
                        new String[i + 1].CollectI((i2, s) =>
                        {
                            if (i2 - 1 == i - 1)
                                return OutputType;
                            return "T" + (i2 + 1);
                        }).Combine(", ")
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
        public static Func<String, String, String, List<String>> CodeReplacements_Args = (PreArgs, PostArgs, EndStr) =>
        {
            Boolean PrefixComma = PreArgs.Contains(ArgumentTokenCommaBefore) || PreArgs == ArgumentTokenCommaBefore;
            Boolean SuffixComma = PreArgs.Contains(ArgumentTokenCommaAfter) || PreArgs == ArgumentTokenCommaAfter;
            int i = 0;
            return L.F<String>(() =>
            {
                String Out = "";
                if (i > 0)
                    {
                    Out = (!PreArgs.IsEmpty() ? PreArgs + (PreArgs != "(" &&
                        PreArgs != "(" + CodeExplodeGenerics.ArgumentToken &&
                        PreArgs != CodeExplodeGenerics.ArgumentToken &&
                        PreArgs != CodeExplodeGenerics.ArgumentTokenCommaAfter &&
                        PreArgs != CodeExplodeGenerics.ArgumentTokenCommaBefore &&
                        PreArgs != CodeExplodeGenerics.ArgumentToken_Layer2 ?
                        ", " : "") : "") +
                        new String[i].CollectI((i2, s) =>
                        {
                            return "o" + (i2 + 1);
                        }).Combine(", ")
                        + (!PostArgs.IsEmpty() ? (PostArgs != ")" && PostArgs != CodeExplodeGenerics.ArgumentToken + ")" &&
                        PostArgs != CodeExplodeGenerics.ArgumentToken &&
                        PostArgs != CodeExplodeGenerics.ArgumentTokenCommaAfter &&
                        PostArgs != CodeExplodeGenerics.ArgumentToken_Layer2 &&
                        PostArgs != CodeExplodeGenerics.ArgumentTokenCommaBefore ? ", " : "") + PostArgs : "") + EndStr;
                    }
                else
                    {
                    if (!PreArgs.IsEmpty() &&
                        !PostArgs.IsEmpty() &&
                        PreArgs != "(" &&
                        PreArgs != "(" + CodeExplodeGenerics.ArgumentToken &&
                        PreArgs != CodeExplodeGenerics.ArgumentToken &&
                        PreArgs != CodeExplodeGenerics.ArgumentTokenCommaAfter &&
                        PreArgs != CodeExplodeGenerics.ArgumentTokenCommaBefore &&
                        PreArgs != CodeExplodeGenerics.ArgumentToken_Layer2 &&
                        PostArgs != ")" &&
                        PostArgs != CodeExplodeGenerics.ArgumentToken + ")" &&
                        PostArgs != CodeExplodeGenerics.ArgumentToken &&
                        PostArgs != CodeExplodeGenerics.ArgumentToken_Layer2 &&
                        PostArgs != CodeExplodeGenerics.ArgumentTokenCommaAfter &&
                        PostArgs != CodeExplodeGenerics.ArgumentTokenCommaBefore)
                        {
                        Out = PreArgs + ", " + PostArgs + EndStr;
                        }
                    else
                        {
                        Out = PreArgs + PostArgs + EndStr;
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
        public static Func<Type[], List<List<String>>> Logic_CodeReplacements = L.F<Type[], List<List<String>>>((OutputParams) =>
        {
            List<List<String>> Out = new List<List<String>>();
            Out.Add(CodeReplacements_GenericParams(CodeExplodeGenerics.MethodActionToken, "("));
            Out.Add(CodeReplacements_GenericParams(CodeExplodeGenerics.MethodActionToken, " = ("));
            Out.Add(CodeReplacements_GenericParams(CodeExplodeGenerics.GenericActionToken, ""));
            Out.Add(CodeReplacements_GenericParams(CodeExplodeGenerics.GenericActionTokenCommaBefore, ""));
            Out.Add(CodeReplacements_GenericParams(CodeExplodeGenerics.GenericActionTokenCommaAfter, ""));
            Out.Add(CodeReplacements_GenericParams(CodeExplodeGenerics.GenericActionTokenI, ""));
            Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.MethodFuncToken, "U", "("));
            Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.MethodFuncToken, "U", " = ("));
            Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncToken, "U", ""));
            Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenCommaBefore, "U", ""));
            Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenCommaAfter, "U", ""));
            Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenI, "U", ""));
            Out.Add(CodeReplacements_GenericParams("Action", "]"));
            Out.Add(CodeReplacements_GenericParams("Action", ">"));
            Out.Add(CodeReplacements_GenericParams("Action", ","));
            OutputParams.Each((output) =>
            {
                Out.Add(CodeReplacements_GenericParamsOutput("Func", output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput("Func", output.FullName, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncToken, output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncToken, output.FullName, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenCommaBefore, output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenCommaBefore, output.FullName, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenCommaAfter, output.Name, ""));
                Out.Add(CodeReplacements_GenericParamsOutput(CodeExplodeGenerics.GenericFuncTokenCommaAfter, output.FullName, ""));
            });
            Out.Add(CodeReplacements_GenericParamsOutput("Func", "U", ""));
            Out.Add(CodeReplacements_Args("(", ")", " =>"));
            Out.Add(CodeReplacements_Args("(", ")", ";"));
            Out.Add(CodeReplacements_Args(CodeExplodeGenerics.ArgumentToken, "", ""));
            Out.Add(CodeReplacements_Args(CodeExplodeGenerics.ArgumentTokenCommaAfter, "", ""));
            Out.Add(CodeReplacements_Args(CodeExplodeGenerics.ArgumentTokenCommaBefore, "", ""));
            return Out;
        }).Cache("CodeExplode_ExplodeLogic_CodeReplacements");
        #endregion

        public virtual List<List<string>> Replacements
            {
            get
                {
                if (_Replacements == null)
                    {
                    _Replacements = new List<List<string>>();
                    _Replacements.AddRange(CodeExplodeGenerics.Logic_CodeReplacements(new Type[] { typeof(Boolean) }));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName + MethodActionToken));
                    //                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_FieldToMethod(this.MethodName + MethodFuncToken));
                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_GenericParams("[MethodName]", "()\r\n"));
                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_GenericParams("[MethodName]" + MethodActionToken, "()\r\n"));
                    _Replacements.Add(CodeExplodeGenerics.CodeReplacements_GenericParamsOutput("[MethodName]" + MethodFuncToken, "U", "()\r\n"));
                    }

                _Replacements = Cutoff(_Replacements);

                return _Replacements;
                }
            }
        protected List<List<String>> Cutoff(List<List<String>> Replacements)
            {
            return Replacements.Collect((l) =>
                    {
                        if (l.Count > MaximumGeneric)
                            return l.First(MaximumGeneric);
                        return l;
                    });

            }
        }
    }