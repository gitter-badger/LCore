using System;
using System.Collections.Generic;
using LCore.Dynamic;
using LCore.ObjectExtensions;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LCore.UnitTesting
    {
    [AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class TestAttribute : Attribute, IL_Attribute_ReverseOrder
        {
        public abstract void RunTest(MethodInfo Method);
        public virtual void FixParameterTypes(MethodInfo Method)
            {
            Method.GetParameters().EachI((i, p) =>
            {
                Object o = Parameters[i];
                FixObject(Method, ((ParameterInfo)p).ParameterType, ref o);
                Parameters[i] = o;
            });
            }
        protected virtual void FixObject(MethodInfo SourceMethod, Type ObjectType, ref Object Obj)
            {
            // Converts Arrays to Lists when the Method requires it.
            if (ObjectType != null &&
                ObjectType != typeof(void))
                {
                if (Obj != null)
                    {
                    if (Obj is Array)
                        {
                        Type[] Args = new Type[] { ((Array)Obj).GetType().GetElementType() };
                        if (ObjectType == typeof(List<>).MakeGenericType(Args))
                            {
                            Type ListType = typeof(List<>).MakeGenericType(Args);

                            IList NewList = (IList)ListType.New();
                            ((Array)Obj).Each((obj) =>
                            {
                                NewList.Add(obj);
                            });

                            Obj = NewList;
                            }
                        }
                    else if (Obj is String && ObjectType.IsSubclassOf(typeof(Delegate)))
                        {
                        Obj = GetMethodDelegate(SourceMethod, ObjectType, (String)Obj);
                        }
                    else if (Obj is Object[] && !ObjectType.IsType(typeof(Object[])))
                        {
                        Type[] Types = ((Object[])Obj).GetTypes();
                        ConstructorInfo[] ObjectConstrutors = ObjectType.GetConstructors();
                        ConstructorInfo Const = ObjectConstrutors.First((c) =>
                        {
                            ParameterInfo[] Params = c.GetParameters();
                            if (Params.Length == Types.Length)
                                {
                                return Params.AllI((i2, p) =>
                                    {
                                        return Types[i2].IsType(p.ParameterType);
                                    });
                                }
                            return false;
                        });

                        if (Const != null)
                            {
                            Obj = Const.Invoke((Object[])Obj);
                            }
                        }
                    }
                }
            }

        private static Object GetMethodDelegate(MethodInfo SourceMethod, Type ObjectType, String MethodName)
            {
            Object Out = MethodName;

            Type SourceType;
            String MemberName;

            if (MethodName.Contains("."))
                {
                List<String> Parts = MethodName.Split('.').List();

                MemberName = Parts.Last();
                Parts.RemoveAt(Parts.Count - 1);

                String TypeName = Parts.Last();
                Parts.RemoveAt(Parts.Count - 1);

                SourceType = Type.GetType(Parts.Combine('.') + "+" + TypeName);

                if (SourceType == null && Parts.Count == 1)
                    {
                    SourceType = Type.GetType(SourceMethod.DeclaringType.Namespace + "." + Parts.Combine('.') + "+" + TypeName);
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

            MemberInfo ValueLambda = SourceType.GetMember(MemberName).Select((m) =>
            {
                return ObjectType == null || m.GetMemberType() == ObjectType;
            }).First();

            if (ValueLambda == null)
                {
                if (ReturnType != null)
                    {
                    ValueLambda = SourceType.GetMember(MemberName).Select((m) =>
                    {
                        return ObjectType == null || m.GetMemberType() == ReturnType;
                    }).First();
                    }
                else
                    {
                    ValueLambda = SourceType.GetMethod(MemberName, Types.ToArray());
                    }

                if (ValueLambda == null)
                    throw new Exception("Could not find Source Method: " + MethodName + " with arguments: " + Types.ToS());
                }

            if (ValueLambda is PropertyInfo)
                {
                Out = ((PropertyInfo)ValueLambda).GetGetMethod().Invoke(null, new Object[] { });
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
                    throw new Exception("Unknown member with arguments: " + ValueLambda.GetType().FullName);
                    }
                else
                    {
                    Out = ((MethodInfo)ValueLambda).Invoke(null, new Object[] { });
                    }
                }
            else
                {
                throw new Exception("Unknown member type: " + ValueLambda.GetType().FullName);
                }
            return Out;
            }

        protected virtual Func<Boolean> GetCheckMethod(MethodInfo SourceMethod, String MethodName)
            {
            Object Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception("Could not find Method: " + MethodName);

            if (Result.GetType().IsType(typeof(Func<Boolean>)))
                {
                return (Func<Boolean>)Result;
                }
            else
                {
                throw new Exception("Unknown type: " + Result.GetType());
                }
            }
        protected virtual Func<Object, Boolean> GetCheckMethodArg(MethodInfo SourceMethod, String MethodName)
            {
            Object Result = GetMethodDelegate(SourceMethod, null, MethodName);
            if (Result == null)
                throw new Exception("Could not find Method: " + MethodName);

            if (Result.GetType().IsType(typeof(Func<,>)))
                {
                Type[] Args = Result.GetType().GetGenericArguments();
                Type[] CastArgs = new Type[] { typeof(Object), typeof(Boolean) };

                MethodInfo CastMethod = typeof(LogicExt).GetMethod("Cast", Args.Append(CastArgs));
                Object Out = CastMethod.Invoke(null, new Object[] { Result });

                return (Func<Object, Boolean>)Out;
                }
            else
                {
                throw new Exception("Unknown type: " + Result.GetType());
                }
            }

        public Object[] Parameters;
        public Type[] GenericTypes;

        public TestAttribute()
            : this(new Object[] { })
            {
            }
        public TestAttribute(Object[] Parameters)
            {
            this.Parameters = Parameters;
            }
        }
    [AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class TestMethodGenerics : Attribute
        {
        public Type[] GenericTypes;

        public TestMethodGenerics(params Type[] GenericTypes)
            {
            this.GenericTypes = GenericTypes;
            }
        }
    }