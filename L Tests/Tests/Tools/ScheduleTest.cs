﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests.Tools
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
    public class ScheduleTest
        {
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void TestSchedule()
            {
            var Date = DateTime.Now.AddMinutes(value: 20);
            var Date2 = DateTime.Now.AddDays(value: 2);

            var Test = new Schedule
                {
                TimesOfDay = new List<DateTime> {Date, Date2},
                // ReSharper disable ArgumentsStyleLiteral
                DaysOfMonth = new List<int> {5, 15, 20},
                // ReSharper restore ArgumentsStyleLiteral
                DaysOfWeek = new List<DayOfWeek> {DayOfWeek.Saturday, DayOfWeek.Thursday},
                Mode = Schedule.ScheduleMode.Daily,
                OneTimeScheduleDate = Date2
                };

            Test.DaysOfMonth.Should().Equal(5, 15, 20);
            Test.DaysOfWeek.Should().Equal(DayOfWeek.Saturday, DayOfWeek.Thursday);
            Test.Mode.Should().Be(Schedule.ScheduleMode.Daily);
            Test.TimesOfDay.Should().Equal(Date, Date2);
            Test.OneTimeScheduleDate.Should().Be(Date2);

            string Str = Test.ToString();

            Str.Should().Be($"Daily|Saturday,Thursday|{Date},{Date2}");

            var Test2 = Schedule.FromString(Str);

            Test2.ToString().Should().Be(Str);

            Test.Mode = Schedule.ScheduleMode.Monthly;

            Str = Test.ToString();

            Str.Should().Be("Monthly|5,15,20");

            Test2 = Schedule.FromString(Str);

            Test2.ToString().Should().Be(Str);

            Test.Mode = Schedule.ScheduleMode.Manual;

            Str = Test.ToString();

            Str.Should().Be("Manual");

            Test2 = Schedule.FromString(Str);

            Test2.ToString().Should().Be(Str);

            Test.Mode = Schedule.ScheduleMode.OneTime;

            Str = Test.ToString();

            Str.Should().Be($"OneTime|{Date2}");

            Test2 = Schedule.FromString(Str);

            Test2.ToString().Should().Be(Str);

            L.A(() => Schedule.FromString($"BadEnum|{Date2}")).ShouldFail();
            L.A(() => Schedule.FromString($"Daily|Saturday,Thursday,Blurnsday|{Date},{Date2}")).ShouldFail();
            }
        }
    }