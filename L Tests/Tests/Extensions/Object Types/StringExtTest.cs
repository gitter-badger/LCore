
using LCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;
using LCore.Tests;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable RedundantCast

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class StringExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(StringExt) };


        [Fact]
        
        public void Test_ReplaceAll_Dictionary()
            {
            var Replacements = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "short"
                };

            const string Test = "aab long long aaa along";

            // ReSharper disable once StringLiteralTypo
            Test.ReplaceAll(Replacements).Should().Be("bbb short short bbb bshort");

            Test.ReplaceAll((Dictionary<string, string>)null).Should().Be(Test);

            var Replacements2 = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "a"
                };

            L.F<string, Dictionary<string, string>, string>(StringExt.ReplaceAll).ShouldFail(Test, Replacements2);
            }


        [Fact]
        
        public void Test_ToStream()
            {
            // ReSharper disable once StringLiteralTypo
            const string Test = "abcdefghijklmnopqrstuvwxyz";
            var Result = Test.ToStream();

            Result.Length.Should().Be(Test.Length);

            var Test2 = new byte[Test.Length];

            Result.Read(Test2, 0, Test2.Length);

            Test2.Should().Equal(97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122);


            const string Test3 = null;
            var Result2 = Test3.ToStream();

            Result2.Length.Should().Be(0);
            }


        [Fact]
        
        public void Test_Matches()
            {
            const string Test = "123 456";
            List<Match> Matches = Test.Matches(@"\d+");

            Matches.Should().HaveCount(2);
            Matches[0].Value.Should().Be("123");
            Matches[1].Value.Should().Be("456");


            Test.Matches(null).Should().HaveCount(0);
            Test.Matches("").Should().HaveCount(0);
            ((string)null).Matches(null).Should().HaveCount(0);
            ((string)null).Matches("").Should().HaveCount(0);
            }
        }
    }
