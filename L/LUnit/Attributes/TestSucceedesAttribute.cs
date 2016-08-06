using System;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Denotes that a particular method succeeds (does not throw an exception)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TestSucceedesAttribute : Attribute, ITestSucceedsAttribute
        {
        /// <summary>
        /// Additional optional checks to perform when running the test.
        /// </summary>
        public string[] AdditionalChecks { get; set; }

        /// <summary>
        /// Parameters for the current test
        /// </summary>
        public object[] Parameters { get; set; }


        /// <summary>
        /// Denotes that a particular method succeeds when passed particular parameters.
        /// </summary>
        public TestSucceedesAttribute(object[] Parameters, params string[] AdditionalChecks)
            {
            this.AdditionalChecks = AdditionalChecks;
            this.Parameters = Parameters;
            }
        }
    }