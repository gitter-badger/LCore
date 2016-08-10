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
    public partial class L_RefTester : XUnitOutputTester
        {
        public L_RefTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_RefTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Constant))]
        public void Constant()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Constant
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Constructor))]
        public void Constructor()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Constructor
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.FindType))]
        public void FindType()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.FindType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.FindMember))]
        public void FindMember()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.FindMember
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.GetNamespaceTypes))]
        public void GetNamespaceTypes_String_TypeArray_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.GetNamespaceTypes))]
        public void GetNamespaceTypes_Type_String_TypeArray_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.GetNamespaceTypes))]
        public void GetNamespaceTypes_Assembly_String_TypeArray_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Member))]
        public void Member()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Member
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Method))]
        public void Method()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Method
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.StaticMethod))]
        public void StaticMethod()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.StaticMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Event))]
        public void Event()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Event
            }

        }
    }