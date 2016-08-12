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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StopWatch))]
    public partial class StopWatchTester : XUnitOutputTester, IDisposable
        {
        public StopWatchTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StopWatch) + "." + nameof(StopWatch.Start) + "()")]
        public void Start()
            {
            // TODO: Implement method test LCore.Tools.StopWatch.Start
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(StopWatch) + "." + nameof(StopWatch.Stop) + "() => Double")]
        public void Stop()
            {
            // TODO: Implement method test LCore.Tools.StopWatch.Stop
            }

        }
    }