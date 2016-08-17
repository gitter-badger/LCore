﻿/*
Covering Assembly: L

Cover application using naming conventions.

LUnit has Autogenerated 2 Classes and 11 Methods:
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Threads;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable CollectionNeverQueried.Local

// ReSharper disable RedundantCast

// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable EmptyDestructor
// ReSharper disable NotAccessedVariable

namespace L_Tests.LCore.Threads
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool))]
    public partial class FakeThreadPoolTester : XUnitOutputTester, IDisposable
        {
        public FakeThreadPoolTester([NotNull] ITestOutputHelper Output) : base(Output)
            {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            }

        public void Dispose()
            {
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.AwaitThreadAdded) + "() => Task")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.GetThreadHistory) + "() => List<ThreadSpinner>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.GetThreadsWaiting) + "() => List<ThreadSpinner>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(ThreadSpinner) + "." + nameof(ThreadSpinner.Wait) + "() => Task")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(ThreadSpinner) + "." + nameof(ThreadSpinner.StopWaiting) + "()")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.Delay) + "(Int32) => Task")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.Delay) + "(UInt32) => Task")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Threads) + "." + nameof(FakeThreadPool) + "." + nameof(FakeThreadPool.Delay) + "(TimeSpan) => Task")]
        public async void SimpleTest()
            {
            var Pool = new FakeThreadPool();

            int Handoff = 0;
            const int Target = 3;

            const int MinWait = 500;
            const int MaxWait = 600;

            const int LongWait = 5000;

            int Task2Waited = 0;
            int Task3Waited = 0;
            int Task4Waited = 0;

            var Task1 = new Task(async () =>
                {
                await Pool.Delay(LongWait);
                Handoff++;
                });
            var Task2 = new Task(async () =>
                {
                while (Handoff != 1)
                    {
                    await Pool.Delay(L.Obj.NewRandom<int>(MinWait, MaxWait));
                    Task2Waited++;
                    }
                Handoff.ShouldBe(Expected: 1);
                Handoff++;
                });
            var Task3 = new Task(async () =>
                {
                while (Handoff != 2)
                    {
                    await Pool.Delay(L.Obj.NewRandom<uint>((uint) MinWait, (uint) MaxWait));
                    Task3Waited++;
                    }
                Handoff.ShouldBe(Expected: 2);
                Handoff++;
                });
            var Task4 = new Task(async () =>
                {
                while (Handoff != 3)
                    {
                    await Pool.Delay(TimeSpan.FromMilliseconds(L.Obj.NewRandom<int>(MinWait, MaxWait)));
                    Task4Waited++;
                    }
                Handoff.ShouldBe(Expected: 3);
                });

            Task1.Start();
            Task2.Start();
            Task3.Start();
            Task4.Start();

            await Pool.AwaitThreadAdded();

            var Timer = new StopWatch();
            Timer.Start();

            while (Handoff < Target)
                await Task.Delay(millisecondsDelay: 1);
            //await Pool.AwaitAllThreadsResumed();

            double Duration = Timer.Stop();

            await Task.Delay(millisecondsDelay: 50);

            List<ThreadSpinner> Results = Pool.GetThreadHistory();

            Results.Count.Should().BeGreaterOrEqualTo(Target);
            Handoff.ShouldBe(Target);

            this._Output.WriteLine($"Handoffs: {Handoff}");
            this._Output.WriteLine($"Actual Task Duration: {Duration.Round()}ms");

            uint TotalFakeWaited = Results.Sum(Thread => Thread.DurationWaited.TotalMilliseconds);
            TotalFakeWaited.Should().BeGreaterThan(LongWait);

            this._Output.WriteLine($"Tasks Fake-Waited: {TimeSpan.FromMilliseconds(TotalFakeWaited).ToTimeString()} over {Results.Count} {"Delay".Pluralize(Results.Count)}");
            }

        [Fact]
        public async void HandoffTest()
            {
            var Pool = new FakeThreadPool();

            const int Target = 100;

            int Handoff = 0;
            const uint LargeDelay = 500000;
            const int SmallDelay = 500;

            var History = new List<string>();

            var Task1 = new Task(async () =>
                {
                while (Handoff < Target)
                    {
                    await Pool.Delay(LargeDelay);
                    Handoff++;
                    History.Add("Task1");
                    }
                });
            var Task2 = new Task(async () =>
                {
                while (Handoff < Target)
                    {
                    while (Handoff%3 != 0)
                        await Pool.Delay(SmallDelay);

                    (Handoff%3).ShouldBe(Expected: 0);
                    Handoff++;
                    History.Add("Task2");
                    }
                });
            var Task3 = new Task(async () =>
                {
                while (Handoff < Target)
                    {
                    while (Handoff%3 != 1)
                        await Pool.Delay(SmallDelay);

                    (Handoff%3).ShouldBe(Expected: 1);
                    Handoff++;
                    History.Add("Task3");
                    }
                });
            var Task4 = new Task(async () =>
                {
                while (Handoff < Target)
                    {
                    while (Handoff%3 != 2)
                        await Pool.Delay(SmallDelay);

                    (Handoff%3).ShouldBe(Expected: 2);
                    Handoff++;
                    History.Add("Task4");
                    }
                });

            Task1.Start();
            Task2.Start();
            Task3.Start();
            Task4.Start();

            var Timer = new StopWatch();
            await Pool.AwaitThreadAdded();
            Timer.Start();

            while (Handoff < Target)
                await Task.Delay(millisecondsDelay: 1);

            //await Pool.AwaitAllThreadsResumed();

            double Duration = Timer.Stop();

            await Task.Delay(millisecondsDelay: 50);

            List<ThreadSpinner> Results = Pool.GetThreadHistory();

            Results.Count.Should().BeGreaterOrEqualTo(expected: 3);
            Handoff.Should().BeGreaterOrEqualTo(Target);
            /*
                        History.Should().Equal("Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task2", "Task3", "Task4",
                            "Task2", "Task3", "Task4", "Task2", "Task3", "Task4", "Task1");*/

            this._Output.WriteLine($"Handoffs:                      {Handoff}");
            this._Output.WriteLine($"Task Resumes:                  {Results.Count}");
            this._Output.WriteLine($"Actual Task Duration:          {Duration.Round()}ms");
            this._Output.WriteLine("");
            this._Output.WriteLine("");
            this._Output.WriteLine($"Duration per handoff:          {(Duration/Handoff).Round()}ms");
            this._Output.WriteLine($"Duration per task resume:      {(Duration/Results.Count).Round()}ms");

            uint TotalFakeWaited = Results.Sum(Thread => Thread.DurationWaited.TotalMilliseconds);
            //TotalFakeWaited.Should().BeGreaterThan(LargeDelay);

            this._Output.WriteLine($"Tasks Fake-Waited: {TimeSpan.FromMilliseconds(TotalFakeWaited).ToTimeString()} over {Results.Count} {"Delay".Pluralize(Results.Count)}");
            }

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
        }
    }