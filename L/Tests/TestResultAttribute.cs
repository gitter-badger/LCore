using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    public class TestResultAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<object, bool>[] Checks = this.AdditionalResultChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(this.GetCheckMethodArg).Supply(Method));

            //            Method.MethodAssertResult(Parameters, ExpectedResult, Checks);

            MethodInfo m = typeof(TestExt).GetMethods().First(
                method => method.Name == "MethodAssertResult" && method.ContainsGenericParameters);

            m = m.MakeGenericMethod(this.ExpectedResult?.GetType() ?? Method.ReturnType);

            m.Invoke(null, new[] { Method, this.Parameters, this.ExpectedResult, Checks });
            }

        protected object ExpectedResult;
        protected string[] AdditionalResultChecks;

        public TestResultAttribute(object[] Parameters, object ExpectedResult)
            : base(Parameters)
            {
            this.ExpectedResult = ExpectedResult;
            }
        public TestResultAttribute(object[] Parameters, object ExpectedResult, params string[] AdditionalResultChecks)
            : base(Parameters)
            {
            this.ExpectedResult = ExpectedResult;
            this.AdditionalResultChecks = AdditionalResultChecks;
            }

        public override void FixParameterTypes(MethodInfo Method)
            {
            this.FixObject(Method, Method.ReturnType, ref this.ExpectedResult);
            base.FixParameterTypes(Method);
            }
        }
    }