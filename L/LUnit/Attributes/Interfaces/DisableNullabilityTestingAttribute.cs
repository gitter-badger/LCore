using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.LUnit
    {
    /// <summary>
    /// Disables LUnit nullability testing for a method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DisableNullabilityTestingAttribute : Attribute, IDisableNullabilityTestingAttribute
        {
        
        }
    }