using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Describes the context of the member
    /// </summary>
    public enum MemberContext
        {
#pragma warning disable 1591
        Instance,
        Static,
        Constant
#pragma warning restore 1591
        }
    }