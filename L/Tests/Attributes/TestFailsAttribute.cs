using System;
using LCore.Extensions;
using System.Reflection;
// ReSharper disable UnusedMember.Global

namespace LCore.Tests
    {
    /// <summary>
    /// Denotes that a particular test fails.
    /// Optionally specify the [ExceptionType] and 
    /// [AdditionalChecks] to be performed
    /// </summary>
    public class TestFailsAttribute : TestAttribute
        {
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        public override void RunTest(MethodInfo Method)
            {
            Func<bool>[] Checks = this.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(this.GetCheckMethod).Supply(Method));
            Method.MethodAssertFails(this.Parameters, this.ExceptionType, Checks);
            }

        /// <summary>
        /// The type of exception to filter.
        /// </summary>
        protected readonly Type ExceptionType;

        /// <summary>
        /// Fully qualified references to additional checks to perform.
        /// </summary>
        protected readonly string[] AdditionalChecks;

        /// <summary>
        /// Denotes that a particular test fails.
        /// Optionally specify the [ExceptionType] and 
        /// [AdditionalChecks] to be performed
        /// </summary>
        public TestFailsAttribute(Type ExceptionType = null)
            : this(null, ExceptionType)
            {
            }

        /// <summary>
        /// Denotes that a particular test fails.
        /// Optionally specify the [ExceptionType] and 
        /// [AdditionalChecks] to be performed
        /// </summary>
        public TestFailsAttribute(object[] Parameters, Type ExceptionType = null, params string[] AdditionalChecks)
            : base(Parameters)
            {
            this.ExceptionType = ExceptionType ?? typeof(Exception);
            this.AdditionalChecks = AdditionalChecks;
            }
        }
    }