using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_DateTester : XUnitOutputTester
        {
        public L_DateTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_DateTester()
            {
            }

        [Fact]
        public void MonthNumberGetName()
            {
            // TODO: Implement method Test LCore.Extensions.L.Date.MonthNumberGetName
            }

        }
    }