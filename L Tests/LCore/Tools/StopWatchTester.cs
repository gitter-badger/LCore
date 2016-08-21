using System;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit.Abstractions;
#if DEBUG
using System.Threading;
using FluentAssertions;
using LCore.Tools;
using Xunit;
#endif

// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable ObjectCreationAsStatement

namespace L_Tests.LCore.Tools
    {
    public partial class StopWatchTester : XUnitOutputTester, IDisposable
        {
        public StopWatchTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

#if DEBUG
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StopWatch) + "." + nameof(StopWatch.Start) + "()")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StopWatch) + "." + nameof(StopWatch.Stop) + "() => Double")]
        public void AllTests()
            {
            var Test = new StopWatch();

            lock (Test)
                {
                Test.Start();
                Thread.Sleep(millisecondsTimeout: 200);

                Test.Stop().Should().BeInRange(minimumValue: 190, maximumValue: 225);

                Test.Start();
                Thread.Sleep(millisecondsTimeout: 20);
                Test.Stop().Should().BeInRange(minimumValue: 15, maximumValue: 25);
                }
            }
#endif
        }
    }