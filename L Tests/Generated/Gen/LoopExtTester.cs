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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt))]
    public partial class LoopExtTester : XUnitOutputTester
        {
        public LoopExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~LoopExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt) + "." + nameof(LoopExt.To))]
        public void To_Int32_Int32_Func_1_List_1()
            {
            // TODO: Implement method test LCore.Extensions.LoopExt.To
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt) + "." + nameof(LoopExt.To))]
        public void To_Int32_Int32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.LoopExt.To
            }

        }
    }