using System;
using LCore;
using LCore.ObjectExtensions;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;
using System.Threading;

namespace LCore
    {
    public partial class L : Logic
        {
        #region Str
        /// <summary>
        /// Returns a function that converts an Object to a String. Shortcut for Logic.Object_ToString
        /// </summary>
        public static Func<Object, String> Str = Object_ToString;
        #endregion
        #region Is
        /// <summary>
        /// Returns a function that safely Compares an object with another, returning whether they are equal. Shortcut for Logic.Object_SafeEquals
        /// </summary>
        public static Func<Object, Object, Boolean> Is = L.Object_SafeEquals;
        #endregion
        }
    public partial class Logic
        {
        #region Base Lambdas
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        public static Func<Object, Object, Boolean> Object_Equals2 = (objA, objB) => { return Object.Equals(objA, objB); };
        public static Func<Object, Object, Boolean> Object_ReferenceEquals = (objA, objB) => { return Object.ReferenceEquals(objA, objB); };
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        #endregion

        #region Object
        /// <summary>
        /// Returns a function that safely compares an object with another, returning whether they are equal.
        /// </summary>
        public static Func<Object, Object, Boolean> Object_SafeEquals = (o1, o2) =>
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(o1, o2))
                {
                return true;
                }

            // If one is null, but not both, return false.
            if (System.Object.ReferenceEquals(o1, null) ||
                System.Object.ReferenceEquals(o2, null))
                {
                return false;
                }

            // If objects are both IEnumerable, send to Enumerable equivalent
            if (o1 is IEnumerable && o2 is IEnumerable)
                {
                return ((IEnumerable)o1).Equivalent((IEnumerable)o2);
                }

            return o1.Equals(o2);
        };

        /// <summary>
        /// Returns a string representation of a set of objects.
        /// </summary>
        public static Func<Object[], String> Objects_ToString = (In) =>
        {
            if (In.IsEmpty())
                return "";
            return In.Convert((o) =>
            {
                if (o == null)
                    return "NULL";
                else
                    return (o.GetType() + ":" + o.ToString());
            }).Combine(", ");
        };
        #endregion

        #region New
        public static Func<U> New<U>()
            {
            return () => { return (U)typeof(U).GetConstructor(L.Array<Type>()()).Invoke(L.Array<object>()()); };
            }
        public static Func<T1, U> New<T1, U>()
            {
            ConstructorInfo Const = typeof(U).GetConstructor(new Type[] { typeof(T1) });
            return (o1) => { return (U)Const.Invoke(new Object[] { o1 }); };
            }
        public static Func<T1, T2, U> New<T1, T2, U>()
            {
            ConstructorInfo Const = typeof(U).GetConstructor(new Type[] { typeof(T1), typeof(T2) });
            return (o1, o2) => { return (U)Const.Invoke(new Object[] { o1, o2 }); };
            }
        public static Func<T1, T2, T3, U> New<T1, T2, T3, U>()
            {
            ConstructorInfo Const = typeof(U).GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            return (o1, o2, o3) => { return (U)Const.Invoke(new Object[] { o1, o2, o3 }); };
            }
        public static Func<T1, T2, T3, T4, U> New<T1, T2, T3, T4, U>()
            {
            ConstructorInfo Const = typeof(U).GetConstructor(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            return (o1, o2, o3, o4) => { return (U)Const.Invoke(new Object[] { o1, o2, o3, o4 }); };
            }
        public static Func<U> New<U>(params Object[] In)
            {
            ConstructorInfo Const = typeof(U).GetConstructor(In.GetTypes());
            return () => { return (U)Const.Invoke(In); };
            }
        #endregion
        #region IsNull
        public static Func<T, Boolean> IsNull<T>()
            {
            Boolean ValueType = L.Language_IsValueType(typeof(T));
            if (ValueType)
                {
                return (o) => { return false; };
                }
            else
                {
                return (o) => { return o.SafeEquals(default(T)); };
                }
            }
        #endregion
        #region IsA
        public static Func<Object, Boolean> IsA<T>()
            {
            return (o) => { return o is T; };
            }
        #endregion

        #region Method
        private static Action<U> Method<U>(String MethodName)
            {
            MethodInfo Method = typeof(U).GetMethod(MethodName, new Type[] { });
            if (Method != null)
                {
                return (o) => { Method.Invoke(o, new object[] { }); };
                }
            else
                throw new Exception(typeof(U).FullName + " " + MethodName);
            }
        #endregion
        #region Getter
        public static Func<T, U> Getter<T, U>(String Field)
            {
            MemberInfo Member = typeof(T).GetMember(Field).First();
            if (Member != null && Member is PropertyInfo)
                {
                PropertyInfo M2 = (PropertyInfo)Member;
                return PropertyInfo_GetU<T, U>(M2);
                }
            else if (Member != null && Member is FieldInfo)
                {
                FieldInfo M3 = (FieldInfo)Member;
                return FieldInfo_GetU<T, U>(M3);
                }
            else
                throw new Exception(typeof(T).FullName + " " + Field);
            }

        private static Func<T, U> PropertyInfo_GetU<T, U>(PropertyInfo Field)
            {
            return L.PropertyInfo_GetValue.Supply3(null).Supply(Field).Cast<object, object, T, U>().Try();
            }
        private static Func<T, U> FieldInfo_GetU<T, U>(FieldInfo Field)
            {
            return L.FieldInfo_GetValue.Supply(Field).Cast<object, object, T, U>().Try();
            }
        #endregion
        #region Setter
        public static Action<T1, T2> Setter<T1, T2>(String Field)
            {
            MemberInfo Member = typeof(T1).GetMember(Field).First();
            if (Member != null && Member is PropertyInfo)
                {
                PropertyInfo M2 = (PropertyInfo)Member;
                return PropertyInfo_SetU<T1, T2>(M2);
                }
            else if (Member != null && Member is FieldInfo)
                {
                FieldInfo M3 = (FieldInfo)Member;
                return FieldInfo_SetU<T1, T2>(M3);
                }
            else
                throw new Exception(typeof(T1).FullName + " " + typeof(T2).FullName + " " + Field);
            }

        private static Action<T, U> PropertyInfo_SetU<T, U>(PropertyInfo Field)
            {
            return L.PropertyInfo_SetValue.Supply(Field).Supply3(null).Cast<object, object, T, U>().Try().Do();
            }
        private static Action<T, U> FieldInfo_SetU<T, U>(FieldInfo Field)
            {
            return L.FieldInfo_SetValue.Supply(Field).Cast<object, object, T, U>().Try().Do();
            }
        #endregion
        }
    public static class ObjectExt
        {
        //Instanciates a new object from parameters
        #region New
        public static T New<T>()
            {
            return L.New<T>()();
            }
        public static T New<T>(params Object[] In)
            {
            return L.New<T>(In)();
            }
        #endregion


        #region Objects To String
        public static String Objects_ToString(this IEnumerable<Object> In)
            {
            return L.Objects_ToString(In.Array());
            }
        #endregion

        public static Boolean HasProperty(this Object In, String PropertyName)
            {
            MemberInfo Member = In.GetType().GetMember(PropertyName).First();

            if (Member != null && Member is PropertyInfo)
                return true;
            else if (Member != null && Member is FieldInfo)
                return true;
            else
                return false;
            }
        public static Object GetProperty(this Object In, String PropertyName)
            {
            MemberInfo Member = In.GetType().GetMember(PropertyName).First();

            if (Member != null && Member is PropertyInfo)
                {
                PropertyInfo M2 = (PropertyInfo)Member;
                return Member.GetValue(In);
                }
            else if (Member != null && Member is FieldInfo)
                {
                FieldInfo M3 = (FieldInfo)Member;
                return Member.GetValue(In);
                }
            else
                throw new Exception(In.GetType().FullName + " " + PropertyName);
            }
        public static void SetProperty(this Object In, String PropertyName, Object PropertyValue)
            {
            MemberInfo Member = In.GetType().GetMember(PropertyName).First();

            if (Member != null && Member is PropertyInfo)
                {
                PropertyInfo M2 = (PropertyInfo)Member;
                Member.SetValue(In, PropertyValue);
                }
            else if (Member != null && Member is FieldInfo)
                {
                FieldInfo M3 = (FieldInfo)Member;
                Member.SetValue(In, PropertyValue);
                }
            else
                throw new Exception(In.GetType().FullName + " " + PropertyName);
            }

        public static void Swap<T>(ref T Obj1, ref T Obj2)
            {
            T temp = Obj1;
            Obj1 = Obj2;
            Obj2 = temp;
            }
        }
    }
