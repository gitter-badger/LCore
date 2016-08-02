using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class DictionaryExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] {typeof(DictionaryExt)};

        [Fact]
        public void Test_Merge()
            {
            var Test = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["b"] = "c",
                ["c"] = "d"
                };

            var Test2 = new Dictionary<string, string>
                {
                ["d"] = "e",
                ["e"] = "f",
                ["f"] = "g"
                };

            Test.Merge(Test2);

            Test.Keys.Count.Should().Be(6);

            Test.Merge(Test2);

            Test.Keys.Count.Should().Be(6);

            var Test3 = new Dictionary<string, string>
                {
                ["g"] = "e",
                ["h"] = "f",
                ["i"] = "g"
                };

            Test.Merge(Test3);

            Test.Keys.Count.Should().Be(9);

            Test.Keys.List().Should().Equal(new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i"});

            Test.Merge(Test3, Value => new KeyValuePair<string, string>($"{Value.Key}a", $"{Value.Value}b"));

            Test.Keys.Count.Should().Be(12);

            Test.Keys.List().Should().Equal(new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "ga", "ha", "ia"});
            }

        [Fact]
        public void Test_AddRange()
            {
            var Test = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["b"] = "c",
                ["c"] = "d"
                };
            var Test2 = new Dictionary<string, string>
                {
                ["d"] = "e",
                ["e"] = "f",
                ["f"] = "g"
                };

            Test.AddRange(Test2);
            }


        [Fact]
        public void Test_SafeAdd()
            {
            ((Dictionary<string, string>) null).SafeAdd("a", "b");

            var Test = new Dictionary<string, string>();

            Test.SafeAdd("a", "b");
            Test.SafeAdd("a", "c");

            Test.Keys.Count.Should().Be(1);
            Test["a"].Should().Be("b");

            Test.SafeAdd(null, null);
            Test.Keys.Count.Should().Be(1);
            Test.SafeAdd(null, "");
            Test.Keys.Count.Should().Be(1);
            Test.SafeAdd("", null);
            Test.Keys.Count.Should().Be(2);
            Test.SafeAdd("", "");
            Test.Keys.Count.Should().Be(2);
            Test[""].Should().Be(null);
            }


        [Fact]
        public void Test_SafeSet()
            {
            ((Dictionary<string, string>) null).SafeSet("a", "b");

            var Test = new Dictionary<string, string>();

            Test.SafeSet("a", "b");
            Test.SafeSet("a", "c");

            Test.Keys.Count.Should().Be(1);
            Test["a"].Should().Be("c");

            Test.SafeSet(null, null);
            Test.SafeSet(null, "");
            Test.SafeSet(null, "c");

            Test.SafeSet("", "c");
            Test.Keys.Count.Should().Be(2);
            Test[""].Should().Be("c");
            }


        [Fact]
        public void Test_SafeGet()
            {
            ((Dictionary<string, string>) null).SafeGet("a").Should().BeNull();

            var Test = new Dictionary<string, string>();
            Test.SafeSet("a", "b");

            Test.SafeGet("a").Should().Be("b");
            Test.SafeGet("b").Should().Be(null);
            }


        [Fact]
        public void Test_GetAllValues()
            {
            ((Dictionary<string, int[]>) null).GetAllValues<string, int, int[]>()
                .Should().Equal(new List<int>());

            var Test = new Dictionary<string, int[]>
                {
                {"a", new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}},
                {"b", new[] {10, 11, 12, 13, 14, 15, 16, 17, 18}},
                {"c", new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}}
                };

            Test.GetAllValues<string, int, int[]>()
                .Should().Equal(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            }
        }
    }