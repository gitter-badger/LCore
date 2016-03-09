using System;
using LCore;
using LCore.ObjectExtensions;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Reflection;
using LCore.UnitTesting;
using System.Linq.Expressions;

namespace LCore
    {
    public partial class Logic
        {
        #region Base Lambdas
        #region ICollection
        public static Func<ICollection, Int32> ICollection_GetCount = (i) => { return i.Count; };
        public static Func<ICollection, Object> ICollection_GetSyncRoot = (i) => { return i.SyncRoot; };
        public static Func<ICollection, Boolean> ICollection_GetIsSynchronized = (i) => { return i.IsSynchronized; };
        public static Action<ICollection, Array, Int32> ICollection_CopyTo = (i, array, index) => { i.CopyTo(array, index); };
        #endregion
        #region IList
        public static Func<IList, Int32, Object> IList_GetAt = (i, index) => { return i[index]; };
        public static Action<IList, Int32, Object> IList_SetAt = (i, index, o) => { i[index] = o; };
        public static Func<IList, Boolean> IList_GetIsReadOnly = (i) => { return i.IsReadOnly; };
        public static Func<IList, Boolean> IList_GetIsFixedSize = (i) => { return i.IsFixedSize; };
        public static Func<IList, Object, Int32> IList_Add = (i, value) => { return i.Add(value); };
        public static Func<IList, Object, Boolean> IList_Contains = (i, value) => { return i.Contains(value); };
        public static Action<IList> IList_Clear = (i) => { i.Clear(); };
        public static Func<IList, Object, Int32> IList_IndexOf = (i, value) => { return i.IndexOf(value); };
        public static Action<IList, Int32, Object> IList_Insert = (i, index, value) => { i.Insert(index, value); };
        public static Action<IList, Object> IList_Remove = (i, value) => { i.Remove(value); };
        public static Action<IList, Int32> IList_RemoveAt = (i, index) => { i.RemoveAt(index); };
        #endregion
        #region Array
        public static Func<Array, Int32> Array_GetLength = (a) => { return a.Length; };
        public static Func<Array, Int64> Array_GetLongLength = (a) => { return a.LongLength; };
        public static Func<Array, Int32> Array_GetRank = (a) => { return a.Rank; };
        public static Func<Array, Object> Array_GetSyncRoot = (a) => { return a.SyncRoot; };
        public static Func<Array, Boolean> Array_GetIsReadOnly = (a) => { return a.IsReadOnly; };
        public static Func<Array, Boolean> Array_GetIsFixedSize = (a) => { return a.IsFixedSize; };
        public static Func<Array, Boolean> Array_GetIsSynchronized = (a) => { return a.IsSynchronized; };
        public static Func<Type, Int32, Array> Array_CreateInstance = (elementType, length) => { return System.Array.CreateInstance(elementType, length); };
        public static Func<Type, Int32, Int32, Array> Array_CreateInstance2 = (elementType, length1, length2) => { return System.Array.CreateInstance(elementType, length1, length2); };
        public static Func<Type, Int32, Int32, Int32, Array> Array_CreateInstance3 = (elementType, length1, length2, length3) => { return System.Array.CreateInstance(elementType, length1, length2, length3); };
        public static Func<Type, Int32[], Array> Array_CreateInstance4 = (elementType, lengths) => { return System.Array.CreateInstance(elementType, lengths); };
        public static Func<Type, Int64[], Array> Array_CreateInstance5 = (elementType, lengths) => { return System.Array.CreateInstance(elementType, lengths); };
        public static Func<Type, Int32[], Int32[], Array> Array_CreateInstance6 = (elementType, lengths, lowerBounds) => { return System.Array.CreateInstance(elementType, lengths, lowerBounds); };
        public static Action<Array, Array, Int32> Array_Copy = (sourceArray, destinationArray, length) => { System.Array.Copy(sourceArray, destinationArray, length); };
        public static Action<Array, Array, Int64> Array_Copy3 = (sourceArray, destinationArray, length) => { System.Array.Copy(sourceArray, destinationArray, length); };
        public static Action<Array, Int32, Int32> Array_Clear = (array, index, length) => { System.Array.Clear(array, index, length); };
        public static Func<Array, Int32[], Object> Array_GetValue = (a, indices) => { return a.GetValue(indices); };
        public static Func<Array, Int32, Object> Array_GetValue2 = (a, index) => { return a.GetValue(index); };
        public static Func<Array, Int32, Int32, Object> Array_GetValue3 = (a, index1, index2) => { return a.GetValue(index1, index2); };
        public static Func<Array, Int32, Int32, Int32, Object> Array_GetValue4 = (a, index1, index2, index3) => { return a.GetValue(index1, index2, index3); };
        public static Func<Array, Int64, Object> Array_GetValue5 = (a, index) => { return a.GetValue(index); };
        public static Func<Array, Int64, Int64, Object> Array_GetValue6 = (a, index1, index2) => { return a.GetValue(index1, index2); };
        public static Func<Array, Int64, Int64, Int64, Object> Array_GetValue7 = (a, index1, index2, index3) => { return a.GetValue(index1, index2, index3); };
        public static Func<Array, Int64[], Object> Array_GetValue8 = (a, indices) => { return a.GetValue(indices); };
        public static Action<Array, Object, Int32> Array_SetValue = (a, value, index) => { a.SetValue(value, index); };
        public static Action<Array, Object, Int32, Int32> Array_SetValue2 = (a, value, index1, index2) => { a.SetValue(value, index1, index2); };
        public static Action<Array, Object, Int32[]> Array_SetValue4 = (a, value, indices) => { a.SetValue(value, indices); };
        public static Action<Array, Object, Int64> Array_SetValue5 = (a, value, index) => { a.SetValue(value, index); };
        public static Action<Array, Object, Int64, Int64> Array_SetValue6 = (a, value, index1, index2) => { a.SetValue(value, index1, index2); };
        public static Action<Array, Object, Int64[]> Array_SetValue8 = (a, value, indices) => { a.SetValue(value, indices); };
        public static Func<Array, Int32, Int32> Array_GetLength2 = (a, dimension) => { return a.GetLength(dimension); };
        public static Func<Array, Int32, Int64> Array_GetLongLength2 = (a, dimension) => { return a.GetLongLength(dimension); };
        public static Func<Array, Int32, Int32> Array_GetUpperBound = (a, dimension) => { return a.GetUpperBound(dimension); };
        public static Func<Array, Int32, Int32> Array_GetLowerBound = (a, dimension) => { return a.GetLowerBound(dimension); };
        public static Func<Array, Object> Array_Clone = (a) => { return a.Clone(); };
        public static Func<Array, Object, Int32> Array_BinarySearch = (array, value) => { return System.Array.BinarySearch(array, value); };
        public static Func<Array, Int32, Int32, Object, Int32> Array_BinarySearch2 = (array, index, length, value) => { return System.Array.BinarySearch(array, index, length, value); };
        public static Func<Array, Object, IComparer, Int32> Array_BinarySearch3 = (array, value, comparer) => { return System.Array.BinarySearch(array, value, comparer); };
        public static Action<Array, Array, Int32> Array_CopyTo = (a, array, index) => { a.CopyTo(array, index); };
        public static Action<Array, Array, Int64> Array_CopyTo2 = (a, array, index) => { a.CopyTo(array, index); };
        public static Func<Array, IEnumerator> Array_GetEnumerator = (a) => { return a.GetEnumerator(); };
        public static Func<Array, Object, Int32> Array_IndexOf = (array, value) => { return System.Array.IndexOf(array, value); };
        public static Func<Array, Object, Int32, Int32> Array_IndexOf2 = (array, value, startIndex) => { return System.Array.IndexOf(array, value, startIndex); };
        public static Func<Array, Object, Int32, Int32, Int32> Array_IndexOf3 = (array, value, startIndex, count) => { return System.Array.IndexOf(array, value, startIndex, count); };
        public static Func<Array, Object, Int32> Array_LastIndexOf = (array, value) => { return System.Array.LastIndexOf(array, value); };
        public static Func<Array, Object, Int32, Int32> Array_LastIndexOf2 = (array, value, startIndex) => { return System.Array.LastIndexOf(array, value, startIndex); };
        public static Func<Array, Object, Int32, Int32, Int32> Array_LastIndexOf3 = (array, value, startIndex, count) => { return System.Array.LastIndexOf(array, value, startIndex, count); };
        public static Action<Array> Array_Reverse = (array) => { System.Array.Reverse(array); };
        public static Action<Array, Int32, Int32> Array_Reverse2 = (array, index, length) => { System.Array.Reverse(array, index, length); };
        public static Action<Array> Array_Sort = (array) => { System.Array.Sort(array); };
        public static Action<Array, Array> Array_Sort2 = (keys, items) => { System.Array.Sort(keys, items); };
        public static Action<Array, Int32, Int32> Array_Sort3 = (array, index, length) => { System.Array.Sort(array, index, length); };
        public static Action<Array, Array, Int32, Int32> Array_Sort4 = (keys, items, index, length) => { System.Array.Sort(keys, items, index, length); };
        public static Action<Array, IComparer> Array_Sort5 = (array, comparer) => { System.Array.Sort(array, comparer); };
        public static Action<Array, Array, IComparer> Array_Sort6 = (keys, items, comparer) => { System.Array.Sort(keys, items, comparer); };
        public static Action<Array, Int32, Int32, IComparer> Array_Sort7 = (array, index, length, comparer) => { System.Array.Sort(array, index, length, comparer); };
        public static Action<Array> Array_Initialize = (a) => { a.Initialize(); };
        /* No Generic Types 
        public static Func<T[], ReadOnlyCollection`1> Array_AsReadOnly = (array) => { return Array.AsReadOnly(array); };
        */
        /* No Generic Types 
        public static Action<T[]&, Int32> Array_Resize = (array, newSize) => {Array.Resize(array, newSize); };
        */
        /* Too Many Parameters :( 
        public static Action<Array, Int32, Array, Int32, Int32> Array_Copy2 = (sourceArray, sourceIndex, destinationArray, destinationIndex, length) => {Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length); };
        */
        /* Too Many Parameters :( 
        public static Action<Array, Int32, Array, Int32, Int32> Array_ConstrainedCopy = (sourceArray, sourceIndex, destinationArray, destinationIndex, length) => {Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length); };
        */
        /* Too Many Parameters :( 
        public static Action<Array, Int64, Array, Int64, Int64> Array_Copy4 = (sourceArray, sourceIndex, destinationArray, destinationIndex, length) => {Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length); };
        */
        /* Too Many Parameters :( 
        public static Action<Array, Object, Int32, Int32, Int32> Array_SetValue3 = (a, value, index1, index2, index3) => {a.SetValue(value, index1, index2, index3); };
        */
        /* Too Many Parameters :( 
        public static Action<Array, Object, Int64, Int64, Int64> Array_SetValue7 = (a, value, index1, index2, index3) => {a.SetValue(value, index1, index2, index3); };
        */
        /* Too Many Parameters :( 
        public static Func<Array, Int32, Int32, Object, IComparer, Int32> Array_BinarySearch4 = (array, index, length, value, comparer) => { return Array.BinarySearch(array, index, length, value, comparer); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32> Array_BinarySearch5 = (array, value) => { return Array.BinarySearch(array, value); };
        */
        /* No Generic Types 
        public static Func<T[], T, IComparer`1, Int32> Array_BinarySearch6 = (array, value, comparer) => { return Array.BinarySearch(array, value, comparer); };
        */
        /* No Generic Types 
        public static Func<T[], Int32, Int32, T, Int32> Array_BinarySearch7 = (array, index, length, value) => { return Array.BinarySearch(array, index, length, value); };
        */
        /* Too Many Parameters :( 
        public static Func<T[], Int32, Int32, T, IComparer`1, Int32> Array_BinarySearch8 = (array, index, length, value, comparer) => { return Array.BinarySearch(array, index, length, value, comparer); };
        */
        /* No Generic Types 
        public static Func<TInput[], Converter`2, TOutput[]> Array_ConvertAll = (array, converter) => { return Array.ConvertAll(array, converter); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, Boolean> Array_Exists = (array, match) => { return Array.Exists(array, match); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, T> Array_Find = (array, match) => { return Array.Find(array, match); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, T[]> Array_FindAll = (array, match) => { return Array.FindAll(array, match); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, Int32> Array_FindIndex = (array, match) => { return Array.FindIndex(array, match); };
        */
        /* No Generic Types 
        public static Func<T[], Int32, Predicate`1, Int32> Array_FindIndex2 = (array, startIndex, match) => { return Array.FindIndex(array, startIndex, match); };
        */
        /* No Generic Types 
        public static Func<T[], Int32, Int32, Predicate`1, Int32> Array_FindIndex3 = (array, startIndex, count, match) => { return Array.FindIndex(array, startIndex, count, match); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, T> Array_FindLast = (array, match) => { return Array.FindLast(array, match); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, Int32> Array_FindLastIndex = (array, match) => { return Array.FindLastIndex(array, match); };
        */
        /* No Generic Types 
        public static Func<T[], Int32, Predicate`1, Int32> Array_FindLastIndex2 = (array, startIndex, match) => { return Array.FindLastIndex(array, startIndex, match); };
        */
        /* No Generic Types 
        public static Func<T[], Int32, Int32, Predicate`1, Int32> Array_FindLastIndex3 = (array, startIndex, count, match) => { return Array.FindLastIndex(array, startIndex, count, match); };
        */
        /* No Generic Types 
        public static Action<T[], Action`1> Array_ForEach = (array, action) => {Array.ForEach(array, action); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32> Array_IndexOf4 = (array, value) => { return Array.IndexOf(array, value); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32, Int32> Array_IndexOf5 = (array, value, startIndex) => { return Array.IndexOf(array, value, startIndex); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32, Int32, Int32> Array_IndexOf6 = (array, value, startIndex, count) => { return Array.IndexOf(array, value, startIndex, count); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32> Array_LastIndexOf4 = (array, value) => { return Array.LastIndexOf(array, value); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32, Int32> Array_LastIndexOf5 = (array, value, startIndex) => { return Array.LastIndexOf(array, value, startIndex); };
        */
        /* No Generic Types 
        public static Func<T[], T, Int32, Int32, Int32> Array_LastIndexOf6 = (array, value, startIndex, count) => { return Array.LastIndexOf(array, value, startIndex, count); };
        */
        /* Too Many Parameters :( 
        public static Action<Array, Array, Int32, Int32, IComparer> Array_Sort8 = (keys, items, index, length, comparer) => {Array.Sort(keys, items, index, length, comparer); };
        */
        /* No Generic Types 
        public static Action<T[]> Array_Sort9 = (array) => {Array.Sort(array); };
        */
        /* No Generic Types 
        public static Action<TKey[], TValue[]> Array_Sort10 = (keys, items) => {Array.Sort(keys, items); };
        */
        /* No Generic Types 
        public static Action<T[], Int32, Int32> Array_Sort11 = (array, index, length) => {Array.Sort(array, index, length); };
        */
        /* No Generic Types 
        public static Action<TKey[], TValue[], Int32, Int32> Array_Sort12 = (keys, items, index, length) => {Array.Sort(keys, items, index, length); };
        */
        /* No Generic Types 
        public static Action<T[], IComparer`1> Array_Sort13 = (array, comparer) => {Array.Sort(array, comparer); };
        */
        /* No Generic Types 
        public static Action<TKey[], TValue[], IComparer`1> Array_Sort14 = (keys, items, comparer) => {Array.Sort(keys, items, comparer); };
        */
        /* No Generic Types 
        public static Action<T[], Int32, Int32, IComparer`1> Array_Sort15 = (array, index, length, comparer) => {Array.Sort(array, index, length, comparer); };
        */
        /* Too Many Parameters :( 
        public static Action<TKey[], TValue[], Int32, Int32, IComparer`1> Array_Sort16 = (keys, items, index, length, comparer) => {Array.Sort(keys, items, index, length, comparer); };
        */
        /* No Generic Types 
        public static Action<T[], Comparison`1> Array_Sort17 = (array, comparison) => {Array.Sort(array, comparison); };
        */
        /* No Generic Types 
        public static Func<T[], Predicate`1, Boolean> Array_TrueForAll = (array, match) => { return Array.TrueForAll(array, match); };
        */
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Int32> Object_GetHashCode = (o) => { return o.GetHashCode(); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region IList
        public static Func<IList, int> List_Count = (list) => { return list == null ? 0 : list.Count; };
        public static Func<IList, Boolean> List_IsEmpty = (arr) => { return arr == null || arr.Count == 0; };
        private static Func<IList, int, Object> _List_Index = (arr, i) => { return arr[i]; };
        public static Func<IList, int, Object> List_Index = _List_Index.Try();
        private static Action<IList, int, Object> _List_IndexSet = (arr, i, obj) => { arr[i] = obj; };
        public static Action<IList, int, Object> List_IndexSet = _List_IndexSet.Try().Do();
        public static Action<IList, Object> List_AddUnlessContains = (List, obj) =>
        {
            if (!List.Contains(obj))
                List.Add(obj);
        };
        #endregion
        #region Array
        public static Func<Array, int> Array_SafeLength = (arr) => { return arr == null ? 0 : arr.Length; };
        public static Func<Array, Boolean> Array_IsEmpty = (arr) => { return arr == null || arr.Length == 0; };
        private static Func<Array, int, Object> _Array_Index = (arr, i) => { return arr.GetValue(i); };
        public static Func<Array, int, Object> Array_SafeIndex = _Array_Index.Try();
        private static Action<Array, int, Object> _Array_IndexSet = (arr, i, obj) => { arr.SetValue(obj, i); };
        public static Action<Array, int, Object> Array_SafeIndexSet = _List_IndexSet.Try().Do();
        #endregion
        #endregion

        #region Array
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Returns a function that returns an empty T[]</returns>
        public static Func<T[]> Array<T>()
            {
            return () => { return new T[] { }; };
            }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <returns>Returns a function that returns a T[] filled with arguments</returns>
        public static Func<T[]> Array<T>(params T[] In)
            {
            return () => { return In; };
            }
        #endregion
        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Returns a function that returns an empty List[T]</returns>
        public static Func<List<T>> List<T>()
            {
            return () => { return new List<T>(); };
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
    public static class ListExt
        {
        #region Each
        /// <summary>
        /// Iterates through every item in a collection, executing the passed Action.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.Fail_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.Fail_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.ReceiveObject_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.ReceiveObject_Name })]
        [TestSucceedes(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.ReceiveObject_Name }, ListExt.Test.HasReceivedObjects_Name)]
        public static void Each(this IEnumerable In, Action<Object> Func)
            {
            if (!In.IsEmpty())
                {
                foreach (Object o in In)
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.ReceiveT_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.ReceiveT_Name })]
        [TestSucceedes(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.ReceiveT_Name }, ListExt.Test.HasReceivedObjects_Name)]
        [TestSucceedes(new Object[] { new Object[] { 1, 2, "a", 3 }, ListExt.Test.ReceiveT_Name }, ListExt.Test.HasReceivedObjectsButNoStrings_Name)]
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.ReceiveT_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.ReceiveT_Name })]
        [TestSucceedes(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.ReceiveT_Name }, ListExt.Test.HasReceivedObjects_Name)]
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailOI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailOI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.ReceiveObjectI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.ReceiveObjectI_Name })]
        [TestSucceedes(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.ReceiveObjectI_Name }, ListExt.Test.HasReceivedObjectsI_Name)]
        public static void EachI(this IEnumerable In, Action<int, Object> Func)
            {
            if (!In.IsEmpty())
                {
                int i = 0;
                foreach (Object o in In)
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailOI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailOI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.ReceiveObjectI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.ReceiveObjectI_Name })]
        [TestSucceedes(new Object[] { new Object[] { 1, 2, "", 3 }, ListExt.Test.ReceiveObjectI_Name }, ListExt.Test.HasReceivedObjectsI_Name)]
        public static void EachI<T>(this IEnumerable In, Action<int, Object> Func)
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailIT_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailIT_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.ReceiveTI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.ReceiveTI_Name })]
        [TestSucceedes(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.ReceiveTI_Name }, ListExt.Test.HasReceivedObjectsI_Name)]
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
        #region Collect
        /// <summary>
        /// Runs a Func[Object,Object] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailOO_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailOO_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.IncrementObjectInt_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.IncrementObjectInt_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.IncrementObjectInt_Name }, new Object[] { 2, 3, 4 })]
        public static List<Object> Collect(this IEnumerable In, Func<Object, Object> Func)
            {
            In = In ?? new Object[] { };
            List<Object> Out = new List<Object>();
            foreach (Object o in In)
                {
                Object obj = Func(o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. 
        /// Null values and values that are not of type T are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.IncrementInt_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.IncrementInt_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.IncrementInt_Name }, new int[] { 2, 3, 4 })]
        [TestResult(new Object[] { new Object[] { 1, 2, "a", 3 }, ListExt.Test.IncrementInt_Name }, new int[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this IEnumerable In, Func<T, T> Func)
            {
            In = In.List<T>();

            List<T> Out = new List<T>();
            foreach (T o in In)
                {
                T obj = Func(o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        /// <summary>
        /// Runs a Func[T,T] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters.
        /// Returns a list containing the result of the Func[T,T]. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.IncrementInt_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.IncrementInt_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.IncrementInt_Name }, new int[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this IEnumerable<T> In, Func<T, T> Func)
            {
            In = In ?? new T[] { };

            List<T> Out = new List<T>();
            foreach (T o in In)
                {
                T obj = Func(o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        /// <summary>
        /// Iterates through a collection, executing the Func[T,T] on the input.
        /// Returns a T[] of the results. Null values are excluded.
        /// This method will fail if [Func] is null or if [Func] throws an exception.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.IncrementInt_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.IncrementInt_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.IncrementInt_Name }, new int[] { 2, 3, 4 })]
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.IncrementInt_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.IncrementInt_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.IncrementInt_Name }, new int[] { 2, 3, 4 })]
        public static List<T> Collect<T>(this List<T> In, Func<T, T> Func)
            {
            In = In ?? new List<T>();
            List<T> Out = new List<T>();
            foreach (T o in In)
                {
                T obj = Func(o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        #endregion
        #region CollectI
        /// <summary>
        /// Runs a Func[Object,Object] [In.Count] times and returns a list with the results. 
        /// Values from the Input collection are used as the parameters. Null values are excluded.
        /// </summary>
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailIOOFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailIOOFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.PassI_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.PassI_Name })]
        [TestResult(new Object[] { new Object[] { 1, 2, 3 }, ListExt.Test.PassI_Name }, new Object[] { 0, 1, 2 })]
        public static List<Object> CollectI(this IEnumerable In, Func<int, Object, Object> Func)
            {
            In = In ?? new Object[] { };

            List<Object> Out = new List<Object>();

            int i = 0;
            foreach (Object o in In)
                {
                Object obj = Func(i, o);
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.PassIII_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.PassIII_Name })]
        [TestResult(new Object[] { new Object[] { 1, 2, 3 }, ListExt.Test.PassIII_Name }, new int[] { 0, 1, 2 })]
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.PassIII_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.PassIII_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.PassIII_Name }, new int[] { 0, 1, 2 })]
        public static List<T> CollectI<T>(this IEnumerable<T> In, Func<int, T, T> Func)
            {
            In = In ?? new T[] { };

            int Count = In.Count();
            List<T> Out = new List<T>();

            int i = 0;
            foreach (T o in In)
                {
                T obj = Func(i, (T)o);
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.PassIII_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.PassIII_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.PassIII_Name }, new int[] { 0, 1, 2 })]
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
        [TestFails(new Object[] { new int[] { 1 }, null })]
        [TestFails(new Object[] { new int[] { 1 }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.FailITTFunc_Name })]
        [TestSucceedes(new Object[] { new int[] { }, null })]
        [TestSucceedes(new Object[] { null, ListExt.Test.PassIII_Name })]
        [TestSucceedes(new Object[] { new int[] { }, ListExt.Test.PassIII_Name })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, ListExt.Test.PassIII_Name }, new int[] { 0, 1, 2 })]
        public static List<T> CollectI<T>(this List<T> In, Func<int, T, T> Func)
            {
            In = In ?? new List<T>();

            int Count = In.Count;
            List<T> Out = new List<T>();
            for (int i = 0; i < Count; i++)
                {
                T o = In[i];
                T obj = Func(i, (T)o);
                if (obj != null)
                    Out.Add(obj);
                }
            return Out;
            }
        #endregion

        #region Collect Func
        /// <summary>
        /// Runs a Func[T] [Count] times and returns a list with the results.
        /// Returns a list containing the result of the Func[T]. Null values are excluded.
        /// </summary>
        public static List<T> Collect<T>(this Func<T> In, int Count)
            {
            List<T> Out = NewList<List<T>, T>();
            (0).To(Count - 1, (i) => { Out.Add(In()); });
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
            (0).To(Count - 1, (i) => { Out.Add(In(i)); });
            return Out;
            }
        #endregion
        #region Convert
        /// <summary>
        /// Iterates through a collection, returning a List[Object] containing the results of the passed Func[Object,Object].
        /// Null values are ignored.
        /// </summary>
        public static List<Object> Convert(this IEnumerable In, Func<Object, Object> Func)
            {
            return In.ConvertI((i, o) => { return Func(o); });
            }
        /// <summary>
        /// Iterates through a collection, returning a U[] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static U[] Convert<T, U>(this T[] In, Func<T, U> Func)
            {
            return In.ConvertI<T, U>((i, o) => { return Func(o); });
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this List<T> In, Func<T, U> Func)
            {
            return In.ConvertI<T, U>((i, o) => { return Func(o); });
            }
        /// <summary>
        /// Iterates through a collection, returning a List[U] containing the results of the passed Func[T,U].
        /// Null values are ignored.
        /// </summary>
        public static List<U> Convert<T, U>(this IEnumerable<T> In, Func<T, U> Func)
            {
            return In.ConvertI<T, U>((i, o) => { return Func(o); });
            }
        #endregion
        #region ConvertI
        /// <summary>
        /// Iterates through a collection, returning a List[Object] containing the results of the passed Func[Object,Object].
        /// The int passed is the 0-based index of the current item.
        /// Null values are ignored.
        /// </summary>
        public static List<Object> ConvertI(this IEnumerable In, Func<int, Object, Object> Func)
            {
            List<Object> Out = NewList<List<Object>, Object>();
            In.EachI((i, o) =>
            {
                Object obj = Func(i, o);
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
        #region While
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static Boolean While(this IEnumerable In, Func<Boolean> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException("Func");

            foreach (Object o in In)
                {
                Boolean Continue = Func();
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static Boolean While<T>(this IEnumerable<T> In, Func<Boolean> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException("Func");

            foreach (T o in In)
                {
                Boolean Continue = Func();
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static Boolean While(this IEnumerable In, Func<Object, Boolean> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException("Func");

            foreach (Object o in In)
                {
                Boolean Continue = Func(o);
                if (!Continue)
                    return false;
                }
            return true;
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static Boolean While<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
            {
            if (In == null)
                return false;
            if (Func == null)
                throw new ArgumentNullException("Func");

            foreach (T o in In)
                {
                Boolean Continue = Func(o);
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
        public static Boolean WhileI(this IEnumerable In, Func<int, Boolean> Func)
            {
            if (Func == null)
                throw new ArgumentNullException("Func");

            int i = 0;
            return In.While((o) =>
            {
                Boolean Continue = Func(i);
                i++;
                return Continue;
            });
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static Boolean WhileI(this IEnumerable In, Func<int, Object, Boolean> Func)
            {
            if (Func == null)
                throw new ArgumentNullException("Func");

            int i = 0;
            return In.While((o) =>
            {
                Boolean Continue = Func(i, o);
                i++;
                return Continue;
            });
            }
        /// <summary>
        /// Iterates through a collection. A false return value from the Func stops the iteration.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Returns false if the While loop was stopped prematurely or if the input was null, true otherwise.
        /// </summary>
        public static Boolean WhileI<T>(this IEnumerable<T> In, Func<int, T, Boolean> Func)
            {
            if (Func == null)
                throw new ArgumentNullException("Func");

            int i = 0;
            return In.While<T>(new Func<T, Boolean>((o) =>
            {
                Boolean Continue = Func(i, o);
                i++;
                return Continue;
            }));
            }
        #endregion
        #region Add
        /// <summary>
        /// Returns a new T[] with the supplied items appended to it.
        /// </summary>
        [TestMethodGenerics(typeof(int))]
        [TestResult(new Object[] { null, null }, new int[] { })]
        [TestResult(new Object[] { null, new int[] { } }, new int[] { })]
        [TestResult(new Object[] { null, new int[] { 1 } }, new int[] { 1 })]
        [TestResult(new Object[] { new int[] { }, new int[] { 1 } }, new int[] { 1 })]
        [TestResult(new Object[] { new int[] { 1 }, null }, new int[] { 1 })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } }, new int[] { 1, 2, 3, 4, 5, 6 })]
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
        [TestResult(new Object[] { null, null }, new int[] { })]
        [TestResult(new Object[] { null, new int[] { } }, new int[] { })]
        [TestResult(new Object[] { null, new int[] { 1 } }, new int[] { 1 })]
        [TestResult(new Object[] { new int[] { }, new int[] { 1 } }, new int[] { 1 })]
        [TestResult(new Object[] { new int[] { 1 }, null }, new int[] { 1 })]
        [TestResult(new Object[] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } }, new int[] { 1, 2, 3, 4, 5, 6 })]
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
        [TestFails(new Object[] { null, null }, typeof(ArgumentNullException))]
        [TestFails(new Object[] { null, new int[] { } }, typeof(ArgumentNullException))]
        [TestFails(new Object[] { null, new int[] { 1 } }, typeof(ArgumentNullException))]
        [TestSource(new Object[] { new int[] { }, null }, new int[] { })]
        [TestSource(new Object[] { new int[] { }, new int[] { 1 } }, new int[] { 1 })]
        [TestSource(new Object[] { new int[] { 1 }, null }, new int[] { 1 })]
        [TestSource(new Object[] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public static void Add<T>(this List<T> In, params T[] Objs)
            {
            In.Add((IEnumerable<T>)Objs);
            }
        [TestMethodGenerics(typeof(int))]
        [TestFails(new Object[] { null, null }, typeof(ArgumentNullException))]
        [TestFails(new Object[] { null, new int[] { } }, typeof(ArgumentNullException))]
        [TestFails(new Object[] { null, new int[] { 1 } }, typeof(ArgumentNullException))]
        [TestSource(new Object[] { new int[] { }, null }, new int[] { })]
        [TestSource(new Object[] { new int[] { }, new int[] { 1 } }, new int[] { 1 })]
        [TestSource(new Object[] { new int[] { 1 }, null }, new int[] { 1 })]
        [TestSource(new Object[] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public static void Add<T>(this List<T> In, IEnumerable<T> Objs)
            {
            if (In == null)
                throw new ArgumentNullException("In");
            if (Objs.IsEmpty())
                return;

            In.AddRange(Objs);
            }
        #endregion
        #region AddTo
        /// <summary>
        /// Adds the item of the supplied collection to the second supplied collection.
        /// This method tries to look for the Collection's Add method, if it exists.
        /// </summary>
        public static void AddTo<T>(this IEnumerable<T> In, ICollection Collection)
            {
            Type CollectionType = Collection.GetType();

            MethodInfo AddMethod = CollectionType.GetMethod("Add", new Type[] { typeof(T) });

            if (AddMethod == null)
                AddMethod = CollectionType.GetMethod("Add", new Type[] { typeof(Object) });

            if (AddMethod == null)
                throw new Exception("Could not find 'Add' method for type '" + typeof(T) + "'");

            In.Each<T>((o) => { AddMethod.Invoke(Collection, new object[] { o }); });
            }
        #endregion
        #region All
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean All(this IEnumerable In, Func<Boolean> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean All<T>(this IEnumerable<T> In, Func<Boolean> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean All(this IEnumerable In, Func<Object, Boolean> Condition)
            {
            return In.While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean All<T>(this IEnumerable In, Func<T, Boolean> Condition)
            {
            if (Condition == null)
                throw new ArgumentNullException("Condition");

            return In.IsEmpty() ? false : In.List<T>().While(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean All<T>(this IEnumerable<T> In, Func<T, Boolean> Condition)
            {
            return In.While(Condition);
            }
        #endregion
        #region AllI
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean AllI(this IEnumerable In, Func<int, Boolean> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean AllI<T>(this IEnumerable<T> In, Func<int, Boolean> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean AllI(this IEnumerable In, Func<int, Object, Boolean> Condition)
            {
            return In.WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean AllI<T>(this IEnumerable In, Func<int, T, Boolean> Condition)
            {
            return In.List<T>().WhileI(Condition);
            }
        /// <summary>
        /// Returns a Boolean indicating whether all items in the list satisfy the supplied condition.
        /// The int passed to the Func is the 0-based index of the current item.
        /// Execution will halt once the Condition returns false.
        /// </summary>
        public static Boolean AllI<T>(this IEnumerable<T> In, Func<int, T, Boolean> Condition)
            {
            return In.WhileI(Condition);
            }
        #endregion
        #region Has Object
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        public static Boolean Has<T>(this IEnumerable In, T Obj)
            {
            return In.Filter<T>().Has(Obj.If());
            }
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        public static Boolean Has(this IEnumerable In, Object Obj)
            {
            return In.Has(Obj.If());
            }
        /// <summary>
        /// Returns whether the collection contains an object equivalent to Obj.
        /// Execution will stop immediately if an object is found.
        /// </summary>
        public static Boolean Has<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Has(Obj.If());
            }
        #endregion
        #region Has Any Object
        public static Boolean HasAny<T>(this IEnumerable In, IEnumerable<T> Obj)
            {
            return Obj.Has((o) => { return In.Has(o); });
            }
        public static Boolean HasAny(this IEnumerable In, IEnumerable Obj)
            {
            return Obj.Has((o) => { return In.Has(o); });
            }
        public static Boolean HasAny<T>(this IEnumerable<T> In, IEnumerable<T> Obj)
            {
            return Obj.Has((o) => { return In.Has(o); });
            }
        public static Boolean HasAny(this IEnumerable In, params Object[] Obj)
            {
            return In.HasAny((IEnumerable)Obj);
            }
        public static Boolean HasAny<T>(this IEnumerable<T> In, params T[] Obj)
            {
            return In.HasAny((IEnumerable<T>)Obj);
            }
        #endregion
        #region Has Func
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        public static Boolean Has<T>(this IEnumerable In, Func<T, Boolean> Condition)
            {
            return In.Filter<T>().Has(Condition);
            }
        /// <summary>
        /// Returns whether the collection contains an object that receives a true value from the condition when passed to it.
        /// Execution will stop immediately if a true value is found.
        /// </summary>
        public static Boolean Has(this IEnumerable In, Func<Object, Boolean> Condition)
            {
            Boolean Found = false;
            In.While((o) =>
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
        public static Boolean Has<T>(this IEnumerable<T> In, Func<T, Boolean> Condition)
            {
            Boolean Found = false;
            In.While((o) =>
            {
                Found = Found || Condition(o);
                return !Found;
            });
            return Found;
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

            if (In is Array)
                {
                return L.Array_SafeLength((Array)(Object)In);
                }
            else if (In is IList)
                {
                return L.List_Count((IList)(Object)In);
                }
            else if (In is ICollection)
                {
                try
                    {
                    return ((ICollection)(Object)In).Count;
                    }
                catch
                    {
                    return 0;
                    }
                }
            else if (In is String)
                {
                try
                    {
                    return ((String)(Object)In).Length;
                    }
                catch
                    {
                    return 0;
                    }
                }
            else if (In is IEnumerable)
                {
                int Count = 0;

                IEnumerator Enumerator = ((IEnumerable)In).GetEnumerator();

                while (Enumerator.MoveNext())
                    {
                    Count++;
                    }

                return Count;
                }
            else
                {
                throw new Exception(typeof(T).FullName);
                }
            }
        #endregion
        #region Count Object
        /// <summary>
        /// Returns the number of items in the collection that are equivalent to Obj.
        /// </summary>
        public static int Count<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Count(L.Object_SafeEquals.Supply(Obj).Cast<Object, Boolean, T, Boolean>());
            }
        #endregion
        #region Count Func
        /*
        /// <summary>
        /// Returns the number of items in the collection that evoke a true result from Func[T,Boolean].
        /// </summary>
        public static int Count<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
            {
            int Out = 0;
            In.Each((o) =>
            {
                Boolean Result = Func(o);
                if (Result)
                    Out++;
            });
            return Out;
            }
         */
        #endregion
        #region IsEmpty
        /// <summary>
        /// Returns whether a collection is empty.
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Boolean IsEmpty(this IEnumerable In)
            {
            return In == null || In.Count() == 0;
            }
        public static Boolean IsEmpty<T>(this IEnumerable<T> In)
            {
            return In == null || System.Linq.Enumerable.Count<T>(In) == 0;
            }
        #endregion
        #region Reverse
        /// <summary>
        /// Returns a new array with the item orders reversed.
        /// </summary>
        public static T[] Reverse<T>(this T[] In)
            {
            int Count = In.Count();
            return In.CollectI<T>((i, o) =>
            {
                return In[Count - (i + 1)];
            });
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
            List<T> Out = In.List<T>();
            Out.Reverse<T>();
            return Out;
            }
        /// <summary>
        /// Returns a new List[Object] with the order of the items revesed.
        /// </summary>
        public static List<Object> Reverse(this IEnumerable In)
            {
            List<Object> Out = In.List<Object>();
            Out.Reverse<Object>();
            return Out;
            }
        #endregion
        #region Random
        private static int RandomSeed = new Random().Next();
        /// <summary>
        /// Returns a new List[T] containing [Count] random items from the collection.
        /// If Count is higher than In.Count, an ArgumentException will be thrown.
        /// </summary>
        public static List<T> Random<T>(this IEnumerable<T> In, int Count)
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

            return RandomIndexes.Convert((i) => { return In.GetAt(i); });
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

            return RandomIndexes.ToArray().Convert((i) => { return In[i]; });
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

            return In.GetAt<T>(RandomIndex);
            }
        #endregion
        #region Fill
        /// <summary>
        /// Returns a new T[] containing [In.Count] entries containing the passed Obj.
        /// </summary>
        public static T[] Fill<T>(this T[] In, T Obj)
            {
            return In.Collect<T>((o) => { return Obj; });
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
            return In.Collect<T>((o) => { return Obj; });
            }
        #endregion
        #region Remove
        /// <summary>
        /// Returns a new List[T] that contains no instances of any object whose ToString value is within the Strings passed.
        /// </summary>
        public static List<T> Remove<T>(this IEnumerable<T> In, params String[] Strings)
            {
            if (Strings.IsEmpty())
                return In.List();

            return In.Remove<T>((o) => { return Strings.Contains(o.ToString()); });
            }
        /// <summary>
        /// Returns a new List[T] that contains no instances of any object passed.
        /// </summary>
        public static List<T> Remove<T>(this IEnumerable<T> In, params T[] Objs)
            {
            if (Objs.IsEmpty())
                return In.List();

            return In.Remove<T>((o) => { return Objs.Contains(o); });
            }
        /// <summary>
        /// Returns a new List[T] that contains no instances of any object that evokes a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Remove<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
            {
            return In.List().Select<T>((o) => { return !Func(o); });
            }
        /// <summary>
        /// Returns a new List[T] that contains no instances of any object that evokes a true result from the passed Func[int,T,Boolean].
        /// The int passed to the function is the 0-based index of the current item.
        /// </summary>
        public static List<T> RemoveI<T>(this IEnumerable<T> In, Func<int, T, Boolean> Func)
            {
            return In.SelectI<T>((i, o) => { return !Func(i, o); });
            }
        #endregion
        #region RemoveAt
        /// <summary>
        /// Returns a new List[T], excluding any indexes passed.
        /// </summary>
        public static List<T> RemoveAt<T>(this IEnumerable<T> In, params int[] Indexes)
            {
            if (Indexes.IsEmpty())
                return In.List();

            return In.SelectI<T>((i, o) => { return !Indexes.Contains(i); });
            }
        public static T[] RemoveAt<T>(this T[] In, params int[] Indexes)
            {
            if (Indexes.IsEmpty())
                return In ?? new T[] { };

            return In.SelectI<T>((i, o) => { return !Indexes.Contains(i); });
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

            In.Each((o) =>
            {
                if (o is T)
                    Out.Add((T)o);
                else if (o is IEnumerable)
                    Out.AddRange(((IEnumerable)o).Flatten<T>());
            });
            return Out;
            }
        #endregion
        #region Select
        /// <summary>
        /// Returns a new List[Object] containing items from In that evoke a true result from the passed Func[Object,Boolean].
        /// </summary>
        public static List<Object> Select(this IEnumerable In, Func<Object, Boolean> Func)
            {
            List<Object> Out = NewList<List<Object>, Object>();

            In.Each((Result) =>
            {
                Boolean Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new T[] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static T[] Select<T>(this T[] In, Func<T, Boolean> Func)
            {
            T[] Out = NewList<T[], T>();

            In.Each((Result) =>
            {
                Boolean Select = Func(Result);
                if (Select)
                    Out = Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Select<T>(this List<T> In, Func<T, Boolean> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each((Result) =>
            {
                Boolean Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Select<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.Each((Result) =>
            {
                Boolean Select = Func(Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }

        /// <summary>
        /// Returns a new List[Object] containing items from In that evoke a true result from the passed Func[int,Object,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<Object> SelectI(this IEnumerable In, Func<int, Object, Boolean> Func)
            {
            List<Object> Out = NewList<List<Object>, Object>();

            In.EachI((i, Result) =>
            {
                Boolean Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }

        /// <summary>
        /// Returns a new T[] containing items from In that evoke a true result from the passed Func[int,T,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static T[] SelectI<T>(this T[] In, Func<int, T, Boolean> Func)
            {
            T[] Out = NewList<T[], T>();

            In.EachI((i, Result) =>
            {
                Boolean Select = Func(i, Result);
                if (Select)
                    Out = Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<T> SelectI<T>(this List<T> In, Func<int, T, Boolean> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.EachI((i, Result) =>
            {
                Boolean Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
            }
        /// <summary>
        /// Returns a new List[T] containing items from In that evoke a true result from the passed Func[T,Boolean].
        /// The int passed to the Func is the 0-based index of the current item.
        /// </summary>
        public static List<T> SelectI<T>(this IEnumerable<T> In, Func<int, T, Boolean> Func)
            {
            List<T> Out = NewList<List<T>, T>();

            In.EachI((i, Result) =>
            {
                Boolean Select = Func(i, Result);
                if (Select)
                    Out.Add(Result);
            });
            return Out;
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
            return In.First(L.True.Arg<T, Boolean>(), Count);
            }
        /// <summary>
        /// Returns the first item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T First<T>(this List<T> In)
            {
            List<T> Result = In.First(L.True.Arg<T, Boolean>(), 1);
            if (Result.Count() > 0)
                return Result[0];
            return default(T);
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items in the source List[T].
        /// </summary>
        public static List<T> First<T>(this List<T> In, int Count)
            {
            return In.First(L.True.Arg<T, Boolean>(), Count);
            }
        /// <summary>
        /// Returns the first item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T First<T>(this IEnumerable<T> In)
            {
            return L.F(() => { return In.GetAt(0); }).Try()();
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
            return In.First(L.True.Arg<T, Boolean>());
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items in the source collection that are of type T.
        /// </summary>
        public static List<T> First<T>(this IEnumerable In, int Count)
            {
            return In.List<T>().First(Count);
            }
        #endregion
        #region First Object
        /// <summary>
        /// Returns the first T in the source T[] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this T[] In, T Obj)
            {
            return In.First<T>(Obj.If());
            }
        /// <summary>
        /// Returns the first T in the source List[T] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this List<T> In, T Obj)
            {
            return In.First<T>(Obj.If());
            }
        /// <summary>
        /// Returns the first T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this IEnumerable<T> In, T Obj)
            {
            return In.First<T>(Obj.If());
            }
        /// <summary>
        /// Returns the first T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T First<T>(this IEnumerable In, T Obj)
            {
            return In.First<T>(Obj.If());
            }
        #endregion
        #region First Func
        /// <summary>
        /// Returns the first item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this IEnumerable In, Func<T, Boolean> Func)
            {
            return In.List<T>().First(Func);
            }
        /// <summary>
        /// Returns the first item in the source T[] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this T[] In, Func<T, Boolean> Func)
            {
            T[] Result = In.First<T>(Func, 1);
            if (Result.Length > 0)
                return Result[0];
            return default(T);
            }
        /// <summary>
        /// Returns the first item in the source List[T] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this List<T> In, Func<T, Boolean> Func)
            {
            List<T> Result = In.First(Func, 1);
            if (Result.Count() > 0)
                return Result[0];
            return default(T);
            }
        /// <summary>
        /// Returns the first item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T First<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
            {
            return In.List().First(Func);
            }
        /// <summary>
        /// Returns a new T[] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static T[] First<T>(this T[] In, Func<T, Boolean> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");
            int StartCount = Count;
            T[] Out = new T[StartCount];

            In.WhileI((i, o) =>
            {
                Boolean Result = Func(o);
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
        public static List<T> First<T>(this IEnumerable In, Func<T, Boolean> Func, int Count)
            {
            return In.List<T>().First(Func, Count);
            }
        /// <summary>
        /// Returns a new List[T] containing the first [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> First<T>(this List<T> In, Func<T, Boolean> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");

            List<T> Out = NewList<List<T>, T>();

            In.While((o) =>
            {
                Boolean Result = Func(o);
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
        public static List<T> First<T>(this IEnumerable<T> In, Func<T, Boolean> Func, int Count)
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
            U[] Result = In.First<T, U>(Func, 1);
            if (Result.Length > 0)
                return Result[0];
            return default(U);
            }
        /// <summary>
        /// Returns the first item in the source List[T] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static U First<T, U>(this List<T> In, Func<T, U> Func)
            {
            List<U> Result = In.First<T, U>(Func, 1);
            if (Result.Count() > 0)
                return Result[0];
            return default(U);
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

            In.While((o) =>
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
            return In.Last(L.True.Arg<T, Boolean>(), Count);
            }
        /// <summary>
        /// Returns the last item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T Last<T>(this List<T> In)
            {
            List<T> Result = In.Last(L.True.Arg<T, Boolean>(), 1);
            if (Result.Count() > 0)
                return Result[0];
            return default(T);
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items in the source List[T].
        /// </summary>
        public static List<T> Last<T>(this List<T> In, int Count)
            {
            return In.Last(L.True.Arg<T, Boolean>(), Count);
            }
        /// <summary>
        /// Returns the Last item in the List[T].
        /// Returns null if the array is empty.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> In)
            {
            int Count = In.Count();
            return L.F(() => { return In.GetAt(Count - 1); }).Try()();
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
            return In.Last(L.True.Arg<T, Boolean>());
            }
        /// <summary>
        /// Returns a new List[T] containing the Last [Count] items in the source collection that are of type T.
        /// </summary>
        public static List<T> Last<T>(this IEnumerable In, int Count)
            {
            return In.List<T>().Last(Count);
            }
        #endregion
        #region Last Object
        /// <summary>
        /// Returns the last T in the source T[] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this T[] In, T Obj)
            {
            return In.Last<T>(Obj.If());
            }
        /// <summary>
        /// Returns the last T in the source List[T] that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this List<T> In, T Obj)
            {
            return In.Last<T>(Obj.If());
            }
        /// <summary>
        /// Returns the last T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> In, T Obj)
            {
            return In.Last<T>(Obj.If());
            }
        /// <summary>
        /// Returns the last T in the source collection that is equivalent to Obj.
        /// Otherwise, returns null.
        /// </summary>
        public static T Last<T>(this IEnumerable In, T Obj)
            {
            return In.Last<T>(Obj.If());
            }
        #endregion
        #region Last Func
        /// <summary>
        /// Returns the last item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this IEnumerable In, Func<T, Boolean> Func)
            {
            return In.List<T>().Last(Func);
            }
        /// <summary>
        /// Returns the last item in the source T[] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this T[] In, Func<T, Boolean> Func)
            {
            T[] Result = In.Last<T>(Func, 1);
            if (Result.Length > 0)
                return Result[0];
            return default(T);
            }
        /// <summary>
        /// Returns the last item in the source List[T] that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this List<T> In, Func<T, Boolean> Func)
            {
            List<T> Result = In.Last(Func, 1);
            if (Result.Count() > 0)
                return Result[0];
            return default(T);
            }
        /// <summary>
        /// Returns the last item in the source collection that evokes a true result from the passed Func[T,Boolean].
        /// Returns null otherwise.
        /// </summary>
        public static T Last<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
            {
            return In.List().Last(Func);
            }
        /// <summary>
        /// Returns a new T[] containing the last [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static T[] Last<T>(this T[] In, Func<T, Boolean> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");
            int StartCount = Count;
            T[] Out = new T[StartCount];

            (In.Length - 1).To(0, (i) =>
            {
                T o = In[i];
                Boolean Result = Func(o);
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
        public static List<T> Last<T>(this IEnumerable In, Func<T, Boolean> Func, int Count)
            {
            return In.List<T>().Last(Func, Count);
            }
        /// <summary>
        /// Returns a new List[T] containing the last [Count] items that evoke a true result from the passed Func[T,Boolean].
        /// </summary>
        public static List<T> Last<T>(this List<T> In, Func<T, Boolean> Func, int Count)
            {
            if (Count <= 0)
                throw new ArgumentException("Count");

            List<T> Out = NewList<List<T>, T>();

            (In.Count - 1).To(0, (i) =>
            {
                T o = In[i];
                Boolean Result = Func(o);
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
        public static List<T> Last<T>(this IEnumerable<T> In, Func<T, Boolean> Func, int Count)
            {
            return In.List().Last(Func, Count);
            }
        #endregion
        #region Get At
        /// <summary>
        /// Returns the item at the specified index.
        /// </summary>
        public static Object GetAt(this IEnumerable In, int Index)
            {
            if (In == null)
                return null;

            if (In is IList)
                {
                return ((IList)In)[Index];
                }
            else if (In is Array)
                {
                return (In as Array).GetValue(Index);
                }
            else if (In is String)
                {
                return (In as String)[Index];
                }
            else
                throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Returns the item at the specified index.
        /// </summary>
        public static T GetAt<T>(this IEnumerable<T> In, int Index)
            {
            if (In == null)
                return default(T);

            if (In is IList<T>)
                {
                return ((IList<T>)In)[Index];
                }
            else if (In is Array)
                {
                return (T)(In as Array).GetValue(Index);
                }
            else
                throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Returns a new T[] containing the items at the specified indexes.
        /// </summary>
        public static T[] GetAt<T>(this T[] In, params int[] Indexes)
            {
            return In.SelectI<T>((i, o) => { return Indexes.Contains(i); });
            }
        /// <summary>
        /// Returns a new List[Object] containing the items at the specified indexes.
        /// </summary>
        public static List<Object> GetAt(this IEnumerable In, params int[] Indexes)
            {
            return In.List().GetAt(Indexes);
            }
        /// <summary>
        /// Returns a new List[T] containing the items at the specified indexes.
        /// </summary>
        public static List<T> GetAt<T>(this List<T> In, params int[] Indexes)
            {
            return In.SelectI<T>((i, o) => { return Indexes.Contains(i); });
            }
        /// <summary>
        /// Returns a new List[T] containing the items at the specified indexes.
        /// </summary>
        public static List<T> GetAt<T>(this IEnumerable<T> In, params int[] Indexes)
            {
            return In.SelectI<T>((i, o) => { return Indexes.Contains(i); });
            }
        #endregion
        #region Set At
        /// <summary>
        /// Sets the item in the colection at [Index] to [Value].
        /// </summary>
        public static void SetAt(this IEnumerable In, int Index, Object Value)
            {
            if (In == null)
                return;

            if (In is IList)
                {
                ((IList)In)[Index] = Value;
                }
            else if (In is Array)
                {
                (In as Array).SetValue(Value, Index);
                }
            else
                throw new Exception(In.GetType().FullName);
            }
        /// <summary>
        /// Sets the item in the colection at [Index] to [Value].
        /// </summary>
        public static void SetAt<T>(this IEnumerable<T> In, int Index, T Value)
            {
            if (In == null)
                return;

            if (In is IList<T>)
                {
                ((IList<T>)In)[Index] = Value;
                }
            else if (In is Array)
                {
                (In as Array).SetValue(Value, Index);
                }
            else
                throw new Exception(typeof(T).FullName);
            }
        #endregion
        #region Sort
        /// <summary>
        /// Sorts the collection using the default comparer which works for all types that support IComparable.
        /// </summary>
        /// <param name="In"></param>
        public static void Sort(this IList In)
            {
            NSort.QuickSorter Sorter = new NSort.QuickSorter(new ComparableComparer(), new NSort.DefaultSwap());
            Sorter.Sort(In);
            }
        /// <summary>
        /// Sorts the collection using the results of the passed Comparer Func[T,T,int].
        /// The Func should return positive if the first item is greater, negative if the second item is greater, and 0 if they are equal.
        /// </summary>
        public static void Sort<T>(this IList In, Func<T, T, int> Comparer)
            {
            NSort.QuickSorter Sorter = new NSort.QuickSorter(new CustomComparer<T>(Comparer), new NSort.DefaultSwap());
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
            NSort.QuickSorter Sorter = new NSort.QuickSorter(new CustomComparer<T>(FieldRetriever), new NSort.DefaultSwap());
            Sorter.Sort(In);
            }
        #endregion
        #region New List
        /// <summary>
        /// Creates a new list of the specified type.
        /// Types supported: U[], List[T], String
        /// </summary>
        public static T NewList<T, U>()
            {
            Object Out;
            if (typeof(T).IsArray)
                {
                Out = new U[] { };
                }
            else if (typeof(T).TypeEquals(typeof(List<U>)))
                {
                Out = new List<U>();
                }
            else if (typeof(T).TypeEquals(typeof(String)))
                {
                Out = "";
                }
            else
                throw new Exception(typeof(T).FullName);

            return (T)Out;
            }
        #endregion
        #region Remove Duplicates
        /// <summary>
        /// Returns a new List[T] with duplicates removed (items with equivalent values).
        /// </summary>
        public static List<T> RemoveDuplicates<T>(this List<T> In)
            {
            List<T> Out = new List<T>();
            In.Each(L.List_AddUnlessContains.Supply(Out));
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
        public static List<Object> RemoveDuplicates(this IEnumerable In)
            {
            return In.List().RemoveDuplicates();
            }
        #endregion
        #region Filter
        /// <summary>
        /// Returns a new List[T] from the supplied collection. 
        /// Values that are null or are not of type T are not included.
        /// </summary>
        public static List<T> Filter<T>(this IEnumerable In)
            {
            List<T> Out = new List<T>();
            In.Each((o) =>
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
            return In.Convert<T, U>(L.As<U>().Cast<Object, U, T, U>());
            }
        #endregion
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
            T[] Out = new T[] { };
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
        public static List<Object> Shuffle(this IEnumerable In)
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

        #region ToList
        /// <summary>
        /// Returns a new List[Object] from the supplied collection.
        /// </summary>
        public static List<Object> List(this IEnumerable In)
            {
            List<Object> Out = new List<Object>();
            foreach (Object o in In)
                Out.Add(o);
            return Out;
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
        #region CollectStr
        /// <summary>
        /// Iterates through a String, applying an action to each char.
        /// </summary>
        public static String Collect(this String In, Func<char, char> Func)
            {
            return new String(In.ToArray().Collect<char>(Func));
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func[int,T,String].
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        public static String CollectStr<T>(this List<T> In, Func<int, T, String> Func)
            {
            return In.CollectStr<T, List<T>>(Func);
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func[int,T,String].
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        public static String CollectStr<T>(this T[] In, Func<int, T, String> Func)
            {
            return In.CollectStr<T, T[]>(Func);
            }
        /// <summary>
        /// Iterates through a collection, collecting the results of the passed Func[int,T,String].
        /// The int passed is the index of the current item.
        /// Returns a string concatenation of the results of the Func.
        /// </summary>
        public static String CollectStr<T, U>(this U In, Func<int, T, String> Func) where U : IEnumerable<T>
            {
            String Out = "";
            In.EachI<T>((i, o) => { Out += Func(i, o) ?? ""; });
            return Out;
            }
        #endregion
        #region AddString
        /// <summary>
        /// Adds a series of chars to the supplied string and returns it.
        /// </summary>
        public static String Add(this String In, params char[] Chars)
            {
            return In.Add((IEnumerable<char>)Chars);
            }
        /// <summary>
        /// Adds a collection of chars to the supplied string and returns it.
        /// </summary>
        public static String Add(this String In, IEnumerable<char> Chars)
            {
            In = In ?? "";
            Chars = Chars ?? new Char[] { };

            String Objs2;
            if (Chars.GetType().TypeEquals(typeof(String)))
                {
                Objs2 = (String)Chars;
                }
            else
                {
                Objs2 = new String(Chars.ToArray());
                }
            return (String)(In + Objs2);
            }
        #endregion

        #region ToArray
        public static Object[] Array(this IEnumerable In)
            {
            Object[] Out = new Object[In.Count()];
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
        public static U[] Array<T, U>(this T[] In) where U : class,T
            {
            return In.Filter<T, U>();
            }
        #endregion

        #region Index
        public static Dictionary<U, Object> Index<U>(this IEnumerable In, Func<Object, U> Indexer)
            {
            return In.List().Index(Indexer);
            }
        public static Dictionary<U, T> Index<T, U>(this IEnumerable<T> In, Func<T, U> Indexer)
            {
            Dictionary<U, T> Out = new Dictionary<U, T>();
            In.Each((o) =>
            {
                U Index = Indexer(o);

                if (!Out.ContainsKey(Index))
                    Out.Add(Index, o);
            });
            return Out;
            }
        public static Dictionary<U, Dictionary<V, Object>> Index<U, V>(this IEnumerable In, Func<Object, U> Indexer1, Func<Object, V> Indexer2)
            {
            return In.List().Index(Indexer1, Indexer2);
            }
        public static Dictionary<U, Dictionary<V, T>> Index<T, U, V>(this IEnumerable<T> In, Func<T, U> Indexer1, Func<T, V> Indexer2)
            {
            Dictionary<U, List<T>> First = In.Group(Indexer1);
            Dictionary<U, Dictionary<V, T>> Out = new Dictionary<U, Dictionary<V, T>>();
            First.Each((kv) =>
            {
                Dictionary<V, T> Dict2 = kv.Value.Index(Indexer2);
                Out.Add(kv.Key, Dict2);
            });
            return Out;
            }
        #endregion
        #region Group

        public static Dictionary<String, List<T>> Group<T>(this IEnumerable<T> In)
            where T : IGrouped
            {
            return In.Group<T, String>(o => (o.Group ?? ""));
            }
        
        public static Dictionary<U, List<Object>> Group<U>(this IEnumerable In, Func<Object, U> Indexer)
            {
            return In.List().Group(Indexer);
            }

        public static Dictionary<U, List<T>> Group<T, U>(this IEnumerable<T> In, Func<T, U> Indexer)
            {
            Dictionary<U, List<T>> Out = new Dictionary<U, List<T>>();
            In.Each((o) =>
            {
                U Index = Indexer(o);
                List<T> L = null;

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
            First.Each((kv) =>
            {
                Dictionary<V, List<T>> Dict2 = kv.Value.Group(Indexer2);
                Out.Add(kv.Key, Dict2);
            });
            return Out;
            }
        #endregion
        // Combines a list of items separating them with a string or char
        #region Combine - String
        public static String Combine(this IEnumerable<String> List)
            {
            return List.Combine("");
            }
        public static String Combine<T, U>(this T List, char SeparateChar)
            where T : IEnumerable<U>
            where U : IConvertible
            {
            return List.Convert<U, String>(L.IConvertible_ToString.Supply2(null).Cast<IConvertible, String, U, String>()).Combine(SeparateChar);
            }
        public static String Combine(this IEnumerable<String> List, char SeparateChar)
            {
            return List.Combine(SeparateChar.ToString());
            }
        public static String Combine<T, U>(this T List, String SeparateStr)
            where T : IEnumerable<U>
            where U : IConvertible
            {
            return List.Convert(L.IConvertible_ToString.Supply2(null).Cast<IConvertible, String, U, String>()).Combine(SeparateStr);
            }
        #endregion
        #region Find
        public static List<T> Find<T>(this IEnumerable<T> In, IEnumerable Obj)
            {
            return In.List().Select<T>((o) => { return Obj.Has(o); });
            }
        public static List<String> Find(this String In, IEnumerable<String> Obj)
            {
            return Obj.List().Select<String>(L.String_Contains.Supply(In));
            }
        #endregion


        #region Convert All
        public static List<Object> ConvertAll(this IEnumerable In, Func<Object, IEnumerable<Object>> Func)
            {
            In = In ?? new Object[] { };
            List<Object> Out = new List<Object>();
            foreach (Object o in In)
                {
                IEnumerable<Object> obj = Func(o);
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

        public static int IndexOf(this IEnumerable In, Func<Object, Boolean> Func)
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
        public static int IndexOf<T>(this IEnumerable<T> In, Func<T, Boolean> Func)
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

        public static void Swap<T>(this T[] In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception("Invalid index 1: " + Index1);
            if (!In.HasIndex(Index2))
                throw new Exception("Invalid index 2: " + Index2);

            T temp = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = temp;
            }
        public static void Swap(this IList In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception("Invalid index 1: " + Index1);
            if (!In.HasIndex(Index2))
                throw new Exception("Invalid index 2: " + Index2);

            Object temp = In[Index1];
            In[Index1] = In[Index2];
            In[Index2] = temp;
            }

        public static void Move<T>(this T[] In, int Index1, int Index2)
            {
            if (!In.HasIndex(Index1))
                throw new Exception("Invalid index 1: " + Index1);
            if (!In.HasIndex(Index2))
                throw new Exception("Invalid index 2: " + Index2);
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
                throw new Exception("Invalid index 1: " + Index1);
            if (!In.HasIndex(Index2))
                throw new Exception("Invalid index 2: " + Index2);

            Object temp = In[Index1];
            In.Insert(Index2, temp);
            }

        public static Boolean HasIndex(this IEnumerable In, int Index)
            {
            int Count = In.Count();

            return Index > 0 && Index < Count;
            }

        public static List<INamed> Named(this IEnumerable In, String Name)
            {
            return In.List<INamed>().Select((o) => { return o != null && o.Name == Name; });
            }

        public static T[] Named<T>(this T[] In, String Name)
            where T : INamed
            {
            return In.Select((o) => { return o != null && o.Name == Name; });
            }

        public static List<T> Named<T>(this List<T> In, String Name)
            where T : INamed
            {
            return In.Select((o) => { return o != null && o.Name == Name; });
            }

        public static IEnumerable<T> Named<T>(this IEnumerable<T> In, String Name)
            where T : INamed
            {
            return In.Where(o => o != null && o.Name == Name);
            }

        public static List<Object> Named(this IEnumerable In, String Name, Func<Object, String> Namer)
            {
            return In.List<Object>().Select((o) => { return o != null && Namer(o) == Name; });
            }
        public static List<T> Named<T>(this IEnumerable<T> In, String Name, Func<T, String> Namer)
            {
            return In.List<T>().Select((o) => { return o != null && Namer(o) == Name; });
            }
        public static T[] Named<T>(this T[] In, String Name, Func<T, String> Namer)
            {
            return In.Select((o) => { return o != null && Namer(o) == Name; });
            }
        public static List<T> Named<T>(this List<T> In, String Name, Func<T, String> Namer)
            {
            return In.Select((o) => { return o != null && Namer(o) == Name; });
            }

        public static Boolean Equivalent(this IEnumerable In, IEnumerable Compare)
            {
            if (In == null && Compare == null)
                return true;
            else if (In == null || Compare == null)
                return false;
            // Strings are IEnumerables too - we have to test for this just in case.
            else if (In is String && Compare is String)
                return (String)In == (String)Compare;

            int Count1 = In.Count();
            int Count2 = Compare.Count();

            if (Count1 != Count2)
                return false;

            return In.AllI((i, o) =>
            {
                return Compare.GetAt(i).SafeEquals(o);
            });
            }

        public static int TotalCount(this IEnumerable In)
            {
            IEnumerable Collection = In;
            if (In is IDictionary)
                {
                Collection = ((IDictionary)In).Values;
                }

            if (In is String)
                {
                return 1;
                }
            else
                {
                int Out = 0;

                Collection.Each((v) =>
                {
                    if (v is IEnumerable)
                        Out += ((IEnumerable)v).TotalCount();
                    else
                        Out++;
                });

                return Out;
                }
            }
        public static void While<T>(this Action<T> In, Func<Boolean> Condition, IEnumerable<T> Obj)
            {
            Obj.While<T>(In.Merge(Condition));
            }
        public static void Do<T>(this Action<T> In, IEnumerable<T> Obj)
            {
            In.Each(Obj);
            }
        public static void Each<T>(this Action<T> In, IEnumerable<T> Obj)
            {
            Obj.Each<T>(In);
            }
        public static void RemoveAt_Checked<T>(this List<T> List, int Index)
            {
            int Count = List.Count;
            List.RemoveAt(Index);
            int Count2 = List.Count;

            if (Count != Count2 + 1)
                {
                RemoveAt_Checked<T>(List, Index);
                }
            }
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
        public static void Cycle(this IEnumerable In, Func<Object, Boolean> Continue)
            {
            while (true)
                {
                Boolean KeepGoing = In.While(Continue);
                if (!KeepGoing)
                    break;
                }
            }
        public static void Cycle<T>(this IEnumerable<T> In, Func<T, Boolean> Continue)
            {
            while (true)
                {
                Boolean KeepGoing = In.While(Continue);
                if (!KeepGoing)
                    break;
                }
            }


        public static Dictionary<U, Object> Map<U>(this IEnumerable In, Func<Object, U> Mapper)
            {
            return In.List().Map(Mapper);
            }
        public static Dictionary<U, T> Map<T, U>(this IEnumerable<T> In, Func<T, U> Mapper)
            {
            Dictionary<U, T> Out = new Dictionary<U, T>();
            In.Each((o) =>
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

        public static class Test
            {
            #region Each
            private static List<Object> TestBox = new List<Object>();

            public const String ReceiveObjectI_Name = "ListExt.Test.ReceiveObjectI";
            public static Action<int, Object> ReceiveObjectI = (i, o) => { TestBox.Add(i); };

            public const String ReceiveObject_Name = "ListExt.Test.ReceiveObject";
            public static Action<Object> ReceiveObject = (o) => { TestBox.Add(o); };

            public const String ReceiveTI_Name = "ListExt.Test.ReceiveTI";
            public static Action<int, int> ReceiveTI = (i, o) => { TestBox.Add(i); };

            public const String ReceiveT_Name = "ListExt.Test.ReceiveT";
            public static Action<int> ReceiveT = (o) => { TestBox.Add(o); };

            public const String Fail_Name = "ListExt.Test.Fail";
            public static Action<Object> Fail = (o) => { throw new Exception(); };

            public const String FailOO_Name = "ListExt.Test.FailOO";
            public static Func<Object, Object> FailOO = (o) => { throw new Exception(); };

            public const String FailITFunc_Name = "ListExt.Test.FailITFunc";
            public static Func<int, int> FailITFunc = (o) => { throw new Exception(); };

            public const String FailIOOFunc_Name = "ListExt.Test.FailIOOFunc";
            public static Func<int, Object, Object> FailIOOFunc = (i, o) => { throw new Exception(); };

            public const String FailOI_Name = "ListExt.Test.FailOI";
            public static Action<int, Object> FailOI = (i, o) => { throw new Exception(); };

            public const String FailI_Name = "ListExt.Test.FailI";
            public static Action<int> FailI = (o) => { throw new Exception(); };

            public const String FailIT_Name = "ListExt.Test.FailIT";
            public static Action<int, int> FailIT = (i, o) => { throw new Exception(); };

            public const String FailITTFunc_Name = "ListExt.Test.FailITTFunc";
            public static Func<int, int, int> FailITTFunc = (i, o) => { throw new Exception(); };

            public const String HasReceivedObjectsButNoStrings_Name = "ListExt.Test.HasReceivedObjectsButNoStrings";
            public static Func<Boolean> HasReceivedObjectsButNoStrings = () =>
            {
                Boolean Out = TestBox.Count > 0 && !TestBox.Contains(L.IsA<String>());
                TestBox.Clear();
                return Out;
            };

            public const String HasReceivedObjects_Name = "ListExt.Test.HasReceivedObjects";
            public static Func<Boolean> HasReceivedObjects = () =>
            {
                Boolean Out = TestBox.Count > 0;
                TestBox.Clear();
                return Out;
            };

            public const String HasReceivedObjectsI_Name = "ListExt.Test.HasReceivedObjectsI";
            public static Func<Boolean> HasReceivedObjectsI = () =>
            {
                Boolean Out = TestBox.Count > 0 && TestBox.Equivalent(new List<Object>() { 0, 1, 2 });
                TestBox.Clear();
                return Out;
            };
            #endregion

            public const String IncrementInt_Name = "ListExt.Test.IncrementInt";
            public static Func<int, int> IncrementInt = L.Int_Increment;

            public const String IncrementObjectInt_Name = "ListExt.Test.IncrementObjectInt";
            public static Func<Object, Object> IncrementObjectInt = (o) => { return (Object)IncrementInt((int)o); };

            public const String PassI_Name = "ListExt.Test.PassI";
            public static Func<int, Object, Object> PassI = (i, o) => { return i; };

            public const String PassIII_Name = "ListExt.Test.PassIII";
            public static Func<int, int, int> PassIII = (i, i2) => { return i; };
            }
        }
    }