using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt))]
    public partial class ComparableExtTester : XUnitOutputTester, IDisposable
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsEqualTo) + "(IComparable, IComparable) => Boolean")]
        public void IsEqualTo()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsEqualTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsNotEqualTo) + "(IComparable, IComparable) => Boolean")]
        public void IsNotEqualTo()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsNotEqualTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsLessThan) + "(IComparable, IComparable) => Boolean")]
        public void IsLessThan()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsLessThan
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsLessThanOrEqual) + "(IComparable, IComparable) => Boolean")]
        public void IsLessThanOrEqual()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsLessThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsGreaterThan) + "(IComparable, IComparable) => Boolean")]
        public void IsGreaterThan()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsGreaterThan
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsGreaterThanOrEqual) + "(IComparable, IComparable) => Boolean")]
        public void IsGreaterThanOrEqual()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.IsGreaterThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.Max) + "(T, T[]) => T")]
        public void Max_T_T_T()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Max
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.Max) + "(IEnumerable`1<T>, Func`2<T, IComparable>) => T")]
        public void Max_IEnumerable_1_T_Func_2_T_IComparable_T()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Max
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.Min) + "(T, T[]) => T")]
        public void Min_T_T_T()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Min
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.Min) + "(IEnumerable`1<T>, Func`2<T, IComparable>) => T")]
        public void Min_IEnumerable_1_T_Func_2_T_IComparable_T()
            {
            // TODO: Implement method test LCore.Extensions.ComparableExt.Min
            }

        }
    }