using System;
using System.Collections;
using System.Collections.Generic;

namespace NSort
    {
    /// <summary>
    /// Summary description for Comparers
    /// </summary>
    public class CustomComparer<T> : IComparer<T>, IComparer
        {
        public int Compare(object x, object y)
            {
            return this.Compare((T)x, (T)y);
            }
        public int Compare(T x, T y)
            {
            if (this.Comparer != null)
                {
                if (x == null)
                    {
                    if (y == null)
                        {
                        return 0;
                        }
                    return -this.Comparer.Invoke(y, default(T));
                    }
                return this.Comparer.Invoke(x, y);
                }
            if (this.FieldRetriever != null)
                {
                if (x == null)
                    {
                    if (y == null)
                        {
                        return 0;
                        }
                    return -this.FieldRetriever(y).CompareTo(null);
                    }
                return this.FieldRetriever(x).CompareTo(this.FieldRetriever(y));
                }
            throw new Exception("Could not compare");
            }

        protected Func<T, T, int> Comparer { get; set; }
        protected Func<T, IComparable> FieldRetriever { get; set; }

        public CustomComparer(Func<T, T, int> Comparer)
            {
            this.Comparer = Comparer;
            }
        public CustomComparer(Func<T, IComparable> FieldRetriever)
            {
            this.FieldRetriever = FieldRetriever;
            }
        }
    }