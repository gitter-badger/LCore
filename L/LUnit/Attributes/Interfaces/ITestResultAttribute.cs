using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Implement this interface to specify an LUnit test attribute based on the method's result.
    /// </summary>
    public interface ITestResultAttribute : ITestMethodGenericsAttribute, ITestParameters, ITopLevelAttribute
        {
        /// <summary>
        /// The expected result from the method.
        /// </summary>
        object ExpectedResult { get; }

        /// <summary>
        /// Fully qualified references to additional checks to perform.
        /// </summary>
        string[] AdditionalResultChecks { get; }
        }
    }