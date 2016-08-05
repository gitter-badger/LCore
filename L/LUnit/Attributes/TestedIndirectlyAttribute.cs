using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.LUnit
    {
    /// <summary>
    /// Indicate that unit tests have been completed for the method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestedIndirectlyAttribute : Attribute, ITestedIndirectlyAttribute {}
    }