using System;
using System.Collections.Generic;
using System.Collections;
using LCore.Interfaces;
using LCore.Tests;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for the Dictionary class.
    /// </summary>
    [ExtensionProvider]
    public static class DictionaryExt
        {
        #region Extensions +

        #region Merge

        /// <summary>
        /// Merges two dictionaries.
        /// If conflicts occur, they are passed to [Conflict].
        /// [Conflict] is responsible for returning a KeyValuePair with a new name to try.
        /// To leave an item out, return a KeyValuePair with a null key.
        /// </summary>
        [Tested]
        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add,
            Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> Conflict = null)
            {
            Conflict = o => new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));

            Add?.Each(o =>
                {
                    var last = default(TKey);

                    while (In.ContainsKey(o.Key) && !o.Key.Equals(last))
                        {
                        last = o.Key;
                        o = Conflict(o);
                        }

                    if (o.Key != null)
                        {
                        In.SafeAdd(o.Key, o.Value);
                        }
                });
            }

        #endregion

        #region AddRange

        /// <summary>
        /// Safely adds one dictionary to another.
        /// If keys from [Add] already exist in [In], they will not be added
        /// </summary>
        [Tested]
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add)
            {
            Add?.Keys.Each(o => { In.SafeAdd(o, Add[o]); });
            }

        #endregion

        #region GetAllValues
        /// <summary>
        /// Returns all values from a dictionary with IEnumerable values.
        /// </summary>
        public static List<TValue> GetAllValues<TKey, TValue>(this Dictionary<TKey, IEnumerable<TValue>> In)
            {
            var Out = new List<TValue>();

            foreach (IEnumerable<TValue> Value in In.Values)
                {
                Out.Add(Value);
                }

            return Out;
            }

        #endregion

        #region SafeSet

        /// <summary>
        /// Safely sets a value for a dictionary item.
        /// If the item doesn't exist it is added.
        /// If it does exist it gets updated.
        /// </summary>
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

        #region SafeAdd

        /// <summary>
        /// Safely adds an item to a dictionary.
        /// If the dictionary is null or the item exists already, nothing is added.
        /// </summary>
        public static void SafeAdd<TKey, TValue>(this IDictionary<TKey, TValue> In, TKey Key, TValue Val)
            {
            if (In != null && !In.ContainsKey(Key))
                In.Add(Key, Val);
            }

        #endregion

        #region SafeGet

        /// <summary>
        /// Safely gets an item from a dictionary if it exists.
        /// </summary>
        public static TValue SafeGet<TKey, TValue>(this IDictionary<TKey, TValue> In, TKey Key)
            {
            if (In != null && In.ContainsKey(Key))
                return In[Key];

            return default(TValue);
            }

        #endregion

        #endregion
        }
    }