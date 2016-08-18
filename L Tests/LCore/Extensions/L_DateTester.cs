using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    public partial class L_DateTester : XUnitOutputTester, IDisposable
        {
        public L_DateTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Date) + "." +
            nameof(L.Date.MonthNumberGetName) + "(Int32) => String")]
        public void MonthNumberGetName()
            {
            L.Date.MonthNumberGetName(Month: 1).ShouldBe("January");
            L.Date.MonthNumberGetName(Month: 2).ShouldBe("February");
            L.Date.MonthNumberGetName(Month: 3).ShouldBe("March");
            L.Date.MonthNumberGetName(Month: 4).ShouldBe("April");
            L.Date.MonthNumberGetName(Month: 5).ShouldBe("May");
            L.Date.MonthNumberGetName(Month: 6).ShouldBe("June");
            L.Date.MonthNumberGetName(Month: 7).ShouldBe("July");
            L.Date.MonthNumberGetName(Month: 8).ShouldBe("August");
            L.Date.MonthNumberGetName(Month: 9).ShouldBe("September");
            L.Date.MonthNumberGetName(Month: 10).ShouldBe("October");
            L.Date.MonthNumberGetName(Month: 11).ShouldBe("November");
            L.Date.MonthNumberGetName(Month: 12).ShouldBe("December");

            L.A(() => L.Date.MonthNumberGetName(Month: 0)).ShouldFail();
            L.A(() => L.Date.MonthNumberGetName(Month: 13)).ShouldFail();
            }

        [Fact]
        public void TestDayOfWeek()
            {
            L.Date.GetDayNumber(DayOfWeek.Sunday).ShouldBe(Expected: 0);
            L.Date.GetDayNumber(DayOfWeek.Monday).ShouldBe(Expected: 1);
            L.Date.GetDayNumber(DayOfWeek.Tuesday).ShouldBe(Expected: 2);
            L.Date.GetDayNumber(DayOfWeek.Wednesday).ShouldBe(Expected: 3);
            L.Date.GetDayNumber(DayOfWeek.Thursday).ShouldBe(Expected: 4);
            L.Date.GetDayNumber(DayOfWeek.Friday).ShouldBe(Expected: 5);
            L.Date.GetDayNumber(DayOfWeek.Saturday).ShouldBe(Expected: 6);
            L.Date.GetDayNumber(default(DayOfWeek)).ShouldBe(Expected: 0);
            }
        }
    }