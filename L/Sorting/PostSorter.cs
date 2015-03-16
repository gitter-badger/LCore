using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NSort;

namespace LCore
    {
    public class InternalSwapper : ISwap
        {
        public int[] SwapList;
        private DefaultSwap Swapper = new DefaultSwap();
        public InternalSwapper(int length)
            {
            SwapList = new int[length];

            for (int i = 0; i < SwapList.Length; i++)
                {
                SwapList[i] = i;
                }
            }

        public void Swap(IList array, int left, int right)
            {
            Swapper.Swap(array, left, right);
            Swapper.Swap(SwapList, left, right);
            }
        public void Set(IList array, int left, int right)
            {
            Swapper.Set(array, left, right);
            Swapper.Set(SwapList, left, right);
            }
        public void Set(IList array, int left, object obj)
            {
            Swapper.Set(array, left, obj);
            Swapper.Set(SwapList, left, obj);
            }

        }
    public class PostSorter : ISorter
        {
        private IComparer Comparer;
        public PostSorter(IComparer Comparer)
            {
            this.Comparer = Comparer;
            }
        public void Sort(IList SortList, IList[] SwapLists)
            {
            Object[] SortListClone = new Object[SortList.Count];
            SortList.CopyTo(SortListClone, 0);

            Object[][] clone = new Object[SwapLists.Length][];

            for (int i = 0; i < SwapLists.Length; i++)
                {
                clone[i] = new Object[SwapLists[i].Count];
                SwapLists[i].CopyTo(clone[i], 0);
                }

            InternalSwapper swap = new InternalSwapper(SortList.Count);
            ISorter Sorter = new QuickSorter(this.Comparer, swap);

            Sorter.Sort(SortListClone);

            for (int j = 0; j < SwapLists.Length; j++)
                {
                IList list = SwapLists[j];
                for (int i = 0; i < list.Count; i++)
                    {
                    list[i] = clone[j][i];
                    }
                }

            }

        void ISorter.Sort(IList list)
            {
            this.Sort(list, new IList[] { list });
            }
        }
    }