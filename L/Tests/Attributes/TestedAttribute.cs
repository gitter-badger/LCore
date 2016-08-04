using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Tests
    {
    /// <summary>
    /// Indicate that unit tests have been completed for the method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestedAttribute : Attribute, ITestedAttribute
        {
        }
    }