using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
using LCore.Tests;
using NSort;
using LCore.Naming;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for list types:
    /// List`T, T[], IEnumerable`T
    /// </summary>
    [ExtensionProvider]
    public static class EnumerableExt
        {
        #region Extensions +

        #region Add
        /// <summary>
        /// Returns a new <typeparamref name="T[]" /> with the supplied items appended to it.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestResult(new object[] { null, null }, new int[] { })]
        [TestResult(new object[] { null, new int[] { } }, new int[] { })]
        [TestResult(new object[] { null, new[] { 1 } }, new[] { 1 })]
        [TestResult(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestResult(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static T[] Add<T>([CanBeNull]this T[] In, [CanBeNull]IEnumerable<T> Objs)
            {
            In = In ?? new T[] { };
            Objs = Objs ?? new T[] { };

            uint Count = In.Count();
            uint CountTotal = In.Count() + Objs.Count();

            if (Count == CountTotal)
                return In;
            if (Count == 0)
                return Objs.Array();

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
        public static T[] Add<T>([CanBeNull]this T[] In, [CanBeNull]params T[] Objs)
            {
            In = In ?? new T[] { };
            Objs = Objs ?? new T[] { };

            uint Count = In.Count();
            uint CountTotal = In.Count() + Objs.Count();

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
        /// Appends the supplied List<typeparamref name="T" /> with the supplied items.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestSucceedes(new object[] { null, null })]
        [TestSucceedes(new object[] { null, new int[] { } })]
        [TestSucceedes(new object[] { null, new[] { 1 } })]
        [TestSource(new object[] { new int[] { }, null }, new int[] { })]
        [TestSource(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static void Add<T>([CanBeNull]this List<T> In, [CanBeNull]params T[] Objs)
            {
            In.Add((IEnumerable<T>)Objs);
            }

        /// <summary>
        /// Appends the supplied List<typeparamref name="T" /> with the supplied items.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        [TestMethodGenerics(typeof(int))]
        [TestSucceedes(new object[] { null, null })]
        [TestSucceedes(new object[] { null, new int[] { } })]
        [TestSucceedes(new object[] { null, new[] { 1 } })]
        [TestSource(new object[] { new int[] { }, null }, new int[] { })]
        [TestSource(new object[] { new int[] { }, new[] { 1 } }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1 }, null }, new[] { 1 })]
        [TestSource(new object[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } }, new[] { 1, 2, 3, 4, 5, 6 })]
        public static void Add<T>([CanBeNull]this List<T> In, [CanBeNull]IEnumerable<T> Objs)
            {
            if (In == null)
                return;

            if (Objs.IsEmpty())
                return;

            // ReSharper disable once InvocationIsSkipped
            Debug.Assert(Objs != null, "Objs != null");
            // ReSharper disable once PossibleNullReferenceException
            foreach (var Obj in Objs)
                {
                if (!In.Contains(Obj))
                    {
                    In.Add(Obj);
                    }
                }
            }


        /// <summary>
        /// Adds many <typeparamref name="T[]" /> <paramref name="Items" /> to an IList`<typeparamref name="T[]" /> <paramref name="In" /> in one command.
        /// </summary>
        public static void Add<T>([CanBeNull]this IList<T> In, [CanBeNull]params T[] Items)
            {
            if (In == null)
                return;

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
        /// <exception cref="InvalidOperationException">If an 'Add' method cannot be found for <paramref name="Collection" />.</exception>
        public static void AddTo<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]ICollection Collection)
            {
            if (Collection != null)
                {
                var CollectionType = Collection.GetType();

                MethodInfo AddMethod = null;

                try
                    {
                    AddMethod = CollectionType.GetMethod("Add", new[] { typeof(T) }) ??
                                CollectionType.GetMethod("Add", new[] { typeof(object) });
                    }
                catch (AmbiguousMatchException) { }

                if (AddMethod == null)
                    throw new InvalidOperationException($"Could not find \'Add\' method for type \'{typeof(T)}\'");

                In.Each(o => { AddMethod.Invoke(Collection, new object[] { o }); });
                }
            }
        #endregion

        #region All
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All([CanBeNull]this IEnumerable In, [CanBeNull]Func<object, bool> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Condition)
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
        [Tested]
        public static bool All([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, object, bool> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, T, bool> Condition)
            {
            return In.List<T>().While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        [Tested]
        public static bool All<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<int, T, bool> Condition)
            {
            return In.While(Condition);
            }
        #endregion

        #region Append
        /// <summary>
        /// Returns a new <typeparamref name="T[]" /> with <paramref name="Obj" /> appended to <paramref name="In" />.
        /// </summary>
        [Tested]
        public static T[] Append<T>([CanBeNull]this T[] In, [CanBeNull]params T[] Obj)
            {
            if (In == null)
                In = new T[] { };
            if (Obj == null)
                return In;

            int Length1 = In.Length;
            int Length2 = Obj.Length;

            var Out = new T[Length1 + Length2];
            In.CopyTo(Out, 0);
            Obj.CopyTo(Out, Length1);

            return Out;
            }
        #endregion

        #region Array
        /// <summary>
        /// Converts an IEnumerable to an object[].
        /// </summary>
        [Tested]
        public static object[] Array([CanBeNull]this IEnumerable In)
            {
            var Out = new object[In.Count()];
            In.Each((i, o) => { Out[i] = o; });
            return Out;
            }
        /// <summary>
        /// Converts an IEnumerable to a <typeparamref name="T[]" />.
        /// </summary>
        [Tested]
        public static T[] Array<T>([CanBeNull]this IEnumerable In)
            {
            return In.List<T>().ToArray();
            }
        /// <summary>
        /// Converts an IEnumerable to a <typeparamref name="T[]" />.
        /// </summary>
        [Tested]
        public static T[] Array<T>([CanBeNull]this IEnumerable<T> In)
            {
            var Out = new T[In.Count()];
            In.Each((i, o) => { Out[i] = o; });
            return Out;
            }
        /// <summary>
        /// Converts an <typeparamref name="T[]" /> to a <typeparamref name="U[]" /> for types 
        /// where <typeparamref name="U" /> : <typeparamref name="T" />. 
        /// Filters out elements of <paramref name="In" /> that are not of type <typeparamref name="U" />.
        /// </summary>
        [Tested]
        public static U[] Array<T, U>([CanBeNull]this IEnumerable<T> In) where U : class, T
            {
            return In.Array().Filter<T, U>();
            }
        #endregion

        #region Collect
        /// <summary>
        /// Runs a Func`<typeparamref name="T" />,<typeparamref name="T" /> <paramref name="In.Count" /> times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. 
        /// Null values and values that are not of type <typeparamref name="T" /> are excluded.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        [TestResult(new object[] { new object[] { 1, 2, "a", 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, T> Func)
            {
            In = In.List<T>();
            Func = Func ?? (o => default(T));

            return In.List<T>().Collect(Func).List();
            }
        /// <summary>
        /// Runs a Func`<typeparamref name="T"/>,<typeparamref name="T" /> <paramref name="In.Count" /> times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters.
        /// Returns a list containing the result of the Func`<typeparamref name="T" />,<typeparamref name="T" />. Null values are excluded.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, T> Func)
            {
            In = In ?? new T[] { };
            Func = Func ?? (o => default(T));

            return In.Select(Obj => Obj != null).Collect(Func).List();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func`<typeparamref name="T" />,<typeparamref name="T" /> on the input.
        /// Returns a T[] of the results. Null values are excluded.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        [DebuggerStepThrough]
        public static T[] Collect<T>([CanBeNull]this T[] In, [CanBeNull]Func<T, T> Func)
            {
            Func = Func ?? (o => default(T));
            return In.List(true).Collect(Func).ToArray();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func`<typeparamref name="T" />,<typeparamref name="T" /> on the input.
        /// Returns a List<typeparamref name="T" /> of the results. Null values are excluded.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.IncrementInt_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.IncrementInt_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.IncrementInt_Name }, new[] { 2, 3, 4 })]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this List<T> In, [CanBeNull]Func<T, T> Func)
            {
            In = In ?? new List<T>();
            Func = Func ?? (o => default(T));

            var Out = new List<T>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var Item in In)
                {
                var Result = Func(Item);

                if (!Result.SafeEquals(default(T)))
                    Out.Add(Result);
                }

            return Out;
            }
        #endregion

        #region Collect I
        /// <summary>
        /// Runs a Func`Object,Object <paramref name="In.Count" /> times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. Null values are excluded.
        /// </summary>

        [TestFails(new object[] { new[] { 1 }, Test.FailIOOFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailIOOFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassI_Name })]
        [TestResult(new object[] { new object[] { 1, 2, 3 }, Test.PassI_Name }, new object[] { 0, 1, 2 })]
        [DebuggerStepThrough]
        public static List<object> Collect([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, object, object> Func)
            {
            In = In ?? new object[] { };
            Func = Func ?? ((i, Obj) => Obj);

            var Out = new List<object>();

            int Index = 0;
            foreach (var Obj in In)
                {
                var Result = Func(Index, Obj);
                if (Result != null)
                    Out.Add(Result);
                Index++;
                }
            return Out;
            }
        /// <summary>
        /// Runs a Func`<typeparamref name="T" />,<typeparamref name="T" /> <paramref name="In.Count" /> times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. 
        /// Null values and values that are not of type T are excluded.
        /// </summary>

        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new object[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, T, T> Func)
            {
            In = In ?? new T[] { };
            Func = Func ?? ((i, Obj) => Obj);

            var Out = new List<T>();

            int Index = 0;
            foreach (T Obj in In)
                {
                var Result = Func(Index, Obj);
                if (Result != null)
                    Out.Add(Result);
                Index++;
                }
            return Out;
            }
        /// <summary>
        /// Runs a Func`<typeparamref name="T" />,<typeparamref name="T" /> <paramref name="In.Count" /> times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters.
        /// Returns a list containing the result of the Func`<typeparamref name="T" />,<typeparamref name="T" />. Null values are excluded.
        /// </summary>

        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<int, T, T> Func)
            {
            In = In ?? new T[] { };
            Func = Func ?? ((i, Obj) => Obj);

            var Out = new List<T>();

            int Index = 0;
            foreach (var Obj in In)
                {
                var Result = Func(Index, Obj);
                if (Result != null)
                    Out.Add(Result);
                Index++;
                }

            return Out;
            }
        /// <summary>
        /// Iterates through a collection, executing the Func`int,<typeparamref name="T" />,<typeparamref name="T" /> on the input. 
        /// The int passed is the 0-based index of the current item.
        /// Returns a T[] of the results of the Func. Null values are excluded.
        /// </summary>

        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        [DebuggerStepThrough]
        public static T[] Collect<T>([CanBeNull]this T[] In, [CanBeNull]Func<int, T, T> Func)
            {
            return In.List().Collect(Func).ToArray();
            }
        /// <summary>
        /// Iterates through a collection, executing the Func`int,<typeparamref name="T" />,<typeparamref name="T" /> on the input. 
        /// The int passed is the 0-based index of the current item.
        /// Returns a List<typeparamref name="T" /> of the results of the Func. Null values are excluded.
        /// </summary>

        [TestMethodGenerics(typeof(int))]
        [TestFails(new object[] { new[] { 1 }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailITTFunc_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.PassIII_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.PassIII_Name })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, Test.PassIII_Name }, new[] { 0, 1, 2 })]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this List<T> In, [CanBeNull]Func<int, T, T> Func)
            {
            In = In ?? new List<T>();
            Func = Func ?? ((i, Obj) => Obj);

            int Count = In.Count;
            var Out = new List<T>();
            for (int Index = 0; Index < Count; Index++)
                {
                var Item = In[Index];
                var Result = Func(Index, Item);
                if (Result != null)
                    Out.Add(Result);
                }
            return Out;
            }
        #endregion

        #region CollectFunc

        /// <summary>
        /// Runs a Func<typeparamref name="T" /> <paramref name="Count" /> times and returns a list with the results.
        /// Returns a list containing the result of the Func<typeparamref name="T" />. Null values are excluded.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this Func<T> In, int Count)
            {
            In = In ?? (() => default(T));

            if (Count < 0)
                throw new ArgumentOutOfRangeException(nameof(Count));

            List<T> Out = L.List.NewList<List<T>, T>();

            if (Count == 0)
                return Out;

            0.To(Count - 1, i => { Out.Add(In()); });
            return Out;
            }
        /// <summary>
        /// Runs a Func<typeparamref name="T" /> <paramref name="Count" /> times and returns a list with the results.
        /// Returns a list containing the result of the Func<typeparamref name="T" />. Null values are excluded.
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<T> Collect<T>([CanBeNull]this Func<int, T> In, int Count)
            {
            In = In ?? (i => default(T));

            if (Count < 0)
                throw new ArgumentOutOfRangeException(nameof(Count));

            List<T> Out = L.List.NewList<List<T>, T>();

            if (Count == 0)
                return Out;

            0.To(Count - 1, i => { Out.Add(In(i)); });
            return Out;
            }
        #endregion

        #region CollectStr
        /// <summary>
        /// Iterates through a String, applying an action to each char.
        /// </summary>
        [Tested]
        public static string CollectStr([CanBeNull]this string In, [CanBeNull]Func<char, char> Func)
            {
            In = In ?? "";
            Func = Func ?? (Char => Char);
            return new string(In.Array().Collect(Func));
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func`int,<typeparamref name="T" />,string.
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        [Tested]
        public static string CollectStr<T>([CanBeNull]this List<T> In, [CanBeNull]Func<int, T, string> Func)
            {
            In = In ?? new List<T>();
            Func = Func ?? ((i, o) => $"{o}");
            return In.CollectStr<T, List<T>>(Func);
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func`int,<typeparamref name="T" />,string.
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>

        [Tested]
        public static string CollectStr<T>([CanBeNull]this T[] In, [CanBeNull]Func<int, T, string> Func)
            {
            In = In ?? new T[] { };
            Func = Func ?? ((i, o) => $"{o}");
            return In.CollectStr<T, T[]>(Func);
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func`int,<typeparamref name="T" />,string.
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        [Tested]
        public static string CollectStr<T, U>([CanBeNull]this U In, [CanBeNull]Func<int, T, string> Func)
            where U : IEnumerable<T>
            {
            if (In == null || Func == null)
                return "";

            string Out = "";
            In.Each((i, o) => { Out += Func(i, o) ?? ""; });
            return Out;
            }
        #endregion

        #region Combine - String
        /// <summary>
        /// Combines a list of strings with no separator.
        /// </summary>
        [TestResult(new object[] { new string[] { } }, "")]
        [TestResult(new object[] { new[] { "" } }, "")]
        [TestResult(new object[] { new[] { "abc" } }, "abc")]
        [TestResult(new object[] { new[] { "abc", "123" } }, "abc123")]
        [TestResult(new object[] { new[] { "abc", "123", "hi" } }, "abc123hi")]
        [TestResult(new object[] { new[] { "abc", "123", null, "hi" } }, "abc123hi")]
        public static string Combine([CanBeNull]this IEnumerable<string> List)
            {
            return List.Combine("");
            }
        /// <summary>
        /// Joins a list of strings with a separator character.
        /// </summary>
        [TestResult(new object[] { new string[] { }, ' ' }, "")]
        [TestResult(new object[] { new[] { "" }, ' ' }, "")]
        [TestResult(new object[] { new[] { "abc" }, ' ' }, "abc")]
        [TestResult(new object[] { new[] { "abc", "123" }, ' ' }, "abc 123")]
        [TestResult(new object[] { new[] { "abc", "123", "hi" }, ',' }, "abc,123,hi")]
        [TestResult(new object[] { new[] { "abc", "123", null, "hi" }, ',' }, "abc,123,hi")]
        public static string Combine([CanBeNull]this IEnumerable<string> List, char SeparateChar)
            {
            return List.Combine(SeparateChar.ToString());
            }
        /// <summary>
        /// Convert a list of IConvertible to strings, then joins them with a separator string.
        /// </summary>
        [Tested]
        public static string Combine<T>([CanBeNull]this IEnumerable<T> List, string SeparateStr)
            where T : IConvertible
            {
            return List.Convert(i => i.ConvertToString()).Combine(SeparateStr);
            }
        /// <summary>
        /// Convert a list of IConvertible to strings, then joins them with a separator character.
        /// </summary>
        [Tested]
        public static string Combine<T>([CanBeNull]this IEnumerable<T> List, char SeparateChar)
            where T : IConvertible
            {
            return List.Convert(i => i.ConvertToString()).Combine(SeparateChar);
            }
        #endregion

        #region Convert
        /// <summary>
        /// Iterates through a collection, returning a List`Object containing the results of the passed Func`Object,Object.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<object> Convert([CanBeNull]this IEnumerable In, [CanBeNull]Func<object, object> Func)
            {
            Func = Func ?? (o => o);
            return In.Convert((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a U[] containing the results of the passed Func`<typeparamref name="T" />,<typeparamref name="U" />.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static U[] Convert<T, U>([CanBeNull]this T[] In, [CanBeNull]Func<T, U> Func)
            {
            Func = Func ?? (o =>
                {
                    var Out = default(U);
                    try { Out = (U)(object)o; } catch { }
                    return Out;
                });
            return In.Convert((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a List`<typeparamref name="U" /> containing the results of the passed Func`<typeparamref name="T" />,<typeparamref name="U" />.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<U> Convert<T, U>([CanBeNull]this List<T> In, [CanBeNull]Func<T, U> Func)
            {
            Func = Func ?? (o =>
            {
                var Out = default(U);
                try { Out = (U)(object)o; } catch { }
                return Out;
            });
            return In.Convert((i, o) => Func(o));
            }
        /// <summary>
        /// Iterates through a collection, returning a List`<typeparamref name="U" /> containing the results of the passed Func`<typeparamref name="T" />,<typeparamref name="U" />.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<U> Convert<T, U>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, U> Func)
            {
            Func = Func ?? (o =>
            {
                var Out = default(U);
                try { Out = (U)(object)o; } catch { }
                return Out;
            });
            return In.Convert((i, o) => Func(o));
            }
        #endregion

        #region ConvertAll
        /// <summary>
        /// Iterates over <paramref name="In" />, passing each item to <paramref name="Func" />.
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<object> ConvertAll([CanBeNull]this IEnumerable In, [CanBeNull]Func<object, IEnumerable<object>> Func)
            {
            In = In ?? new object[] { };

            var Out = new List<object>();

            if (Func == null)
                return Out;

            foreach (var Obj in In)
                {
                IEnumerable<object> Result = Func(Obj);
                if (Result != null)
                    Out.AddRange(Result);
                }
            return Out.List();
            }
        /// <summary>
        /// Iterates over <paramref name="In" />, passing each item to <paramref name="Func" />.
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<U> ConvertAll<T, U>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, IEnumerable<U>> Func)
            {
            In = In.List<T>();

            var Out = new List<U>();

            if (Func == null)
                return Out;

            foreach (T Obj in In)
                {
                IEnumerable<U> Result = Func(Obj);
                if (Result != null)
                    Out.AddRange(Result);
                }
            return Out.List();
            }
        /// <summary>
        /// Iterates over <paramref name="In" />, passing each item to <paramref name="Func" />.
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<U> ConvertAll<T, U>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, IEnumerable<U>> Func)
            {
            In = In ?? new T[] { };

            var Out = new List<U>();

            if (Func == null)
                return Out;

            foreach (var Obj in In)
                {
                IEnumerable<U> Result = Func(Obj);
                if (Result != null)
                    Out.AddRange(Result);
                }
            return Out.List();
            }
        /// <summary>
        /// Iterates over <paramref name="In" />, passing each item to <paramref name="Func" />.
        /// Func can return multiple objects. 
        /// They are all collected and returned in one array.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static U[] ConvertAll<T, U>([CanBeNull]this T[] In, [CanBeNull]Func<T, IEnumerable<U>> Func)
            {
            return In.List().ConvertAll(Func).ToArray();
            }
        /// <summary>
        /// Iterates over <paramref name="In" />, passing each item to <paramref name="Func" />.
        /// Func can return multiple objects. 
        /// They are all collected and returned in one list.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<U> ConvertAll<T, U>([CanBeNull]this List<T> In, [CanBeNull]Func<T, IEnumerable<U>> Func)
            {
            In = In ?? new List<T>();
            var Out = new List<U>();

            if (Func == null)
                return Out;

            foreach (var Obj in In)
                {
                IEnumerable<U> Result = Func(Obj);
                if (Result != null)
                    Out.AddRange(Result);
                }
            return Out.List();
            }
        #endregion

        #region Convert I
        /// <summary>
        /// Iterates through a collection, returning a List`Object containing the results of the passed Func`Object,Object.
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<object> Convert([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, object, object> Func)
            {
            List<object> Out = L.List.NewList<List<object>, object>();

            if (Func == null)
                return Out;

            In.Each((i, o) =>
            {
                var Result = Func(i, o);
                if (Result != null)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, returning a U[] containing the results of the passed Func`<typeparamref name="T" />,<typeparamref name="U" />.
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static U[] Convert<T, U>([CanBeNull]this T[] In, [CanBeNull]Func<int, T, U> Func)
            {
            if (In == null)
                return new U[] { };

            var Out = new U[In.Length];

            if (Func == null)
                return Out;

            In.Each((i, o) =>
            {
                Out[i] = Func(i, o);
            });
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, returning a List`<typeparamref name="U" /> containing the results of the passed Func`int,<typeparamref name="T" />,<typeparamref name="U" />.
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>

        [Tested]
        [DebuggerStepThrough]
        public static List<U> Convert<T, U>([CanBeNull]this List<T> In, [CanBeNull]Func<int, T, U> Func)
            {
            List<U> Out = L.List.NewList<List<U>, U>();

            if (Func == null)
                return Out;

            In.Each((i, o) =>
            {
                var Result = Func(i, o);
                if (Result != null)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, returning a List`<typeparamref name="U" /> containing the results of the passed Func`int,<typeparamref name="T" />,<typeparamref name="U" />.
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static List<U> Convert<T, U>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<int, T, U> Func)
            {
            List<U> Out = L.List.NewList<List<U>, U>();

            if (Func == null)
                return Out;

            In.Each((i, o) =>
            {
                var Result = Func(i, o);
                if (Result != null)
                    Out.Add(Result);
            });
            return Out;
            }
        #endregion

        #region Count
        /// <summary>
        /// Returns the size of a collection
        /// </summary>
        [Tested]
        [DebuggerStepThrough]
        public static uint Count<T>([CanBeNull]this T In) where T : IEnumerable
            {
            if (In == null)
                return 0;

            var Array = In as Array;
            if (Array != null)
                return (uint)Array.Length;


            var List = In as IList;
            if (List != null)
                return (uint)List.Count;

            var Collection = In as ICollection;
            if (Collection != null)
                {
                try
                    {
                    return (uint)Collection.Count;
                    }
                catch
                    {
                    return 0;
                    }
                }
            string Str = In as string;

            if (Str != null)
                return (uint)Str.Length;

            uint Count = 0;

            var Enumerator = In.GetEnumerator();

            while (Enumerator.MoveNext())
                Count++;

            return Count;
            }
        #endregion

        #region Count Object
        /// <summary>
        /// Returns the number of items in the collection that are equivalent to Obj.
        /// </summary>
        [Tested]
        public static uint Count<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]T Obj)
            {
            In = In ?? new T[] { };

            return In.Count(i => L.Obj.SafeEquals(Obj, i));
            }
        #endregion

        #region Count Condition
        /// <summary>
        /// Returns the number of items in the collection that cause <paramref name="Condition"/> to return true.
        /// </summary>
        [Tested]
        public static uint Count<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Condition)
            {
            In = In ?? new T[] { };

            if (Condition == null)
                return 0;

            uint Count = 0;

            foreach (var Item in In)
                {
                if (Condition(Item))
                    Count++;
                }

            return Count;
            }
        #endregion

        #region Cycle
        /// <summary>
        /// Cycles through a list of objects indefinitely.
        /// If <paramref name="Continue" /> returns true at the end, the set of objects will be iterated again.
        /// </summary>
        [Tested]
        public static void Cycle([CanBeNull]this IEnumerable In, [CanBeNull]Func<object, bool> Continue)
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
        /// If <paramref name="Continue" /> returns true at the end, the set of objects will be iterated again.
        /// </summary>
        [Tested]
        public static void Cycle<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Continue)
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
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>

        [TestSucceedes(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.Fail_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.Fail_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveObject_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveObject_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveObject_Name }, Test.HasReceivedObjects_Name)]
        [DebuggerStepThrough]
        public static void Each([CanBeNull]this IEnumerable In, [CanBeNull]Action<object> Func)
            {
            if (Func == null)
                return;

            if (!In.IsEmpty())
                {
                // ReSharper disable once PossibleNullReferenceException
                foreach (var Obj in In)
                    {
                    Func(Obj);
                    }
                }
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action.
        /// The collection items are used as the parameters to the Action.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestSucceedes(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveT_Name }, Test.HasReceivedObjects_Name)]
        [TestSucceedes(new object[] { new object[] { 1, 2, "a", 3 }, Test.ReceiveT_Name }, Test.HasReceivedObjectsButNoStrings_Name)]
        [DebuggerStepThrough]
        public static void Each<T>([CanBeNull]this IEnumerable In, [CanBeNull]Action<T> Func)
            {
            if (Func == null)
                return;

            List<T> List = In.Filter<T>();
            List.Each(Func);
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action.
        /// The collection items are used as the parameters to the Action.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>

        [TestMethodGenerics(typeof(int))]
        [TestSucceedes(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveT_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveT_Name }, Test.HasReceivedObjects_Name)]
        [DebuggerStepThrough]
        public static void Each<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Action<T> Func)
            {
            if (Func == null)
                return;

            if (!In.IsEmpty())
                {
                // ReSharper disable once PossibleNullReferenceException
                foreach (var Obj in In)
                    {
                    Func(Obj);
                    }
                }
            }



        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action`int,Object.
        /// The int passed to the Action is the 0-based index of the current item.
        /// The collection items are used as the parameters to the Func`int,Object.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>

        [TestSucceedes(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveObjectI_Name }, Test.HasReceivedObjectsI_Name)]
        [DebuggerStepThrough]
        public static void Each([CanBeNull]this IEnumerable In, [CanBeNull]Action<int, object> Func)
            {
            if (Func == null)
                return;

            if (!In.IsEmpty())
                {
                int Index = 0;
                // ReSharper disable once PossibleNullReferenceException
                foreach (var Obj in In)
                    {
                    Func(Index, Obj);
                    Index++;
                    }
                }
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action`int,Object.
        /// The int passed to the Action is the 0-based index of the current item.
        /// The collection items are used as the parameters to the Action`int,Object.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>

        [TestMethodGenerics(typeof(int))]
        [TestSucceedes(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailOI_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveObjectI_Name })]
        [TestSucceedes(new object[] { new object[] { 1, 2, "", 3 }, Test.ReceiveObjectI_Name }, Test.HasReceivedObjectsI_Name)]
        [DebuggerStepThrough]
        public static void Each<T>([CanBeNull]this IEnumerable In, [CanBeNull]Action<int, object> Func)
            {
            if (Func == null)
                return;

            List<T> List = In.Filter<T>();
            List.Each(Func);
            }
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action`int,<typeparamref name="T" />.
        /// The int passed to the Action is the 0-based index of the current item.
        /// The collection items are used as the parameters to the Action`int,<typeparamref name="T" />.
        /// This method will fail only if <paramref name="Func" /> throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestSucceedes(new object[] { new[] { 1 }, null })]
        [TestFails(new object[] { new[] { 1 }, Test.FailIT_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.FailIT_Name })]
        [TestSucceedes(new object[] { new int[] { }, null })]
        [TestSucceedes(new object[] { null, Test.ReceiveTI_Name })]
        [TestSucceedes(new object[] { new int[] { }, Test.ReceiveTI_Name })]
        [TestSucceedes(new object[] { new[] { 1, 2, 3 }, Test.ReceiveTI_Name }, Test.HasReceivedObjectsI_Name)]
        [DebuggerStepThrough]
        public static void Each<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Action<int, T> Func)
            {
            if (Func == null)
                return;

            if (!In.IsEmpty())
                {
                int Index = 0;
                // ReSharper disable once PossibleNullReferenceException
                foreach (var Obj in In)
                    {
                    Func(Index, Obj);
                    Index++;
                    }
                }
            }
        #endregion

        #region Each Object
        /// <summary>
        /// Performs the supplied action on each T in <paramref name="Obj" />
        /// </summary>
        [Tested]
        public static void Each<T>([CanBeNull]this Action<T> In, [CanBeNull]IEnumerable<T> Obj)
            {
            Obj.Each(In);
            }
        #endregion

        #region Equivalent

        /// <summary>
        /// Compares the contents of two IEnumerable.
        /// Returns true if their count and all contents are the same.
        /// </summary>
        [Tested]
        public static bool Equivalent([CanBeNull]this IEnumerable In, [CanBeNull]IEnumerable Compare)
            {
            if (In == null && Compare == null)
                return true;
            if (In == null || Compare == null)
                return false;

            // Strings are IEnumerable too - we have to test for this just in case.
            string Str = In as string;
            if (Str != null && Compare is string)
                return Str == (string)Compare;

            uint Count1 = In.Count();
            uint Count2 = Compare.Count();

            return Count1 == Count2 &&
                In.All((i, o) => Compare.GetAt(i).SafeEquals(o));
            }
        #endregion

        #region Fill
        /// <summary>
        /// Returns a new T[] containing <paramref name="In.Count" /> entries containing the passed Obj.
        /// </summary>
        [Tested]
        public static T[] Fill<T>([CanBeNull]this T[] In, [CanBeNull]T Obj)
            {
            return In.Collect(o => Obj);
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> containing <paramref name="In.Count" /> entries containing the passed Obj.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <param name="Obj"></param>
        /// <returns></returns>
        [Tested]
        public static List<T> Fill<T>([CanBeNull]this List<T> In, [CanBeNull]T Obj)
            {
            return In.Collect(o => Obj);
            }
        #endregion

        #region Filter
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> from the supplied collection. 
        /// Values that are null or are not of type T are not included.
        /// </summary>
        [Tested]
        public static List<T> Filter<T>([CanBeNull]this IEnumerable In, bool IncludeNulls = false)
            {
            var Out = new List<T>();
            In.Each(o =>
            {
                if (o is T ||
                ((typeof(T).IsNullable() || typeof(T).IsClass) && IncludeNulls && o.IsNull()))
                    Out.Add((T)o);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new U[] from the supplied collection. 
        /// Values that are null or are not of type U are not included.
        /// </summary>
        [Tested]
        public static U[] Filter<T, U>([CanBeNull]this T[] In, bool IncludeNulls = false)
            {
            var Out = new List<U>();
            In.Each(o =>
            {
                if (o is U ||
                ((typeof(T).IsNullable() || typeof(T).IsClass) && IncludeNulls && o.IsNull()))
                    Out.Add((U)o);
            });
            return Out.Array();
            }
        /// <summary>
        /// Returns a new U[] from the supplied collection. 
        /// Values that are null or are not of type U are not included.
        /// </summary>
        [Tested]
        public static List<U> Filter<T, U>([CanBeNull]this List<T> In, bool IncludeNulls = false)
            {
            var Out = new List<U>();
            In.Each(o =>
            {
                if (o is U ||
                ((typeof(T).IsNullable() || typeof(T).IsClass) && IncludeNulls && o.IsNull()))
                    Out.Add((U)o);
            });
            return Out;
            }
        #endregion

        #region First
        /// <summary>
        /// Returns the first item in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns null if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static T First<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, bool> Condition = null)
            {
            if (In == null)
                return default(T);

            Condition = Condition ?? (o => true);

            foreach (var Item in In)
                {
                if (Item is T && Condition((T)Item))
                    return (T)Item;
                }

            return default(T);
            }
        /// <summary>
        /// Returns the first item in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns null if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static T First<T>([CanBeNull]this T[] In, [CanBeNull]Func<object, bool> Condition = null)
            {
            if (In == null)
                return default(T);

            Condition = Condition ?? (o => true);

            foreach (var Item in In)
                {
                if (Condition(Item))
                    return Item;
                }

            return default(T);
            }
        /// <summary>
        /// Returns the first item in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns null if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static T First<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Condition = null)
            {
            if (In == null)
                return default(T);

            Condition = Condition ?? (o => true);

            foreach (var Item in In)
                {
                if (Item != null && Condition(Item))
                    return Item;
                }

            return default(T);
            }
        #endregion 

        #region First Multi
        /// <summary>
        /// Returns the first <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> First<T>([CanBeNull]this IEnumerable In, int Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            return Count < 0
                ? new List<T>()
                : In.First((uint)Count, Condition);
            }

        /// <summary>
        /// Returns the first <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> First<T>([CanBeNull]this IEnumerable In, uint Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            In = In ?? new T[] { };
            Condition = Condition ?? (o => true);
            var Out = new List<T>();
            if (Count > 0)
                {
                foreach (var Item in In)
                    {
                    if (Item is T && Condition((T)Item))
                        Out.Add((T)Item);
                    if (Out.Count == Count)
                        break;
                    }
                }
            return Out;
            }

        /// <summary>
        /// Returns the first <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> First<T>([CanBeNull]this IEnumerable<T> In, int Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            return Count < 0
                ? new List<T>()
                : In.First((uint)Count, Condition);
            }
        /// <summary>
        /// Returns the first <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> First<T>([CanBeNull]this IEnumerable<T> In, uint Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            In = In ?? new T[] { };
            Condition = Condition ?? (o => true);
            var Out = new List<T>();
            if (Count > 0)
                {
                foreach (var Item in In)
                    {
                    if (Condition(Item))
                        Out.Add(Item);

                    if (Out.Count == Count)
                        break;
                    }
                }

            return Out;
            }

        /// <summary>
        /// Returns the first <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty array if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T[] First<T>([CanBeNull]this T[] In, int Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            return Count < 0
                ? new T[] { }
                : In.First((uint)Count, Condition);
            }

        /// <summary>
        /// Returns the first <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty array if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T[] First<T>([CanBeNull]this T[] In, uint Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            In = In ?? new T[] { };
            Condition = Condition ?? (o => true);
            var Out = new List<T>();

            if (Count > 0)
                {
                foreach (var Item in In)
                    {
                    if (Condition(Item))
                        Out.Add(Item);
                    if (Out.Count == Count)
                        break;
                    }
                }

            return

            Out.Array();
            }

        #endregion

        #region First Match

        /// <summary>
        /// Returns the first Object in <paramref name="In"/> that causes is equal to <paramref name="Object"/>.
        /// Returns null if <paramref name="Object"/> is null or is not found.
        /// </summary>
        [Tested]
        public static T First<T>([CanBeNull]this IEnumerable In, [CanBeNull]T Object)
            {
            return In.First<T>(o => o.SafeEquals(Object));
            }

        #endregion

        #region Flatten
        /// <summary>
        /// Iterates through a collection and sub-collections and returns a flattened List<typeparamref name="T" />. 
        /// Ignores all Objects that are not of type T as well as nulls.
        /// </summary>
        [Tested]
        public static List<T> Flatten<T>([CanBeNull]this IEnumerable In)
            {
            List<T> Out = L.List.NewList<List<T>, T>();

            In.Each(o =>
                {
                    if (o.IsNull())
                        return;

                    if (o is IEnumerable)
                        {
                        List<T> Flat = ((IEnumerable)o).Flatten<T>();

                        if (Flat.Count > 0)
                            Out.AddRange(Flat);
                        else if (o is T)
                            Out.Add((T)o);
                        }
                    else if (o is T)
                        Out.Add((T)o);
                });
            return Out;
            }
        #endregion

        #region GetAt
        /// <summary>
        /// Returns the item at the specified index.
        /// If the index is out of range, null is returned.
        /// </summary>
        [Tested]
        public static object GetAt([CanBeNull]this IEnumerable In, int Index)
            {
            return Index < 0
                ? null
                : In.GetAt((uint)Index);
            }

        /// <summary>
        /// Returns the item at the specified index.
        /// If the index is out of range, null is returned.
        /// </summary>
        [Tested]
        public static object GetAt([CanBeNull]this IEnumerable In, uint Index)
            {
            if (In == null)
                return null;

            var List = In as IList;
            if (List != null)
                {
                return List.Count > Index
                    ? List[(int)Index]
                    : null;
                }

            string Str = In as string;
            if (Str != null)
                {
                return Str.Length > Index
                    ? Str[(int)Index]
                    : default(char);
                }

            var IndexProp = In.GetType().IndexGetter<int>();

            return IndexProp?.GetMethod.Invoke(In, new object[] { (int)Index });
            }

        /// <summary>
        /// Returns the item at the specified index.
        /// If the index is out of range, null is returned.
        /// </summary>
        [Tested]
        public static T GetAt<T>([CanBeNull]this IEnumerable<T> In, int Index)
            {
            return Index < 0
                ? default(T)
                : In.GetAt((uint)Index);
            }

        /// <summary>
        /// Returns the item at the specified index.
        /// If the index is out of range, null is returned.
        /// </summary>
        [Tested]
        public static T GetAt<T>([CanBeNull]this IEnumerable<T> In, uint Index)
            {
            if (In == null)
                return default(T);

            // ReSharper disable once SuspiciousTypeConversion.Global
            var Array = In as Array;
            if (Array != null)
                {
                return Array.Length > Index
                    ? (T)Array.GetValue(Index)
                    : default(T);
                }

            var List = In as IList<T>;
            if (List != null)
                {
                return List.Count > Index
                    ? List[(int)Index]
                    : default(T);
                }

            string Str = In as string;
            if (Str != null)
                {
                return Str.Length > Index
                    ? (T)(object)Str[(int)Index]
                    : default(T);
                }

            var IndexProp = In.GetType().IndexGetter<int, T>();
            if (IndexProp != null)
                return (T)IndexProp.GetMethod.Invoke(In, new object[] { (int)Index });

            return default(T);
            }

        #endregion

        #region GetAtIndices
        /// <summary>
        /// Returns a new T[] containing the items at the specified indexes.
        /// </summary>
        [Tested]
        public static T[] GetAtIndices<T>([CanBeNull]this T[] In, [CanBeNull]params int[] Indices)
            {
            return In.Select((i, o) => Indices.Has(i));
            }
        /// <summary>
        /// Returns a new List`Object containing the items at the specified indexes.
        /// </summary>
        [Tested]
        public static List<T> GetAtIndices<T>([CanBeNull]this IEnumerable In, [CanBeNull]params int[] Indices)
            {
            return In.Select<T>((i, o) => Indices.Has(i));
            }
        /// <summary>
        /// Returns a new List<typeparam name="T" /> containing the items at the specified indexes.
        /// </summary>
        [Tested]
        public static List<T> GetAtIndices<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]params int[] Indices)
            {
            return In.Select((i, o) => Indices.Has(i));
            }
        #endregion

        #region Group

        /// <summary>
        /// Groups items implementing interface IGroup from an IEnumerable into a Dictionary`string,List`T` />" />
        /// </summary>
        [Tested]
        public static Dictionary<string, List<T>> Group<T>([CanBeNull]this IEnumerable<T> In)
            where T : IGrouped
            {
            return In.Group(o => o.Group ?? "");
            }

        /// <summary>
        /// Groups items into a dictionary using a custom indexer. 
        /// The result of the indexer will be used as the Key for each element.
        /// </summary>
        [Tested]
        public static Dictionary<TKey, List<TValue>> Group<TValue, TKey>([CanBeNull]this IEnumerable<TValue> In, [CanBeNull]Func<TValue, TKey> Grouper)
            {
            Grouper = Grouper ?? (o => default(TKey));
            var Out = new Dictionary<TKey, List<TValue>>();
            In.Each(o =>
            {
                var Index = Grouper(o);

                if (Index != null)
                    {
                    List<TValue> GroupList;
                    if (Out.ContainsKey(Index))
                        {
                        GroupList = Out[Index];
                        }
                    else
                        {
                        GroupList = new List<TValue>();
                        Out.Add(Index, GroupList);
                        }

                    GroupList.Add(o);
                    }
            });
            return Out;
            }
        #endregion

        #region GroupTwice
        /// <summary>
        /// Groups items into a 2-level dictionary using 2 custom indexers. 
        /// The result of the indexers will be used as the Keys for each element.
        /// </summary>
        [Tested]
        public static Dictionary<U, Dictionary<V, List<T>>> GroupTwice<T, U, V>([CanBeNull]this IEnumerable<T> In,
            [CanBeNull]Func<T, U> Grouper1, [CanBeNull]Func<T, V> Grouper2)
            {
            Dictionary<U, List<T>> First = In.Group(Grouper1);
            var Out = new Dictionary<U, Dictionary<V, List<T>>>();
            First.Each(Pair =>
                {
                    Dictionary<V, List<T>> Dict2 = Pair.Value.Group(Grouper2);
                    Out.Add(Pair.Key, Dict2);
                });
            return Out;
            }
        #endregion

        #region Has Object
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        [Tested]
        public static bool Has<T>([CanBeNull]this IEnumerable In, [CanBeNull]T Obj)
            {
            return In.List<T>(true).Has(Obj.FN_If());
            }
        #endregion

        #region HasAny
        /// <summary>
        /// Returns whether or not the source IEnumerable <paramref name="In" /> contains any of the elements from <paramref name="Obj" />
        /// </summary>
        [Tested]
        public static bool HasAny([CanBeNull]this IEnumerable In, [CanBeNull]IEnumerable Obj)
            {
            return Obj.Has<object>(In.Has);
            }
        /// <summary>
        /// Returns whether or not the source T <paramref name="In" /> contains any of the elements from <paramref name="Obj" />
        /// </summary>
        [Tested]
        public static bool HasAny<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]IEnumerable<T> Obj)
            {
            return Obj.Has(In.Has);
            }
        /// <summary>
        /// Returns whether or not the source IEnumerable <paramref name="In" /> contains any of the elements from <paramref name="Obj" />
        /// </summary>
        [Tested]
        public static bool HasAny([CanBeNull]this IEnumerable In, [CanBeNull]params object[] Obj)
            {
            return In.HasAny((IEnumerable)Obj);
            }
        /// <summary>
        /// Returns whether or not the source T <paramref name="In" /> contains any of the elements from <paramref name="Obj" />
        /// </summary>
        [Tested]
        public static bool HasAny<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]params T[] Obj)
            {
            return In.HasAny((IEnumerable<T>)Obj);
            }
        #endregion

        #region Has Func
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        [Tested]
        public static bool Has<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, bool> Condition)
            {
            if (Condition == null)
                return false;

            bool Found = false;
            In.While(o =>
            {
                if (o is T ||
                ((typeof(T).IsNullable() || typeof(T).IsClass) && o.IsNull()))
                    Found = Found || Condition((T)o);
                return !Found;
            });
            return Found;
            }
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        [Tested]
        public static bool Has<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Condition)
            {
            if (Condition == null)
                return false;

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
        /// Returns whether or not a given IEnumerable has an <paramref name="Index" />.
        /// </summary>
        [Tested]
        public static bool HasIndex([CanBeNull]this IEnumerable In, int Index)
            {
            return Index >= 0 &&
                In.HasIndex((uint)Index);
            }

        /// <summary>
        /// Returns whether or not a given IEnumerable has an <paramref name="Index" />.
        /// </summary>
        [Tested]
        public static bool HasIndex([CanBeNull]this IEnumerable In, uint Index)
            {
            uint Count = In.Count();

            return Index < Count;
            }
        #endregion

        #region Index
        /// <summary>
        /// Converts an IEnumerable to a Dictionary, using an indexer.
        /// Keys map to values 1-to-1, duplicate key values will be ignored. 
        /// </summary>
        [Tested]
        public static Dictionary<U, object> Index<U>([CanBeNull]this IEnumerable In, [CanBeNull]Func<object, U> Indexer)
            {
            return In.List().Index(Indexer);
            }
        /// <summary>
        /// Converts an IEnumerable to a Dictionary, using an indexer.
        /// Keys map to values 1-to-1, duplicate key values will be ignored. 
        /// </summary>
        [Tested]
        public static Dictionary<U, T> Index<T, U>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, U> Indexer)
            {
            Indexer = Indexer ?? (o => default(U));
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
        [Tested]
        public static Dictionary<U, Dictionary<V, T>> IndexTwice<T, U, V>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, U> Indexer1,
           [CanBeNull] Func<T, V> Indexer2)
            {
            Dictionary<U, List<T>> First = In.Group(Indexer1);
            var Out = new Dictionary<U, Dictionary<V, T>>();
            First.Each(Pair =>
                {
                    Dictionary<V, T> Dict2 = Pair.Value.Index(Indexer2);
                    Out.Add(Pair.Key, Dict2);
                });
            return Out;
            }

        #endregion

        #region IndexOf
        /// <summary>
        /// Iterates over <paramref name="In" /> and returns the index of the first true result from <paramref name="Func" />.
        /// </summary>
        [Tested]
        public static int? IndexOf<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, bool> Func)
            {
            return In.List<T>(true).IndexOf(Func);
            }
        /// <summary>
        /// Iterates over <paramref name="In" /> and returns the index of the first true result from <paramref name="Func" />.
        /// </summary>
        [Tested]
        public static int? IndexOf<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Func)
            {
            if (Func == null)
                return null;

            int? Out = null;

            In.While((i, o) =>
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
        [DebuggerStepThrough]
        [Tested]
        public static bool IsEmpty([CanBeNull]this IEnumerable In)
            {
            uint Count = In.Count();
            return Count == 0;
            }
        #endregion

        #region Last

        /// <summary>
        /// Returns the Last item in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns null if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T Last<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, bool> Condition = null)
            {
            Condition = Condition ?? (o => true);

            foreach (var Item in In.Mirror<T>())
                {
                if (Condition(Item))
                    return Item;
                }

            return default(T);
            }
        /// <summary>
        /// Returns the Last item in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns null if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T Last<T>([CanBeNull]this T[] In, [CanBeNull]Func<object, bool> Condition = null)
            {
            Condition = Condition ?? (o => true);

            foreach (var Item in In.Mirror())
                {
                if (Condition(Item))
                    return Item;
                }

            return default(T);
            }
        /// <summary>
        /// Returns the Last item in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns null if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T Last<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Condition = null)
            {
            Condition = Condition ?? (o => true);

            foreach (var Item in In.Mirror())
                {
                if (Item != null && Condition(Item))
                    return Item;
                }

            return default(T);
            }
        #endregion 

        #region Last Multi
        /// <summary>
        /// Returns the Last <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> Last<T>([CanBeNull]this IEnumerable In, int Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            return Count < 0
                ? new List<T>()
                : In.Last((uint)Count, Condition);
            }

        /// <summary>
        /// Returns the Last <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> Last<T>([CanBeNull]this IEnumerable In, uint Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            In = In ?? new List<T>();
            Condition = Condition ?? (o => true);
            var Out = new List<T>();
            if (Count > 0)
                {
                foreach (var Item in In)
                    {
                    if (Item is T && Condition((T)Item))
                        Out.Add((T)Item);

                    if (Out.Count > Count)
                        Out.RemoveAt(0);
                    }
                }
            return Out;
            }

        /// <summary>
        /// Returns the Last <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> Last<T>([CanBeNull]this IEnumerable<T> In, int Count, [CanBeNull] Func<T, bool> Condition = null)
            {
            return Count < 0
                ? new List<T>()
                : In.Last((uint)Count, Condition);
            }
        /// <summary>
        /// Returns the Last <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty list if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static List<T> Last<T>([CanBeNull]this IEnumerable<T> In, uint Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            In = In ?? new List<T>();
            Condition = Condition ?? (o => true);
            var Out = new List<T>();

            if (Count > 0)
                {
                foreach (var Item in In)
                    {
                    if (Condition(Item))
                        Out.Add(Item);

                    if (Out.Count > Count)
                        Out.RemoveAt(0);
                    }
                }

            return Out;
            }

        /// <summary>
        /// Returns the Last <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty array if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T[] Last<T>([CanBeNull]this T[] In, int Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            return Count < 0
                ? new T[] { }
                : In.Last((uint)Count, Condition);
            }

        /// <summary>
        /// Returns the Last <paramref name="Count"/> Items in <paramref name="In"/> that causes <paramref name="Condition"/> to return true.
        /// Returns an empty array if <paramref name="In"/> is null or empty or <paramref name="Condition"/> never returns true.
        /// </summary>
        [Tested]
        public static T[] Last<T>([CanBeNull]this T[] In, uint Count, [CanBeNull]Func<T, bool> Condition = null)
            {
            In = In ?? new T[] { };
            Condition = Condition ?? (o => true);
            var Out = new List<T>();

            if (Count > 0)
                {
                foreach (var Item in In)
                    {
                    if (Condition(Item))
                        Out.Add(Item);
                    if (Out.Count > Count)
                        Out.RemoveAt(0);
                    }
                }

            return Out.Array();
            }

        #endregion

        #region Last Match

        /// <summary>
        /// Returns the Last Object in <paramref name="In"/> that causes is equal to <paramref name="Object"/>.
        /// Returns null if <paramref name="Object"/> is null or is not found.
        /// </summary>
        [Tested]
        public static T Last<T>([CanBeNull]this IEnumerable In, T Object)
            {
            return In.Last<T>(o => o.SafeEquals(Object));
            }

        #endregion

        #region List
        /// <summary>
        /// Returns a new List`Object from the supplied collection.
        /// </summary>
        [Tested]
        public static List<object> List([CanBeNull]this IEnumerable In, bool IncludeNulls = false)
            {
            return In.List<object>(IncludeNulls);
            }

        /// <summary>
        /// Creates a new List<typeparamref name="T" /> from the supplied collection.
        /// This method cannot fail.
        /// </summary>
        [Tested]
        public static List<T> List<T>([CanBeNull]this IEnumerable<T> In, bool IncludeNulls = false)
            {
            var Out = new List<T>();

            if (!In.IsEmpty())
                Out.AddRange(In);


            return IncludeNulls
                ? Out
                : Out.Filter<T>();
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> from the supplied collection.
        /// Nulls and values that are not of type <typeparamref name="T" /> are not included.
        /// </summary>
        [Tested]
        public static List<T> List<T>([CanBeNull]this IEnumerable In, bool IncludeNulls = false)
            {
            return In.Filter<T>(IncludeNulls);
            }
        /// <summary>
        /// Returns a new List`<typeparamref name="U" /> from the supplied collection<typeparamref name="T" />.
        /// Nulls and values that are not of type U are not included.
        /// </summary>
        [Tested]
        public static List<U> List<T, U>([CanBeNull]this IEnumerable<T> In, bool IncludeNulls = false)
            {
            return In.Filter<U>(IncludeNulls);
            }
        #endregion

        #region Move

        /// <summary>
        /// Moves items in an array, recursively shifting items where needed.
        /// </summary>
        [Tested]
        public static void Move<T>([CanBeNull]this T[] In, int Index1, int Index2)
            {
            if (In == null)
                return;
            if (Index1 < 0)
                Index1 = 0;
            if (Index2 < 0)
                Index2 = 0;
            if (Index1 >= In.Length)
                Index1 = In.Length - 1;
            if (Index2 >= In.Length)
                Index2 = In.Length - 1;
            if (Index1 == Index2)
                return;

            if (Index2 > Index1)
                {
                In.Swap(Index1, Index1 + 1);
                In.Move(Index1 + 1, Index2);
                }
            else
                {
                In.Swap(Index1, Index1 - 1);
                In.Move(Index1 - 1, Index2);
                }
            }

        /// <summary>
        /// Moves items in an IList, shifting items where needed.
        /// </summary>
        [Tested]
        public static void Move([CanBeNull]this IList In, int Index1, int Index2)
            {
            if (In == null)
                return;
            if (Index1 < 0)
                Index1 = 0;
            if (Index2 < 0)
                Index2 = 0;
            if (Index1 >= In.Count)
                Index1 = In.Count - 1;
            if (Index2 >= In.Count)
                Index2 = In.Count - 1;
            if (Index1 == Index2)
                return;

            var Item = In[Index1];

            In.RemoveAt(Index1);

            In.Insert(Index2, Item);
            }
        #endregion

        #region Named
        /// <summary>
        /// Returns all items within <paramref name="In" /> that have the given <paramref name="Name" />
        /// </summary>
        [Tested]
        public static List<INamed> Named([CanBeNull]this IEnumerable In, [CanBeNull]string Name)
            {
            return In.List<INamed>().Select(o => o?.Name == Name);
            }
        /// <summary>
        /// Returns all items within <paramref name="In" /> that have the given <paramref name="Name" />
        /// </summary>
        [Tested]
        public static T[] Named<T>([CanBeNull]this T[] In, [CanBeNull]string Name)
            where T : INamed
            {
            return In.Select(o => o?.Name == Name);
            }
        /// <summary>
        /// Returns all items within <paramref name="In" /> that have the given <paramref name="Name" />
        /// </summary>
        [Tested]
        public static IEnumerable<T> Named<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]string Name)
            where T : INamed
            {
            return In.Select(o => o?.Name == Name);
            }

        /// <summary>
        /// Returns all items within <paramref name="In" /> that have the given <paramref name="Name" />
        /// </summary>
        [Tested]
        public static List<object> Named([CanBeNull]this IEnumerable In, [CanBeNull]string Name, [CanBeNull]Func<object, string> Namer)
            {
            Namer = Namer ?? (o => null);

            return In.List<object>().Select(o => o != null && Namer(o) == Name);
            }
        /// <summary>
        /// Returns all items within <paramref name="In" /> that have the given <paramref name="Name" />
        /// </summary>
        [Tested]
        public static List<T> Named<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]string Name, [CanBeNull]Func<T, string> Namer)
            {
            Namer = Namer ?? (o => null);

            return In.List().Select(o => o != null && Namer(o) == Name);
            }
        /// <summary>
        /// Returns all items within <paramref name="In" /> that have the given <paramref name="Name" />
        /// </summary>
        [Tested]
        public static T[] Named<T>([CanBeNull]this T[] In, [CanBeNull]string Name, [CanBeNull]Func<T, string> Namer)
            {
            Namer = Namer ?? (o => null);

            return In.Select(o => o != null && Namer(o) == Name);
            }
        #endregion

        #region Random
        private static int _RandomSeed = new Random().Next();
        /// <summary>
        /// Returns a new List`<typeparamref name="T" /> containing <paramref name="Count" /> random items from the collection.
        /// If Count is higher than In.Count, an ArgumentException will be thrown.
        /// This method will not include any single index more than once unless AllowDuplicates is set to true.
        /// </summary>
        [Tested]
        public static List<T> Random<T>([CanBeNull]this IEnumerable<T> In, int Count, bool AllowDuplicates = false)
            {
            return Count < 0
                ? new List<T>()
                : In.Random((uint)Count, AllowDuplicates);
            }

        /// <summary>
        /// Returns a new List`<typeparamref name="T" /> containing <paramref name="Count" /> random items from the collection.
        /// If Count is higher than In.Count, an ArgumentException will be thrown.
        /// This method will not include any single index more than once unless AllowDuplicates is set to true.
        /// </summary>
        [Tested]
        public static List<T> Random<T>([CanBeNull]this IEnumerable<T> In, uint Count, bool AllowDuplicates = false)
            {
            uint Count2 = In.Count();

            var RandomIndexes = new List<int>();

            var Rand = new Random(_RandomSeed);

            _RandomSeed = Rand.Next();

            if (AllowDuplicates)
                {
                while (RandomIndexes.Count < (int)Count)
                    {
                    int RandInt = Rand.Next((int)Count2);

                    RandomIndexes.Add(RandInt);
                    }

                return RandomIndexes.Convert(In.GetAt).First(Count).List();
                }
            else
                {
                if (Count > Count2)
                    Count = Count2;

                while (RandomIndexes.Count < (int)Count)
                    {
                    int RandInt = Rand.Next((int)Count2);

                    if (!RandomIndexes.Has(RandInt))
                        RandomIndexes.Add(RandInt);
                    }

                return RandomIndexes.Convert((i, Item) => In.GetAt(Item)).First(Count).List();
                }
            }

        /// <summary>
        /// Returns a new <typeparamref name="T[]" /> containing <paramref name="Count" /> random items from the source <typeparamref name="T[]" />
        /// If <paramref name="Count" /> is higher than In.Count, an ArgumentException will be thrown.
        /// </summary>
        [Tested]
        public static T[] Random<T>([CanBeNull]this T[] In, int Count, bool AllowDuplicates = false)
            {
            return Count < 0
                ? new T[] { }
                : In.Random((uint)Count, AllowDuplicates);
            }

        /// <summary>
        /// Returns a new <typeparamref name="T[]" /> containing <paramref name="Count" /> random items from the source <typeparamref name="T[]" />
        /// If <paramref name="Count" /> is higher than In.Count, an ArgumentException will be thrown.
        /// </summary>
        [Tested]
        public static T[] Random<T>([CanBeNull]this T[] In, uint Count, bool AllowDuplicates = false)
            {
            In = In ?? new T[] { };
            uint Count2 = In.Count();

            var RandomIndexes = new List<int>();

            var Rand = new Random(_RandomSeed);
            _RandomSeed = Rand.Next();

            if (!AllowDuplicates)
                {
                if (Count > In.Length)
                    {
                    Count = (uint)In.Length;
                    }
                }

            while (RandomIndexes.Count < (int)Count)
                {
                int RandInt = Rand.Next((int)Count2);

                RandomIndexes.Add(RandInt);
                }

            return RandomIndexes.ToArray().Convert(i => In[i]);
            }

        /// <summary>
        /// Returns 1 random item from the collection.
        /// If the collection is empty, null is returned.
        /// </summary>
        [Tested]
        public static T Random<T>([CanBeNull]this IEnumerable<T> In)
            {
            return In.Random(1).First();
            }
        #endregion

        #region Remove

        /// <summary>
        /// Returns a new List<typeparamref name="T" /> that contains no instances of any object passed.
        /// </summary>
        [Tested]
        public static List<T> Remove<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]params T[] Objs)
            {
            return Objs.IsEmpty() ? In.List() : In.Remove(Objs.Has);
            }

        /// <summary>
        /// Returns a new List<typeparamref name="T" /> that contains no instances of any object that evokes a true result from the passed Func`<typeparamref name="T" />,Boolean.
        /// </summary>
        [Tested]
        public static List<T> Remove<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Func)
            {
            return Func == null
                ? In.List()
                : In.List().Select(o => !Func(o));
            }

        /// <summary>
        /// Returns a new List<typeparamref name="T" /> that contains no instances of any object that evokes a true result from the passed 
        /// Func`int,<typeparamref name="T" />,Boolean.
        /// The int passed to the function is the 0-based index of the current item.
        /// </summary>
        [Tested]
        public static List<T> Remove<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<int, T, bool> Func)
            {
            return Func == null
                ? In.List()
                : In.Select((i, o) => !Func(i, o));
            }

        #endregion

        #region RemoveAt
        /// <summary>
        /// Returns a new List<typeparamref name="T" />, excluding any indexes passed.
        /// </summary>
        [Tested]
        public static List<T> RemoveAt<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]params int[] Indexes)
            {
            return Indexes.IsEmpty()
                ? In.List()
                : In.Select((i, o) => !Indexes.Has(i));
            }

        /// <summary>
        /// Returns a new T[], excluding any indexes passed.
        /// </summary>
        [Tested]
        public static T[] RemoveAt<T>([CanBeNull]this T[] In, [CanBeNull]params int[] Indexes)
            {
            if (Indexes.IsEmpty())
                return In ?? new T[] { };

            return In.Select((i, o) => !Indexes.Has(i));
            }
        #endregion

        #region RemoveAt_Checked
        /// <summary>
        /// Ensures items are removed from a list, checking the count afterwards and retrying
        /// if the remove fails.
        /// </summary>
        public static void RemoveAt_Checked<T>([CanBeNull]this List<T> List, int Index)
            {
            if (List == null)
                return;

            int Count = List.Count;
            List.RemoveAt(Index);
            int Count2 = List.Count;

            if (Count != Count2 + 1)
                {
                RemoveAt_Checked(List, Index);
                }
            }
        #endregion

        #region RemoveDuplicate

        /// <summary>
        /// Removes duplicate items from an enumerable using <paramref name="Indexer" /> to determine 
        /// uniqueness.
        /// </summary>
        [Tested]
        public static List<T> RemoveDuplicate<T, U>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, U> Indexer)
            {
            In = In ?? new T[] { };
            Indexer = Indexer ?? L.F<T, U>();

            var Keys = new List<U>();
            var Out = new List<T>();

            In.Each(i =>
            {
                var Key = Indexer(i);
                if (!Keys.Contains(Key))
                    Out.Add(i);
                Keys.Add(Key);
            });

            return Out;
            }
        /// <summary>
        /// Removes duplicate items from an enumerable using <paramref name="Indexer" /> to determine 
        /// uniqueness.
        /// </summary>
        [Tested]
        public static T[] RemoveDuplicate<T, U>([CanBeNull]this T[] In, [CanBeNull]Func<T, U> Indexer)
            {
            return ((IEnumerable<T>)In).RemoveDuplicate(Indexer).Array();
            }
        /// <summary>
        /// Removes duplicate items from an enumerable using <paramref name="Indexer" /> to determine 
        /// uniqueness.
        /// </summary>
        [Tested]
        public static List<T> RemoveDuplicate<T, U>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, U> Indexer)
            {
            return In.List<T>().RemoveDuplicate(Indexer);
            }

        #endregion

        #region RemoveDuplicates
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> with duplicates removed (items with equivalent values).
        /// </summary>
        [Tested]
        public static List<T> RemoveDuplicates<T>([CanBeNull]this IEnumerable<T> In)
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
        /// Returns a new List<typeparamref name="T" /> with duplicates removed (items with equivalent values).
        /// </summary>
        [Tested]
        public static T[] RemoveDuplicates<T>([CanBeNull]this T[] In)
            {
            return In.List().RemoveDuplicates().Array();
            }
        /// <summary>
        /// Returns a new List`Object with duplicates removed (items with equivalent values).
        /// </summary>
        [Tested]
        public static List<T> RemoveDuplicates<T>([CanBeNull]this IEnumerable In)
            {
            return In.List<T>().RemoveDuplicates();
            }
        #endregion

        #region Mirror
        /// <summary>
        /// Returns a new array with the item orders reversed.
        /// </summary>
        [Tested]
        public static T[] Mirror<T>([CanBeNull]this T[] In)
            {
            In = In ?? new T[] { };

            uint Count = In.Count();
            return In.Collect((i, o) => In[Count - (i + 1)]);
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> with the order of the items reversed.
        /// </summary>
        [Tested]
        public static List<T> Mirror<T>([CanBeNull]this IEnumerable<T> In)
            {
            List<T> Out = In.List();
            Out.Reverse();
            return Out;
            }
        /// <summary>
        /// Returns a new List`Object with the order of the items reversed.
        /// </summary>
        [Tested]
        public static List<T> Mirror<T>([CanBeNull]this IEnumerable In)
            {
            List<T> Out = In.List<T>();
            return Out.Mirror();
            }
        #endregion

        #region Select
        /// <summary>
        /// Returns a new T[] containing items from In that evoke a true result from the passed Func`<typeparamref name="T" />,Boolean.
        /// </summary>
        [Tested]
        public static T[] Select<T>([CanBeNull]this T[] In, [CanBeNull]Func<T, bool> Func)
            {
            if (Func == null)
                return new T[] { };

            T[] Out = L.List.NewList<T[], T>();

            In.Each(Result =>
            {
                bool Select = Func(Result);
                if (Select)
                    Out = Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> containing items from In that evoke a true result from the passed Func`<typeparamref name="T" />,Boolean.
        /// </summary>
        [Tested]
        public static List<T> Select<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Func)
            {
            if (Func == null)
                return new List<T>();

            List<T> Out = L.List.NewList<List<T>, T>();

            In.Each(Result =>
            {
                bool Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }

        /// <summary>
        /// Returns a new List`Object containing items from In that evoke a true result from the passed 
        /// Func`Object,Boolean />.
        /// </summary>
        [Tested]
        public static List<T> Select<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<T, bool> Func)
            {
            if (Func == null)
                return new List<T>();

            List<T> Out = L.List.NewList<List<T>, T>();

            In.Each(Result =>
            {
                if (Result is T)
                    {
                    bool Select = Func((T)Result);
                    if (Select)
                        Out.Add((T)Result);
                    }
            });
            return Out;
            }


        /// <summary>
        /// Returns a new List`Object containing items from In that evoke a true result from the passed Func`int,Object,Boolean.
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        [Tested]
        public static List<T> Select<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, T, bool> Func)
            {
            if (Func == null)
                return new List<T>();

            List<T> Out = L.List.NewList<List<T>, T>();

            In.Each((i, Result) =>
            {
                if (Result is T)
                    {
                    bool Select = Func(i, (T)Result);
                    if (Select)
                        Out.Add((T)Result);
                    }
            });
            return Out;
            }

        /// <summary>
        /// Returns a new T[] containing items from In that evoke a true result from the passed Func`int,<typeparamref name="T" />,Boolean.
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        [Tested]
        public static T[] Select<T>([CanBeNull]this T[] In, [CanBeNull]Func<int, T, bool> Func)
            {
            if (Func == null)
                return new T[] { };
            T[] Out = L.List.NewList<T[], T>();

            In.Each((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out = Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> containing items from In that evoke a true result from the passed Func`<typeparamref name="T" />,Boolean.
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        [Tested]
        public static List<T> Select<T>([CanBeNull]this List<T> In, [CanBeNull]Func<int, T, bool> Func)
            {
            if (Func == null)
                return new List<T>();

            List<T> Out = L.List.NewList<List<T>, T>();

            In.Each((i, Result) =>
            {
                bool Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> containing items from In that evoke a true result from the passed Func`<typeparamref name="T" />,Boolean.
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        [Tested]
        public static List<T> Select<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<int, T, bool> Func)
            {
            if (Func == null)
                return new List<T>();

            List<T> Out = L.List.NewList<List<T>, T>();

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
        /// Sets the item in the collection at <paramref name="Index" /> to <paramref name="Value" />.
        /// </summary>
        [Tested]
        public static void SetAt([CanBeNull]this IEnumerable In, int Index, [CanBeNull]object Value)
            {
            if (In == null)
                return;
            if (!In.HasIndex(Index))
                return;

            var List = In as IList;
            if (List != null)
                {
                List[Index] = Value;
                }
            }
        /// <summary>
        /// Sets the item in the collection at <paramref name="Index" /> to <paramref name="Value" />.
        /// </summary>
        [Tested]
        public static void SetAt<T>([CanBeNull]this IEnumerable<T> In, int Index, [CanBeNull]T Value)
            {
            if (In == null)
                return;
            if (!In.HasIndex(Index))
                return;

            var List = In as IList<T>;
            if (List != null)
                {
                List[Index] = Value;
                }
            }
        #endregion

        #region Shuffle
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> with the item order randomized.
        /// </summary>
        [Tested]
        public static List<T> Shuffle<T>([CanBeNull]this IEnumerable<T> In)
            {
            return In.Random(In.Count(), false);
            }
        /// <summary>
        /// Returns a new T[] with the item order randomized.
        /// </summary>
        [Tested]
        public static T[] Shuffle<T>([CanBeNull]this T[] In)
            {
            return In.List().Shuffle().Array();
            }
        /// <summary>
        /// Returns a new List<typeparamref name="T" /> with the item order randomized.
        /// </summary>
        [Tested]
        public static List<T> Shuffle<T>([CanBeNull]this IEnumerable In)
            {
            return In.List<T>().Shuffle();
            }
        #endregion

        #region Sort
        /// <summary>
        /// Sorts the collection using the default comparer which works for all types that support IComparable.
        /// </summary>
        /// <param name="In"></param>
        public static void Sort([CanBeNull]this IList In)
            {
            var Sorter = new QuickSorter(new ComparableComparer(), new DefaultSwap());
            Sorter.Sort(In);
            }
        /// <summary>
        /// Sorts the collection using the results of the passed [Comparer] Func`<typeparamref name="T" />,<typeparamref name="T" />,int.
        /// The Func should return positive if the first item is greater, negative if the second item is greater, and 0 if they are equal.
        /// </summary>
        public static void Sort<T>([CanBeNull]this IList<T> In, [CanBeNull]Func<T, T, int> Comparer)
            {
            var Sorter = new QuickSorter(new CustomComparer<T>(Comparer), new DefaultSwap());
            Sorter.Sort(In);
            }
        /// <summary>
        /// Sorts the collection using the results of the passed Field Retriever Func`<typeparamref name="T" />,IComparable to determine what the items should be sorted by.
        /// Return the value you would like the collection sorted by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <param name="FieldRetriever"></param>
        public static void Sort<T>([CanBeNull]this IList<T> In, [CanBeNull]Func<T, IComparable> FieldRetriever)
            {
            var Sorter = new QuickSorter(new CustomComparer<T>(FieldRetriever), new DefaultSwap());
            Sorter.Sort(In);
            }
        #endregion

        #region Swap
        /// <summary>
        /// Swaps two indexes in T[] <paramref name="In" />.
        /// </summary>
        public static void Swap<T>([CanBeNull]this T[] In, int Index1, int Index2)
            {
            if (In == null)
                return;
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            var Item = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = Item;
            }
        /// <summary>
        /// Swaps two indexes in list <paramref name="In" />.
        /// </summary>
        public static void Swap([CanBeNull]this IList In, int Index1, int Index2)
            {
            if (In == null)
                return;
            if (!In.HasIndex(Index1))
                throw new Exception($"Invalid index 1: {Index1}");
            if (!In.HasIndex(Index2))
                throw new Exception($"Invalid index 2: {Index2}");

            var Item = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = Item;
            }
        #endregion

        #region TotalCount
        /// <summary>
        /// Returns the total number of elements within the collection.
        /// Counts contained IEnumerable objects for their contents also.
        /// </summary>
        public static int TotalCount([CanBeNull]this IEnumerable In)
            {
            var Collection = In;
            var Dictionary = In as IDictionary;
            if (Dictionary != null)
                {
                Collection = Dictionary.Values;
                }

            if (In is string)
                {
                return 1;
                }
            int Out = 0;

            Collection.Each(Item =>
                {
                    var Enumerable = Item as IEnumerable;
                    if (Enumerable != null)
                        Out += Enumerable.TotalCount();
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
        public static bool While([CanBeNull]this IEnumerable In, [CanBeNull]Func<bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                return false;

            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once UnusedVariable
            foreach (var Obj in In)
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
        public static bool While<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                return false;

            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once UnusedVariable
            foreach (var Obj in In)
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
        public static bool While([CanBeNull]this IEnumerable In, [CanBeNull]Func<object, bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                return false;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var Obj in In)
                {
                bool Continue = Func(Obj);
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<T, bool> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                return false;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var Obj in In)
                {
                bool Continue = Func(Obj);
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
        public static bool While<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, bool> Func)
            {
            if (Func == null)
                return false;

            int Index = 0;
            return In.List<T>().While(o =>
            {
                bool Continue = Func(Index);
                Index++;
                return Continue;
            });
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While<T>([CanBeNull]this IEnumerable In, [CanBeNull]Func<int, T, bool> Func)
            {
            if (Func == null)
                return false;

            int Index = 0;
            return In.List<T>().While(o =>
            {
                bool Continue = Func(Index, o);
                Index++;
                return Continue;
            });
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static bool While<T>([CanBeNull]this IEnumerable<T> In, [CanBeNull]Func<int, T, bool> Func)
            {
            if (Func == null)
                return false;
            int Index = 0;
            return In.While(o =>
                {
                    bool Continue = Func(Index, o);
                    Index++;
                    return Continue;
                });
            }
        #endregion

        #region While Object
        /// <summary>
        /// Executes Action <paramref name="In" /> while <paramref name="Condition" /> returns true. 
        /// <paramref name="In" /> is passed values from <paramref name="Obj" />.
        /// </summary>
        public static void While<T>([CanBeNull]this Action<T> In, [CanBeNull]Func<bool> Condition, [CanBeNull]IEnumerable<T> Obj)
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
        /// Contains Generic List static methods and lambdas.
        /// </summary>
        public static class List
            {
            #region NewList
            /// <summary>
            /// Creates a new list of the specified type.
            /// Types supported: U[], List`<typeparamref name="U" />, String
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

            #region List +
            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns a function that returns an empty List<typeparamref name="T" /></returns>
            public static Func<List<T>> ToList<T>()
                {
                return () => new List<T>();
                }
            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns a function that returns a List<typeparamref name="T" /> filled with arguments</returns>
            public static Func<List<T>> ToList<T>(params T[] In)
                {
                return () => { var Out = new List<T>(); Out.AddRange(In); return Out; };
                }
            #endregion
            }
        }
    }