using System;
using System.Collections;

// ReSharper disable InconsistentNaming

namespace NSort
{
	/// <summary>
	/// http://www.codeproject.com/csharp/csquicksort.asp
	/// </summary>
	
	public class QuickSorter : SwapSorter
	{
		public QuickSorter()
		{}

		public QuickSorter(IComparer comparer, ISwap swapper)
			:base(comparer,swapper)
		{}

	    /// <summary>
	    /// Sorts the array.
	    /// </summary>
	    /// <param name="array">The array to sort.</param>
	    /// <exception cref="NullReferenceException">comparer is null</exception>
	    public override void Sort(IList array)
			{
		    this.Sort(array, 0, array.Count-1);
			}

	    /// <exception cref="NullReferenceException">comparer is null</exception>
	    public void Sort(IList array, int start)
			{
		    this.Sort(array, start, array.Count - 1);
			}

	    /// <exception cref="NullReferenceException">comparer is null</exception>
	    public void Sort(IList array, int lower, int upper)
		{
			// Check for non-base case
			if (lower < upper)
				{
				// Split and sort partitions
				int Split= this.Pivot(array, lower, upper);

				    this.Sort(array, lower, Split-1);
				    this.Sort(array, Split+1, upper);
			}
		}

		#region Internal

	    /// <exception cref="NullReferenceException">comparer is null</exception>
	    internal int Pivot(IList array, int lower, int upper)
		{
			// Pivot with first element
			int Left=lower+1;
			var Pivot=array[lower];
			int Right=upper;

			// Partition array elements
			while (Left <= Right)
			{
				// Find item out of place
				while ( (Left <= Right) && (this.Comparer.Compare(array[Left], Pivot) <= 0) )
				{
					++Left;
				}

				while ( (Left <= Right) && (this.Comparer.Compare(array[Right], Pivot) > 0) )
				{
					--Right;
				}

				// Swap values if necessary
				if (Left < Right)
				{
				    this.Swapper.Swap(array, Left, Right);
					++Left;
					--Right;
				}
			}

			// Move pivot element
		    this.Swapper.Swap(array, lower, Right);
			return Right;
		}
		#endregion
	}
}
