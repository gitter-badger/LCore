using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    /// <summary>
    /// Denotes that a method returns a specific result when passed a 
    /// certain set of input parameters.
    /// </summary>
    public class TestResultAttribute : TestAttribute
        {
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        public override void RunTest(MethodInfo Method)
            {
            Func<object, bool>[] Checks = this.AdditionalResultChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(this.GetCheckMethodArg).Supply(Method));

            //            Method.MethodAssertResult(Parameters, ExpectedResult, Checks);

            var m = typeof(TestExt).GetMethods().First(
                method => method.Name == "MethodAssertResult" && method.ContainsGenericParameters);

            m = m.MakeGenericMethod(this.ExpectedResult?.GetType() ?? Method.ReturnType);

            m.Invoke(null, new[] { Method, this.Parameters, this.ExpectedResult, Checks });
            }

        /// <summary>
        /// The expected result from the method.
        /// </summary>
        protected object ExpectedResult;
        /// <summary>
        /// Fully qualified references to additional checks to perform.
        /// </summary>
        protected readonly string[] AdditionalResultChecks;

        /// <summary>
        /// Denotes that a method returns a specific result when passed a 
        /// certain set of input parameters.
        /// </summary>
        public TestResultAttribute(object[] Parameters, object ExpectedResult)
            : base(Parameters)
            {
            this.ExpectedResult = ExpectedResult;
            }
        /// <summary>
        /// Denotes that a method returns a specific result when passed a 
        /// certain set of input parameters.
        /// </summary>
        public TestResultAttribute(object[] Parameters, object ExpectedResult, params string[] AdditionalResultChecks)
            : base(Parameters)
            {
            this.ExpectedResult = ExpectedResult;
            this.AdditionalResultChecks = AdditionalResultChecks;
            }

        /// <summary>
        /// Attempts to resolve parameter types for a method test.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        public override void FixParameterTypes(MethodInfo Method)
            {
            this.FixObject(Method, Method.ReturnType, ref this.ExpectedResult);
            base.FixParameterTypes(Method);
            }
        }
    }