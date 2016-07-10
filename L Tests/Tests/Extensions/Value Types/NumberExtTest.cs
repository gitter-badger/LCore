
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable StringLiteralTypo

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class NumberExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(NumberExt) };


        [TestMethod]
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

        [TestMethod]
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
        }
    }
