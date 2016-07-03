using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    /// <summary>
    /// Denotes that a method modifies the source when passed a 
    /// certain set of input parameters.
    /// This is usefel for methods the manipulate the source object
    /// rather than returning data.
    /// </summary>
    public class TestSourceAttribute : TestAttribute
        {
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        public override void RunTest(MethodInfo Method)
            {
            Func<object, bool>[] Checks = this.AdditionalSourceChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(this.GetCheckMethodArg).Supply(Method));

            //    Method.MethodAssertSource(Parameters, ExpectedSource);

            var m = typeof(TestExt).GetMethods().First(
                method => method.Name == "MethodAssertSource" && method.ContainsGenericParameters);

            if (this.ExpectedSource != null)
                {
                m = m.MakeGenericMethod(this.ExpectedSource.GetType());
                }
            else if (this.Parameters[0] != null)
                {
                m = m.MakeGenericMethod(this.Parameters[0].GetType());
                }
            else
                {
                m = m.MakeGenericMethod(typeof(object));
                }

            m.Invoke(null, new[] { Method, this.Parameters, this.ExpectedSource, Checks });
            }

        /// <summary>
        /// The expected source value.
        /// </summary>
        protected object ExpectedSource;

        /// <summary>
        /// Additional optional source checks to perform.
        /// </summary>
        protected string[] AdditionalSourceChecks;


        /// <summary>
        /// Denotes that a method modifies the source when passed a 
        /// certain set of input parameters.
        /// This is usefel for methods the manipulate the source object
        /// rather than returning data.
        /// </summary>
        public TestSourceAttribute(object[] Parameters, object ExpectedSource)
            : base(Parameters)
            {
            this.ExpectedSource = ExpectedSource;
            }
        /// <summary>
        /// Denotes that a method modifies the source when passed a 
        /// certain set of input parameters.
        /// This is usefel for methods the manipulate the source object
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