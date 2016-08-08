using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class LoopExtTester : XUnitOutputTester
        {
        public LoopExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~LoopExtTester() { }

        [Fact]
        public void To_Int32_Int32_Func_1_List_1()
            {
            // TODO: Implement method Test LCore.Extensions.LoopExt.To
            }

        [Fact]
        public void To_Int32_Int32_Func_2_List_1()
            {
            // TODO: Implement method Test LCore.Extensions.LoopExt.To
            }

        }
    }