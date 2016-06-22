using Singularity.Models;
using System;

namespace Singularity.Annotations
    {
    public class FieldDefaultValueAttribute : Attribute
        {
        private object _Value { get; }
        public virtual object GetValue(IModel Model)
            {
            return this._Value;
            }

        public FieldDefaultValueAttribute(object Value)
            {
            this._Value = Value;
            }
        }
    }
