using System;
using System.Collections.Generic;

namespace LCore.Tools
    {
    /// <summary>
    /// A simple container for two objects of any types.
    /// </summary>
    public class Set<T1, T2>
        {
        /// <summary>
        /// Object 1
        /// </summary>
        public T1 Obj1 { get; set; }
        /// <summary>
        /// Object 3
        /// </summary>
        public T2 Obj2 { get; set; }

        /// <summary>
        /// Construct a set with <typeparamref name="T1" /> and <typeparamref name="T2" />
        /// </summary>
        public Set(T1 Obj1, T2 Obj2)
            {
            this.Obj1 = Obj1;
            this.Obj2 = Obj2;
            }
        }
    }