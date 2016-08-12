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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool))]
    public partial class FakeThreadPoolTester : XUnitOutputTester, IDisposable
        {
        public FakeThreadPoolTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.GetCurrentTime) + "() => DateTime")]
        public void GetCurrentTime()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.GetCurrentTime
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.AwaitAllThreadsResumed) + "() => Task")]
        public void AwaitAllThreadsResumed()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.AwaitAllThreadsResumed
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.AwaitThreadAdded) + "() => Task")]
        public void AwaitThreadAdded()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.AwaitThreadAdded
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.Delay) + "(Int32) => Task")]
        public void Delay_Int32_Task()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.Delay
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.Delay) + "(UInt32) => Task")]
        public void Delay_UInt32_Task()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.Delay
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.Delay) + "(TimeSpan) => Task")]
        public void Delay_TimeSpan_Task()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.Delay
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.GetThreadHistory) + "() => List`1<ThreadSpinner>")]
        public void GetThreadHistory()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.GetThreadHistory
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.GetThreadsWaiting) + "() => List`1<ThreadSpinner>")]
        public void GetThreadsWaiting()
            {
            // TODO: Implement method test LCore.Threads.FakeThreadPool.GetThreadsWaiting
            }

        }
    }