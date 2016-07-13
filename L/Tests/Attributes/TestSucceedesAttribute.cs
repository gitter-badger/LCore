using System;
using LCore.Extensions;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LCore.Tests
    {
    /// <summary>
    /// Denotes that a particular method succeeds (does not throw an exception)
    /// </summary>
    public class TestSucceedesAttribute : TestAttribute
        {
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public override void RunTest(MethodInfo Method)
            {
            Func<bool>[] Checks = this.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(this.GetCheckMethod).Supply(Method));
            Method.MethodAssertSucceedes(this.Parameters, Checks);
            }

        /// <summary>
        /// Additional optional checks to perform when running the test.
        /// </summary>
        protected readonly string[] AdditionalChecks;
        
        /// <summary>
        /// Denotes that a particular method succeeds when passed particular parameters.
        /// </summary>
        public TestSucceedesAttribute(object[] Parameters)
            : base(Parameters)
            {
            }
        /// <summary>
        /// Denotes that a particular method succeeds when passed particular parameters.
        /// </summary>
        public TestSucceedesAttribute(object[] Parameters, params string[] AdditionalChecks)
            : base(Parameters)
            {
            this.AdditionalChecks = AdditionalChecks;
            }

        }
    }