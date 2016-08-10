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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor))]
    public partial class StatMonitorTester : XUnitOutputTester
        {
        public StatMonitorTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~StatMonitorTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." + nameof(StatMonitor.GetCurrentAverageStat))]
        public void GetCurrentAverageStat()
            {
            // TODO: Implement method test LCore.Tools.StatMonitor.GetCurrentAverageStat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." + nameof(StatMonitor.AddStat))]
        public void AddStat()
            {
            // TODO: Implement method test LCore.Tools.StatMonitor.AddStat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." + nameof(StatMonitor.Clear))]
        public void Clear()
            {
            // TODO: Implement method test LCore.Tools.StatMonitor.Clear
            }

        }
    }