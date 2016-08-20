using System;
using System.Threading;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable PossibleNullReferenceException

namespace L_Thread_Tests.LCore.Extensions
    {
    public partial class ThreadExtTester : XUnitOutputTester, IDisposable
        {
        public const string Category = "Threading";

        public ThreadExtTester([NotNull] ITestOutputHelper Output) : base(Output)
            {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            }

        public void Dispose() {}

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action, ThreadPriority) => Action")]
        public void Async_Action()
            {
            bool Success = false;
            var TestAction = new Action(() =>
                {
                Thread.Sleep(millisecondsTimeout: 20);
                Success = true;
                });

            lock (TestAction)
                {
                TestAction.Async()();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeTrue();
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action, TimeSpan, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action, Int32, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action, UInt32, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action, Int64, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action, UInt64, ThreadPriority) => Action")]
        public void Async_Action_TimeLimit()
            {
            bool Success = false;
            var TestAction = new Action(() =>
                {
                Thread.Sleep(millisecondsTimeout: 20);
                Success = true;
                });

            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test uint
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20u)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50u)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test long
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20L)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50L)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test ulong
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20uL)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50uL)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test TimeSpan
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeSpan.FromMilliseconds(value: 20))();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.Async(TimeSpan.FromMilliseconds(value: 50))();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>) => Action<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>, ThreadPriority) => Action<T>")]
        public void Async_Action_T()
            {
            string Success = "";
            var TestAction = new Action<string>(Str =>
                {
                Thread.Sleep(millisecondsTimeout: 5);
                Success = Str;
                });

            lock (Success)
                {
                TestAction.Async()("abc");
                Success.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 30);

                Success.ShouldBe("abc");
                }
            Success = "";

            lock (Success)
                {
                TestAction.Async(ThreadPriority.AboveNormal)("abc");
                Success.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 30);

                Success.ShouldBe("abc");
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>, TimeSpan, ThreadPriority) => Action<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>, Int32, ThreadPriority) => Action<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>, UInt32, ThreadPriority) => Action<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>, Int64, ThreadPriority) => Action<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Async) + "(Action<T>, UInt64, ThreadPriority) => Action<T>")]
        public void Async_Action_T_TimeLimit()
            {
            string Result = "";
            var TestAction = new Action<string>(Str =>
                {
                Thread.Sleep(millisecondsTimeout: 30);
                Result = Str;
                });

            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20)("abc");
                Result.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 80);

                Result.ShouldBe("");

                TestAction.Async(TimeLimitMilliseconds: 50)("abc");
                Result.ShouldBe("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.ShouldBe("abc");

                TestAction("abc");
                }

            // Test uint
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20u)("abc");
                Result.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.ShouldBe("");

                TestAction.Async(TimeLimitMilliseconds: 50u)("abc");
                Result.ShouldBe("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.ShouldBe("abc");

                TestAction("abc");
                }

            // Test long
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20L)("abc");
                Result.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.ShouldBe("");

                TestAction.Async(TimeLimitMilliseconds: 50L)("abc");
                Result.ShouldBe("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.ShouldBe("abc");

                TestAction("abc");
                }

            // Test long
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20uL)("abc");
                Result.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.ShouldBe("");

                TestAction.Async(TimeLimitMilliseconds: 50uL)("abc");
                Result.ShouldBe("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.ShouldBe("abc");

                TestAction("abc");
                }

            // Test TimeSpan
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeSpan.FromMilliseconds(value: 20))("abc");
                Result.ShouldBe("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.ShouldBe("");

                TestAction.Async(TimeSpan.FromMilliseconds(value: 50))("abc");
                Result.ShouldBe("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.ShouldBe("abc");

                TestAction("abc");
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>, ThreadPriority) => Action")]
        public void Async_Func()
            {
            var TestAction = new Func<string>(() => "yes");

            lock (TestAction)
                {
                TestAction.AsyncResult(Result => { Result.ShouldBe("yes"); })();

                Thread.Sleep(millisecondsTimeout: 20);

                TestAction.AsyncResult(Result => { Result.ShouldBe("yes"); }, ThreadPriority.AboveNormal)();

                Thread.Sleep(millisecondsTimeout: 20);
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>, ThreadPriority) => Action<T1>")]
        public void Async_Func_T()
            {
            var TestAction = new Func<string, string>(Str => $"{Str}yes");

            lock (TestAction)
                {
                bool Success = false;
                TestAction.AsyncResult(Result =>
                    {
                    Result.ShouldBe("abcyes");
                    Success = true;
                    }, ThreadPriority.Highest)("abc");

                Thread.Sleep(millisecondsTimeout: 500);

                Success.ShouldBeTrue();

                Success = false;
                TestAction.AsyncResult(Result =>
                    {
                    Result.ShouldBe("abcyes");
                    Success = true;
                    }, ThreadPriority.AboveNormal)("abc");

                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>, TimeSpan, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>, Int32, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>, UInt32, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>, Int64, ThreadPriority) => Action")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<U>, Action<U>, UInt64, ThreadPriority) => Action")]
        public void Async_Func_U_TimeLimit()
            {
            bool Success = false;
            var TestAction = new Func<string>(() =>
                {
                Thread.Sleep(millisecondsTimeout: 30);
                Success = true;
                return "abc";
                });

            Action<string> TestAction2 = Result => { Result.ShouldBe("abc"); };

            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 10)();

                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test uint
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20u)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50u)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test long
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20L)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50L)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test ulong
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20uL)();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50uL)();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }

            // test TimeSpan
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeSpan.FromMilliseconds(value: 20))();
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(TestAction2, TimeSpan.FromMilliseconds(value: 50))();
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction();
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>, TimeSpan, ThreadPriority) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>, Int32, ThreadPriority) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>, UInt32, ThreadPriority) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>, Int64, ThreadPriority) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.AsyncResult) + "(Func<T1, U>, Action<U>, UInt64, ThreadPriority) => Action<T1>")]
        public void Async_Func_T_U_TimeLimit()
            {
            bool Success = false;
            var TestAction = new Func<string, string>(Result =>
                {
                Result.ShouldBe("abc");
                Thread.Sleep(millisecondsTimeout: 30);
                Success = true;
                return "abc";
                });

            Action<string> ResultFunction = Result => { Result.ShouldBe("abc"); };

            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20)("abc");

                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50)("abc");
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 60);

                Success.ShouldBeTrue();

                TestAction("abc");
                }

            // test uint
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20u)("abc");
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50u)("abc");
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 60);

                Success.ShouldBeTrue();

                TestAction("abc");
                }

            // test long
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20L)("abc");
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50L)("abc");
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction("abc");
                }

            // test ulong
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20uL)("abc");
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50uL)("abc");
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction("abc");
                }

            // test TimeSpan
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeSpan.FromMilliseconds(value: 20))("abc");
                Success.ShouldBeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.ShouldBeFalse();

                TestAction.AsyncResult(ResultFunction, TimeSpan.FromMilliseconds(value: 50))("abc");
                Success.ShouldBeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.ShouldBeTrue();

                TestAction("abc");
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Get) + "(String) => MethodProfileData")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Remove) + "(String)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Add) + "(String, MethodProfileData)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Has) + "(String) => Boolean")]
        public void MethodProfileCache()
            {
            const string ProfileName = "TestProfile";

            L.Thread.MethodProfileData_Remove(ProfileName);
            L.Thread.MethodProfileData_Get(ProfileName).ShouldBeNull();

            var Action = new Action(() =>
                {
                int Wait = new Random().Next(minValue: 25, maxValue: 50);
                Thread.Sleep(Wait);
                }).Profile(ProfileName).Repeat(Times: 5);

            lock (Action)
                {
                Action();

                var Profile = L.Thread.MethodProfileData_Get(ProfileName);

                Profile.AverageMS.Should().BeInRange(minimumValue: 25, maximumValue: 55);
                Profile.Times.Count.ShouldBe(Expected: 6);

                L.Thread.MethodProfileData_Remove(ProfileName);
                L.Thread.MethodProfileData_Get(ProfileName).ShouldBeNull();
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Profile) + "(Action, UInt32) => TimeSpan")]
        public void Profile()
            {
            Action Act = () => Thread.Sleep(millisecondsTimeout: 10);
            lock (Act)
                {
                Act.Profile().Should().BeCloseTo(new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 10), precision: 40);
                Act.Profile(Repeat: 5)
                    .Should()
                    .BeCloseTo(new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50), precision: 80);
                Act.Profile(Repeat: 20)
                    .Should()
                    .BeCloseTo(new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 200), precision: 100);

                ((Action) null).Profile().Should().BeCloseTo(new TimeSpan(ticks: 0));
                ((Action) null).Profile(Repeat: 5).Should().BeCloseTo(new TimeSpan(ticks: 0));
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Profile) + "(Action<T1>, String) => Action<T1>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Profile) + "(Action, String) => Action")]
        public void ProfileString()
            {
            L.Thread.MethodProfileData_Remove("TestProfile");

            L.Thread.MethodProfileData_Get("TestProfile").ShouldBeNull();

            Action<string> Act = Str =>
                {
                Str.ShouldBe("abc");
                Thread.Sleep(millisecondsTimeout: 10);
                };

            Act = Act.Profile("TestProfile");

            lock (Act)
                {
                Act("abc");
                Act("abc");
                Act("abc");
                Act("abc");
                Act("abc");

                var Result = L.Thread.MethodProfileData_Get("TestProfile");

                Result.Times.Count.ShouldBe(Expected: 5);
                Result.AverageMS.Should().BeInRange(minimumValue: 8, maximumValue: 20);
                Result.Data.Count().ShouldBe(Expected: 0u);
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Profile) + "(Func<U>, UInt32) => MethodProfileData<U>")]
        public void ProfileFunc()
            {
            Func<int> Func = () =>
                {
                int Rand = new Random().Next(minValue: 50, maxValue: 70);
                Thread.Sleep(Rand);
                return Rand;
                };

            Thread.Sleep(millisecondsTimeout: 50);

            lock (Func)
                {
                MethodProfileData<int> Result = Func.Profile();

                Result.AverageMS.Should().BeInRange(minimumValue: 45, maximumValue: 95);
                Result.Data.Count().ShouldBe(Expected: 1u);
                Result.Data.GetAt(Index: 0).Should().BeInRange(minimumValue: 45, maximumValue: 75);


                Result = Func.Profile(Repeat: 5);

                Result.AverageMS.Should().BeInRange(minimumValue: 45, maximumValue: 95);
                Result.Data.Count().ShouldBe(Expected: 6u);
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Profile) + "(Func<U>, String) => Func<U>")]
        public void ProfileFuncString()
            {
            const string ProfieName = "TestProfile";

            L.Thread.MethodProfileData_Remove(ProfieName);

            L.Thread.MethodProfileData_Get(ProfieName).ShouldBeNull();

            Func<string> Func = () =>
                {
                Thread.Sleep(millisecondsTimeout: 10);
                return "abc";
                };

            Func = Func.Profile(ProfieName);

            lock (Func)
                {
                Func();
                Func();
                Func();
                Func();
                Func();

                var Result = L.Thread.MethodProfileData_Get(ProfieName);

                Result.Times.Count.ShouldBe(Expected: 5);
                Result.AverageMS.Should().BeInRange(minimumValue: 5, maximumValue: 25);
                Result.Data.Count().ShouldBe(Expected: 5u);
                Result.Data.Should().Equal("abc", "abc", "abc", "abc", "abc");
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.Profile) + "(Func<T1, U>, String) => Func<T1, U>")]
        public void ProfileFuncString_2()
            {
            L.Thread.MethodProfileData_Remove("TestProfile");

            L.Thread.MethodProfileData_Get("TestProfile").ShouldBeNull();

            Func<string, string> Func = Str =>
                {
                Str.ShouldBe("abc");
                Thread.Sleep(millisecondsTimeout: 10);
                return "abc";
                };

            Func = Func.Profile("TestProfile");

            lock (Func)
                {
                Func("abc").ShouldBe("abc");
                Func("abc").ShouldBe("abc");
                Func("abc").ShouldBe("abc");
                Func("abc").ShouldBe("abc");
                Func("abc").ShouldBe("abc");

                var Result = L.Thread.MethodProfileData_Get("TestProfile");

                Result.Times.Count.ShouldBe(Expected: 5);
                Result.AverageMS.Should().BeInRange(minimumValue: 5, maximumValue: 25);
                Result.Data.Count().ShouldBe(Expected: 5u);
                Result.Data.Should().Equal("abc", "abc", "abc", "abc", "abc");
                }
            }

        [Fact]
        [TestCategory(Category)]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ThreadExt) + "." +
            nameof(ThreadExt.CountExecutions) + "(Action, UInt32) => UInt32")]
        public void CountExecutions()
            {
            var Act = new Action(() => { Thread.Sleep(millisecondsTimeout: 2); });

            Act.CountExecutions(Milliseconds: 100).Should().BeInRange(minimumValue: 30, maximumValue: 50);
            }
        }
    }