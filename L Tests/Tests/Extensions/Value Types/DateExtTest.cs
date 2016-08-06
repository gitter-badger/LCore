using LCore.Extensions;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;
using LCore.LUnit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class DateExtTest : XUnitOutputTester
        {
        [Fact]
        public void Test_CleanDateString()
            {
            new DateTime(2001, 5, 7, 5, 5, 5).CleanDateString().Should().Be("5-7-2001 5.05.05 AM");
            DateTime.MinValue.CleanDateString().Should().Be("1-1-0001 12.00.00 AM");
            DateTime.MaxValue.CleanDateString().Should().Be("12-31-9999 11.59.59 PM");
            }

        [Fact]
        public void Test_ToSpecification()
            {
            new DateTime(2001, 5, 7, 5, 5, 5).ToSpecification().Should().Be("Mon, 07 May 2001 15:05:05 GMT");
            DateTime.MinValue.ToSpecification().Should().Be("Mon, 01 Jan 1 10:00:00 GMT");
            DateTime.MaxValue.ToSpecification().Should().Be("Fri, 31 Dec 9999 23:59:59 GMT");
            }

        [Fact]
        public void Test_GetMonthName()
            {
            new DateTime(2001, 5, 7, 5, 5, 5).GetMonthName().Should().Be("May");
            DateTime.MinValue.GetMonthName().Should().Be("January");
            DateTime.MaxValue.GetMonthName().Should().Be("December");
            }

        [Fact]
        public void Test_ToTimeString()
            {
            new TimeSpan(5, 8, 10, 12).ToTimeString().Should().Be("5 days");
            new TimeSpan(100, 2, 12, 6).ToTimeString().Should().Be("100 days");
            TimeSpan.MinValue.ToTimeString().Should().Be("-80 centuries");
            TimeSpan.MaxValue.ToTimeString().Should().Be("80 centuries");
            }

        [Fact]
        public void Test_TimeDifference()
            {
            var Date1 = new DateTime(2005, 5, 7, 3, 2, 4);
            var Date2 = new DateTime(2009, 8, 13, 4, 12, 5);
            var Date3 = new DateTime(2005, 5, 7, 3, 2, 14);
            var Date4 = new DateTime(2005, 5, 7, 3, 4, 14);
            var Date5 = new DateTime(2005, 5, 7, 5, 4, 14);
            var Date6 = new DateTime(2005, 5, 8, 5, 4, 14);
            var Date7 = new DateTime(2005, 5, 19, 5, 4, 14);
            var Date8 = new DateTime(2005, 6, 8, 5, 4, 14);

            Date1.TimeDifference(Date2, true).Should().Be("4 years ago");
            Date1.TimeDifference(Date2, false).Should().Be("4 years");
            Date2.TimeDifference(Date1, true).Should().Be("4 years from now");
            Date2.TimeDifference(Date1, false).Should().Be("4 years");

            Date1.TimeDifference(Date3, true).Should().Be("10 seconds ago");
            Date1.TimeDifference(Date4, true).Should().Be("2 minutes ago");
            Date1.TimeDifference(Date5, true).Should().Be("2 hours ago");
            Date1.TimeDifference(Date6, true).Should().Be("1 day ago");
            Date1.TimeDifference(Date7, true).Should().Be("1 week ago");
            Date1.TimeDifference(Date8, true).Should().Be("1 month ago");
            Date1.TimeDifference(Date1, true).Should().Be("Just now");
            DateTime.MinValue.TimeDifference(Date1, true).Should().Be("Never");
            Date1.TimeDifference(DateTime.MinValue, true).Should().Be("Never");
            }

        [Fact]
        public void Test_IsFuture()
            {
            new DateTime(2001, 5, 7, 5, 5, 5).IsFuture().Should().BeFalse();
            DateTime.MinValue.IsFuture().Should().BeFalse();
            DateTime.MaxValue.IsFuture().Should().BeTrue();
            }

        [Fact]
        public void Test_IsPast()
            {
            new DateTime(2001, 5, 7, 5, 5, 5).IsPast().Should().BeTrue();
            DateTime.MinValue.IsPast().Should().BeTrue();
            DateTime.MaxValue.IsPast().Should().BeFalse();
            }

        [Fact]
        public void Test_Average()
            {
            var Test = new TimeSpan(1, 0, 0, 40);
            var Test2 = new TimeSpan(5, 2, 6, 40);
            var Test3 = new TimeSpan(8, 2, 6, 40);
            var Test4 = new TimeSpan(0, 0, 0, 40);
            var Test5 = new TimeSpan(0, 0, 0, 40);

            new[] {Test, Test2, Test3, Test4, Test5}.Average().Should().Be(new TimeSpan(2, 20, 3, 4));

            new TimeSpan[] {}.Average().Should().Be(new TimeSpan(0));
            }

        public DateExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }