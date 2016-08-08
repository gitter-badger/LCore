using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class IntNumberTester : XUnitOutputTester
        {
        public IntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~IntNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.op_Implicit
            }

        }
    }