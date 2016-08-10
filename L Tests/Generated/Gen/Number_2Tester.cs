using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Numbers
    {
    [Trait(Traits.TargetMember, "LCore.Numbers.Number`2")]
    public partial class Number_2Tester : XUnitOutputTester
        {
        public Number_2Tester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~Number_2Tester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number`2.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.Number`2.op_Implicit
            }

        }
    }