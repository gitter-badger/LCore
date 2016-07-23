using System;
using System.Collections.Generic;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace LCore.Tools
    {
    /// <summary>
    /// A simple container for two objects of any types.
    /// </summary>
    public class Set<T1, T2> : IEquatable<Set<T1, T2>>
        {
        public override bool Equals(object Obj)
            {
            if (ReferenceEquals(null, Obj))
                return false;
            if (ReferenceEquals(this, Obj))
                return true;
            if (!(Obj is Set<T1, T2>))
                return false;

            return this.Equals((Set<T1, T2>)Obj);
            }

        public override int GetHashCode()
            {
            unchecked
                {
                return (EqualityComparer<T1>.Default.GetHashCode(this.Obj1) * 397) ^ EqualityComparer<T2>.Default.GetHashCode(this.Obj2);
                }
            }

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

        /// <summary>
        /// Determines if both members of a set match another set of the same type.
        /// </summary>
        public bool Equals(Set<T1, T2> Other)
            {
            if (ReferenceEquals(null, Other)) return false;
            if (ReferenceEquals(this, Other)) return true;
            return EqualityComparer<T1>.Default.Equals(this.Obj1, Other.Obj1) && EqualityComparer<T2>.Default.Equals(this.Obj2, Other.Obj2);
            }
        }
    }