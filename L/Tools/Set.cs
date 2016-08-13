using System;
using System.Collections.Generic;
using JetBrains.Annotations;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

namespace LCore.Tools
    {
    /// <summary>
    /// A simple container for two objects of any types.
    /// </summary>
    public class Set<T1, T2> : IEquatable<Set<T1, T2>>
        {
        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="Obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals([CanBeNull] object Obj)
            {
            if (ReferenceEquals(objA: null, objB: Obj)) return false;
            if (ReferenceEquals(this, Obj)) return true;
            return Obj.GetType() == this.GetType() && this.Equals((Set<T1, T2>)Obj);
            }

        /// <summary>
        /// Returns whether <paramref name="Set1"/> is equal to <paramref name="Set2"/>
        /// </summary>
        public static bool operator ==([CanBeNull]Set<T1, T2> Set1, [CanBeNull]Set<T1, T2> Set2)
            {
            if (ReferenceEquals(Set1, objB: null) && !ReferenceEquals(Set2, objB: null))
                return false;
            if (!ReferenceEquals(Set1, objB: null) && ReferenceEquals(Set2, objB: null))
                return false;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (ReferenceEquals(Set1, objB: null) && ReferenceEquals(Set2, objB: null))
                return true;

            return Set1.Equals(Set2);
            }
        /// <summary>
        /// Returns whether <paramref name="Set1"/> is not equal to <paramref name="Set2"/>
        /// </summary>
        public static bool operator !=([CanBeNull]Set<T1, T2> Set1, [CanBeNull]Set<T1, T2> Set2)
            {
            return !(Set1 == Set2);
            }

        /// <summary>
        /// Implicitally convert a Set to a Tuple
        /// </summary>
        public static implicit operator Tuple<T1, T2>(Set<T1, T2> Set)
            {
            return new Tuple<T1, T2>(Set.Obj1, Set.Obj2);
            }

        /// <summary>
        /// Implicitally convert a Tuple to a Set
        /// </summary>
        public static implicit operator Set<T1, T2>(Tuple<T1, T2> Tuple)
            {
            return new Set<T1, T2>(Tuple.Item1, Tuple.Item2);
            }


        /// <summary>Serves as a hash function for a particular type. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
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
        public bool Equals([CanBeNull] Set<T1, T2> Other)
            {
            if (ReferenceEquals(objA: null, objB: Other)) return false;
            return ReferenceEquals(this, Other) || EqualityComparer<T2>.Default.Equals(this.Obj2, Other.Obj2);
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
            {
            return $"[{this.Obj1},{this.Obj2}]";
            }
        }
    }