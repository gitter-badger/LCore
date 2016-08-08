using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class FloatNumberTester : XUnitOutputTester
        {
        public FloatNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~FloatNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.op_Implicit
            }

        }
    }