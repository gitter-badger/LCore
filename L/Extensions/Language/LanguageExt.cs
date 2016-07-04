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
            internal static readonly Func<string, string> RemoveTypeNamespaces = s =>
            {
                while (s.Has('.'))
                    {
                    int index = s.IndexOf('.');
                    string temp = s.Substring(0, index);
                    int indexspace = temp.LastIndexOfAny(SeparatorChars);
                    if (indexspace < 0)
                        {
                        s = s.Substring(index + 1);
                        }
                    else
                        {
                        s = s.Substring(0, indexspace + 1) + s.Substring(index + 1);
                        }
                    }
                return s;
            };
            #endregion
            #region CleanGenericTypeName
            internal static readonly Func<string, string> CleanGenericTypeName = s =>
            {
                s = s.Replace("`1[", "<");
                s = s.Replace("`2[", "<");
                s = s.Replace("`3[", "<");
                s = s.Replace("`4[", "<");
                s = s.Replace("`5[", "<");
                s = s.Replace("`6[", "<");
                s = s.Replace("`7[", "<");
                s = s.Replace("`8[", "<");
                s = s.Replace("`9[", "<");
                s = s.Replace("`10[", "<");
                s = s.Replace("`11[", "<");
                s = s.Replace("`12[", "<");
                s = s.Replace("`13[", "<");
                s = s.Replace("`14[", "<");
                s = s.Replace("`15[", "<");
                s = s.Replace("`16[", "<");
                s = s.Replace("`17[", "<");
                s = s.Replace("Action`10", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>");
                s = s.Replace("Action`11", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>");
                s = s.Replace("Action`12", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>");
                s = s.Replace("Action`13", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>");
                s = s.Replace("Action`14", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>");
                s = s.Replace("Action`15", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>");
                s = s.Replace("Action`16", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>");
                s = s.Replace("Action`1", "Action<T1>");
                s = s.Replace("Action`2", "Action<T1,T2>");
                s = s.Replace("Action`3", "Action<T1,T2,T3>");
                s = s.Replace("Action`4", "Action<T1,T2,T3,T4>");
                s = s.Replace("Action`5", "Action<T1,T2,T3,T4,T5>");
                s = s.Replace("Action`6", "Action<T1,T2,T3,T4,T5,T6>");
                s = s.Replace("Action`7", "Action<T1,T2,T3,T4,T5,T6,T7>");
                s = s.Replace("Action`8", "Action<T1,T2,T3,T4,T5,T6,T7,T8>");
                s = s.Replace("Action`9", "Action<T1,T2,T3,T4,T5,T6,T7,T8,T9>");
                s = s.Replace("Func`10", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,U>");
                s = s.Replace("Func`11", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,U>");
                s = s.Replace("Func`12", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,U>");
                s = s.Replace("Func`13", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,U>");
                s = s.Replace("Func`14", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,U>");
                s = s.Replace("Func`15", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,U>");
                s = s.Replace("Func`16", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,U>");
                s = s.Replace("Func`17", "Func<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,U>");
                s = s.Replace("Func`1", "Func<U>");
                s = s.Replace("Func`2", "Func<T1,U>");
                s = s.Replace("Func`3", "Func<T1,T2,U>");
                s = s.Replace("Func`4", "Func<T1,T2,T3,U>");
                s = s.Replace("Func`5", "Func<T1,T2,T3,T4,U>");
                s = s.Replace("Func`6", "Func<T1,T2,T3,T4,T5,U>");
                s = s.Replace("Func`7", "Func<T1,T2,T3,T4,T5,T6,U>");
                s = s.Replace("Func`8", "Func<T1,T2,T3,T4,T5,T6,T7,U>");
                s = s.Replace("Func`9", "Func<T1,T2,T3,T4,T5,T6,T7,T8,U>");
                s = s.Replace("[]", "***");
                s = s.Replace("]", ">");
                s = s.Replace("[", ">");
                s = s.Replace("***", "[]");
                return RemoveTypeNamespaces(s);
            };
            #endregion

            internal static readonly string[] GenericInputTypes = { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16" };
            internal static readonly string[] GenericOutputTypes = { "U" };
            internal static readonly string[] GenericTypes = { "T", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12", "T13", "T14", "T15", "T16", "U" };
            internal static readonly string[] OpenSequences = { "[", "{", "(", "<", "\'", "\"", "/*", "//" };
            internal static readonly string[] CloseSequences = { "]", "}", ")", ">", "\'", "\"", "*/", "\r\n" };
            internal static readonly char[] SeparatorChars = { ' ', ',', '<', '>', '(', ')', '{', '}', '[', ']', '-', '+', '.', '/', '*', '-', '&', '^', '%', '=', '?' };

            #region GetAssemblyTypesWithAttribute
            internal static readonly Func<Type, List<Type>> GetAssemblyTypesWithAttribute = attr =>
            {
                return Assembly.GetCallingAssembly().GetModules()
                    .Convert(mod =>
                        {
                            return mod.GetTypes().Select(t =>
                            {
                                return attr.TypeEquals(typeof(void)) || t.HasAttribute(attr, true);
                            });
                        })
                    .Flatten<Type>();
            };
            #endregion
            #region GetAssemblyTypes
            internal static Func<List<Type>> GetAssemblyTypes = GetAssemblyTypesWithAttribute.Supply(typeof(void));
            #endregion
            #region ReplaceNativeTypes
            internal static readonly Func<string, string> ReplaceNativeTypes = s =>
            {
                s = s.Replace("System.Double", "double");
                s = s.Replace("System.UInt32", "uint");
                s = s.Replace("System.Int32", "int");
                s = s.Replace("System.Single", "float");
                s = s.Replace("System.Boolean", "bool");
                s = s.Replace("Double", "double");
                s = s.Replace("UInt32", "uint");
                s = s.Replace("Int32", "int");
                s = s.Replace("Single", "float");
                s = s.Replace("Boolean", "bool");
                return s;
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
            internal static readonly Func<string[], string, string> Using = (Usings, In) =>
            {
                if (Usings.IsEmpty() || In.IsEmpty())
                    return In;

                string Out = "";
                Usings.Each(str =>
                {
                    Out += $"using {str};\r\n";
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
                    Generics.Each(g =>
                    {
                        Out.AddRange(GetTypeGenerics(g));
                    });

                    Out = Out.RemoveDuplicates();
                    Out = Out.Select(s => GenericTypes.Has(s)).List();
                    Out.Sort(Str.NumericalCompare);
                    return Out;
                };
            #endregion
            #region GetTypeGenerics
            internal static readonly Func<string, List<string>> GetTypeGenerics = TypeStr =>
            {
                string Out = TypeStr.Has('<') ? TypeStr.Substring(TypeStr.LastIndexOf('<') + 1, TypeStr.LastIndexOf('>') - TypeStr.LastIndexOf('<') - 1) : "";
                if (Out.Has(','))
                    return Out.Split(',').List().Collect(s =>
                        {
                            if (s == "T")
                                return "T1";
                            return s == "" ? null : s.Trim();
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
                    string ParameterTypes = Method.GetParameters().Convert(p => CleanGenericTypeName(p.ParameterType.ToString())).Combine(", ");
                    string ParameterNames = Method.GetParameters().Convert(p => p.Name).Combine(",  ");
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
                    $"{(MemberType.HasFlag(MemberTypes.Method) ? "()" : "")}({Params.List1.List().Collect(s => { if (s.Contains(" = ")) s = s.Substring(0, s.IndexOf(" = ")); return s; }).Combine(", ")})";
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