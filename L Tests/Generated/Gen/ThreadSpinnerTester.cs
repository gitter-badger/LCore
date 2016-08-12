using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Threads;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Threads
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(ThreadSpinner))]
    public partial class ThreadSpinnerTester : XUnitOutputTester, IDisposable
        {
        public ThreadSpinnerTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(ThreadSpinner) + "." + nameof(ThreadSpinner.Wait) + "() => Task")]
        public void Wait()
            {
            // TODO: Implement method test LCore.Threads.ThreadSpinner.Wait
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(ThreadSpinner) + "." + nameof(ThreadSpinner.StopWaiting) + "()")]
        public void StopWaiting()
            {
            // TODO: Implement method test LCore.Threads.ThreadSpinner.StopWaiting
            }

        }
    }