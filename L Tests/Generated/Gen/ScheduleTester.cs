using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule))]
    public partial class ScheduleTester : XUnitOutputTester, IDisposable
        {
        public ScheduleTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule) + "." + nameof(Schedule.ToString) + "() => String")]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Tools.Schedule.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule) + "." + nameof(Schedule.FromString) + "(String) => Schedule")]
        public void FromString()
            {
            // TODO: Implement method test LCore.Tools.Schedule.FromString
            }

        }
    }