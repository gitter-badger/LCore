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
    public class UIntNumberTester : XUnitOutputTester
        {
        public UIntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~UIntNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.op_Implicit
            }

        }
    }