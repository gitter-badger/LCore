
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Naming;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class EnumExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(EnumExt) };


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_GetFriendlyName()
            {
            TestEnum.Test2.GetFriendlyName().Should().Be("Test 2");
            TestEnum.Test1.GetFriendlyName().Should().Be("FriendlyName");
            TestEnum.CamelCaseEnumsAreGreat.GetFriendlyName().Should().Be("Camel Case Enums Are Great");

            ((Enum)null).GetFriendlyName().Should().Be("");
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_ParseEnum_FriendlyName()
            {
            ((string)null).ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(null);
            "".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(null);

            "FriendlyName".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "Camel Case Enums Are Great".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(TestEnum.CamelCaseEnumsAreGreat);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_ParseEnum()
            {
            ((string)null).ParseEnum(typeof(TestEnum)).Should().Be(null);

            "".ParseEnum(typeof(TestEnum)).Should().BeNull();
            "Test1".ParseEnum(null).Should().BeNull();
            "FriendlyName".ParseEnum(typeof(TestEnum)).Should().BeNull();

            "Test1".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "CamelCaseEnumsAreGreat".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.CamelCaseEnumsAreGreat);
            }

        public enum TestEnum
            {
            [FriendlyName("FriendlyName")]
            Test1,
            Test2,
            Test3,
            CamelCaseEnumsAreGreat
            }
        }
    }
