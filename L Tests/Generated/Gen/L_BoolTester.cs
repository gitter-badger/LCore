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
    public partial class L_BoolTester : XUnitOutputTester, IDisposable
        {
        public L_BoolTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Bool) + "." + nameof(L.Bool.L_If_A))]
        public void L_If_A_Func_3()
            {
            // TODO: Implement method test LCore.Extensions.L.Bool.L_If_A
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Bool) + "." + nameof(L.Bool.L_If_F))]
        public void L_If_F_Func_3()
            {
            // TODO: Implement method test LCore.Extensions.L.Bool.L_If_F
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Bool) + "." + nameof(L.Bool.L_IfElse))]
        public void L_IfElse_Func_4()
            {
            // TODO: Implement method test LCore.Extensions.L.Bool.L_IfElse
            }

        }
    }