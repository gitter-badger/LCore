
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using FluentAssertions;
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
            var TestAction = new Action(() => { Success = true; });

            lock (TestAction)
                {
                TestAction.Async()();
                Success.Should().BeFalse();

                Thread.Sleep(20);

                Success.Should().BeTrue();
                }
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Profile()
            {
            const string ProfileName = "TestProfile";

            L.Thread.MethodProfileCache.SafeRemove(ProfileName);
            L.Thread.MethodProfileCache.ContainsKey(ProfileName).Should().BeFalse();

            var Action = new Action(() =>
                {
                    int Wait = new Random().Next(25, 50);
                    Thread.Sleep(Wait);

                }).Profile(ProfileName);

            Action.Repeat(5)();

            var Profile = L.Thread.MethodProfileCache[ProfileName];

            Profile.AverageMS.Should().BeInRange(25, 50);

            L.Thread.MethodProfileCache.SafeRemove(ProfileName);
            L.Thread.MethodProfileCache.ContainsKey(ProfileName).Should().BeFalse();
            }
        }
    }
