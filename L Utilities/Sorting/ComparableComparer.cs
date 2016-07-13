using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming


namespace NSort
    {
    public class ComparableComparer : IComparer<IComparable>, IComparer
        {
        public int Compare(object x, object y)
            {
            return this.Compare((IComparable)x, (IComparable)y);
            }
        public int Compare(IComparable x, IComparable y)
            {
            if (x == null)
                {
                if (y == null)
                    {
                    return 0;
                    }
                return -y.CompareTo(null);
                }
            return x.CompareTo(y);
            }
        }
    }