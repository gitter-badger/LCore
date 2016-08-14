using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt))]
    public partial class ComparableExtTester : XUnitOutputTester, IDisposable
        {
        public ComparableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.IsEqualTo) + "(IComparable, IComparable) => Boolean")]
        public void IsEqualTo()
            {
            const string Test = "abc";

            ((string)null).IsEqualTo((string)null).ShouldBeTrue();
            ((string)null).IsEqualTo("").ShouldBeFalse();
            "".IsEqualTo((string)null).ShouldBeFalse();
            "".IsEqualTo("").ShouldBeTrue();
            Test.IsEqualTo(Test).ShouldBeTrue();

            5.IsEqualTo(Obj: 5).ShouldBeTrue();
            5u.IsEqualTo(Obj: 5u).ShouldBeTrue();
            5uL.IsEqualTo(Obj: 5uL).ShouldBeTrue();
            5f.IsEqualTo(Obj: 5f).ShouldBeTrue();
            5d.IsEqualTo(Obj: 5d).ShouldBeTrue();
            5m.IsEqualTo(Obj: 5m).ShouldBeTrue();
            ((short)5).IsEqualTo((short)5).ShouldBeTrue();
            ((ushort)5).IsEqualTo((ushort)5).ShouldBeTrue();

            5.IsEqualTo(Obj: 6).ShouldBeFalse();
            5u.IsEqualTo(Obj: 6u).ShouldBeFalse();
            5uL.IsEqualTo(Obj: 6uL).ShouldBeFalse();
            5f.IsEqualTo(Obj: 6f).ShouldBeFalse();
            5d.IsEqualTo(Obj: 6d).ShouldBeFalse();
            5m.IsEqualTo(Obj: 6m).ShouldBeFalse();
            ((short)5).IsEqualTo((short)6).ShouldBeFalse();
            ((ushort)5).IsEqualTo((ushort)6).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.IsNotEqualTo) + "(IComparable, IComparable) => Boolean")]
        public void IsNotEqualTo()
            {
            const string Test = "abc";

            ((string)null).IsNotEqualTo((string)null).ShouldBeFalse();
            ((string)null).IsNotEqualTo("").ShouldBeTrue();
            "".IsNotEqualTo((string)null).ShouldBeTrue();
            "".IsNotEqualTo("").ShouldBeFalse();
            Test.IsNotEqualTo(Test).ShouldBeFalse();

            5.IsNotEqualTo(Obj: 5).ShouldBeFalse();
            5u.IsNotEqualTo(Obj: 5u).ShouldBeFalse();
            5uL.IsNotEqualTo(Obj: 5uL).ShouldBeFalse();
            5f.IsNotEqualTo(Obj: 5f).ShouldBeFalse();
            5d.IsNotEqualTo(Obj: 5d).ShouldBeFalse();
            5m.IsNotEqualTo(Obj: 5m).ShouldBeFalse();
            ((short)5).IsNotEqualTo((short)5).ShouldBeFalse();
            ((ushort)5).IsNotEqualTo((ushort)5).ShouldBeFalse();

            5.IsNotEqualTo(Obj: 6).ShouldBeTrue();
            5u.IsNotEqualTo(Obj: 6u).ShouldBeTrue();
            5uL.IsNotEqualTo(Obj: 6uL).ShouldBeTrue();
            5f.IsNotEqualTo(Obj: 6f).ShouldBeTrue();
            5d.IsNotEqualTo(Obj: 6d).ShouldBeTrue();
            5m.IsNotEqualTo(Obj: 6m).ShouldBeTrue();
            ((short)5).IsNotEqualTo((short)6).ShouldBeTrue();
            ((ushort)5).IsNotEqualTo((ushort)6).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.IsLessThan) + "(IComparable, IComparable) => Boolean")]
        public void IsLessThan()
            {
            const string Test = "abc";

            ((string)null).IsLessThan((string)null).ShouldBeFalse();
            ((string)null).IsLessThan("").ShouldBeTrue();
            "".IsLessThan((string)null).ShouldBeFalse();
            "".IsLessThan("").ShouldBeFalse();
            Test.IsLessThan(Test).ShouldBeFalse();

            5.IsLessThan(Obj: 5).ShouldBeFalse();
            5u.IsLessThan(Obj: 5u).ShouldBeFalse();
            5uL.IsLessThan(Obj: 5uL).ShouldBeFalse();
            5f.IsLessThan(Obj: 5f).ShouldBeFalse();
            5d.IsLessThan(Obj: 5d).ShouldBeFalse();
            5m.IsLessThan(Obj: 5m).ShouldBeFalse();
            ((short)5).IsLessThan((short)5).ShouldBeFalse();
            ((ushort)5).IsLessThan((ushort)5).ShouldBeFalse();

            5.IsLessThan(Obj: 6).ShouldBeTrue();
            5u.IsLessThan(Obj: 6u).ShouldBeTrue();
            5uL.IsLessThan(Obj: 6uL).ShouldBeTrue();
            5f.IsLessThan(Obj: 6f).ShouldBeTrue();
            5d.IsLessThan(Obj: 6d).ShouldBeTrue();
            5m.IsLessThan(Obj: 6m).ShouldBeTrue();
            ((short)5).IsLessThan((short)6).ShouldBeTrue();
            ((ushort)5).IsLessThan((ushort)6).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.IsGreaterThanOrEqual) + "(IComparable, IComparable) => Boolean")]
        public void IsGreaterThanOrEqual()
            {
            const string Test = "abc";

            ((string)null).IsGreaterThanOrEqual((string)null).ShouldBeTrue();
            ((string)null).IsGreaterThanOrEqual("").ShouldBeFalse();
            "".IsGreaterThanOrEqual((string)null).ShouldBeTrue();
            "".IsGreaterThanOrEqual("").ShouldBeTrue();
            Test.IsGreaterThanOrEqual(Test).ShouldBeTrue();

            5.IsGreaterThanOrEqual(Obj: 5).ShouldBeTrue();
            5u.IsGreaterThanOrEqual(Obj: 5u).ShouldBeTrue();
            5uL.IsGreaterThanOrEqual(Obj: 5uL).ShouldBeTrue();
            5f.IsGreaterThanOrEqual(Obj: 5f).ShouldBeTrue();
            5d.IsGreaterThanOrEqual(Obj: 5d).ShouldBeTrue();
            5m.IsGreaterThanOrEqual(Obj: 5m).ShouldBeTrue();
            ((short)5).IsGreaterThanOrEqual((short)5).ShouldBeTrue();
            ((ushort)5).IsGreaterThanOrEqual((ushort)5).ShouldBeTrue();

            5.IsGreaterThanOrEqual(Obj: 6).ShouldBeFalse();
            5u.IsGreaterThanOrEqual(Obj: 6u).ShouldBeFalse();
            5uL.IsGreaterThanOrEqual(Obj: 6uL).ShouldBeFalse();
            5f.IsGreaterThanOrEqual(Obj: 6f).ShouldBeFalse();
            5d.IsGreaterThanOrEqual(Obj: 6d).ShouldBeFalse();
            5m.IsGreaterThanOrEqual(Obj: 6m).ShouldBeFalse();
            ((short)5).IsGreaterThanOrEqual((short)6).ShouldBeFalse();
            ((ushort)5).IsGreaterThanOrEqual((ushort)6).ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.IsGreaterThan) + "(IComparable, IComparable) => Boolean")]
        public void IsGreaterThan()
            {
            const string Test = "abc";

            ((string)null).IsGreaterThan((string)null).ShouldBeFalse();
            ((string)null).IsGreaterThan("").ShouldBeFalse();
            "".IsGreaterThan((string)null).ShouldBeTrue();
            "".IsGreaterThan("").ShouldBeFalse();
            Test.IsGreaterThan(Test).ShouldBeFalse();

            5.IsGreaterThan(Obj: 5).ShouldBeFalse();
            5u.IsGreaterThan(Obj: 5u).ShouldBeFalse();
            5uL.IsGreaterThan(Obj: 5uL).ShouldBeFalse();
            5f.IsGreaterThan(Obj: 5f).ShouldBeFalse();
            5d.IsGreaterThan(Obj: 5d).ShouldBeFalse();
            5m.IsGreaterThan(Obj: 5m).ShouldBeFalse();
            ((short)5).IsGreaterThan((short)5).ShouldBeFalse();
            ((ushort)5).IsGreaterThan((ushort)5).ShouldBeFalse();

            5.IsGreaterThan(Obj: 6).ShouldBeFalse();
            5u.IsGreaterThan(Obj: 6u).ShouldBeFalse();
            5uL.IsGreaterThan(Obj: 6uL).ShouldBeFalse();
            5f.IsGreaterThan(Obj: 6f).ShouldBeFalse();
            5d.IsGreaterThan(Obj: 6d).ShouldBeFalse();
            5m.IsGreaterThan(Obj: 6m).ShouldBeFalse();
            ((short)5).IsGreaterThan((short)6).ShouldBeFalse();
            ((ushort)5).IsGreaterThan((ushort)6).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ComparableExt) + "." +
            nameof(ComparableExt.IsLessThanOrEqual) + "(IComparable, IComparable) => Boolean")]
        public void IsLessThanOrEqual()
            {
            const string Test = "abc";

            ((string)null).IsLessThanOrEqual((string)null).ShouldBeTrue();
            ((string)null).IsLessThanOrEqual("").ShouldBeTrue();
            "".IsLessThanOrEqual((string)null).ShouldBeFalse();
            "".IsLessThanOrEqual("").ShouldBeTrue();
            Test.IsLessThanOrEqual(Test).ShouldBeTrue();

            5.IsLessThanOrEqual(Obj: 5).ShouldBeTrue();
            5u.IsLessThanOrEqual(Obj: 5u).ShouldBeTrue();
            5uL.IsLessThanOrEqual(Obj: 5uL).ShouldBeTrue();
            5f.IsLessThanOrEqual(Obj: 5f).ShouldBeTrue();
            5d.IsLessThanOrEqual(Obj: 5d).ShouldBeTrue();
            5m.IsLessThanOrEqual(Obj: 5m).ShouldBeTrue();
            ((short)5).IsLessThanOrEqual((short)5).ShouldBeTrue();
            ((ushort)5).IsLessThanOrEqual((ushort)5).ShouldBeTrue();

            5.IsLessThanOrEqual(Obj: 6).ShouldBeTrue();
            5u.IsLessThanOrEqual(Obj: 6u).ShouldBeTrue();
            5uL.IsLessThanOrEqual(Obj: 6uL).ShouldBeTrue();
            5f.IsLessThanOrEqual(Obj: 6f).ShouldBeTrue();
            5d.IsLessThanOrEqual(Obj: 6d).ShouldBeTrue();
            5m.IsLessThanOrEqual(Obj: 6m).ShouldBeTrue();
            ((short)5).IsLessThanOrEqual((short)6).ShouldBeTrue();
            ((ushort)5).IsLessThanOrEqual((ushort)6).ShouldBeTrue();
            }
        }
    }
