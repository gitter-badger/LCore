using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantExtendsListEntry
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt))]
    public partial class DateExtTester : XUnitOutputTester
        {
        public DateExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        ~DateExtTester() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.Average) + "(IEnumerable`1<TimeSpan>) => TimeSpan")]
        public void Average()
            {
            var Test = new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 40);
            var Test2 = new TimeSpan(days: 5, hours: 2, minutes: 6, seconds: 40);
            var Test3 = new TimeSpan(days: 8, hours: 2, minutes: 6, seconds: 40);
            var Test4 = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 40);
            var Test5 = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 40);

            new[] {Test, Test2, Test3, Test4, Test5}.Average().Should().Be(new TimeSpan(days: 2, hours: 20, minutes: 3, seconds: 4));

            new TimeSpan[] {}.Average().Should().Be(new TimeSpan(ticks: 0));
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.CleanDateString) + "(DateTime) => String")]
        public void CleanDateString()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).CleanDateString().Should().Be("5-7-2001 5.05.05 AM");
            DateTime.MinValue.CleanDateString().Should().Be("1-1-0001 12.00.00 AM");
            DateTime.MaxValue.CleanDateString().Should().Be("12-31-9999 11.59.59 PM");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.ToSpecification) + "(DateTime) => String")]
        public void ToSpecification()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).ToSpecification().Should().Be("Mon, 07 May 2001 15:05:05 GMT");
            DateTime.MinValue.ToSpecification().Should().Be("Mon, 01 Jan 1 10:00:00 GMT");
            DateTime.MaxValue.ToSpecification().Should().Be("Fri, 31 Dec 9999 23:59:59 GMT");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.GetMonthName) + "(DateTime) => String")]
        public void GetMonthName()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).GetMonthName().Should().Be("May");
            DateTime.MinValue.GetMonthName().Should().Be("January");
            DateTime.MaxValue.GetMonthName().Should().Be("December");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.ToTimeString) + "(TimeSpan) => String")]
        public void ToTimeString()
            {
            new TimeSpan(days: 5, hours: 8, minutes: 10, seconds: 12).ToTimeString().Should().Be("5 days");
            new TimeSpan(days: 100, hours: 2, minutes: 12, seconds: 6).ToTimeString().Should().Be("100 days");
            TimeSpan.MinValue.ToTimeString().Should().Be("-80 centuries");
            TimeSpan.MaxValue.ToTimeString().Should().Be("80 centuries");
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

            Date1.TimeDifference(Date2, IncludeAgo: true).Should().Be("4 years ago");
            Date1.TimeDifference(Date2, IncludeAgo: false).Should().Be("4 years");
            Date2.TimeDifference(Date1, IncludeAgo: true).Should().Be("4 years from now");
            Date2.TimeDifference(Date1, IncludeAgo: false).Should().Be("4 years");

            Date1.TimeDifference(Date3, IncludeAgo: true).Should().Be("10 seconds ago");
            Date1.TimeDifference(Date4, IncludeAgo: true).Should().Be("2 minutes ago");
            Date1.TimeDifference(Date5, IncludeAgo: true).Should().Be("2 hours ago");
            Date1.TimeDifference(Date6, IncludeAgo: true).Should().Be("1 day ago");
            Date1.TimeDifference(Date7, IncludeAgo: true).Should().Be("1 week ago");
            Date1.TimeDifference(Date8, IncludeAgo: true).Should().Be("1 month ago");
            Date1.TimeDifference(Date1, IncludeAgo: true).Should().Be("Just now");
            DateTime.MinValue.TimeDifference(Date1, IncludeAgo: true).Should().Be("Never");
            Date1.TimeDifference(DateTime.MinValue, IncludeAgo: true).Should().Be("Never");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.IsPast) + "(DateTime) => Boolean")]
        public void IsPast()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).IsPast().Should().BeTrue();
            DateTime.MinValue.IsPast().Should().BeTrue();
            DateTime.MaxValue.IsPast().Should().BeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.IsFuture) + "(DateTime) => Boolean")]
        public void IsFuture()
            {
            new DateTime(year: 2001, month: 5, day: 7, hour: 5, minute: 5, second: 5).IsFuture().Should().BeFalse();
            DateTime.MinValue.IsFuture().Should().BeFalse();
            DateTime.MaxValue.IsFuture().Should().BeTrue();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.DayOfWeekNumber) + "(DayOfWeek) => Int32")]
        public void DayOfWeekNumber()
            {
            // Attribute Tests Implemented
            }
        }
    }