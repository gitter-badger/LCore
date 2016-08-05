using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;
// ReSharper disable UnusedMember.Global

namespace LCore.Dynamic
    {
    /// <summary>
    /// Internal class used to store multiple Attribute objects.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AttributeList : ICustomAttributeProvider
        {
        /// <summary>
        /// The name of the type this AttributeList is representing
        /// </summary>
        public string TypeName { get; set; }

        private readonly Attribute[] _Attributes;

        /// <summary>
        /// Creates a new AttributeList from a 
        /// </summary>
        /// <param name="TypeName"></param>
        /// <param name="Attributes"></param>
        public AttributeList(string TypeName, [CanBeNull] IEnumerable<Attribute> Attributes)
            {
            if (Attributes == null)
                Attributes = new Attribute[] { };

            this.TypeName = TypeName;
            this._Attributes = Attributes.Array();
            }

        // ReSharper disable once CoVariantArrayConversion
        /// <summary>Returns an array of all of the custom attributes defined on this member, excluding named attributes, or an empty array if there are no custom attributes.</summary>
        /// <returns>An array of Objects representing custom attributes, or an empty array.</returns>
        /// <param name="Inherit">When true, look up the hierarchy chain for the inherited custom attribute. </param>
        public object[] GetCustomAttributes(bool Inherit) => this._Attributes;

        /// <summary>Returns an array of custom attributes defined on this member, identified by type, or an empty array if there are no custom attributes of that type.</summary>
        /// <returns>An array of Objects representing custom attributes, or an empty array.</returns>
        /// <param name="AttributeType">The type of the custom attributes. </param>
        /// <param name="Inherit">When true, look up the hierarchy chain for the inherited custom attribute. </param>
        public object[] GetCustomAttributes(Type AttributeType, bool Inherit)
            {
            return this._Attributes.Select(Attr => Attr.IsType(AttributeType)).Array<object>();
            }

        /// <summary>Indicates whether one or more instance of <paramref name="AttributeType" /> is defined on this member.</summary>
        /// <returns>true if the <paramref name="AttributeType" /> is defined on this member; false otherwise.</returns>
        /// <param name="AttributeType">The type of the custom attributes. </param>
        /// <param name="Inherit">When true, look up the hierarchy chain for the inherited custom attribute. </param>
        public bool IsDefined(Type AttributeType, bool Inherit)
            {
            return this._Attributes.Count(Attr => Attr.IsType(AttributeType)) > 0;
            }
        }
    }