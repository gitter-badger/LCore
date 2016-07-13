using System;

using LCore.Tools;
using System.Collections.Generic;
using System.Reflection;

namespace LCore.Extensions
    {
    public static partial class L
        {
        internal static class Lang
            {
            #region RemoveTypeNamespaces
            internal static readonly Func<string, string> RemoveTypeNamespaces = Str =>
            {
                while (Str.Has('.'))
                    {
                    int Index = Str.IndexOf('.');
                    string Temp = Str.Substring(0, Index);
                    int IndexSpace = Temp.LastIndexOfAny(SeparatorChars);
                    if (IndexSpace < 0)
                        {
                        Str = Str.Substring(Index + 1);
                        }
                    else
                        {
                        Str = Str.Substring(0, IndexSpace + 1) + Str.Substring(Index + 1);
                        }
                    }
                return Str;
            };
            #endregion
            #region CleanGenericTypeName
            internal static readonly Func<string, string> CleanGenericTypeName = Str =>
            {
                Str = Str.Replace("`1[", "<");
                Str = Str.Replace("`2[", "<");
                Str = Str.Replace("`3[", "<");
                Str = Str.Replace("`4[", "<");
                Str = Str.Replace("`5[", "<");
                Str = Str.Replace("`6[", "<");
                Str = Str.Replace("`7[", "<");
                Str = Str.Replace("`8[", "<");
                Str = Str.Replace("`9[", "<");
                Str = Str.Replace("`10[", "<");
                Str = Str.Replace("`11[", "<");
                Str = Str.Replace("`12[", "<");
                Str = Str.Replace("`13[", "<");
                Str = Str.Replace("`14[", "<");
                Str = Str.Replace("`15[", "<");
                Str = Str.Replace("`16[", "<");
                Str = Str.Replace("`17[", "<");
                Str = Str.Replace("Action`10", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>");
                Str = Str.Replace("Action`11", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>");
                Str = Str.Replace("Action`12", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>");
                Str = Str.Replace("Action`13", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>");
                Str = Str.Replace("Action`14", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>");
                Str = Str.Replace("Action`15", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>");
                Str = Str.Replace("Action`16", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>");
                Str = Str.Replace("Action`1", "Action<T1>");
                Str = Str.Replace("Action`2", "Action<T1,T2>");
                Str = Str.Replace("Action`3", "Action<T1,T2,T3>");
                Str = Str.Replace("Action`4", "Action<T1,T2,T3,T4>");
                Str = Str.Replace("Action`5", "Action<T1,T2,T3,T4,T5>");
                Str = Str.Replace("Action`6", "Action<T1,T2,T3,T4,T5,T6>");
                Str = Str.Replace("Action`7", "Action<T1,T2,T3,T4,T5,T6,T7>");
                Str = Str.Replace("Action`8", "Action<T1,T2,T3,T4,T5,T6,T7,T8>");
                Str = Str.Replace("Action`9", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9>");
                Str = Str.Replace("Func`10", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,U>");
                Str = Str.Replace("Func`11", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,U>");
                Str = Str.Replace("Func`12", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,U>");
                Str = Str.Replace("Func`13", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,U>");
                Str = Str.Replace("Func`14", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,U>");
                Str = Str.Replace("Func`15", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,U>");
                Str = Str.Replace("Func`16", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,U>");
                Str = Str.Replace("Func`17", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,U>");
                Str = Str.Replace("Func`1", "Func<U>");
                Str = Str.Replace("Func`2", "Func<T1,U>");
                Str = Str.Replace("Func`3", "Func<T1,T2,U>");
                Str = Str.Replace("Func`4", "Func<T1,T2,T3,U>");
                Str = Str.Replace("Func`5", "Func<T1,T2,T3,T4,U>");
                Str = Str.Replace("Func`6", "Func<T1,T2,T3,T4,T5,U>");
                Str = Str.Replace("Func`7", "Func<T1,T2,T3,T4,T5,T6,U>");
                Str = Str.Replace("Func`8", "Func<T1,T2,T3,T4,T5,T6,T7,U>");
                Str = Str.Replace("Func`9", "Func<T1,T2,T3,T4,T5,T6,T7,T8,U>");
                Str = Str.Replace("[]", "***");
                Str = Str.Replace("]", ">");
                Str = Str.Replace("[", ">");
                Str = Str.Replace("***", "[]");
                return RemoveTypeNamespaces(Str);
            };
            #endregion

            internal static readonly string[] GenericInputTypes = { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16" };
            internal static readonly string[] GenericOutputTypes = { "U" };
            internal static readonly string[] GenericTypes = { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16", "U" };
            internal static readonly string[] OpenSequences = { "[", "{", "(", "<", "\'", "\"", "/*", "//" };
            internal static readonly string[] CloseSequences = { "]", "}", ")", ">", "\'", "\"", "*/", "\r\n" };
            internal static readonly char[] SeparatorChars = { ' ', ',', '<', '>', '(', ')', '{', '}', '[', ']', '-', '+', '.', '/', '*', '-', '&', '^', '%', '=', '?' };

            #region GetAssemblyTypesWithAttribute
            internal static readonly Func<Type, List<Type>> GetAssemblyTypesWithAttribute = Attr =>
            {
                return Assembly.GetCallingAssembly().GetModules()
                    .Convert(Module =>
                        {
                            return Module.GetTypes().Select(Type =>
                            {
                                return Attr.TypeEquals(typeof(void)) || Type.HasAttribute(Attr, true);
                            });
                        })
                    .Flatten<Type>();
            };
            #endregion
            #region GetAssemblyTypes
            internal static Func<List<Type>> GetAssemblyTypes = GetAssemblyTypesWithAttribute.Supply(typeof(void));
            #endregion
            #region ReplaceNativeTypes
            internal static readonly Func<string, string> ReplaceNativeTypes = Str =>
            {
                Str = Str.Replace("System.Double", "double");
                Str = Str.Replace("System.UInt32", "uint");
                Str = Str.Replace("System.Int32", "int");
                Str = Str.Replace("System.Single", "float");
                Str = Str.Replace("System.Boolean", "bool");
                Str = Str.Replace("Double", "double");
                Str = Str.Replace("UInt32", "uint");
                Str = Str.Replace("Int32", "int");
                Str = Str.Replace("Single", "float");
                Str = Str.Replace("Boolean", "bool");
                return Str;
            };
            #endregion
            #region CommentSummary
            internal static readonly Func<string, string> CommentSummary =
                In => In.Replace("\r\n", "\r\n/// ").Surround("/// <summary>\r\n/// ", "\r\n/// </summary>\r\n");
            #endregion
            #region Class
            internal static readonly Func<string, string, bool, string> Class =
                (In, ClassName, Static) => In.Surround(
                $"public {(Static ? "static " : "")}class {ClassName}\r\n{{\r\n", "}\r\n");
            #endregion
            #region Using
            internal static readonly Func<string[], string, string> Using = (Using, In) =>
            {
                if (Using.IsEmpty() || In.IsEmpty())
                    return In;

                string Out = "";
                Using.Each(Str =>
                {
                    Out += $"using {Str};\r\n";
                });
                Out += "\r\n";
                Out += In;
                return Out;
            };

            #endregion
            #region Namespace
            internal static readonly Func<string, string, string> Namespace = (In, NamespaceName) => In.Surround(
                $"namespace {NamespaceName}\r\n{{\r\n",
                "}\r\n");
            #endregion
            #region Region
            internal static readonly Func<string, string, string> Region = (In, Region) => In.Surround(
                $"#region {Region}\r\n",
                "#endregion\r\n");
            #endregion
            #region GetGenericsFromTypes
            internal static readonly Func<string[], List<string>> GetGenericsFromTypes = Generics =>
                {
                    var Out = new List<string>();
                    Generics.Each(Generic =>
                    {
                        Out.AddRange(GetTypeGenerics(Generic));
                    });

                    Out = Out.RemoveDuplicates();
                    Out = Out.Select(Str => GenericTypes.Has(Str)).List();
                    Out.Sort(Str.NumericalCompare);
                    return Out;
                };
            #endregion
            #region GetTypeGenerics
            internal static readonly Func<string, List<string>> GetTypeGenerics = TypeStr =>
            {
                string Out = TypeStr.Has('<') ? TypeStr.Substring(TypeStr.LastIndexOf('<') + 1, TypeStr.LastIndexOf('>') - TypeStr.LastIndexOf('<') - 1) : "";
                if (Out.Has(','))
                    return Out.Split(',').List().Collect(Str =>
                        {
                            if (Str == "T")
                                return "T1";
                            return Str == "" ? null : Str.Trim();
                        });
                return !Out.IsEmpty() ? new List<string> { Out } : new List<string>();
            };
            #endregion
            #region GetEmptyTypeLambdaMethods
            internal static Func<Type, string> GetEmptyTypeLambdaMethods = Type =>
                {
                    MethodInfo[] Methods = Type.GetMethods();
                    return Methods.Convert(GetEmptyLambdaFromMethod).Combine();
                };
            #endregion
            #region GetEmptyLambdaFromMethod
            internal static readonly Func<MethodInfo, string> GetEmptyLambdaFromMethod = Method =>
                {
                    string FunctionTypeName = CleanGenericTypeName(Method.ReturnType.ToString());
                    string ParameterTypes = Method.GetParameters().Convert(Param => CleanGenericTypeName(Param.ParameterType.ToString())).Combine(", ");
                    string ParameterNames = Method.GetParameters().Convert(Param => Param.Name).Combine(",  ");
                    List<string> Generics = GetGenericsFromTypes(ParameterTypes.Split(",  ").Add(FunctionTypeName));
                    bool ReadOnly = Generics.IsEmpty();
                    string BaseType = Method.ReturnType.TypeEquals(typeof(void)) ? "Action" : "Func";
                    if (!ParameterTypes.IsEmpty())
                        BaseType += $"<{ParameterTypes}";
                    if (!Method.ReturnType.TypeEquals(typeof(void)))
                        BaseType += $", {CleanGenericTypeName(Method.ReturnType.ToString())}";
                    BaseType += ">";

                    string Out = $"public static {(ReadOnly ? "readonly " : "")}";
                    Out += $"{BaseType} ";
                    Out += Method.Name;
                    if (!ReadOnly)
                        {
                        Out += $"<{Generics.Combine(", ")}>";
                        Out += "()\r\n";
                        Out += "{\r\n";
                        Out += "return ";
                        }
                    else
                        {
                        Out += " = ";
                        }
                    Out += $"({ParameterNames}) => \r\n";
                    Out += "{\r\n";
                    Out += "};\r\n";
                    if (!ReadOnly)
                        {
                        Out += "}\r\n";
                        }

                    if (Out.Contains(", )"))
                        {
                        }

                    return Out;
                };
            #endregion
            #region GetExtensionMethodDeclaration
            internal static readonly Func<string, Lists<string, Type>, Type, string, MemberTypes, bool, string> GetExtensionMethodDeclaration = (Name, Params, OutType, Comment, MemberType, ExecuteResult) =>
            {
                if (Params.List1.Count == 0 ||
                    Params.List2.Count == 0)
                    throw new ArgumentException("No Parameters found");
                string FunctionTypeName = CleanGenericTypeName(OutType.ToString());
                string ExtensionParam = CleanGenericTypeName(Params.List2[0].ToString());
                string Parameters = "";
                if (Params.Count > 1)
                    Parameters = 1.To(Params.Count - 1, i => { return CleanGenericTypeName(Params.List2[i].ToString()); }).Combine(",  ");

                List<string> Generics = GetGenericsFromTypes(Parameters.Split(",  ").Add(FunctionTypeName, ExtensionParam));

                string Out = $"public static {(ExecuteResult ? "void " : FunctionTypeName)}";
                Out += $" {Name}";


                if (!Generics.IsEmpty())
                    {
                    Out += $"<{Generics.Combine(", ")}>";
                    }

                Out += $"(this {ExtensionParam} {Params.List1[0]}";
                if (Params.Count > 1)
                    {
                    Out += ", ";
                    1.For(Params.Count, i =>
                    {
                        string ParamType = CleanGenericTypeName(Params.List2[i].ToString());
                        if (Params.List1[i].StartsWith("params"))
                            {
                            Out += "params ";
                            Params.Set1(i, Params.List1[i].Substring(7));
                            }
                        Out += $"{ParamType} {Params.List1[i]}";
                        if (i < Params.Count - 1)
                            Out += ", ";
                        return true;
                    });
                    }

                Out += ")\r\n";

                if (Out.Contains(", )"))
                    {
                    }

                if (!Comment.IsEmpty())
                    Out = CommentSummary(Comment) + Out;
                return Out;
            };
            #endregion
            #region GetExtensionMethodBody
            internal static readonly Func<Type, string, Lists<string, Type>, Type, MemberTypes, bool, string> GetExtensionMethodBody = (DeclaringType, Name, Params, ReturnType, MemberType, ExecuteResult) =>
            {

                string ExtensionParam = CleanGenericTypeName(Params.List2[0].ToString());
                string Parameters = "";
                if (Params.Count > 1)
                    Parameters = 1.To(Params.Count - 1, i => { return CleanGenericTypeName(Params.List2[i].ToString()); }).Combine(",  ");

                string FunctionTypeName = CleanGenericTypeName(ReturnType.ToString());
                List<string> Generics = GetGenericsFromTypes(Parameters.Split(",  ").Add(FunctionTypeName, ExtensionParam));

                string Out = "{\r\n";
                Out +=
                    $"{(!ReturnType.TypeEquals(typeof(void)) && !ExecuteResult ? "return " : "")}{DeclaringType.Name}.{Name}";

                if (!Generics.IsEmpty())
                    {
                    Out += $"<{Generics.Combine(", ")}>";
                    }

                Out +=
                    $"{(MemberType.HasFlag(MemberTypes.Method) ? "()" : "")}({Params.List1.List().Collect(Str => { if (Str.Contains(" = ")) Str = Str.Substring(0, Str.IndexOf(" = ")); return Str; }).Combine(", ")})";
                if (ExecuteResult)
                    Out += "()";
                Out += ";\r\n";

                Out += "}\r\n";
                return Out;
            };
            #endregion
            }
        }
    }