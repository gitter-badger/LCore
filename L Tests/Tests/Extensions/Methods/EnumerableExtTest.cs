using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using LCore.Extensions.Optional;
using LCore.Interfaces;
using LCore.Tests;
using Xunit;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable RedundantArgumentDefaultValue

// ReSharper disable RedundantCast
// ReSharper disable RedundantTypeArgumentsOfMethod
// ReSharper disable RedundantExplicitArrayCreation
// ReSharper disable UnusedVariable

namespace L_Tests.Tests.Extensions
    {
    public class EnumerableExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(EnumerableExt) };


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_All_0()
            {
            var Test = new[] { 1, 5, 7, 3, 4, 7, 4, 7, 10 };

            ((IEnumerable)Test).All((Func<object, bool>)(o => (int)o < 15)).Should().BeTrue();
            ((IEnumerable)Test).All((Func<object, bool>)(o => (int)o < 10)).Should().BeFalse();

            int Count = 0;

            ((IEnumerable)Test).All((Func<int, object, bool>)((i, o) =>
                {
                    i.Should().Be(Count);
                    Count++;
                    return (int)o < 15;
                })).Should().BeTrue();
            Count = 0;
            ((IEnumerable)Test).All((Func<int, object, bool>)((i, o) =>
            {
                i.Should().Be(Count);
                Count++;
                return (int)o < 10;
            })).Should().BeFalse();

            Test.All((i1, i2) => i2 < 11).Should().BeTrue();
            Test.All((i1, i2) => i2 < 10).Should().BeFalse();

            Test.All((i, i2) => i2 < 15).Should().BeTrue();
            Test.All((i, i2) => i2 < 10).Should().BeFalse();

            ((IEnumerable)Test).All<int>((i, o) => o < 15).Should().BeTrue();
            ((IEnumerable)Test).All<int>((i, o) => o < 10).Should().BeFalse();

            ((IEnumerable<int>)Test).All<int>((i, o) => o < 15).Should().BeTrue();
            ((IEnumerable<int>)Test).All<int>((i, o) => o < 10).Should().BeFalse();

            ((IEnumerable<int>)Test).All<int>(o => o < 15).Should().BeTrue();
            ((IEnumerable<int>)Test).All<int>(o => o < 10).Should().BeFalse();
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Append()
            {
            var Test1 = new int[] { 1, 5, 9, 5, 3 };
            var Test2 = new int[] { 55, 55, 55, 55 };

            ((int[])null).Append(Test2).Should().Equal(55, 55, 55, 55);
            Test2.Append((int[])null).Should().Equal(55, 55, 55, 55);

            ((int[])null).Append(Test1).Should().Equal(1, 5, 9, 5, 3);
            Test1.Append((int[])null).Should().Equal(1, 5, 9, 5, 3);

            Test1.Append(Test2).Should().Equal(1, 5, 9, 5, 3, 55, 55, 55, 55);
            Test2.Append(Test1).Should().Equal(55, 55, 55, 55, 1, 5, 9, 5, 3);
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Array()
            {
            var Test1 = new List<int> { 1, 5, 9, 5, 3 };
            var Test2 = new List<object> { 1, 5, 9, 5, 3, "s" };

            ((IEnumerable)Test1).Array().Should().Equal(1, 5, 9, 5, 3);
            ((IEnumerable)Test2).Array().Should().Equal(1, 5, 9, 5, 3, "s");

            ((IEnumerable<int>)Test1).Array().Should().Equal(1, 5, 9, 5, 3);
            ((IEnumerable<object>)Test2).Array().Should().Equal(1, 5, 9, 5, 3, "s");

            ((IEnumerable)Test1).Array<int>().Should().Equal(1, 5, 9, 5, 3);
            ((IEnumerable)Test2).Array<int>().Should().Equal(1, 5, 9, 5, 3);

            ((IEnumerable<object>)Test2).Array<object, IComparable>().Should().Equal(1, 5, 9, 5, 3, "s");
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_CollectFunc()
            {
            int Counter = 0;
            Func<int> Func = () => ++Counter;

            Func.Collect(0).Should().Equal();
            Func.Collect(1).Should().Equal(1);
            Func.Collect(5).Should().Equal(2, 3, 4, 5, 6);

            L.A(() => Func.Collect(-1)).ShouldFail();

            Counter = 0;

            Func<int, int> Func2 = i =>
                 {
                     Counter += i;
                     return Counter;
                 };

            Func2.Collect(0).Should().Equal();
            Func2.Collect(1).Should().Equal(0);
            Func2.Collect(5).Should().Equal(0, 1, 3, 6, 10);

            L.A(() => Func2.Collect(-1)).ShouldFail();
            }

        [Fact]
        public void Test_CollectStr()
            {
            Func<char, char> Modifier = Char => (char)(Char + 1);
            Func<int, int, string> Modifier2 = (i, o) => $"{o}-";

            ((string)null).CollectStr(Modifier).Should().Be("");
            "abc".CollectStr(null).Should().Be("abc");

            "abc".CollectStr(Modifier).Should().Be("bcd");


            ((int[])null).CollectStr(Modifier2).Should().Be("");
            ((List<int>)null).CollectStr(Modifier2).Should().Be("");

            new[] { 5, 1, 77, 2, 7, 3 }.CollectStr(Modifier2).Should().Be("5-1-77-2-7-3-");
            new[] { 5, 1, 77, 2, 7, 3 }.CollectStr(null).Should().Be("5177273");

            new[] { 5, 1, 77, 2, 7, 3 }.List().CollectStr(Modifier2).Should().Be("5-1-77-2-7-3-");
            new[] { 5, 1, 77, 2, 7, 3 }.List().CollectStr(null).Should().Be("5177273");

            ((List<int>)null).CollectStr<int, List<int>>(Modifier2).Should().Be("");
            }

        [Fact]
        public void Test_CombineString()
            {
            var List = new IConvertible[] { 123, "abc", 5.5f, null, 'a' };

            List.Combine("--").Should().Be("123--abc--5.5--a");
            List.Combine(',').Should().Be("123,abc,5.5,a");

            List.Combine(null).Should().Be("123abc5.5a");
            List.Combine("").Should().Be("123abc5.5a");

            ((IConvertible[])null).Combine("--").Should().Be("");
            ((IConvertible[])null).Combine(',').Should().Be("");
            }

        [Fact]
        public void Test_Convert()
            {
            var List = new object[] { 123, "abc", 5.5f, null, 'a' };

            Func<object, object> Converter = o => o?.ToString();

            ((IEnumerable)List).Convert(Converter).Should().Equal("123", "abc", "5.5", "a");

            ((IEnumerable)List).Convert((Func<object, object>)null).Should().Equal(123, "abc", 5.5f, 'a');

            ((IEnumerable)null).Convert(Converter).Should().Equal();

            Func<object, string> Converter2 = o => o?.ToString();

            ((IEnumerable<object>)List).Convert(Converter2).Should().Equal("123", "abc", "5.5", "a");

            ((IEnumerable<object>)List).Convert((Func<object, string>)null).Should().Equal("abc");

            ((IEnumerable<object>)null).Convert(Converter2).Should().Equal();

            ((object[])List).Convert(Converter2).Should().Equal("123", "abc", "5.5", null, "a");

            ((object[])List).Convert((Func<object, string>)null).Should().Equal(null, "abc", null, null, null);

            ((object[])null).Convert(Converter2).Should().Equal();

            List.List().Convert(Converter2).Should().Equal("123", "abc", "5.5", "a");

            List.List().Convert((Func<object, string>)null).Should().Equal("abc");

            ((List<object>)null).List().Convert(Converter2).Should().Equal();
            }

        [Fact]
        public void Test_ConvertAll()
            {
            var List = new object[] { 123, "abc", 5.5f, null, 'a' };

            Func<object, string[]> Converter = o => new[] { o?.ToString(), o?.ToString() };

            ((IEnumerable)List).ConvertAll(Converter).Should().Equal(
                new List<string> { "123", "123", "abc", "abc", "5.5", "5.5", "a", "a" });

            ((IEnumerable)null).ConvertAll(Converter).Should().Equal(
                new List<string>());


            ((IEnumerable<object>)List).ConvertAll<object, string>(Converter).Should().Equal(
                new List<string> { "123", "123", "abc", "abc", "5.5", "5.5", "a", "a" });

            ((IEnumerable<object>)null).ConvertAll<object, string>(Converter).Should().Equal(
                new List<string>());

            }

        [Fact]
        public void Test_ConvertAll_1()
            {
            var List = new object[] { 123, "abc", 5.5f, null, 'a' };

            Func<object, IEnumerable<object>> Converter = o => new object[] { o?.ToString(), o?.ToString() };

            ((IEnumerable)List).ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");

            ((IEnumerable)null).ConvertAll(Converter).Should().Equal();


            ((IEnumerable<object>)List).ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");

            ((IEnumerable<object>)null).ConvertAll(Converter).Should().Equal();


            ((object[])List).ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");

            ((object[])null).ConvertAll(Converter).Should().Equal();


            List.List().ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");

            ((List<object>)null).ConvertAll(Converter).Should().Equal();
            }


        [Fact]
        public void Test_Count_T()
            {
            ((string)null).Count().Should().Be(0);
            ((IEnumerable)null).Count().Should().Be(0);
            ((ICollection)null).Count().Should().Be(0);
            ((IList)null).Count().Should().Be(0);
            ((IList<object>)null).Count().Should().Be(0);

            "55555".Count().Should().Be(5);

            new object[] { 1, 2, 3, 4, 5 }.Count().Should().Be(5);

            new List<object> { 1, 2, 3, 4, 5 }.Count().Should().Be(5);

            var Bad = new BadCollection(null, false);

            Bad.Count().Should().Be(0);
            }

        [Fact]
        public void Test_Count_Object()
            {
            var Test = new string[] { "a", "a", "a", "a", "b" };

            Test.Count((string)null).Should().Be(0);
            Test.Count("a").Should().Be(4);
            Test.Count("b").Should().Be(1);
            Test.Count("c").Should().Be(0);

            ((string[])null).Count("a").Should().Be(0);
            ((List<string>)null).Count("a").Should().Be(0);
            ((List<string>)null).Count("a").Should().Be(0);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Cycle()
            {
            var Test = new string[] { "a", "a", "a", "a", null, "a" };

            int Count = 0;

            // Test IEnumerable
            ((IEnumerable)Test).Cycle(Str =>
                {
                    Count++;
                    return Str != null;
                });

            Count.Should().Be(5);

            // Test IEnumerable<T>
            Count = 0;

            Test.Cycle(Str =>
            {
                Count++;
                return Str != null;
            });

            Count.Should().Be(5);

            // Test multiple cycles
            Count = 0;

            ((IEnumerable)Test).Cycle(Str =>
            {
                Count++;
                return Count < 7 || Str != null;
            });

            Count.Should().Be(11);

            // Test multiple cycles
            Count = 0;

            Test.Cycle(Str =>
            {
                Count++;
                return Count < 7 || Str != null;
            });

            Count.Should().Be(11);

            // Exceptions are not hidden.
            L.A(() => Test.Cycle(Str =>
                {
                    throw new Exception();
                })).ShouldFail();
            }

        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [Fact]
        public void Test_EachObject()
            {
            var Test = new string[] { "a", "b", "c" };
            string Result = "";

            L.A<string>(Str => { Result += Str; }).Each(Test);

            Result.Should().Be("abc");

            ((Action<string>)null).Each(Test);

            Action<string> Action = Str => { Result += Str; };

            L.A<string>(Action).Each(null);

            Result.Should().Be("abc");

            L.A<string>(Action).Each(Test);

            Result.Should().Be("abcabc");

            // Exceptions are not hidden.
            L.A(() =>
                L.A<string>(Str =>
                {
                    throw new Exception();
                }).Each(Test))
                .ShouldFail();
            }

        [Fact]
        public void Test_Equivalent()
            {
            int[] Test1 = { 5, 8, 3, 7, 84, 356, 1 };
            int[] Test2 = Test1.Array();
            int[] Test3 = { 5, 8, 3, 7, 84, 356, 2 };

            Test1.Equivalent(Test2).Should().BeTrue();
            Test1.Equivalent(Test3).Should().BeFalse();

            ((int[])null).Equivalent(Test2).Should().BeFalse();
            Test1.Equivalent((int[])null).Should().BeFalse();
            ((int[])null).Equivalent((int[])null).Should().BeTrue();


            "abc".Equivalent("abc").Should().BeTrue();
            "abc".Equivalent("abcd").Should().BeFalse();
            ((string)null).Equivalent("abcd").Should().BeFalse();
            "abc".Equivalent((string)null).Should().BeFalse();
            }

        [Fact]
        public void Test_Fill()
            {
            var Test = new int[5];

            Test.Fill(1).Should().Equal(1, 1, 1, 1, 1);

            ((int[])null).Fill(1).Should().Equal();

            new object[5].Fill(null)
                .Should().Equal();
            }
        [Fact]
        public void Test_Fill_List()
            {
            var Test = new int[5];

            Test.List().Fill(1).Should().Equal(1, 1, 1, 1, 1);

            ((List<int>)null).Fill(1).Should().Equal();

            new List<object> { 1, 2, 3, 4, 5 }.Fill(null)
                .Should().Equal();
            }

        [Fact]
        public void Test_Filter()
            {
            object[] Test = { 0, 5, "abc", "123", 'a', 'b', null };


            ((IEnumerable)null).Filter<int>()
                .Should().Equal(new List<int>());
            ((IEnumerable)Test).Filter<int>()
                .Should().Equal(0, 5);
            ((IEnumerable)Test).Filter<string>()
                .Should().Equal("abc", "123");
            ((IEnumerable)Test).Filter<object>()
                .Should().Equal(0, 5, "abc", "123", 'a', 'b');
            ((IEnumerable)Test).Filter<char>()
                .Should().Equal('a', 'b');


            ((object[])null).Filter<int>()
                .Should().Equal();
            Test.Filter<int>()
                .Should().Equal(0, 5);
            Test.Filter<string>()
                .Should().Equal("abc", "123");
            Test.Filter<char>()
                .Should().Equal('a', 'b');
            Test.Filter<object>()
                .Should().Equal(0, 5, "abc", "123", 'a', 'b');


            ((List<object>)null).Filter<int>()
                .Should().Equal();
            Test.List().Filter<object, int>()
                .Should().Equal(0, 5);
            Test.List().Filter<object, string>()
                .Should().Equal("abc", "123");
            Test.List().Filter<object, char>()
                .Should().Equal('a', 'b');
            Test.List().Filter<object, object>()
                .Should().Equal(0, 5, "abc", "123", 'a', 'b');
            }

        [Fact]
        public void Test_First()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            Test.First().Should().Be(5);
            Test.First(null).Should().Be(5);
            Test.First(i => false).Should().Be(default(int));
            Test.First(i => true).Should().Be(5);
            Test.First(i => i > 100).Should().Be(21436);
            Test.First(i => i > 100 && i < 1000).Should().Be(253);
            Test.First(i => i > 1000).Should().Be(21436);

            Test.List().First().Should().Be(5);
            Test.List().First(null).Should().Be(5);
            Test.List().First(i => false).Should().Be(default(int));
            Test.List().First(i => true).Should().Be(5);
            Test.List().First(i => i > 100).Should().Be(21436);
            Test.List().First(i => i > 100 && i < 1000).Should().Be(253);
            Test.List().First(i => i > 1000).Should().Be(21436);

            ((IEnumerable)Test).First<int>().Should().Be(5);
            ((IEnumerable)Test).First<int?>().Should().Be(5);
            ((IEnumerable)Test).First<int>(null).Should().Be(5);
            ((IEnumerable)Test).First<int>(i => false).Should().Be(default(int));
            ((IEnumerable)Test).First<int?>((Func<int?, bool>)null).Should().Be(5);
            ((IEnumerable)Test).First<int?>(i => false).Should().Be((int?)null);
            ((IEnumerable)Test).First<int>(i => true).Should().Be(5);
            ((IEnumerable)Test).First<int>(i => i > 100).Should().Be(21436);
            ((IEnumerable)Test).First<int>(i => i > 100 && i < 1000).Should().Be(253);
            ((IEnumerable)Test).First<int>(i => i > 1000).Should().Be(21436);
            }

        [Fact]
        public void Test_FirstMulti()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            Func<int, bool> True = i => true;
            Func<int, bool> False = i => false;

            Test.First(2).Should().Equal(5, 21436);
            Test.First(-5, True).Should().Equal();
            Test.First(0, True).Should().Equal();
            Test.First(2, False).Should().Equal();
            Test.First(2, True).Should().Equal(5, 21436);
            Test.First(5, i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.First(2, i => i > 100).Should().Equal(21436, 253);
            Test.First(2, i => i > 100 && i < 1000).Should().Equal(253);
            Test.First(2, i => i > 1000).Should().Equal(21436);

            Test.First(2u).Should().Equal(5, 21436);
            Test.First(0u, True).Should().Equal();
            Test.First(2u, False).Should().Equal();
            Test.First(2u, True).Should().Equal(5, 21436);
            Test.First(5u, i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.First(2u, i => i > 100).Should().Equal(21436, 253);
            Test.First(2u, i => i > 100 && i < 1000).Should().Equal(253);
            Test.First(2u, i => i > 1000).Should().Equal(21436);

            Test.List().First(2).Should().Equal(5, 21436);
            Test.List().First(-5, True).Should().Equal();
            Test.List().First(0, True).Should().Equal();
            Test.List().First(2, False).Should().Equal();
            Test.List().First(2, True).Should().Equal(5, 21436);
            Test.List().First(5, i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.List().First(2, i => i > 100).Should().Equal(21436, 253);
            Test.List().First(2, i => i > 100 && i < 1000).Should().Equal(253);
            Test.List().First(2, i => i > 1000).Should().Equal(21436);

            Test.List().First(2u).Should().Equal(5, 21436);
            Test.List().First(0u, True).Should().Equal();
            Test.List().First(2u, False).Should().Equal();
            Test.List().First(2u, True).Should().Equal(5, 21436);
            Test.List().First(5u, i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.List().First(2u, i => i > 100).Should().Equal(21436, 253);
            Test.List().First(2u, i => i > 100 && i < 1000).Should().Equal(253);
            Test.List().First(2u, i => i > 1000).Should().Equal(21436);

            ((IEnumerable)Test).First<int>(2, null).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(-5, True).Should().Equal();
            ((IEnumerable)Test).First<int>(0, True).Should().Equal();
            ((IEnumerable)Test).First<int>(2, False).Should().Equal();
            ((IEnumerable)Test).First<int>(2, True).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(5, i => i > 2).Should().Equal(5, 21436, 7, 253);
            ((IEnumerable)Test).First<int>(2, i => i > 100).Should().Equal(21436, 253);
            ((IEnumerable)Test).First<int>(2, i => i > 100 && i < 1000).Should().Equal(253);
            ((IEnumerable)Test).First<int>(2, i => i > 1000).Should().Equal(21436);

            ((IEnumerable)Test).First<int>(2u, null).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(0u, True).Should().Equal();
            ((IEnumerable)Test).First<int>(2u, False).Should().Equal();
            ((IEnumerable)Test).First<int>(2u, True).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(5u, i => i > 2).Should().Equal(5, 21436, 7, 253);
            ((IEnumerable)Test).First<int>(2u, i => i > 100).Should().Equal(21436, 253);
            ((IEnumerable)Test).First<int>(2u, i => i > 100 && i < 1000).Should().Equal(253);
            ((IEnumerable)Test).First<int>(2u, i => i > 1000).Should().Equal(21436);
            }

        [Fact]
        public void Test_FirstMatch()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            ((IEnumerable)Test).First(5).Should().Be(5);
            ((IEnumerable)Test).First(10).Should().Be(default(int));
            }

        [Fact]
        public void Test_Flatten()
            {
            var Test = new object[]
                {
                "a",
                1,
                null,
                new [] {5,7,3},
                null,
                new object[]
                    {5,7,0,3, null,
                    new [] {5,7,3}
                    }
                };

            ((IEnumerable)null).Flatten<object>().Should().Equal();

            Test.Flatten<object>().ToS().Should().Be(new List<object> { "a", 1, 5, 7, 3, 5, 7, 0, 3, 5, 7, 3 }.ToS());
            Test.Flatten<string>().Should().Equal("a");
            Test.Flatten<int>().Should().Equal(1, 5, 7, 3, 5, 7, 0, 3, 5, 7, 3);
            }

        [Fact]
        public void Test_GetAt()
            {
            int[] Test = { 5, 32, 46, 43, 13, 26531, 15315 };


            Test.GetAt(-1).Should().Be(0);
            Test.GetAt(0).Should().Be(5);
            Test.GetAt(1).Should().Be(32);
            Test.GetAt(100).Should().Be(0);

            Test.GetAt(0u).Should().Be(5);
            Test.GetAt(1u).Should().Be(32);
            Test.GetAt(100u).Should().Be(0);

            ((IEnumerable)Test).GetAt(-1).Should().Be(null);
            ((IEnumerable)Test).GetAt(0).Should().Be(5);
            ((IEnumerable)Test).GetAt(1).Should().Be(32);
            ((IEnumerable)Test).GetAt(100).Should().Be(null);

            ((IEnumerable)Test).GetAt(0u).Should().Be(5);
            ((IEnumerable)Test).GetAt(1u).Should().Be(32);
            ((IEnumerable)Test).GetAt(100u).Should().Be(null);

            ((Array)Test).GetAt(-1).Should().Be(null);
            ((Array)Test).GetAt(0).Should().Be(5);
            ((Array)Test).GetAt(1).Should().Be(32);
            ((Array)Test).GetAt(100).Should().Be(null);

            ((Array)Test).GetAt(0u).Should().Be(5);
            ((Array)Test).GetAt(1u).Should().Be(32);
            ((Array)Test).GetAt(100u).Should().Be(null);


            ((int[])null).GetAt(5).Should().Be(0);
            ((IEnumerable)null).GetAt(5).Should().Be(null);

            "".GetAt(0).Should().Be(default(char));
            "12345".GetAt(-1).Should().Be(default(char));
            "12345".GetAt(0).Should().Be('1');
            "12345".GetAt(1).Should().Be('2');
            "12345".GetAt(5).Should().Be(default(char));
            ((IEnumerable)"12345").GetAt(1).Should().Be('2');
            ((string)null).GetAt(0).Should().Be(default(char));

            "".GetAt(0u).Should().Be(default(char));
            "12345".GetAt(0u).Should().Be('1');
            "12345".GetAt(1u).Should().Be('2');
            "12345".GetAt(5u).Should().Be(default(char));
            ((IEnumerable)"12345").GetAt(1u).Should().Be('2');
            ((string)null).GetAt(0u).Should().Be(default(char));

            // Custom iterators work if they use ints ONLY
            new BadCollection().GetAt(0).Should().Be("0");
            new BadCollection().GetAt(1).Should().Be("1");

            // Non-indexers return null / default
            ((IEnumerable)new NotAnIndexer()).GetAt(0).Should().BeNull();
            ((IEnumerable<int>)new NotAnIndexer()).GetAt(0).Should().Be(default(int));
            }

        [Fact]
        public void Test_GetAtIndices()
            {
            int[] Test = { 5, 32, 46, 43, 13, 26531, 15315, 4364643, 445, 44, 553, 663, 223 };

            ((int[])null).GetAtIndices().Should().Equal();
            new int[] { }.GetAtIndices().Should().Equal();
            ((int[])null).GetAtIndices(5, 7, 9).Should().Equal();
            new int[] { }.GetAtIndices(5, 7, 9).Should().Equal();

            Test.GetAtIndices().Should().Equal();

            Test.GetAtIndices(5, 7, 9).Should().Equal(26531, 4364643, 44);
            Test.GetAtIndices(5, 7, 9, -1, int.MinValue, int.MaxValue).Should().Equal(26531, 4364643, 44);

            ((IEnumerable)Test).GetAtIndices<int>(5, 7, 9).Should().Equal(26531, 4364643, 44);
            ((IEnumerable)Test).GetAtIndices<object>(5, 7, 9).Should().Equal(26531, 4364643, 44);
            ((IEnumerable)Test).GetAtIndices<string>(5, 7, 9).Should().Equal();

            ((IEnumerable<int>)Test).GetAtIndices<int>(5, 7, 9).Should().Equal(26531, 4364643, 44);
            ((IEnumerable<int>)Test).GetAtIndices<object>(5, 7, 9).Should().Equal(26531, 4364643, 44);
            ((IEnumerable<int>)Test).GetAtIndices<string>(5, 7, 9).Should().Equal();
            }

        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [Fact]
        public void Test_Group()
            {
            int[] Test =
                {
                5, 32, 46, 43, 13, 26531, 15315, 35, 72, 14, 94, 2, 589, 36, 8875, 245, 235, 886, 2226, 9542,
                4364643, 445, 44, 553, 663, 223
                };

            Dictionary<string, List<int>> Result = Test.Group(i => $"{i.ToString().Sub(0, 1)}");

            Result.Keys.List().Should().Equal(
                "5", "3", "4", "1", "2", "7", "9", "8", "6"
                );
            Result.Values.List().ToS().Should().Be(new List<List<int>>
                {
                new List<int> {5, 589, 553},
                new List<int> {32, 35, 36},
                new List<int> {46, 43, 4364643, 445, 44},
                new List<int> {13, 15315, 14},
                new List<int> {26531, 2, 245, 235, 2226, 223},
                new List<int> {72},
                new List<int> {94, 9542},
                new List<int> {8875, 886},
                new List<int> {663}
                }.ToS());

            Result = Test.Group((Func<int, string>)null);

            Result.Keys.List().Should().Equal();
            Result.Values.List().ShouldBeEquivalentTo(new List<int>());

            ((int[])null).Group((Func<int, string>)null).Should().BeEmpty();
            new int[] { }.Group((Func<int, string>)null).Should().BeEmpty();


            L.A(() => Test.Group<int, int>(i => { throw new Exception(); })).ShouldFail();
            }

        [Fact]
        public void Test_Group_IGroup()
            {
            var Test2 = new[]
                {
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("ccc"),
                new TestGroup("ccc"),
                new TestGroup("ccc"),
                new TestGroup("ccc"),
                new TestGroup("ccc"),
                new TestGroup("ccc"),
                new TestGroup("ccc"),
                new TestGroup("b"),
                new TestGroup("b"),
                new TestGroup("b")
                };

            Dictionary<string, List<TestGroup>> Result2 = Test2.Group();

            Result2.Keys.Should().Equal("a", "ccc", "b");

            Result2["a"].Count.Should().Be(6);
            Result2["b"].Count.Should().Be(3);
            Result2["ccc"].Count.Should().Be(7);

            Result2["a"].Should().BeOfType<List<TestGroup>>();
            Result2["b"].Should().BeOfType<List<TestGroup>>();
            Result2["ccc"].Should().BeOfType<List<TestGroup>>();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_GroupTwice()
            {
            int[] Test =
                {
                5, 32, 46, 43, 13, 26531, 15315, 35, 72, 14, 94, 2, 589, 36, 8875, 245, 235, 886, 2226, 9542,
                4364643, 445, 44, 553, 663, 223
                };

            Dictionary<string, Dictionary<string, List<int>>> Result = Test.GroupTwice(
                i => i < 1000 ? "Small Numbers" : "Large Numbers",
                i => $"{i.ToString().Sub(0, 1)}");

            Result.Keys.List().Should().Equal("Small Numbers", "Large Numbers");


            Result["Small Numbers"].Keys.List().Should().Equal("5", "3", "4", "1", "7", "9", "2", "8", "6");
            Result["Large Numbers"].Keys.List().Should().Equal("2", "1", "8", "9", "4");

            Result["Small Numbers"].Values.Flatten<int>().Count.Should().Be(20);
            Result["Large Numbers"].Values.Flatten<int>().Count.Should().Be(6);

            ((int[])null).GroupTwice((Func<int, string>)null, (Func<int, string>)null).Should().BeEmpty();
            new int[] { }.GroupTwice((Func<int, string>)null, (Func<int, string>)null).Should().BeEmpty();

            L.A(() => Test.GroupTwice<int, int, int>(i => i, i => { throw new Exception(); })).ShouldFail();
            L.A(() => Test.GroupTwice<int, int, int>(i => { throw new Exception(); }, i => i)).ShouldFail();
            }

        [Fact]
        public void Test_Has()
            {
            var Test = new object[]
                {
                "a", 1, 2, 3, 4, 5, null
                };

            Test.Has("a").Should().BeTrue();
            Test.Has(1).Should().BeTrue();
            Test.Has(1f).Should().BeFalse();
            Test.Has((object)null).Should().BeTrue();

            ((IEnumerable)null).Has(5).Should().BeFalse();
            ((IEnumerable<int>)null).Has(5).Should().BeFalse();
            }

        [Fact]
        public void Test_HasAny()
            {
            var Test = new object[]
                {
                "a", 1, 2, 3, 4, 5, null
                };

            Test.HasAny(new List<object> { "a" }).Should().BeTrue();
            Test.HasAny(new List<object> { 1 }).Should().BeTrue();
            Test.HasAny(new List<object> { 1f }).Should().BeFalse();
            Test.HasAny(new List<object> { 1f, 2d, 3.0m }).Should().BeFalse();
            Test.HasAny(new List<object> { 1f, 2d, 3.0m, 5 }).Should().BeTrue();
            Test.HasAny(new List<object> { (object)null }).Should().BeTrue();

            ((IEnumerable)Test).HasAny(new List<object> { "a" }).Should().BeTrue();
            ((IEnumerable)Test).HasAny(new List<object> { 1 }).Should().BeTrue();
            ((IEnumerable)Test).HasAny(new List<object> { 1f }).Should().BeFalse();
            ((IEnumerable)Test).HasAny(new List<object> { 1f, 2d, 3.0m }).Should().BeFalse();
            ((IEnumerable)Test).HasAny(new List<object> { 1f, 2d, 3.0m, 5 }).Should().BeTrue();
            ((IEnumerable)Test).HasAny(new List<object> { (object)null }).Should().BeTrue();

            Test.HasAny("b", "a").Should().BeTrue();
            Test.HasAny(1).Should().BeTrue();
            Test.HasAny(1f).Should().BeFalse();
            Test.HasAny(1f, 2d, 3.0m).Should().BeFalse();
            Test.HasAny(1f, 2d, 3.0m, 5).Should().BeTrue();
            Test.HasAny((object)null).Should().BeTrue();

            ((IEnumerable)Test).HasAny("b", "a").Should().BeTrue();
            ((IEnumerable)Test).HasAny(1).Should().BeTrue();
            ((IEnumerable)Test).HasAny(1f).Should().BeFalse();
            ((IEnumerable)Test).HasAny(1f, 2d, 3.0m).Should().BeFalse();
            ((IEnumerable)Test).HasAny(1f, 2d, 3.0m, 5).Should().BeTrue();
            ((IEnumerable)Test).HasAny((object)null).Should().BeTrue();

            ((IEnumerable)null).HasAny(5).Should().BeFalse();
            ((IEnumerable<int>)null).HasAny(5).Should().BeFalse();
            }

        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [Fact]
        public void Test_Has_Func()
            {
            var Test = new object[]
                {
                "a", 1, 2, 3, 4, 5, null
                };


            Test.Has(o => o is int && (int)o == 1).Should().BeTrue();
            Test.Has(o => o is string && (string)o == "a").Should().BeTrue();
            Test.Has(o => o is string && (string)o == "b").Should().BeFalse();

            ((IEnumerable)Test).Has<object>(o => o is int && (int)o == 1).Should().BeTrue();
            ((IEnumerable)Test).Has<object>(o => o is string && (string)o == "a").Should().BeTrue();
            ((IEnumerable)Test).Has<object>(o => o is string && (string)o == "b").Should().BeFalse();

            Test.Has((Func<object, bool>)null).Should().BeFalse();
            ((IEnumerable)Test).Has((Func<object, bool>)null).Should().BeFalse();
            ((IEnumerable)null).Has((Func<object, bool>)null).Should().BeFalse();
            ((IEnumerable<int>)null).Has((Func<object, bool>)null).Should().BeFalse();


            L.A(() => Test.Has<int>(i => { throw new Exception(); })).ShouldFail();
            }

        [Fact]
        public void Test_HasIndex()
            {
            var Test = new object[]
                {
                "a", 1, 2, 3, 4, 5, null
                };


            Test.HasIndex(-1).Should().BeFalse();
            Test.HasIndex(0).Should().BeTrue();
            Test.HasIndex(1).Should().BeTrue();
            Test.HasIndex(6).Should().BeTrue();
            Test.HasIndex(7).Should().BeFalse();

            Test.HasIndex(0u).Should().BeTrue();
            Test.HasIndex(1u).Should().BeTrue();
            Test.HasIndex(6u).Should().BeTrue();
            Test.HasIndex(7u).Should().BeFalse();

            ((int[])null).HasIndex(0).Should().BeFalse();
            ((IEnumerable)null).HasIndex(0).Should().BeFalse();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Index()
            {
            var Test = new int[]
                {
                5, 322, 466, 3, 5549, 456, 1, 23, 1, 2, 77, 9, 756475, 4, 123, 655, 8996, 45, 8, 7412, 21, 5, 3, 65, 4,
                12, 54, 78, 9, 8, 56, 66, 5, 4, 88
                };

            Dictionary<string, int> Result = Test.Index(i => i.ToString().Sub(0, 2));

            Result.Keys.Should().Equal("5", "32", "46", "3", "55", "45", "1", "23", "2", "77", "9", "75", "4", "12", "65", "89", "8", "74", "21", "54", "78", "56", "66", "88");

            Result.Values.TotalCount().Should().Be(24);

            ((int[])null).Index<int>(null).Should().BeEmpty();
            ((IEnumerable)null).Index<object>(null).Should().BeEmpty();

            L.A(() => Test.Index<int>(i => { throw new Exception(); })).ShouldFail();
            }

        #region Internal

        [ExcludeFromCodeCoverage]
        internal class TestGroup : IGrouped
            {
            public TestGroup(string Group)
                {
                this.Group = Group;
                }

            public string Group { get; }
            }
        [ExcludeFromCodeCoverage]
        internal class BadCollection : ICollection
            {
            public string this[int Index]
                {
                get
                    {
                    return $"{Index}";
                    }
                // ReSharper disable once ValueParameterNotUsed
                set
                    {

                    }
                }

            // ReSharper disable once NotNullMemberIsNotInitialized
            public BadCollection() { }

            public BadCollection(object SyncRoot, bool IsSynchronized)
                {
                this.SyncRoot = SyncRoot;
                this.IsSynchronized = IsSynchronized;
                }

            public IEnumerator GetEnumerator()
                {
                return null;
                }

            public void CopyTo(Array Array, int Index) { }

            /// <exception cref="Exception" accessor="get"></exception>
            public int Count
                {
                get { throw new Exception(); }
                }

            public object SyncRoot { get; }
            public bool IsSynchronized { get; }
            }

        internal class NotAnIndexer : IEnumerable<int>
            {
            private readonly int[] _Test = { 5, 6, 7 };

            IEnumerator<int> IEnumerable<int>.GetEnumerator()
                {
                return this._Test.List().GetEnumerator();
                }

            public IEnumerator GetEnumerator()
                {
                return this._Test.GetEnumerator();
                }
            }

        #endregion
        }
    }
