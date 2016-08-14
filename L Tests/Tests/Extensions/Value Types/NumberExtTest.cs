using LCore.Extensions;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class NumberExtTest : XUnitOutputTester
        {
        [Fact]
        public void Max()
            {
            ((IComparable)null).Max().Should().Be(expected: null);
            ((IComparable)null).Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 14);

            50.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 50);
            5.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("ttt");
            }

        [Fact]
        public void Min()
            {
            ((IComparable)null).Min().Should().Be(expected: null);
            ((IComparable)null).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 1);

            50.Min(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("acl");
            }

        [Fact]
        public void NumericalCompare()
            {
            L.Str.CompareNumberString("5", "10").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("15", "10").Should().BeGreaterThan(expected: 0);
            L.Str.CompareNumberString("-5", "10").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("5", "-10").Should().BeGreaterThan(expected: 0);
            L.Str.CompareNumberString("-5", "-10").Should().BeGreaterThan(expected: 0);
            L.Str.CompareNumberString("-5", "-5").Should().Be(expected: 0);
            L.Str.CompareNumberString("-5000.00000", "-5000.000").Should().Be(expected: 0);

            L.Str.CompareNumberString("-5000.000001", "-5000.000").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("-5000.000001", "-5000.0001").Should().BeGreaterThan(expected: 0);


            L.Str.CompareNumberString("55", "501").Should().BeLessThan(expected: 0);
            L.Str.CompareNumberString("501", "55").Should().BeGreaterThan(expected: 0);

            L.Str.CompareNumberString(int.MaxValue.ToString(), "4").Should().BeGreaterThan(expected: 0);
            }



        public NumberExtTest([NotNull] ITestOutputHelper Output) : base(Output) { }
        }
    }