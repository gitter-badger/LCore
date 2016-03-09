using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public interface IFieldLoadFromQueryStringAttribute
        {

        }

    public class FieldLoadFromQueryStringAttribute : Attribute, IFieldLoadFromQueryStringAttribute
        {
        public FieldLoadFromQueryStringAttribute()
            {
            }
        }
    }