namespace LCore.ObjectExtensions
    {
    public static class ObjectExt
        {
        // Gets a function that returns the input parameter
        #region Func
        public static Func<T> Func<T>(this T In)
            {
            return L.Return(In);
            }
        #endregion
        // Acts as the inverse of the function 'Supply' command, supplying the object as the parameter.
        #region Supply - T
        #region Supply - T - Action_T
        public static Action Supply<T>(T Obj, Action<T> In)
            {
            return () => { In(Obj); };
            }
        #endregion
        #region Supply - T - Action_T_T
        public static Action<T2> Supply<T1, T2>(T1 Obj, Action<T1, T2> In)
            {
            return (o) => { In(Obj, o); };
            }
        public static Action<T1> Supply2<T1, T2>(T2 Obj, Action<T1, T2> In)
            {
            return (o) => { In(o, Obj); };
            }
        #endregion
        #region Supply - T - Action_T_T_T
        public static Action<T2, T3> Supply<T1, T2, T3>(T1 Obj, Action<T1, T2, T3> In)
            {
            return (o1, o2) => { In(Obj, o1, o2); };
            }
        public static Action<T1, T3> Supply2<T1, T2, T3>(T2 Obj, Action<T1, T2, T3> In)
            {
            return (o1, o2) => { In(o1, Obj, o2); };
            }
        public static Action<T1, T2> Supply3<T1, T2, T3>(T3 Obj, Action<T1, T2, T3> In)
            {
            return (o1, o2) => { In(o1, o2, Obj); };
            }
        #endregion
        #region Supply - T - Action_T_T_T
        public static Action<T2, T3, T4> Supply<T1, T2, T3, T4>(T1 Obj, Action<T1, T2, T3, T4> In)
            {
            return (o1, o2, o3) => { In(Obj, o1, o2, o3); };
            }
        public static Action<T1, T3, T4> Supply2<T1, T2, T3, T4>(T2 Obj, Action<T1, T2, T3, T4> In)
            {
            return (o1, o2, o3) => { In(o1, Obj, o2, o3); };
            }
        public static Action<T1, T2, T4> Supply3<T1, T2, T3, T4>(T3 Obj, Action<T1, T2, T3, T4> In)
            {
            return (o1, o2, o3) => { In(o1, o2, Obj, o3); };
            }
        public static Action<T1, T2, T3> Supply4<T1, T2, T3, T4>(T4 Obj, Action<T1, T2, T3, T4> In)
            {
            return (o1, o2, o3) => { In(o1, o2, o3, Obj); };
            }
        #endregion
        #region Supply - T - Func_T_T
        public static Func<U> Supply<T1, U>(T1 Obj, Func<T1, U> In)
            {
            return () => { return In(Obj); };
            }
        #endregion
        #region Supply - T - Func_T_T_T
        public static Func<T2, U> Supply<T1, T2, U>(T1 Obj, Func<T1, T2, U> In)
            {
            return (o) => { return In(Obj, o); };
            }
        public static Func<T1, U> Supply2<T1, T2, U>(T2 Obj, Func<T1, T2, U> In)
            {
            return (o) => { return In(o, Obj); };
            }
        #endregion
        #region Supply - T - Func_T_T_T_T
        public static Func<T2, T3, U> Supply<T1, T2, T3, U>(T1 Obj, Func<T1, T2, T3, U> In)
            {
            return (o1, o2) => { return In(Obj, o1, o2); };
            }
        public static Func<T1, T3, U> Supply2<T1, T2, T3, U>(T2 Obj, Func<T1, T2, T3, U> In)
            {
            return (o1, o2) => { return In(o1, Obj, o2); };
            }
        public static Func<T1, T2, U> Supply3<T1, T2, T3, U>(T3 Obj, Func<T1, T2, T3, U> In)
            {
            return (o1, o2) => { return In(o1, o2, Obj); };
            }
        #endregion
        #region Supply - T - Func_T_T_T_T
        public static Func<T2, T3, T4, U> Supply<T1, T2, T3, T4, U>(T1 Obj, Func<T1, T2, T3, T4, U> In)
            {
            return (o1, o2, o3) => { return In(Obj, o1, o2, o3); };
            }
        public static Func<T1, T3, T4, U> Supply2<T1, T2, T3, T4, U>(T2 Obj, Func<T1, T2, T3, T4, U> In)
            {
            return (o1, o2, o3) => { return In(o1, Obj, o2, o3); };
            }
        public static Func<T1, T2, T4, U> Supply3<T1, T2, T3, T4, U>(T3 Obj, Func<T1, T2, T3, T4, U> In)
            {
            return (o1, o2, o3) => { return In(o1, o2, Obj, o3); };
            }
        public static Func<T1, T2, T3, U> Supply4<T1, T2, T3, T4, U>(T4 Obj, Func<T1, T2, T3, T4, U> In)
            {
            return (o1, o2, o3) => { return In(o1, o2, o3, Obj); };
            }
        #endregion
        #endregion
        public static void Traverse(this Object In, Func<Object, Object> Traverser)
            {
            Object Cursor = In;

            while (Cursor != null)
                {
                Cursor = Traverser(Cursor);
                }
            }
        public static void Traverse<T>(this T In, Func<T, T> Traverser)
            {
            T Cursor = In;

            while (Cursor != null)
                {
                Cursor = Traverser(Cursor);
                }
            }

        public static String Details<T>(this T In, Boolean ShowErrorFields = false)
            {
            String Out = typeof(T).FullName + " {\r\n";

            Out += typeof(T).GetMembers().CollectStr((i, m) =>
                {
                    String Out2;
                    if (m is FieldInfo)
                        {
                        Out2 = ((FieldInfo)m).Name;
                        if (In == null)
                            {
                            Out2 += ", ";
                            }
                        else
                            {
                            try
                                {
                                Out2 += ": " + ((FieldInfo)m).GetValue(In) + "\r\n";
                                }
                            catch (Exception e)
                                {
                                if (!ShowErrorFields)
                                    return "";

                                Out2 += ": " + e.ToS() + "\r\n";
                                }
                            }
                        return Out2;
                        }
                    else if (m is PropertyInfo)
                        {
                        Out2 = ((PropertyInfo)m).Name;
                        if (In == null)
                            {
                            Out2 += ", ";
                            }
                        else
                            {
                            try
                                {
                                Out2 += ": " + ((PropertyInfo)m).GetValue(In) + "\r\n";
                                }
                            catch (Exception e)
                                {
                                if (!ShowErrorFields)
                                    return "";

                                Out2 += ": " + e.ToS() + "\r\n";
                                }
                            }
                        return Out2;
                        }
                    return "";
                });

            Out += "}";

            return Out;
            }


        #region List
        /// <summary>
        /// Returns a function that creates a new List from parameters
        /// </summary>
        public static Func<List<T>> List<T>(this T In)
            {
            return () =>
            {
                List<T> Out = new List<T>();
                Out.Add(In);
                return Out;
            };
            }
        #endregion
        #region Array
        /// <summary>
        /// Returns a function that creates a new Array from parameters
        /// </summary>
        public static Func<T[]> Array<T>(this T In)
            {
            return () => { return new T[] { In }; };
            }
        /// <summary>
        /// Returns a function that creates a new Array containing [Count] instances of [In]
        /// </summary>
        public static Func<T[]> Array<T>(this T In, int Count)
            {
            return () =>
            {
                T[] Out = new T[Count];
                Out.Fill(In);
                return Out;
            };
            }
        #endregion

        public static String ToS(this Object In)
            {
            return L.ToS(In);
            }

        #region Safe Equals
        public static Boolean SafeEquals(this Object In, Object Obj)
            {
            return L.Object_SafeEquals(In, Obj);
            }
        #endregion
        // Returns a function returns true if the object supplied is not equal to the Input parameter
        #region Unless
        public static Func<T, Boolean> Unless<T>(T In)
            {
            return L.F<T, Boolean>(IsNull);
            }
        #endregion
        #region Present
        /// <summary>
        /// Returns a function that returns true if the object send is not a null value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T, Boolean> Present<T>()
            {
            return ObjectExt.IsPresent<T>();
            }
        #endregion
        #region IsPresent
        public static Func<T, Boolean> IsPresent<T>()
            {
            return ObjectExt.Null<T>().Not();
            }
        #endregion
        #region Default
        /// <summary>
        /// Returns a function that returns true if the object send is a null value. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T, Boolean> Default<T>()
            {
            return IsDefault<T>();
            }
        #endregion
        #region Null
        /// <summary>
        /// Returns a function that returns true if the object send is a null value. This statement is equivalent to Default[T]()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T, Boolean> Null<T>()
            {
            return IsDefault<T>();
            }
        #endregion

        #region IsDefault
        /// <summary>
        /// Returns a function that returns true if the object send is the Default value for its type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T, Boolean> IsDefault<T>()
            {
            return default(T).If<T>();
            }
        #endregion

        // Returns a function returns true if the object supplied is equal to the Input parameter
        #region If
        public static Func<T, Boolean> If<T>(this T In)
            {
            return L.Object_SafeEquals.Supply2(In).Cast<Object, Boolean, T, Boolean>();
            }
        #endregion

        // Returns whether the object is null, or equivalent to the default of its type.
        #region IsNull
        public static Boolean IsNull<T>(this T In)
            {
            return L.IsNull<T>()(In);
            }
        #endregion

        public static void InitProperties<T>(this Object In, T InitValue = default(T))
            {
            if (In != null)
                {
                Type ObjType = In.GetType();
                MemberInfo[] Members = ObjType.GetMembers();

                if (InitValue == null)
                    InitValue = typeof(T).New<T>();

                foreach (MemberInfo Member in Members)
                    {
                    if (Member.ReflectedType != typeof(T))
                        {
                        continue;
                        }

                    if (Member is PropertyInfo && ((PropertyInfo)Member).CanWrite)
                        {
                        ((PropertyInfo)Member).SetValue(In, InitValue);
                        }
                    if (Member is FieldInfo)
                        {
                        ((FieldInfo)Member).SetValue(In, InitValue);
                        }
                    }
                }
            }
        }
    }
