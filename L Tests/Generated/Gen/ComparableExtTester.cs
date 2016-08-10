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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt))]
    public partial class ComparableExtTester : XUnitOutputTester
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ComparableExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsEqualTo))]
        public void IsEqualTo()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsEqualTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsNotEqualTo))]
        public void IsNotEqualTo()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsNotEqualTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsLessThan))]
        public void IsLessThan()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsLessThan
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsLessThanOrEqual))]
        public void IsLessThanOrEqual()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsLessThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsGreaterThan))]
        public void IsGreaterThan()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsGreaterThan
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsGreaterThanOrEqual))]
        public void IsGreaterThanOrEqual()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsGreaterThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.Max))]
        public void Max()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Max
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.Min))]
        public void Min()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Min
            }

        }
    }