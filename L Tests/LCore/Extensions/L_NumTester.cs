using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.dotMemoryUnit.Util;
using LCore.Extensions;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_NumTester
        {
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Num) + "." + nameof(L.Num.NumberTypes))]
        public void NumberTypes()
            {
            Dictionary<Type, Number> Types = L.Num.NumberTypes;

            Types.Should().NotBeNull();
            Types.Keys.Should().NotBeEmpty();
            Types.Values.Should().NotBeEmpty();
            }
        }
    }