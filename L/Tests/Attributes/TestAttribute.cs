using System;
using System.Collections.Generic;

using LCore.Extensions;
using LCore.Extensions.Optional;
using System.Collections;
using System.Reflection;
using System.Linq;
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LCore.Tests
    {
    /// <summary>
    /// Override this attribute to define a test case for a particular
    /// method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class TestAttribute : Attribute, ITestAttribute
        {
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        public abstract void RunTest(MethodInfo Method);

        /// <summary>
        /// Attempts to resolve parameter types for a method test.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        public virtual void FixParameterTypes(MethodInfo Method)
            {
            Method.GetParameters().Each((i, p) =>
            {
                if (this.Parameters.HasIndex(i))
                    {
                    var Param = this.Parameters[i];
                    this.FixObject(Method, p.ParameterType, ref Param);
                    this.Parameters[i] = Param;
                    }
            });
            }

        /// <summary>
        /// Attempts to resolve a single parameter object.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        protected virtual void FixObject(MethodInfo SourceMethod, Type ObjectType, ref object Obj)
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
                        Type[] Args = { Array.GetType().GetElementType() };
                        if (ObjectType == typeof(List<>).MakeGenericType(Args))
                            {
                            var ListType = typeof(List<>).MakeGenericType(Args);

                            var NewList = (IList)ListType.New();
                            Array.Each(obj =>
                            {
                                NewList.Add(obj);
                            });

                            Obj = NewList;
                            }
                        }
                    else if (Obj is string && ObjectType.IsSubclassOf(typeof(Delegate)))
                        {
                        Obj = GetMethodDelegate(SourceMethod, ObjectType, (string)Obj);
                        }
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    else if (Obj is object[] && !ObjectType.IsType(typeof(object[])))
                    // ReSharper disable HeuristicUnreachableCode
                        {
                        Type[] Types = ((object[])Obj).GetTypes();
                        ConstructorInfo[] ObjectConstructors = ObjectType.GetConstructors();
                        var Const = ObjectConstructors.First(c =>
                        {
                            ParameterInfo[] Params = c.GetParameters();
                            return Params.Length == Types.Length && Params.All((i2, p) => Types[i2].IsType(p.ParameterType));
                        });

                        if (Const != null)
                            {
                            Obj = Const.Invoke((object[])Obj);
                            }
                        }
                    // ReSharper restore HeuristicUnreachableCode
                    else if (Obj is IConvertible && ObjectType == typeof(decimal))
                        {
                        Obj = ((IConvertible)Obj).ConvertTo<decimal>();
                        }
                    }
                }
            }

        private static object GetMethodDelegate(MethodInfo SourceMethod, Type ObjectType, string MethodName)
            {
            object Out;

            Type SourceType;
            string MemberName;

            if (MethodName.Contains("."))
                {
                List<string> Parts = MethodName.Split(".").ToList();

                MemberName = Parts.Last();
                Parts.RemoveAt(Parts.Count - 1);

                string TypeName = Parts.Last();
                Parts.RemoveAt(Parts.Count - 1);

                SourceType = Type.GetType($"{Parts.Combine('.')}+{TypeName}");

                if (SourceType == null && Parts.Count == 1)
                    {
                    SourceType = Type.GetType($"{SourceMethod.DeclaringType?.Namespace}.{Parts.Combine('.')}+{TypeName}");
                    }

                if (SourceType == null)
                    throw new Exception("Could not find Source Type");
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
                m => ObjectType == null || m.GetMemberType() == ObjectType).First();

            if (ValueLambda == null)
                {
                if (ReturnType != null)
                    {
                    ValueLambda = SourceType?.GetMember(MemberName).Select(
                        m => ObjectType == null || m.GetMemberType() == ReturnType).First();
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
                Out = Info.GetGetMethod().Invoke(null, new object[] { });
                }
            else if (ValueLambda is FieldInfo)
                {
                Out = ((FieldInfo)ValueLambda).GetValue(null);
                }
            else if (ValueLambda is MethodInfo)
                {
                ParameterInfo[] Params = ((MethodInfo)ValueLambda).GetParameters();
                if (Params.Length > 0)
                    {
                    throw new Exception($"Unknown member with arguments: {ValueLambda.GetType().FullName}");
                    }
                Out = ((MethodInfo)ValueLambda).Invoke(null, new object[] { });
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
        protected virtual Func<bool> GetCheckMethod(MethodInfo SourceMethod, string MethodName)
            {
            var Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception($"Could not find Method: {MethodName}");

            if (Result.GetType().IsType(typeof(Func<bool>)))
                {
                return (Func<bool>)Result;
                }
            throw new Exception($"Unknown type: {Result.GetType()}");
            }

        /// <summary>
        /// Locates the method to be tested.
        /// Its argument input is set to object.
        /// </summary>
        protected virtual Func<object, bool> GetCheckMethodArg(MethodInfo SourceMethod, string MethodName)
            {
            var Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception($"Could not find Method: {MethodName}");

            if (Result.GetType().IsType(typeof(Func<,>)))
                {
                Type[] Args = Result.GetType().GetGenericArguments();
                Type[] CastArgs = { typeof(object), typeof(bool) };

                var CastMethod = typeof(LogicExt).GetMethod("Cast", Args.Append(CastArgs));
                var Out = CastMethod.Invoke(null, new[] { Result });

                return (Func<object, bool>)Out;
                }
            throw new Exception($"Unknown type: {Result.GetType()}");
            }

        /// <summary>
        /// Parameters for the current test
        /// </summary>
        public readonly object[] Parameters;

        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        public Type[] GenericTypes { get; set; }

        /// <summary>
        /// Create a new Test Attribute with no parameters.
        /// </summary>
        protected TestAttribute()
            : this(new object[] { })
            {
            }

        /// <summary>
        /// Create a new Test Attribute with parameters.
        /// </summary>
        protected TestAttribute(object[] Parameters)
            {
            this.Parameters = Parameters;
            }
        }
    }