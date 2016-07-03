using System;
using System.Collections;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace NSort
    {
    public class InternalSwapper : ISwap
        {
        public int[] SwapList;
        private DefaultSwap Swapper = new DefaultSwap();
        public InternalSwapper(int length)
            {
            this.SwapList = new int[length];

            for (int i = 0; i < this.SwapList.Length; i++)
                {
                this.SwapList[i] = i;
                }
            }

        public void Swap(IList array, int left, int right)
            {
            this.Swapper.Swap(array, left, right);
            this.Swapper.Swap(this.SwapList, left, right);
            }
        public void Set(IList array, int left, int right)
            {
            this.Swapper.Set(array, left, right);
            this.Swapper.Set(this.SwapList, left, right);
            }
        public void Set(IList array, int left, object obj)
            {
            this.Swapper.Set(array, left, obj);
            this.Swapper.Set(this.SwapList, left, obj);
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
            var SortListClone = new object[SortList.Count];
            SortList.CopyTo(SortListClone, 0);

            var clone = new object[SwapLists.Length][];

            for (int i = 0; i < SwapLists.Length; i++)
                {
                clone[i] = new object[SwapLists[i].Count];
                SwapLists[i].CopyTo(clone[i], 0);
                }

            var swap = new InternalSwapper(SortList.Count);
            ISorter Sorter = new QuickSorter(this.Comparer, swap);

            Sorter.Sort(SortListClone);

            for (int j = 0; j < SwapLists.Length; j++)
                {
                var list = SwapLists[j];
                for (int i = 0; i < list.Count; i++)
                    {
                    list[i] = clone[j][i];
                    }
                }

            }

        void ISorter.Sort(IList list)
            {
            this.Sort(list, new[] { list });
            }
        }
    }