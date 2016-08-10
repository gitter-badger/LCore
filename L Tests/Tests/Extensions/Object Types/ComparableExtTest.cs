
using LCore.Extensions;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;
using LCore.LUnit;

// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class ComparableExtTest : XUnitOutputTester
        {
        [Fact]
        public void Test_IsEqualTo()
            {
            const string Test = "abc";

            ((string)null).IsEqualTo((string)null).Should().BeTrue();
            ((string)null).IsEqualTo("").Should().BeFalse();
            "".IsEqualTo((string)null).Should().BeFalse();
            "".IsEqualTo("").Should().BeTrue();
            Test.IsEqualTo(Test).Should().BeTrue();

            5.IsEqualTo(Obj: 5).Should().BeTrue();
            5u.IsEqualTo(Obj: 5u).Should().BeTrue();
            5uL.IsEqualTo(Obj: 5uL).Should().BeTrue();
            5f.IsEqualTo(Obj: 5f).Should().BeTrue();
            5d.IsEqualTo(Obj: 5d).Should().BeTrue();
            5m.IsEqualTo(Obj: 5m).Should().BeTrue();
            ((short)5).IsEqualTo((short)5).Should().BeTrue();
            ((ushort)5).IsEqualTo((ushort)5).Should().BeTrue();

            5.IsEqualTo(Obj: 6).Should().BeFalse();
            5u.IsEqualTo(Obj: 6u).Should().BeFalse();
            5uL.IsEqualTo(Obj: 6uL).Should().BeFalse();
            5f.IsEqualTo(Obj: 6f).Should().BeFalse();
            5d.IsEqualTo(Obj: 6d).Should().BeFalse();
            5m.IsEqualTo(Obj: 6m).Should().BeFalse();
            ((short)5).IsEqualTo((short)6).Should().BeFalse();
            ((ushort)5).IsEqualTo((ushort)6).Should().BeFalse();
            }
        [Fact]
        public void Test_IsNotEqualTo()
            {
            const string Test = "abc";

            ((string)null).IsNotEqualTo((string)null).Should().BeFalse();
            ((string)null).IsNotEqualTo("").Should().BeTrue();
            "".IsNotEqualTo((string)null).Should().BeTrue();
            "".IsNotEqualTo("").Should().BeFalse();
            Test.IsNotEqualTo(Test).Should().BeFalse();

            5.IsNotEqualTo(Obj: 5).Should().BeFalse();
            5u.IsNotEqualTo(Obj: 5u).Should().BeFalse();
            5uL.IsNotEqualTo(Obj: 5uL).Should().BeFalse();
            5f.IsNotEqualTo(Obj: 5f).Should().BeFalse();
            5d.IsNotEqualTo(Obj: 5d).Should().BeFalse();
            5m.IsNotEqualTo(Obj: 5m).Should().BeFalse();
            ((short)5).IsNotEqualTo((short)5).Should().BeFalse();
            ((ushort)5).IsNotEqualTo((ushort)5).Should().BeFalse();

            5.IsNotEqualTo(Obj: 6).Should().BeTrue();
            5u.IsNotEqualTo(Obj: 6u).Should().BeTrue();
            5uL.IsNotEqualTo(Obj: 6uL).Should().BeTrue();
            5f.IsNotEqualTo(Obj: 6f).Should().BeTrue();
            5d.IsNotEqualTo(Obj: 6d).Should().BeTrue();
            5m.IsNotEqualTo(Obj: 6m).Should().BeTrue();
            ((short)5).IsNotEqualTo((short)6).Should().BeTrue();
            ((ushort)5).IsNotEqualTo((ushort)6).Should().BeTrue();
            }

        [Fact]
        public void Test_IsLessThan()
            {
            const string Test = "abc";

            ((string)null).IsLessThan((string)null).Should().BeFalse();
            ((string)null).IsLessThan("").Should().BeTrue();
            "".IsLessThan((string)null).Should().BeFalse();
            "".IsLessThan("").Should().BeFalse();
            Test.IsLessThan(Test).Should().BeFalse();

            5.IsLessThan(Obj: 5).Should().BeFalse();
            5u.IsLessThan(Obj: 5u).Should().BeFalse();
            5uL.IsLessThan(Obj: 5uL).Should().BeFalse();
            5f.IsLessThan(Obj: 5f).Should().BeFalse();
            5d.IsLessThan(Obj: 5d).Should().BeFalse();
            5m.IsLessThan(Obj: 5m).Should().BeFalse();
            ((short)5).IsLessThan((short)5).Should().BeFalse();
            ((ushort)5).IsLessThan((ushort)5).Should().BeFalse();

            5.IsLessThan(Obj: 6).Should().BeTrue();
            5u.IsLessThan(Obj: 6u).Should().BeTrue();
            5uL.IsLessThan(Obj: 6uL).Should().BeTrue();
            5f.IsLessThan(Obj: 6f).Should().BeTrue();
            5d.IsLessThan(Obj: 6d).Should().BeTrue();
            5m.IsLessThan(Obj: 6m).Should().BeTrue();
            ((short)5).IsLessThan((short)6).Should().BeTrue();
            ((ushort)5).IsLessThan((ushort)6).Should().BeTrue();
            }

        [Fact]
        public void Test_IsGreaterThanOrEqual()
            {
            const string Test = "abc";

            ((string)null).IsGreaterThanOrEqual((string)null).Should().BeTrue();
            ((string)null).IsGreaterThanOrEqual("").Should().BeFalse();
            "".IsGreaterThanOrEqual((string)null).Should().BeTrue();
            "".IsGreaterThanOrEqual("").Should().BeTrue();
            Test.IsGreaterThanOrEqual(Test).Should().BeTrue();

            5.IsGreaterThanOrEqual(Obj: 5).Should().BeTrue();
            5u.IsGreaterThanOrEqual(Obj: 5u).Should().BeTrue();
            5uL.IsGreaterThanOrEqual(Obj: 5uL).Should().BeTrue();
            5f.IsGreaterThanOrEqual(Obj: 5f).Should().BeTrue();
            5d.IsGreaterThanOrEqual(Obj: 5d).Should().BeTrue();
            5m.IsGreaterThanOrEqual(Obj: 5m).Should().BeTrue();
            ((short)5).IsGreaterThanOrEqual((short)5).Should().BeTrue();
            ((ushort)5).IsGreaterThanOrEqual((ushort)5).Should().BeTrue();

            5.IsGreaterThanOrEqual(Obj: 6).Should().BeFalse();
            5u.IsGreaterThanOrEqual(Obj: 6u).Should().BeFalse();
            5uL.IsGreaterThanOrEqual(Obj: 6uL).Should().BeFalse();
            5f.IsGreaterThanOrEqual(Obj: 6f).Should().BeFalse();
            5d.IsGreaterThanOrEqual(Obj: 6d).Should().BeFalse();
            5m.IsGreaterThanOrEqual(Obj: 6m).Should().BeFalse();
            ((short)5).IsGreaterThanOrEqual((short)6).Should().BeFalse();
            ((ushort)5).IsGreaterThanOrEqual((ushort)6).Should().BeFalse();
            }


        [Fact]
        public void Test_IsGreaterThan()
            {
            const string Test = "abc";

            ((string)null).IsGreaterThan((string)null).Should().BeFalse();
            ((string)null).IsGreaterThan("").Should().BeFalse();
            "".IsGreaterThan((string)null).Should().BeTrue();
            "".IsGreaterThan("").Should().BeFalse();
            Test.IsGreaterThan(Test).Should().BeFalse();

            5.IsGreaterThan(Obj: 5).Should().BeFalse();
            5u.IsGreaterThan(Obj: 5u).Should().BeFalse();
            5uL.IsGreaterThan(Obj: 5uL).Should().BeFalse();
            5f.IsGreaterThan(Obj: 5f).Should().BeFalse();
            5d.IsGreaterThan(Obj: 5d).Should().BeFalse();
            5m.IsGreaterThan(Obj: 5m).Should().BeFalse();
            ((short)5).IsGreaterThan((short)5).Should().BeFalse();
            ((ushort)5).IsGreaterThan((ushort)5).Should().BeFalse();

            5.IsGreaterThan(Obj: 6).Should().BeFalse();
            5u.IsGreaterThan(Obj: 6u).Should().BeFalse();
            5uL.IsGreaterThan(Obj: 6uL).Should().BeFalse();
            5f.IsGreaterThan(Obj: 6f).Should().BeFalse();
            5d.IsGreaterThan(Obj: 6d).Should().BeFalse();
            5m.IsGreaterThan(Obj: 6m).Should().BeFalse();
            ((short)5).IsGreaterThan((short)6).Should().BeFalse();
            ((ushort)5).IsGreaterThan((ushort)6).Should().BeFalse();
            }

        [Fact]
        public void Test_IsLessThanOrEqual()
            {
            const string Test = "abc";

            ((string)null).IsLessThanOrEqual((string)null).Should().BeTrue();
            ((string)null).IsLessThanOrEqual("").Should().BeTrue();
            "".IsLessThanOrEqual((string)null).Should().BeFalse();
            "".IsLessThanOrEqual("").Should().BeTrue();
            Test.IsLessThanOrEqual(Test).Should().BeTrue();

            5.IsLessThanOrEqual(Obj: 5).Should().BeTrue();
            5u.IsLessThanOrEqual(Obj: 5u).Should().BeTrue();
            5uL.IsLessThanOrEqual(Obj: 5uL).Should().BeTrue();
            5f.IsLessThanOrEqual(Obj: 5f).Should().BeTrue();
            5d.IsLessThanOrEqual(Obj: 5d).Should().BeTrue();
            5m.IsLessThanOrEqual(Obj: 5m).Should().BeTrue();
            ((short)5).IsLessThanOrEqual((short)5).Should().BeTrue();
            ((ushort)5).IsLessThanOrEqual((ushort)5).Should().BeTrue();

            5.IsLessThanOrEqual(Obj: 6).Should().BeTrue();
            5u.IsLessThanOrEqual(Obj: 6u).Should().BeTrue();
            5uL.IsLessThanOrEqual(Obj: 6uL).Should().BeTrue();
            5f.IsLessThanOrEqual(Obj: 6f).Should().BeTrue();
            5d.IsLessThanOrEqual(Obj: 6d).Should().BeTrue();
            5m.IsLessThanOrEqual(Obj: 6m).Should().BeTrue();
            ((short)5).IsLessThanOrEqual((short)6).Should().BeTrue();
            ((ushort)5).IsLessThanOrEqual((ushort)6).Should().BeTrue();
            }

        public ComparableExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }
