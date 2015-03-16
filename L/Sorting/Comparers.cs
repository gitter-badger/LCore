using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;


namespace LCore
    {
    public class ComparableComparer : IComparer<IComparable>, IComparer
        {
        public int Compare(Object x, Object y)
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
                return -(y.CompareTo(x));
                }
            return x.CompareTo(y);
            }
        }
    }