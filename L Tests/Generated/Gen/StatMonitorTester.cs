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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor))]
    public partial class StatMonitorTester : XUnitOutputTester, IDisposable
        {
        public StatMonitorTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." + nameof(StatMonitor.GetCurrentAverageStat) + "() => Double")]
        public void GetCurrentAverageStat()
            {
            // TODO: Implement method test LCore.Tools.StatMonitor.GetCurrentAverageStat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." + nameof(StatMonitor.AddStat) + "(Double)")]
        public void AddStat()
            {
            // TODO: Implement method test LCore.Tools.StatMonitor.AddStat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." + nameof(StatMonitor.Clear) + "()")]
        public void Clear()
            {
            // TODO: Implement method test LCore.Tools.StatMonitor.Clear
            }

        }
    }