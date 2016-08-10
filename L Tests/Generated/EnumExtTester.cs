using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt))]
    public partial class EnumExtTester
        {
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum))]
        public void ParseEnum_String_Nullable_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumExt) + "." + nameof(EnumExt.ParseEnum))]
        public void ParseEnum_Enum_Nullable_1()
            {
            // Attribute Tests Implemented
            }

        }
    }