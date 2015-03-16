using System;
using System.Collections.Generic;
using LCore.Dynamic;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LCore.UnitTesting
    {
    public class TestResultAttribute : TestAttribute
        {
        public override void RunTest(MethodInfo Method)
            {
            Func<Object, Boolean>[] Checks = AdditionalResultChecks.Convert(L.F<MethodInfo, String, Func<Object, Boolean>>(base.GetCheckMethodArg).Supply(Method));

            //            Method.MethodAssertResult(Parameters, ExpectedResult, Checks);

            MethodInfo m = typeof(TestExt).GetMethods().First<MethodInfo>((method) =>
            {
                return method.Name == "MethodAssertResult" && method.ContainsGenericParameters;
            });

            if (ExpectedResult != null)
                {
                m = m.MakeGenericMethod(ExpectedResult.GetType());
                }
            else
                {
                m = m.MakeGenericMethod(Method.ReturnType);
                }

            m.Invoke(null, new Object[] { Method, Parameters, ExpectedResult, Checks });
            }

        protected Object ExpectedResult;
        protected String[] AdditionalResultChecks;

        public TestResultAttribute(Object[] Parameters, Object ExpectedResult)
            : base(Parameters)
            {
            this.ExpectedResult = ExpectedResult;
            }
        public TestResultAttribute(Object[] Parameters, Object ExpectedResult, params String[] AdditionalResultChecks)
            : base(Parameters)
            {
            this.ExpectedResult = ExpectedResult;
            this.AdditionalResultChecks = AdditionalResultChecks;
            }

        public override void FixParameterTypes(MethodInfo Method)
            {
            FixObject(Method, Method.ReturnType, ref ExpectedResult);
            base.FixParameterTypes(Method);
            }
        }
    }