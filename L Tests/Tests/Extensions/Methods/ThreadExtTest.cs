﻿
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using LCore.Tools;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    public class ThreadExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ThreadExt) };

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Async()
            {
            bool Success = false;
            var TestAction = new Action(() =>
            {
                Thread.Sleep(20);
                Success = true;
            });

            lock (TestAction)
                {
                TestAction.Async()();
                Success.Should().BeFalse();

                Thread.Sleep(40);

                Success.Should().BeTrue();
                }

            ((Action)null).Async()();
            }
        [Fact]
        public void Test_AsyncTimeLimit()
            {
            bool Success = false;
            var TestAction = new Action(() =>
            {
                Thread.Sleep(30);
                Success = true;
            });

            Thread.Sleep(40);
            lock (TestAction)
                {
                TestAction.Async(20)();
                Success.Should().BeFalse();

                Thread.Sleep(40);

                Success.Should().BeFalse();

                TestAction.Async(50)();
                Success.Should().BeFalse();
                Thread.Sleep(50);

                Success.Should().BeTrue();

                TestAction();
                }
            }
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Async_T()
            {
            string Success = "";
            var TestAction = new Action<string>(Str => { Success = Str; });

            lock (TestAction)
                {
                TestAction.Async()("abc");
                Success.Should().Be("");

                Thread.Sleep(30);

                Success.Should().Be("abc");
                }

            ((Action<string>)null).Async()("");
            }
        [Fact]
        public void Test_Async_T_TimeLimit()
            {
            string Result = "";
            var TestAction = new Action<string>(Str =>
            {
                Thread.Sleep(30);
                Result = Str;
            });

            Thread.Sleep(40);

            lock (TestAction)
                {
                TestAction.Async(20)("abc");
                Result.Should().Be("");

                Thread.Sleep(40);

                Result.Should().Be("");

                TestAction.Async(50)("abc");
                Result.Should().Be("");
                Thread.Sleep(50);

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
                TestAction.Async(Result =>
                    {
                        Result.Should().Be("yes");
                    })();

                Thread.Sleep(20);
                }

            ((Func<string>)null).Async(null)();
            }
        [Fact]
        public void Test_Async_Func_T()
            {
            var TestAction = new Func<string, string>(Str => $"{Str}yes");

            lock (TestAction)
                {
                bool Success = false;
                TestAction.Async(Result =>
                    {
                        Result.Should().Be("abcyes");
                        Success = true;
                    })("abc");

                Thread.Sleep(1000);

                Success.Should().BeTrue();
                }

            ((Func<string, string>)null).Async(null)("abc");
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_MethodProfileCache()
            {
            const string ProfileName = "TestProfile";

            L.Thread.MethodProfileCache.SafeRemove(ProfileName);
            L.Thread.MethodProfileCache.ContainsKey(ProfileName).Should().BeFalse();

            var Action = new Action(() =>
                {
                    int Wait = new Random().Next(25, 50);
                    Thread.Sleep(Wait);

                }).Profile(ProfileName).Repeat(5);

            lock (Action)
                {
                Action();

                var Profile = L.Thread.MethodProfileCache[ProfileName];

                Profile.AverageMS.Should().BeInRange(25, 55);
                Profile.Times.Count.Should().Be(6);

                L.Thread.MethodProfileCache.SafeRemove(ProfileName);
                L.Thread.MethodProfileCache.ContainsKey(ProfileName).Should().BeFalse();
                }
            }

        [Fact]
        public void Test_Profile()
            {
            Action Act = () => Thread.Sleep(10);
            lock (Act)
                {
                Act.Profile().Should().BeCloseTo(new TimeSpan(0, 0, 0, 0, 10), 30);
                Act.Profile(5).Should().BeCloseTo(new TimeSpan(0, 0, 0, 0, 50), 30);

                ((Action)null).Profile().Should().BeCloseTo(new TimeSpan(0));
                ((Action)null).Profile(5).Should().BeCloseTo(new TimeSpan(0));
                }
            }

        [Fact]
        public void Test_ProfileString()
            {
            L.Thread.MethodProfileCache.SafeRemove("TestProfile");

            L.Thread.MethodProfileCache.ContainsKey("TestProfile").Should().BeFalse();

            Action<string> Act = Str =>
                {
                    Str.Should().Be("abc");
                    Thread.Sleep(10);
                };

            Act = Act.Profile("TestProfile");

            lock (Act)
                {
                Act("abc");
                Act("abc");
                Act("abc");
                Act("abc");
                Act("abc");

                var Result = L.Thread.MethodProfileCache["TestProfile"];

                Result.Times.Count.Should().Be(5);
                Result.AverageMS.Should().BeInRange(8, 20);
                Result.Data.Count().Should().Be(0);
                }
            }

        [Fact]
        public void Test_ProfileFunc()
            {
            Func<int> Func = () =>
                {
                    int Rand = new Random().Next(50, 70);
                    Thread.Sleep(Rand);
                    return Rand;
                };

            Thread.Sleep(50);

            lock (Func)
                {
                MethodProfileData<int> Result = Func.Profile();

                Result.AverageMS.Should().BeInRange(45, 75);
                Result.Data.Count().Should().Be(1);
                Result.Data.GetAt(0).Should().BeInRange(45, 75);


                Result = Func.Profile(5);

                Result.AverageMS.Should().BeInRange(45, 95);
                Result.Data.Count().Should().Be(6);
                }
            }
        [Fact]
        public void Test_ProfileFuncString()
            {
            L.Thread.MethodProfileCache.SafeRemove("TestProfile");

            L.Thread.MethodProfileCache.ContainsKey("TestProfile").Should().BeFalse();

            Func<string> Func = () =>
            {
                Thread.Sleep(10);
                return "abc";
            };

            Func = Func.Profile("TestProfile");

            lock (Func)
                {
                Func();
                Func();
                Func();
                Func();
                Func();

                var Result = L.Thread.MethodProfileCache["TestProfile"];

                Result.Times.Count.Should().Be(5);
                Result.AverageMS.Should().BeInRange(8, 15);
                Result.Data.Count().Should().Be(5);
                Result.Data.Should().Equal("abc", "abc", "abc", "abc", "abc");
                }
            }
        [Fact]
        public void Test_ProfileFuncString_2()
            {
            L.Thread.MethodProfileCache.SafeRemove("TestProfile");

            L.Thread.MethodProfileCache.ContainsKey("TestProfile").Should().BeFalse();

            Func<string, string> Func = Str =>
            {
                Str.Should().Be("abc");
                Thread.Sleep(10);
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

                var Result = L.Thread.MethodProfileCache["TestProfile"];

                Result.Times.Count.Should().Be(5);
                Result.AverageMS.Should().BeInRange(8, 18);
                Result.Data.Count().Should().Be(5);
                Result.Data.Should().Equal("abc", "abc", "abc", "abc", "abc");
                }
            }

        [Fact]
        public void Test_CountExecutions()
            {
            var Act = new Action(() =>
                {
                    Thread.Sleep(2);
                });

            Act.CountExecutions(100).Should().BeInRange(30, 50);
            }
        }
    }