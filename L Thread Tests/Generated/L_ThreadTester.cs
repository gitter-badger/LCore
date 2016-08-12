using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Thread_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_ThreadTester : XUnitOutputTester, IDisposable
        {
        public L_ThreadTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Get) + "(String) => MethodProfileData")]
        public void MethodProfileData_Get()
            {
            // TODO: Implement method test LCore.Extensions.L.Thread.MethodProfileData_Get
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Remove) + "(String)")]
        public void MethodProfileData_Remove()
            {
            // TODO: Implement method test LCore.Extensions.L.Thread.MethodProfileData_Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Add) + "(String, MethodProfileData)")]
        public void MethodProfileData_Add()
            {
            // TODO: Implement method test LCore.Extensions.L.Thread.MethodProfileData_Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Thread) + "." + nameof(L.Thread.MethodProfileData_Has) + "(String) => Boolean")]
        public void MethodProfileData_Has()
            {
            // TODO: Implement method test LCore.Extensions.L.Thread.MethodProfileData_Has
            }

        }
    }