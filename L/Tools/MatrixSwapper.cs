using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace LCore
    {
    public class MatrixSwapper : NSort.ISwap
        {
        public String[,] Source;
        public Boolean Header;

        public MatrixSwapper(String[,] In, Boolean Header)
            {
            Source = In;
            this.Header = Header;
            }

        public void Swap(IList array, int left, int right)
            {
            if (Header && (left == 0 || right == 0))
                return;

            for (int i = 0; i < Source.GetLength(0); i++)
                {
                object temp = Source[i, left];
                Source[i, left] = Source[i, right];
                Source[i, right] = (string)temp;
                }

            object temp2 = array[left];
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