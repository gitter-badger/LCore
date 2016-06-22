using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    public class TestSourceAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<object, bool>[] Checks = this.AdditionalSourceChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(this.GetCheckMethodArg).Supply(Method));

            //    Method.MethodAssertSource(Parameters, ExpectedSource);

            MethodInfo m = typeof(TestExt).GetMethods().First(
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

        protected object ExpectedSource;
        protected string[] AdditionalSourceChecks;

        public TestSourceAttribute(object[] Parameters, object ExpectedSource)
            : base(Parameters)
            {
            this.ExpectedSource = ExpectedSource;
            }
        public TestSourceAttribute(object[] Parameters, object ExpectedResult, params string[] AdditionalSourceChecks)
            : base(Parameters)
            {
            this.ExpectedSource = ExpectedResult;
            this.AdditionalSourceChecks = AdditionalSourceChecks;
            }

        public override void FixParameterTypes(MethodInfo Method)
            {
            this.FixObject(Method, Method.GetParameters()[0].ParameterType, ref this.ExpectedSource);
            base.FixParameterTypes(Method);
            }
        }
    }