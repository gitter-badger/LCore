using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt))]
    public partial class DateExtTester
        {
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DateExt) + "." + nameof(DateExt.DayOfWeekNumber))]
        public void DayOfWeekNumber()
            {
            // Attribute Tests Implemented
            }

        }
    }