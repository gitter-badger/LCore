using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    public class TestSucceedesAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<bool>[] Checks = this.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(this.GetCheckMethod).Supply(Method));
            Method.MethodAssertSucceedes(this.Parameters, Checks);
            }
        protected string[] AdditionalChecks;

        public TestSucceedesAttribute()
            {
            }
        public TestSucceedesAttribute(object[] Parameters)
            : base(Parameters)
            {
            }
        public TestSucceedesAttribute(object[] Parameters, params string[] AdditionalChecks)
            : base(Parameters)
            {
            this.AdditionalChecks = AdditionalChecks;
            }

        }
    }