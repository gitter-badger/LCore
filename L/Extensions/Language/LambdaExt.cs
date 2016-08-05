using System;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using LCore.Extensions.Optional;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Dynamic
    {
    /// <summary>
    /// Provides internal methods to take a Type or MemberInfo and 
    /// return a string representation of methods, properties, etc.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class LambdaExt
        {
        #region Extensions +

        internal static string GetLambdas(this Type In, Type[] Types)
            {
            return L.Lam.TypeGetLambdas(In, Types);
            }

        internal static string GetAllLambdas(this Type In)
            {
            return L.Lam.TypeGetAllLambdas(In);
            }

        internal static string GetLambdas(this FieldInfo In)
            {
            return L.Lam.FieldInfoGetLambdaStrings(In).Keys.Combine('\n');
            }

        internal static string GetLambdas(this PropertyInfo In)
            {
            return L.Lam.PropertyInfoGetLambdaStrings(In).Keys.Combine('\n');
            }

        internal static string GetLambdas(this MethodBase In)
            {
            return L.Lam.MethodBaseGetLambdaString(In, In.DeclaringType).Keys.Combine('\n');
            }

        #endregion
        }

    }

namespace LCore.Extensions
    {
    public static partial class L
        {
        [ExcludeFromCodeCoverage]
        internal static class Lam
            {
            internal static readonly Type[] AllLambdaTypes = Ary.Array(typeof(FieldInfo), typeof(PropertyInfo), typeof(MethodInfo), typeof(ConstructorInfo))();

            #region GetLambdas
            internal static readonly Func<Type, Type[], string> TypeGetLambdas = (Type, FieldTypes) =>
            {
                var Out = new Dictionary<string, string>();
                Func<KeyValuePair<string, string>, KeyValuePair<string, string>> IncrementFunctionNames = o =>
                {
                    if (o.Value.StartsWith("/*"))
                        {
                        return new KeyValuePair<string, string>($"/*{o.Key}*/", o.Value);
                        }

                    int Index = 1;
                    while (Out.ContainsKey(Index == 1 ? o.Key : o.Key + Index)) { Index++; }
                    if (Index > 1)
                        {
                        return new KeyValuePair<string, string>(o.Key + Index,
                        o.Value.Replace($" {o.Key} =", $" {o.Key}{Index} ="));
                        }
                    return o;
                };

                if (FieldTypes.Has(typeof(FieldInfo)))
                    Type.GetFields().List()
                    .Convert(FieldInfoGetLambdaStrings)
                    .Each(Dict => { Out.Merge(Dict, IncrementFunctionNames); });
                if (FieldTypes.Has(typeof(PropertyInfo)))
                    Type.GetProperties().List()
                    .Convert(PropertyInfoGetLambdaStrings)
                    .Each(Dict => { Out.Merge(Dict, IncrementFunctionNames); });
                if (FieldTypes.Has(typeof(MethodInfo)))
                    Type.GetMethods()
                    .Convert(MethodInfoGetLambdaString.Supply2(Type))
                    .Each(Dict => { Out.Merge(Dict, IncrementFunctionNames); });
                if (FieldTypes.Has(typeof(ConstructorInfo)))
                    Type.GetConstructors().List<MethodBase>()
                    .Convert(MethodBaseGetLambdaString.Supply2(Type))
                    .Each(Dict => { Out.Merge(Dict, IncrementFunctionNames); });

                string Out2 =
                    $"#region {Type.Name}\npublic static class {Type.Name}\n{{\n{Out.Values.Combine('\n').ReplaceAll("\n\n", "\n")}\n}}\n#endregion";

                //                Type[] Interfaces = t.GetInterfaces();
                //                Interfaces.Each((t2) => { Out2 += $"\n{t2.GetLambdas(AllLambdaTypes)}"; });
                return Out2;
            };
            #endregion
            #region GetAllLambdas
            internal static readonly Func<Type, string> TypeGetAllLambdas = TypeGetLambdas.Supply2(AllLambdaTypes);
            #endregion
            #region PropertyInfo
            internal static readonly Func<PropertyInfo, Dictionary<string, string>> PropertyInfoGetLambdaStrings = Prop =>
            {
                bool Index = false;
                string MethodType = Prop.DeclaringType?.Name;
                string FieldType = Prop.PropertyType.Name;
                string FieldName = Prop.Name;
                var IndexParameter = Prop.GetIndexParameters().First();
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
                    var Getter = Prop.GetGetMethod();
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
                    var Setter = Prop.GetSetMethod();
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
            internal static readonly Func<FieldInfo, Dictionary<string, string>> FieldInfoGetLambdaStrings = Field =>
            {
                string MethodType = Field.DeclaringType?.Name;
                string FieldType = Field.FieldType.Name;
                string FieldName = Field.Name;
                string FunctionGetName = $"{MethodType}_Get{FieldName}";
                string FunctionSetName = $"{MethodType}_Set{FieldName}";
                bool IsConst = Field.IsLiteral || Field.IsInitOnly;
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
            internal static readonly Func<MethodBase, Type, Dictionary<string, string>> MethodBaseGetLambdaString = (Method, Type) =>
            {
                ParameterInfo[] Params = Method.GetParameters();
                bool IsConstructor = Method is ConstructorInfo;
                var Info = Method as MethodInfo;
                var ReturnType = Info?.ReturnType ?? (IsConstructor ? ((ConstructorInfo)Method).DeclaringType : typeof(void));
                string[] TypeNames = Params.Convert(Param => Param.ParameterType.Name);
                string[] ParamNames = Params.Convert(Param => Param.Name);
                string ReturnTypeStr = ReturnType.TypeEquals(typeof(void)) ? "" : ReturnType.Name;
                string MethodType = ReturnType.TypeEquals(typeof(void)) ? "Action" : "Func";
                string DeclaringType = Method.DeclaringType?.Name;
                string MethodName = Method.Name;
                string FunctionName = $"{DeclaringType}_{MethodName}";

                if (MethodName.StartsWith("get_") ||
                    MethodName.StartsWith("set_"))
                    return new Dictionary<string, string>();
                string[] FunctionStrings = ParamNames;
                if (!Method.IsStatic && !IsConstructor)
                    {
                    TypeNames = new[] { DeclaringType }.Add(TypeNames);
                    DeclaringType = DeclaringType?.ToLower()[0].ToString();
                    ParamNames = new[] { DeclaringType }.Add(ParamNames);
                    }

                if (!ReturnTypeStr.IsEmpty())
                    TypeNames = TypeNames.Add(ReturnTypeStr);
                var TempFound = new List<string>();
                string ParamString = ParamNames.Collect(Str =>
                    {
                        if (!TempFound.Contains(Str))
                            return Str;
                            {
                            Str = Str + TempFound.Count(Str.FN_If()).ToString();
                            TempFound.Add(Str);
                            return Str;
                            }
                    }).Combine(", ");
                TempFound = new List<string>();
                string FunctionString = FunctionStrings.Collect(Str =>
                {
                    if (!TempFound.Contains(Str))
                        return Str;
                    Str = Str + TempFound.Count(Str.FN_If()).ToString();
                    TempFound.Add(Str);
                    return Str;
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
                else if (!IsConstructor && !Method.GetGenericArguments().IsEmpty() || Out.Has('`'))
                    Out = $"/* No Generic Types \n{Out}\n*/";
                else if (!Method.DeclaringType.TypeEquals(Type))
                    Out = $"/* Method found on base type \n{Out}\n*/";
                else if (Out.Contains("&"))
                    Out = $"/* No Ref or Out Types \n{Out}\n*/";

                Out2.Add(FunctionName, Out);
                return Out2;
            };
            internal static readonly Func<MethodInfo, Type, Dictionary<string, string>> MethodInfoGetLambdaString = MethodBaseGetLambdaString;
            #endregion

            internal const uint ParameterLimit = 4;
            }
        }
    }