using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Implement an Attribute with this interface to apply a maximum and/or 
    /// minimum bound to the parameter at the specified index.
    /// </summary>
    public interface ITestSucceedsAttribute : ITopLevelAttribute, ITestParameters
        {
        /// <summary>
        /// Additional optional checks to perform when running the test.
        /// </summary>
        string[] AdditionalChecks { get; set; }
        }
    }