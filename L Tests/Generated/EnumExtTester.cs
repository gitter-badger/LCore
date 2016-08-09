using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt))]
    public partial class EnumExtTester : XUnitOutputTester
        {
        public EnumExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~EnumExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum))]
        public void ParseEnum_String_Nullable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumExt.ParseEnum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum))]
        public void ParseEnum_String_Type_Enum()
            {
            // TODO: Implement method test LCore.Extensions.EnumExt.ParseEnum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum))]
        public void ParseEnum_Enum_Nullable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumExt.ParseEnum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum_FriendlyName))]
        public void ParseEnum_FriendlyName()
            {
            // TODO: Implement method test LCore.Extensions.EnumExt.ParseEnum_FriendlyName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.GetFriendlyName))]
        public void GetFriendlyName()
            {
            // TODO: Implement method test LCore.Extensions.EnumExt.GetFriendlyName
            }

        }
    }