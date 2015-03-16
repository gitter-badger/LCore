using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using LCore;

namespace LCore
    {
    public class AttributeList : ICustomAttributeProvider
        {
        public String TypeName;
        private Attribute[] Attrs;
        public AttributeList(String TypeName, List<Attribute> Attrs)
            : this(TypeName, Attrs.ToArray())
            {
            }
        public AttributeList(String TypeName, Attribute[] Attrs)
            {
            this.TypeName = TypeName;
            this.Attrs = Attrs;
            }

        public object[] GetCustomAttributes(bool inherit)
            {
            return Attrs;
            }
        public object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
            return Attrs.Select((a) => { return a.IsType(attributeType); }).ToArray();
            }
        public bool IsDefined(Type attributeType, bool inherit)
            {
            return Attrs.Count((a) => { return a.IsType(attributeType); }) > 0;
            }
        }
    }