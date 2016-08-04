using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace LCore.Tests
    {
    /// <summary>
    /// Indicate that unit tests have been completed for the method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestedIndirectlyAttribute : TestedAttribute
        {
        }
    }