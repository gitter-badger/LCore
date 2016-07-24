using System;
using LCore.Extensions.Optional;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Interfaces;
using LCore.Tests;

namespace LCore.Extensions
    {
    /// <summary>
    /// Extensions to objects of all types.
    /// </summary>
    [ExtensionProvider]
    public static class ObjectExt
        {
        #region Extensions +

        #region HasProperty
        /// <summary>
        /// Returns whether a given object has a property with a specific name
        /// </summary>
        /// <returns>Whether a given object has a property with a specific name</returns>
        [TestResult(new object[] { null, null }, false)]
        [TestResult(new object[] { null, "" }, false)]
        [TestResult(new object[] { "", null }, false)]
        [TestResult(new object[] { "", "" }, false)]
        [TestResult(new object[] { "", "nope" }, false)]
        [TestResult(new object[] { "", nameof(string.Length) }, true)]
        public static bool HasProperty(this object In, string PropertyName)
            {
            return L.Obj.HasProperty()(In, PropertyName);
            }
        #endregion

        #region Objects To String
        /// <summary>
        /// Returns a string representation of a set of objects.
        /// </summary>
        /// <param name="In">The set of objects</param>
        /// <returns></returns>
        [TestResult(new object[] { null }, "")]
        [TestResult(new object[] { new object[] { } }, "")]
        [TestResult(new object[] { new object[] { null } }, "NULL")]
        [TestResult(new object[] { new object[] { "" } }, "System.String:")]
        [TestResult(new object[] { new object[] { "a", 1, 2, 3.6f } }, "System.String:a, System.Int32:1, System.Int32:2, System.Single:3.6")]
        public static string Objects_ToString(this IEnumerable<object> In)
            {
            return L.Obj.Objects_ToString(In.Array());
            }
        #endregion

        #region GetProperty
        /// <summary>
        /// Returns the value of a specific property, if it exists.
        /// </summary>
        /// <returns>The value of a specific property, if it exists.</returns>
        [Tested]
        [CanBeNull]
        public static object GetProperty([CanBeNull]this object In, [CanBeNull]string PropertyName)
            {
            return L.Obj.GetProperty()(In, PropertyName);
            }
        #endregion

        #region SetProperty
        /// <summary>
        /// Sets the value of a specific property, if it exists.
        /// </summary>
        [Tested]
        public static void SetProperty(this object In, string PropertyName, object PropertyValue)
            {
            L.Obj.SetProperty()(In, PropertyName, PropertyValue);
            }
        #endregion

        #region Type
        /// <summary>
        /// Returns the type of an object.
        /// </summary>
        [TestResult(new object[] { 0 }, typeof(int), GenericTypes = new[] { typeof(int) })]
        [TestResult(new object[] { "" }, typeof(string), GenericTypes = new[] { typeof(string) })]
        // ReSharper disable once UnusedParameter.Global
        public static Type Type<T>(this T In)
            {
            return typeof(T);
            }
        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains System.Object static methods and lambdas.
        /// </summary>
        public static class Obj
            {
            #region Static Methods +

            #region Str
            /// <summary>
            /// Returns a function that converts an Object to a String. Shortcut for Logic.Object_ToString
            /// </summary>
            public static Func<object, string> Str = o => o.ToString();
            #endregion

            #region Swap
            /// <summary>
            /// Swaps two objects by reference
            /// </summary>
            public static void Swap<T>(ref T Obj1, ref T Obj2)
                {
                var Temp = Obj1;
                Obj1 = Obj2;
                Obj2 = Temp;
                }
            #endregion

            #region SafeEquals
            /// <summary>
            /// Returns a function that safely compares an object with another, returning whether they are equal.
            /// </summary>
            public static bool SafeEquals([CanBeNull]object o1, [CanBeNull]object o2)
                {
                // If both are null, or both are same instance, return true.
                if (ReferenceEquals(o1, o2))
                    {
                    return true;
                    }

                // If one is null, but not both, return false.
                if (ReferenceEquals(o1, null) ||
                    ReferenceEquals(o2, null))
                    {
                    return false;
                    }

                // If objects are both IEnumerable, send to Enumerable equivalent
                var Enumerable = o1 as IEnumerable;
                if (Enumerable != null && o2 is IEnumerable)
                    {
                    return Enumerable.Equivalent((IEnumerable)o2);
                    }

                return o1.Equals(o2);
                }
            #endregion

            #region ToString
            /// <summary>
            /// Returns a string representation of a set of objects.
            /// </summary>
            public static readonly Func<object[], string> Objects_ToString = In =>
            {
                return In.IsEmpty() ? "" : In.Convert(o => o == null ? "NULL" : $"{o.GetType()}:{o.ToString()}").Combine(", ");
            };
            #endregion

            #region New

            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" /> with the supplied parameters.
            /// </summary>
            public static Func<U> New<U>(params object[] In)
                {
                var Const = typeof(U).GetConstructor(In.GetTypes());
                return () => (U)Const?.Invoke(In);
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<U> New<U>()
                {
                return () => (U)typeof(U).GetConstructor(Ary.Array<Type>()())?.Invoke(Ary.Array<object>()());
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, U> New<T1, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1) });
                return o1 => (U)Const?.Invoke(new object[] { o1 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, U> New<T1, T2, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2) });
                return (o1, o2) => (U)Const?.Invoke(new object[] { o1, o2 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, U> New<T1, T2, T3, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3) });
                return (o1, o2, o3) => (U)Const?.Invoke(new object[] { o1, o2, o3 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, U> New<T1, T2, T3, T4, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, U> New<T1, T2, T3, T4, T5, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, U> New<T1, T2, T3, T4, T5, T6, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, U> New<T1, T2, T3, T4, T5, T6, T7, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> New<T1, T2, T3, T4, T5, T6, T7, T8, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15 });
                }
            /// <summary>
            /// Retrieves a func that creates an object of type <typeparamref name="U" />.
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> New<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
                {
                var Const = typeof(U).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => (U)Const?.Invoke(new object[] { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16 });
                }
            #endregion

            #region IsNull
            /// <summary>
            /// Retrieves a func that determines if a certain type of object is null.
            /// </summary>
            public static Func<T, bool> IsNull<T>()
                {
                bool ValueType = typeof(T).IsValueType;

                if (ValueType)
                    {
                    return o => false;
                    }
                return o => o.SafeEquals(default(T));
                }
            #endregion

            #region IsA
            /// <summary>
            /// Retrieves a func that determines if an object matches type <typeparamref name="T" />.
            /// </summary>
            public static Func<object, bool> IsA<T>()
                {
                return o => o is T;
                }
            #endregion

            #region Method
            /// <summary>
            /// Retrieves a func that retrieves a method executor on type <typeparamref name="U" /> using the supplied parameters
            /// </summary>
            private static Action<U> Method<U>(string MethodName, [CanBeNull]params object[] Params)
                {
                Params = Params ?? new object[] { };

                var Method = typeof(U).GetMethod(MethodName, Params.GetTypes());
                if (Method != null)
                    {
                    return o => { Method.Invoke(o, Params); };
                    }
                throw new ArgumentException($"{typeof(U).FullName} {MethodName}");
                }
            #endregion

            /// <summary>
            /// Determine if an object has a property by name.
            /// </summary>
            public static Func<object, string, bool> HasProperty()
                {
                return (In, PropertyName) =>
                {
                    if (In == null)
                        return false;
                    PropertyName = PropertyName ?? "";
                    var Member = In.GetType().GetMember(PropertyName).First();

                    if (Member is PropertyInfo)
                        return true;
                    return Member is FieldInfo;
                };
                }

            /// <summary>
            /// Get a property value from an object.
            /// </summary>
            public static Func<object, string, object> GetProperty()
                {
                return (In, PropertyName) =>
                {
                    var Member = In.GetType().GetMember(PropertyName).First();

                    var PropertyInfo = Member as PropertyInfo;
                    if (PropertyInfo != null)
                        {
                        var M2 = PropertyInfo;
                        return M2.GetValue(In);
                        }
                    var FieldInfo = Member as FieldInfo;
                    if (FieldInfo != null)
                        {
                        var M3 = FieldInfo;
                        return M3.GetValue(In);
                        }
                    throw new ArgumentException($"{In.GetType().FullName} {PropertyName}");
                };
                }

            /// <summary>
            /// Set a property value on an object.
            /// </summary>
            public static Action<object, string, object> SetProperty()
                {
                return (In, PropertyName, PropertyValue) =>
                {
                    var Member = In.GetType().GetMember(PropertyName).First();

                    var PropertyInfo = Member as PropertyInfo;
                    if (PropertyInfo != null)
                        {
                        var M2 = PropertyInfo;
                        M2.SetValue(In, PropertyValue);
                        }
                    else if (Member is FieldInfo)
                        {
                        var M3 = (FieldInfo)Member;
                        M3.SetValue(In, PropertyValue);
                        }
                    else
                        throw new ArgumentException($"{In.GetType().FullName} {PropertyName}");

                };
                }

            #endregion

            #region Lambdas +
            #region Is
            /// <summary>
            /// Returns a function that safely Compares an object with another, returning whether they are equal. Shortcut for Logic.Object_SafeEquals
            /// </summary>
            public static Func<object, object, bool> Is = SafeEquals;
            #endregion
            #endregion
            }
        }
    }
