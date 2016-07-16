
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
        }
    }
