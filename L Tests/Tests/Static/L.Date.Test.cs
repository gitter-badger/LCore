using LCore.Extensions;
using System;
using FluentAssertions;
using LCore.LUnit.Fluent;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace LCore.Tests.Extensions
    {
    [Trait(Category, StaticMethods)]
    public class DateTest
        {
        [Fact]
        public void Test_MonthNumberGetName()
            {
            L.Date.MonthNumberGetName(Month: 1).Should().Be("January");
            L.Date.MonthNumberGetName(Month: 2).Should().Be("February");
            L.Date.MonthNumberGetName(Month: 3).Should().Be("March");
            L.Date.MonthNumberGetName(Month: 4).Should().Be("April");
            L.Date.MonthNumberGetName(Month: 5).Should().Be("May");
            L.Date.MonthNumberGetName(Month: 6).Should().Be("June");
            L.Date.MonthNumberGetName(Month: 7).Should().Be("July");
            L.Date.MonthNumberGetName(Month: 8).Should().Be("August");
            L.Date.MonthNumberGetName(Month: 9).Should().Be("September");
            L.Date.MonthNumberGetName(Month: 10).Should().Be("October");
            L.Date.MonthNumberGetName(Month: 11).Should().Be("November");
            L.Date.MonthNumberGetName(Month: 12).Should().Be("December");

            L.A(() => L.Date.MonthNumberGetName(Month: 0)).ShouldFail();
            L.A(() => L.Date.MonthNumberGetName(Month: 13)).ShouldFail();
            }

        [Fact]
        public void Test_DayOfWeek()
            {
            L.Date.GetDayNumber(DayOfWeek.Sunday).Should().Be(expected: 0);
            L.Date.GetDayNumber(DayOfWeek.Monday).Should().Be(expected: 1);
            L.Date.GetDayNumber(DayOfWeek.Tuesday).Should().Be(expected: 2);
            L.Date.GetDayNumber(DayOfWeek.Wednesday).Should().Be(expected: 3);
            L.Date.GetDayNumber(DayOfWeek.Thursday).Should().Be(expected: 4);
            L.Date.GetDayNumber(DayOfWeek.Friday).Should().Be(expected: 5);
            L.Date.GetDayNumber(DayOfWeek.Saturday).Should().Be(expected: 6);
            L.Date.GetDayNumber(default(DayOfWeek)).Should().Be(expected: 0);
            }
        }
    }