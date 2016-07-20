using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace NSort
    {
    /// <summary>
    /// Default swap class
    /// </summary>

    public class DefaultSwap : ISwap
        {
        public void Swap(IList array, int left, int right)
            {
            var Swap = array[left];
            array[left] = array[right];
            array[right] = Swap;
            }

        public void Set(IList array, int left, int right)
            {
            array[left] = array[right];
            }

        public void Set(IList array, int left, object obj)
            {
            array[left] = obj;
            }

        public void Swap<T>(IList<T> array, int left, int right)
            {
            var Swap = array[left];
            array[left] = array[right];
            array[right] = Swap;
            }

        public void Set<T>(IList<T> array, int left, int right)
            {
            array[left] = array[right];
            }

        public void Set<T>(IList<T> array, int left, T obj)
            {
            array[left] = obj;
            }
        }
    }
