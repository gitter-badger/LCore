﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantCast

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt))]
    public partial class StringExtTester : XUnitOutputTester, IDisposable
        {
        public StringExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." +
            nameof(StringExt.ReplaceAll) + "(String, IDictionary<String, String>) => String")]
        public void ReplaceAll_Dictionary()
            {
            var Replacements = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "short"
                };

            const string Test = "aab long long aaa along";

            // ReSharper disable once StringLiteralTypo
            Test.ReplaceAll(Replacements).ShouldBe("bbb short short bbb bshort");

            Test.ReplaceAll((Dictionary<string, string>)null).ShouldBe(Test);

            var Replacements2 = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "a"
                };

            L.F<string, Dictionary<string, string>, string>(StringExt.ReplaceAll).ShouldFail(Test, Replacements2);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." +
            nameof(StringExt.ToStream) + "(String) => Stream")]
        public void ToStream()
            {
            // ReSharper disable once StringLiteralTypo
            const string Test = "abcdefghijklmnopqrstuvwxyz";
            var Result = Test.ToStream();

            Result.Length.ShouldBe(Test.Length);

            var Test2 = new byte[Test.Length];

            Result.Read(Test2, offset: 0, count: Test2.Length);

            Test2.Should().Equal(97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122);


            const string Test3 = null;
            var Result2 = Test3.ToStream();

            Result2.Length.ShouldBe(Compare: 0);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(StringExt) + "." +
            nameof(StringExt.Matches) + "(String, String) => List<Match>")]
        public void Matches()
            {
            const string Test = "123 456";
            List<Match> Matches = Test.Matches(@"\d+");

            Matches.Should().HaveCount(expected: 2);
            Matches[index: 0].Value.ShouldBe("123");
            Matches[index: 1].Value.ShouldBe("456");


            Test.Matches(Expression: null).Should().HaveCount(expected: 0);
            Test.Matches("").Should().HaveCount(expected: 0);
            ((string)null).Matches(Expression: null).Should().HaveCount(expected: 0);
            ((string)null).Matches("").Should().HaveCount(expected: 0);
            }

        }
    }