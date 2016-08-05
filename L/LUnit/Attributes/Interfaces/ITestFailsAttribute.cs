using System;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Interface denotes a test attribute. 
    /// Used to determine which methods are tested and untested.
    /// </summary>
    public interface ITestFailsAttribute : ITopLevelAttribute, ITestParameters
        {
        /// <summary>
        /// The type of exception to filter.
        /// </summary>
        Type ExceptionType { get; set; }

        /// <summary>
        /// Fully qualified references to additional checks to perform.
        /// </summary>
        string[] AdditionalChecks { get; set; }
        }
    }