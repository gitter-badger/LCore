using System;

namespace NSort
	{
	public class MatrixComparer : ComparableComparer
		{
		public new int Compare(IComparable x, IComparable y)
			{
			return base.Compare(x, y);
			}
		}
	}