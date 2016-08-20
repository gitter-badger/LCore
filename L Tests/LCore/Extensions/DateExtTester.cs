using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantExtendsListEntry
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    public partial class DateExtTester : XUnitOutputTester
        {
        public DateExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        ~DateExtTester() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.Average) + "(IEnumerable<TimeSpan>) => TimeSpan")]
        public void Average()
            {
            var Test = new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 40);
            var Test2 = new TimeSpan(days: 5, hours: 2, minutes: 6, seconds: 40);
            var Test3 = new TimeSpan(days: 8, hours: 2, minutes: 6, seconds: 40);
            var Test4 = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 40);
            var Test5 = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 40);

            new[] {Test, Test2, Test3, Test4, Test5}.Average().ShouldBe(new TimeSpan(days: 2, hours: 20, minutes: 3, seconds: 4));

            new TimeSpan[] {}.Average().ShouldBe(new TimeSpan(ticks: 0));
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.CleanDateString) + "(DateTime) => String")]
        public void CleanDateString()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).CleanDateString().ShouldBe("5-7-2001 5.05.05 AM");
            DateTime.MinValue.CleanDateString().ShouldBe("1-1-0001 12.00.00 AM");
            DateTime.MaxValue.CleanDateString().ShouldBe("12-31-9999 11.59.59 PM");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.ToSpecification) + "(DateTime) => String")]
        public void ToSpecification()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).ToUniversalTime().ToSpecification().ShouldBe("Mon, 07 May 2001 15:05:05 GMT");
            DateTime.MinValue.ToSpecification().ShouldBe("Mon, 01 Jan 1 10:00:00 GMT");
            DateTime.MaxValue.ToSpecification().ShouldBe("Fri, 31 Dec 9999 23:59:59 GMT");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.GetMonthName) + "(DateTime) => String")]
        public void GetMonthName()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).GetMonthName().ShouldBe("May");
            DateTime.MinValue.GetMonthName().ShouldBe("January");
            DateTime.MaxValue.GetMonthName().ShouldBe("December");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.ToTimeString) + "(TimeSpan) => String")]
        public void ToTimeString()
            {
            new TimeSpan(days: 5, hours: 8, minutes: 10, seconds: 12).ToTimeString().ShouldBe("5 days");
            new TimeSpan(days: 100, hours: 2, minutes: 12, seconds: 6).ToTimeString().ShouldBe("100 days");
            TimeSpan.MinValue.ToTimeString().ShouldBe("-80 centuries");
            TimeSpan.MaxValue.ToTimeString().ShouldBe("80 centuries");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.TimeDifference) + "(DateTime, DateTime, Boolean) => String")]
        public void TimeDifference()
            {
            var Date1 = new DateTime(year: 2005, month: 5, day: 7, hour: 3, minute: 2, second: 4);
            var Date2 = new DateTime(year: 2009, month: 8, day: 13, hour: 4, minute: 12, second: 5);
            var Date3 = new DateTime(year: 2005, month: 5, day: 7, hour: 3, minute: 2, second: 14);
            var Date4 = new DateTime(year: 2005, month: 5, day: 7, hour: 3, minute: 4, second: 14);
            var Date5 = new DateTime(year: 2005, month: 5, day: 7, hour: 5, minute: 4, second: 14);
            var Date6 = new DateTime(year: 2005, month: 5, day: 8, hour: 5, minute: 4, second: 14);
            var Date7 = new DateTime(year: 2005, month: 5, day: 19, hour: 5, minute: 4, second: 14);
            var Date8 = new DateTime(year: 2005, month: 6, day: 8, hour: 5, minute: 4, second: 14);

            Date1.TimeDifference(Date2, IncludeAgo: true).ShouldBe("4 years ago");
            Date1.TimeDifference(Date2, IncludeAgo: false).ShouldBe("4 years");
            Date2.TimeDifference(Date1, IncludeAgo: true).ShouldBe("4 years from now");
            Date2.TimeDifference(Date1, IncludeAgo: false).ShouldBe("4 years");

            Date1.TimeDifference(Date3, IncludeAgo: true).ShouldBe("10 seconds ago");
            Date1.TimeDifference(Date4, IncludeAgo: true).ShouldBe("2 minutes ago");
            Date1.TimeDifference(Date5, IncludeAgo: true).ShouldBe("2 hours ago");
            Date1.TimeDifference(Date6, IncludeAgo: true).ShouldBe("1 day ago");
            Date1.TimeDifference(Date7, IncludeAgo: true).ShouldBe("1 week ago");
            Date1.TimeDifference(Date8, IncludeAgo: true).ShouldBe("1 month ago");
            Date1.TimeDifference(Date1, IncludeAgo: true).ShouldBe("Just now");
            DateTime.MinValue.TimeDifference(Date1, IncludeAgo: true).ShouldBe("Never");
            Date1.TimeDifference(DateTime.MinValue, IncludeAgo: true).ShouldBe("Never");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.IsPast) + "(DateTime) => Boolean")]
        public void IsPast()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).IsPast().ShouldBeTrue();
            DateTime.MinValue.IsPast().ShouldBeTrue();
            DateTime.MaxValue.IsPast().ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.IsFuture) + "(DateTime) => Boolean")]
        public void IsFuture()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).IsFuture().ShouldBeFalse();
            DateTime.MinValue.IsFuture().ShouldBeFalse();
            DateTime.MaxValue.IsFuture().ShouldBeTrue();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.DayOfWeekNumber) + "(DayOfWeek) => Int32")]
        public void DayOfWeekNumber()
            {
            // Attribute Tests Implemented
            }
        }
    }