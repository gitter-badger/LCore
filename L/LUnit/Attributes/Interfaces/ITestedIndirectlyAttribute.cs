using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Extend this attribute to mark members as Tested indirectly within LUnit
    /// </summary>
    public interface ITestedIndirectlyAttribute : ITestedAttribute {}
    }