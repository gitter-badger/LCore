using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NSort;

namespace LCore
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
                foreach (IList list in Lists)
                    {
                    Object o = list[First];
                    Object o2 = ((Object)list[Second]);
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
                foreach (IList list in Lists)
                    {
                    Object o = list[Second];
                    if (o is ICloneable)
                        o = ((ICloneable)o).Clone();
                    list[First] = list[Second];
                    }
                }
            }
        public virtual void Set(IList List, int i, Object o)
            {
            throw new Exception();
            }
        }
    }