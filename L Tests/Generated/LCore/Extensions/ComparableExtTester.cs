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
        public void IsLessThanOrEqual()
            {
            // TODO: Implement method Test LCore.Extensions.ComparableExt.IsLessThanOrEqual
            }

        [Fact]
        public void IsGreaterThan()
            {
            // TODO: Implement method Test LCore.Extensions.ComparableExt.IsGreaterThan
            }
        }
    }