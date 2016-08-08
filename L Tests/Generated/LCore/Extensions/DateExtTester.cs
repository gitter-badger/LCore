using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class DateExtTester : XUnitOutputTester
        {
        public DateExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~DateExtTester()
            {
            }

        [Fact]
        public void ToSpecification()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.ToSpecification
            }

        [Fact]
        public void GetMonthName()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.GetMonthName
            }
        [Fact]
        public void Average()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.Average
            }

        [Fact]
        public void DayOfWeekNumber()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.DayOfWeekNumber
            }

        [Fact]
        public void CleanDateString()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.CleanDateString
            }

        [Fact]
        public void ToTimeString()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.ToTimeString
            }

        [Fact]
        public void TimeDifference()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.TimeDifference
            }

        [Fact]
        public void IsPast()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.IsPast
            }

        [Fact]
        public void IsFuture()
            {
            // TODO: Implement method test LCore.Extensions.DateExt.IsFuture
            }
        }
    }