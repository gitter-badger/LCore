using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

// ReSharper disable InconsistentNaming


namespace NSort
    {
    public class ComparableComparer : IComparer<IComparable>, IComparer
        {
        public int Compare([CanBeNull]object x, [CanBeNull]object y)
            {
            return this.Compare((IComparable)x, (IComparable)y);
            }
        public int Compare([CanBeNull]IComparable x, [CanBeNull]IComparable y)
            {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (x == null)
                // ReSharper disable HeuristicUnreachableCode
                {
                if (y == null)
                    {
                    return 0;
                    }
                return -y.CompareTo(null);
                }
            // ReSharper restore HeuristicUnreachableCode
            return x.CompareTo(y);
            }
        }
    }