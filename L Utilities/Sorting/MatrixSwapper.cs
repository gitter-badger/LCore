using System;
using System.Collections;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

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

            for (int i = 0; i < this.Source.GetLength(0); i++)
                {
                object temp = this.Source[i, left];
                this.Source[i, left] = this.Source[i, right];
                this.Source[i, right] = (string)temp;
                }

            var temp2 = array[left];
            array[left] = array[right];
            array[right] = temp2;
            }
        public void Set(IList array, int left, int right)
            {
            }
        public void Set(IList array, int left, object obj)
            {
            }
        }
    }