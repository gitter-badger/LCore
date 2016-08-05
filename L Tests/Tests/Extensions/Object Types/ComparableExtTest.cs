
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

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class ComparableExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ComparableExt) };

        [Fact]
        public void Test_IsEqualTo()
            {
            const string Test = "abc";

            ((string)null).IsEqualTo((string)null).Should().BeTrue();
            ((string)null).IsEqualTo("").Should().BeFalse();
            "".IsEqualTo((string)null).Should().BeFalse();
            "".IsEqualTo("").Should().BeTrue();
            Test.IsEqualTo(Test).Should().BeTrue();

            5.IsEqualTo(5).Should().BeTrue();
            5u.IsEqualTo(5u).Should().BeTrue();
            5uL.IsEqualTo(5uL).Should().BeTrue();
            5f.IsEqualTo(5f).Should().BeTrue();
            5d.IsEqualTo(5d).Should().BeTrue();
            5m.IsEqualTo(5m).Should().BeTrue();
            ((short)5).IsEqualTo((short)5).Should().BeTrue();
            ((ushort)5).IsEqualTo((ushort)5).Should().BeTrue();

            5.IsEqualTo(6).Should().BeFalse();
            5u.IsEqualTo(6u).Should().BeFalse();
            5uL.IsEqualTo(6uL).Should().BeFalse();
            5f.IsEqualTo(6f).Should().BeFalse();
            5d.IsEqualTo(6d).Should().BeFalse();
            5m.IsEqualTo(6m).Should().BeFalse();
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

            5.IsNotEqualTo(5).Should().BeFalse();
            5u.IsNotEqualTo(5u).Should().BeFalse();
            5uL.IsNotEqualTo(5uL).Should().BeFalse();
            5f.IsNotEqualTo(5f).Should().BeFalse();
            5d.IsNotEqualTo(5d).Should().BeFalse();
            5m.IsNotEqualTo(5m).Should().BeFalse();
            ((short)5).IsNotEqualTo((short)5).Should().BeFalse();
            ((ushort)5).IsNotEqualTo((ushort)5).Should().BeFalse();

            5.IsNotEqualTo(6).Should().BeTrue();
            5u.IsNotEqualTo(6u).Should().BeTrue();
            5uL.IsNotEqualTo(6uL).Should().BeTrue();
            5f.IsNotEqualTo(6f).Should().BeTrue();
            5d.IsNotEqualTo(6d).Should().BeTrue();
            5m.IsNotEqualTo(6m).Should().BeTrue();
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

            5.IsLessThan(5).Should().BeFalse();
            5u.IsLessThan(5u).Should().BeFalse();
            5uL.IsLessThan(5uL).Should().BeFalse();
            5f.IsLessThan(5f).Should().BeFalse();
            5d.IsLessThan(5d).Should().BeFalse();
            5m.IsLessThan(5m).Should().BeFalse();
            ((short)5).IsLessThan((short)5).Should().BeFalse();
            ((ushort)5).IsLessThan((ushort)5).Should().BeFalse();

            5.IsLessThan(6).Should().BeTrue();
            5u.IsLessThan(6u).Should().BeTrue();
            5uL.IsLessThan(6uL).Should().BeTrue();
            5f.IsLessThan(6f).Should().BeTrue();
            5d.IsLessThan(6d).Should().BeTrue();
            5m.IsLessThan(6m).Should().BeTrue();
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

            5.IsGreaterThanOrEqual(5).Should().BeTrue();
            5u.IsGreaterThanOrEqual(5u).Should().BeTrue();
            5uL.IsGreaterThanOrEqual(5uL).Should().BeTrue();
            5f.IsGreaterThanOrEqual(5f).Should().BeTrue();
            5d.IsGreaterThanOrEqual(5d).Should().BeTrue();
            5m.IsGreaterThanOrEqual(5m).Should().BeTrue();
            ((short)5).IsGreaterThanOrEqual((short)5).Should().BeTrue();
            ((ushort)5).IsGreaterThanOrEqual((ushort)5).Should().BeTrue();

            5.IsGreaterThanOrEqual(6).Should().BeFalse();
            5u.IsGreaterThanOrEqual(6u).Should().BeFalse();
            5uL.IsGreaterThanOrEqual(6uL).Should().BeFalse();
            5f.IsGreaterThanOrEqual(6f).Should().BeFalse();
            5d.IsGreaterThanOrEqual(6d).Should().BeFalse();
            5m.IsGreaterThanOrEqual(6m).Should().BeFalse();
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

            5.IsGreaterThan(5).Should().BeFalse();
            5u.IsGreaterThan(5u).Should().BeFalse();
            5uL.IsGreaterThan(5uL).Should().BeFalse();
            5f.IsGreaterThan(5f).Should().BeFalse();
            5d.IsGreaterThan(5d).Should().BeFalse();
            5m.IsGreaterThan(5m).Should().BeFalse();
            ((short)5).IsGreaterThan((short)5).Should().BeFalse();
            ((ushort)5).IsGreaterThan((ushort)5).Should().BeFalse();

            5.IsGreaterThan(6).Should().BeFalse();
            5u.IsGreaterThan(6u).Should().BeFalse();
            5uL.IsGreaterThan(6uL).Should().BeFalse();
            5f.IsGreaterThan(6f).Should().BeFalse();
            5d.IsGreaterThan(6d).Should().BeFalse();
            5m.IsGreaterThan(6m).Should().BeFalse();
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

            5.IsLessThanOrEqual(5).Should().BeTrue();
            5u.IsLessThanOrEqual(5u).Should().BeTrue();
            5uL.IsLessThanOrEqual(5uL).Should().BeTrue();
            5f.IsLessThanOrEqual(5f).Should().BeTrue();
            5d.IsLessThanOrEqual(5d).Should().BeTrue();
            5m.IsLessThanOrEqual(5m).Should().BeTrue();
            ((short)5).IsLessThanOrEqual((short)5).Should().BeTrue();
            ((ushort)5).IsLessThanOrEqual((ushort)5).Should().BeTrue();

            5.IsLessThanOrEqual(6).Should().BeTrue();
            5u.IsLessThanOrEqual(6u).Should().BeTrue();
            5uL.IsLessThanOrEqual(6uL).Should().BeTrue();
            5f.IsLessThanOrEqual(6f).Should().BeTrue();
            5d.IsLessThanOrEqual(6d).Should().BeTrue();
            5m.IsLessThanOrEqual(6m).Should().BeTrue();
            ((short)5).IsLessThanOrEqual((short)6).Should().BeTrue();
            ((ushort)5).IsLessThanOrEqual((ushort)6).Should().BeTrue();
            }

        public ComparableExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }
