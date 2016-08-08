using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    // ReSharper disable once InconsistentNaming
    public class ULongNumberTester : XUnitOutputTester
        {
        public ULongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ULongNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.op_Implicit
            }

        }
    }