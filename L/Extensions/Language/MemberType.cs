using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Describes the type of member
    /// </summary>
    public enum MemberType
        {
#pragma warning disable 1591
        Field,
        Property,
        Method,
        Class,
        Structure,
        Interface,
        Enum,
        Event
#pragma warning restore 1591
        }
    }