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
    public interface ITestBoundAttribute : ILUnitAttribute, ITopLevelAttribute
        {
        /// <summary>
        /// The 0-based index of the parameter you're applying a bound to.
        /// </summary>
        uint ParameterIndex { get; }

        /// <summary>
        /// The Minimum bound for this parameter (optional)
        /// </summary>
        object Minimum { get; }

        /// <summary>
        /// The Maximum bound for this parameter (optional)
        /// </summary>
        object Maximum { get; }

        /// <summary>
        /// The type of value used for the Minimum and Maximum
        /// </summary>
        Type ValueType { get; }
        }
    }