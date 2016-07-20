
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using Xunit;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable StringLiteralTypo

namespace L_Tests.Tests.Extensions
    {
    public class NumberExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(NumberExt) };


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Max()
            {
            ((IComparable)null).Max().Should().Be(null);
            ((IComparable)null).Max(1, 2, 3, 14, 5, 6, 7).Should().Be(14);

            50.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(50);
            5.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("ttt");
            }

        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Min()
            {
            ((IComparable)null).Min().Should().Be(null);
            ((IComparable)null).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(1);

            50.Min(1, 2, 3, 14, 5, 6, 7).Should().Be(1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("acl");
            }

        [Fact]
        public void Test_NumericalCompare()
            {
            L.Str.CompareNumberString("5", "10").Should().BeLessThan(0);
            L.Str.CompareNumberString("15", "10").Should().BeGreaterThan(0);
            L.Str.CompareNumberString("-5", "10").Should().BeLessThan(0);
            L.Str.CompareNumberString("5", "-10").Should().BeGreaterThan(0);
            L.Str.CompareNumberString("-5", "-10").Should().BeGreaterThan(0);
            L.Str.CompareNumberString("-5", "-5").Should().Be(0);
            L.Str.CompareNumberString("-5000.00000", "-5000.000").Should().Be(0);

            L.Str.CompareNumberString("-5000.000001", "-5000.000").Should().BeLessThan(0);
            L.Str.CompareNumberString("-5000.000001", "-5000.0001").Should().BeGreaterThan(0);


            L.Str.CompareNumberString("55", "501").Should().BeLessThan(0);
            L.Str.CompareNumberString("501", "55").Should().BeGreaterThan(0);

            L.Str.CompareNumberString(int.MaxValue.ToString(), "4").Should().BeGreaterThan(0);
            }

        [Fact]
        public void Test_ScientificNotationConversion()
            {
            L.Num.ScientificNotationToNumber("1.0e5").Should().Be("100000.0");
            }
        }
    }
