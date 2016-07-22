using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Tests;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

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

            ((int[])null).Append(Test2).ShouldBeEquivalentTo(new int[] { 55, 55, 55, 55 });
            Test2.Append((int[])null).ShouldBeEquivalentTo(new int[] { 55, 55, 55, 55 });

            ((int[])null).Append(Test1).ShouldBeEquivalentTo(new int[] { 1, 5, 9, 5, 3 });
            Test1.Append((int[])null).ShouldBeEquivalentTo(new int[] { 1, 5, 9, 5, 3 });

            Test1.Append(Test2).ShouldBeEquivalentTo(new int[] { 1, 5, 9, 5, 3, 55, 55, 55, 55 });
            Test2.Append(Test1).ShouldBeEquivalentTo(new int[] { 55, 55, 55, 55, 1, 5, 9, 5, 3 });
            }


        [Fact]
        [TestCategory(UnitTests)]
        public void Test_Array()
            {
            var Test1 = new List<int> { 1, 5, 9, 5, 3 };
            var Test2 = new List<object> { 1, 5, 9, 5, 3, "s" };

            ((IEnumerable)Test1).Array().ShouldBeEquivalentTo(new object[] { 1, 5, 9, 5, 3 });
            ((IEnumerable)Test2).Array().ShouldBeEquivalentTo(new object[] { 1, 5, 9, 5, 3, "s" });

            ((IEnumerable<int>)Test1).Array().ShouldBeEquivalentTo(new int[] { 1, 5, 9, 5, 3 });
            ((IEnumerable<object>)Test2).Array().ShouldBeEquivalentTo(new object[] { 1, 5, 9, 5, 3, "s" });

            ((IEnumerable)Test1).Array<int>().ShouldBeEquivalentTo(new int[] { 1, 5, 9, 5, 3 });
            ((IEnumerable)Test2).Array<int>().ShouldBeEquivalentTo(new int[] { 1, 5, 9, 5, 3 });

            ((IEnumerable<object>)Test2).Array<object, IComparable>().ShouldBeEquivalentTo(new IComparable[] { 1, 5, 9, 5, 3, "s" });
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [TestCategory(UnitTests)]
        public void Test_CollectFunc()
            {
            int Counter = 0;
            Func<int> Func = () => ++Counter;

            Func.Collect(0).ShouldBeEquivalentTo(new int[] { });
            Func.Collect(1).ShouldBeEquivalentTo(new int[] { 1 });
            Func.Collect(5).ShouldBeEquivalentTo(new int[] { 2, 3, 4, 5, 6 });

            L.A(() => Func.Collect(-1)).ShouldFail();

            Counter = 0;

            Func<int, int> Func2 = i =>
                 {
                     Counter += i;
                     return Counter;
                 };

            Func2.Collect(0).ShouldBeEquivalentTo(new int[] { });
            Func2.Collect(1).ShouldBeEquivalentTo(new int[] { 0 });
            Func2.Collect(5).ShouldBeEquivalentTo(new int[] { 0, 1, 3, 6, 10 });

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

            ((IEnumerable)List).Convert(Converter).ShouldBeEquivalentTo(new List<object> { "123", "abc", "5.5", "a" });

            ((IEnumerable)List).Convert((Func<object, object>)null).ShouldBeEquivalentTo(new List<object> { 123, "abc", 5.5f, 'a' });

            ((IEnumerable)null).Convert(Converter).ShouldBeEquivalentTo(new List<object>());

            Func<object, string> Converter2 = o => o?.ToString();

            ((IEnumerable<object>)List).Convert(Converter2).ShouldBeEquivalentTo(new List<string> { "123", "abc", "5.5", "a" });

            ((IEnumerable<object>)List).Convert((Func<object, string>)null).ShouldBeEquivalentTo(new List<string> { "abc" });

            ((IEnumerable<object>)null).Convert(Converter2).ShouldBeEquivalentTo(new List<string>());

            ((object[])List).Convert(Converter2).ShouldBeEquivalentTo(new string[] { "123", "abc", "5.5", null, "a" });

            ((object[])List).Convert((Func<object, string>)null).ShouldBeEquivalentTo(new string[] { null, "abc", null, null, null });

            ((object[])null).Convert(Converter2).ShouldBeEquivalentTo(new string[] { });

            List.List().Convert(Converter2).ShouldBeEquivalentTo(new List<string> { "123", "abc", "5.5", "a" });

            List.List().Convert((Func<object, string>)null).ShouldBeEquivalentTo(new List<string> { "abc" });

            ((List<object>)null).List().Convert(Converter2).ShouldBeEquivalentTo(new List<string>());
            }

        [Fact]
        public void Test_ConvertAll()
            {
            var List = new object[] { 123, "abc", 5.5f, null, 'a' };

            Func<object, string[]> Converter = o => new[] { o?.ToString(), o?.ToString() };

            ((IEnumerable)List).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object> { "123", "123", "abc", "abc", "5.5", "5.5", "a", "a" });

            ((IEnumerable)null).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object>());


            ((IEnumerable<object>)List).ConvertAll<object, string>(Converter).ShouldBeEquivalentTo(
                new List<object> { "123", "123", "abc", "abc", "5.5", "5.5", null, null, "a", "a" });

            ((IEnumerable<object>)null).ConvertAll<object, string>(Converter).ShouldBeEquivalentTo(
                new List<object>());

            }

        [Fact]
        public void Test_ConvertAll_1()
            {
            var List = new object[] { 123, "abc", 5.5f, null, 'a' };

            Func<object, IEnumerable<object>> Converter = o => new object[] { o?.ToString(), o?.ToString() };

            ((IEnumerable)List).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object> { "123", "123", "abc", "abc", "5.5", "5.5", null, null, "a", "a" });

            ((IEnumerable)null).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object>());


            ((IEnumerable<object>)List).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object> { "123", "123", "abc", "abc", "5.5", "5.5", null, null, "a", "a" });

            ((IEnumerable<object>)null).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object>());


            ((object[])List).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object> { "123", "123", "abc", "abc", "5.5", "5.5", null, null, "a", "a" });

            ((object[])null).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object>());


            List.List().ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object> { "123", "123", "abc", "abc", "5.5", "5.5", null, null, "a", "a" });

            ((List<object>)null).ConvertAll(Converter).ShouldBeEquivalentTo(
                new List<object>());
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

            Test.Fill(1).ShouldBeEquivalentTo(new int[] { 1, 1, 1, 1, 1 });

            ((int[])null).Fill(1).ShouldBeEquivalentTo(new int[] { });

            new object[5].Fill(null)
                .ShouldBeEquivalentTo(new object[] { });
            }
        [Fact]
        public void Test_Fill_List()
            {
            var Test = new int[5];

            Test.List().Fill(1).ShouldBeEquivalentTo(new int[] { 1, 1, 1, 1, 1 });

            ((List<int>)null).Fill(1).ShouldBeEquivalentTo(new int[] { });

            new List<object> { 1, 2, 3, 4, 5 }.Fill(null)
                .ShouldBeEquivalentTo(new List<object>());
            }

        [Fact]
        public void Test_Filter()
            {
            object[] Test = { 0, 5, "abc", "123", 'a', 'b', null };


            ((IEnumerable)null).Filter<int>()
                .ShouldBeEquivalentTo(new List<int>());
            ((IEnumerable)Test).Filter<int>()
                .ShouldBeEquivalentTo(new List<int> { 0, 5 });
            ((IEnumerable)Test).Filter<string>()
                .ShouldBeEquivalentTo(new List<string> { "abc", "123" });
            ((IEnumerable)Test).Filter<object>()
                .ShouldBeEquivalentTo(new List<object> { 0, 5, "abc", "123", 'a', 'b' });
            ((IEnumerable)Test).Filter<char>()
                .ShouldBeEquivalentTo(new List<char> { 'a', 'b' });


            ((object[])null).Filter<int>()
                .ShouldBeEquivalentTo(new int[] { });
            Test.Filter<int>()
                .ShouldBeEquivalentTo(new int[] { 0, 5 });
            Test.Filter<string>()
                .ShouldBeEquivalentTo(new string[] { "abc", "123" });
            Test.Filter<char>()
                .ShouldBeEquivalentTo(new char[] { 'a', 'b' });
            Test.Filter<object>()
                .ShouldBeEquivalentTo(new object[] { 0, 5, "abc", "123", 'a', 'b' });


            ((List<object>)null).Filter<int>()
                .ShouldBeEquivalentTo(new int[] { });
            Test.List().Filter<object, int>()
                .ShouldBeEquivalentTo(new int[] { 0, 5 });
            Test.List().Filter<object, string>()
                .ShouldBeEquivalentTo(new string[] { "abc", "123" });
            Test.List().Filter<object, char>()
                .ShouldBeEquivalentTo(new char[] { 'a', 'b' });
            Test.List().Filter<object, object>()
                .ShouldBeEquivalentTo(new object[] { 0, 5, "abc", "123", 'a', 'b' });
            }

        [Fact]
        public void Test_First()
            {
            
            }
        #region Internal

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void TestInternal()
            {
            var Bad = new BadCollection(null, false);

            Bad.GetEnumerator();
            Bad.CopyTo(null, 0);
            var Temp = Bad.SyncRoot;
            bool Temp2 = Bad.IsSynchronized;

            L.F(() => Bad.Count).ShouldFail();
            }

        internal class BadCollection : ICollection
            {
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

        #endregion
        }
    }
