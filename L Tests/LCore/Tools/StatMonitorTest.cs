using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable ObjectCreationAsStatement

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor))]
    public partial class StatMonitorTester : XUnitOutputTester, IDisposable
        {
        public StatMonitorTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." +
            nameof(StatMonitor.GetCurrentAverageStat) + "() => Double")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." +
            nameof(StatMonitor.AddStat) + "(Double)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StatMonitor) + "." +
            nameof(StatMonitor.Clear) + "()")]
        public void StatisticalGathering()
            {
            L.A(() => new StatMonitor(-1)).ShouldFail();
            L.A(() => new StatMonitor(WalkingAverageSize: 0)).ShouldFail();

            var Test = new StatMonitor(WalkingAverageSize: 10);

            Test.GetCurrentAverageStat().ShouldBe(double.NaN);

            Test.AddStat(Stat: 1);
            Test.AddStat(Stat: 2);
            Test.AddStat(Stat: 3);
            Test.AddStat(Stat: 4);
            Test.AddStat(Stat: 5);
            Test.AddStat(Stat: 6);
            Test.AddStat(Stat: 7);
            Test.AddStat(Stat: 8);
            Test.AddStat(Stat: 9);
            Test.AddStat(Stat: 10);

            Test.GetCurrentAverageStat().ShouldBe(Compare: 5.5);

            Test.AddStat(Stat: 11);
            Test.AddStat(Stat: 12);
            Test.AddStat(Stat: 13);
            Test.AddStat(Stat: 14);
            Test.AddStat(Stat: 15);
            Test.AddStat(Stat: 16);
            Test.AddStat(Stat: 17);
            Test.AddStat(Stat: 18);
            Test.AddStat(Stat: 19);
            Test.AddStat(Stat: 20);

            Test.GetCurrentAverageStat().ShouldBe(Compare: 15.5);

            Test.Clear();
            Test.GetCurrentAverageStat().ShouldBe(double.NaN);
            }
        }
    }