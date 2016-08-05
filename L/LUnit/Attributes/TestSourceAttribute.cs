using System;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Denotes that a method modifies the source when passed a 
    /// certain set of input parameters.
    /// This is useful for methods the manipulate the source object
    /// rather than returning data.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestSourceAttribute : Attribute, ITestSourceAttribute
        {
        /// <summary>
        /// The expected source value.
        /// </summary>
        public object ExpectedSource { get; }

        /// <summary>
        /// Additional optional source checks to perform.
        /// </summary>
        public string[] AdditionalSourceChecks { get; }

        public object[] Parameters { get; }

        /// <summary>
        /// Denotes that a method modifies the source when passed a 
        /// certain set of input parameters.
        /// This is useful for methods the manipulate the source object
        /// rather than returning data.
        /// Optionally provide additional source checks to perform.
        /// </summary>
        public TestSourceAttribute(object[] Parameters, object ExpectedResult, params string[] AdditionalSourceChecks)
            {
            this.ExpectedSource = ExpectedResult;
            this.AdditionalSourceChecks = AdditionalSourceChecks;
            this.Parameters = Parameters;
            }
        }
    }