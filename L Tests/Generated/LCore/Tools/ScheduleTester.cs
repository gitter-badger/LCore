using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    public class ScheduleTester : XUnitOutputTester
        {
        public ScheduleTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~ScheduleTester()
            {
            }

        [Fact]
        public void FromString()
            {
            // TODO: Implement method test LCore.Tools.Schedule.FromString
            }

        }
    }