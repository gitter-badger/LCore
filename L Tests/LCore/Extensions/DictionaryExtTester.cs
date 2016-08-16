using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt))]
    public partial class DictionaryExtTester : XUnitOutputTester, IDisposable
        {
        public DictionaryExtTester([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." +
            nameof(DictionaryExt.Merge) +
            "(IDictionary`2<TKey, TValue>, IDictionary`2<TKey, TValue>, Func`2<KeyValuePair`2<TKey, TValue>, KeyValuePair`2<TKey, TValue>>)")]
        public void Merge()
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

            Test.Keys.Count.ShouldBe(Compare: 6);

            Test.Merge(Test2);

            Test.Keys.Count.ShouldBe(Compare: 6);

            var Test3 = new Dictionary<string, string>
                {
                ["g"] = "e",
                ["h"] = "f",
                ["i"] = "g"
                };

            Test.Merge(Test3);

            Test.Keys.Count.ShouldBe(Compare: 9);

            Test.Keys.List().Should().Equal(new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i"});

            Test.Merge(Test3, Value => new KeyValuePair<string, string>($"{Value.Key}a", $"{Value.Value}b"));

            Test.Keys.Count.ShouldBe(Compare: 12);

            Test.Keys.List().Should().Equal(new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "ga", "ha", "ia"});
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." +
            nameof(DictionaryExt.AddRange) + "(IDictionary`2<TKey, TValue>, IDictionary`2<TKey, TValue>)")]
        public void AddRange()
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
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." +
            nameof(DictionaryExt.SafeAdd) + "(IDictionary`2<TKey, TValue>, TKey, TValue)")]
        public void SafeAdd()
            {
            ((Dictionary<string, string>) null).SafeAdd("a", "b");

            var Test = new Dictionary<string, string>();

            Test.SafeAdd("a", "b");
            Test.SafeAdd("a", "c");

            Test.Keys.Count.ShouldBe(Compare: 1);
            Test["a"].ShouldBe("b");

            Test.SafeAdd(Key: null, Val: null);
            Test.Keys.Count.ShouldBe(Compare: 1);
            Test.SafeAdd(Key: null, Val: "");
            Test.Keys.Count.ShouldBe(Compare: 1);
            Test.SafeAdd("", Val: null);
            Test.Keys.Count.ShouldBe(Compare: 2);
            Test.SafeAdd("", "");
            Test.Keys.Count.ShouldBe(Compare: 2);
            Test[""].ShouldBe(Compare: null);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." +
            nameof(DictionaryExt.SafeGet) + "(IDictionary`2<TKey, TValue>, TKey) => TValue")]
        public void SafeSet()
            {
            ((Dictionary<string, string>) null).SafeSet("a", "b");

            var Test = new Dictionary<string, string>();

            Test.SafeSet("a", "b");
            Test.SafeSet("a", "c");

            Test.Keys.Count.ShouldBe(Compare: 1);
            Test["a"].ShouldBe("c");

            Test.SafeSet(Key: null, Val: null);
            Test.SafeSet(Key: null, Val: "");
            Test.SafeSet(Key: null, Val: "c");

            Test.SafeSet("", "c");
            Test.Keys.Count.ShouldBe(Compare: 2);
            Test[""].ShouldBe("c");
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." +
            nameof(DictionaryExt.SafeSet) + "(IDictionary`2<TKey, TValue>, TKey, TValue)")]
        public void SafeGet()
            {
            ((Dictionary<string, string>) null).SafeGet("a").Should().BeNull();

            var Test = new Dictionary<string, string>();
            Test.SafeSet("a", "b");

            Test.SafeGet("a").ShouldBe("b");
            Test.SafeGet("b").ShouldBe(Compare: null);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." +
            nameof(DictionaryExt.GetAllValues) + "(Dictionary`2<TKey, TValueList>) => List`1<TValue>")]
        public void GetAllValues()
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
                // ReSharper disable ArgumentsStyleLiteral
                .Should().Equal(new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            // ReSharper restore ArgumentsStyleLiteral
            }
        }
    }