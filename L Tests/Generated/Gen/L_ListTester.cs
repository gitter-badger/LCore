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
    public partial class L_ListTester : XUnitOutputTester, IDisposable
        {
        public L_ListTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." + nameof(L.List.NewList) + "() => T")]
        public void NewList()
            {
            // TODO: Implement method test LCore.Extensions.L.List.NewList
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." + nameof(L.List.ToList) + "() => Func`1<List`1<T>>")]
        public void ToList_Func_1_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.L.List.ToList
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." + nameof(L.List.ToList) + "(T[]) => Func`1<List`1<T>>")]
        public void ToList_T_Func_1_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.L.List.ToList
            }

        }
    }