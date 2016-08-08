using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class ByteNumberTester : XUnitOutputTester
        {
        public ByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ByteNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.op_Implicit
            }

        }
    }