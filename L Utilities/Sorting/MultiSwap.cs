using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace NSort
    {
    public class MultiSwap : ISwap
        {
        public IList[] Lists;

        public MultiSwap(params IList[] Lists)
            {
            this.Lists = Lists;
            }

        public virtual void Swap(IList List, int First, int Second)
            {
            if (First != Second)
                {
                foreach (var list in this.Lists)
                    {
                    var o = list[First];
                    var o2 = list[Second];
                    if (o is ICloneable)
                        o = ((ICloneable)o).Clone();
                    if (o2 is ICloneable)
                        o2 = ((ICloneable)o2).Clone();

                    list[First] = o2;
                    list[Second] = o;
                    }
                }
            }
        public virtual void Set(IList List, int First, int Second)
            {
            if (First != Second)
                {
                foreach (var list in this.Lists)
                    {
                    var o = list[Second];
                    if (o is ICloneable)
                        o = ((ICloneable)o).Clone();
                    list[First] = o;
                    }
                }
            }

        /// <exception cref="Exception"></exception>
        public virtual void Set(IList List, int i, object o)
            {
            throw new Exception();
            }

        public void Swap<T>(IList<T> array, int First, int Second)
            {
            if (First != Second)
                {
                foreach (var list in this.Lists)
                    {
                    var o = list[First];
                    var o2 = list[Second];
                    if (o is ICloneable)
                        o = ((ICloneable)o).Clone();
                    if (o2 is ICloneable)
                        o2 = ((ICloneable)o2).Clone();

                    list[First] = o2;
                    list[Second] = o;
                    }
                }
            }

        public void Set<T>(IList<T> array, int First, int Second)
            {
            if (First != Second)
                {
                foreach (var list in this.Lists)
                    {
                    var o = list[Second];
                    if (o is ICloneable)
                        o = ((ICloneable)o).Clone();
                    list[First] = o;
                    }
                }
            }

        /// <exception cref="Exception">Condition.</exception>
        public void Set<T>(IList<T> array, int left, T obj)
            {
            throw new Exception();
            }
        }
    }