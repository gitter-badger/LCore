using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class EnumExtTester : XUnitOutputTester
        {
        public EnumExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~EnumExtTester()
            {
            }

        [Fact]
        public void ParseEnum_String_Type_Enum()
            {
            // TODO: Implement method Test LCore.Extensions.EnumExt.ParseEnum
            }

        [Fact]
        public void ParseEnum_FriendlyName()
            {
            // TODO: Implement method Test LCore.Extensions.EnumExt.ParseEnum_FriendlyName
            }

        [Fact]
        public void GetFriendlyName()
            {
            // TODO: Implement method Test LCore.Extensions.EnumExt.GetFriendlyName
            }

        [Fact]
        public void ParseEnum_String_Nullable_1()
            {
            // TODO: Implement method Test LCore.Extensions.EnumExt.ParseEnum
            }

        [Fact]
        public void ParseEnum_Enum_Nullable_1()
            {
            // TODO: Implement method Test LCore.Extensions.EnumExt.ParseEnum
            }

        }
    }