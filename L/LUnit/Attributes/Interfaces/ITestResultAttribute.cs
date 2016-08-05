using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
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