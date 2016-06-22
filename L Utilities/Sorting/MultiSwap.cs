using System;
using System.Collections;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

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
                foreach (IList list in this.Lists)
                    {
                    object o = list[First];
                    object o2 = list[Second];
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
                foreach (IList list in this.Lists)
                    {
                    object o = list[Second];
                    if (o is ICloneable)
                        o = ((ICloneable)o).Clone();
                    list[First] = o;
                    }
                }
            }
        public virtual void Set(IList List, int i, object o)
            {
            throw new Exception();
            }
        }
    }