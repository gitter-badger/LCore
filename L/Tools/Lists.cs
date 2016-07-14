using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LCore.Tools
    {
    /// <summary>
    /// A class to maintain paired lists of two related objects.
    /// Useful when you are using two lists in unisen whose 
    /// lengths must match.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
	public class Lists<T1, T2>
        {
        private readonly List<T1> _List1;
        private readonly List<T2> _List2;

        /// <summary>
        /// Retrieve the contents of List1.
        /// </summary>
        public ReadOnlyCollection<T1> List1 => this._List1.AsReadOnly();

        /// <summary>
        /// Retrieve the contents of List2.
        /// </summary>
        public ReadOnlyCollection<T2> List2 => this._List2.AsReadOnly();


        /// <summary>
        /// Retrieve the Count of both lists.
        /// </summary>
        public int Count => this.List1.Count;

        /// <summary>
        /// Adds an object to each list.
        /// </summary>
        public void Add(T1 o1, T2 o2)
            {
            this._List1.Add(o1);
            this._List2.Add(o2);
            }

        /// <summary>
        /// Sets the values at index for both lists.
        /// </summary>
        public void Set(int Index, T1 Value, T2 Value2)
            {
            this.Set1(Index, Value);
            this.Set2(Index, Value2);
            }

        /// <summary>
        /// Sets the values at index for the first list.
        /// </summary>
        public void Set1(int Index, T1 Value)
            {
            this._List1[Index] = Value;
            }

        /// <summary>
        /// Sets the values at index for the second list.
        /// </summary>
        public void Set2(int Index, T2 Value)
            {
            this._List2[Index] = Value;
            }

        /// <summary>
        /// Returns the Set of values at the index.
        /// </summary>
        public Set<T1, T2> GetAt(int Index)
            {
            return new Set<T1, T2>(this._List1[Index], this._List2[Index]);
            }

        /// <summary>
        /// Removes values from both lists at <paramref name="Index" />.
        /// </summary>
        public void RemoveAt(int Index)
            {
            this._List1.RemoveAt(Index);
            this._List2.RemoveAt(Index);
            }

        /// <summary>
        /// Create a new Lists object.
        /// </summary>
        public Lists()
            : this(new List<T1>(), new List<T2>())
            {
            }

        /// <summary>
        /// Create a new lists object starting with two lists with the same Count.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="List1"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="List2"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">List counts did not match</exception>
        public Lists(List<T1> List1, List<T2> List2)
            {
            if (List1 == null)
                throw new ArgumentNullException(nameof(List1));
            if (List2 == null)
                throw new ArgumentNullException(nameof(List2));
            if (List1.Count != List2.Count)
                throw new ArgumentException("List counts did not match");

            this._List1 = List1;
            this._List2 = List2;
            }
        }
    }