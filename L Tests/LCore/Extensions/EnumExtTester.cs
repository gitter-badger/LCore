using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Naming;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt))]
    public partial class EnumExtTester : XUnitOutputTester
        {
        public EnumExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~EnumExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum))]
        public void ParseEnum_String_Type_Enum()
            {
            ((string)null).ParseEnum(typeof(TestEnum)).Should().Be(expected: null);

            "".ParseEnum(typeof(TestEnum)).Should().BeNull();
            "Test1".ParseEnum(Type: null).Should().BeNull();
            "FriendlyName".ParseEnum(typeof(TestEnum)).Should().BeNull();

            "Test1".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "CamelCaseEnumsAreGreat".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.CamelCaseEnumsAreGreat);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum_FriendlyName))]
        public void ParseEnum_FriendlyName()
            {
            ((string)null).ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(expected: null);
            "".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(expected: null);

            "FriendlyName".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "Camel Case Enums Are Great".ParseEnum_FriendlyName(typeof(TestEnum))
                .Should()
                .Be(TestEnum.CamelCaseEnumsAreGreat);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.GetFriendlyName))]
        public void GetFriendlyName()
            {
            TestEnum.Test2.GetFriendlyName().Should().Be("Test 2");
            TestEnum.Test1.GetFriendlyName().Should().Be("FriendlyName");
            TestEnum.CamelCaseEnumsAreGreat.GetFriendlyName().Should().Be("Camel Case Enums Are Great");

            ((Enum)null).GetFriendlyName().Should().Be("");
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