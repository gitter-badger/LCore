using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class Number_2Tester : XUnitOutputTester
        {
        public Number_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~Number_2Tester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method Test LCore.Numbers.Number`2.op_Implicit
            }

        }
    }