using System.Collections.Generic;

namespace LCore.Tools
    {
    /// <summary>
    /// The double dictionary indexes data using two keys. 
    /// </summary>
    /// <typeparam name="TKey">TKey is the Primary Key</typeparam>
    /// <typeparam name="TKey2">TKey2 is the Secondary Key</typeparam>
    /// <typeparam name="TValue">TValue is the Value</typeparam>
    public class DoubleDictionary<TKey, TKey2, TValue> : Dictionary<TKey, Dictionary<TKey2, TValue>>
        {
        }
    }