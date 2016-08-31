using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Describes the inheritance setting of a member
    /// </summary>
    public enum MemberInheritance
        {
#pragma warning disable 1591
        None,
        Sealed,
        Virtual,
        Abstract,
        Override
#pragma warning restore 1591
        }
    }