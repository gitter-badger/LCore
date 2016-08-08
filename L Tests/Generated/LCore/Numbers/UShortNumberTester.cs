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
    public class UShortNumberTester : XUnitOutputTester
        {
        public UShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~UShortNumberTester()
            {
            }

        [Fact]
        public void op_Implicit()
            {
            // TODO: Implement method Test LCore.Numbers.UShortNumber.op_Implicit
            }

        }
    }