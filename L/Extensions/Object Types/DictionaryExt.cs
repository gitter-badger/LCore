using System;
using System.Collections.Generic;
using System.Collections;

namespace LCore.Extensions
    {
    public static class DictionaryExt
        {
        #region Extensions
        /* TODO: L: Dictionary: Comment All Below */

        // TODO: L: Dictionary: Untested
        #region Merge
        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add)
            {
            In.Merge(Add, L.F<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>>());
            }
        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> Conflict)
            {
            Add?.Each(o =>
                {
                while (In.ContainsKey(o.Key))
                    {
                    o = Conflict(o);
                    }
                if (o.Key != null)
                    {
                    In.Add(o.Key, o.Value);
                    }
                });
            }
        #endregion
        // TODO: L: Dictionary: Untested
        #region AddRange
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add)
            {
            Add?.Keys.Each(o => { In.SafeAdd(o, Add[o]); });
            }
        #endregion
        // TODO: L: Dictionary: Untested
        #region SafeSet
        public static void SafeSet<TKey, TValue>(this IDictionary<TKey, TValue> In, TKey Key, TValue Val)
            {
            if (In != null)
                {
                if (!In.ContainsKey(Key))
                    In.Add(Key, Val);
                else
                    In[Key] = Val;
                }
            }
        #endregion
        // TODO: L: Dictionary: Untested
        #region SafeAdd
        public static void SafeAdd<TKey, TValue>(this IDictionary<TKey, TValue> In, TKey Key, TValue Val)
            {
            if (In != null && !In.ContainsKey(Key))
                In.Add(Key, Val);
            }
        #endregion

        #endregion
        }
    }