using System;
using System.Collections.Generic;
using LCore.Dynamic;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LCore.UnitTesting
    {
    public class TestFailsAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<Boolean>[] Checks = AdditionalChecks.Convert(L.F<MethodInfo, String, Func<Boolean>>(base.GetCheckMethod).Supply(Method));
            Method.MethodAssertFails(Parameters, ExceptionType, Checks);
            }

        protected Type ExceptionType;
        protected String[] AdditionalChecks;

        public TestFailsAttribute(Type ExceptionType)
            : this(null, ExceptionType)
            {
            }
        public TestFailsAttribute(Object[] Parameters)
            : this(Parameters, null)
            {
            this.ExceptionType = ExceptionType;
            }
        public TestFailsAttribute(Object[] Parameters, Type ExceptionType)
            : base(Parameters)
            {
            this.ExceptionType = ExceptionType;
            }
        public TestFailsAttribute(Object[] Parameters, Type ExceptionType, params String[] AdditionalChecks)
            : base(Parameters)
            {
            this.ExceptionType = ExceptionType;
            }
        }
    }