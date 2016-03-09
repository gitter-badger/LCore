using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class FieldDefaultValueAttribute : Attribute
        {
        private Object _Value { get; set; }
        public virtual Object GetValue(IModel Model)
            {
            return _Value;
            }

        public FieldDefaultValueAttribute(Object Value)
            {
            _Value = Value;
            }
        }
    }
