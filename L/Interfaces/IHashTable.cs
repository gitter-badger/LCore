using System.Collections.Generic;

namespace LCore.Interfaces
    {
    public interface IHashTable<TKey, TValue>
        {
        IList<TKey> Keys { get; }
        IList<TValue> Values { get; }
        TValue this[TKey key] { get; set; }
        }
    }