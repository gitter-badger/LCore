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
    public partial class L_ObjTester : XUnitOutputTester
        {
        public L_ObjTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_ObjTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.As))]
        public void As()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.As
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.Swap))]
        public void Swap()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.Swap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.SafeEquals))]
        public void SafeEquals()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.SafeEquals
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.New))]
        public void New()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.NewRandom))]
        public void NewRandom_Nullable_1_Nullable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.NewRandom
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.NewRandom))]
        public void NewRandom_Type_Object_Object_Object()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.NewRandom
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.IsNull))]
        public void IsNull()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.IsNull
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.IsA))]
        public void IsA()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.IsA
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.HasProperty))]
        public void HasProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.HasProperty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.GetProperty))]
        public void GetProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.GetProperty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.SetProperty))]
        public void SetProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.SetProperty
            }

        }
    }