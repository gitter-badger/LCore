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
    public partial class L_AryTester : XUnitOutputTester
        {
        public L_AryTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_AryTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ary) + "." + nameof(L.Ary.Array))]
        public void Array_Func_1()
            {
            // TODO: Implement method test LCore.Extensions.L.Ary.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ary) + "." + nameof(L.Ary.Array))]
        public void Array_T_Func_1()
            {
            // TODO: Implement method test LCore.Extensions.L.Ary.Array
            }

        }
    }