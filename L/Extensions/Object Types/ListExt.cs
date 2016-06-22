using System;
using LCore.Extensions.ObjectExt;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using LCore.Tests;
using NSort;
using LCore.Naming;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    public static class ListExt
        {
        #region Extensions
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

            T[] Out = new T[CountTotal];
            In.CopyTo(Out, 0);
            Objs.EachI((i, o) => { Out[Count + i] = o; });
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

            T[] Out = new T[CountTotal];
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

            In.AddRange(Objs);
            }
        #endregion

        // TODO: L: List: Untested
        #region AddString
        /// <summary>
        /// Adds a series of chars to the supplied string and returns it.
        /// </summary>
        public static string Add(this string In, params char[] Chars)
            {
            return In.Add((IEnumerable<char>)Chars);
            }
        /// <summary>
        /// Adds a collection of chars to the supplied string and returns it.
        /// </summary>
        public static string Add(this string In, IEnumerable<char> Chars)
            {
            In = In ?? "";
            Chars = Chars ?? new char[] { };

            string Objs2;
            if (Chars.GetType().TypeEquals(typeof(string)))
                {
                Objs2 = (string)Chars;
                }
            else
                {
                Objs2 = new string(Chars.ToArray());
                }
            return In + Objs2;
            }
        #endregion

        // TODO: L: List: Untested
        #region AddTo
        /// <summary>
        /// Adds the item of the supplied collection to the second supplied collection.
        /// This method tries to look for the Collection's Add method, if it exists.
        /// </summary>
        public static void AddTo<T>(this IEnumerable<T> In, ICollection Collection)
            {
            Type CollectionType = Collection.GetType();

            MethodInfo AddMethod = CollectionType.GetMethod("Add", new[] { typeof(T) }) ??
                                   CollectionType.GetMethod("Add", new[] { typeof(object) });

            if (AddMethod == null)
                throw new Exception($"Could not find \'Add\' method for type \'{typeof(T)}\'");

            In.Each(o => { AddMethod.Invoke(Collection, new object[] { o }); });
            }
        #endregion

        // TODO: L: List: Untested
        #region All
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool All(this IEnumerable In, Func<bool> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool All<T>(this IEnumerable<T> In, Func<bool> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool All(this IEnumerable In, Func<object, bool> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool All<T>(this IEnumerable In, Func<T, bool> Condition)
            {
            if (Condition == null)
                throw new ArgumentNullException(nameof(Condition));

            return !In.IsEmpty() && In.List<T>().While(Condition);
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

        // TODO: L: List: Untested
        #region AllI
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool AllI(this IEnumerable In, Func<int, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool AllI<T>(this IEnumerable<T> In, Func<int, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool AllI(this IEnumerable In, Func<int, object, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool AllI<T>(this IEnumerable In, Func<int, T, bool> Condition)
            {
            return In.List<T>().WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static bool AllI<T>(this IEnumerable<T> In, Func<int, T, bool> Condition)
            {
            return In.WhileI(Condition);
            }
        #endregion

        // TODO: L: List: Untested
        #region Append
        public static T[] Append<T>(this T[] In, params T[] Obj)
            {
            if (In == null)
                In = new T[] { };
            if (Obj == null)
                return In;

            T[] Out = new T[In.Length + Obj.Length];
            In.CopyTo(Out, 0);
            Obj.CopyTo(Out, In.Length);
            return Out;
            }
        #endregion

        #region Collect
        /// <summary>
        /// Runs a Func[Object,Object] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailOO_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailOO_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementObjectInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementObjectInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementObjectInt_Name }, new object[] { 2, 3, 4 })]
        public static List<object> Collect(this IEnumerable In, Func<object, object> Func)
            {
            In = In ?? new object[] { };
            return In.Cast<object>().Select(Func).Where(obj => obj != null).ToList();
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. 
        /// Null values and values that are not of type T are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
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

            return In.Cast<T>().Select(Func).Where(obj => obj != null).ToList();
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters.
        /// Returns a list containing the result of the Func[T,T]. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this IEnumerable<T> In, Func<T, T> Func)
            {
            In = In ?? new T[] { };

            return In.Select(Func).Where(obj => obj != null).ToList();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[T,T] on the input.
        /// Returns a T[] of the results. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static T[] Collect<T>(this T[] In, Func<T, T> Func)
            {
            return In.List().Collect(Func).ToArray();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[T,T] on the input.
        /// Returns a List[T] of the results. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this List<T> In, Func<T, T> Func)
            {
            In = In ?? new List<T>();
            return In.Select(Func).Where(obj => obj != null).ToList();
            }
        #endregion

        #region CollectI
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
        public static List<object> CollectI(this IEnumerable In, Func<int, object, object> Func)
            {
            In = In ?? new object[] { };

            List<object> Out = new List<object>();

            int i = 0;
            foreach (object o in In)
                {
                object obj = Func(i, o);
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
        public static List<T> CollectI<T>(this IEnumerable In, Func<int, T, T> Func)
            {
            In = In ?? new T[] { };

            List<T> Out = new List<T>();

            int i = 0;
            foreach (T o in In)
                {
                T obj = Func(i, o);
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
        public static List<T> CollectI<T>(this IEnumerable<T> In, Func<int, T, T> Func)
            {
            In = In ?? new T[] { };

            List<T> Out = new List<T>();

            int i = 0;
            foreach (T o in In)
                {
                T obj = Func(i, o);
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
        public static T[] CollectI<T>(this T[] In, Func<int, T, T> Func)
            {
            return In.List().CollectI(Func).ToArray();
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
        public static List<T> CollectI<T>(this List<T> In, Func<int, T, T> Func)
            {
            In = In ?? new List<T>();

            int Count = In.Count;
            List<T> Out = new List<T>();
            for (int i = 0; i < Count; i++)
                {
                T o = In[i];
                T obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
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
            In.EachI((i, o) => { Out += Func(i, o) ?? ""; });
            return Out;
            }
        #endregion

        /* TODO: L: List: Comment All Below */

        // Combines a list of items separating them with a string or char
        // TODO: L: List: Untested
        #region Combine - String
        public static string Combine(this IEnumerable<string> List)
            {
            return List.Combine("");
            }
        public static string Combine<T, U>(this T List, char SeparateChar)
            where T : IEnumerable<U>
            where U : IConvertible
            {
            return List.Convert(i => i.ToString()).Combine(SeparateChar);
            }
        public static string Combine(this IEnumerable<string> List, char SeparateChar)
            {
            return List.Combine(SeparateChar.ToString());
            }
        public static string Combine<T, U>(this T List, string SeparateStr)
            where T : IEnumerable<U>
            where U : IConvertible
            {
            return List.Convert(i => i.ToString()).Combine(SeparateStr);
            }
        #endregion

        // TODO: L: List: Untested
        #region Convert
        /// <summary>
        /// Iterates through a collection, returning a List[Object] containing the results of the passed Func[Object,Object].
        /// Null values are ignored.
        /// </summary>
        public static List<object> Convert(this IEnumerable In, Func<object, object> Func)
            {
            return In.ConvertI((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a U[] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static U[] Convert<T, U>(this T[] In, Func<T, U> Func)
            {
            return In.ConvertI((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this List<T> In, Func<T, U> Func)
            {
            return In.ConvertI((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this IEnumerable<T> In, Func<T, U> Func)
            {
            return In.ConvertI((i, o) => Func(o));
            }
        #endregion

        // TODO: L: List: Untested
        #region ConvertAll
        public static List<object> ConvertAll(this IEnumerable In, Func<object, IEnumerable<object>> Func)
            {
            In = In ?? new object[] { };
            List<object> Out = new List<object>();
            foreach (object o in In)
                {
                IEnumerable<object> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        public static List<U> ConvertAll<T, U>(this IEnumerable In, Func<T, IEnumerable<U>> Func)
            {
            In = In.List<T>();

            List<U> Out = new List<U>();
            foreach (T o in In)
                {
                IEnumerable<U> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        public static List<U> ConvertAll<T, U>(this IEnumerable<T> In, Func<T, IEnumerable<U>> Func)
            {
            In = In ?? new T[] { };

            List<U> Out = new List<U>();
            foreach (T o in In)
                {
                IEnumerable<U> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        public static U[] ConvertAll<T, U>(this T[] In, Func<T, IEnumerable<U>> Func)
            {
            return In.List().ConvertAll(Func).ToArray();
            }
        public static List<U> ConvertAll<T, U>(this List<T> In, Func<T, IEnumerable<U>> Func)
            {
            In = In ?? new List<T>();
            List<U> Out = new List<U>();
            foreach (T o in In)
                {
                IEnumerable<U> obj = Func(o);
                if (obj != null)
                    Out.AddRange(obj);
                }
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
        #region ConvertI
        /// <summary>
        /// Iterates through a collection, returning a List[Object] containing the results of the passed Func[Object,Object].
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        public static List<object> ConvertI(this IEnumerable In, Func<int, object, object> Func)
            {
            List<object> Out = NewList<List<object>, object>();
            In.EachI((i, o) =>
            {
                object obj = Func(i, o);
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
        public static U[] ConvertI<T, U>(this T[] In, Func<int, T, U> Func)
            {
            if (In == null)
                return new U[] { };
            U[] Out = new U[In.Length];
            In.EachI((i, o) =>
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
        public static List<U> ConvertI<T, U>(this List<T> In, Func<int, T, U> Func)
            {
            List<U> Out = NewList<List<U>, U>();
            In.EachI((i, o) =>
            {
                U obj = Func(i, o);
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
        public static List<U> ConvertI<T, U>(this IEnumerable<T> In, Func<int, T, U> Func)
            {
            List<U> Out = NewList<List<U>, U>();
            In.EachI((i, o) =>
            {
                U obj = Func(i, o);
                if (obj != null)
                    Out.Add(obj);
            });
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
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

            Array o = In as Array;
            if (o != null)
                {
                return o.Length;
                }
            IList list = In as IList;
            if (list != null)
                {
                return list.Count;
                }
            ICollection collection = In as ICollection;
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

            IEnumerator Enumerator = In.GetEnumerator();

            while (Enumerator.MoveNext())
                {
                Count++;
                }

            return Count;
            }
        #endregion

        // TODO: L: List: Untested
        #region Count Object
        /// <summary>
        /// Returns the number of items in the collection that are equivalent to Obj.
        /// </summary>
        public static int Count<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Count(Logic.Object_SafeEquals.Supply(Obj).Cast<object, bool, T, bool>());
            }
        #endregion

        // TODO: L: List: Untested
        #region Cycle
        public static void Cycle(this IEnumerable In, Func<object, bool> Continue)
            {
            while (true)
                {
                bool KeepGoing = In.While(Continue);
                if (!KeepGoing)
                    break;
                }
            }
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

        // TODO: L: List: Untested
        #region Do
        public static void Do<T>(this Action<T> In, IEnumerable<T> Obj)
            {
            In.Each(Obj);
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
                foreach (object o in In)
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
                foreach (T o in In)
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
        public static void EachI(this IEnumerable In, Action<int, object> Func)
            {
            if (!In.IsEmpty())
                {
                int i = 0;
                foreach (object o in In)
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
        public static void EachI<T>(this IEnumerable In, Action<int, object> Func)
            {
            List<T> List = In.Filter<T>();
            List.EachI(Func);
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
        public static void EachI<T>(this IEnumerable<T> In, Action<int, T> Func)
            {
            if (!In.IsEmpty())
                {
                int i = 0;
                foreach (T o in In)
                    {
                    Func(i, o);
                    i++;
                    }
                }
            }
        #endregion

        // TODO: L: List: Untested
        #region Each Object
        public static void Each<T>(this Action<T> In, IEnumerable<T> Obj)
            {
            Obj.Each(In);
            }
        #endregion

        // TODO: L: List: Untested
        #region Equivalent
        public static bool Equivalent(this IEnumerable In, IEnumerable Compare)
            {
            if (In == null && Compare == null)
                return true;
            if (In == null || Compare == null)
                return false;
            // Strings are IEnumerables too - we have to test for this just in case.
            string s = In as string;
            if (s != null && Compare is string)
                return s == (string)Compare;

            int Count1 = In.Count();
            int Count2 = Compare.Count();

            return Count1 == Count2 && In.AllI((i, o) => Compare.GetAt(i).SafeEquals(o));
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region Filter
        /// <summary>
        /// Returns a new List[T] from the supplied collection. 
        /// Values that are null or are not of type T are not included.
        /// </summary>
        public static List<T> Filter<T>(this IEnumerable In)
            {
            List<T> Out = new List<T>();
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
            return In.Convert(Logic.Def.TypeExt.As<U>().Cast<object, U, T, U>());
            }
        #endregion

        // TODO: L: List: Untested
        #region Find
        public static List<T> Find<T>(this IEnumerable<T> In, IEnumerable Obj)
            {
            return In.List().Select(Obj.Has);
            }
        public static List<string> Find(this string In, IEnumerable<string> Obj)
            {
            return Obj.List().Select(s => s.Contains(In));
            }
        #endregion

        // TODO: L: List: Untested
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
            return In.First(t=>true, Count);
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

        // TODO: L: List: Untested
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
            T[] Out = new T[StartCount];

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

        // TODO: L: List: Untested
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
            U[] Out = new U[StartCount];

            In.WhileI((i, o) =>
            {
                U Result = Func(o);
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

            List<U> Out = new List<U>();

            In.While(o =>
            {
                U Result = Func(o);
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

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region GetAt
        /// <summary>
        /// Returns the item at the specified index.
        /// </summary>
        public static object GetAt(this IEnumerable In, int Index)
            {
            if (In == null)
                return null;

            IList @in = In as IList;
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

            IList<T> @in = In as IList<T>;
            if (@in != null)
                {
                return @in[Index];
                }
            // ReSharper disable once SuspiciousTypeConversion.Global
            Array array = In as Array;
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

        // TODO: L: List: Untested
        #region Group
        public static Dictionary<string, List<T>> Group<T>(this IEnumerable<T> In)
            where T : IGrouped
            {
            return In.Group(o => o.Group ?? "");
            }

        public static Dictionary<U, List<object>> Group<U>(this IEnumerable In, Func<object, U> Indexer)
            {
            return In.List().Group(Indexer);
            }

        public static Dictionary<U, List<T>> Group<T, U>(this IEnumerable<T> In, Func<T, U> Indexer)
            {
            Dictionary<U, List<T>> Out = new Dictionary<U, List<T>>();
            In.Each(o =>
            {
                U Index = Indexer(o);
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

        public static Dictionary<U, Dictionary<V, List<T>>> Group<T, U, V>(this IEnumerable<T> In, Func<T, U> Indexer1, Func<T, V> Indexer2)
            {
            Dictionary<U, List<T>> First = In.Group(Indexer1);
            Dictionary<U, Dictionary<V, List<T>>> Out = new Dictionary<U, Dictionary<V, List<T>>>();
            First.Each(kv =>
            {
                Dictionary<V, List<T>> Dict2 = kv.Value.Group(Indexer2);
                Out.Add(kv.Key, Dict2);
            });
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region HasAny
        public static bool HasAny<T>(this IEnumerable In, IEnumerable<T> Obj)
            {
            return Obj.Has(In.Has);
            }
        public static bool HasAny(this IEnumerable In, IEnumerable Obj)
            {
            return Obj.Has(In.Has);
            }
        public static bool HasAny<T>(this IEnumerable<T> In, IEnumerable<T> Obj)
            {
            return Obj.Has(In.Has);
            }
        public static bool HasAny(this IEnumerable In, params object[] Obj)
            {
            return In.HasAny((IEnumerable)Obj);
            }
        public static bool HasAny<T>(this IEnumerable<T> In, params T[] Obj)
            {
            return In.HasAny((IEnumerable<T>)Obj);
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region HasIndex
        public static bool HasIndex(this IEnumerable In, int Index)
            {
            int Count = In.Count();

            return Index > 0 && Index < Count;
            }
        #endregion

        // TODO: L: List: Untested
        #region Index
        public static Dictionary<U, object> Index<U>(this IEnumerable In, Func<object, U> Indexer)
            {
            return In.List().Index(Indexer);
            }
        public static Dictionary<U, T> Index<T, U>(this IEnumerable<T> In, Func<T, U> Indexer)
            {
            Dictionary<U, T> Out = new Dictionary<U, T>();
            In.Each(o =>
            {
                U Index = Indexer(o);

                if (!Out.ContainsKey(Index))
                    Out.Add(Index, o);
            });
            return Out;
            }
        public static Dictionary<U, Dictionary<V, object>> Index<U, V>(this IEnumerable In, Func<object, U> Indexer1, Func<object, V> Indexer2)
            {
            return In.List().Index(Indexer1, Indexer2);
            }
        public static Dictionary<U, Dictionary<V, T>> Index<T, U, V>(this IEnumerable<T> In, Func<T, U> Indexer1, Func<T, V> Indexer2)
            {
            Dictionary<U, List<T>> First = In.Group(Indexer1);
            Dictionary<U, Dictionary<V, T>> Out = new Dictionary<U, Dictionary<V, T>>();
            First.Each(kv =>
            {
                Dictionary<V, T> Dict2 = kv.Value.Index(Indexer2);
                Out.Add(kv.Key, Dict2);
            });
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
        #region IndexOf
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

        // TODO: L: List: Untested
        #region IsEmpty
        public static bool IsEmpty(this IEnumerable In)
            {
            int Count = In.Count();
            return Count == 0;
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
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
            T[] Out = new T[StartCount];

            (In.Length - 1).To(0, i =>
            {
                T o = In[i];
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
                T o = In[i];
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

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region Map
        public static Dictionary<U, object> Map<U>(this IEnumerable In, Func<object, U> Mapper)
            {
            return In.List().Map(Mapper);
            }
        public static Dictionary<U, T> Map<T, U>(this IEnumerable<T> In, Func<T, U> Mapper)
            {
            Dictionary<U, T> Out = new Dictionary<U, T>();
            In.Each(o =>
            {
                U Key = Mapper(o);

                if (Out.ContainsKey(Key))
                    {
                    // Ignore duplicate keys, only the first is kept.
                    }
                else
                    {
                    Out.Add(Key, o);
                    }
            });
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
        #region Move
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
        public static void Move(this IList In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            object temp = In[Index1];
            In.Insert(Index2, temp);
            }
        #endregion

        // TODO: L: List: Untested
        #region Named
        public static List<INamed> Named(this IEnumerable In, string Name)
            {
            return In.List<INamed>().Select(o => o?.Name == Name);
            }
        public static T[] Named<T>(this T[] In, string Name)
            where T : INamed
            {
            return In.Select(o => o?.Name == Name);
            }
        public static List<T> Named<T>(this List<T> In, string Name)
            where T : INamed
            {
            return In.Select(o => o?.Name == Name);
            }

        public static IEnumerable<T> Named<T>(this IEnumerable<T> In, string Name)
            where T : INamed
            {
            return In.Where(o => o?.Name == Name);
            }

        public static List<object> Named(this IEnumerable In, string Name, Func<object, string> Namer)
            {
            return In.List<object>().Select(o => o != null && Namer(o) == Name);
            }
        public static List<T> Named<T>(this IEnumerable<T> In, string Name, Func<T, string> Namer)
            {
            return In.List().Select(o => o != null && Namer(o) == Name);
            }
        public static T[] Named<T>(this T[] In, string Name, Func<T, string> Namer)
            {
            return In.Select(o => o != null && Namer(o) == Name);
            }
        public static List<T> Named<T>(this List<T> In, string Name, Func<T, string> Namer)
            {
            return In.Select(o => o != null && Namer(o) == Name);
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region Random
        private static int RandomSeed = new Random().Next();
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

            List<int> RandomIndexes = new List<int>();

            Random rand = new Random(RandomSeed);
            RandomSeed = rand.Next();
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

            List<int> RandomIndexes = new List<int>();

            Random rand = new Random(RandomSeed);
            RandomSeed = rand.Next();

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

            Random rand = new Random(RandomSeed);
            RandomSeed = rand.Next();

            int RandomIndex = rand.Next(Count);

            return In.GetAt(RandomIndex);
            }
        #endregion

        // TODO: L: List: Untested
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

        // TODO: L: List: Untested
        #region RemoveAt
        /// <summary>
        /// Returns a new List[T], excluding any indexes passed.
        /// </summary>
        public static List<T> RemoveAt<T>(this IEnumerable<T> In, params int[] Indexes)
            {
            return Indexes.IsEmpty() ? In.List() : In.SelectI((i, o) => !Indexes.Contains(i));
            }

        public static T[] RemoveAt<T>(this T[] In, params int[] Indexes)
            {
            if (Indexes.IsEmpty())
                return In ?? new T[] { };

            return In.SelectI((i, o) => !Indexes.Contains(i));
            }
        #endregion

        // TODO: L: List: Untested
        #region RemoveAt_Checked
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

        // TODO: L: List: Untested
        #region RemoveDuplicates
        /// <summary>
        /// Returns a new List[T] with duplicates removed (items with equivalent values).
        /// </summary>
        public static List<T> RemoveDuplicates<T>(this List<T> In)
            {
            List<T> Out = new List<T>();
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

        // TODO: L: List: Untested
        #region Reverse
        /// <summary>
        /// Returns a new array with the item orders reversed.
        /// </summary>
        public static T[] Reverse<T>(this T[] In)
            {
            int Count = In.Count();
            return In.CollectI((i, o) => In[Count - (i + 1)]);
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
        /// Returns a new List[T] with the order of the items revesed.
        /// </summary>
        public static List<T> Reverse<T>(this IEnumerable<T> In)
            {
            List<T> Out = In.List();
            Out.Reverse<T>();
            return Out;
            }
        /// <summary>
        /// Returns a new List[Object] with the order of the items revesed.
        /// </summary>
        public static List<object> Reverse(this IEnumerable In)
            {
            List<object> Out = In.List<object>();
            Out.Reverse<object>();
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
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

            In.EachI((i, Result) =>
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

            In.EachI((i, Result) =>
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

            In.EachI((i, Result) =>
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

            In.EachI((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
        #region SetAt
        /// <summary>
        /// Sets the item in the colection at [Index] to [Value].
        /// </summary>
        public static void SetAt(this IEnumerable In, int Index, object Value)
            {
            if (In == null)
                return;

            IList @in = In as IList;
            if (@in != null)
                {
                @in[Index] = Value;
                }
            else throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Sets the item in the colection at [Index] to [Value].
        /// </summary>
        public static void SetAt<T>(this IEnumerable<T> In, int Index, T Value)
            {
            if (In == null)
                return;

            IList<T> @in = In as IList<T>;
            if (@in != null)
                {
                @in[Index] = Value;
                return;
                }

            // ReSharper disable once SuspiciousTypeConversion.Global
            Array array = In as Array;
            if (array != null)
                {
                array.SetValue(Value, Index);
                return;
                }

            throw new Exception(typeof(T).FullName);
            }
        #endregion

        // TODO: L: List: Untested
        #region Shuffle
        /// <summary>
        /// Returns a new List[T] with the item order randomized.
        /// </summary>
        public static List<T> Shuffle<T>(this List<T> In)
            {
            List<T> Out = new List<T>();
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
        public static List<object> Shuffle(this IEnumerable In)
            {
            return In.List().Shuffle();
            }
        public static List<T> Shuffle<T>(this IEnumerable<T> In)
            {
            List<T> Out = new List<T>();
            if (!In.IsEmpty())
                {
                Out = In.Random(In.Count());
                }
            return Out;
            }
        #endregion

        // TODO: L: List: Untested
        #region Sort
        /// <summary>
        /// Sorts the collection using the default comparer which works for all types that support IComparable.
        /// </summary>
        /// <param name="In"></param>
        public static void Sort(this IList In)
            {
            QuickSorter Sorter = new QuickSorter(new ComparableComparer(), new DefaultSwap());
            Sorter.Sort(In);
            }
        /// <summary>
        /// Sorts the collection using the results of the passed Comparer Func[T,T,int].
        /// The Func should return positive if the first item is greater, negative if the second item is greater, and 0 if they are equal.
        /// </summary>
        public static void Sort<T>(this IList In, Func<T, T, int> Comparer)
            {
            QuickSorter Sorter = new QuickSorter(new CustomComparer<T>(Comparer), new DefaultSwap());
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
            QuickSorter Sorter = new QuickSorter(new CustomComparer<T>(FieldRetriever), new DefaultSwap());
            Sorter.Sort(In);
            }
        #endregion

        // TODO: L: List: Untested
        #region Swap
        public static void Swap<T>(this T[] In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            T temp = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = temp;
            }
        public static void Swap(this IList In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            object temp = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = temp;
            }
        #endregion

        // TODO: L: List: Untested
        #region ToArray
        public static object[] Array(this IEnumerable In)
            {
            object[] Out = new object[In.Count()];
            In.EachI((i, o) => { Out[i] = o; });
            return Out;
            }
        public static T[] Array<T>(this IEnumerable In)
            {
            return In.List<T>().ToArray();
            }
        public static T[] Array<T>(this IEnumerable<T> In)
            {
            T[] Out = new T[In.Count()];
            In.EachI((i, o) => { Out[i] = o; });
            return Out;
            }
        public static U[] Array<T, U>(this T[] In) where U : class, T
            {
            return In.Filter<T, U>();
            }
        #endregion

        // TODO: L: List: Untested
        #region ToList
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
            List<T> Out = new List<T>();
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

        // TODO: L: List: Untested
        #region TotalCount
        public static int TotalCount(this IEnumerable In)
            {
            IEnumerable Collection = In;
            IDictionary @in = In as IDictionary;
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
                    IEnumerable enumerable = v as IEnumerable;
                    if (enumerable != null)
                        Out += enumerable.TotalCount();
                    else
                        Out++;
                });

            return Out;
            }
        #endregion

        // TODO: L: List: Untested
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
            foreach (object o in In)
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
            foreach (T o in In)
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
            foreach (object o in In)
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
            foreach (T o in In)
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

        // TODO: L: List: Untested
        #region While Object
        public static void While<T>(this Action<T> In, Func<bool> Condition, IEnumerable<T> Obj)
            {
            Obj.While(In.Merge(Condition));
            }
        #endregion

        #endregion

        public static class Test
            {
            #region Tests
            #region Each
            private static readonly List<object> TestBox = new List<object>();

            public const string ReceiveObjectI_Name = "ListExt.Test.ReceiveObjectI";
            public static Action<int, object> ReceiveObjectI = (i, o) => { TestBox.Add(i); };

            public const string ReceiveObject_Name = "ListExt.Test.ReceiveObject";
            public static Action<object> ReceiveObject = o => { TestBox.Add(o); };

            public const string ReceiveTI_Name = "ListExt.Test.ReceiveTI";
            public static Action<int, int> ReceiveTI = (i, o) => { TestBox.Add(i); };

            public const string ReceiveT_Name = "ListExt.Test.ReceiveT";
            public static Action<int> ReceiveT = o => { TestBox.Add(o); };

            public const string Fail_Name = "ListExt.Test.Fail";
            public static Action<object> Fail = o => { throw new Exception(); };

            public const string FailOO_Name = "ListExt.Test.FailOO";
            public static Func<object, object> FailOO = o => { throw new Exception(); };

            public const string FailITFunc_Name = "ListExt.Test.FailITFunc";
            public static Func<int, int> FailITFunc = o => { throw new Exception(); };

            public const string FailIOOFunc_Name = "ListExt.Test.FailIOOFunc";
            public static Func<int, object, object> FailIOOFunc = (i, o) => { throw new Exception(); };

            public const string FailOI_Name = "ListExt.Test.FailOI";
            public static Action<int, object> FailOI = (i, o) => { throw new Exception(); };

            public const string FailI_Name = "ListExt.Test.FailI";
            public static Action<int> FailI = o => { throw new Exception(); };

            public const string FailIT_Name = "ListExt.Test.FailIT";
            public static Action<int, int> FailIT = (i, o) => { throw new Exception(); };

            public const string FailITTFunc_Name = "ListExt.Test.FailITTFunc";
            public static Func<int, int, int> FailITTFunc = (i, o) => { throw new Exception(); };

            public const string HasReceivedObjectsButNoStrings_Name = "ListExt.Test.HasReceivedObjectsButNoStrings";
            public static Func<bool> HasReceivedObjectsButNoStrings = () =>
            {
                bool Out = TestBox.Count > 0 && !TestBox.Contains(Logic.IsA<string>());
                TestBox.Clear();
                return Out;
            };

            public const string HasReceivedObjects_Name = "ListExt.Test.HasReceivedObjects";
            public static Func<bool> HasReceivedObjects = () =>
            {
                bool Out = TestBox.Count > 0;
                TestBox.Clear();
                return Out;
            };

            public const string HasReceivedObjectsI_Name = "ListExt.Test.HasReceivedObjectsI";
            public static Func<bool> HasReceivedObjectsI = () =>
            {
                bool Out = TestBox.Count > 0 && TestBox.Equivalent(new List<object> { 0, 1, 2 });
                TestBox.Clear();
                return Out;
            };
            #endregion

            public const string IncrementInt_Name = "ListExt.Test.IncrementInt";
            public static readonly Func<int, int> IncrementInt = i => i + 1;

            public const string IncrementObjectInt_Name = "ListExt.Test.IncrementObjectInt";
            public static Func<object, object> IncrementObjectInt = o => (object)IncrementInt((int)o);

            public const string PassI_Name = "ListExt.Test.PassI";
            public static Func<int, object, object> PassI = (i, o) => i;

            public const string PassIII_Name = "ListExt.Test.PassIII";
            public static Func<int, int, int> PassIII = (i, i2) => i;
            #endregion
            }
        }
    public partial class Logic
        {
        public partial class Def
            {
            public class ArrayExt
                {
                // TODO: L: List: Untested
                #region Array
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
                // TODO: L: List: Untested
                #region List
                /// <summary>
                /// 
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <returns>Returns a function that returns an empty List[T]</returns>
                public static Func<List<T>> List<T>()
                    {
                    return () => new List<T>();
                    }
                /// <summary>
                /// 
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="In"></param>
                /// <returns>Returns a function that returns a List[T] filled with arguments</returns>
                public static Func<List<T>> List<T>(params T[] In)
                    {
                    return () => { List<T> Out = new List<T>(); Out.AddRange(In); return Out; };
                    }
                #endregion
                }
            }
        }
    }