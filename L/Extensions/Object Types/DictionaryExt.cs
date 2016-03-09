using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace LCore
    {
    public partial class Logic
        {
        #region Base Lambdas
        #region IDictionary
        //public static Func<IDictionary, Object> IDictionary_GetItem = (i) => { return i.Item; };
        //public static Action<IDictionary, Object> IDictionary_SetItem = (i, o) => { i.Item = o; };
        public static Func<IDictionary, ICollection> IDictionary_GetKeys = (i) => { return i.Keys; };
        public static Func<IDictionary, ICollection> IDictionary_GetValues = (i) => { return i.Values; };
        public static Func<IDictionary, Boolean> IDictionary_GetIsReadOnly = (i) => { return i.IsReadOnly; };
        public static Func<IDictionary, Boolean> IDictionary_GetIsFixedSize = (i) => { return i.IsFixedSize; };
        public static Func<IDictionary, Object, Boolean> IDictionary_Contains = (i, key) => { return i.Contains(key); };
        public static Action<IDictionary, Object, Object> IDictionary_Add = (i, key, value) => { i.Add(key, value); };
        public static Action<IDictionary> IDictionary_Clear = (i) => { i.Clear(); };
        public static Func<IDictionary, IDictionaryEnumerator> IDictionary_GetEnumerator = (i) => { return i.GetEnumerator(); };
        public static Action<IDictionary, Object> IDictionary_Remove = (i, key) => { i.Remove(key); };
        #endregion
        #endregion

        }
    public static class DictionaryExt
        {
        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add)
            {
            In.Merge(Add, L.F<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>>());
            }
        public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> Conflict)
            {
            if (Add == null)
                return;
            Add.Each((o) =>
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
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> In, IDictionary<TKey, TValue> Add)
            {
            if (Add == null)
                return;
            Add.Keys.Each((o) => { In.SafeAdd(o, Add[o]); });
            }
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
        public static void SafeAdd<TKey, TValue>(this IDictionary<TKey, TValue> In, TKey Key, TValue Val)
            {
            if (In != null && !In.ContainsKey(Key))
                In.Add(Key, Val);
            }
        }

    /// <summary>
    /// The double dictionary indexes data using two keys. 
    /// </summary>
    /// <typeparam name="TKey">TKey is the Primary Key</typeparam>
    /// <typeparam name="TKey2">TKey2 is the Secondary Key</typeparam>
    /// <typeparam name="TValue">TValue is the Value</typeparam>
    public class Dictionary<TKey, TKey2, TValue> : Dictionary<TKey, Dictionary<TKey2, TValue>>
        {
        }
    }