using LMVC.Models;
using System;
using LCore.Extensions;

namespace LMVC.Annotations
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
