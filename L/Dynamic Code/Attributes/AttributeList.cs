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
        private readonly Attribute[] Attrs;

        public AttributeList(string TypeName, List<Attribute> Attrs)
            : this(TypeName, Attrs.ToArray())
            {
            }

        public AttributeList(string TypeName, Attribute[] Attrs)
            {
            this.TypeName = TypeName;
            this.Attrs = Attrs;
            }

        // ReSharper disable once CoVariantArrayConversion
        public object[] GetCustomAttributes(bool inherit) => this.Attrs;

        public object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
            return this.Attrs.Select(a => (object)a.IsType(attributeType)).ToArray();
            }

        public bool IsDefined(Type attributeType, bool inherit)
            {
            return this.Attrs.Count(a => a.IsType(attributeType)) > 0;
            }
        }
    }