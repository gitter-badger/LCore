using LCore.Extensions;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Naming;
using Xunit;
using Xunit.Abstractions;
using LCore.LUnit;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class EnumExtTest : XUnitOutputTester
        {
        [Fact]
        public void Test_GetFriendlyName()
            {
            TestEnum.Test2.GetFriendlyName().Should().Be("Test 2");
            TestEnum.Test1.GetFriendlyName().Should().Be("FriendlyName");
            TestEnum.CamelCaseEnumsAreGreat.GetFriendlyName().Should().Be("Camel Case Enums Are Great");

            ((Enum) null).GetFriendlyName().Should().Be("");
            }


        [Fact]
        public void Test_ParseEnum_FriendlyName()
            {
            ((string) null).ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(expected: null);
            "".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(expected: null);

            "FriendlyName".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "Camel Case Enums Are Great".ParseEnum_FriendlyName(typeof(TestEnum))
                .Should()
                .Be(TestEnum.CamelCaseEnumsAreGreat);
            }


        [Fact]
        public void Test_ParseEnum()
            {
            ((string) null).ParseEnum(typeof(TestEnum)).Should().Be(expected: null);

            "".ParseEnum(typeof(TestEnum)).Should().BeNull();
            "Test1".ParseEnum(Type: null).Should().BeNull();
            "FriendlyName".ParseEnum(typeof(TestEnum)).Should().BeNull();

            "Test1".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "CamelCaseEnumsAreGreat".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.CamelCaseEnumsAreGreat);
            }

        public enum TestEnum
            {
            [FriendlyName("FriendlyName")] Test1,
            Test2,
            Test3,
            CamelCaseEnumsAreGreat
            }

        public EnumExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }