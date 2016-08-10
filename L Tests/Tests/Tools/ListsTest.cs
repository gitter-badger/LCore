using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable ObjectCreationAsStatement

namespace LCore.Tests.Tools
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
    public class ListsTest
        {
        [Fact]
        public void Test_Lists()
            {
            var Test = new Lists<string, int>();

            Test.Add("a", o2: 1);

            Test.Count.Should().Be(expected: 1);
            Test.GetAt(Index: 0).Should().Be(new Set<string, int>("a", Obj2: 1));

            Test.Set(Index: 0, Value: "b", Value2: 2);

            Test.GetAt(Index: 0).Should().Be(new Set<string, int>("b", Obj2: 2));

            Test.Set1(Index: 0, Value: "c");

            Test.GetAt(Index: 0).Should().Be(new Set<string, int>("c", Obj2: 2));

            Test.Set2(Index: 0, Value: 3);

            Test.GetAt(Index: 0).Should().Be(new Set<string, int>("c", Obj2: 3));

            var Rand = new Random();

            L.A(() => Test.Add(Guid.NewGuid().ToString(), Rand.Next())).Repeat(Times: 100)();

            Test.Count.Should().Be(expected: 102);

            Test.RemoveAt(Index: 1);

            Test.Count.Should().Be(expected: 101);
            Test.List1.Count.Should().Be(expected: 101);
            Test.List2.Count.Should().Be(expected: 101);

            Test.GetAt(Index: 0).Should().Be(new Set<string, int>("c", Obj2: 3));

            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_ListFailures()
            {
            L.A(() => new Lists<string, int>(List1: null, List2: new List<int>())).ShouldFail();
            L.A(() => new Lists<string, int>(new List<string>(), List2: null)).ShouldFail();
            L.A(() => new Lists<string, int>(new List<string> { "a" }, new List<int>())).ShouldFail();
            }
        }
    }
