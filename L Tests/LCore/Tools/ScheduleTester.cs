using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    public partial class ScheduleTester : XUnitOutputTester, IDisposable
        {
        public ScheduleTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule) + "." + nameof(Schedule.ToString) + "() => String")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(Schedule) + "." + nameof(Schedule.FromString) + "(String) => Schedule")]
        public new void ToString()
            {
            var Date = DateTime.Now.AddMinutes(value: 20);
            var Date2 = DateTime.Now.AddDays(value: 2);

            var Test = new Schedule
                {
                TimesOfDay = new List<DateTime> { Date, Date2 },
                // ReSharper disable ArgumentsStyleLiteral
                DaysOfMonth = new List<int> { 5, 15, 20 },
                // ReSharper restore ArgumentsStyleLiteral
                DaysOfWeek = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Thursday },
                Mode = Schedule.ScheduleMode.Daily,
                OneTimeScheduleDate = Date2
                };

            Test.DaysOfMonth.Should().Equal(5, 15, 20);
            Test.DaysOfWeek.Should().Equal(DayOfWeek.Saturday, DayOfWeek.Thursday);
            Test.Mode.ShouldBe(Schedule.ScheduleMode.Daily);
            Test.TimesOfDay.Should().Equal(Date, Date2);
            Test.OneTimeScheduleDate.ShouldBe(Date2);

            string Str = Test.ToString();

            Str.ShouldBe($"Daily|Saturday,Thursday|{Date},{Date2}");

            var Test2 = Schedule.FromString(Str);

            Test2.ToString().ShouldBe(Str);

            Test.Mode = Schedule.ScheduleMode.Monthly;

            Str = Test.ToString();

            Str.ShouldBe("Monthly|5,15,20");

            Test2 = Schedule.FromString(Str);

            Test2.ToString().ShouldBe(Str);

            Test.Mode = Schedule.ScheduleMode.Manual;

            Str = Test.ToString();

            Str.ShouldBe("Manual");

            Test2 = Schedule.FromString(Str);

            Test2.ToString().ShouldBe(Str);

            Test.Mode = Schedule.ScheduleMode.OneTime;

            Str = Test.ToString();

            Str.ShouldBe($"OneTime|{Date2}");

            Test2 = Schedule.FromString(Str);

            Test2.ToString().ShouldBe(Str);

            L.A(() => Schedule.FromString($"BadEnum|{Date2}")).ShouldFail();
            L.A(() => Schedule.FromString($"Daily|Saturday,Thursday,Blurnsday|{Date},{Date2}")).ShouldFail();

            }

        }
    }