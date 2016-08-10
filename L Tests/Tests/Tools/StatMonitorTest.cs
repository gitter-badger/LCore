using System;
using FluentAssertions;
using LCore.Extensions;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable ObjectCreationAsStatement

namespace LCore.Tests.Tools
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
    public class StatMonitorTest
        {
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [Fact]
        public void Test_StatMonitor()
            {
            L.A(() => new StatMonitor(-1)).ShouldFail();
            L.A(() => new StatMonitor(WalkingAverageSize: 0)).ShouldFail();

            var Test = new StatMonitor(WalkingAverageSize: 10);

            Test.GetCurrentAverageStat().Should().Be(double.NaN);

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

            Test.GetCurrentAverageStat().Should().Be(expected: 5.5);

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

            Test.GetCurrentAverageStat().Should().Be(expected: 15.5);
            }
        }
    }