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
            var Test = new Set<int, string>(5, "4");

            Test.Obj1.Should().Be(5);
            Test.Obj2.Should().Be("4");

            var Test2 = new Set<int?, string>(null, null);

            Test2.Obj1.Should().Be(null);
            Test2.Obj2.Should().Be(null);
            }

        [Fact]
        public void Test_Equals()
            {
            var Test = new Set<int, string>(5, "4");
            var Test2 = new Set<int, string>(5, "4");

            Test.Equals(null).Should().BeFalse();
            Test.Equals(Test2).Should().BeTrue();
            Test.Equals(Test).Should().BeTrue();
            Test.Equals((object)null).Should().BeFalse();
            Test.Equals((object)Test2).Should().BeTrue();
            Test.Equals((object)Test).Should().BeTrue();
            Test.Equals("").Should().BeFalse();

            Test.GetHashCode().Should().Be(372027467);
            Test2.GetHashCode().Should().Be(372027467);
            }
        }
    }
