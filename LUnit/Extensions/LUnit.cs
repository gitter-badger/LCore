using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions.Optional;

// ReSharper disable UnusedMember.Global

namespace LCore.LUnit
    {
    public static class LUnit
        {
        /// <summary>
        /// Attempts to resolve parameter types for a method test.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        public static void FixParameterTypes(MethodInfo Method, object[] Parameters)
            {
            Method.GetParameters().Each((i, Parameter) =>
                {
                if (Parameters.HasIndex(i))
                    {
                    var Param = Parameters[i];
                    FixObject(Method, Parameter.ParameterType, ref Param);
                    Parameters[i] = Param;
                    }
                });
            }

        /// <summary>
        /// Attempts to resolve a single parameter object.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        public static void FixObject([CanBeNull] MethodInfo SourceMethod, [CanBeNull] Type ObjectType, ref object Obj)
            {
            // Converts Arrays to Lists when the Method requires it.
            if (ObjectType != null &&
                ObjectType != typeof(void))
                {
                if (Obj != null)
                    {
                    var Array = Obj as Array;
                    if (Array != null)
                        {
                        Type[] Args = {Array.GetType().GetElementType()};
                        if (ObjectType == typeof(List<>).MakeGenericType(Args))
                            {
                            var ListType = typeof(List<>).MakeGenericType(Args);

                            var NewList = (IList) ListType.New();
                            Array.Each(Item => { NewList?.Add(Item); });

                            Obj = NewList;
                            }
                        }
                    else if (Obj is string && ObjectType.IsSubclassOf(typeof(Delegate)))
                        {
                        Obj = GetMethodDelegate(SourceMethod, ObjectType, (string) Obj);
                        }
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    else if (Obj is object[] && !ObjectType.IsType(typeof(object[])))
                        // ReSharper disable HeuristicUnreachableCode
                        {
                        Type[] Types = ((object[]) Obj).GetTypes();
                        ConstructorInfo[] ObjectConstructors = ObjectType.GetConstructors();
                        var Const = ObjectConstructors.First(Constructor =>
                            {
                            ParameterInfo[] Params = Constructor.GetParameters();
                            return Params.Length == Types.Length && Params.All((i2, Param) => Types[i2].IsType(Param.ParameterType));
                            });

                        if (Const != null)
                            {
                            Obj = Const.Invoke((object[]) Obj);
                            }
                        }
                    // ReSharper restore HeuristicUnreachableCode
                    else if (Obj is IConvertible && ObjectType == typeof(decimal))
                        {
                        Obj = ((IConvertible) Obj).ConvertTo<decimal>();
                        }
                    }
                }
            }

        [CanBeNull]
        public static object GetMethodDelegate([CanBeNull] MethodInfo SourceMethod, [CanBeNull] Type ObjectType,
            [CanBeNull] string MethodName)
            {
            if (SourceMethod == null || MethodName == null)
                return null;

            object Out;

            Type SourceType;
            string MemberName;

            if (MethodName.Contains("."))
                {
                List<string> Parts = MethodName.Split(".").List();

                MemberName = Parts.Last();
                Parts.RemoveAt(Parts.Count - 1);

                string TypeName = Parts.Last();
                Parts.RemoveAt(Parts.Count - 1);

                SourceType = L.Ref.FindType($"{Parts.Combine('.')}+{TypeName}");

                if (SourceType == null && Parts.Count == 1)
                    {
                    SourceType = L.Ref.FindType($"{SourceMethod.DeclaringType?.Namespace}.{Parts.Combine('.')}+{TypeName}");
                    }

                if (SourceType == null)
                    throw new Exception($"Could not find Source Type {MethodName}");
                }
            else
                {
                SourceType = SourceMethod.DeclaringType;
                MemberName = MethodName;
                }


            var Types = new List<Type>();
            var ReturnType = typeof(void);
            if (ObjectType != null)
                {
                Types = ObjectType.GetGenericArguments().List();
                if (ObjectType.FullName.ToLower().Contains("func"))
                    {
                    ReturnType = Types.Last();
                    Types.RemoveAt(Types.Count - 1);
                    }
                }

            var ValueLambda = SourceType?.GetMember(MemberName).Select(
                Member => ObjectType == null || Member.GetMemberType() == ObjectType).First();

            if (ValueLambda == null)
                {
                if (ReturnType != typeof(void))
                    {
                    ValueLambda = SourceType?.GetMember(MemberName).Select(
                        Member => ObjectType == null || Member.GetMemberType() == ReturnType).First();
                    }
                else
                    {
                    ValueLambda = SourceType?.GetMethod(MemberName, Types.ToArray());
                    }

                if (ValueLambda == null)
                    throw new Exception($"Could not find Source Method: {MethodName} with arguments: {Types.ToS()}");
                }

            var Info = ValueLambda as PropertyInfo;
            if (Info != null)
                {
                Out = Info.GetGetMethod().Invoke(null, new object[] {});
                }
            else if (ValueLambda is FieldInfo)
                {
                Out = ((FieldInfo) ValueLambda).GetValue(null);
                }
            else if (ValueLambda is MethodInfo)
                {
                ParameterInfo[] Params = ((MethodInfo) ValueLambda).GetParameters();
                if (Params.Length > 0)
                    {
                    throw new Exception($"Unknown member with arguments: {ValueLambda.GetType().FullName}");
                    }
                Out = ((MethodInfo) ValueLambda).Invoke(null, new object[] {});
                }
            else
                {
                throw new Exception($"Unknown member type: {ValueLambda.GetType().FullName}");
                }
            return Out;
            }

        /// <summary>
        /// Locates the method to be tested
        /// </summary>
        public static Func<bool> GetCheckMethod(MethodInfo SourceMethod, string MethodName)
            {
            var Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception($"Could not find Method: {MethodName}");

            if (Result.GetType().IsType(typeof(Func<bool>)))
                {
                return (Func<bool>) Result;
                }
            throw new Exception($"Unknown type: {Result.GetType()}");
            }

        /// <summary>
        /// Locates the method to be tested.
        /// Its argument input is set to object.
        /// </summary>
        public static Func<object, bool> GetCheckMethodArg(MethodInfo SourceMethod, string MethodName)
            {
            var Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception($"Could not find Method: {MethodName}");

            if (Result.GetType().IsType(typeof(Func<,>)))
                {
                Type[] Args = Result.GetType().GetGenericArguments();
                Type[] CastArgs = {typeof(object), typeof(bool)};

                var CastMethod = typeof(LogicExt).GetMethod("Cast", Args.Append(CastArgs));
                var Out = CastMethod.Invoke(null, new[] {Result});

                return (Func<object, bool>) Out;
                }
            throw new Exception($"Unknown type: {Result.GetType()}");
            }

        #region Categories

        /// <summary>
        /// Unit test categories
        /// </summary>
        public static class Categories
            {
            /// <summary>
            /// Category value name
            /// </summary>
            public const string Category = nameof(Category);

            /// <summary>
            /// Category value name
            /// </summary>
            public const string StaticMethods = "Static Methods";

            /// <summary>
            /// Attribute test category name
            /// </summary>
            public const string AttributeTests = "Attribute Tests";

            /// <summary>
            /// Tools test category name
            /// </summary>
            public const string Tools = nameof(Tools);

            /// <summary>
            /// Unit Tests category name
            /// </summary>
            public const string UnitTests = "Unit Tests";

            /// <summary>
            /// Internal category name
            /// </summary>
            public const string Internal = nameof(Internal);

            /// <summary>
            /// NullabilityTests category name
            /// </summary>
            public const string NullabilityTests = "Nullability Tests";

            /// <summary>
            /// AssemblyTest category name
            /// </summary>
            public const string AssemblyTests = "Assembly Tests";
            }

        #endregion
        }
    }