using System;
using System.Collections;

namespace NSort
{
	/// <summary>
	/// Default <see cref="IComparable"/> object comparer.
	/// </summary>
	
	public class ComparableComparer : IComparer
	{
		public int Compare(IComparable x, Object y)
		{
			return x.CompareTo(y);
		}

		#region IComparer Members
		int IComparer.Compare(Object x, Object y)
		{
			return this.Compare((IComparable)x,y);
		}

		#endregion
	}
}
