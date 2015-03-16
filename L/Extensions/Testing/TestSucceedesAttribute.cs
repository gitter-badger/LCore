using System;
using System.Collections.Generic;
using LCore.Dynamic;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LCore.UnitTesting
    {
    public class TestSucceedesAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<Boolean>[] Checks = AdditionalChecks.Convert(L.F<MethodInfo, String, Func<Boolean>>(base.GetCheckMethod).Supply(Method));
            Method.MethodAssertSucceedes(Parameters, Checks);
            }
        protected String[] AdditionalChecks;

        public TestSucceedesAttribute()
            : base()
            {
            }
        public TestSucceedesAttribute(Object[] Parameters)
            : base(Parameters)
            {
            }
        public TestSucceedesAttribute(Object[] Parameters, params String[] AdditionalChecks)
            : base(Parameters)
            {
            this.AdditionalChecks = AdditionalChecks;
            }

        }
    }