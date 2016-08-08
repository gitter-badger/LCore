using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class DoubleNumberTester : XUnitOutputTester
        {
        public DoubleNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }



        ~DoubleNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.op_Implicit
            }

        }
    }