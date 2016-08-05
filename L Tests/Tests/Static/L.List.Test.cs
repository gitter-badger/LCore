using LCore.Extensions;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions.Optional;
using LCore.LUnit.Fluent;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class ListTest
        {
        [Fact]
        public void Test_List()
            {
            L.List.ToList<int>()()
                .Should()
                .BeOfType<List<int>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "System.Collections.Generic.List`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] {  }");
            L.List.ToList<string>()()
                .Should()
                .BeOfType<List<string>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] {  }");


            L.List.ToList(1, 2, 3)()
                .Should()
                .BeOfType<List<int>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "System.Collections.Generic.List`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] { 1, 2, 3 }");

            L.List.ToList("a", "b", "c")()
                .Should()
                .BeOfType<List<string>>()
                .And.Subject.ToS()
                .Should()
                .Be(
                    "System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] { a, b, c }");
            }

        [Fact]
        public void Test_NewList()
            {
            L.List.NewList<List<int>, int>().Should().Equal();
            L.List.NewList<List<string>, string>().Should().Equal();
            L.List.NewList<string, char>().Should().Be("");


            L.A(() => L.List.NewList<IEnumerable<char>, char>()).ShouldFail();
            }
        }
    }