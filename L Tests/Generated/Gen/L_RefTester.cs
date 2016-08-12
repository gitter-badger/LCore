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
    public partial class L_RefTester : XUnitOutputTester, IDisposable
        {
        public L_RefTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Constant) + "(String) => MemberInfo")]
        public void Constant()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Constant
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Constructor) + "(Expression`1<Func`1<T>>) => ConstructorInfo")]
        public void Constructor()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Constructor
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.FindType) + "(String, Assembly[]) => Type")]
        public void FindType()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.FindType
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.FindMember) + "(String, Assembly[]) => MemberInfo[]")]
        public void FindMember()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.FindMember
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.GetNamespaceTypes) + "(String, Type[]) => Type[]")]
        public void GetNamespaceTypes_String_Type_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.GetNamespaceTypes) + "(Type, String, Type[]) => Type[]")]
        public void GetNamespaceTypes_Type_String_Type_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.GetNamespaceTypes) + "(Assembly, String, Type[]) => Type[]")]
        public void GetNamespaceTypes_Assembly_String_Type_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Member) + "(Expression`1<Func`2<T, Object>>) => MemberInfo")]
        public void Member()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Member
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Method) + "(Expression`1<Action`1<T>>) => MethodInfo")]
        public void Method()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Method
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.StaticMethod) + "(Expression`1<Action>) => MethodInfo")]
        public void StaticMethod()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.StaticMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Event) + "(String) => EventInfo")]
        public void Event()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Event
            }

        }
    }