using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class LongNumberTester : XUnitOutputTester
        {
        public LongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~LongNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.op_Implicit
            }

        }
    }