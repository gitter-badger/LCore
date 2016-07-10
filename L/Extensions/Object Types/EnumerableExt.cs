﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using LCore.Extensions.Optional;
using LCore.Tests;
using NSort;
using LCore.Naming;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for list types:
    /// List[T], T[], IEnumerable[T]
    /// </summary>
    [ExtensionProvider]
    public static class EnumerableExt
        {
        #region Extensions +

        #region Add
        /// <summary>
        /// Returns a new T[] with the supplied items appended to it.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestResult(new object[] { null, null }, new int[] { })]
        [TestResult(new object[] { null, new int[] { } }, new int[] { })]
        [TestResult(new object[] { null, new[] { 1 } }, new[] { 1 })]
        [TestResult(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestResult(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static T[] Add<T>(this T[] In, IEnumerable<T> Objs)
            {
            In = In ?? new T[] { };
            Objs = Objs ?? new T[] { };

            int Count = In.Count();
            int CountTotal = In.Count() + Objs.Count();

            if (Count == CountTotal)
                return In;
            if (Count == 0)
                return Objs.ToArray();

            var Out = new T[CountTotal];
            In.CopyTo(Out, 0);
            Objs.Each((i, o) => { Out[Count + i] = o; });
            return Out;
            }

        /// <summary>
        /// Returns a new T[] with the supplied items appended to it.
        /// </summary>
        /// 
        [TestMethodGenerics(typeof(int))]
        [TestResult(new object[] { null, null }, new int[] { })]
        [TestResult(new object[] { null, new int[] { } }, new int[] { })]
        [TestResult(new object[] { null, new[] { 1 } }, new[] { 1 })]
        [TestResult(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestResult(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static T[] Add<T>(this T[] In, params T[] Objs)
            {
            In = In ?? new T[] { };
            Objs = Objs ?? new T[] { };

            int Count = In.Count();
            int CountTotal = In.Count() + Objs.Count();

            if (Count == CountTotal)
                return In;
            if (Count == 0)
                return Objs;

            var Out = new T[CountTotal];
            In.CopyTo(Out, 0);
            Objs.CopyTo(Out, Count);
            return Out;
            }

        /// <summary>
        /// Appends the supplied List[T] with the supplied items.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { null, null }, typeof(ArgumentNullException))]
        [TestFails(new object[] { null, new int[] { } }, typeof(ArgumentNullException))]
        [TestFails(new object[] { null, new[] { 1 } }, typeof(ArgumentNullException))]
        [TestSource(new object[] { new int[] { }, null }, new int[] { })]
        [TestSource(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static void Add<T>(this List<T> In, params T[] Objs)
            {
            In.Add((IEnumerable<T>)Objs);
            }

        /// <summary>
        /// Appends the supplied List[T] with the supplied items.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { null, null }, typeof(ArgumentNullException))]
        [TestFails(new object[] { null, new int[] { } }, typeof(ArgumentNullException))]
        [TestFails(new object[] { null, new[] { 1 } }, typeof(ArgumentNullException))]
        [TestSource(new object[] { new int[] { }, null }, new int[] { })]
        [TestSource(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static void Add<T>(this List<T> In, IEnumerable<T> Objs)
            {
            if (In == null)
                throw new ArgumentNullException(nameof(In));
            if (Objs.IsEmpty())
                return;

            foreach (var obj in Objs)
                {
                if (!In.Contains(obj))
                    {
                    In.Add(obj);
                    }
                }
            }


        /// <summary>
        /// Adds many T [Items] to an IList[T] [In] in one command.
        /// </summary>
        public static void Add<T>(this IList<T> In, params T[] Items)
            {
            Items = Items ?? new T[] { };

            foreach (var Item in Items)
                {
                In.Add(Item);
                }
            }

        #endregion

        #region AddTo
        /// <summary>
        /// Adds the item of the supplied collection to the second supplied collection.
        /// This method tries to look for the Collection's Add method, if it exists.
        /// </summary>
        public static void AddTo<T>(this IEnumerable<T> In, ICollection Collection)
            {
            var CollectionType = Collection.GetType();

            var AddMethod = CollectionType.GetMethod("Add", new[] { typeof(T) }) ??
                                   CollectionType.GetMethod("Add", new[] { typeof(object) });

            if (AddMethod == null)
                throw new Exception($"Could not find \'Add\' method for type \'{typeof(T)}\'");

            In.Each(o => { AddMethod.Invoke(Collection, new object[] { o }); });
            }
        #endregion

        #region All
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All(this IEnumerable In, Func<object, bool> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool All<T>(this IEnumerable<T> In, Func<T, bool> Condition)
            {
            return In.While(Condition);
            }
        #endregion

        #region All I
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool All(this IEnumerable In, Func<int, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All<T>(this IEnumerable<T> In, Func<int, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All(this IEnumerable In, Func<int, object, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All<T>(this IEnumerable In, Func<int, T, bool> Condition)
            {
            return In.List<T>().WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All<T>(this IEnumerable<T> In, Func<int, T, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        #endregion

        #region Append
        /// <summary>
        /// Returns a new T[] with [Obj] appended to [In].
        /// </summary>
        public static T[] Append<T>(this T[] In, params T[] Obj)
            {
            if (In == null)
                In = new T[] { };
            if (Obj == null)
                return In;

            var Out = new T[In.Length + Obj.Length];
            In.CopyTo(Out, 0);
            Obj.CopyTo(Out, In.Length);
            return Out;
            }
        #endregion

        #region Array
        /// <summary>
        /// Converts an IEnumerable to an object[].
        /// </summary>
        public static object[] Array(this IEnumerable In)
            {
            var Out = new object[In.Count()];
            In.Each((i, o) => { Out[i] = o; });
            return Out;
            }
        /// <summary>
        /// Converts an IEnumerable to a T[].
        /// </summary>
        public static T[] Array<T>(this IEnumerable In)
            {
            return In.List<T>().ToArray();
            }
        /// <summary>
        /// Converts an IEnumerable to a T[].
        /// </summary>
        public static T[] Array<T>(this IEnumerable<T> In)
            {
            var Out = new T[In.Count()];
            In.Each((i, o) => { Out[i] = o; });
            return Out;
            }
        /// <summary>
        /// Converts an T[] to a T[] for types where U : T.
        /// Filters out elements of [In] that are not of type [U].
        /// </summary>
        public static U[] Array<T, U>(this T[] In) where U : class, T
            {
            return In.Filter<T, U>();
            }
        #endregion

        #region Collect
        /// <summary>
        /// Runs a Func[Object,Object] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestFails(new object[] { new[] { 1 }, Test.FailOO_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailOO_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementObjectInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementObjectInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementObjectInt_Name }, new object[] { 2, 3, 4 })]
        public static List<object> Collect(this IEnumerable In, Func<object, object> Func)
            {
            In = In ?? new object[] { };
            Func = Func ?? (o => null);
            return In.Cast<object>().Select(Func).Where(obj => obj != null).ToList();
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. 
        /// Null values and values that are not of type T are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        [TestResult(new object[] { new object[] { 1, 2, "a", 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this IEnumerable In, Func<T, T> Func)
            {
            In = In.List<T>();
            Func = Func ?? (o => default(T));

            return In.Cast<T>().Select(Func).Where(obj => obj != null).ToList();
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters.
        /// Returns a list containing the result of the Func[T,T]. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this IEnumerable<T> In, Func<T, T> Func)
            {
            In = In ?? new T[] { };
            Func = Func ?? (o => default(T));

            return In.Select(Func).Where(obj => obj != null).ToList();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[T,T] on the input.
        /// Returns a T[] of the results. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static T[] Collect<T>(this T[] In, Func<T, T> Func)
            {
            Func = Func ?? (o => default(T));
            return In.List().Collect(Func).ToArray();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[T,T] on the input.
        /// Returns a List[T] of the results. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this List<T> In, Func<T, T> Func)
            {
            In = In ?? new List<T>();
            Func = Func ?? (o => default(T));

            return In.Select(Func).Where(obj => obj != null).ToList();
            }
        #endregion

        #region Collect I
        /// <summary>
        /// Runs a Func[Object,Object] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. Null values are excluded.
        /// </summary>
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailIOOFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailIOOFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassI_Name })]
        [TestResult(new object[] { new object[] { 1, 2, 3 }, Test.PassI_Name }, new object[] { 0, 1, 2 })]
        public static List<object> Collect(this IEnumerable In, Func<int, object, object> Func)
            {
            In = In ?? new object[] { };

            var Out = new List<object>();

            int i = 0;
            foreach (var o in In)
                {
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
                i++;
                }
            return Out;
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. 
        /// Null values and values that are not of type T are excluded.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new object[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        public static List<T> Collect<T>(this IEnumerable In, Func<int, T, T> Func)
            {
            In = In ?? new T[] { };

            var Out = new List<T>();

            int i = 0;
            foreach (T o in In)
                {
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
                i++;
                }
            return Out;
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters.
        /// Returns a list containing the result of the Func[T,T]. Null values are excluded.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        public static List<T> Collect<T>(this IEnumerable<T> In, Func<int, T, T> Func)
            {
            In = In ?? new T[] { };

            var Out = new List<T>();

            int i = 0;
            foreach (var o in In)
                {
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
                i++;
                }

            return Out;
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[int,T,T] on the input. 
        /// The int passed is the 0-based index of the current item.
        /// Returns a T[] of the results of the Func. Null values are excluded.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        public static T[] Collect<T>(this T[] In, Func<int, T, T> Func)
            {
            return In.List().Collect(Func).ToArray();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[int,T,T] on the input. 
        /// The int passed is the 0-based index of the current item.
        /// Returns a List[T] of the results of the Func. Null values are excluded.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        public static List<T> Collect<T>(this List<T> In, Func<int, T, T> Func)
            {
            In = In ?? new List<T>();

            int Count = In.Count;
            var Out = new List<T>();
            for (int i = 0; i < Count; i++)
                {
                var o = In[i];
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        #endregion

        #region CollectFunc
        /// <summary>
        /// Runs a Func[T] [Count] times and returns a list with the results.
        /// Returns a list containing the result of the Func[T]. Null values are excluded.
        /// </summary>
        public static List<T> Collect<T>(this Func<T> In, int Count)
            {
            List<T> Out = NewList<List<T>, T>();
            0.To(Count - 1, i => { Out.Add(In()); });
            return Out;
            }
        /// <summary>
        /// Runs a Func[T] [Count] times and returns a list with the results.
        /// Returns a list containing the result of the Func[T]. Null values are excluded.
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<T> CollectI<T>(this Func<int, T> In, int Count)
            {
            List<T> Out = NewList<List<T>, T>();
            0.To(Count - 1, i => { Out.Add(In(i)); });
            return Out;
            }
        #endregion

        #region CollectStr
        /// <summary>
        /// Iterates through a String, applying an action to each char.
        /// </summary>
        public static string Collect(this string In, Func<char, char> Func)
            {
            return new string(In.ToArray().Collect(Func));
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func[int,T,String].
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        public static string CollectStr<T>(this List<T> In, Func<int, T, string> Func)
            {
            return In.CollectStr<T, List<T>>(Func);
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func[int,T,String].
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        public static string CollectStr<T>(this T[] In, Func<int, T, string> Func)
            {
            return In.CollectStr<T, T[]>(Func);
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func[int,T,String].
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        public static string CollectStr<T, U>(this U In, Func<int, T, string> Func) where U : IEnumerable<T>
            {
            string Out = "";
            In.Each((i, o) => { Out += Func(i, o) ?? ""; });
            return Out;
            }
        #endregion

        #region Combine - String
        /// <summary>
        /// Combines a list of strings with no separator.
        /// </summary>
        public static string Combine(this IEnumerable<string> List)
            {
            return List.Combine("");
            }
        /// <summary>
        /// Convert a list of IConvertible to strings, then joins them with a separator character.
        /// </summary>
        public static string Combine<T>(this IEnumerable<T> List, char SeparateChar)
            where T : IConvertible
            {
            return List.Convert(i => i.ToString()).Combine(SeparateChar);
            }
        /// <summary>
        /// Joins a list of strings with a separator character.
        /// </summary>
        public static string Combine(this IEnumerable<string> List, char SeparateChar)
            {
            return List.Combine(SeparateChar.ToString());
            }
        /// <summary>
        /// Convert a list of IConvertible to strings, then joins them with a separator string.
        /// </summary>
        public static string Combine<T>(this IEnumerable<T> List, string SeparateStr)
            where T : IConvertible
            {
            return List.Convert(i => i.ToString()).Combine(SeparateStr);
            }
        #endregion

        #region Convert
        /// <summary>
        /// Iterates through a collection, returning a List[Object] containing the results of the passed Func[Object,Object].
        /// Null values are ignored.
        /// </summary>
        public static List<object> Convert(this IEnumerable In, Func<object, object> Func)
            {
            return In.Convert((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a U[] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static U[] Convert<T, U>(this T[] In, Func<T, U> Func)
            {
            return In.Convert((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this List<T> In, Func<T, U> Func)
            {
            return In.Convert((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this IEnumerable<T> In, Func<T, U> Func)
            {
            return In.Convert((i, o) => Func(o));
            }
        #endregion

        #region ConvertAll
        /// <summary>
        /// Iterates over [In], passing each item to [Func].
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        public static List<object> ConvertAll(this IEnumerable In, Func<object, IEnumerable<object>> Func)
            {
            In = In ?? new object[] { };
            var Out = new List<object>();
            foreach (var o in In)
                {
                IEnumerable<object> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        /// <summary>
        /// Iterates over [In], passing each item to [Func].
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        public static List<U> ConvertAll<T, U>(this IEnumerable In, Func<T, IEnumerable<U>> Func)
            {
            In = In.List<T>();

            var Out = new List<U>();
            foreach (T o in In)
                {
                IEnumerable<U> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        /// <summary>
        /// Iterates over [In], passing each item to [Func].
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        public static List<U> ConvertAll<T, U>(this IEnumerable<T> In, Func<T, IEnumerable<U>> Func)
            {
            In = In ?? new T[] { };

            var Out = new List<U>();
            foreach (var o in In)
                {
                IEnumerable<U> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        /// <summary>
        /// Iterates over [In], passing each item to [Func].
        /// Func can return multiple objects. 
        /// They are all collected and returned in one array.
        /// </summary>
        public static U[] ConvertAll<T, U>(this T[] In, Func<T, IEnumerable<U>> Func)
            {
            return In.List().ConvertAll(Func).ToArray();
            }
        /// <summary>
        /// Iterates over [In], passing each item to [Func].
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        public static List<U> ConvertAll<T, U>(this List<T> In, Func<T, IEnumerable<U>> Func)
            {
            In = In ?? new List<T>();
            var Out = new List<U>();
            foreach (var o in In)
                {
                IEnumerable<U> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        #endregion

        #region Convert I
        /// <summary>
        /// Iterates through a collection, returning a List[Object] containing the results of the passed Func[Object,Object].
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        public static List<object> Convert(this IEnumerable In, Func<int, object, object> Func)
            {
            List<object> Out = NewList<List<object>, object>();
            In.Each((i, o) =>
            {
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
            });
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, returning a U[] containing the results of the passed Func[T,U].
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        public static U[] Convert<T, U>(this T[] In, Func<int, T, U> Func)
            {
            if (In == null)
                return new U[] { };
            var Out = new U[In.Length];
            In.Each((i, o) =>
            {
                Out[i] = Func(i, o);
            });
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[int, T,U].
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this List<T> In, Func<int, T, U> Func)
            {
            List<U> Out = NewList<List<U>, U>();
            In.Each((i, o) =>
            {
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
            });
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[int, T,U].
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this IEnumerable<T> In, Func<int, T, U> Func)
            {
            List<U> Out = NewList<List<U>, U>();
            In.Each((i, o) =>
            {
                var obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
            });
            return Out;
            }
        #endregion

        #region Count
        /// <summary>
        /// Returns the size of a collection
        /// </summary>
        public static int Count<T>(this T In) where T : IEnumerable
            {
            if (In == null)
                {
                return 0;
                }

            var o = In as Array;
            if (o != null)
                {
                return o.Length;
                }
            var list = In as IList;
            if (list != null)
                {
                return list.Count;
                }
            var collection = In as ICollection;
            if (collection != null)
                {
                try
                    {
                    return collection.Count;
                    }
                catch
                    {
                    return 0;
                    }
                }
            string s = In as string;
            if (s != null)
                {
                try
                    {
                    return ((string)(object)In).Length;
                    }
                catch
                    {
                    return 0;
                    }
                }

            int Count = 0;

            var Enumerator = In.GetEnumerator();

            while (Enumerator.MoveNext())
                {
                Count++;
                }

            return Count;
            }
        #endregion

        #region Count Object
        /// <summary>
        /// Returns the number of items in the collection that are equivalent to Obj.
        /// </summary>
        public static int Count<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Count(L.Obj.SafeEquals.Supply(Obj).Cast<object, bool, T, bool>());
            }
        #endregion

        #region Cycle
        /// <summary>
        /// Cycles through a list of objects indefinitely.
        /// If [Continue] returns true at the end, the set of objects will be iterated again.
        /// </summary>
        public static void Cycle(this IEnumerable In, Func<object, bool> Continue)
            {
            while (true)
                {
                bool KeepGoing = In.While(Continue);
                if (!KeepGoing)
                    break;
                }
            }
        /// <summary>
        /// Cycles through a list of objects indefinitely.
        /// If [Continue] returns true at the end, the set of objects will be iterated again.
        /// </summary>
        public static void Cycle<T>(this IEnumerable<T> In, Func<T, bool> Continue)
            {
            while (true)
                {
                bool KeepGoing = In.While(Continue);
                if (!KeepGoing)
                    break;
                }
            }
        #endregion

        #region Each
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.Fail_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.Fail_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveObject_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveObject_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveObject_Name }, Test.HasReceivedObjects_Name)]
        public static void Each(this IEnumerable In, Action<object> Func)
            {
            if (!In.IsEmpty())
                {
                foreach (var o in In)
                    {
                    Func(o);
                    }
                }
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action.
        /// The collection items are used as the parameters to the Action.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveT_Name }, Test.HasReceivedObjects_Name)]
        [TestSucceedes(new object[] { new object[] { 1, 2, "a", 3 }, Test.ReceiveT_Name }, Test.HasReceivedObjectsButNoStrings_Name)]
        public static void Each<T>(this IEnumerable In, Action<T> Func)
            {
            List<T> List = In.Filter<T>();
            List.Each(Func);
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action.
        /// The collection items are used as the parameters to the Action.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveT_Name }, Test.HasReceivedObjects_Name)]
        public static void Each<T>(this IEnumerable<T> In, Action<T> Func)
            {
            if (!In.IsEmpty())
                {
                foreach (var o in In)
                    {
                    Func(o);
                    }
                }
            }



        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action[int, Object].
        /// The int passed to the Action is the 0-based index of the current item.
        /// The collection items are used as the parameters to the Func[int, Object].
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveObjectI_Name }, Test.HasReceivedObjectsI_Name)]
        public static void Each(this IEnumerable In, Action<int, object> Func)
            {
            if (!In.IsEmpty())
                {
                int i = 0;
                foreach (var o in In)
                    {
                    Func(i, o);
                    i++;
                    }
                }
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action[int, Object].
        /// The int passed to the Action is the 0-based index of the current item.
        /// The collection items are used as the parameters to the Action[int, Object].
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new object[] { 1, 2, "", 3 }, Test.ReceiveObjectI_Name }, Test.HasReceivedObjectsI_Name)]
        public static void Each<T>(this IEnumerable In, Action<int, object> Func)
            {
            List<T> List = In.Filter<T>();
            List.Each(Func);
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action[int, T].
        /// The int passed to the Action is the 0-based index of the current item.
        /// The collection items are used as the parameters to the Action[int, T].
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailIT_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailIT_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveTI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveTI_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveTI_Name }, Test.HasReceivedObjectsI_Name)]
        public static void Each<T>(this IEnumerable<T> In, Action<int, T> Func)
            {
            if (!In.IsEmpty())
                {
                int i = 0;
                foreach (var o in In)
                    {
                    Func(i, o);
                    i++;
                    }
                }
            }
        #endregion

        #region Each Object
        /// <summary>
        /// Performs the supplied action on each T in [Obj]
        /// </summary>
        public static void Each<T>(this Action<T> In, IEnumerable<T> Obj)
            {
            Obj.Each(In);
            }
        #endregion

        #region Equivalent

        /// <summary>
        /// Compares the contents of two IEnumerable.
        /// Returns true if their count and all contents are the same.
        /// </summary>
        public static bool Equivalent(this IEnumerable In, IEnumerable Compare)
            {
            if (In == null && Compare == null)
                return true;
            if (In == null || Compare == null)
                return false;
            // Strings are IEnumerable too - we have to test for this just in case.
            string s = In as string;
            if (s != null && Compare is string)
                return s == (string)Compare;

            int Count1 = In.Count();
            int Count2 = Compare.Count();

            return Count1 == Count2 &&
                In.All((i, o) => Compare.GetAt(i).SafeEquals(o));
            }
        #endregion

        #region Fill
        /// <summary>
        /// Returns a new T[] containing [In.Count] entries containing the passed Obj.
        /// </summary>
        public static T[] Fill<T>(this T[] In, T Obj)
            {
            return In.Collect(o => Obj);
            }
        /// <summary>
        /// Returns a new List[T] containing [In.Count] entries containing the passed Obj.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static List<T> Fill<T>(this List<T> In, T Obj)
            {
            return In.Collect(o => Obj);
            }
        #endregion

        #region Filter
        /// <summary>
        /// Returns a new List[T] from the supplied collection. 
        /// Values that are null or are not of type T are not included.
        /// </summary>
        public static List<T> Filter<T>(this IEnumerable In)
            {
            var Out = new List<T>();
            In.Each(o =>
            {
                if (o is T)
                    Out.Add((T)o);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new U[] from the supplied collection. 
        /// Values that are null or are not of type U are not included.
        /// </summary>
        public static U[] Filter<T, U>(this T[] In)
            where U : class
            {
            return In.Convert(L.Ref.As<U>().Cast<object, U, T, U>());
            }
        #endregion

        #region First
        /// <summary>
        /// Returns the first item in the T[].
        /// Returns null if the array is empty.
        /// </summary>
        public static T First<T>(this T[] In)
            {
            return In == null || In.Length == 0 ? default(T) : In[0];
            }
        /// <summary>
        /// Returns a new T[] containing the first [Count] items in the T[].
        /// </summary>
        public static T[] First<T>(this T[] In, int Count)
            {
            return In.First(t => true, Count);
            }
        /// <summary>
        /// Returns the first item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T First<T>(this List<T> In)
            {
            List<T> Result = In.First(t => true, 1);
            return Result.Any() ? Result[0] : default(T);
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items in the source List[T].
        /// </summary>
        public static List<T> First<T>(this List<T> In, int Count)
            {
            return In.First(t => true, Count);
            }
        /// <summary>
        /// Returns the first item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T First<T>(this IEnumerable<T> In)
            {
            return L.F(() => In.GetAt(0)).Try()();
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items in the source List[T].
        /// </summary>
        public static List<T> First<T>(this IEnumerable<T> In, int Count)
            {
            return In.List().First(Count);
            }
        /// <summary>
        /// Returns the first item in the collection of type T.
        /// Returns null if the array is empty.
        /// </summary>
        public static T First<T>(this IEnumerable In)
            {
            return In.First<T>(t => true);
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items in the source collection that are of type T.
        /// </summary>
        public static List<T> First<T>(this IEnumerable In, int Count)
            {
            return In.List<T>().First(Count);
            }
        #endregion

        #region First Func
        /// <summary>
        /// Returns the first item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this IEnumerable In, Func<T, bool> Func)
            {
            return In.List<T>().First(Func);
            }
        /// <summary>
        /// Returns the first item in the source T[] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this T[] In, Func<T, bool> Func)
            {
            T[] Result = In.First(Func, 1);
            return Result.Length > 0 ? Result[0] : default(T);
            }
        /// <summary>
        /// Returns the first item in the source List[T] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this List<T> In, Func<T, bool> Func)
            {
            List<T> Result = In.First(Func, 1);
            return Result.Any() ? Result[0] : default(T);
            }
        /// <summary>
        /// Returns the first item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this IEnumerable<T> In, Func<T, bool> Func)
            {
            return In.List().First(Func);
            }
        /// <summary>
        /// Returns a new T[] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static T[] First<T>(this T[] In, Func<T, bool> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");
            int StartCount = Count;
            var Out = new T[StartCount];

            In.WhileI((i, o) =>
            {
                bool Result = Func(o);
                if (Result)
                    {
                    Out[StartCount - Count] = o;

                    Count--;
                    if (Count == 0)
                        return false;
                    }
                return true;
            });

            if (Count > 0)
                Out = Out.First(Count);

            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> First<T>(this IEnumerable In, Func<T, bool> Func, int Count)
            {
            return In.List<T>().First(Func, Count);
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> First<T>(this List<T> In, Func<T, bool> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");

            List<T> Out = NewList<List<T>, T>();

            In.While(o =>
            {
                bool Result = Func(o);
                if (Result)
                    {
                    Out.Add(o);
                    Count--;
                    if (Count == 0)
                        return false;
                    }
                return true;
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> First<T>(this IEnumerable<T> In, Func<T, bool> Func, int Count)
            {
            return In.List().First(Func, Count);
            }
        #endregion

        #region First Func U
        /// <summary>
        /// Returns the first item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static U First<T, U>(this IEnumerable In, Func<T, U> Func)
            {
            return In.List<T>().First(Func);
            }
        /// <summary>
        /// Returns the first item in the source T[] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static U First<T, U>(this T[] In, Func<T, U> Func)
            {
            U[] Result = In.First(Func, 1);
            return Result.Length > 0 ? Result[0] : default(U);
            }
        /// <summary>
        /// Returns the first item in the source List[T] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static U First<T, U>(this List<T> In, Func<T, U> Func)
            {
            List<U> Result = In.First(Func, 1);
            return Result.Any() ? Result[0] : default(U);
            }
        /// <summary>
        /// Returns the first item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static U First<T, U>(this IEnumerable<T> In, Func<T, U> Func)
            {
            return In.List().First(Func);
            }
        /// <summary>
        /// Returns a new T[] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static U[] First<T, U>(this T[] In, Func<T, U> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");
            int StartCount = Count;
            var Out = new U[StartCount];

            In.WhileI((i, o) =>
            {
                var Result = Func(o);
                if (Result != null)
                    {
                    Out[StartCount - Count] = Result;

                    Count--;
                    if (Count == 0)
                        return false;
                    }
                return true;
            });

            if (Count > 0)
                Out = Out.First(Count);

            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<U> First<T, U>(this IEnumerable In, Func<T, U> Func, int Count)
            {
            return In.List<T>().First(Func, Count);
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<U> First<T, U>(this List<T> In, Func<T, U> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");

            var Out = new List<U>();

            In.While(o =>
            {
                var Result = Func(o);
                if (Result != null)
                    {
                    Out.Add(Result);
                    Count--;
                    if (Count == 0)
                        return false;
                    }
                return true;
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<U> First<T, U>(this IEnumerable<T> In, Func<T, U> Func, int Count)
            {
            return In.List().First(Func, Count);
            }
        #endregion

        #region First Object
        /// <summary>
        /// Returns the first T in the source T[] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this T[] In, T Obj)
            {
            return In.First(Obj.FN_If());
            }
        /// <summary>
        /// Returns the first T in the source List[T] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this List<T> In, T Obj)
            {
            return In.First(Obj.FN_If());
            }
        /// <summary>
        /// Returns the first T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this IEnumerable<T> In, T Obj)
            {
            return In.First(Obj.FN_If());
            }
        /// <summary>
        /// Returns the first T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this IEnumerable In, T Obj)
            {
            return In.First(Obj.FN_If());
            }
        #endregion

        #region Flatten
        /// <summary>
        /// Iterates through a collection and sub-collections and returns a flattened List[T]. 
        /// Ignores all Objects that are not of type T as well as nulls.
        /// </summary>
        public static List<T> Flatten<T>(this IEnumerable In)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each(o =>
            {
                if (o is T)
                    Out.Add((T)o);
                else if (o is IEnumerable)
                    Out.AddRange(((IEnumerable)o).Flatten<T>());
            });
            return Out;
            }
        #endregion

        #region GetAt
        /// <summary>
        /// Returns the item at the specified index.
        /// </summary>
        public static object GetAt(this IEnumerable In, int Index)
            {
            if (In == null)
                return null;

            var @in = In as IList;
            if (@in != null)
                {
                return @in[Index];
                }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (In is Array)
            // ReSharper disable HeuristicUnreachableCode
                {
                return (In as Array).GetValue(Index);
                }
            // ReSharper restore HeuristicUnreachableCode

            string s = In as string;
            if (s != null)
                {
                return s[Index];
                }
            throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Returns the item at the specified index.
        /// </summary>
        public static T GetAt<T>(this IEnumerable<T> In, int Index)
            {
            if (In == null)
                return default(T);

            var @in = In as IList<T>;
            if (@in != null)
                {
                return @in[Index];
                }
            // ReSharper disable once SuspiciousTypeConversion.Global
            var array = In as Array;
            if (array != null)
                {
                return (T)array.GetValue(Index);
                }
            throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Returns a new T[] containing the items at the specified indexes.
        /// </summary>
        public static T[] GetAt<T>(this T[] In, params int[] Indexes)
            {
            return In.SelectI((i, o) => Indexes.Contains(i));
            }
        /// <summary>
        /// Returns a new List[Object] containing the items at the specified indexes.
        /// </summary>
        public static List<object> GetAt(this IEnumerable In, params int[] Indexes)
            {
            return In.List().GetAt(Indexes);
            }
        /// <summary>
        /// Returns a new List[T] containing the items at the specified indexes.
        /// </summary>
        public static List<T> GetAt<T>(this List<T> In, params int[] Indexes)
            {
            return In.SelectI((i, o) => Indexes.Contains(i));
            }
        /// <summary>
        /// Returns a new List[T] containing the items at the specified indexes.
        /// </summary>
        public static List<T> GetAt<T>(this IEnumerable<T> In, params int[] Indexes)
            {
            return In.SelectI((i, o) => Indexes.Contains(i));
            }
        #endregion

        #region Group

        /// <summary>
        /// Groups items implementing interface IGroup from an IEnumerable into a Dictionary[string,List[T]]
        /// </summary>
        public static Dictionary<string, List<T>> Group<T>(this IEnumerable<T> In)
            where T : IGrouped
            {
            return In.Group(o => o.Group ?? "");
            }

        /// <summary>
        /// Groups items into a dictionary using a custom indexer. 
        /// The result of the indexer will be used as the Key for each element.
        /// </summary>
        public static Dictionary<U, List<object>> Group<U>(this IEnumerable In, Func<object, U> Grouper)
            {
            return In.List().Group(Grouper);
            }

        /// <summary>
        /// Groups items into a dictionary using a custom indexer. 
        /// The result of the indexer will be used as the Key for each element.
        /// </summary>
        public static Dictionary<U, List<T>> Group<T, U>(this IEnumerable<T> In, Func<T, U> Grouper)
            {
            var Out = new Dictionary<U, List<T>>();
            In.Each(o =>
            {
                var Index = Grouper(o);
                List<T> L;

                if (Out.ContainsKey(Index))
                    {
                    L = Out[Index];
                    }
                else
                    {
                    L = new List<T>();
                    Out.Add(Index, L);
                    }

                L.Add(o);
            });
            return Out;
            }
        #endregion

        #region GroupDouble
        /// <summary>
        /// Groups items into a 2-level dictionary using 2 custom indexers. 
        /// The result of the indexers will be used as the Keys for each element.
        /// </summary>
        public static Dictionary<U, Dictionary<V, List<T>>> GroupTwice<T, U, V>(this IEnumerable<T> In,
            Func<T, U> Grouper1, Func<T, V> Grouper2)
            {
            Dictionary<U, List<T>> First = In.Group(Grouper1);
            var Out = new Dictionary<U, Dictionary<V, List<T>>>();
            First.Each(kv =>
                {
                    Dictionary<V, List<T>> Dict2 = kv.Value.Group(Grouper2);
                    Out.Add(kv.Key, Dict2);
                });
            return Out;
            }
        #endregion

        #region Has
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        public static bool Has<T>(this IEnumerable In, T Obj)
            {
            return In.Filter<T>().Has(Obj.FN_If());
            }
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        public static bool Has(this IEnumerable In, object Obj)
            {
            return In.Has(Obj.FN_If());
            }
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        public static bool Has<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Has(Obj.FN_If());
            }
        #endregion

        #region HasAny
        /// <summary>
        /// Returns whether or not the source IEnumerable [In] contains any of the elements from [Obj]
        /// </summary>
        public static bool HasAny<T>(this IEnumerable In, IEnumerable<T> Obj)
            {
            return Obj.Has(In.Has);
            }
        /// <summary>
        /// Returns whether or not the source IEnumerable [In] contains any of the elements from [Obj]
        /// </summary>
        public static bool HasAny(this IEnumerable In, IEnumerable Obj)
            {
            return Obj.Has(In.Has);
            }
        /// <summary>
        /// Returns whether or not the source T [In] contains any of the elements from [Obj]
        /// </summary>
        public static bool HasAny<T>(this IEnumerable<T> In, IEnumerable<T> Obj)
            {
            return Obj.Has(In.Has);
            }
        /// <summary>
        /// Returns whether or not the source IEnumerable [In] contains any of the elements from [Obj]
        /// </summary>
        public static bool HasAny(this IEnumerable In, params object[] Obj)
            {
            return In.HasAny((IEnumerable)Obj);
            }
        /// <summary>
        /// Returns whether or not the source T [In] contains any of the elements from [Obj]
        /// </summary>
        public static bool HasAny<T>(this IEnumerable<T> In, params T[] Obj)
            {
            return In.HasAny((IEnumerable<T>)Obj);
            }
        #endregion

        #region Has Func
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        public static bool Has<T>(this IEnumerable In, Func<T, bool> Condition)
            {
            return In.Filter<T>().Has(Condition);
            }
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        public static bool Has(this IEnumerable In, Func<object, bool> Condition)
            {
            bool Found = false;
            In.While(o =>
            {
                Found = Found || Condition(o);
                return !Found;
            });
            return Found;
            }
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        public static bool Has<T>(this IEnumerable<T> In, Func<T, bool> Condition)
            {
            bool Found = false;
            In.While(o =>
            {
                Found = Found || Condition(o);
                return !Found;
            });
            return Found;
            }
        #endregion

        #region HasIndex
        /// <summary>
        /// Returns whether or not a given IEnumerable has an [Index].
        /// </summary>
        public static bool HasIndex(this IEnumerable In, int Index)
            {
            int Count = In.Count();

            return Index >= 0 && Index < Count;
            }
        #endregion

        #region Index
        /// <summary>
        /// Converts an IEnumerable to a Dictionary, using an indexer.
        /// Keys map to values 1 to 1, duplicate key values will be ignored. 
        /// </summary>
        public static Dictionary<U, object> Index<U>(this IEnumerable In, Func<object, U> Indexer)
            {
            return In.List().Index(Indexer);
            }
        /// <summary>
        /// Converts an IEnumerable to a Dictionary, using an indexer.
        /// Keys map to values 1 to 1, duplicate key values will be ignored. 
        /// </summary>
        public static Dictionary<U, T> Index<T, U>(this IEnumerable<T> In, Func<T, U> Indexer)
            {
            var Out = new Dictionary<U, T>();
            In.Each(o =>
            {
                var Index = Indexer(o);

                if (!Out.ContainsKey(Index))
                    Out.Add(Index, o);
            });
            return Out;
            }
        #endregion

        #region IndexTwice
        /// <summary>
        /// Indexes an IEnumerable into a two-level Dictionary.
        /// Using, two indexers, if keys are the same, duplicates will be ignored.
        /// </summary>
        public static Dictionary<U, Dictionary<V, object>> IndexTwice<U, V>(this IEnumerable In, Func<object, U> Indexer1, Func<object, V> Indexer2)
            {
            return In.List().IndexTwice(Indexer1, Indexer2);
            }

        /// <summary>
        /// Indexes an IEnumerable into a two-level Dictionary.
        /// Using, two indexers, if keys are the same, duplicates will be ignored.
        /// </summary>
        public static Dictionary<U, Dictionary<V, T>> IndexTwice<T, U, V>(this IEnumerable<T> In, Func<T, U> Indexer1,
            Func<T, V> Indexer2)
            {
            Dictionary<U, List<T>> First = In.Group(Indexer1);
            var Out = new Dictionary<U, Dictionary<V, T>>();
            First.Each(kv =>
                {
                    Dictionary<V, T> Dict2 = kv.Value.Index(Indexer2);
                    Out.Add(kv.Key, Dict2);
                });
            return Out;
            }

        #endregion

        #region IndexOf
        /// <summary>
        /// Iterates over [In] and returns the index of the first true result from [Func].
        /// </summary>
        public static int IndexOf(this IEnumerable In, Func<object, bool> Func)
            {
            int Out = -1;

            In.WhileI((i, o) =>
            {
                if (Func(o))
                    {
                    Out = i;
                    return false;
                    }
                return true;
            });

            return Out;
            }
        /// <summary>
        /// Iterates over [In] and returns the index of the first true result from [Func].
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> In, Func<T, bool> Func)
            {
            int Out = -1;

            In.WhileI((i, o) =>
            {
                if (Func(o))
                    {
                    Out = i;
                    return false;
                    }
                return true;
            });

            return Out;
            }
        #endregion

        #region IsEmpty
        /// <summary>
        /// Returns whether or not this supplied is null or empty.
        /// </summary>
        public static bool IsEmpty(this IEnumerable In)
            {
            int Count = In.Count();
            return Count == 0;
            }
        #endregion

        #region Last
        /// <summary>
        /// Returns the last item in the T[].
        /// Returns null if the array is empty.
        /// </summary>
        public static T Last<T>(this T[] In)
            {
            return In == null || In.Length == 0 ? default(T) : In[In.Length - 1];
            }
        /// <summary>
        /// Returns a new T[] containing the last [Count] items in the T[].
        /// </summary>
        public static T[] Last<T>(this T[] In, int Count)
            {
            return In.Last(t => true, Count);
            }
        /// <summary>
        /// Returns the last item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T Last<T>(this List<T> In)
            {
            List<T> Result = In.Last(t => true, 1);
            return Result.Any() ? Result[0] : default(T);
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items in the source List[T].
        /// </summary>
        public static List<T> Last<T>(this List<T> In, int Count)
            {
            return In.Last(t => true, Count);
            }
        /// <summary>
        /// Returns the Last item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> In)
            {
            int Count = In.Count();
            return L.F(() => In.GetAt(Count - 1)).Try()();
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items in the source List[T].
        /// </summary>
        public static List<T> Last<T>(this IEnumerable<T> In, int Count)
            {
            return In.List().Last(Count);
            }
        /// <summary>
        /// Returns the last item in the collection of type T.
        /// Returns null if the array is empty.
        /// </summary>
        public static T Last<T>(this IEnumerable In)
            {
            return In.Last<T>(o => true);
            }
        /// <summary>
        /// Returns a new List[T] containing the Last [Count] items in the source collection that are of type T.
        /// </summary>
        public static List<T> Last<T>(this IEnumerable In, int Count)
            {
            return In.List<T>().Last(Count);
            }
        #endregion

        #region Last Func
        /// <summary>
        /// Returns the last item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this IEnumerable In, Func<T, bool> Func)
            {
            return In.List<T>().Last(Func);
            }
        /// <summary>
        /// Returns the last item in the source T[] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this T[] In, Func<T, bool> Func)
            {
            T[] Result = In.Last(Func, 1);
            return Result.Length > 0 ? Result[0] : default(T);
            }
        /// <summary>
        /// Returns the last item in the source List[T] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this List<T> In, Func<T, bool> Func)
            {
            List<T> Result = In.Last(Func, 1);
            return Result.Any() ? Result[0] : default(T);
            }
        /// <summary>
        /// Returns the last item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> In, Func<T, bool> Func)
            {
            return In.List().Last(Func);
            }
        /// <summary>
        /// Returns a new T[] containing the last [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static T[] Last<T>(this T[] In, Func<T, bool> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");
            int StartCount = Count;
            var Out = new T[StartCount];

            (In.Length - 1).To(0, i =>
            {
                var o = In[i];
                bool Result = Func(o);
                if (Result)
                    {
                    Out[StartCount - Count] = o;

                    Count--;
                    if (Count == 0)
                        return false;
                    }
                return true;
            });

            if (Count > 0)
                Out = Out.First(Count);

            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Last<T>(this IEnumerable In, Func<T, bool> Func, int Count)
            {
            return In.List<T>().Last(Func, Count);
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Last<T>(this List<T> In, Func<T, bool> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");

            List<T> Out = NewList<List<T>, T>();

            (In.Count - 1).To(0, i =>
            {
                var o = In[i];
                bool Result = Func(o);
                if (Result)
                    {
                    Out.Add(o);
                    Count--;
                    if (Count == 0)
                        return false;
                    }
                return true;
            });

            if (Count > 0)
                Out = Out.First(Count);

            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Last<T>(this IEnumerable<T> In, Func<T, bool> Func, int Count)
            {
            return In.List().Last(Func, Count);
            }
        #endregion

        #region Last Object
        /// <summary>
        /// Returns the last T in the source T[] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this T[] In, T Obj)
            {
            return In.Last(Obj.FN_If());
            }
        /// <summary>
        /// Returns the last T in the source List[T] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this List<T> In, T Obj)
            {
            return In.Last(Obj.FN_If());
            }
        /// <summary>
        /// Returns the last T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Last(Obj.FN_If());
            }
        /// <summary>
        /// Returns the last T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this IEnumerable In, T Obj)
            {
            return In.Last(Obj.FN_If());
            }
        #endregion

        #region List
        /// <summary>
        /// Returns a new List[Object] from the supplied collection.
        /// </summary>
        public static List<object> List(this IEnumerable In)
            {
            return In.Cast<object>().ToList();
            }

        /// <summary>
        /// Creates a new List[T] from the supplied collection.
        /// This method cannot fail.
        /// </summary>
        public static List<T> List<T>(this IEnumerable<T> In)
            {
            var Out = new List<T>();
            if (!In.IsEmpty())
                Out.AddRange(In);
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] from the supplied collection.
        /// Nulls and values that are not of type T are not included.
        /// </summary>
        public static List<T> List<T>(this IEnumerable In)
            {
            return In.Filter<T>();
            }
        /// <summary>
        /// Returns a new List[U] from the supplied collection[T].
        /// Nulls and values that are not of type U are not included.
        /// </summary>
        public static List<U> List<T, U>(this IEnumerable<T> In)
            {
            return In.Filter<U>();
            }
        #endregion

        #region Move

        /// <summary>
        /// Moves items in an array, recursively shifting items where needed.
        /// </summary>
        public static void Move<T>(this T[] In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");
            if (Index1 == Index2)
                return;

            In.Swap(Index1, Index2);

            if (Index1 < Index2)
                {
                In.Move(Index1 + 1, Index2);
                }
            else if (Index1 > Index2)
                {
                In.Move(Index1 - 1, Index2);
                }
            }

        /// <summary>
        /// Moves items in an IList, shifting items where needed.
        /// </summary>
        public static void Move(this IList In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            var temp = In[Index1];

            In.RemoveAt(Index1);

            In.Insert(Index2, temp);
            }
        #endregion

        #region Named
        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static List<INamed> Named(this IEnumerable In, string Name)
            {
            return In.List<INamed>().Select(o => o?.Name == Name);
            }
        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static T[] Named<T>(this T[] In, string Name)
            where T : INamed
            {
            return In.Select(o => o?.Name == Name);
            }
        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static List<T> Named<T>(this List<T> In, string Name)
            where T : INamed
            {
            return In.Select(o => o?.Name == Name);
            }

        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static IEnumerable<T> Named<T>(this IEnumerable<T> In, string Name)
            where T : INamed
            {
            return In.Where(o => o?.Name == Name);
            }

        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static List<object> Named(this IEnumerable In, string Name, Func<object, string> Namer)
            {
            return In.List<object>().Select(o => o != null && Namer(o) == Name);
            }
        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static List<T> Named<T>(this IEnumerable<T> In, string Name, Func<T, string> Namer)
            {
            return In.List().Select(o => o != null && Namer(o) == Name);
            }
        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static T[] Named<T>(this T[] In, string Name, Func<T, string> Namer)
            {
            return In.Select(o => o != null && Namer(o) == Name);
            }
        /// <summary>
        /// Returns all items within [In] that have the given [Name]
        /// </summary>
        public static List<T> Named<T>(this List<T> In, string Name, Func<T, string> Namer)
            {
            return In.Select(o => o != null && Namer(o) == Name);
            }
        #endregion

        #region NewList
        /// <summary>
        /// Creates a new list of the specified type.
        /// Types supported: U[], List[T], String
        /// </summary>
        public static T NewList<T, U>()
            {
            object Out;
            if (typeof(T).IsArray)
                {
                Out = new U[] { };
                }
            else if (typeof(T).TypeEquals(typeof(List<U>)))
                {
                Out = new List<U>();
                }
            else if (typeof(T).TypeEquals(typeof(string)))
                {
                Out = "";
                }
            else
                throw new Exception(typeof(T).FullName);

            return (T)Out;
            }
        #endregion

        #region Random
        private static int _RandomSeed = new Random().Next();
        /// <summary>
        /// Returns a single random T from an IEnumerable[T].
        /// </summary>
        public static T RandomItem<T>(this IEnumerable<T> In)
            {
            return In.Random(1)[0];
            }
        /// <summary>
        /// Returns a new List[T] containing [Count] random items from the collection.
        /// If Count is higher than In.Count, an ArgumentException will be thrown.
        /// This method will not include any single index more than once unless AllowDuplicates is set to true.
        /// </summary>
        public static List<T> Random<T>(this IEnumerable<T> In, int Count, bool AllowDuplicates = false)
            {
            int Count2 = In.Count();
            if (Count > Count2)
                throw new ArgumentException("Count");

            var RandomIndexes = new List<int>();

            var rand = new Random(_RandomSeed);
            _RandomSeed = rand.Next();
            while (RandomIndexes.Count < Count)
                {
                int r = rand.Next(Count2);
                if (!AllowDuplicates && !RandomIndexes.Contains(r))
                    RandomIndexes.Add(r);
                }

            return RandomIndexes.Convert(In.GetAt);
            }
        /// <summary>
        /// Returns a new T[] containing [Count] random items from the source T[].
        /// If Count is higher than In.Count, an ArgumentException will be thrown.
        /// </summary>
        public static T[] Random<T>(this T[] In, int Count)
            {
            int Count2 = In.Count();
            if (Count > Count2)
                throw new ArgumentException("Count");

            var RandomIndexes = new List<int>();

            var rand = new Random(_RandomSeed);
            _RandomSeed = rand.Next();

            while (RandomIndexes.Count < Count)
                {
                int r = rand.Next(Count2);
                if (!RandomIndexes.Contains(r))
                    RandomIndexes.Add(r);
                }

            return RandomIndexes.ToArray().Convert(i => In[i]);
            }
        /// <summary>
        /// Returns 1 random item from the collection.
        /// If the collection is empty, null is returned.
        /// </summary>
        public static T Random<T>(this IEnumerable<T> In)
            {
            int Count = In.Count();
            if (Count < 1)
                return default(T);

            var rand = new Random(_RandomSeed);
            _RandomSeed = rand.Next();

            int RandomIndex = rand.Next(Count);

            return In.GetAt(RandomIndex);
            }
        #endregion

        #region Remove
        /// <summary>
        /// Returns a new List[T] that contains no instances of any object whose ToString value is within the Strings passed.
        /// </summary>
        public static List<T> Remove<T>(this IEnumerable<T> In, params string[] Strings)
            {
            return Strings.IsEmpty() ? In.List() : In.Remove(o => Strings.Contains(o.ToString()));
            }

        /// <summary>
        /// Returns a new List[T] that contains no instances of any object passed.
        /// </summary>
        public static List<T> Remove<T>(this IEnumerable<T> In, params T[] Objs)
            {
            return Objs.IsEmpty() ? In.List() : In.Remove(Objs.Contains);
            }

        /// <summary>
        /// Returns a new List[T] that contains no instances of any object that evokes a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Remove<T>(this IEnumerable<T> In, Func<T, bool> Func)
            {
            return In.List().Select(o => !Func(o));
            }
        /// <summary>
        /// Returns a new List[T] that contains no instances of any object that evokes a true result from the passed Func[int,T,Boolean].
        /// The int passed to the function is the 0-based index of the current item.
        /// </summary>
        public static List<T> RemoveI<T>(this IEnumerable<T> In, Func<int, T, bool> Func)
            {
            return In.SelectI((i, o) => !Func(i, o));
            }
        #endregion

        #region RemoveAt
        /// <summary>
        /// Returns a new List[T], excluding any indexes passed.
        /// </summary>
        public static List<T> RemoveAt<T>(this IEnumerable<T> In, params int[] Indexes)
            {
            return Indexes.IsEmpty() ? In.List() : In.SelectI((i, o) => !Indexes.Contains(i));
            }

        /// <summary>
        /// Returns a new T[], excluding any indexes passed.
        /// </summary>
        public static T[] RemoveAt<T>(this T[] In, params int[] Indexes)
            {
            if (Indexes.IsEmpty())
                return In ?? new T[] { };

            return In.SelectI((i, o) => !Indexes.Contains(i));
            }
        #endregion

        #region RemoveAt_Checked
        /// <summary>
        /// Ensures items are removed from a list, checking the count afterwards and retrying
        /// if the remove fails.
        /// </summary>
        public static void RemoveAt_Checked<T>(this List<T> List, int Index)
            {
            int Count = List.Count;
            List.RemoveAt(Index);
            int Count2 = List.Count;

            if (Count != Count2 + 1)
                {
                RemoveAt_Checked(List, Index);
                }
            }
        #endregion

        #region RemoveDuplicates
        /// <summary>
        /// Returns a new List[T] with duplicates removed (items with equivalent values).
        /// </summary>
        public static List<T> RemoveDuplicates<T>(this List<T> In)
            {
            var Out = new List<T>();
            In.Each(i =>
                {
                    if (!Out.Contains(i))
                        Out.Add(i);
                });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] with duplicates removed (items with equivalent values).
        /// </summary>
        public static List<T> RemoveDuplicates<T>(this IEnumerable<T> In)
            {
            return In.List().RemoveDuplicates();
            }
        /// <summary>
        /// Returns a new List[Object] with duplicates removed (items with equivalent values).
        /// </summary>
        public static List<object> RemoveDuplicates(this IEnumerable In)
            {
            return In.List().RemoveDuplicates();
            }
        #endregion

        #region Reverse
        /// <summary>
        /// Returns a new array with the item orders reversed.
        /// </summary>
        public static T[] Reverse<T>(this T[] In)
            {
            int Count = In.Count();
            return In.Collect((i, o) => In[Count - (i + 1)]);
            }
        /// <summary>
        /// Reverses the order of the items a List[T].
        /// </summary>
        public static void Reverse<T>(this List<T> In)
            {
            int Count = In.Count();
            In.Reverse(0, Count);
            }
        /// <summary>
        /// Returns a new List[T] with the order of the items reversed.
        /// </summary>
        public static List<T> Reverse<T>(this IEnumerable<T> In)
            {
            List<T> Out = In.List();
            Out.Reverse<T>();
            return Out;
            }
        /// <summary>
        /// Returns a new List[Object] with the order of the items reversed.
        /// </summary>
        public static List<object> Reverse(this IEnumerable In)
            {
            List<object> Out = In.List<object>();
            Out.Reverse<object>();
            return Out;
            }
        #endregion

        #region Select
        /// <summary>
        /// Returns a new List[Object] containing items from In that evoke a true result from the passed Func[Object,Boolean].
        /// </summary>
        public static List<object> Select(this IEnumerable In, Func<object, bool> Func)
            {
            List<object> Out = NewList<List<object>, object>();

            In.Each(Result =>
            {
                bool Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new T[] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static T[] Select<T>(this T[] In, Func<T, bool> Func)
            {
            T[] Out = NewList<T[], T>();

            In.Each(Result =>
            {
                bool Select = Func(Result);
                if (Select)
                    Out = Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Select<T>(this List<T> In, Func<T, bool> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each(Result =>
            {
                bool Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Select<T>(this IEnumerable<T> In, Func<T, bool> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each(Result =>
            {
                bool Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }

        /// <summary>
        /// Returns a new List[Object] containing items from In that evoke a true result from the passed Func[int,Object,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<object> SelectI(this IEnumerable In, Func<int, object, bool> Func)
            {
            List<object> Out = NewList<List<object>, object>();

            In.Each((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }

        /// <summary>
        /// Returns a new T[] containing items from In that evoke a true result from the passed Func[int,T,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static T[] SelectI<T>(this T[] In, Func<int, T, bool> Func)
            {
            T[] Out = NewList<T[], T>();

            In.Each((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out = Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<T> SelectI<T>(this List<T> In, Func<int, T, bool> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<T> SelectI<T>(this IEnumerable<T> In, Func<int, T, bool> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        #endregion

        #region SetAt
        /// <summary>
        /// Sets the item in the collection at [Index] to [Value].
        /// </summary>
        public static void SetAt(this IEnumerable In, int Index, object Value)
            {
            if (In == null)
                return;

            var @in = In as IList;
            if (@in != null)
                {
                @in[Index] = Value;
                }
            else throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Sets the item in the collection at [Index] to [Value].
        /// </summary>
        public static void SetAt<T>(this IEnumerable<T> In, int Index, T Value)
            {
            if (In == null)
                return;

            var @in = In as IList<T>;
            if (@in != null)
                {
                @in[Index] = Value;
                return;
                }

            // ReSharper disable once SuspiciousTypeConversion.Global
            var array = In as Array;
            if (array != null)
                {
                array.SetValue(Value, Index);
                return;
                }

            throw new Exception(typeof(T).FullName);
            }
        #endregion

        #region Shuffle
        /// <summary>
        /// Returns a new List[T] with the item order randomized.
        /// </summary>
        public static List<T> Shuffle<T>(this List<T> In)
            {
            var Out = new List<T>();
            if (!In.IsEmpty())
                {
                Out = In.Random(In.Count);
                }
            return Out;
            }
        /// <summary>
        /// Returns a new T[] with the item order randomized.
        /// </summary>
        public static T[] Shuffle<T>(this T[] In)
            {
            T[] Out = { };
            if (!In.IsEmpty())
                {
                Out = In.Random(In.Count());
                }
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] with the item order randomized.
        /// </summary>
        public static List<T> Shuffle<T>(this IEnumerable In)
            {
            return In.List<T>().Shuffle();
            }
        /// <summary>
        /// Returns a new List[object] with the item order randomized.
        /// </summary>
        public static List<object> Shuffle(this IEnumerable In)
            {
            return In.List().Shuffle();
            }
        /// <summary>
        /// Returns a new List[T] with the item order randomized.
        /// </summary>
        public static List<T> Shuffle<T>(this IEnumerable<T> In)
            {
            var Out = new List<T>();
            if (!In.IsEmpty())
                {
                Out = In.Random(In.Count());
                }
            return Out;
            }
        #endregion

        #region Sort
        /// <summary>
        /// Sorts the collection using the default comparer which works for all types that support IComparable.
        /// </summary>
        /// <param name="In"></param>
        public static void Sort(this IList In)
            {
            var Sorter = new QuickSorter(new ComparableComparer(), new DefaultSwap());
            Sorter.Sort(In);
            }
        /// <summary>
        /// Sorts the collection using the results of the passed Comparer Func[T,T,int].
        /// The Func should return positive if the first item is greater, negative if the second item is greater, and 0 if they are equal.
        /// </summary>
        public static void Sort<T>(this IList In, Func<T, T, int> Comparer)
            {
            var Sorter = new QuickSorter(new CustomComparer<T>(Comparer), new DefaultSwap());
            Sorter.Sort(In);
            }
        /// <summary>
        /// Sorts the collection using the results of the passed Field Retriever Func[T, IComparable] to determine what the items should be sorted by.
        /// Return the value you would like the collection sorted by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <param name="FieldRetriever"></param>
        public static void Sort<T>(this IList In, Func<T, IComparable> FieldRetriever)
            {
            var Sorter = new QuickSorter(new CustomComparer<T>(FieldRetriever), new DefaultSwap());
            Sorter.Sort(In);
            }
        #endregion

        #region Swap
        /// <summary>
        /// Swaps two indexes in T[] [In].
        /// </summary>
        public static void Swap<T>(this T[] In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            var temp = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = temp;
            }
        /// <summary>
        /// Swaps two indexes in list [In].
        /// </summary>
        public static void Swap(this IList In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            var temp = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = temp;
            }
        #endregion

        #region TotalCount
        /// <summary>
        /// Returns the total number of elements within the collection.
        /// Counts contained IEnumerable objects for their contents also.
        /// </summary>
        public static int TotalCount(this IEnumerable In)
            {
            var Collection = In;
            var @in = In as IDictionary;
            if (@in != null)
                {
                Collection = @in.Values;
                }

            if (In is string)
                {
                return 1;
                }
            int Out = 0;

            Collection.Each(v =>
                {
                    var enumerable = v as IEnumerable;
                    if (enumerable != null)
                        Out += enumerable.TotalCount();
                    else
                        Out++;
                });

            return Out;
            }
        #endregion

        #region While
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While(this IEnumerable In, Func<bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once UnusedVariable
            foreach (var o in In)
                {
                bool Continue = Func();
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While<T>(this IEnumerable<T> In, Func<bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once UnusedVariable
            foreach (var o in In)
                {
                bool Continue = Func();
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While(this IEnumerable In, Func<object, bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var o in In)
                {
                bool Continue = Func(o);
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While<T>(this IEnumerable<T> In, Func<T, bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var o in In)
                {
                bool Continue = Func(o);
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool WhileI(this IEnumerable In, Func<int, bool> Func)
            {
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            int i = 0;
            return In.While(o =>
            {
                bool Continue = Func(i);
                i++;
                return Continue;
            });
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool WhileI(this IEnumerable In, Func<int, object, bool> Func)
            {
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            int i = 0;
            return In.While(o =>
            {
                bool Continue = Func(i, o);
                i++;
                return Continue;
            });
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool WhileI<T>(this IEnumerable<T> In, Func<int, T, bool> Func)
            {
            if (Func == null)
                throw new ArgumentNullException(nameof(Func));

            int i = 0;
            return In.While(o =>
                {
                    bool Continue = Func(i, o);
                    i++;
                    return Continue;
                });
            }
        #endregion

        #region While Object
        /// <summary>
        /// Executes Action [In] while [Condition] returns true. 
        /// [In] is passed values from [Obj].
        /// </summary>
        public static void While<T>(this Action<T> In, Func<bool> Condition, IEnumerable<T> Obj)
            {
            Obj.While(In.Merge(Condition));
            }
        #endregion

        #endregion

        internal static class Test
            {
            // ReSharper disable InconsistentNaming
            #region Tests +
            #region Each
            private static readonly List<object> TestBox = new List<object>();

            public const string ReceiveObjectI_Name = "EnumerableExt.Test.ReceiveObjectI";
            public static Action<int, object> ReceiveObjectI = (i, o) => { TestBox.Add(i); };

            public const string ReceiveObject_Name = "EnumerableExt.Test.ReceiveObject";
            public static Action<object> ReceiveObject = o => { TestBox.Add(o); };

            public const string ReceiveTI_Name = "EnumerableExt.Test.ReceiveTI";
            public static Action<int, int> ReceiveTI = (i, o) => { TestBox.Add(i); };

            public const string ReceiveT_Name = "EnumerableExt.Test.ReceiveT";
            public static Action<int> ReceiveT = o => { TestBox.Add(o); };

            public const string Fail_Name = "EnumerableExt.Test.Fail";
            public static Action<object> Fail = o => { throw new Exception(); };

            public const string FailOO_Name = "EnumerableExt.Test.FailOO";
            public static Func<object, object> FailOO = o => { throw new Exception(); };

            public const string FailITFunc_Name = "EnumerableExt.Test.FailITFunc";
            public static Func<int, int> FailITFunc = o => { throw new Exception(); };

            public const string FailIOOFunc_Name = "EnumerableExt.Test.FailIOOFunc";
            public static Func<int, object, object> FailIOOFunc = (i, o) => { throw new Exception(); };

            public const string FailOI_Name = "EnumerableExt.Test.FailOI";
            public static Action<int, object> FailOI = (i, o) => { throw new Exception(); };

            public const string FailI_Name = "EnumerableExt.Test.FailI";
            public static Action<int> FailI = o => { throw new Exception(); };

            public const string FailIT_Name = "EnumerableExt.Test.FailIT";
            public static Action<int, int> FailIT = (i, o) => { throw new Exception(); };

            public const string FailITTFunc_Name = "EnumerableExt.Test.FailITTFunc";
            public static Func<int, int, int> FailITTFunc = (i, o) => { throw new Exception(); };

            public const string HasReceivedObjectsButNoStrings_Name = "EnumerableExt.Test.HasReceivedObjectsButNoStrings";
            public static Func<bool> HasReceivedObjectsButNoStrings = () =>
            {
                bool Out = TestBox.Count > 0 && !TestBox.Contains(L.Obj.IsA<string>());
                TestBox.Clear();
                return Out;
            };

            public const string HasReceivedObjects_Name = "EnumerableExt.Test.HasReceivedObjects";
            public static Func<bool> HasReceivedObjects = () =>
            {
                bool Out = TestBox.Count > 0;
                TestBox.Clear();
                return Out;
            };

            public const string HasReceivedObjectsI_Name = "EnumerableExt.Test.HasReceivedObjectsI";
            public static Func<bool> HasReceivedObjectsI = () =>
            {
                bool Out = TestBox.Count > 0 && TestBox.Equivalent(new List<object> { 0, 1, 2 });
                TestBox.Clear();
                return Out;
            };
            #endregion

            public const string IncrementInt_Name = "EnumerableExt.Test.IncrementInt";
            public static readonly Func<int, int> IncrementInt = i => i + 1;

            public const string IncrementObjectInt_Name = "EnumerableExt.Test.IncrementObjectInt";
            public static Func<object, object> IncrementObjectInt = o => (object)IncrementInt((int)o);

            public const string PassI_Name = "EnumerableExt.Test.PassI";
            public static Func<int, object, object> PassI = (i, o) => i;

            public const string PassIII_Name = "EnumerableExt.Test.PassIII";
            public static Func<int, int, int> PassIII = (i, i2) => i;
            #endregion
            // ReSharper restore InconsistentNaming
            }
        }
    public static partial class L
        {
        /// <summary>
        /// Contains Array static methods and lambdas.
        /// </summary>
        public static class Ary
            {
            #region Array +
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns>Returns a function that returns an empty T[]</returns>
            public static Func<T[]> Array<T>()
                {
                return () => new T[] { };
                }
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="In"></param>
            /// <returns>Returns a function that returns a T[] filled with arguments</returns>
            public static Func<T[]> Array<T>(params T[] In)
                {
                return () => In;
                }
            #endregion
            }
        /// <summary>
        /// Contains List[T] static methods and lambdas.
        /// </summary>
        public static class List
            {
            #region List +
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns>Returns a function that returns an empty List[T]</returns>
            public static Func<List<T>> ToList<T>()
                {
                return () => new List<T>();
                }
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="In"></param>
            /// <returns>Returns a function that returns a List[T] filled with arguments</returns>
            public static Func<List<T>> ToList<T>(params T[] In)
                {
                return () => { var Out = new List<T>(); Out.AddRange(In); return Out; };
                }
            #endregion
            }
        }
    }