using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt))]
    public partial class DateExtTester : XUnitOutputTester
        {
        public DateExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~DateExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.Average))]
        public void Average()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.Average
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.DayOfWeekNumber))]
        public void DayOfWeekNumber()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.DayOfWeekNumber
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.CleanDateString))]
        public void CleanDateString()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.CleanDateString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.ToSpecification))]
        public void ToSpecification()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.ToSpecification
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.GetMonthName))]
        public void GetMonthName()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.GetMonthName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.ToTimeString))]
        public void ToTimeString()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.ToTimeString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.TimeDifference))]
        public void TimeDifference()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.TimeDifference
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.IsPast))]
        public void IsPast()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.IsPast
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.IsFuture))]
        public void IsFuture()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.IsFuture
            }

        }
    }