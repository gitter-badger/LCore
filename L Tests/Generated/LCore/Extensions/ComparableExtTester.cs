using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class ComparableExtTester : XUnitOutputTester
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ComparableExtTester()
            {
            }

        [Fact]
        public void IsEqualTo()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsEqualTo
            }

        [Fact]
        public void IsNotEqualTo()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsNotEqualTo
            }

        [Fact]
        public void IsLessThan()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsLessThan
            }

        [Fact]
        public void IsGreaterThanOrEqual()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsGreaterThanOrEqual
            }

        [Fact]
        public void Max()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Max
            }

        [Fact]
        public void Min()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Min
            }
        [Fact]
        public void IsLessThanOrEqual()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsLessThanOrEqual
            }

        [Fact]
        public void IsGreaterThan()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsGreaterThan
            }
        }
    }