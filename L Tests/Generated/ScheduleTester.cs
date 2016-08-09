using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule))]
    public partial class ScheduleTester : XUnitOutputTester
        {
        public ScheduleTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ScheduleTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule) + "." + nameof(Schedule.ToString))]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Tools.Schedule.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule) + "." + nameof(Schedule.FromString))]
        public void FromString()
            {
            // TODO: Implement method test LCore.Tools.Schedule.FromString
            }

        }
    }