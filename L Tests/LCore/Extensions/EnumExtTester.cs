using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Naming;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantExtendsListEntry
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt))]
    public partial class EnumExtTester : XUnitOutputTester
        {
        public EnumExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        ~EnumExtTester() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum) + "(String, Type) => Enum")]
        public void ParseEnum_String_Type_Enum()
            {
            ((string) null).ParseEnum(typeof(TestEnum)).Should().Be(expected: null);

            "".ParseEnum(typeof(TestEnum)).Should().BeNull();
            "Test1".ParseEnum(Type: null).Should().BeNull();
            "FriendlyName".ParseEnum(typeof(TestEnum)).Should().BeNull();

            "Test1".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "CamelCaseEnumsAreGreat".ParseEnum(typeof(TestEnum)).Should().Be(TestEnum.CamelCaseEnumsAreGreat);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum_FriendlyName) + "(String, Type) => Enum")]
        public void ParseEnum_FriendlyName()
            {
            ((string) null).ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(expected: null);
            "".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(expected: null);

            "FriendlyName".ParseEnum_FriendlyName(typeof(TestEnum)).Should().Be(TestEnum.Test1);
            "Camel Case Enums Are Great".ParseEnum_FriendlyName(typeof(TestEnum))
                .Should()
                .Be(TestEnum.CamelCaseEnumsAreGreat);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.GetFriendlyName) + "(Enum) => String")]
        public void GetFriendlyName()
            {
            TestEnum.Test2.GetFriendlyName().Should().Be("Test 2");
            TestEnum.Test1.GetFriendlyName().Should().Be("FriendlyName");
            TestEnum.CamelCaseEnumsAreGreat.GetFriendlyName().Should().Be("Camel Case Enums Are Great");

            ((Enum) null).GetFriendlyName().Should().Be("");
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum) + "(String) => Nullable`1<T>")]
        public void ParseEnum_String_Nullable_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum) + "(Enum) => Nullable`1<T>")]
        public void ParseEnum_Enum_Nullable_1()
            {
            // Attribute Tests Implemented
            }


        public enum TestEnum
            {
            [FriendlyName("FriendlyName")] Test1,
            Test2,
            Test3,
            CamelCaseEnumsAreGreat
            }
        }
    }