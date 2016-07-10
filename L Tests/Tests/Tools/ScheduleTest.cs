using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L_Tests.Tests.Tools
    {
    [TestClass]
    public class ScheduleTest
        {
        [TestMethod]
        [TestCategory(L.Test.Categories.Tools)]
        public void TestSchedule()
            {
            var Date = DateTime.Now.AddMinutes(20);
            var Date2 = DateTime.Now.AddDays(2);

            var Test = new Schedule
                {
                TimesOfDay = new List<DateTime> { Date, Date2 },
                DaysOfMonth = new List<int> { 5, 15, 20 },
                DaysOfWeek = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Thursday },
                Mode = Schedule.ScheduleMode.Daily,
                OneTimeScheduleDate = Date2
                };

            Test.DaysOfMonth.ShouldBeEquivalentTo(new List<int> { 5, 15, 20 });
            Test.DaysOfWeek.ShouldBeEquivalentTo(new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Thursday });
            Test.Mode.ShouldBeEquivalentTo(Schedule.ScheduleMode.Daily);
            Test.TimesOfDay.ShouldBeEquivalentTo(new List<DateTime> { Date, Date2 });
            Test.OneTimeScheduleDate.ShouldBeEquivalentTo(Date2);

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

            }
        }
    }
