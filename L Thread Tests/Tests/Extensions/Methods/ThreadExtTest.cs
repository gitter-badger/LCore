using LCore.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;
using LCore.LUnit;
using LCore.LUnit.Fluent;

// ReSharper disable PossibleNullReferenceException

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class ThreadExtTest : XUnitOutputTester
        {
        public ThreadExtTest([NotNull] ITestOutputHelper Output) : base(Output)
            {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            }

        [Fact]
        public void Test_Async_Action()
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
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeTrue();
                }
            }

        [Fact]
        public void Test_Async_Action_TimeLimit()
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
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test uint
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20u)();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50u)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test long
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20L)();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50L)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test ulong
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20uL)();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.Async(TimeLimitMilliseconds: 50uL)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test TimeSpan
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.Async(TimeSpan.FromMilliseconds(value: 20))();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.Async(TimeSpan.FromMilliseconds(value: 50))();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }
            }

        [Fact]
        public void Test_Async_Action_T()
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
                Success.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 30);

                Success.Should().Be("abc");
                }
            Success = "";

            lock (Success)
                {
                TestAction.Async(ThreadPriority.AboveNormal)("abc");
                Success.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 30);

                Success.Should().Be("abc");
                }
            }

        [Fact]
        public void Test_Async_Action_T_TimeLimit()
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
                Result.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.Should().Be("");

                TestAction.Async(TimeLimitMilliseconds: 50)("abc");
                Result.Should().Be("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.Should().Be("abc");

                TestAction("abc");
                }

            // Test uint
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20u)("abc");
                Result.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.Should().Be("");

                TestAction.Async(TimeLimitMilliseconds: 50u)("abc");
                Result.Should().Be("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.Should().Be("abc");

                TestAction("abc");
                }

            // Test long
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20L)("abc");
                Result.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.Should().Be("");

                TestAction.Async(TimeLimitMilliseconds: 50L)("abc");
                Result.Should().Be("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.Should().Be("abc");

                TestAction("abc");
                }

            // Test long
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeLimitMilliseconds: 20uL)("abc");
                Result.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.Should().Be("");

                TestAction.Async(TimeLimitMilliseconds: 50uL)("abc");
                Result.Should().Be("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.Should().Be("abc");

                TestAction("abc");
                }

            // Test TimeSpan
            Result = "";
            Thread.Sleep(millisecondsTimeout: 40);

            lock (TestAction)
                {
                TestAction.Async(TimeSpan.FromMilliseconds(value: 20))("abc");
                Result.Should().Be("");

                Thread.Sleep(millisecondsTimeout: 40);

                Result.Should().Be("");

                TestAction.Async(TimeSpan.FromMilliseconds(value: 50))("abc");
                Result.Should().Be("");
                Thread.Sleep(millisecondsTimeout: 50);

                Result.Should().Be("abc");

                TestAction("abc");
                }
            }

        [Fact]
        public void Test_Async_Func()
            {
            var TestAction = new Func<string>(() => "yes");

            lock (TestAction)
                {
                TestAction.AsyncResult(Result => { Result.Should().Be("yes"); })();

                Thread.Sleep(millisecondsTimeout: 20);

                TestAction.AsyncResult(Result => { Result.Should().Be("yes"); }, ThreadPriority.AboveNormal)();

                Thread.Sleep(millisecondsTimeout: 20);
                }
            }

        [Fact]
        public void Test_Async_Func_T()
            {
            var TestAction = new Func<string, string>(Str => $"{Str}yes");

            lock (TestAction)
                {
                bool Success = false;
                TestAction.AsyncResult(Result =>
                    {
                    Result.Should().Be("abcyes");
                    Success = true;
                    })("abc");

                Thread.Sleep(millisecondsTimeout: 100);

                Success.Should().BeTrue();

                Success = false;
                TestAction.AsyncResult(Result =>
                    {
                    Result.Should().Be("abcyes");
                    Success = true;
                    }, ThreadPriority.AboveNormal)("abc");

                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();
                }
            }

        [Fact]
        public void Test_Async_Func_U_TimeLimit()
            {
            bool Success = false;
            var TestAction = new Func<string>(() =>
                {
                Thread.Sleep(millisecondsTimeout: 30);
                Success = true;
                return "abc";
                });

            Action<string> TestAction2 = Result => { Result.Should().Be("abc"); };

            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20)();

                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test uint
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20u)();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50u)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test long
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20L)();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50L)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test ulong
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 20uL)();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(TestAction2, TimeLimitMilliseconds: 50uL)();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }

            // test TimeSpan
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(TestAction2, TimeSpan.FromMilliseconds(value: 20))();
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(TestAction2, TimeSpan.FromMilliseconds(value: 50))();
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction();
                }
            }

        [Fact]
        public void Test_Async_Func_T_U_TimeLimit()
            {
            bool Success = false;
            var TestAction = new Func<string, string>(Result =>
                {
                Result.Should().Be("abc");
                Thread.Sleep(millisecondsTimeout: 30);
                Success = true;
                return "abc";
                });

            Action<string> ResultFunction = Result => { Result.Should().Be("abc"); };

            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20)("abc");

                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50)("abc");
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 60);

                Success.Should().BeTrue();

                TestAction("abc");
                }

            // test uint
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20u)("abc");
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50u)("abc");
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 60);

                Success.Should().BeTrue();

                TestAction("abc");
                }

            // test long
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20L)("abc");
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50L)("abc");
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction("abc");
                }

            // test ulong
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 20uL)("abc");
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(ResultFunction, TimeLimitMilliseconds: 50uL)("abc");
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction("abc");
                }

            // test TimeSpan
            Success = false;
            Thread.Sleep(millisecondsTimeout: 40);
            lock (TestAction)
                {
                TestAction.AsyncResult(ResultFunction, TimeSpan.FromMilliseconds(value: 20))("abc");
                Success.Should().BeFalse();

                Thread.Sleep(millisecondsTimeout: 40);

                Success.Should().BeFalse();

                TestAction.AsyncResult(ResultFunction, TimeSpan.FromMilliseconds(value: 50))("abc");
                Success.Should().BeFalse();
                Thread.Sleep(millisecondsTimeout: 50);

                Success.Should().BeTrue();

                TestAction("abc");
                }
            }

        [Fact]
        public void Test_MethodProfileCache()
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
                Profile.Times.Count.Should().Be(expected: 6);

                L.Thread.MethodProfileData_Remove(ProfileName);
                L.Thread.MethodProfileData_Get(ProfileName).ShouldBeNull();
                }
            }

        [Fact]
        public void Test_Profile()
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
        public void Test_ProfileString()
            {
            L.Thread.MethodProfileData_Remove("TestProfile");

            L.Thread.MethodProfileData_Get("TestProfile").ShouldBeNull();

            Action<string> Act = Str =>
                {
                Str.Should().Be("abc");
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

                Result.Times.Count.Should().Be(expected: 5);
                Result.AverageMS.Should().BeInRange(minimumValue: 8, maximumValue: 20);
                Result.Data.Count().Should().Be(expected: 0);
                }
            }

        [Fact]
        public void Test_ProfileFunc()
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
                Result.Data.Count().Should().Be(expected: 1);
                Result.Data.GetAt(Index: 0).Should().BeInRange(minimumValue: 45, maximumValue: 75);


                Result = Func.Profile(Repeat: 5);

                Result.AverageMS.Should().BeInRange(minimumValue: 45, maximumValue: 95);
                Result.Data.Count().Should().Be(expected: 6);
                }
            }

        [Fact]
        public void Test_ProfileFuncString()
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

                Result.Times.Count.Should().Be(expected: 5);
                Result.AverageMS.Should().BeInRange(minimumValue: 5, maximumValue: 25);
                Result.Data.Count().Should().Be(expected: 5);
                Result.Data.Should().Equal("abc", "abc", "abc", "abc", "abc");
                }
            }

        [Fact]
        public void Test_ProfileFuncString_2()
            {
            L.Thread.MethodProfileData_Remove("TestProfile");

            L.Thread.MethodProfileData_Get("TestProfile").ShouldBeNull();

            Func<string, string> Func = Str =>
                {
                Str.Should().Be("abc");
                Thread.Sleep(millisecondsTimeout: 10);
                return "abc";
                };

            Func = Func.Profile("TestProfile");

            lock (Func)
                {
                Func("abc").Should().Be("abc");
                Func("abc").Should().Be("abc");
                Func("abc").Should().Be("abc");
                Func("abc").Should().Be("abc");
                Func("abc").Should().Be("abc");

                var Result = L.Thread.MethodProfileData_Get("TestProfile");

                Result.Times.Count.Should().Be(expected: 5);
                Result.AverageMS.Should().BeInRange(minimumValue: 5, maximumValue: 25);
                Result.Data.Count().Should().Be(expected: 5);
                Result.Data.Should().Equal("abc", "abc", "abc", "abc", "abc");
                }
            }

        [Fact]
        public void Test_CountExecutions()
            {
            var Act = new Action(() => { Thread.Sleep(millisecondsTimeout: 2); });

            Act.CountExecutions(Milliseconds: 100).Should().BeInRange(minimumValue: 30, maximumValue: 50);
            }
        }
    }