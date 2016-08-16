using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_ListTester : XUnitOutputTester, IDisposable
        {
        public L_ListTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." +
            nameof(L.List.NewList) + "() => T")]
        public void NewList()
            {
            L.List.NewList<List<int>, int>().Should().Equal();
            L.List.NewList<List<string>, string>().Should().Equal();
            L.List.NewList<string, char>().ShouldBe("");


            L.A(() => L.List.NewList<IEnumerable<char>, char>()).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." +
            nameof(L.List.ToList) + "() => Func`1<List`1<T>>")]
        public void ToList_Func_1_List_1_T()
            {
            L.List.ToList<int>()()
                .Should()
                .BeOfType<List<int>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "List`1<Int32> {  }");
            L.List.ToList<string>()()
                .Should()
                .BeOfType<List<string>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "List`1<String> {  }");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.List) + "." +
            nameof(L.List.ToList) + "(T[]) => Func`1<List`1<T>>")]
        public void ToList_T_Func_1_List_1_T()
            {
            L.List.ToList(1, 2, 3)()
                .Should()
                .BeOfType<List<int>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "List`1<Int32> { 1, 2, 3 }");

            L.List.ToList("a", "b", "c")()
                .Should()
                .BeOfType<List<string>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "List`1<String> { a, b, c }");
            }
        }
    }