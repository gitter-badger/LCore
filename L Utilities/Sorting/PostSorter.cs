using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming

namespace NSort
    {
    public class InternalSwapper : ISwap
        {
        public int[] SwapList;
        public List<int> SwapList2 = new List<int>();

        private DefaultSwap _Swapper = new DefaultSwap();

        public InternalSwapper(int length)
            {
            this.SwapList = new int[length];

            for (int Index = 0; Index < this.SwapList.Length; Index++)
                {
                this.SwapList[Index] = Index;
                }
            }

        public void Swap(IList array, int left, int right)
            {
            this._Swapper.Swap(array, left, right);
            this._Swapper.Swap((IList)this.SwapList, left, right);
            }
        public void Set(IList array, int left, int right)
            {
            this._Swapper.Set(array, left, right);
            this._Swapper.Set((IList)this.SwapList, left, right);
            }
        public void Set(IList array, int left, object obj)
            {
            this._Swapper.Set(array, left, obj);
            this._Swapper.Set(this.SwapList, left, obj);
            }

        public void Swap<T>(IList<T> array, int left, int right)
            {
            this._Swapper.Swap(array, left, right);
            this._Swapper.Swap((IList<T>)this.SwapList2, left, right);
            }

        public void Set<T>(IList<T> array, int left, int right)
            {
            this._Swapper.Set(array, left, right);
            this._Swapper.Set((IList<T>)this.SwapList2, left, right);
            }

        public void Set<T>(IList<T> array, int left, T obj)
            {
            this._Swapper.Set(array, left, obj);
            this._Swapper.Set((IList<T>)this.SwapList2, left, obj);
            }
        }
    public class PostSorter : ISorter
        {
        private IComparer _Comparer;
        public PostSorter(IComparer Comparer)
            {
            this._Comparer = Comparer;
            }
        public void Sort(IList SortList, IList[] SwapLists)
            {
            var SortListClone = new object[SortList.Count];
            SortList.CopyTo(SortListClone, 0);

            var Clone = new object[SwapLists.Length][];

            for (int Index = 0; Index < SwapLists.Length; Index++)
                {
                Clone[Index] = new object[SwapLists[Index].Count];
                SwapLists[Index].CopyTo(Clone[Index], 0);
                }

            var Swap = new InternalSwapper(SortList.Count);
            ISorter Sorter = new QuickSorter(this._Comparer, Swap);

            Sorter.Sort(SortListClone);

            for (int Index2 = 0; Index2 < SwapLists.Length; Index2++)
                {
                var List = SwapLists[Index2];
                for (int Index3 = 0; Index3 < List.Count; Index3++)
                    {
                    List[Index3] = Clone[Index2][Index3];
                    }
                }

            }

        void ISorter.Sort(IList list)
            {
            this.Sort(list, new[] { list });
            }
        }
    }