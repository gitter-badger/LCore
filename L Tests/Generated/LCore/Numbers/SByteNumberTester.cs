using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    public class SByteNumberTester : XUnitOutputTester
        {
        public SByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~SByteNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.op_Implicit
            }

        }
    }