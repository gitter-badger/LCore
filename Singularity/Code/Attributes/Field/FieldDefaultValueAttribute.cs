using Singularity.Models;
using System;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public class FieldDefaultValueAttribute : Attribute, ISubClassPersistentAttribute
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
