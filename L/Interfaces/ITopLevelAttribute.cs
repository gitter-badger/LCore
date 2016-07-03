using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Tag an Attribute with the ITopLevelAttribute interface and 
    /// L will, by default, only scan top level classes for your attribute type.
    /// Used within *.GetAttribute, *.GetAttributes, and *.HasAttribute.
    /// </summary>
    public interface ITopLevelAttribute : IPersistAttribute
        {

        }
    }