﻿using System;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tests;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement

namespace L_Tests.Tests.Tools
    {
    [TestClass]
    public class StatMonitorTest
        {
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [TestMethod]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_StatMonitor()
            {
            L.A(() => new StatMonitor(-1)).ShouldFail();
            L.A(() => new StatMonitor(0)).ShouldFail();

            var Test = new StatMonitor(10);

            Test.GetCurrentAverageStat().Should().Be(double.NaN);

            Test.AddStat(1);
            Test.AddStat(2);
            Test.AddStat(3);
            Test.AddStat(4);
            Test.AddStat(5);
            Test.AddStat(6);
            Test.AddStat(7);
            Test.AddStat(8);
            Test.AddStat(9);
            Test.AddStat(10);

            Test.GetCurrentAverageStat().Should().Be(5.5);

            Test.AddStat(11);
            Test.AddStat(12);
            Test.AddStat(13);
            Test.AddStat(14);
            Test.AddStat(15);
            Test.AddStat(16);
            Test.AddStat(17);
            Test.AddStat(18);
            Test.AddStat(19);
            Test.AddStat(20);

            Test.GetCurrentAverageStat().Should().Be(15.5);
            }
        }
    }