using System;
using System.Collections.Generic;
using System.Collections;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
using LCore.Interfaces;
using LCore.LUnit;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for the Dictionary class.
    /// </summary>
    [ExtensionProvider]
    public static class DictionaryExt
        {
        #region Extensions +

        #region Flip
        /// <summary>
        /// Flips the Keys and Values in a Dictionary.
        /// If duplicate Values are found in the source Dictionary, only the first will 
        /// be included in the result.
        /// </summary>
        public static Dictionary<TValue, TKey> Flip<TKey, TValue>([CanBeNull]this Dictionary<TKey, TValue> In)
            {
            var Out = new Dictionary<TValue, TKey>();

            if (In != null)
                {
                foreach (KeyValuePair<TKey, TValue> ValueKey in In)
                    {
                    if (!Out.ContainsKey(ValueKey.Value))
                        Out.Add(ValueKey.Value, ValueKey.Key);
                    }
                }

            return Out;
            }
        #endregion

        #region Merge

        /// <summary>
        /// Merges two dictionaries.
        /// If conflicts occur, they are passed to <paramref name="Conflict" />.
        /// <paramref name="Conflict" /> is responsible for returning a KeyValuePair with a new name to try.
        /// To leave an item out, return a KeyValuePair with a null key.
        /// </summary>

        [Tested]
        public static void Merge<TKey, TValue>([CanBeNull]this IDictionary<TKey, TValue> In, [CanBeNull]IDictionary<TKey, TValue> Add,
            [CanBeNull]Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> Conflict = null)
            {
            Conflict = Conflict ?? (o => new KeyValuePair<TKey, TValue>(default(TKey), default(TValue)));
            In = In ?? new Dictionary<TKey, TValue>();

            Add?.Each(o =>
                {
                    var Last = default(TKey);

                    while (!o.IsNull() && o.Key != null && In.ContainsKey(o.Key) && o.Key?.Equals(Last) != true)
                        {
                        Last = o.Key;
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
        /// If keys from <paramref name="Add" /> already exist in <paramref name="In" />, they will not be added
        /// </summary>
        [Tested]
        public static void AddRange<TKey, TValue>([CanBeNull]this IDictionary<TKey, TValue> In, [CanBeNull]IDictionary<TKey, TValue> Add)
            {
            Add?.Keys.Each(o => { In.SafeAdd(o, Add[o]); });
            }

        #endregion

        #region GetAllValues

        /// <summary>
        /// Returns all values from a dictionary with IEnumerable values.
        /// </summary>
        [Tested]
        public static List<TValue> GetAllValues<TKey, TValue, TValueList>([CanBeNull]this Dictionary<TKey, TValueList> In)
            where TValueList : IEnumerable<TValue>
            {
            var Out = new List<TValue>();

            if (In != null)
                {
                foreach (var Value in In.Values)
                    {
                    Out.AddRange(Value);
                    }
                }

            return Out;
            }

        #endregion

        #region SafeAdd

        /// <summary>
        /// Safely adds an item to a dictionary.
        /// If the dictionary is null or the item exists already, nothing is added.
        /// </summary>
        [Tested]
        public static void SafeAdd<TKey, TValue>([CanBeNull]this IDictionary<TKey, TValue> In, [CanBeNull]TKey Key, [CanBeNull]TValue Val)
            {
            if (In != null)
                {
                lock (In)
                    {
                    if (Key != null && !In.ContainsKey(Key))
                        In.Add(Key, Val);
                    }
                }
            }

        #endregion

        #region SafeSet

        /// <summary>
        /// Safely sets a value for a dictionary item.
        /// If the item doesn't exist it is added.
        /// If it does exist it gets updated.
        /// </summary>
        [Tested]
        public static void SafeSet<TKey, TValue>([CanBeNull]this IDictionary<TKey, TValue> In, [CanBeNull]TKey Key, [CanBeNull]TValue Val)
            {
            if (In != null && Key != null)
                {
                lock (In)
                    {
                    if (!In.ContainsKey(Key))
                        In.Add(Key, Val);
                    else
                        In[Key] = Val;
                    }
                }
            }

        #endregion

        #region SafeGet

        /// <summary>
        /// Safely gets an item from a dictionary if it exists.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static TValue SafeGet<TKey, TValue>([CanBeNull]this IDictionary<TKey, TValue> In, [CanBeNull]TKey Key)
            {
            if (In != null)
                {
                lock (In)
                    {
                    if (In.ContainsKey(Key))
                        {
                        return In[Key];
                        }
                    }
                }

            return default(TValue);
            }

        #endregion

        #region SafeRemove

        /// <summary>
        /// Safely removes an item from a dictionary if it exists.
        /// </summary>
        public static void SafeRemove<TKey, TValue>([CanBeNull]this Dictionary<TKey, TValue> Dictionary, [CanBeNull]TKey Key)
            {
            if (!Equals(Key, default(TKey)) && Dictionary != null)
                {
                lock (Dictionary)
                    {
                    if (Dictionary.ContainsKey(Key))
                        Dictionary.Remove(Key);
                    }
                }
            }

        #endregion

        #endregion

        #region ToDictionary
        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TValue>> In)
            {
            var Out = new Dictionary<TKey, List<TValue>>();

            In.Each(Tuple =>
                {
                    if (!Out.ContainsKey(Tuple.Item1))
                        Out.Add(Tuple.Item1, new List<TValue>());

                    Out[Tuple.Item1].Add(Tuple.Item2);
                });

            return Out;
            }

        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, Dictionary<TKey2, List<TValue>>> ToDictionary<TKey, TKey2, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TKey2, TValue>> In)
            {
            var Out = new Dictionary<TKey, Dictionary<TKey2, List<TValue>>>();

            In.Each(Tuple =>
            {
                if (!Out.ContainsKey(Tuple.Item1))
                    Out.Add(Tuple.Item1, new Dictionary<TKey2, List<TValue>>());

                Dictionary<TKey2, List<TValue>> Level1 = Out[Tuple.Item1];

                if (!Level1.ContainsKey(Tuple.Item2))
                    Level1.Add(Tuple.Item2, new List<TValue>());

                List<TValue> Level2 = Level1[Tuple.Item2];
                Level2.Add(Tuple.Item3);
            });

            return Out;
            }

        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, List<TValue>>>> ToDictionary<TKey, TKey2, TKey3, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TKey2, TKey3, TValue>> In)
            {
            var Out = new Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, List<TValue>>>>();

            In.Each(Tuple =>
            {
                if (!Out.ContainsKey(Tuple.Item1))
                    Out.Add(Tuple.Item1, new Dictionary<TKey2, Dictionary<TKey3, List<TValue>>>());

                Dictionary<TKey2, Dictionary<TKey3, List<TValue>>> Level1 = Out[Tuple.Item1];

                if (!Level1.ContainsKey(Tuple.Item2))
                    Level1.Add(Tuple.Item2, new Dictionary<TKey3, List<TValue>>());

                Dictionary<TKey3, List<TValue>> Level2 = Level1[Tuple.Item2];

                if (!Level2.ContainsKey(Tuple.Item3))
                    Level2.Add(Tuple.Item3, new List<TValue>());

                List<TValue> Level3 = Level2[Tuple.Item3];

                Level3.Add(Tuple.Item4);
            });

            return Out;
            }

        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, List<TValue>>>>> ToDictionary<TKey, TKey2, TKey3, TKey4, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TKey2, TKey3, TKey4, TValue>> In)
            {
            var Out = new Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, List<TValue>>>>>();

            In.Each(Tuple =>
                {
                    if (!Out.ContainsKey(Tuple.Item1))
                        Out.Add(Tuple.Item1, new Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, List<TValue>>>>());

                    Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, List<TValue>>>> Level1 = Out[Tuple.Item1];

                    if (!Level1.ContainsKey(Tuple.Item2))
                        Level1.Add(Tuple.Item2, new Dictionary<TKey3, Dictionary<TKey4, List<TValue>>>());

                    Dictionary<TKey3, Dictionary<TKey4, List<TValue>>> Level2 = Level1[Tuple.Item2];

                    if (!Level2.ContainsKey(Tuple.Item3))
                        Level2.Add(Tuple.Item3, new Dictionary<TKey4, List<TValue>>());

                    Dictionary<TKey4, List<TValue>> Level3 = Level2[Tuple.Item3];

                    if (!Level3.ContainsKey(Tuple.Item4))
                        Level3.Add(Tuple.Item4, new List<TValue>());

                    List<TValue> Level4 = Level3[Tuple.Item4];

                    Level4.Add(Tuple.Item5);
                });

            return Out;
            }

        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>>>> ToDictionary<TKey, TKey2, TKey3, TKey4, TKey5, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TKey2, TKey3, TKey4, TKey5, TValue>> In)
            {
            var Out = new Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>>>>();

            In.Each(Tuple =>
            {
                if (!Out.ContainsKey(Tuple.Item1))
                    Out.Add(Tuple.Item1, new Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>>>());

                Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>>> Level1 = Out[Tuple.Item1];

                if (!Level1.ContainsKey(Tuple.Item2))
                    Level1.Add(Tuple.Item2, new Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>>());

                Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>> Level2 = Level1[Tuple.Item2];

                if (!Level2.ContainsKey(Tuple.Item3))
                    Level2.Add(Tuple.Item3, new Dictionary<TKey4, Dictionary<TKey5, List<TValue>>>());

                Dictionary<TKey4, Dictionary<TKey5, List<TValue>>> Level3 = Level2[Tuple.Item3];

                if (!Level3.ContainsKey(Tuple.Item4))
                    Level3.Add(Tuple.Item4, new Dictionary<TKey5, List<TValue>>());

                Dictionary<TKey5, List<TValue>> Level4 = Level3[Tuple.Item4];

                if (!Level4.ContainsKey(Tuple.Item5))
                    Level4.Add(Tuple.Item5, new List<TValue>());

                List<TValue> Level5 = Level4[Tuple.Item5];

                Level5.Add(Tuple.Item6);
            });

            return Out;
            }

        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>>>> ToDictionary<TKey, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>> In)
            {
            var Out = new Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>>>>();

            In.Each(Tuple =>
            {
                if (!Out.ContainsKey(Tuple.Item1))
                    Out.Add(Tuple.Item1, new Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>>>());

                Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>>> Level1 = Out[Tuple.Item1];

                if (!Level1.ContainsKey(Tuple.Item2))
                    Level1.Add(Tuple.Item2, new Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>>());

                Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>> Level2 = Level1[Tuple.Item2];

                if (!Level2.ContainsKey(Tuple.Item3))
                    Level2.Add(Tuple.Item3, new Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>>());

                Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>> Level3 = Level2[Tuple.Item3];

                if (!Level3.ContainsKey(Tuple.Item4))
                    Level3.Add(Tuple.Item4, new Dictionary<TKey5, Dictionary<TKey6, List<TValue>>>());

                Dictionary<TKey5, Dictionary<TKey6, List<TValue>>> Level4 = Level3[Tuple.Item4];

                if (!Level4.ContainsKey(Tuple.Item5))
                    Level4.Add(Tuple.Item5, new Dictionary<TKey6, List<TValue>>());

                Dictionary<TKey6, List<TValue>> Level5 = Level4[Tuple.Item5];

                if (!Level5.ContainsKey(Tuple.Item6))
                    Level5.Add(Tuple.Item6, new List<TValue>());

                List<TValue> Level6 = Level5[Tuple.Item6];

                Level6.Add(Tuple.Item7);
            });

            return Out;
            }

        /// <summary>
        /// Convert a generic Tuple to a dictionary lookup.
        /// Lookup is performed in the order of the Tuple items.
        /// </summary>
        public static Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>>>> ToDictionary<TKey, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>([CanBeNull]this IEnumerable<Tuple<TKey, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>> In)
            {
            var Out = new Dictionary<TKey, Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>>>>();

            In.Each(Tuple =>
            {
                if (!Out.ContainsKey(Tuple.Item1))
                    Out.Add(Tuple.Item1, new Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>>>());

                Dictionary<TKey2, Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>>> Level1 = Out[Tuple.Item1];

                if (!Level1.ContainsKey(Tuple.Item2))
                    Level1.Add(Tuple.Item2, new Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>>());

                Dictionary<TKey3, Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>> Level2 = Level1[Tuple.Item2];

                if (!Level2.ContainsKey(Tuple.Item3))
                    Level2.Add(Tuple.Item3, new Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>>());

                Dictionary<TKey4, Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>> Level3 = Level2[Tuple.Item3];

                if (!Level3.ContainsKey(Tuple.Item4))
                    Level3.Add(Tuple.Item4, new Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>>());

                Dictionary<TKey5, Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>> Level4 = Level3[Tuple.Item4];

                if (!Level4.ContainsKey(Tuple.Item5))
                    Level4.Add(Tuple.Item5, new Dictionary<TKey6, Dictionary<TKey7, List<TValue>>>());

                Dictionary<TKey6, Dictionary<TKey7, List<TValue>>> Level5 = Level4[Tuple.Item5];

                if (!Level5.ContainsKey(Tuple.Item6))
                    Level5.Add(Tuple.Item6, new Dictionary<TKey7, List<TValue>>());

                Dictionary<TKey7, List<TValue>> Level6 = Level5[Tuple.Item6];

                if (!Level6.ContainsKey(Tuple.Item7))
                    Level6.Add(Tuple.Item7, new List<TValue>());

                List<TValue> Level7 = Level6[Tuple.Item7];

                Level7.Add(Tuple.Rest);
            });

            return Out;
            }
        #endregion
        }
    }