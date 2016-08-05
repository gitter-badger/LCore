using LCore.Extensions;
using System;
using FluentAssertions;
using LCore.LUnit.Fluent;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, StaticMethods)]
    public class DateTest
        {
        [Fact]
        public void Test_MonthNumberGetName()
            {
            L.Date.MonthNumberGetName(1).Should().Be("January");
            L.Date.MonthNumberGetName(2).Should().Be("February");
            L.Date.MonthNumberGetName(3).Should().Be("March");
            L.Date.MonthNumberGetName(4).Should().Be("April");
            L.Date.MonthNumberGetName(5).Should().Be("May");
            L.Date.MonthNumberGetName(6).Should().Be("June");
            L.Date.MonthNumberGetName(7).Should().Be("July");
            L.Date.MonthNumberGetName(8).Should().Be("August");
            L.Date.MonthNumberGetName(9).Should().Be("September");
            L.Date.MonthNumberGetName(10).Should().Be("October");
            L.Date.MonthNumberGetName(11).Should().Be("November");
            L.Date.MonthNumberGetName(12).Should().Be("December");

            L.A(() => L.Date.MonthNumberGetName(0)).ShouldFail();
            L.A(() => L.Date.MonthNumberGetName(13)).ShouldFail();
            }

        [Fact]
        public void Test_DayOfWeek()
            {
            L.Date.GetDayNumber(DayOfWeek.Sunday).Should().Be(0);
            L.Date.GetDayNumber(DayOfWeek.Monday).Should().Be(1);
            L.Date.GetDayNumber(DayOfWeek.Tuesday).Should().Be(2);
            L.Date.GetDayNumber(DayOfWeek.Wednesday).Should().Be(3);
            L.Date.GetDayNumber(DayOfWeek.Thursday).Should().Be(4);
            L.Date.GetDayNumber(DayOfWeek.Friday).Should().Be(5);
            L.Date.GetDayNumber(DayOfWeek.Saturday).Should().Be(6);
            L.Date.GetDayNumber(default(DayOfWeek)).Should().Be(0);
            }
        }
    }