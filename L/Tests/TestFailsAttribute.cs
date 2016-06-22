using System;
using LCore.Extensions;
using System.Reflection;

namespace LCore.Tests
    {
    public class TestFailsAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<bool>[] Checks = this.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(this.GetCheckMethod).Supply(Method));
            Method.MethodAssertFails(this.Parameters, this.ExceptionType, Checks);
            }

        protected Type ExceptionType;
        protected string[] AdditionalChecks;

        public TestFailsAttribute(Type ExceptionType)
            : this(null, ExceptionType)
            {
            }

        public TestFailsAttribute(object[] Parameters, Type ExceptionType = null)
            : base(Parameters)
            {
            this.ExceptionType = ExceptionType;
            }
        public TestFailsAttribute(object[] Parameters, Type ExceptionType, params string[] AdditionalChecks)
            : base(Parameters)
            {
            this.ExceptionType = ExceptionType;
            this.AdditionalChecks = AdditionalChecks;
            }
        }
    }