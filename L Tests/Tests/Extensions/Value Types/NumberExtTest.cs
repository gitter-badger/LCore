using LCore.Extensions;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
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
        public void Test_Max()
            {
            ((IComparable) null).Max().Should().Be(expected: null);
            ((IComparable) null).Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 14);

            50.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 50);
            5.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("ttt");
            }

        [Fact]
        public void Test_Min()
            {
            ((IComparable) null).Min().Should().Be(expected: null);
            ((IComparable) null).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 1);

            50.Min(1, 2, 3, 14, 5, 6, 7).Should().Be(expected: 1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(expected: 1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("acl");
            }

        [Fact]
        public void Test_NumericalCompare()
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
        
        [Fact]
        public void Test_DecimalPlaces()
            {
            1.DecimalPlaces().Should().Be(expected: 0);
            ((short) 1).DecimalPlaces().Should().Be(expected: 0);
            1L.DecimalPlaces().Should().Be(expected: 0);
            1uL.DecimalPlaces().Should().Be(expected: 0);
            ((char) 0).DecimalPlaces().Should().Be(expected: 0);
            ((char) 0).DecimalPlaces().Should().Be(expected: 0);
            ((byte) 0).DecimalPlaces().Should().Be(expected: 0);
            ((sbyte) 0).DecimalPlaces().Should().Be(expected: 0);

            5.5m.DecimalPlaces().Should().Be(expected: 1);
            5.50032m.DecimalPlaces().Should().Be(expected: 5);
            5.50042032m.DecimalPlaces().Should().Be(expected: 8);
            5.501042032m.DecimalPlaces().Should().Be(expected: 9);

            (-5.5m).DecimalPlaces().Should().Be(expected: 1);
            (-5.50032m).DecimalPlaces().Should().Be(expected: 5);
            (-5.50042032m).DecimalPlaces().Should().Be(expected: 8);
            (-5.501042032m).DecimalPlaces().Should().Be(expected: 9);

            5.5d.DecimalPlaces().Should().Be(expected: 1);
            5.50032d.DecimalPlaces().Should().Be(expected: 5);
            5.50042032d.DecimalPlaces().Should().Be(expected: 8);
            5.501042032d.DecimalPlaces().Should().Be(expected: 9);

            (-5.5d).DecimalPlaces().Should().Be(expected: 1);
            (-5.50032d).DecimalPlaces().Should().Be(expected: 5);
            (-5.50042032d).DecimalPlaces().Should().Be(expected: 8);
            (-5.501042032d).DecimalPlaces().Should().Be(expected: 9);

            5.5f.DecimalPlaces().Should().Be(expected: 1);
            5.50032f.DecimalPlaces().Should().Be(expected: 5);
            5.50042032f.DecimalPlaces().Should().Be(expected: 5);
            5.501042032f.DecimalPlaces().Should().Be(expected: 6);
            (-5.5f).DecimalPlaces().Should().Be(expected: 1);
            (-5.50032f).DecimalPlaces().Should().Be(expected: 5);
            (-5.50042032f).DecimalPlaces().Should().Be(expected: 5);
            (-5.501042032f).DecimalPlaces().Should().Be(expected: 6);

            float.MinValue.DecimalPlaces().Should().Be(expected: 0);
            double.MinValue.DecimalPlaces().Should().Be(expected: 0);
            decimal.MinValue.DecimalPlaces().Should().Be(expected: 0);

            float.Epsilon.DecimalPlaces().Should().Be(expected: 51);
            double.Epsilon.DecimalPlaces().Should().Be(expected: 338);
            ((IConvertible) new DecimalNumber().TypePrecision.GetValue()).ConvertTo<decimal>()?.DecimalPlaces().Should().Be(expected: 28);

            50d.DecimalPlaces().Should().Be(expected: 0);
            50.0m.DecimalPlaces().Should().Be(expected: 0);
            50f.DecimalPlaces().Should().Be(expected: 0);
            }


        public NumberExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }