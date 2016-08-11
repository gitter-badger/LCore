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
    public partial class L_ListTester : XUnitOutputTester, IDisposable
        {
        public L_ListTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." + nameof(L.List.NewList))]
        public void NewList()
            {
            // TODO: Implement method test LCore.Extensions.L.List.NewList
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." + nameof(L.List.ToList))]
        public void ToList_Func_1()
            {
            // TODO: Implement method test LCore.Extensions.L.List.ToList
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." + nameof(L.List.ToList))]
        public void ToList_TArray_Func_1()
            {
            // TODO: Implement method test LCore.Extensions.L.List.ToList
            }

        }
    }