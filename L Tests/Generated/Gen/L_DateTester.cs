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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_DateTester : XUnitOutputTester
        {
        public L_DateTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_DateTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Date) + "." + nameof(L.Date.MonthNumberGetName))]
        public void MonthNumberGetName()
            {
            // TODO: Implement method test LCore.Extensions.L.Date.MonthNumberGetName
            }

        }
    }