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
    public interface ITestSourceAttribute : ITopLevelAttribute, ITestParameters
        {
        /// <summary>
        /// The expected source value.
        /// </summary>
        object ExpectedSource { get; }

        /// <summary>
        /// Additional optional source checks to perform.
        /// </summary>
        string[] AdditionalSourceChecks { get; }
        }
    }