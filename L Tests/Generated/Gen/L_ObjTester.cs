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
    public partial class L_ObjTester : XUnitOutputTester, IDisposable
        {
        public L_ObjTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.As) + "() => Func`2<Object, T>")]
        public void As()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.As
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.Swap) + "(T&, T&)")]
        public void Swap()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.Swap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.SafeEquals) + "(Object, Object) => Boolean")]
        public void SafeEquals()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.SafeEquals
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.New) + "(Object[]) => T")]
        public void New()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.NewRandom) + "(Nullable`1<T>, Nullable`1<T>) => T")]
        public void NewRandom_Nullable_1_T_Nullable_1_T_T()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.NewRandom
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.NewRandom) + "(Type, Object, Object) => Object")]
        public void NewRandom_Type_Object_Object_Object()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.NewRandom
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.IsNull) + "() => Func`2<T, Boolean>")]
        public void IsNull()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.IsNull
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.IsA) + "() => Func`2<Object, Boolean>")]
        public void IsA()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.IsA
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.HasProperty) + "() => Func`3<Object, String, Boolean>")]
        public void HasProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.HasProperty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.GetProperty) + "() => Func`3<Object, String, Object>")]
        public void GetProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.GetProperty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Obj) + "." + nameof(L.Obj.SetProperty) + "() => Action`3<Object, String, Object>")]
        public void SetProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Obj.SetProperty
            }

        }
    }