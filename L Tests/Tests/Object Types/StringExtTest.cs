
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Tests;

// ReSharper disable RedundantCast

namespace L_Tests
    {
    [TestClass]
    public class StringExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(StringExt) };


        [TestMethod]
        public void Test_ReplaceAll_Dictionary()
            {
            var replacements = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "short"
                };

            const string test = "aab long long aaa along";

            // ReSharper disable once StringLiteralTypo
            test.ReplaceAll(replacements).Should().Be("bbb short short bbb bshort");

            test.ReplaceAll((Dictionary<string, string>)null).Should().Be(test);

            var replacements2 = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["long"] = "a"
                };

            L.F<string, Dictionary<string, string>, string>(StringExt.ReplaceAll).ShouldFail(test, replacements2);
            }


        [TestMethod]
        public void Test_ToStream()
            {
            // ReSharper disable once StringLiteralTypo
            const string test = "abcdefghijklmnopqrstuvwxyz";
            var result = test.ToStream();

            result.Length.Should().Be(test.Length);

            var test2 = new byte[test.Length];

            result.Read(test2, 0, test2.Length);

            test2.ShouldBeEquivalentTo(new byte[] { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 });


            const string test3 = null;
            var result2 = test3.ToStream();

            result2.Length.Should().Be(0);
            }
        }
    }
