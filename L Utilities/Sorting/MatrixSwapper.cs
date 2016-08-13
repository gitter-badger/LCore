using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace NSort
    {
    public class MatrixSwapper : ISwap
        {
        public string[,] Source;
        public bool Header;

        public MatrixSwapper(string[,] In, bool Header)
            {
            this.Source = In;
            this.Header = Header;
            }

        public void Swap(IList array, int left, int right)
            {
            if (this.Header && (left == 0 || right == 0))
                return;

            for (int Index = 0; Index < this.Source.GetLength(dimension: 0); Index++)
                {
                object Temp = this.Source[Index, left];
                this.Source[Index, left] = this.Source[Index, right];
                this.Source[Index, right] = (string)Temp;
                }

            var Temp2 = array[left];
            array[left] = array[right];
            array[right] = Temp2;
            }
        public void Set(IList array, int left, int right)
            {
            }
        public void Set(IList array, int left, object obj)
            {
            }

        public void Swap<T>(IList<T> array, int left, int right)
            {
            if (this.Header && (left == 0 || right == 0))
                return;

            for (int Index = 0; Index < this.Source.GetLength(dimension: 0); Index++)
                {
                object Temp = this.Source[Index, left];
                this.Source[Index, left] = this.Source[Index, right];
                this.Source[Index, right] = (string)Temp;
                }

            var Temp2 = array[left];
            array[left] = array[right];
            array[right] = Temp2;
            }

        public void Set<T>(IList<T> array, int left, int right)
            {
            }

        public void Set<T>(IList<T> array, int left, T obj)
            {
            }
        }
    }