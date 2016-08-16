using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tests;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ArgumentsStyleLiteral

// ReSharper disable InvokeAsExtensionMethod

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_RefTester : XUnitOutputTester, IDisposable
        {
        public L_RefTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." +
            nameof(L.Ref.GetNamespaceTypes) + "(String, Type[]) => Type[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." +
            nameof(L.Ref.GetNamespaceTypes) + "(Type, String, Type[]) => Type[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." +
            nameof(L.Ref.GetNamespaceTypes) + "(Assembly, String, Type[]) => Type[]")]
        public void GetNamespaceTypes()
            {
            L.Ref.GetNamespaceTypes("LCore.Tests").ShouldBeEquivalentTo(new List<Type>
                {
                typeof(LCoreAssemblyTester)
                });

            L.Ref.GetNamespaceTypes("LCore", typeof(L)).Should().Equal();

            L.Ref.GetNamespaceTypes(typeof(L), "LCore.Extensions", typeof(L)).ShouldBeEquivalentTo(new List<Type>
                {
                typeof(L)
                });

            L.Ref.GetNamespaceTypes(Assembly.GetAssembly(typeof(L)), "LCore.Extensions", typeof(L)).ShouldBeEquivalentTo(new List<Type>
                {
                typeof(L)
                });
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Constructor) + "(Expression`1<Func`1<T>>) => ConstructorInfo")]
        public void Constructor()
            {
            var Constructor = L.Ref.Constructor(() => new Set<string, string>("", ""));

            var Test = Constructor.Invoke(new object[] {"a", "b"});

            Test.ShouldBe(new Set<string, string>("a", "b"));
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.FindType) + "(String, Assembly[]) => Type")]
        public void FindType()
            {
            L.Ref.FindType($"{nameof(System)}.{nameof(Object)}").ShouldBe(typeof(object));

            L.Ref.FindType($"{nameof(System)}.{nameof(String)}").ShouldBe(typeof(string));

            L.Ref.FindType($"{nameof(L)}.{nameof(L.Ref)}").ShouldBe(typeof(L.Ref));
            L.Ref.FindType($"{typeof(L).Namespace}.{nameof(L)}.{nameof(L.Ref)}").ShouldBe(typeof(L.Ref));

            L.Ref.FindType($"{typeof(L).Namespace}.{nameof(L)}.{nameof(L.Ref)}", typeof(LCoreAssemblyTester).GetAssembly()).ShouldBeNull();
            L.Ref.FindType($"{typeof(L).Namespace}.{nameof(L)}.{nameof(L.Ref)}", typeof(L).GetAssembly()).ShouldBe(typeof(L.Ref));


            L.Ref.FindType("nope").ShouldBeNull();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.FindMembers) + "(String, Assembly[]) => MemberInfo[]")]
        public void FindMembers()
            {
            var Member = L.Ref.FindMembers($"{nameof(L)}.{nameof(L.Ref)}.{nameof(L.Ref.FindMembers)}").First();

            Member.ShouldNotBeNull();

            var Members = (MemberInfo[]) ((MethodInfo) Member)?.Invoke(obj: null, parameters: new object[] {$"{typeof(L).Namespace}.{nameof(L)}.{nameof(L.Ref)}.{nameof(L.Ref.FindMembers)}", null});

            Members.First().ShouldBe(Member);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Member) + "(Expression`1<Func`2<T, Object>>) => MemberInfo")]
        public void Member()
            {
            L.Ref.Member<object>(o => o.ToString()).ShouldBeNull();

            L.Ref.Member<object>(Expr: null).ShouldBeNull();

            var Member = L.Ref.Member<ReflectionExtTester.TestClass>(o => o.Test);

            Member.ShouldNotBeNull();
            
            var Test = new ReflectionExtTester.TestClass {Test = "a"};

            (Member as PropertyInfo)?.GetValue(Test).ShouldBe("a");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.Method) + "(Expression`1<Action`1<T>>) => MethodInfo")]
        public void Method()
            {
            L.Ref.Method<object>(o => o.ToString()).ShouldNotBeNull();

            L.Ref.Method<object>(Expr: null).ShouldBeNull();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Ref) + "." + nameof(L.Ref.StaticMethod) + "(Expression`1<Action>) => MethodInfo")]
        public void StaticMethod()
            {
            L.Ref.StaticMethod(() => StringExt.AlignLeft("", 0, ' ')).ShouldNotBeNull();

            L.Ref.StaticMethod(Expr: null).ShouldBeNull();
            }
        }
    }