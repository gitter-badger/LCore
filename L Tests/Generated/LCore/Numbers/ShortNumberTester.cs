using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class ShortNumberTester : XUnitOutputTester
        {
        public ShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~ShortNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.op_Implicit
            }

        }
    }