namespace LCore.Extensions.Optional
    {
    /// <summary>
    /// An optional, additional extension method class for all object types
    /// </summary>
    [ExtensionProvider]
    public static class ObjectExt
        {
        #region Extensions +

        #region CopyFieldsTo
        /// <summary>
        /// Copies all possible fields from <paramref name="In" /> to <paramref name="Obj" />.
        /// Matching field names are transferred to <paramref name="Obj" /> for fields and properties with public setters.
        /// </summary>
        [Tested]
        public static void CopyFieldsTo<T>(this T In, object Obj)
            {
            In.CopyFieldsTo(Obj, FieldName => FieldName);
            }

        /// <summary>
        /// Copies all possible fields from <paramref name="In" /> to <paramref name="Obj" />.
        /// Matching field names are transferred to <paramref name="Obj" /> for fields and properties with public setters.
        /// 
        /// Optionally you can supply a CustomMapper dictionary to map fields to new field names.
        /// </summary>
        [Tested]
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static void CopyFieldsTo<T>(this T In, object Obj, Dictionary<string, string> CustomMapper = null)
            {
            In.CopyFieldsTo(Obj, CustomMapper == null ?
                (Func<string, string>)(FieldName => FieldName) :
                (FieldName => CustomMapper.ContainsKey(FieldName) ? CustomMapper[FieldName] : FieldName));
            }

        /// <summary>
        /// Copies all possible fields from <paramref name="In" /> to <paramref name="Obj" />.
        /// Matching field names are transferred to <paramref name="Obj" /> for fields and properties with public setters.
        /// 
        /// Optionally you can supply a CustomMapper function to map fields to new field names.
        /// </summary>
        [Tested]
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static void CopyFieldsTo<T>([CanBeNull]this T In, [CanBeNull]object Obj, [CanBeNull]Func<string, string> CustomMapper = null)
            {
            var CustomMappedKeys = new List<string>();
            if (Obj != null)
                {
                foreach (var Member in typeof(T).GetMembers())
                    {
                    if (Member is MethodInfo)
                        continue;

                    string Name = "";

                    if (Obj.HasProperty(Member.Name))
                        {
                        Name = Member.Name;
                        }
                    // Custom mapper takes precedence
                    if (CustomMapper != null)
                        {
                        Name = CustomMapper(Member.Name);
                        if (CustomMappedKeys.Contains(Name))
                            continue;
                        if (Member.Name != Name)
                            CustomMappedKeys.Add(Name);
                        }

                    var Member2 = Obj.GetType().GetMember(Name).FirstOrDefault();

                    if ((Member2 is PropertyInfo && ((PropertyInfo)Member2).CanWrite) ||
                        Member2 is FieldInfo)
                        Obj.SetProperty(Name, In.GetProperty(Member.Name));
                    }
                }
            }

        #endregion

        #region Details
        /// <summary>
        /// Returns a JSON-formatted string detailing the object and its public properties.
        /// Fields that return an error are hidden by defaults
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In">Source object</param>
        /// <param name="ShowErrorFields">Hide fields that throw errors? Default is true.</param>
        /// <returns></returns>
        [Tested]
        public static string Details<T>(this T In, bool ShowErrorFields = false)
            {
            string Out = $"{typeof(T).FullName} {{\r\n";

            Out += typeof(T).GetMembers().CollectStr((i, Member) =>
                {
                    if (!(Member is PropertyInfo || Member is FieldInfo))
                        return "";

                    string Out2 = Member.Name;

                    try
                        {
                        var FieldInfo = Member as FieldInfo;
                        if (FieldInfo != null)
                            {
                            Out2 += $": {FieldInfo.GetValue(In)}\r\n";
                            }
                        var PropertyInfo = Member as PropertyInfo;
                        if (PropertyInfo != null)
                            {
                            Out2 += $": {PropertyInfo.GetValue(In)}\r\n";
                            }
                        }
                    catch (Exception Ex)
                        {
                        if (!ShowErrorFields)
                            return "";

                        Out2 += $": {Ex.Message}\r\n";
                        }
                    return Out2;
                });

            Out += "}";

            return Out;
            }
        #endregion

        #region FN_CreateArray
        /// <summary>
        /// Returns a function that creates a new Array from parameters
        /// </summary>
        [Tested]
        public static Func<T[]> FN_CreateArray<T>(this T In)
            {
            return () => new[] { In };
            }

        /// <summary>
        /// Returns a function that creates a new Array containing <paramref name="Count" /> instances of <paramref name="In" />
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="Count" /> is less than 0.</exception>
        [Tested]
        public static Func<T[]> FN_CreateArray<T>(this T In, int Count)
            {
            if (Count < 0) throw new ArgumentOutOfRangeException(nameof(Count));

            return () =>
            {
                var Out = new T[Count];
                Out = Out.Fill(In);
                return Out;
            };
            }

        #endregion

        #region FN_CreateList
        /// <summary>
        /// Returns a function that creates a new List from parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Func<List<T>> FN_CreateList<T>(this T In)
            {
            return () =>
            {
                var Out = new List<T> { In };
                return Out;
            };
            }

        /// <summary>
        /// Returns a function that creates a new List from parameters.
        /// If <paramref name="Count" /> is passed, the List will be filled with <paramref name="Count" /> instances of <paramref name="In" />
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="Count" /> is less than 0.</exception>
        [Tested]
        public static Func<List<T>> FN_CreateList<T>(this T In, int Count)
            {
            if (Count < 0) throw new ArgumentOutOfRangeException(nameof(Count));

            return () =>
            {
                var Out = new List<T>();
                if (Count == 0)
                    return Out;
                new Action(() => Out.Add(In)).Repeat((uint)Count - 1)();
                return Out;
            };
            }
        #endregion

        #region FN_Func
        /// <summary>
        /// Retrieves a function that returns the input parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In">The parameter will be returned by the function</param>
        /// <returns>A function that returns the input parameter <paramref name="In" /></returns>
        [Tested]
        public static Func<T> FN_Func<T>(this T In)
            {
            return L.Logic.Return(In);
            }
        #endregion

        #region FN_If
        /// <summary>
        /// Returns a function that returns true if the object supplied is equal to the Input parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <returns>A function that returns true if the object supplied is equal to the Input parameter</returns>
        [Tested]
        public static Func<T, bool> FN_If<T>(this T In)
            {
            return Obj => L.Obj.SafeEquals(In, Obj);
            }
        #endregion

        #region InitProperties

        /// <summary>
        /// Initializes an object's properties of type <typeparamref name="T" /> to <paramref name="InitValue" /> or their default values.
        /// Only affects properties of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <param name="InitValue"></param>
        /// <exception cref="TargetException">Throws an exception if the a property setter throws an exception.</exception>
        /// <exception cref="FieldAccessException">Throws an exception if the field cannot be accessed.</exception>
        [Tested]
        public static void InitProperties<T>([CanBeNull]this object In, [CanBeNull]T InitValue = default(T))
            {
            if (In != null)
                {
                var ObjType = In.GetType();
                MemberInfo[] Members = ObjType.GetMembers();

                foreach (var Member in Members)
                    {
                    if (Member.GetMemberType() != typeof(T))
                        {
                        continue;
                        }

                    var PropertyInfo = Member as PropertyInfo;
                    if (PropertyInfo != null && PropertyInfo.CanWrite)
                        {
                        PropertyInfo.SetValue(In, InitValue.SafeEquals(default(T)) ? typeof(T).New<T>() : InitValue);
                        }
                    else
                        {
                        var FieldInfo = Member as FieldInfo;
                        FieldInfo?.SetValue(In, InitValue.SafeEquals(default(T)) ? typeof(T).New<T>() : InitValue);
                        }
                    }
                }
            }
        #endregion

        #region IsNull
        /// <summary>
        /// Returns whether the supplied object is null, or equivalent to the default of its type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [TestResult(new object[] { null }, true)]
        [TestResult(new object[] { "" }, false)]
        [TestMethodGenerics(typeof(string))]
        public static bool IsNull<T>(this T In)
            {
            return L.Obj.IsNull<T>()(In);
            }
        #endregion

        #region SafeEquals
        /// <summary>
        /// Safely compare any two Objects whether either is null.
        /// </summary>
        /// <param name="In"></param>
        /// <param name="Obj"></param>
        /// <returns>True if the objects are equal otherwise false</returns>
        [Tested]
        public static bool SafeEquals(this object In, object Obj)
            {
            return L.Obj.SafeEquals(In, Obj);
            }
        #endregion

        #region SupplyTo - T
        #region SupplyTo - T - Action_T1
        /// <summary>
        /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj">The parameter supplied</param>
        /// <param name="In">The action</param>
        /// <returns>An action with one less parameter input</returns>
        [Tested]
        public static Action SupplyTo<T>(this T Obj, Action<T> In)
            {
            return () => { In(Obj); };
            }
        #endregion
        /*    #region SupplyTo - T - Action_T2
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2> SupplyTo<T1, T2>(T1 Obj, Action<T1, T2> In)
                {
                return o => { In(Obj, o); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included.
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1> SupplyTo2<T1, T2>(T2 Obj, Action<T1, T2> In)
                {
                return o => { In(o, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T3
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3> SupplyTo<T1, T2, T3>(T1 Obj, Action<T1, T2, T3> In)
                {
                return (o1, o2) => { In(Obj, o1, o2); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3> SupplyTo2<T1, T2, T3>(T2 Obj, Action<T1, T2, T3> In)
                {
                return (o1, o2) => { In(o1, Obj, o2); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2> SupplyTo3<T1, T2, T3>(T3 Obj, Action<T1, T2, T3> In)
                {
                return (o1, o2) => { In(o1, o2, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T4
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4> SupplyTo<T1, T2, T3, T4>(T1 Obj, Action<T1, T2, T3, T4> In)
                {
                return (o1, o2, o3) => { In(Obj, o1, o2, o3); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4> SupplyTo2<T1, T2, T3, T4>(T2 Obj, Action<T1, T2, T3, T4> In)
                {
                return (o1, o2, o3) => { In(o1, Obj, o2, o3); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4> SupplyTo3<T1, T2, T3, T4>(T3 Obj, Action<T1, T2, T3, T4> In)
                {
                return (o1, o2, o3) => { In(o1, o2, Obj, o3); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3> SupplyTo4<T1, T2, T3, T4>(T4 Obj, Action<T1, T2, T3, T4> In)
                {
                return (o1, o2, o3) => { In(o1, o2, o3, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T5
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5> SupplyTo<T1, T2, T3, T4, T5>(T1 Obj, Action<T1, T2, T3, T4, T5> In)
                {
                return (o1, o2, o3, o4) => { In(Obj, o1, o2, o3, o4); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5> SupplyTo2<T1, T2, T3, T4, T5>(T2 Obj, Action<T1, T2, T3, T4, T5> In)
                {
                return (o1, o2, o3, o4) => { In(o1, Obj, o2, o3, o4); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5> SupplyTo3<T1, T2, T3, T4, T5>(T3 Obj, Action<T1, T2, T3, T4, T5> In)
                {
                return (o1, o2, o3, o4) => { In(o1, o2, Obj, o3, o4); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5> SupplyTo4<T1, T2, T3, T4, T5>(T4 Obj, Action<T1, T2, T3, T4, T5> In)
                {
                return (o1, o2, o3, o4) => { In(o1, o2, o3, Obj, o4); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4> SupplyTo5<T1, T2, T3, T4, T5>(T5 Obj, Action<T1, T2, T3, T4, T5> In)
                {
                return (o1, o2, o3, o4) => { In(o1, o2, o3, o4, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T6
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6> SupplyTo<T1, T2, T3, T4, T5, T6>(T1 Obj, Action<T1, T2, T3, T4, T5, T6> In)
                {
                return (o1, o2, o3, o4, o5) => { In(Obj, o1, o2, o3, o4, o5); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6> SupplyTo2<T1, T2, T3, T4, T5, T6>(T2 Obj, Action<T1, T2, T3, T4, T5, T6> In)
                {
                return (o1, o2, o3, o4, o5) => { In(o1, Obj, o2, o3, o4, o5); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6> SupplyTo3<T1, T2, T3, T4, T5, T6>(T3 Obj, Action<T1, T2, T3, T4, T5, T6> In)
                {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, Obj, o3, o4, o5); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6> SupplyTo4<T1, T2, T3, T4, T5, T6>(T4 Obj, Action<T1, T2, T3, T4, T5, T6> In)
                {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, Obj, o4, o5); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6> SupplyTo5<T1, T2, T3, T4, T5, T6>(T5 Obj, Action<T1, T2, T3, T4, T5, T6> In)
                {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4, Obj, o5); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5> SupplyTo6<T1, T2, T3, T4, T5, T6>(T6 Obj, Action<T1, T2, T3, T4, T5, T6> In)
                {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4, o5, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T7
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7> SupplyTo<T1, T2, T3, T4, T5, T6, T7>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(Obj, o1, o2, o3, o4, o5, o6); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7> SupplyTo2<T1, T2, T3, T4, T5, T6, T7>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, Obj, o2, o3, o4, o5, o6); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7> SupplyTo3<T1, T2, T3, T4, T5, T6, T7>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, Obj, o3, o4, o5, o6); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7> SupplyTo4<T1, T2, T3, T4, T5, T6, T7>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, Obj, o4, o5, o6); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7> SupplyTo5<T1, T2, T3, T4, T5, T6, T7>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, Obj, o5, o6); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7> SupplyTo6<T1, T2, T3, T4, T5, T6, T7>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5, Obj, o6); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6> SupplyTo7<T1, T2, T3, T4, T5, T6, T7>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5, o6, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T8
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(Obj, o1, o2, o3, o4, o5, o6, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, Obj, o2, o3, o4, o5, o6, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, Obj, o3, o4, o5, o6, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, Obj, o4, o5, o6, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, Obj, o5, o6, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, Obj, o6, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6, Obj, o7); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6, o7, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T9
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T10
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T11
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #11 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T11 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj); };
                }

            #endregion
            #region SupplyTo - T - Action_T12
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #11 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T11 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #12 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T12 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T13
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #11 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #12 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #13 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj); };
                }
            #endregion

            #region SupplyTo - T - Action_T14
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #11 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T11 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #12 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T12 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #13 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T13 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj, o13); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #14 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> SupplyTo14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T14 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T15
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #11 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T11 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #12 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T12 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #13 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T13 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj, o13, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #14 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15> SupplyTo14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T14 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, Obj, o14); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #15 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> SupplyTo15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T15 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, Obj); };
                }
            #endregion
            #region SupplyTo - T - Action_T16
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #1 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #2 in action <paramref name="In" />.
            /// </summary>
            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T2 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #3 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T3 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #4 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T4 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #5 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T5 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #6 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T6 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #7 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T7 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #8 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T8 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #9 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T9 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #10 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T10 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #11 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T11 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #12 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T12 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #13 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T13 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj, o13, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #14 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16> SupplyTo14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T14 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, Obj, o14, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #15 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16> SupplyTo15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T15 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, Obj, o15); };
                }
            /// <summary>
            /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
            /// Inserts the parameter #16 in action <paramref name="In" />.
            /// </summary>

            /// <param name="Obj">The parameter supplied</param>
            /// <param name="In">The action</param>
            /// <returns>An action with one less parameter input</returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> SupplyTo16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T16 Obj, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, Obj); };
                }
            #endregion*/

        #region SupplyTo - T - Func_T1

        /// <summary>
        /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
        /// Inserts the parameter #1 in func <paramref name="In" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Obj">The parameter supplied</param>
        /// <param name="In">The action</param>
        /// <returns>A func with one less parameter input</returns>
        [Tested]
        public static Func<U> SupplyTo<T, U>(this T Obj, Func<T, U> In)
            {
            return () => In(Obj);
            }
        #endregion
        /*        #region SupplyTo - T - Func_T2
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>
                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, U> SupplyTo<T1, T2, U>(T1 Obj, Func<T1, T2, U> In)
                    {
                    return o => In(Obj, o);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>
                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, U> SupplyTo2<T1, T2, U>(T2 Obj, Func<T1, T2, U> In)
                    {
                    return o => In(o, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T3
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, U> SupplyTo<T1, T2, T3, U>(T1 Obj, Func<T1, T2, T3, U> In)
                    {
                    return (o1, o2) => In(Obj, o1, o2);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, U> SupplyTo2<T1, T2, T3, U>(T2 Obj, Func<T1, T2, T3, U> In)
                    {
                    return (o1, o2) => In(o1, Obj, o2);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, U> SupplyTo3<T1, T2, T3, U>(T3 Obj, Func<T1, T2, T3, U> In)
                    {
                    return (o1, o2) => In(o1, o2, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T4
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, U> SupplyTo<T1, T2, T3, T4, U>(T1 Obj, Func<T1, T2, T3, T4, U> In)
                    {
                    return (o1, o2, o3) => In(Obj, o1, o2, o3);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, U> SupplyTo2<T1, T2, T3, T4, U>(T2 Obj, Func<T1, T2, T3, T4, U> In)
                    {
                    return (o1, o2, o3) => In(o1, Obj, o2, o3);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, U> SupplyTo3<T1, T2, T3, T4, U>(T3 Obj, Func<T1, T2, T3, T4, U> In)
                    {
                    return (o1, o2, o3) => In(o1, o2, Obj, o3);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, U> SupplyTo4<T1, T2, T3, T4, U>(T4 Obj, Func<T1, T2, T3, T4, U> In)
                    {
                    return (o1, o2, o3) => In(o1, o2, o3, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T5
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, U> SupplyTo<T1, T2, T3, T4, T5, U>(T1 Obj, Func<T1, T2, T3, T4, T5, U> In)
                    {
                    return (o1, o2, o3, o4) => In(Obj, o1, o2, o3, o4);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, U> SupplyTo2<T1, T2, T3, T4, T5, U>(T2 Obj, Func<T1, T2, T3, T4, T5, U> In)
                    {
                    return (o1, o2, o3, o4) => In(o1, Obj, o2, o3, o4);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, U> SupplyTo3<T1, T2, T3, T4, T5, U>(T3 Obj, Func<T1, T2, T3, T4, T5, U> In)
                    {
                    return (o1, o2, o3, o4) => In(o1, o2, Obj, o3, o4);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, U> SupplyTo4<T1, T2, T3, T4, T5, U>(T4 Obj, Func<T1, T2, T3, T4, T5, U> In)
                    {
                    return (o1, o2, o3, o4) => In(o1, o2, o3, Obj, o4);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, U> SupplyTo5<T1, T2, T3, T4, T5, U>(T5 Obj, Func<T1, T2, T3, T4, T5, U> In)
                    {
                    return (o1, o2, o3, o4) => In(o1, o2, o3, o4, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T6
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, U> SupplyTo<T1, T2, T3, T4, T5, T6, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => In(Obj, o1, o2, o3, o4, o5);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, U> SupplyTo2<T1, T2, T3, T4, T5, T6, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => In(o1, Obj, o2, o3, o4, o5);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, U> SupplyTo3<T1, T2, T3, T4, T5, T6, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => In(o1, o2, Obj, o3, o4, o5);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, U> SupplyTo4<T1, T2, T3, T4, T5, T6, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => In(o1, o2, o3, Obj, o4, o5);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, U> SupplyTo5<T1, T2, T3, T4, T5, T6, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => In(o1, o2, o3, o4, Obj, o5);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, U> SupplyTo6<T1, T2, T3, T4, T5, T6, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => In(o1, o2, o3, o4, o5, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T7
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(Obj, o1, o2, o3, o4, o5, o6);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(o1, Obj, o2, o3, o4, o5, o6);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(o1, o2, Obj, o3, o4, o5, o6);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(o1, o2, o3, Obj, o4, o5, o6);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(o1, o2, o3, o4, Obj, o5, o6);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(o1, o2, o3, o4, o5, Obj, o6);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => In(o1, o2, o3, o4, o5, o6, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T8
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(Obj, o1, o2, o3, o4, o5, o6, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, Obj, o2, o3, o4, o5, o6, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, o2, Obj, o3, o4, o5, o6, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, o2, o3, Obj, o4, o5, o6, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, o2, o3, o4, Obj, o5, o6, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, o2, o3, o4, o5, Obj, o6, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, o2, o3, o4, o5, o6, Obj, o7);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => In(o1, o2, o3, o4, o5, o6, o7, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T9
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T10
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T11
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #11 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(T11 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T12
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #11 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, U> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T11 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #12 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(T12 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T13
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #11 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, U> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T11 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #12 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, U> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T12 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #13 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(T13 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T14
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #11 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, U> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T11 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #12 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, U> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T12 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #13 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, U> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T13 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj, o13);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #14 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> SupplyTo14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(T14 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T15
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #11 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, U> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T11 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #12 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, U> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T12 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #13 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, U> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T13 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj, o13, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #14 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, U> SupplyTo14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T14 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, Obj, o14);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #15 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> SupplyTo15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(T15 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, Obj);
                    }
                #endregion
                #region SupplyTo - T - Func_T16
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #1 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T1 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(Obj, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #2 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T2 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #3 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T3 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #4 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T4 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #5 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T5 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #6 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T6 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, Obj, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #7 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T7 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, Obj, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #8 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T9, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T8 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, Obj, o8, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #9 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10, T11, T12, T13, T14, T15, T16, U> SupplyTo9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T9 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, Obj, o9, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #10 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11, T12, T13, T14, T15, T16, U> SupplyTo10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T10 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, Obj, o10, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #11 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T12, T13, T14, T15, T16, U> SupplyTo11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T11 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, Obj, o11, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #12 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T13, T14, T15, T16, U> SupplyTo12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T12 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, Obj, o12, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #13 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T14, T15, T16, U> SupplyTo13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T13 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, Obj, o13, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #14 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T15, T16, U> SupplyTo14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T14 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, Obj, o14, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #15 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T16, U> SupplyTo15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T15 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, Obj, o15);
                    }
                /// <summary>
                /// Supplies a parameter <paramref name="Obj" /> so it does not need to be included
                /// Inserts the parameter #16 in func <paramref name="In" />.
                /// </summary>

                /// <param name="Obj">The parameter supplied</param>
                /// <param name="In">The action</param>
                /// <returns>A func with one less parameter input</returns>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> SupplyTo16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(T16 Obj, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, Obj);
                    }
                #endregion*/
        #endregion

        #region ToS
        /// <summary>
        /// Shorthand function to convert any object to a string.
        /// </summary>
        /// <param name="In">Object to be converted</param>
        /// <returns>A String representation of the object passed.</returns>
        [Tested]
        public static string ToS(this object In)
            {
            return L.Str.ToS(In);
            }
        #endregion

        #region Traverse
        /// <summary>
        /// Traverses an object structure using a traverser function you supply <paramref name="Traverser" />
        /// </summary>
        /// <param name="In">Source object</param>
        /// <param name="Traverser">Traversing function</param>
        [Tested]
        public static void Traverse(this object In, Func<object, object> Traverser)
            {
            var Cursor = In;

            while (Cursor != null)
                {
                Cursor = Traverser(Cursor);
                }
            }

        /// <summary>
        /// Traverses an object structure using a traverser function you supply <paramref name="Traverser" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In">Source object</param>
        /// <param name="Traverser">Traversing function</param>
        [Tested]
        public static void Traverse<T>(this T In, Func<T, T> Traverser)
            {
            var Cursor = In;

            while (Cursor != null)
                {
                Cursor = Traverser(Cursor);
                }
            }
        #endregion

        #endregion
        }
    }
