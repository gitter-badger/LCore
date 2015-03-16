using System;
using System.Collections.Generic;
using LCore.Dynamic;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LCore.UnitTesting
    {
    public class TestSourceAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<Object, Boolean>[] Checks = AdditionalSourceChecks.Convert(L.F<MethodInfo, String, Func<Object, Boolean>>(base.GetCheckMethodArg).Supply(Method));

            //    Method.MethodAssertSource(Parameters, ExpectedSource);

            MethodInfo m = typeof(TestExt).GetMethods().First<MethodInfo>((method) =>
            {
                return method.Name == "MethodAssertSource" && method.ContainsGenericParameters;
            });

            if (ExpectedSource != null)
                {
                m = m.MakeGenericMethod(ExpectedSource.GetType());
                }
            else if (Parameters[0] != null)
                {
                m = m.MakeGenericMethod(Parameters[0].GetType());
                }
            else
                {
                m = m.MakeGenericMethod(typeof(Object));
                }

            m.Invoke(null, new Object[] { Method, Parameters, ExpectedSource, Checks });
            }

        protected Object ExpectedSource;
        protected String[] AdditionalSourceChecks;

        public TestSourceAttribute(Object[] Parameters, Object ExpectedSource)
            : base(Parameters)
            {
            this.ExpectedSource = ExpectedSource;
            }
        public TestSourceAttribute(Object[] Parameters, Object ExpectedResult, params String[] AdditionalSourceChecks)
            : base(Parameters)
            {
            this.ExpectedSource = ExpectedResult;
            this.AdditionalSourceChecks = AdditionalSourceChecks;
            }

        public override void FixParameterTypes(MethodInfo Method)
            {
            FixObject(Method, Method.GetParameters()[0].ParameterType, ref ExpectedSource);
            base.FixParameterTypes(Method);
            }
        }
    }