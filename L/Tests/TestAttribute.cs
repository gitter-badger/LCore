using System;
using System.Collections.Generic;

using LCore.Extensions;
using LCore.Extensions.ObjectExt;
using System.Collections;
using System.Reflection;
using System.Linq;
using LCore.Interfaces;

namespace LCore.Tests
    {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class TestAttribute : Attribute, IL_Attribute_ReverseOrder
        {
        public abstract void RunTest(MethodInfo Method);
        public virtual void FixParameterTypes(MethodInfo Method)
            {
            Method.GetParameters().EachI((i, p) =>
            {
                object o = this.Parameters[i];
                this.FixObject(Method, p.ParameterType, ref o);
                this.Parameters[i] = o;
            });
            }
        protected virtual void FixObject(MethodInfo SourceMethod, Type ObjectType, ref object Obj)
            {
            // Converts Arrays to Lists when the Method requires it.
            if (ObjectType != null &&
                ObjectType != typeof(void))
                {
                if (Obj != null)
                    {
                    Array array = Obj as Array;
                    if (array != null)
                        {
                        Type[] Args = { array.GetType().GetElementType() };
                        if (ObjectType == typeof(List<>).MakeGenericType(Args))
                            {
                            Type ListType = typeof(List<>).MakeGenericType(Args);

                            IList NewList = (IList)ListType.New();
                            array.Each(obj =>
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
                        ConstructorInfo[] ObjectConstrutors = ObjectType.GetConstructors();
                        ConstructorInfo Const = ObjectConstrutors.First(c =>
                        {
                            ParameterInfo[] Params = c.GetParameters();
                            return Params.Length == Types.Length && Params.AllI((i2, p) => Types[i2].IsType(p.ParameterType));
                        });

                        if (Const != null)
                            {
                            Obj = Const.Invoke((object[])Obj);
                            }
                        }
                    // ReSharper restore HeuristicUnreachableCode
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


            List<Type> Types = new List<Type>();
            Type ReturnType = typeof(void);
            if (ObjectType != null)
                {
                Types = ObjectType.GetGenericArguments().List();
                if (ObjectType.FullName.ToLower().Contains("func"))
                    {
                    ReturnType = Types.Last();
                    Types.RemoveAt(Types.Count - 1);
                    }
                }

            MemberInfo ValueLambda = SourceType?.GetMember(MemberName).Select(
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

            PropertyInfo info = ValueLambda as PropertyInfo;
            if (info != null)
                {
                Out = info.GetGetMethod().Invoke(null, new object[] { });
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

        protected virtual Func<bool> GetCheckMethod(MethodInfo SourceMethod, string MethodName)
            {
            object Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception($"Could not find Method: {MethodName}");

            if (Result.GetType().IsType(typeof(Func<bool>)))
                {
                return (Func<bool>)Result;
                }
            throw new Exception($"Unknown type: {Result.GetType()}");
            }
        protected virtual Func<object, bool> GetCheckMethodArg(MethodInfo SourceMethod, string MethodName)
            {
            object Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception($"Could not find Method: {MethodName}");

            if (Result.GetType().IsType(typeof(Func<,>)))
                {
                Type[] Args = Result.GetType().GetGenericArguments();
                Type[] CastArgs = { typeof(object), typeof(bool) };

                MethodInfo CastMethod = typeof(LogicExt).GetMethod("Cast", Args.Append(CastArgs));
                object Out = CastMethod.Invoke(null, new[] { Result });

                return (Func<object, bool>)Out;
                }
            throw new Exception($"Unknown type: {Result.GetType()}");
            }

        public object[] Parameters;
        public Type[] GenericTypes;

        protected TestAttribute()
            : this(new object[] { })
            {
            }

        protected TestAttribute(object[] Parameters)
            {
            this.Parameters = Parameters;
            }
        }
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodGenerics : Attribute
        {
        public Type[] GenericTypes;

        public TestMethodGenerics(params Type[] GenericTypes)
            {
            this.GenericTypes = GenericTypes;
            }
        }
    }