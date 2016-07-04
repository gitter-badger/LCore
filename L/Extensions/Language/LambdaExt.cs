using System;

using System.Collections.Generic;
using LCore.Extensions.Optional;
using System.Reflection;
using System.Linq;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides internal methods to take a Type or MemberInfo and 
    /// return a string representaion of methods, properties, etc.
    /// </summary>
    [ExtensionProvider]
    internal static class LambdaExt
        {
        #region Extensions +

        internal static string GetLambdas(this Type In, Type[] Types)
            {
            return L.Lam.Type_GetLambdas(In, Types);
            }

        internal static string GetAllLambdas(this Type In)
            {
            return L.Lam.Type_GetAllLambdas(In);
            }

        internal static string GetLambdas(this FieldInfo In)
            {
            return L.Lam.FieldInfo_GetLambdaStrings(In).Keys.Combine('\n');
            }

        internal static string GetLambdas(this PropertyInfo In)
            {
            return L.Lam.PropertyInfo_GetLambdaStrings(In).Keys.Combine('\n');
            }

        internal static string GetLambdas(this MethodBase In)
            {
            return L.Lam.MethodBase_GetLambdaString(In, In.DeclaringType).Keys.Combine('\n');
            }

        #endregion
        }

    public static partial class L
        {
        internal static class Lam
            {
            internal static readonly Type[] AllLambdaTypes = IEn.Array(typeof(FieldInfo), typeof(PropertyInfo), typeof(MethodInfo), typeof(ConstructorInfo))();

            #region GetLambdas
            internal static readonly Func<Type, Type[], string> Type_GetLambdas = (t, FieldTypes) =>
            {
                var Out = new Dictionary<string, string>();
                Func<KeyValuePair<string, string>, KeyValuePair<string, string>> IncrementFunctionNames = o =>
                {
                    if (o.Value.StartsWith("/*"))
                        {
                        return new KeyValuePair<string, string>($"/*{o.Key}*/", o.Value);
                        }

                    int i = 1;
                    while (Out.ContainsKey(i == 1 ? o.Key : o.Key + i)) { i++; }
                    if (i > 1)
                        {
                        return new KeyValuePair<string, string>(o.Key + i,
                        o.Value.Replace($" {o.Key} =", $" {o.Key}{i} ="));
                        }
                    return o;
                };

                if (FieldTypes.Contains(typeof(FieldInfo)))
                    t.GetFields().List()
                    .Convert(FieldInfo_GetLambdaStrings)
                    .Each(d => { Out.Merge(d, IncrementFunctionNames); });
                if (FieldTypes.Contains(typeof(PropertyInfo)))
                    t.GetProperties().List()
                    .Convert(PropertyInfo_GetLambdaStrings)
                    .Each(d => { Out.Merge(d, IncrementFunctionNames); });
                if (FieldTypes.Contains(typeof(MethodInfo)))
                    t.GetMethods()
                    .Convert(MethodInfo_GetLambdaString.Supply2(t))
                    .Each(d => { Out.Merge(d, IncrementFunctionNames); });
                if (FieldTypes.Contains(typeof(ConstructorInfo)))
                    t.GetConstructors().List<MethodBase>()
                    .Convert(MethodBase_GetLambdaString.Supply2(t))
                    .Each(d => { Out.Merge(d, IncrementFunctionNames); });

                string Out2 =
                    $"#region {t.Name}\npublic static class {t.Name}\n{{\n{Out.Values.Combine('\n').ReplaceAll("\n\n", "\n")}\n}}\n#endregion";

            //                Type[] Interfaces = t.GetInterfaces();
            //                Interfaces.Each((t2) => { Out2 += $"\n{t2.GetLambdas(AllLambdaTypes)}"; });
            return Out2;
            };
            #endregion
            #region GetAllLambdas
            internal static readonly Func<Type, string> Type_GetAllLambdas = Type_GetLambdas.Supply2(AllLambdaTypes);
            #endregion
            #region PropertyInfo
            internal static readonly Func<PropertyInfo, Dictionary<string, string>> PropertyInfo_GetLambdaStrings = p =>
            {
                bool Index = false;
                string MethodType = p.DeclaringType?.Name;
                string FieldType = p.PropertyType.Name;
                string FieldName = p.Name;
                var IndexParameter = p.GetIndexParameters().First();
                if (IndexParameter != null)
                    {
                    Index = true;
                    FieldName = "At";
                    }

                string FunctionGetName = $"{MethodType}_Get{FieldName}";
                string FunctionSetName = $"{MethodType}_Set{FieldName}";
                string ObjName = MethodType?.ToLower()[0].ToString();

                var Out = new Dictionary<string, string>();
                try
                    {
                    var Getter = p.GetGetMethod();
                    bool IsStatic = Getter.IsStatic;
                    if (!Getter.IsPublic)
                        throw new Exception();
                    string GetFunction =
                        $"public static Func<{(!IsStatic || Index ? $"{MethodType}, " : "")}{(Index ? $"{IndexParameter.ParameterType.Name}, " : "")}{FieldType}> {FunctionGetName} = ({(!IsStatic ? ObjName : "")}{(Index ? ", index" : "")}) => {{ return {(!IsStatic || Index ? ObjName : MethodType)}{(Index ? "[index]" : $".{FieldName}")}; }};";

                    Out.Add(FunctionGetName, GetFunction);
                    }
                catch { }
                try
                    {
                    var Setter = p.GetSetMethod();
                    bool IsStatic = Setter.IsStatic;
                    if (!Setter.IsPublic)
                        throw new Exception();
                    Out.Add(FunctionSetName,
                        $"public static Action<{(!IsStatic || Index ? $"{MethodType}, " : "")}{(Index ? $"{IndexParameter.ParameterType.Name}, " : "")}{FieldType}> {FunctionSetName} = ({ObjName}{(Index ? ", index" : "")}, {FieldType.ToLower()[0]}) => {{ {(!IsStatic || Index ? ObjName : MethodType)}{(Index ? "[index]" : $".{FieldName}")} = {FieldType.ToLower()[0]}; }};");
                    }
                catch { }
                return Out;
            };
            #endregion
            #region FieldInfo
            internal static readonly Func<FieldInfo, Dictionary<string, string>> FieldInfo_GetLambdaStrings = f =>
            {
                string MethodType = f.DeclaringType?.Name;
                string FieldType = f.FieldType.Name;
                string FieldName = f.Name;
                string FunctionGetName = $"{MethodType}_Get{FieldName}";
                string FunctionSetName = $"{MethodType}_Set{FieldName}";
                bool IsConst = f.IsLiteral || f.IsInitOnly;
                string ObjName = MethodType?.ToLower()[0].ToString();

                var Out = new Dictionary<string, string>
                {
                {
                    FunctionGetName,
                    $"public static Func<{(!IsConst ? $"{MethodType}, " : "")}{FieldType}> {FunctionGetName} = ({(!IsConst ? $"{ObjName}, " : "")}) => {{ return {(!IsConst ? ObjName : MethodType)}.{FieldName}; }};"
                }
                };
                if (!IsConst)
                    Out.Add(FunctionSetName,
                        $"public static Action<{MethodType}, {FieldType}> {FunctionSetName} = ({ObjName}, {FieldType.ToLower()[0]}) => {{ {MethodType}.{FieldName} = {FieldType.ToLower()[0]}; }};");
                return Out;
            };
            #endregion
            #region MethodInfo
            internal static readonly Func<MethodBase, Type, Dictionary<string, string>> MethodBase_GetLambdaString = (m, t) =>
            {
                ParameterInfo[] Params = m.GetParameters();
                bool IsConstructor = m is ConstructorInfo;
                var info = m as MethodInfo;
                var ReturnType = info?.ReturnType ?? (IsConstructor ? ((ConstructorInfo)m).DeclaringType : typeof(void));
                string[] TypeNames = Params.Convert(p => p.ParameterType.Name);
                string[] ParamNames = Params.Convert(p => p.Name);
                string ReturnTypeStr = ReturnType.TypeEquals(typeof(void)) ? "" : ReturnType.Name;
                string MethodType = ReturnType.TypeEquals(typeof(void)) ? "Action" : "Func";
                string DeclaringType = m.DeclaringType?.Name;
                string MethodName = m.Name;
                string FunctionName = $"{DeclaringType}_{MethodName}";

                if (MethodName.StartsWith("get_") ||
                    MethodName.StartsWith("set_"))
                    return new Dictionary<string, string>();
                string[] FunctionStrings = ParamNames;
                if (!m.IsStatic && !IsConstructor)
                    {
                    TypeNames = new[] { DeclaringType }.Add(TypeNames);
                    DeclaringType = DeclaringType?.ToLower()[0].ToString();
                    ParamNames = new[] { DeclaringType }.Add(ParamNames);
                    }

                if (!ReturnTypeStr.IsEmpty())
                    TypeNames = TypeNames.Add(ReturnTypeStr);
                var TempFound = new List<string>();
                string ParamString = ParamNames.Collect(s =>
                    {
                        if (!TempFound.Contains(s))
                            return s;
                            {
                            s = s + TempFound.Count(s.FN_If()).ToString();
                            TempFound.Add(s);
                            return s;
                            }
                    }).Combine(", ");
                TempFound = new List<string>();
                string FunctionString = FunctionStrings.Collect(s =>
                {
                    if (!TempFound.Contains(s))
                        return s;
                    s = s + TempFound.Count(s.FN_If()).ToString();
                    TempFound.Add(s);
                    return s;
                }).Combine(", ");

                string MethodAction = $"{DeclaringType}.{MethodName}({FunctionString})";

                if (MethodName.StartsWith("op_"))
                    {
                //    FunctionName = $"{DeclaringType}_{Ref.Language_CleanOperationFunctionName(MethodName)}";
                //    MethodAction = FunctionString.Replace(",", Ref.Language_CleanOperationFunctionAction(MethodName));
                    }
                else if (IsConstructor)
                    {
                    FunctionName = $"{DeclaringType}_New";
                    MethodAction = $"new {DeclaringType}({FunctionString})";
                    }
                string Out = $"public static {MethodType}";
                if (!TypeNames.IsEmpty())
                    Out += $"<{TypeNames.Combine(", ")}>";
                Out += $" {FunctionName} = ";
                Out += "(";
                Out += ParamString;
                Out += ") => {";
                if (!ReturnTypeStr.IsEmpty())
                    Out += " return ";
                Out += MethodAction;
                Out += "; };";

                var Out2 = new Dictionary<string, string>();

                if (ParamNames.Count() > ParameterLimit)
                    Out = $"/* Too Many Parameters :( \n{Out}\n*/";
                else if (!IsConstructor && !m.GetGenericArguments().IsEmpty() || Out.Contains('`'))
                    Out = $"/* No Generic Types \n{Out}\n*/";
                else if (!m.DeclaringType.TypeEquals(t))
                    Out = $"/* Method found on base type \n{Out}\n*/";
                else if (Out.Contains("&"))
                    Out = $"/* No Ref or Out Types \n{Out}\n*/";

                Out2.Add(FunctionName, Out);
                return Out2;
            };
            internal static readonly Func<MethodInfo, Type, Dictionary<string, string>> MethodInfo_GetLambdaString = MethodBase_GetLambdaString;
            #endregion

            internal const uint ParameterLimit = 4;
            }
        }
    }