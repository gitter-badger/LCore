using System;
using LCore.Extensions;

// ReSharper disable UnusedMember.Global

namespace LCore.LUnit
    {
    /// <summary>
    /// Denotes that a particular test fails.
    /// Optionally specify the ExceptionType and 
    /// AdditionalChecks to be performed
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestFailsAttribute : Attribute, ITestFailsAttribute
        {
        /// <summary>
        /// The type of exception to filter.
        /// </summary>
        public Type ExceptionType { get; set; }

        /// <summary>
        /// Fully qualified references to additional checks to perform.
        /// </summary>
        public string[] AdditionalChecks { get; set; }

        /// <summary>
        /// Parameters for the current test
        /// </summary>
        public object[] Parameters { get; set; }

        /// <summary>
        /// Denotes that a particular test fails.
        /// Optionally specify the <paramref name="ExceptionType" /> and 
        /// <paramref name="AdditionalChecks" /> to be performed
        /// </summary>
        public TestFailsAttribute(object[] Parameters = null, Type ExceptionType = null, params string[] AdditionalChecks)
            {
            this.ExceptionType = ExceptionType ?? typeof(Exception);
            this.AdditionalChecks = AdditionalChecks;
            this.Parameters = Parameters;
            }
        }
    }