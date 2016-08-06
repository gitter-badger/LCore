using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Implement this interface to specify an LUnit test attribute that contains method parameters.
    /// </summary>
    public interface ITestParameters: ILUnitAttribute
        {
        /// <summary>
        /// Parameters for the current test
        /// </summary>
        object[] Parameters { get; }
        }
    }