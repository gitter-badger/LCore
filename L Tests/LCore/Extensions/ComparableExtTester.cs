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
    public partial class ComparableExtTester : XUnitOutputTester, IDisposable
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Max) + "(T, T[]) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Max) + "(IEnumerable<T>, Func<T, IComparable>) => T")]
        public void Max()
            {
            ((IComparable) null).Max().ShouldBe(Expected: null);
            ((IComparable) null).Max(1, 2, 3, 14, 5, 6, 7).ShouldBe(Expected: 14);

            50.Max(1, 2, 3, 14, 5, 6, 7).ShouldBe(Expected: 50);
            5.Max(1, 2, 3, 14, 5, 6, 7).ShouldBe(Expected: 14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(Expected: 50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(Expected: 14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("ttt");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Min) + "(T, T[]) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.Min) + "(IEnumerable<T>, Func<T, IComparable>) => T")]
        public void Min()
            {
            ((IComparable) null).Min().ShouldBe(Expected: null);
            ((IComparable) null).Min(1, 2, 3, 14, 5, 6, 7).ShouldBe(Expected: 1);

            50.Min(1, 2, 3, 14, 5, 6, 7).ShouldBe(Expected: 1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).ShouldBe(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(Expected: 1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).ShouldBe(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").ShouldBe("acl");
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsEqualTo) + "(IComparable, IComparable) => Boolean")]
        public void IsEqualTo()
            {
            const int Test = 5;

            Test.IsEqualTo(Obj: 0).ShouldBeFalse();
            Test.IsEqualTo(Obj: 5).ShouldBeTrue();
            Test.IsEqualTo(Obj: 10).ShouldBeFalse();
            Test.IsEqualTo(int.MinValue).ShouldBeFalse();
            Test.IsEqualTo(int.MaxValue).ShouldBeFalse();
            Test.IsEqualTo(default(int)).ShouldBeFalse();

            "abc".IsEqualTo("a").ShouldBeFalse();
            "abc".IsEqualTo("abc").ShouldBeTrue();

            ((IComparable) null).IsEqualTo(default(int)).ShouldBeFalse();
            ((IComparable) null).IsEqualTo(Obj: null).ShouldBeTrue();
            default(int).IsEqualTo(Obj: null).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsNotEqualTo) + "(IComparable, IComparable) => Boolean")]
        public void IsNotEqualTo()
            {
            const int Test = 5;

            Test.IsNotEqualTo(Obj: 0).ShouldBeTrue();
            Test.IsNotEqualTo(Obj: 5).ShouldBeFalse();
            Test.IsNotEqualTo(Obj: 10).ShouldBeTrue();
            Test.IsNotEqualTo(int.MinValue).ShouldBeTrue();
            Test.IsNotEqualTo(int.MaxValue).ShouldBeTrue();
            Test.IsNotEqualTo(default(int)).ShouldBeTrue();

            "abc".IsNotEqualTo("a").ShouldBeTrue();
            "abc".IsNotEqualTo("abc").ShouldBeFalse();

            ((IComparable) null).IsNotEqualTo(default(int)).ShouldBeTrue();
            ((IComparable) null).IsNotEqualTo(Obj: null).ShouldBeFalse();
            default(int).IsNotEqualTo(Obj: null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsLessThan) + "(IComparable, IComparable) => Boolean")]
        public void IsLessThan()
            {
            const int Test = 5;

            Test.IsLessThan(Obj: 0).ShouldBeFalse();
            Test.IsLessThan(Obj: 5).ShouldBeFalse();
            Test.IsLessThan(Obj: 10).ShouldBeTrue();
            Test.IsLessThan(int.MinValue).ShouldBeFalse();
            Test.IsLessThan(int.MaxValue).ShouldBeTrue();
            Test.IsLessThan(default(int)).ShouldBeFalse();

            "abc".IsLessThan("a").ShouldBeFalse();
            "abc".IsLessThan("abc").ShouldBeFalse();
            "abc".IsLessThan("bbc").ShouldBeTrue();

            ((IComparable) null).IsLessThan(default(int)).ShouldBeTrue();
            ((IComparable) null).IsLessThan(Obj: null).ShouldBeFalse();
            default(int).IsLessThan(Obj: null).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsLessThanOrEqual) + "(IComparable, IComparable) => Boolean")]
        public void IsLessThanOrEqual()
            {
            const int Test = 5;

            Test.IsLessThanOrEqual(Obj: 0).ShouldBeFalse();
            Test.IsLessThanOrEqual(Obj: 5).ShouldBeTrue();
            Test.IsLessThanOrEqual(Obj: 10).ShouldBeTrue();
            Test.IsLessThanOrEqual(int.MinValue).ShouldBeFalse();
            Test.IsLessThanOrEqual(int.MaxValue).ShouldBeTrue();
            Test.IsLessThanOrEqual(default(int)).ShouldBeFalse();

            "abc".IsLessThanOrEqual("a").ShouldBeFalse();
            "abc".IsLessThanOrEqual("abc").ShouldBeTrue();
            "abc".IsLessThanOrEqual("bbc").ShouldBeTrue();

            ((IComparable) null).IsLessThanOrEqual(default(int)).ShouldBeTrue();
            ((IComparable) null).IsLessThanOrEqual(Obj: null).ShouldBeTrue();
            default(int).IsLessThanOrEqual(Obj: null).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsGreaterThan) + "(IComparable, IComparable) => Boolean")]
        public void IsGreaterThan()
            {
            const int Test = 5;

            Test.IsGreaterThan(Obj: 0).ShouldBeTrue();
            Test.IsGreaterThan(Obj: 5).ShouldBeFalse();
            Test.IsGreaterThan(Obj: 10).ShouldBeFalse();
            Test.IsGreaterThan(int.MinValue).ShouldBeTrue();
            Test.IsGreaterThan(int.MaxValue).ShouldBeFalse();
            Test.IsGreaterThan(default(int)).ShouldBeTrue();

            "abc".IsGreaterThan("a").ShouldBeTrue();
            "abc".IsGreaterThan("abc").ShouldBeFalse();
            "abc".IsGreaterThan("bbc").ShouldBeFalse();

            ((IComparable) null).IsGreaterThan(default(int)).ShouldBeFalse();
            ((IComparable) null).IsGreaterThan(Obj: null).ShouldBeFalse();
            default(int).IsGreaterThan(Obj: null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." + nameof(ComparableExt.IsGreaterThanOrEqual) + "(IComparable, IComparable) => Boolean")]
        public void IsGreaterThanOrEqual()
            {
            const int Test = 5;

            Test.IsGreaterThanOrEqual(Obj: 0).ShouldBeTrue();
            Test.IsGreaterThanOrEqual(Obj: 5).ShouldBeTrue();
            Test.IsGreaterThanOrEqual(Obj: 10).ShouldBeFalse();
            Test.IsGreaterThanOrEqual(int.MinValue).ShouldBeTrue();
            Test.IsGreaterThanOrEqual(int.MaxValue).ShouldBeFalse();
            Test.IsGreaterThanOrEqual(default(int)).ShouldBeTrue();

            "abc".IsGreaterThanOrEqual("a").ShouldBeTrue();
            "abc".IsGreaterThanOrEqual("abc").ShouldBeTrue();
            "abc".IsGreaterThanOrEqual("bbc").ShouldBeFalse();

            ((IComparable) null).IsGreaterThanOrEqual(default(int)).ShouldBeFalse();
            ((IComparable) null).IsGreaterThanOrEqual(Obj: null).ShouldBeTrue();
            default(int).IsGreaterThanOrEqual(Obj: null).ShouldBeTrue();
            }
        }
    }