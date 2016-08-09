using System;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests.Tools
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
    public class SetTest
        {
        [Fact]
        public void TestSets()
            {
            var Test = new Set<int, string>(Obj1: 5, Obj2: "4");

            Test.Obj1.Should().Be(expected: 5);
            Test.Obj2.Should().Be("4");

            var Test2 = new Set<int?, string>(Obj1: null, Obj2: null);

            Test2.Obj1.Should().Be(expected: null);
            Test2.Obj2.Should().Be(expected: null);
            }

        [Fact]
        public void Test_Equals()
            {
            var Test = new Set<int, string>(Obj1: 5, Obj2: "4");
            var Test2 = new Set<int, string>(Obj1: 5, Obj2: "4");

            Test.Equals(Other: null).Should().BeFalse();
            Test.Equals(Test2).Should().BeTrue();
            Test.Equals(Test).Should().BeTrue();
            Test.Equals((object) null).Should().BeFalse();
            Test.Equals((object) Test2).Should().BeTrue();
            Test.Equals((object) Test).Should().BeTrue();
            Test.Equals("").Should().BeFalse();

            Test.GetHashCode().Should().Be(expected: 372027467);
            Test2.GetHashCode().Should().Be(expected: 372027467);
            }
        }
    }