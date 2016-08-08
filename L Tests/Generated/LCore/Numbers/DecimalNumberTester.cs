using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class DecimalNumberTester : XUnitOutputTester
        {
        public DecimalNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~DecimalNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method Test LCore.Numbers.DecimalNumber.op_Implicit
            }

        }
    }