using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace LCore
    {
    /// <summary>
    /// Summary description for Comparers
    /// </summary>
    public class CustomComparer<T> : IComparer<T>, IComparer
        {
        public int Compare(Object x, Object y)
            {
            return this.Compare((T)x, (T)y);
            }
        public int Compare(T x, T y)
            {
            if (Comparer != null)
                {
                if (x == null)
                    {
                    if (y == null)
                        {
                        return 0;
                        }
                    return -(Comparer.Invoke(y, x));
                    }
                return Comparer.Invoke(x, y);
                }
            else if (FieldRetriever != null)
                {
                if (x == null)
                    {
                    if (y == null)
                        {
                        return 0;
                        }
                    return -(FieldRetriever(y).CompareTo(null));
                    }
                return FieldRetriever(x).CompareTo(FieldRetriever(y));
                }
            else
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