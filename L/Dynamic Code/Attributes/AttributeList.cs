using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using LCore.Extensions;

namespace LCore.Dynamic
    {
    internal class AttributeList : ICustomAttributeProvider
        {
        public string TypeName;
        private readonly Attribute[] _Attributes;

        public AttributeList(string TypeName, List<Attribute> Attributes)
            : this(TypeName, Attributes.ToArray())
            {
            }

        public AttributeList(string TypeName, Attribute[] Attributes)
            {
            this.TypeName = TypeName;
            this._Attributes = Attributes;
            }

        // ReSharper disable once CoVariantArrayConversion
        public object[] GetCustomAttributes(bool inherit) => this._Attributes;

        public object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
            return this._Attributes.Select(a => (object)a.IsType(attributeType)).ToArray();
            }

        public bool IsDefined(Type attributeType, bool inherit)
            {
            return this._Attributes.Count(a => a.IsType(attributeType)) > 0;
            }
        }
    }