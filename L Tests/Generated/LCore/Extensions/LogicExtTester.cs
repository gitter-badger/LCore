using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class LogicExtTester : XUnitOutputTester
        {
        public LogicExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }



        ~LogicExtTester()
            {
            }

        [Fact]
        public void Surround_Action_1_Func_4_Action_3()
            {
            // TODO: Implement method Test LCore.Extensions.LogicExt.Surround
            }

        }
    }