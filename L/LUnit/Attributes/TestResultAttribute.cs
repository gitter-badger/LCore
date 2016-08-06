using System;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Denotes that a method returns a specific result when passed a 
    /// certain set of input parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestResultAttribute : Attribute, ITestResultAttribute
        {
        /// <summary>
        /// Parameters for the current test
        /// </summary>
        public object[] Parameters { get; }

        /// <summary>
        /// The expected result from the method.
        /// </summary>
        public object ExpectedResult { get; }

        /// <summary>
        /// Fully qualified references to additional checks to perform.
        /// </summary>
        public string[] AdditionalResultChecks { get; }

        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        public Type[] GenericTypes{ get; set; }

        /// <summary>
        /// Denotes that a method returns a specific result when passed a 
        /// certain set of input parameters.
        /// </summary>
        public TestResultAttribute(object[] Parameters, object ExpectedResult, params string[] AdditionalResultChecks)
            {
            this.ExpectedResult = ExpectedResult;
            this.AdditionalResultChecks = AdditionalResultChecks;
            this.Parameters = Parameters;
            }
        }
    }