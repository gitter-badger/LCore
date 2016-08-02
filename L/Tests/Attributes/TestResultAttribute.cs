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
        /// <exception cref="TargetException">Test target may throw an exception.</exception>
        /// <exception cref="TargetInvocationException">Test target may throw an exception.</exception>
        /// <exception cref="TargetParameterCountException">The <paramref>
        ///         <name>parameters</name>
        ///     </paramref>
        ///     array does not have the correct number of arguments. </exception>
        /// <exception cref="MethodAccessException">In the .NET for Windows Store apps or the Portable Class Library, catch the base class exception, <see cref="T:System.MemberAccessException" />, instead.The caller does not have permission to execute the method or constructor that is represented by the current instance. </exception>
        /// <exception cref="ArgumentException">The elements of the <paramref>
        ///         <name>parameters</name>
        ///     </paramref>
        ///     array do not match the signature of the method or constructor reflected by this instance. </exception>
        public override void RunTest(MethodInfo Method)
            {
            Func<object, bool>[] Checks = this.AdditionalResultChecks.Convert(
                L.F<MethodInfo, string, Func<object, bool>>(this.GetCheckMethodArg).Supply(Method));

            //            Method.MethodAssertResult(Parameters, ExpectedResult, Checks);

            var Info = typeof(TestExt).GetMethods().First((Func<MethodInfo, bool>)(MethodInfo =>
                MethodInfo.Name == nameof(TestExt.MethodAssertResult) &&
                MethodInfo.ContainsGenericParameters));

            Info = Info?.MakeGenericMethod(this.ExpectedResult?.GetType() ?? Method.ReturnType);

            Info?.Invoke(null, new[] { Method, null, this.Parameters, this.ExpectedResult, Checks });
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