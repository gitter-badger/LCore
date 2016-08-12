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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt))]
    public partial class LoopExtTester : XUnitOutputTester, IDisposable
        {
        public LoopExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt) + "." + nameof(LoopExt.To) + "(Int32, Int32, Func`1<U>) => List`1<U>")]
        public void To_Int32_Int32_Func_1_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.LoopExt.To
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt) + "." + nameof(LoopExt.To) + "(Int32, Int32, Func`2<Int32, T>) => List`1<T>")]
        public void To_Int32_Int32_Func_2_Int32_T_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.LoopExt.To
            }

        }
    }