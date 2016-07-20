using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tests;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

// ReSharper disable ObjectCreationAsStatement

namespace L_Tests.Tests.Tools
    {
    public class ListsTest
        {
        [Fact]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_Lists()
            {
            var Test = new Lists<string, int>();

            Test.Add("a", 1);

            Test.Count.Should().Be(1);
            Test.GetAt(0).ShouldBeEquivalentTo(new Set<string, int>("a", 1));

            Test.Set(0, "b", 2);

            Test.GetAt(0).ShouldBeEquivalentTo(new Set<string, int>("b", 2));

            Test.Set1(0, "c");

            Test.GetAt(0).ShouldBeEquivalentTo(new Set<string, int>("c", 2));

            Test.Set2(0, 3);

            Test.GetAt(0).ShouldBeEquivalentTo(new Set<string, int>("c", 3));

            var Rand = new Random();

            L.A(() => Test.Add(Guid.NewGuid().ToString(), Rand.Next())).Repeat(100)();

            Test.Count.Should().Be(102);

            Test.RemoveAt(1);

            Test.Count.Should().Be(101);
            Test.List1.Count.Should().Be(101);
            Test.List2.Count.Should().Be(101);

            Test.GetAt(0).ShouldBeEquivalentTo(new Set<string, int>("c", 3));

            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_ListFailures()
            {
            L.A(() => new Lists<string, int>(null, new List<int>())).ShouldFail();
            L.A(() => new Lists<string, int>(new List<string>(), null)).ShouldFail();
            L.A(() => new Lists<string, int>(new List<string> { "a" }, new List<int>())).ShouldFail();
            }
        }
    }
