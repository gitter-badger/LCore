using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    /// <summary>
    /// Denotes that a method modifies the source when passed a 
    /// certain set of input parameters.
    /// This is useful for methods the manipulate the source object
    /// rather than returning data.
    /// </summary>
    public class TestSourceAttribute : TestAttribute
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
            Func<object, bool>[] Checks = this.AdditionalSourceChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(this.GetCheckMethodArg).Supply(Method));

            //    Method.MethodAssertSource(Parameters, ExpectedSource);

            var OutMethod = typeof(TestExt).GetMethods().First((Func<MethodInfo, bool>)(MethodInfo =>
                MethodInfo.Name == nameof(TestExt.MethodAssertSource) && MethodInfo.ContainsGenericParameters));

            if (this.ExpectedSource != null)
                {
                OutMethod = OutMethod.MakeGenericMethod(this.ExpectedSource.GetType());
                }
            else if (this.Parameters[0] != null)
                {
                OutMethod = OutMethod.MakeGenericMethod(this.Parameters[0].GetType());
                }
            else
                {
                OutMethod = OutMethod.MakeGenericMethod(typeof(object));
                }

            OutMethod.Invoke(null, new[] { Method, this.Parameters, this.ExpectedSource, Checks });
            }

        /// <summary>
        /// The expected source value.
        /// </summary>
        protected object ExpectedSource;

        /// <summary>
        /// Additional optional source checks to perform.
        /// </summary>
        protected readonly string[] AdditionalSourceChecks;

        /// <summary>
        /// Denotes that a method modifies the source when passed a 
        /// certain set of input parameters.
        /// This is useful for methods the manipulate the source object
        /// rather than returning data.
        /// Optionally provide additional source checks to perform.
        /// </summary>
        public TestSourceAttribute(object[] Parameters, object ExpectedResult, params string[] AdditionalSourceChecks)
            : base(Parameters)
            {
            this.ExpectedSource = ExpectedResult;
            this.AdditionalSourceChecks = AdditionalSourceChecks;
            }

        /// <summary>
        /// Attempts to resolve parameter types for a method test.
        /// This corrects parameter types, converts arrays to lists if needed.
        /// </summary>
        public override void FixParameterTypes(MethodInfo Method)
            {
            this.FixObject(Method, Method.GetParameters()[0].ParameterType, ref this.ExpectedSource);
            base.FixParameterTypes(Method);
            }
        }
    }