using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_AryTester : XUnitOutputTester, IDisposable
        {
        public L_AryTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ary) + "." + nameof(L.Ary.Array) + "() => Func`1<T[]>")]
        public void Array_Func_1_T()
            {
            // TODO: Implement method test LCore.Extensions.L.Ary.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ary) + "." + nameof(L.Ary.Array) + "(T[]) => Func`1<T[]>")]
        public void Array_T_Func_1_T()
            {
            // TODO: Implement method test LCore.Extensions.L.Ary.Array
            }

        }
    }