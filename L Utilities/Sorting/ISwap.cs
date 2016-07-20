using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace NSort
{
	/// <summary>
	/// Object swapper interface
	/// </summary>
	
	public interface ISwap
	{
		void Swap(IList array, int left, int right);
		void Set(IList array, int left, int right);
		void Set(IList array, int left, object obj);
        void Swap<T>(IList<T> array, int left, int right);
        void Set<T>(IList<T> array, int left, int right);
        void Set<T>(IList<T> array, int left, T obj);
        }
}
