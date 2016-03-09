using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class FieldDontCloneAttribute : Attribute, IDontClone
        {
        public FieldDontCloneAttribute()
            {
            }
        }
    }