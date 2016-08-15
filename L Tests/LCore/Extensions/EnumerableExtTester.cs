using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.Interfaces;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Naming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable SuggestVarOrType_Elsewhere
// ReSharper disable RedundantDelegateCreation
// ReSharper disable MethodOverloadWithOptionalParameter
// ReSharper disable UnusedTypeParameter
// ReSharper disable UnusedParameter.Global
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local

// ReSharper disable RedundantCast
// ReSharper disable RedundantTypeArgumentsOfMethod
// ReSharper disable RedundantExplicitArrayCreation
// ReSharper disable UnusedVariable

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt))]
    public partial class EnumerableExtTester : XUnitOutputTester, IDisposable
        {
        public EnumerableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.All) + "(IEnumerable, Func`2<Object, Boolean>) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.All) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.All) + "(IEnumerable, Func`3<Int32, Object, Boolean>) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.All) + "(IEnumerable, Func`3<Int32, T, Boolean>) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.All) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => Boolean")]
        public void Test_All_0()
            {
            int[] Test = { 1, 5, 7, 3, 4, 7, 4, 7, 10 };

            ((IEnumerable)Test).All((Func<object, bool>)(o => (int)o < 15)).ShouldBeTrue();
            ((IEnumerable)Test).All((Func<object, bool>)(o => (int)o < 10)).ShouldBeFalse();

            int Count = 0;

            ((IEnumerable)Test).All((Func<int, object, bool>)((i, o) =>
              {
                  i.Should().Be(Count);
                  Count++;
                  return (int)o < 15;
              })).ShouldBeTrue();
            Count = 0;
            ((IEnumerable)Test).All((Func<int, object, bool>)((i, o) =>
              {
                  i.Should().Be(Count);
                  Count++;
                  return (int)o < 10;
              })).ShouldBeFalse();

            Test.All((i1, i2) => i2 < 11).ShouldBeTrue();
            Test.All((i1, i2) => i2 < 10).ShouldBeFalse();

            Test.All((i, i2) => i2 < 15).ShouldBeTrue();
            Test.All((i, i2) => i2 < 10).ShouldBeFalse();

            ((IEnumerable)Test).All<int>((i, o) => o < 15).ShouldBeTrue();
            ((IEnumerable)Test).All<int>((i, o) => o < 10).ShouldBeFalse();

            ((IEnumerable<int>)Test).All<int>((i, o) => o < 15).ShouldBeTrue();
            ((IEnumerable<int>)Test).All<int>((i, o) => o < 10).ShouldBeFalse();

            ((IEnumerable<int>)Test).All<int>(o => o < 15).ShouldBeTrue();
            ((IEnumerable<int>)Test).All<int>(o => o < 10).ShouldBeFalse();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Append) + "(T[], T[]) => T[]")]
        public void Test_Append()
            {
            int[] Test1 = { 1, 5, 9, 5, 3 };
            int[] Test2 = { 55, 55, 55, 55 };


            Test1.Append(Test2).Should().Equal(1, 5, 9, 5, 3, 55, 55, 55, 55);
            Test2.Append(Test1).Should().Equal(55, 55, 55, 55, 1, 5, 9, 5, 3);
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Array) + "(IEnumerable) => Object[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Array) + "(IEnumerable) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Array) + "(IEnumerable`1<T>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Array) + "(IEnumerable`1<T>) => U[]")]
        public void Test_Array()
            {
            // ReSharper disable ArgumentsStyleLiteral
            List<int> Test1 = new List<int> { 1, 5, 9, 5, 3 };
            List<object> Test2 = new List<object> { 1, 5, 9, 5, 3, "s" };
            // ReSharper restore ArgumentsStyleLiteral

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
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Collect) + "(Func`1<T>, Int32) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Collect) + "(Func`2<Int32, T>, Int32) => List`1<T>")]
        public void Test_CollectFunc()
            {
            int Counter = 0;
            Func<int> Func = () => ++Counter;

            Func.Collect(Count: 0).Should().Equal();
            Func.Collect(Count: 1).Should().Equal(1);
            Func.Collect(Count: 5).Should().Equal(2, 3, 4, 5, 6);

            L.A(() => Func.Collect(-1)).ShouldFail();

            Counter = 0;

            Func<int, int> Func2 = i =>
                {
                    Counter += i;
                    return Counter;
                };

            Func2.Collect(Count: 0).Should().Equal();
            Func2.Collect(Count: 1).Should().Equal(0);
            Func2.Collect(Count: 5).Should().Equal(0, 1, 3, 6, 10);

            L.A(() => Func2.Collect(-1)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.CollectStr) + "(String, Func`2<Char, Char>) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.CollectStr) + "(List`1<T>, Func`3<Int32, T, String>) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.CollectStr) + "(T[], Func`3<Int32, T, String>) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.CollectStr) + "(U, Func`3<Int32, T, String>) => String")]
        public void Test_CollectStr()
            {
            Func<char, char> Modifier = Char => (char)(Char + 1);
            Func<int, int, string> Modifier2 = (i, o) => $"{o}-";


            "abc".CollectStr(Modifier).Should().Be("bcd");


            new[] { 5, 1, 77, 2, 7, 3 }.CollectStr(Modifier2).Should().Be("5-1-77-2-7-3-");
            new[] { 5, 1, 77, 2, 7, 3 }.CollectStr(Func: null).Should().Be("5177273");

            new[] { 5, 1, 77, 2, 7, 3 }.List().CollectStr(Modifier2).Should().Be("5-1-77-2-7-3-");
            new[] { 5, 1, 77, 2, 7, 3 }.List().CollectStr(Func: null).Should().Be("5177273");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Combine) + "(IEnumerable`1<String>) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Combine) + "(IEnumerable`1<String>, Char) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Combine) + "(IEnumerable`1<T>, String) => String")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Combine) + "(IEnumerable`1<T>, Char) => String")]
        public void Test_CombineString()
            {
            IConvertible[] List = { 123, "abc", 5.5f, null, 'a' };

            List.Combine("--").Should().Be("123--abc--5.5--a");
            List.Combine(SeparateChar: ',').Should().Be("123,abc,5.5,a");

            List.Combine(SeparateStr: null).Should().Be("123abc5.5a");
            List.Combine("").Should().Be("123abc5.5a");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(List`1<T>, Func`2<T, U>) => List`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(IEnumerable, Func`2<Object, Object>) => List`1<Object>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(T[], Func`2<T, U>) => U[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(IEnumerable`1<T>, Func`2<T, U>) => List`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(IEnumerable, Func`3<Int32, Object, Object>) => List`1<Object>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(T[], Func`3<Int32, T, U>) => U[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(List`1<T>, Func`3<Int32, T, U>) => List`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Convert) + "(IEnumerable`1<T>, Func`3<Int32, T, U>) => List`1<U>")]
        public void Test_Convert()
            {
            object[] List = { 123, "abc", 5.5f, null, 'a' };

            Func<object, object> Converter = o => o?.ToString();

            ((IEnumerable)List).Convert(Converter).Should().Equal("123", "abc", "5.5", "a");

            ((IEnumerable)List).Convert((Func<object, object>)null).Should().Equal(123, "abc", 5.5f, 'a');

            Func<object, string> Converter2 = o => o?.ToString();

            ((IEnumerable<object>)List).Convert(Converter2).Should().Equal("123", "abc", "5.5", "a");

            ((IEnumerable<object>)List).Convert((Func<object, string>)null).Should().Equal("abc");

            ((object[])List).Convert(Converter2).Should().Equal("123", "abc", "5.5", null, "a");

            ((object[])List).Convert((Func<object, string>)null).Should().Equal(null, "abc", null, null, null);

            List.List().Convert(Converter2).Should().Equal("123", "abc", "5.5", "a");

            List.List().Convert((Func<object, string>)null).Should().Equal("abc");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.ConvertAll) + "(IEnumerable, Func`2<Object, IEnumerable`1<Object>>) => List`1<Object>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.ConvertAll) + "(IEnumerable, Func`2<T, IEnumerable`1<U>>) => List`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.ConvertAll) + "(IEnumerable`1<T>, Func`2<T, IEnumerable`1<U>>) => List`1<U>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.ConvertAll) + "(T[], Func`2<T, IEnumerable`1<U>>) => U[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.ConvertAll) + "(List`1<T>, Func`2<T, IEnumerable`1<U>>) => List`1<U>")]
        public void Test_ConvertAll()
            {
            object[] List = { 123, "abc", 5.5f, null, 'a' };

            Func<object, string[]> Converter = o => new[] { o?.ToString(), o?.ToString() };

            ((IEnumerable)List).ConvertAll(Converter).Should().Equal(
                new List<string> { "123", "123", "abc", "abc", "5.5", "5.5", "a", "a" });

            ((IEnumerable<object>)List).ConvertAll<object, string>(Converter).Should().Equal(
                new List<string> { "123", "123", "abc", "abc", "5.5", "5.5", "a", "a" });
            }

        [Fact]
        public void Test_ConvertAll_1()
            {
            object[] List = { 123, "abc", 5.5f, null, 'a' };

            Func<object, IEnumerable<object>> Converter = o => new object[] { o?.ToString(), o?.ToString() };

            ((IEnumerable)List).ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");

            ((IEnumerable)null).ConvertAll(Converter).Should().Equal();


            ((IEnumerable<object>)List).ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");


            ((object[])List).ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");


            List.List().ConvertAll(Converter).Should().Equal("123", "123", "abc", "abc", "5.5", "5.5", "a", "a");
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Count) + "(T) => UInt32")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Count) + "(IEnumerable`1<T>, T) => UInt32")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Count) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => UInt32")]
        public void Test_Count_T()
            {
            "55555".Count().Should().Be(expected: 5);

            new object[] { 1, 2, 3, 4, 5 }.Count().Should().Be(expected: 5);

            // ReSharper disable ArgumentsStyleLiteral
            new List<object> { 1, 2, 3, 4, 5 }.Count().Should().Be(expected: 5);
            // ReSharper restore ArgumentsStyleLiteral

            var Bad = new BadCollection(SyncRoot: null, IsSynchronized: false);

            Bad.Count().Should().Be(expected: 0);
            }

        [Fact]
        public void Test_Count_Object()
            {
            string[] Test = { "a", "a", "a", "a", "b" };

            Test.Count((string)null).Should().Be(expected: 0);
            Test.Count("a").Should().Be(expected: 4);
            Test.Count("b").Should().Be(expected: 1);
            Test.Count("c").Should().Be(expected: 0);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Cycle) + "(IEnumerable, Func`2<Object, Boolean>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Cycle) + "(IEnumerable`1<T>, Func`2<T, Boolean>)")]
        public void Test_Cycle()
            {
            string[] Test = { "a", "a", "a", "a", null, "a" };

            int Count = 0;

            // Test IEnumerable
            ((IEnumerable)Test).Cycle(Str =>
               {
                   Count++;
                   return Str != null;
               });

            Count.Should().Be(expected: 5);

            // Test IEnumerable<T>
            Count = 0;

            Test.Cycle(Str =>
                {
                    Count++;
                    return Str != null;
                });

            Count.Should().Be(expected: 5);

            // Test multiple cycles
            Count = 0;

            ((IEnumerable)Test).Cycle(Str =>
               {
                   Count++;
                   return Count < 7 || Str != null;
               });

            Count.Should().Be(expected: 11);

            // Test multiple cycles
            Count = 0;

            Test.Cycle(Str =>
                {
                    Count++;
                    return Count < 7 || Str != null;
                });

            Count.Should().Be(expected: 11);

            // Exceptions are not hidden.
            L.A(() => Test.Cycle(Str => { throw new Exception(); })).ShouldFail();
            }

        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Each) + "(IEnumerable, Action`1<T>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Each) + "(IEnumerable, Action`1<Object>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Each) + "(IEnumerable`1<T>, Action`1<T>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Each) + "(IEnumerable, Action`2<Int32, Object>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Each) + "(IEnumerable`1<T>, Action`2<Int32, T>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Each) + "(Action`1<T>, IEnumerable`1<T>)")]
        public void Test_EachObject()
            {
            string[] Test = { "a", "b", "c" };
            string Result = "";

            L.A<string>(Str => { Result += Str; }).Each(Test);

            Result.Should().Be("abc");

            ((Action<string>)null).Each(Test);

            Action<string> Action = Str => { Result += Str; };

            L.A<string>(Action).Each(Obj: null);

            Result.Should().Be("abc");

            L.A<string>(Action).Each(Test);

            Result.Should().Be("abcabc");

            // Exceptions are not hidden.
            L.A(() =>
                L.A<string>(Str => { throw new Exception(); }).Each(Test))
                .ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Equivalent) + "(IEnumerable, IEnumerable) => Boolean")]
        public void Test_Equivalent()
            {
            int[] Test1 = { 5, 8, 3, 7, 84, 356, 1 };
            int[] Test2 = Test1.Array();
            int[] Test3 = { 5, 8, 3, 7, 84, 356, 2 };

            Test1.Equivalent(Test2).ShouldBeTrue();
            Test1.Equivalent(Test3).ShouldBeFalse();

            ((int[])null).Equivalent(Test2).ShouldBeFalse();
            Test1.Equivalent((int[])null).ShouldBeFalse();
            ((int[])null).Equivalent((int[])null).ShouldBeTrue();


            "abc".Equivalent("abc").ShouldBeTrue();
            "abc".Equivalent("abcd").ShouldBeFalse();
            ((string)null).Equivalent("abcd").ShouldBeFalse();
            "abc".Equivalent((string)null).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Fill) + "(T[], T) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Fill) + "(T[], Func`2<T, T>) => T[]")]
        public void Test_Fill()
            {
            int[] Test = new int[5];

            Test.Fill(Obj: 1).Should().Equal(1, 1, 1, 1, 1);

            ((int[])null).Fill(Obj: 1).Should().Equal();

            new object[5].Fill(Filler: null)
                .Should().Equal();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Fill) + "(List`1<T>, T) => List`1<T>")]
        public void Test_Fill_List()
            {
            int[] Test = new int[5];

            Test.List().Fill(Obj: 1).Should().Equal(1, 1, 1, 1, 1);

            ((List<int>)null).Fill(Obj: 1).Should().Equal();

            // ReSharper disable ArgumentsStyleLiteral
            new List<object> { 1, 2, 3, 4, 5 }.Fill(Obj: null)
                .Should().Equal();
            // ReSharper restore ArgumentsStyleLiteral
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Filter) + "(IEnumerable, Boolean) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Filter) + "(T[], Boolean) => U[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Filter) + "(List`1<T>, Boolean) => List`1<U>")]
        public void Test_Filter()
            {
            object[] Test = { 0, 5, "abc", "123", 'a', 'b', null };


            ((IEnumerable)Test).Filter<int>()
                .Should().Equal(0, 5);
            ((IEnumerable)Test).Filter<string>()
                .Should().Equal("abc", "123");
            ((IEnumerable)Test).Filter<object>()
                .Should().Equal(0, 5, "abc", "123", 'a', 'b');
            ((IEnumerable)Test).Filter<char>()
                .Should().Equal('a', 'b');


            Test.Filter<int>()
                .Should().Equal(0, 5);
            Test.Filter<string>()
                .Should().Equal("abc", "123");
            Test.Filter<char>()
                .Should().Equal('a', 'b');
            Test.Filter<object>()
                .Should().Equal(0, 5, "abc", "123", 'a', 'b');


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
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable`1<T>, Int32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable`1<T>, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(T[], Int32, Func`2<T, Boolean>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(T[], UInt32, Func`2<T, Boolean>) => T[]")]
        public void Test_First()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            Test.First().Should().Be(expected: 5);
            Test.First(Condition: null).Should().Be(expected: 5);
            Test.First(i => false).Should().Be(default(int));
            Test.First(i => true).Should().Be(expected: 5);
            Test.First(i => i > 100).Should().Be(expected: 21436);
            Test.First(i => i > 100 && i < 1000).Should().Be(expected: 253);
            Test.First(i => i > 1000).Should().Be(expected: 21436);

            Test.List().First().Should().Be(expected: 5);
            Test.List().First(Condition: null).Should().Be(expected: 5);
            Test.List().First(i => false).Should().Be(default(int));
            Test.List().First(i => true).Should().Be(expected: 5);
            Test.List().First(i => i > 100).Should().Be(expected: 21436);
            Test.List().First(i => i > 100 && i < 1000).Should().Be(expected: 253);
            Test.List().First(i => i > 1000).Should().Be(expected: 21436);

            ((IEnumerable)Test).First<int>().Should().Be(expected: 5);
            ((IEnumerable)Test).First<int?>().Should().Be(expected: 5);
            ((IEnumerable)Test).First<int>(Condition: null).Should().Be(expected: 5);
            ((IEnumerable)Test).First<int>(i => false).Should().Be(default(int));
            ((IEnumerable)Test).First<int?>((Func<int?, bool>)null).Should().Be(expected: 5);
            ((IEnumerable)Test).First<int?>(i => false).Should().Be((int?)null);
            ((IEnumerable)Test).First<int>(i => true).Should().Be(expected: 5);
            ((IEnumerable)Test).First<int>(i => i > 100).Should().Be(expected: 21436);
            ((IEnumerable)Test).First<int>(i => i > 100 && i < 1000).Should().Be(expected: 253);
            ((IEnumerable)Test).First<int>(i => i > 1000).Should().Be(expected: 21436);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable, Func`2<T, Boolean>) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(T[], Func`2<Object, Boolean>) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable, Int32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        public void Test_FirstMulti()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            Func<int, bool> True = i => true;
            Func<int, bool> False = i => false;

            Test.First(Count: 2).Should().Equal(5, 21436);
            Test.First(-5, True).Should().Equal();
            Test.First(Count: 0, Condition: True).Should().Equal();
            Test.First(Count: 2, Condition: False).Should().Equal();
            Test.First(Count: 2, Condition: True).Should().Equal(5, 21436);
            Test.First(Count: 5, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.First(Count: 2, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.First(Count: 2, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.First(Count: 2, Condition: i => i > 1000).Should().Equal(21436);

            Test.First(Count: 2u).Should().Equal(5, 21436);
            Test.First(Count: 0u, Condition: True).Should().Equal();
            Test.First(Count: 2u, Condition: False).Should().Equal();
            Test.First(Count: 2u, Condition: True).Should().Equal(5, 21436);
            Test.First(Count: 5u, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.First(Count: 2u, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.First(Count: 2u, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.First(Count: 2u, Condition: i => i > 1000).Should().Equal(21436);

            Test.List().First(Count: 2).Should().Equal(5, 21436);
            Test.List().First(-5, True).Should().Equal();
            Test.List().First(Count: 0, Condition: True).Should().Equal();
            Test.List().First(Count: 2, Condition: False).Should().Equal();
            Test.List().First(Count: 2, Condition: True).Should().Equal(5, 21436);
            Test.List().First(Count: 5, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.List().First(Count: 2, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.List().First(Count: 2, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.List().First(Count: 2, Condition: i => i > 1000).Should().Equal(21436);

            Test.List().First(Count: 2u).Should().Equal(5, 21436);
            Test.List().First(Count: 0u, Condition: True).Should().Equal();
            Test.List().First(Count: 2u, Condition: False).Should().Equal();
            Test.List().First(Count: 2u, Condition: True).Should().Equal(5, 21436);
            Test.List().First(Count: 5u, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.List().First(Count: 2u, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.List().First(Count: 2u, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.List().First(Count: 2u, Condition: i => i > 1000).Should().Equal(21436);

            ((IEnumerable)Test).First<int>(Count: 2, Condition: null).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(-5, True).Should().Equal();
            ((IEnumerable)Test).First<int>(Count: 0, Condition: True).Should().Equal();
            ((IEnumerable)Test).First<int>(Count: 2, Condition: False).Should().Equal();
            ((IEnumerable)Test).First<int>(Count: 2, Condition: True).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(Count: 5, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            ((IEnumerable)Test).First<int>(Count: 2, Condition: i => i > 100).Should().Equal(21436, 253);
            ((IEnumerable)Test).First<int>(Count: 2, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            ((IEnumerable)Test).First<int>(Count: 2, Condition: i => i > 1000).Should().Equal(21436);

            ((IEnumerable)Test).First<int>(Count: 2u, Condition: null).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(Count: 0u, Condition: True).Should().Equal();
            ((IEnumerable)Test).First<int>(Count: 2u, Condition: False).Should().Equal();
            ((IEnumerable)Test).First<int>(Count: 2u, Condition: True).Should().Equal(5, 21436);
            ((IEnumerable)Test).First<int>(Count: 5u, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            ((IEnumerable)Test).First<int>(Count: 2u, Condition: i => i > 100).Should().Equal(21436, 253);
            ((IEnumerable)Test).First<int>(Count: 2u, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            ((IEnumerable)Test).First<int>(Count: 2u, Condition: i => i > 1000).Should().Equal(21436);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.First) + "(IEnumerable, T) => T")]
        public void Test_FirstMatch()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            ((IEnumerable)Test).First(Object: 5).Should().Be(expected: 5);
            ((IEnumerable)Test).First(Object: 10).Should().Be(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Flatten) + "(IEnumerable) => List`1<T>")]
        public void Test_Flatten()
            {
            object[] Test =
                {
                "a",
                1,
                null,
                new[] {5, 7, 3},
                null,
                new object[]
                    {
                    5, 7, 0, 3, null,
                    new[] {5, 7, 3}
                    }
                };

            // ReSharper disable ArgumentsStyleLiteral
            Test.Flatten<object>().ToS().Should().Be(new List<object> { "a", 1, 5, 7, 3, 5, 7, 0, 3, 5, 7, 3 }.ToS());
            // ReSharper restore ArgumentsStyleLiteral
            Test.Flatten<string>().Should().Equal("a");
            Test.Flatten<int>().Should().Equal(1, 5, 7, 3, 5, 7, 0, 3, 5, 7, 3);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAt) + "(IEnumerable, Int32) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAt) + "(IEnumerable, UInt32) => Object")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAt) + "(IEnumerable`1<T>, Int32) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAt) + "(IEnumerable`1<T>, UInt32) => T")]
        public void Test_GetAt()
            {
            int[] Test = { 5, 32, 46, 43, 13, 26531, 15315 };


            Test.GetAt(-1).Should().Be(expected: 0);
            Test.GetAt(Index: 0).Should().Be(expected: 5);
            Test.GetAt(Index: 1).Should().Be(expected: 32);
            Test.GetAt(Index: 100).Should().Be(expected: 0);

            Test.GetAt(Index: 0u).Should().Be(expected: 5);
            Test.GetAt(Index: 1u).Should().Be(expected: 32);
            Test.GetAt(Index: 100u).Should().Be(expected: 0);

            ((IEnumerable)Test).GetAt(-1).Should().Be(expected: null);
            ((IEnumerable)Test).GetAt(Index: 0).Should().Be(expected: 5);
            ((IEnumerable)Test).GetAt(Index: 1).Should().Be(expected: 32);
            ((IEnumerable)Test).GetAt(Index: 100).Should().Be(expected: null);

            ((IEnumerable)Test).GetAt(Index: 0u).Should().Be(expected: 5);
            ((IEnumerable)Test).GetAt(Index: 1u).Should().Be(expected: 32);
            ((IEnumerable)Test).GetAt(Index: 100u).Should().Be(expected: null);

            ((Array)Test).GetAt(-1).Should().Be(expected: null);
            ((Array)Test).GetAt(Index: 0).Should().Be(expected: 5);
            ((Array)Test).GetAt(Index: 1).Should().Be(expected: 32);
            ((Array)Test).GetAt(Index: 100).Should().Be(expected: null);

            ((Array)Test).GetAt(Index: 0u).Should().Be(expected: 5);
            ((Array)Test).GetAt(Index: 1u).Should().Be(expected: 32);
            ((Array)Test).GetAt(Index: 100u).Should().Be(expected: null);

            "".GetAt(Index: 0).Should().Be(default(char));
            "12345".GetAt(-1).Should().Be(default(char));
            "12345".GetAt(Index: 0).Should().Be(expected: '1');
            "12345".GetAt(Index: 1).Should().Be(expected: '2');
            "12345".GetAt(Index: 5).Should().Be(default(char));
            ((IEnumerable)"12345").GetAt(Index: 1).Should().Be(expected: '2');
            ((string)null).GetAt(Index: 0).Should().Be(default(char));

            "".GetAt(Index: 0u).Should().Be(default(char));
            "12345".GetAt(Index: 0u).Should().Be(expected: '1');
            "12345".GetAt(Index: 1u).Should().Be(expected: '2');
            "12345".GetAt(Index: 5u).Should().Be(default(char));
            ((IEnumerable)"12345").GetAt(Index: 1u).Should().Be(expected: '2');
            ((string)null).GetAt(Index: 0u).Should().Be(default(char));

            // Custom iterators work if they use ints ONLY
            new BadCollection().GetAt(Index: 0).Should().Be("0");
            new BadCollection().GetAt(Index: 1).Should().Be("1");

            // Non-indexers return null / default
            ((IEnumerable)new NotAnIndexer()).GetAt(Index: 0).Should().BeNull();
            ((IEnumerable<int>)new NotAnIndexer()).GetAt(Index: 0).Should().Be(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAtIndices) + "(T[], Int32[]) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAtIndices) + "(IEnumerable, Int32[]) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GetAtIndices) + "(IEnumerable`1<T>, Int32[]) => List`1<T>")]
        public void Test_GetAtIndices()
            {
            int[] Test = { 5, 32, 46, 43, 13, 26531, 15315, 4364643, 445, 44, 553, 663, 223 };

            new int[] { }.GetAtIndices().Should().Equal();
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
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Group) + "(IEnumerable`1<T>) => Dictionary`2<String, List`1<T>>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Group) +
            "(IEnumerable`1<TValue>, Func`2<TValue, TKey>) => Dictionary`2<TKey, List`1<TValue>>")]
        public void Test_Group()
            {
            int[] Test =
                {
                5, 32, 46, 43, 13, 26531, 15315, 35, 72, 14, 94, 2, 589, 36, 8875, 245, 235, 886, 2226, 9542,
                4364643, 445, 44, 553, 663, 223
                };

            Dictionary<string, List<int>> Result = Test.Group(i => $"{i.ToString().Sub(Start: 0, Length: 1)}");

            Result.Keys.List().Should().Equal(
                "5", "3", "4", "1", "2", "7", "9", "8", "6"
                );
            Result.Values.List().ToS().Should().Be(new List<List<int>>
                {
                // ReSharper disable ArgumentsStyleLiteral
                new List<int> {5, 589, 553},
                new List<int> {32, 35, 36},
                new List<int> {46, 43, 4364643, 445, 44},
                new List<int> {13, 15315, 14},
                new List<int> {26531, 2, 245, 235, 2226, 223},
                new List<int> {72},
                new List<int> {94, 9542},
                new List<int> {8875, 886},
                new List<int> {663}
                // ReSharper restore ArgumentsStyleLiteral
                }.ToS());

            Result = Test.Group((Func<int, string>)null);

            Result.Keys.List().Should().Equal();
            Result.Values.List().ShouldBeEquivalentTo(new List<int>());


            L.A(() => Test.Group<int, int>(i => { throw new Exception(); })).ShouldFail();
            }

        [Fact]
        public void Test_Group_IGroup()
            {
            TestGroup[] Test2 =
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

            Result2["a"].Count.Should().Be(expected: 6);
            Result2["b"].Count.Should().Be(expected: 3);
            Result2["ccc"].Count.Should().Be(expected: 7);

            Result2["a"].Should().BeOfType<List<TestGroup>>();
            Result2["b"].Should().BeOfType<List<TestGroup>>();
            Result2["ccc"].Should().BeOfType<List<TestGroup>>();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.GroupTwice) +
            "(IEnumerable`1<T>, Func`2<T, U>, Func`2<T, V>) => Dictionary`2<U, Dictionary`2<V, List`1<T>>>")]
        public void Test_GroupTwice()
            {
            int[] Test =
                {
                5, 32, 46, 43, 13, 26531, 15315, 35, 72, 14, 94, 2, 589, 36, 8875, 245, 235, 886, 2226, 9542,
                4364643, 445, 44, 553, 663, 223
                };

            Dictionary<string, Dictionary<string, List<int>>> Result = Test.GroupTwice(
                i => i < 1000
                    ? "Small Numbers"
                    : "Large Numbers",
                i => $"{i.ToString().Sub(Start: 0, Length: 1)}");

            Result.Keys.List().Should().Equal("Small Numbers", "Large Numbers");


            Result["Small Numbers"].Keys.List().Should().Equal("5", "3", "4", "1", "7", "9", "2", "8", "6");
            Result["Large Numbers"].Keys.List().Should().Equal("2", "1", "8", "9", "4");

            Result["Small Numbers"].Values.Flatten<int>().Count.Should().Be(expected: 20);
            Result["Large Numbers"].Values.Flatten<int>().Count.Should().Be(expected: 6);

            L.A(() => Test.GroupTwice<int, int, int>(i => i, i => { throw new Exception(); })).ShouldFail();
            L.A(() => Test.GroupTwice<int, int, int>(i => { throw new Exception(); }, Grouper2: null)).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Has) + "(IEnumerable, T) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Has) + "(IEnumerable, Int32, T) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Has) + "(IEnumerable, UInt32, T) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Has) + "(IEnumerable, Func`2<T, Boolean>) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Has) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Boolean")]
        public void Test_Has()
            {
            object[] Test =
                {
                "a", 1, 2, 3, 4, 5, null
                };

            Test.Has("a").ShouldBeTrue();
            Test.Has(Obj: 1).ShouldBeTrue();
            Test.Has(Obj: 1f).ShouldBeFalse();
            Test.Has((object)null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.HasAny) + "(IEnumerable, IEnumerable) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.HasAny) + "(IEnumerable`1<T>, IEnumerable`1<T>) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.HasAny) + "(IEnumerable, Object[]) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.HasAny) + "(IEnumerable`1<T>, T[]) => Boolean")]
        public void Test_HasAny()
            {
            object[] Test =
                {
                "a", 1, 2, 3, 4, 5, null
                };

            Test.HasAny(new List<object> { "a" }).ShouldBeTrue();
            // ReSharper disable ArgumentsStyleLiteral
            Test.HasAny(new List<object> { 1 }).ShouldBeTrue();
            Test.HasAny(new List<object> { 1f }).ShouldBeFalse();
            Test.HasAny(new List<object> { 1f, 2d, 3.0m }).ShouldBeFalse();
            Test.HasAny(new List<object> { 1f, 2d, 3.0m, 5 }).ShouldBeTrue();
            // ReSharper restore ArgumentsStyleLiteral
            Test.HasAny(new List<object> { (object)null }).ShouldBeTrue();

            ((IEnumerable)Test).HasAny(new List<object> { "a" }).ShouldBeTrue();
            // ReSharper disable ArgumentsStyleLiteral
            ((IEnumerable)Test).HasAny(new List<object> { 1 }).ShouldBeTrue();
            ((IEnumerable)Test).HasAny(new List<object> { 1f }).ShouldBeFalse();
            ((IEnumerable)Test).HasAny(new List<object> { 1f, 2d, 3.0m }).ShouldBeFalse();
            ((IEnumerable)Test).HasAny(new List<object> { 1f, 2d, 3.0m, 5 }).ShouldBeTrue();
            // ReSharper restore ArgumentsStyleLiteral
            ((IEnumerable)Test).HasAny(new List<object> { (object)null }).ShouldBeTrue();

            Test.HasAny("b", "a").ShouldBeTrue();
            Test.HasAny(1).ShouldBeTrue();
            Test.HasAny(1f).ShouldBeFalse();
            Test.HasAny(1f, 2d, 3.0m).ShouldBeFalse();
            Test.HasAny(1f, 2d, 3.0m, 5).ShouldBeTrue();
            Test.HasAny((object)null).ShouldBeTrue();

            ((IEnumerable)Test).HasAny("b", "a").ShouldBeTrue();
            ((IEnumerable)Test).HasAny(1).ShouldBeTrue();
            ((IEnumerable)Test).HasAny(1f).ShouldBeFalse();
            ((IEnumerable)Test).HasAny(1f, 2d, 3.0m).ShouldBeFalse();
            ((IEnumerable)Test).HasAny(1f, 2d, 3.0m, 5).ShouldBeTrue();
            ((IEnumerable)Test).HasAny((object)null).ShouldBeTrue();

            ((IEnumerable)null).HasAny(5).ShouldBeFalse();
            ((IEnumerable<int>)null).HasAny(5).ShouldBeFalse();
            }

        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [Fact]
        public void Test_Has_Func()
            {
            object[] Test =
                {
                "a", 1, 2, 3, 4, 5, null
                };


            Test.Has(o => o is int && (int)o == 1).ShouldBeTrue();
            Test.Has(o => o is string && (string)o == "a").ShouldBeTrue();
            Test.Has(o => o is string && (string)o == "b").ShouldBeFalse();

            ((IEnumerable)Test).Has<object>(o => o is int && (int)o == 1).ShouldBeTrue();
            ((IEnumerable)Test).Has<object>(o => o is string && (string)o == "a").ShouldBeTrue();
            ((IEnumerable)Test).Has<object>(o => o is string && (string)o == "b").ShouldBeFalse();

            Test.Has((Func<object, bool>)null).ShouldBeFalse();
            ((IEnumerable)Test).Has((Func<object, bool>)null).ShouldBeFalse();
            ((IEnumerable)null).Has((Func<object, bool>)null).ShouldBeFalse();
            ((IEnumerable<int>)null).Has((Func<object, bool>)null).ShouldBeFalse();


            L.A(() => Test.Has<string>(s => { throw new Exception(); })).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.HasIndex) + "(IEnumerable, Int32) => Boolean")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.HasIndex) + "(IEnumerable, UInt32) => Boolean")]
        public void Test_HasIndex()
            {
            object[] Test =
                {
                "a", 1, 2, 3, 4, 5, null
                };


            Test.HasIndex(-1).ShouldBeFalse();
            Test.HasIndex(Index: 0).ShouldBeTrue();
            Test.HasIndex(Index: 1).ShouldBeTrue();
            Test.HasIndex(Index: 6).ShouldBeTrue();
            Test.HasIndex(Index: 7).ShouldBeFalse();

            Test.HasIndex(Index: 0u).ShouldBeTrue();
            Test.HasIndex(Index: 1u).ShouldBeTrue();
            Test.HasIndex(Index: 6u).ShouldBeTrue();
            Test.HasIndex(Index: 7u).ShouldBeFalse();

            ((int[])null).HasIndex(Index: 0).ShouldBeFalse();
            ((IEnumerable)null).HasIndex(Index: 0).ShouldBeFalse();
            }


        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Index) + "(IEnumerable, Func`2<Object, U>) => Dictionary`2<U, Object>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Index) + "(IEnumerable`1<T>, Func`2<T, U>) => Dictionary`2<U, T>")]
        public void Test_Index()
            {
            object[] Test =
                {
                5, 322, 466, 3, 5549, 456, 1, 23, 1, 2, 77, 9, 756475, 4, 123, 655, 8996, 45, 8, 7412, 21, 5, 3, 65, 4,
                12, 54, 78, 9, 8, 56, 66, 5, 4, null, 88
                };

            Dictionary<string, int> Result = Test.List<int>().Index(i => i.ToString().Sub(Start: 0, Length: 2));

            Result.Keys.Should()
                .Equal("5", "32", "46", "3", "55", "45", "1", "23", "2", "77", "9", "75", "4", "12", "65", "89", "8", "74", "21", "54", "78",
                    "56", "66", "88");

            Result.Values.TotalCount().Should().Be(expected: 24);

            Dictionary<string, object> Result2 = Test.Index(i => i?.ToString().Sub(Start: 0, Length: 2));

            Result.Keys.Should()
                .Equal("5", "32", "46", "3", "55", "45", "1", "23", "2", "77", "9", "75", "4", "12", "65", "89", "8", "74", "21", "54", "78",
                    "56", "66", "88");

            Result.Values.TotalCount().Should().Be(expected: 24);


            L.A(() => Test.Index<int>(i => { throw new Exception(); })).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.IndexTwice) +
            "(IEnumerable`1<T>, Func`2<T, U>, Func`2<T, V>) => Dictionary`2<U, Dictionary`2<V, T>>")]
        public void Test_IndexTwice()
            {
            int[] Test =
                {
                5, 322, 466, 3, 5549, 456, 1, 23, 1, 2, 77, 9, 756475, 4, 123, 655, 8996, 45, 8, 7412, 21, 5, 3, 65, 4,
                12, 54, 78, 9, 8, 56, 66, 5, 4, 88
                };

            Dictionary<string, Dictionary<string, int>> Result = Test.IndexTwice(
                i => i.ToString().Sub(Start: 0, Length: 2),
                i => i.ToString().Sub(Start: 2, Length: 2));

            Result.Keys.Should()
                .Equal("5", "32", "46", "3", "55", "45", "1", "23", "2", "77", "9", "75", "4", "12", "65", "89", "8", "74", "21", "54", "78",
                    "56", "66", "88");

            Result.Values.TotalCount().Should().Be(expected: 27);

            Result = ((IEnumerable<int>)Test).IndexTwice<int, string, string>(
                i => i.ToString().Sub(Start: 0, Length: 2),
                i => i.ToString().Sub(Start: 2, Length: 2));

            Result.Keys.Should()
                .Equal("5", "32", "46", "3", "55", "45", "1", "23", "2", "77", "9", "75", "4", "12", "65", "89", "8", "74", "21", "54", "78",
                    "56", "66", "88");

            Result.Values.TotalCount().Should().Be(expected: 27);

            L.A(() => Test.Index<int>(i => { throw new Exception(); })).ShouldFail();
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.IndexOf) + "(IEnumerable, Func`2<T, Boolean>) => Nullable`1<Int32>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.IndexOf) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Nullable`1<Int32>")]
        public void Test_IndexOf()
            {
            int[] Test =
                {
                5, 322, 466, 3, 5549, 456, 1, 23, 1, 2, 77, 9, 756475, 4, 123, 655, 8996, 45, 8, 7412, 21, 5, 3, 65, 4,
                12, 54, 78, 9, 8, 56, 66, 5, 4, 88
                };

            Test.IndexOf(i => i == 23).Should().Be(expected: 7);
            Test.IndexOf(i => i == 88).Should().Be(expected: 34);
            Test.IndexOf(i => i == 88888).Should().Be(expected: null);

            ((IEnumerable)Test).IndexOf<int>(i => i == 23).Should().Be(expected: 7);
            ((IEnumerable)Test).IndexOf<int>(i => i == 88).Should().Be(expected: 34);
            ((IEnumerable)Test).IndexOf<int>(i => i == 88888).Should().Be(expected: null);


            L.A(() => Test.IndexOf<int>(i => { throw new Exception(); })).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.IsEmpty) + "(IEnumerable) => Boolean")]
        public void Test_IsEmpty()
            {
            ((IEnumerable)"").IsEmpty().ShouldBeTrue();
            ((IEnumerable)"a").IsEmpty().ShouldBeFalse();
            ((IEnumerable)"   a   ").IsEmpty().ShouldBeFalse();
            ((IEnumerable)"       ").IsEmpty().ShouldBeFalse();
            new int[] { }.IsEmpty().ShouldBeTrue();
            new int[] { 5 }.IsEmpty().ShouldBeFalse();

            ((string)null).IsEmpty().ShouldBeTrue();
            ((int[])null).IsEmpty().ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable, Func`2<T, Boolean>) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(T[], Func`2<Object, Boolean>) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => T")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable, Int32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable`1<T>, Int32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable`1<T>, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(T[], Int32, Func`2<T, Boolean>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(T[], UInt32, Func`2<T, Boolean>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Last) + "(IEnumerable, T) => T")]
        public void Test_Last()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            Test.Last().Should().Be(expected: 253);
            Test.Last(Condition: null).Should().Be(expected: 253);
            Test.Last(i => false).Should().Be(default(int));
            Test.Last(i => true).Should().Be(expected: 253);
            Test.Last(i => i > 100).Should().Be(expected: 253);
            Test.Last(i => i > 100 && i < 1000).Should().Be(expected: 253);
            Test.Last(i => i > 1000).Should().Be(expected: 21436);

            Test.List().Last().Should().Be(expected: 253);
            Test.List().Last(Condition: null).Should().Be(expected: 253);
            Test.List().Last(i => false).Should().Be(default(int));
            Test.List().Last(i => true).Should().Be(expected: 253);
            Test.List().Last(i => i > 100).Should().Be(expected: 253);
            Test.List().Last(i => i > 100 && i < 1000).Should().Be(expected: 253);
            Test.List().Last(i => i > 1000).Should().Be(expected: 21436);

            ((IEnumerable)Test).Last<int>().Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int?>().Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int>(Condition: null).Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int>(i => false).Should().Be(default(int));
            ((IEnumerable)Test).Last<int?>((Func<int?, bool>)null).Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int?>(i => false).Should().Be((int?)null);
            ((IEnumerable)Test).Last<int>(i => true).Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int>(i => i > 100).Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int>(i => i > 100 && i < 1000).Should().Be(expected: 253);
            ((IEnumerable)Test).Last<int>(i => i > 1000).Should().Be(expected: 21436);
            }

        [Fact]
        public void Test_LastMulti()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            Func<int, bool> True = i => true;
            Func<int, bool> False = i => false;

            Test.Last(Count: 2).Should().Equal(2, 253);
            Test.Last(-5, True).Should().Equal();
            Test.Last(Count: 0, Condition: True).Should().Equal();
            Test.Last(Count: 2, Condition: False).Should().Equal();
            Test.Last(Count: 2, Condition: True).Should().Equal(2, 253);
            Test.Last(Count: 5, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.Last(Count: 2, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.Last(Count: 2, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.Last(Count: 2, Condition: i => i > 1000).Should().Equal(21436);

            Test.Last(Count: 2u).Should().Equal(2, 253);
            Test.Last(Count: 0u, Condition: True).Should().Equal();
            Test.Last(Count: 2u, Condition: False).Should().Equal();
            Test.Last(Count: 2u, Condition: True).Should().Equal(2, 253);
            Test.Last(Count: 5u, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.Last(Count: 2u, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.Last(Count: 2u, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.Last(Count: 2u, Condition: i => i > 1000).Should().Equal(21436);

            Test.List().Last(Count: 2).Should().Equal(2, 253);
            Test.List().Last(-5, True).Should().Equal();
            Test.List().Last(Count: 0, Condition: True).Should().Equal();
            Test.List().Last(Count: 2, Condition: False).Should().Equal();
            Test.List().Last(Count: 2, Condition: True).Should().Equal(2, 253);
            Test.List().Last(Count: 5, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.List().Last(Count: 2, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.List().Last(Count: 2, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.List().Last(Count: 2, Condition: i => i > 1000).Should().Equal(21436);

            Test.List().Last(Count: 2u).Should().Equal(2, 253);
            Test.List().Last(Count: 0u, Condition: True).Should().Equal();
            Test.List().Last(Count: 2u, Condition: False).Should().Equal();
            Test.List().Last(Count: 2u, Condition: True).Should().Equal(2, 253);
            Test.List().Last(Count: 5u, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            Test.List().Last(Count: 2u, Condition: i => i > 100).Should().Equal(21436, 253);
            Test.List().Last(Count: 2u, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            Test.List().Last(Count: 2u, Condition: i => i > 1000).Should().Equal(21436);

            ((IEnumerable)Test).Last<int>(Count: 2, Condition: null).Should().Equal(2, 253);
            ((IEnumerable)Test).Last<int>(-5, True).Should().Equal();
            ((IEnumerable)Test).Last<int>(Count: 0, Condition: True).Should().Equal();
            ((IEnumerable)Test).Last<int>(Count: 2, Condition: False).Should().Equal();
            ((IEnumerable)Test).Last<int>(Count: 2, Condition: True).Should().Equal(2, 253);
            ((IEnumerable)Test).Last<int>(Count: 5, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            ((IEnumerable)Test).Last<int>(Count: 2, Condition: i => i > 100).Should().Equal(21436, 253);
            ((IEnumerable)Test).Last<int>(Count: 2, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            ((IEnumerable)Test).Last<int>(Count: 2, Condition: i => i > 1000).Should().Equal(21436);

            ((IEnumerable)Test).Last<int>(Count: 2u, Condition: null).Should().Equal(2, 253);
            ((IEnumerable)Test).Last<int>(Count: 0u, Condition: True).Should().Equal();
            ((IEnumerable)Test).Last<int>(Count: 2u, Condition: False).Should().Equal();
            ((IEnumerable)Test).Last<int>(Count: 2u, Condition: True).Should().Equal(2, 253);
            ((IEnumerable)Test).Last<int>(Count: 5u, Condition: i => i > 2).Should().Equal(5, 21436, 7, 253);
            ((IEnumerable)Test).Last<int>(Count: 2u, Condition: i => i > 100).Should().Equal(21436, 253);
            ((IEnumerable)Test).Last<int>(Count: 2u, Condition: i => i > 100 && i < 1000).Should().Equal(253);
            ((IEnumerable)Test).Last<int>(Count: 2u, Condition: i => i > 1000).Should().Equal(21436);
            }

        [Fact]
        public void Test_LastMatch()
            {
            int[] Test = { 5, 21436, 7, 2, 2, 253 };

            ((IEnumerable)Test).Last(Object: 5).Should().Be(expected: 5);
            ((IEnumerable)Test).Last(Object: 10).Should().Be(default(int));
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.List) + "(IEnumerable, Boolean) => List`1<Object>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.List) + "(IEnumerable`1<T>, Boolean) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.List) + "(IEnumerable, Boolean) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.List) + "(IEnumerable`1<T>, Boolean) => List`1<U>")]
        public void Test_List()
            {
            int[] Test = { 5, 6, 2, 2 };
            object[] Test2 = { 5, 6, 2, 2, null, "a" };

            Test.List().Should().Equal(5, 6, 2, 2);
            Test2.List().Should().Equal(5, 6, 2, 2, "a");
            Test2.List(IncludeNulls: true).Should().Equal(5, 6, 2, 2, null, "a");
            Test2.List(IncludeNulls: false).Should().Equal(5, 6, 2, 2, "a");

            ((IEnumerable)Test).List().Should().Equal(5, 6, 2, 2);
            ((IEnumerable)Test2).List().Should().Equal(5, 6, 2, 2, "a");
            ((IEnumerable)Test2).List(IncludeNulls: true).Should().Equal(5, 6, 2, 2, null, "a");
            ((IEnumerable)Test2).List(IncludeNulls: false).Should().Equal(5, 6, 2, 2, "a");

            Test2.List<int>().Should().Equal(5, 6, 2, 2);
            Test2.List<string>().Should().Equal("a");
            Test2.List<object>().Should().Equal(5, 6, 2, 2, "a");
            Test2.List<object>(IncludeNulls: true).Should().Equal(5, 6, 2, 2, null, "a");
            Test2.List<object>(IncludeNulls: false).Should().Equal(5, 6, 2, 2, "a");
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Move) + "(T[], Int32, Int32)")]
        public void Test_Move_Array()
            {
            int[] Test = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            Test.Move(Index1: 0, Index2: 1);

            Test.Should().Equal(2, 1, 3, 4, 5, 6, 7, 8, 9);

            Test.Move(Index1: 0, Index2: 5);

            Test.Should().Equal(1, 3, 4, 5, 6, 2, 7, 8, 9);

            Test.Move(Index1: 4, Index2: 1);

            Test.Should().Equal(1, 6, 3, 4, 5, 2, 7, 8, 9);

            Test.Move(-1, Index2: 5);
            Test.Should().Equal(6, 3, 4, 5, 2, 1, 7, 8, 9);

            Test.Move(-1, -1);
            Test.Should().Equal(6, 3, 4, 5, 2, 1, 7, 8, 9);

            Test.Move(Index1: 0, Index2: 9);
            Test.Should().Equal(3, 4, 5, 2, 1, 7, 8, 9, 6);

            Test.Move(Index1: 9, Index2: 9);
            Test.Should().Equal(3, 4, 5, 2, 1, 7, 8, 9, 6);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Move) + "(IList, Int32, Int32)")]
        public void Test_Move_List()
            {
            List<int> Test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.List();

            Test.Move(Index1: 0, Index2: 1);
            Test.Should().Equal(2, 1, 3, 4, 5, 6, 7, 8, 9);
            Test.Move(Index1: 0, Index2: 5);
            Test.Should().Equal(1, 3, 4, 5, 6, 2, 7, 8, 9);
            Test.Move(Index1: 4, Index2: 1);
            Test.Should().Equal(1, 6, 3, 4, 5, 2, 7, 8, 9);


            Test.Move(-1, Index2: 5);
            Test.Should().Equal(6, 3, 4, 5, 2, 1, 7, 8, 9);

            Test.Move(-1, -1);
            Test.Should().Equal(6, 3, 4, 5, 2, 1, 7, 8, 9);

            Test.Move(Index1: 0, Index2: 9);
            Test.Should().Equal(3, 4, 5, 2, 1, 7, 8, 9, 6);

            Test.Move(Index1: 9, Index2: 9);
            Test.Should().Equal(3, 4, 5, 2, 1, 7, 8, 9, 6);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Named) + "(IEnumerable, String) => List`1<INamed>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Named) + "(T[], String) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Named) + "(IEnumerable`1<T>, String) => IEnumerable`1<T>")]
        public void Test_Named()
            {
            TestGroup[] Test =
                {
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("a"),
                new TestGroup("b"),
                new TestGroup("b"),
                new TestGroup("b")
                };


            Test.Named("a").Length.Should().Be(expected: 6);
            Test.Named("A").Length.Should().Be(expected: 0);
            Test.Named("b").Length.Should().Be(expected: 3);
            Test.Named("").Length.Should().Be(expected: 0);
            Test.Named(Name: null).Length.Should().Be(expected: 0);

            List<TestGroup> Test2 = Test.List();

            Test2.Named("a").Count().Should().Be(expected: 6);
            Test2.Named("A").Count().Should().Be(expected: 0);
            Test2.Named("b").Count().Should().Be(expected: 3);
            Test2.Named("").Count().Should().Be(expected: 0);
            Test2.Named(Name: null).Count().Should().Be(expected: 0);

            ((IEnumerable)Test2).Named("a").Count.Should().Be(expected: 6);
            ((IEnumerable)Test2).Named("A").Count.Should().Be(expected: 0);
            ((IEnumerable)Test2).Named("b").Count.Should().Be(expected: 3);
            ((IEnumerable)Test2).Named("").Count.Should().Be(expected: 0);
            ((IEnumerable)Test2).Named(Name: null).Count.Should().Be(expected: 0);

            ((INamed[])null).Named("A").Count().Should().Be(expected: 0);
            ((IEnumerable<INamed>)null).Named("A").Count().Should().Be(expected: 0);
            ((IEnumerable<INamed>)null).Named("A").Count().Should().Be(expected: 0);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Named) + "(IEnumerable, String, Func`2<Object, String>) => List`1<Object>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Named) + "(IEnumerable`1<T>, String, Func`2<T, String>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Named) + "(T[], String, Func`2<T, String>) => T[]")]
        public void Test_Named_Func()
            {
            int[] Test = { 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 };

            Func<int, string> Namer = new Func<int, string>(i => i.ToString().Sub(Start: 0, Length: 1));
            Func<object, string> Namer2 = new Func<object, string>(i => i.ToString().Sub(Start: 0, Length: 1));

            Test.Named("a", Namer).Should().BeEmpty();
            Test.Named("1", Namer).Length.Should().Be(expected: 2);
            Test.Named("8", Namer).Length.Should().Be(expected: 1);

            List<int> Test2 = Test.List();
            Test2.Named("a", Namer).Should().BeEmpty();
            Test2.Named("1", Namer).Count.Should().Be(expected: 2);
            Test2.Named("8", Namer).Count.Should().Be(expected: 1);

            ((IEnumerable)Test2).Named("a", Namer2).Should().BeEmpty();
            ((IEnumerable)Test2).Named("1", Namer2).Count().Should().Be(expected: 2);
            ((IEnumerable)Test2).Named("8", Namer2).Count().Should().Be(expected: 1);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Random) + "(IEnumerable`1<T>, Int32, Boolean) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Random) + "(IEnumerable`1<T>, UInt32, Boolean) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Random) + "(T[], Int32, Boolean) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Random) + "(T[], UInt32, Boolean) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Random) + "(IEnumerable`1<T>) => T")]
        public void Test_Random()
            {
            int[] Test = { 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 };
            uint[] Test2 = { 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 };

            for (int i = 0; i < 300; i++)
                {
                Test.Has(Test.Random()).ShouldBeTrue();
                }


            Test.Random(-1).Should().BeEmpty();
            Test.Random(Count: 0).Should().BeEmpty();

            Test.List().Random(-1).Should().BeEmpty();
            Test.List().Random(Count: 0).Should().BeEmpty();

            for (int i = 0; i < 20; i++)
                {
                int[] Results = Test.Random(Count: 5);

                Results.Length.Should().Be(expected: 5);
                Results.All(Item => Test.Has(Item)).ShouldBeTrue();


                int[] Results2 = Test.Random(Count: 50, AllowDuplicates: false);

                Results2.Length.Should().Be(Test.Length);
                Results2.All(Item => Test.Has(Item)).ShouldBeTrue();

                int[] Results3 = Test.Random(Count: 50, AllowDuplicates: true);

                Results3.Length.Should().Be(expected: 50);
                Results3.All(Item => Test.Has(Item)).ShouldBeTrue();


                int[] Results4 = Test.Random(Count: 5u);

                Results4.Length.Should().Be(expected: 5);
                Results4.All(Item => Test.Has(Item)).ShouldBeTrue();


                int[] Results5 = Test.Random(Count: 50u, AllowDuplicates: false);

                Results5.Length.Should().Be(Test.Length);
                Results5.All(Item => Test.Has(Item)).ShouldBeTrue();

                int[] Results6 = Test.Random(Count: 50u, AllowDuplicates: true);

                Results6.Length.Should().Be(expected: 50);
                Results6.All(Item => Test.Has(Item)).ShouldBeTrue();


                List<int> Test3 = Test.List();

                List<int> Result7 = Test3.Random(Count: 5);

                Result7.Count.Should().Be(expected: 5);
                Result7.All(Item => Test.Has(Item)).ShouldBeTrue();


                List<int> Results8 = Test3.Random(Count: 50, AllowDuplicates: false);

                Results8.Count.Should().Be(Test.Length);
                Results8.All(Item => Test.Has(Item)).ShouldBeTrue();

                List<int> Results9 = Test3.Random(Count: 50, AllowDuplicates: true);

                Results9.Count.Should().Be(expected: 50);
                Results9.All(Item => Test.Has(Item)).ShouldBeTrue();


                List<int> Results10 = Test3.Random(Count: 5u);

                Results10.Count.Should().Be(expected: 5);
                Results10.All(Item => Test.Has(Item)).ShouldBeTrue();


                List<int> Results11 = Test3.Random(Count: 50u, AllowDuplicates: false);

                Results11.Count.Should().Be(Test.Length);
                Results11.All(Item => Test.Has(Item)).ShouldBeTrue();

                List<int> Results12 = Test3.Random(Count: 50u, AllowDuplicates: true);

                Results12.Count.Should().Be(expected: 50);
                Results12.All(Item => Test.Has(Item)).ShouldBeTrue();
                }

            L.Obj.NewRandom_TypeCreators.Keys.Random().Should().NotBeNull();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Remove) + "(IEnumerable`1<T>, T[]) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Remove) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Remove) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => List`1<T>")]
        public void Test_Remove()
            {
            int[] Test = { 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 };

            Test.Remove(6, 5).Should().Equal(48498, 45, 542, 321, 2, 1, 13, 698, 9, 88, 7, 44, 223, 3, 446);
            Test.Remove(0, 1).Should().Equal(48498, 45, 6, 542, 321, 2, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);
            Test.Remove().Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);
            Test.Remove(i => i < 1000).Should().Equal(48498);
            Test.Remove((Index, Item) => Index < 6).Should().Equal(1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);

            Test.List().Remove(6, 5).Should().Equal(48498, 45, 542, 321, 2, 1, 13, 698, 9, 88, 7, 44, 223, 3, 446);
            Test.List()
                .Remove(0, 1)
                // ReSharper disable ArgumentsStyleLiteral
                .ShouldBeEquivalentTo(new List<int> { 48498, 45, 6, 542, 321, 2, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 });
            // ReSharper restore ArgumentsStyleLiteral
            Test.List().Remove().Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);
            Test.List().Remove(i => i < 1000).Should().Equal(48498);
            Test.List().Remove((Index, Item) => Index < 6).Should().Equal(1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveAt) + "(IEnumerable`1<T>, Int32[]) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveAt) + "(T[], Int32[]) => T[]")]
        public void Test_RemoveAt()
            {
            int[] Test = { 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 };


            Test.RemoveAt().Should()
                .Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);


            Test.RemoveAt(5, 1, 6, 8, 64, 3, 6, 7).Should()
                .Equal(48498, 6, 321, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);

            Test.RemoveAt(-5, 1, 6, -8, -64, 3, 6, 7).Should()
                .Equal(48498, 6, 321, 2, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);


            Test.List().RemoveAt().Should()
                .Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);


            Test.List().RemoveAt(5, 1, 6, 8, 64, 3, 6, 7).Should()
                .Equal(48498, 6, 321, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);

            Test.List().RemoveAt(-5, 1, 6, -8, -64, 3, 6, 7).Should()
                .Equal(48498, 6, 321, 2, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveDuplicate) + "(IEnumerable`1<T>, Func`2<T, U>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveDuplicate) + "(T[], Func`2<T, U>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveDuplicate) + "(IEnumerable, Func`2<T, U>) => List`1<T>")]
        public void Test_RemoveDuplicate()
            {
            int[] Test = { 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6, 446 };

            Func<int, string> Func = i => i.ToString().Sub(Start: 0, Length: 2);
            Func<int, string> Func2 = i => i.ToString().Sub(Start: 0, Length: 1);

            //////////////////////////////////

            Test.RemoveDuplicate(Func)
                .Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3);
            Test.RemoveDuplicate(Func2)
                .Should().Equal(48498, 6, 542, 321, 2, 1, 9, 88, 7);

            Test.RemoveDuplicate(Func)
                .Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3);

            Test.Convert(i => i.ToString()).RemoveDuplicate(s => s.Sub(Start: 0, Length: 1))
                .Should().Equal("48498", "6", "542", "321", "2", "1", "9", "88", "7");

            //////////////////////////////////

            var TestList = Test.List();

            TestList.RemoveDuplicate(Func)
                .Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3);
            TestList.RemoveDuplicate(Func2)
                .Should().Equal(48498, 6, 542, 321, 2, 1, 9, 88, 7);

            TestList.RemoveDuplicate(Func)
                .Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3);

            TestList.Convert(i => i.ToString()).RemoveDuplicate(s => s.Sub(Start: 0, Length: 1))
                .Should().Equal("48498", "6", "542", "321", "2", "1", "9", "88", "7");

            //////////////////////////////////

            ((IEnumerable)TestList).RemoveDuplicate(Func)
                .Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3);
            ((IEnumerable)TestList).RemoveDuplicate(Func2)
                .Should().Equal(48498, 6, 542, 321, 2, 1, 9, 88, 7);

            ((IEnumerable)TestList).RemoveDuplicate(Func)
                .Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3);

            ((IEnumerable)TestList.Convert(i => i.ToString())).RemoveDuplicate<string, string>(s => s.Sub(Start: 0, Length: 1))
                .Should().Equal("48498", "6", "542", "321", "2", "1", "9", "88", "7");
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveDuplicates) + "(T[]) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveDuplicates) + "(IEnumerable) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.RemoveDuplicates) + "(IEnumerable`1<T>) => List`1<T>")]
        public void Test_RemoveDuplicates()
            {
            int[] Test =
                {
                48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4
                };

            Test.RemoveDuplicates().Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3, 446, 4);
            Test.Convert(i => i.ToString()).RemoveDuplicates()
                .Should().Equal("48498", "45", "6", "542", "321", "2", "1", "13", "5", "698", "9", "88", "7", "44", "223", "3", "446", "4");

            Test.List().RemoveDuplicates().Should().Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3, 446, 4);
            Test.Convert(i => i.ToString())
                .List()
                .RemoveDuplicates()
                .Should()
                .Equal("48498", "45", "6", "542", "321", "2", "1", "13", "5", "698", "9", "88", "7", "44", "223", "3", "446", "4");

            new List<int>().RemoveDuplicates().Should().Equal();

            ((IEnumerable)Test).RemoveDuplicates<int>()
                .Should()
                .Equal(48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 44, 223, 3, 446, 4);
            ((IEnumerable)Test.Convert(i => i.ToString())).RemoveDuplicates<string>()
                .Should()
                .Equal("48498", "45", "6", "542", "321", "2", "1", "13", "5", "698", "9", "88", "7", "44", "223", "3", "446", "4");

            ((IEnumerable)(object)new List<int>()).RemoveDuplicates<int>().Should().Equal();
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Mirror) + "(T[]) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Mirror) + "(IEnumerable`1<T>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Mirror) + "(IEnumerable) => List`1<T>")]
        public void Test_Mirror()
            {
            int[] Test =
                {
                48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4
                };


            int[] Mirrored =
                {
                4, 3, 2, 1, 5, 4, 4, 4, 4, 2, 446, 6, 5, 3, 223, 5, 6, 44, 5, 7, 88, 9,
                698, 5, 13, 1, 2, 321, 542, 6, 45, 48498, 446, 6, 5, 3, 223, 5, 6, 44, 5, 7, 88, 9, 698,
                5, 13, 1, 2, 321, 542, 6, 45, 48498
                };


            Test.Mirror().Should().Equal(Mirrored);
            Test.List().Mirror().Should().Equal(Mirrored);
            ((IEnumerable)Test).Mirror<int>().Should().Equal(Mirrored);

            Test.Mirror().Mirror().Should().Equal(Test);
            Test.List().Mirror().Mirror().Should().Equal(Test);
            ((IEnumerable)Test).Mirror<int>().Mirror().Should().Equal(Test);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(T[], Func`2<T, Boolean>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(IEnumerable, Func`2<T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(IEnumerable, Func`3<Int32, T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(T[], Func`3<Int32, T, Boolean>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(List`1<T>, Func`3<Int32, T, Boolean>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Select) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => List`1<T>")]
        public void Test_Select()
            {
            int[] Test =
                {
                48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4
                };

            var IndexTest = new List<int>();
            //////////////////////

            Test.Select(i => i < 50)
                .Should()
                .Equal(45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1,
                    2, 3, 4);
            Test.Select(i => i > 50).Should().Equal(48498, 542, 321, 698, 88, 223, 446, 48498, 542, 321, 698, 88, 223, 446);
            Test.Select(i => i < 10)
                .Should()
                .Equal(6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            Test.Select((Index, Item) => Item < 50)
                .Should()
                .Equal(45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1,
                    2, 3, 4);
            Test.Select((Index, Item) => Item > 50).Should().Equal(48498, 542, 321, 698, 88, 223, 446, 48498, 542, 321, 698, 88, 223, 446);
            Test.Select((Index, Item) =>
                {
                    IndexTest.Add(Index);
                    return Item < 10;
                }).Should().Equal(6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            IndexTest.Should()
                .Equal(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
                    32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53);

            //////////////////////
            IndexTest = new List<int>();

            Test.List()
                .Select(i => i < 50)
                .Should()
                .Equal(45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1,
                    2, 3, 4);
            Test.List().Select(i => i > 50).Should().Equal(48498, 542, 321, 698, 88, 223, 446, 48498, 542, 321, 698, 88, 223, 446);
            Test.List()
                .Select(i => i < 10)
                .Should()
                .Equal(6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            Test.List()
                .Select<int>((Index, Item) => Item < 50)
                .Should()
                .Equal(45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1,
                    2, 3, 4);
            Test.List()
                .Select<int>((Index, Item) => Item > 50)
                .Should()
                .Equal(48498, 542, 321, 698, 88, 223, 446, 48498, 542, 321, 698, 88, 223, 446);
            Test.List().Select<int>((Index, Item) =>
                {
                    IndexTest.Add(Index);
                    return Item < 10;
                }).Should().Equal(6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            IndexTest.Should()
                .Equal(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
                    32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53);

            //////////////////////
            IndexTest = new List<int>();

            ((IEnumerable)Test.List()).Select<int>(i => i < 50)
                .Should()
                .Equal(45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1,
                    2, 3, 4);
            ((IEnumerable)Test.List()).Select<int>(i => i > 50)
                .Should()
                .Equal(48498, 542, 321, 698, 88, 223, 446, 48498, 542, 321, 698, 88, 223, 446);
            ((IEnumerable)Test.List()).Select<int>(i => i < 10)
                .Should()
                .Equal(6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            ((IEnumerable)Test.List()).Select<int>((Index, Item) => Item < 50)
                .Should()
                .Equal(45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 45, 6, 2, 1, 13, 5, 9, 7, 5, 44, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1,
                    2, 3, 4);
            ((IEnumerable)Test.List()).Select<int>((Index, Item) => Item > 50)
                .Should()
                .Equal(48498, 542, 321, 698, 88, 223, 446, 48498, 542, 321, 698, 88, 223, 446);
            ((IEnumerable)Test.List()).Select<int>((Index, Item) =>
               {
                   IndexTest.Add(Index);
                   return Item < 10;
               }).Should().Equal(6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 6, 2, 1, 5, 9, 7, 5, 6, 5, 3, 5, 6, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            IndexTest.Should()
                .Equal(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
                    32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.SetAt) + "(IEnumerable, Int32, T)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.SetAt) + "(IEnumerable, UInt32, T)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.SetAt) + "(IEnumerable`1<T>, Int32, T)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.SetAt) + "(IEnumerable`1<T>, UInt32, T)")]
        public void Test_SetAt()
            {
            int[] Test =
                {
                48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4
                };
            var Test2 = Test.List();
            var Test3 = Test.List();

            Test.SetAt(Index: 0, Value: 0);
            Test.SetAt(Index: 1, Value: 5);

            Test.Should().Equal(0, 5, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            // Out of range silently fails.
            Test.SetAt(-1, Value: 5);
            Test.SetAt(Index: 1000, Value: 5);

            Test.Should().Equal(0, 5, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);


            //////////////////////////////////////////////


            Test2.SetAt(Index: 0, Value: 0);
            Test2.SetAt(Index: 1, Value: 5);

            Test2.Should().Equal(0, 5, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            // Out of range silently fails.
            Test2.SetAt(-1, Value: 5);
            Test2.SetAt(Index: 1000, Value: 5);

            Test2.Should().Equal(0, 5, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            //////////////////////////////////////////////

            ((IEnumerable)Test3).SetAt(Index: 0, Value: 0);
            ((IEnumerable)Test3).SetAt(Index: 1, Value: 5);

            Test3.Should().Equal(0, 5, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);

            ((IEnumerable)Test3).SetAt(-1, Value: 5);
            ((IEnumerable)Test3).SetAt(Index: 1000, Value: 5);

            ((IEnumerable)Test3).Should().Equal(0, 5, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Shuffle) + "(IEnumerable`1<T>) => List`1<T>")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Shuffle) + "(T[]) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Shuffle) + "(IEnumerable) => List`1<T>")]
        public void Test_Shuffle()
            {
            int[] Test =
                {
                48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5,
                6, 446, 48498, 45, 6, 542, 321, 2, 1, 13, 5, 698, 9, 88, 7, 5, 44, 6, 5, 223, 3, 5, 6,
                446, 2, 4, 4, 4, 4, 5, 1, 2, 3, 4
                };

            // Test 30 times
            for (int i = 0; i < 30; i++)
                {
                // Have all items with no regard for order.
                var Shuffled = Test.Shuffle();
                Shuffled.ShouldBeEquivalentTo(Test);

                // But not equal to test with order (incredibly small chance for this to fail randomly)
                Shuffled.ToS().Should().NotBe(Test.ToS());
                }


            // Test List
            List<int> Test2 = Test.List();

            // Test 100 times
            for (int i = 0; i < 30; i++)
                {
                // Have all items with no regard for order.
                var Shuffled = Test2.Shuffle();
                Shuffled.ShouldBeEquivalentTo(Test2);

                // But not equal to test with order (incredibly small chance for this to fail randomly)
                Shuffled.ToS().Should().NotBe(Test2.ToS());
                }

            // Test List
            IEnumerable Test3 = Test.List();

            // Test 100 times
            for (int i = 0; i < 30; i++)
                {
                // Have all items with no regard for order.
                var Shuffled = Test3.Shuffle<int>();
                Shuffled.ShouldBeEquivalentTo(Test3);

                // But not equal to test with order (incredibly small chance for this to fail randomly)
                Shuffled.ToS().Should().NotBe(Test3.ToS());
                }
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Sort) + "(IList)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Sort) + "(IList`1<T>, Func`3<T, T, Int32>)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Sort) + "(IList`1<T>, Func`2<T, IComparable>)")]
        public void Test_Sort()
            {
            for (int i = 0; i < 50; i++)
                {
                int[] Random = new int[50].Fill(j => (int)L.Obj.NewRandom<int>());

                Random.Sort();
                Random.Should().BeInAscendingOrder();

                string[] Random2 = new string[50].Fill(j => (string)typeof(string).NewRandom());

                Random2.Sort();
                Random2.Should().BeInAscendingOrder();

                char[] Random3 = new char[50].Fill(j => (char)L.Obj.NewRandom<char>());

                Random3.Sort();
                Random3.Should().BeInAscendingOrder();

                string[] Random4 = new string[50].Fill(j => (string)typeof(string).NewRandom());

                Random4.Sort(s => s.ToString());
                Random4.Should().BeInAscendingOrder();

                string[] Random5 = new string[50].Fill(j => (string)typeof(string).NewRandom());

                // ReSharper disable once StringCompareToIsCultureSpecific
                Random5.Sort((o1, o2) => o1.CompareTo(o2));
                Random5.Should().BeInAscendingOrder();

                string[] Random6 = new string[50].Fill(j => (string)typeof(string).NewRandom());

                // ReSharper disable once StringCompareToIsCultureSpecific
                Random6.Sort((Func<string, IComparable>)null);
                Random6.Should().BeInAscendingOrder();

                string[] Random7 = new string[50].Fill(j => (string)typeof(string).NewRandom());

                // ReSharper disable once StringCompareToIsCultureSpecific
                Random7.Sort((Func<string, string, int>)null);
                Random7.Should().BeInAscendingOrder();
                }
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Swap) + "(T[], Int32, Int32)")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Swap) + "(IList, Int32, Int32)")]
        public void Test_Swap()
            {
            int[] Test = { 48498, 45, 6, 542, 321, 2, 1 };


            List<int> Test2 = Test.List();

            Test.Swap(Index1: 0, Index2: 1);
            Test.Should().Equal(45, 48498, 6, 542, 321, 2, 1);
            Test.Swap(Index1: 1, Index2: 5);
            Test.Should().Equal(45, 2, 6, 542, 321, 48498, 1);
            Test.Swap(-1, Index2: 10);
            Test.Should().Equal(1, 2, 6, 542, 321, 48498, 45);
            Test.Swap(-1, -1);
            Test.Should().Equal(1, 2, 6, 542, 321, 48498, 45);
            Test.Swap(Index1: 10, Index2: 10);
            Test.Should().Equal(1, 2, 6, 542, 321, 48498, 45);

            Test2.Swap(Index1: 0, Index2: 1);
            Test2.Should().Equal(45, 48498, 6, 542, 321, 2, 1);
            Test2.Swap(Index1: 1, Index2: 5);
            Test2.Should().Equal(45, 2, 6, 542, 321, 48498, 1);
            Test2.Swap(-1, Index2: 10);
            Test2.Should().Equal(1, 2, 6, 542, 321, 48498, 45);
            Test2.Swap(-1, -1);
            Test2.Should().Equal(1, 2, 6, 542, 321, 48498, 45);
            Test2.Swap(Index1: 10, Index2: 10);
            Test2.Should().Equal(1, 2, 6, 542, 321, 48498, 45);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.TotalCount) + "(IEnumerable) => Int32")]
        public void Test_TotalCount()
            {
            var Test = new object[]
                {
                1,
                2,
                3,
                new int[] {4, 5, 6},
                new object[]
                    {
                    null,
                    new int[] {7, 8, 9, 10},
                    new int[] {11, 12, 13, 14}
                    },
                "15",
                "    16    "
                };


            Test.TotalCount().Should().Be(expected: 16);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Add) + "(T[], IEnumerable`1<T>) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Add) + "(T[], T[]) => T[]")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Add) + "(List`1<T>, T[])")]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.Add) + "(List`1<T>, IEnumerable`1<T>)")]
        public void Test_Add()
            {
            int[] Test = { 1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736 };

            int[] Test2 = { 52317854, 87, 53, 23843254, 1, 45394, 73643854, 948746, 5 };


            Test.Add(5)
                .Should()
                .Equal(1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736, 5);


            Test.Add(5, 6, 7, 8, 1)
                .Should()
                .Equal(1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736, 5, 6, 7, 8, 1);
            }

        [Fact]
        public void Test_Add_List()
            {
            // ReSharper disable ArgumentsStyleLiteral
            List<int> Test = new List<int> { 1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736, 5 };
            // ReSharper restore ArgumentsStyleLiteral


            Test.Should()
                .Equal(1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736, 5);


            Test.Add(5, 6, 7, 8, 1);
            Test.Should()
                .Equal(1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736, 5, 5, 6, 7, 8, 1);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." +
            nameof(EnumerableExt.AddTo) + "(IEnumerable`1<T>, ICollection)")]
        public void Test_AddTo()
            {
            int[] Test = { 1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736 };

            Collection<int> Collection = new Collection<int>();

            Test.AddTo(Collection);

            Collection.Should().Equal(1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736);

            Test.AddTo(Collection);

            Collection.Should()
                .Equal(1, 3, 7, 8, 3, 33578, 24, 7854, 332889, 35235, 78, 235839, 26, 765643547, 54736, 1, 3, 7, 8, 3, 33578, 24, 7854,
                    332889, 35235, 78, 235839, 26, 765643547, 54736);

            var Test2 = new BadCollection();

            L.A(() => Test.AddTo(Test2)).ShouldFail<InvalidOperationException>();

            var Test3 = new AmbiguousMatchCollection();

            L.A(() => Test.Convert<int, string>(i => $"{i}").AddTo(Test3)).ShouldFail<InvalidOperationException>();
            }

        [Fact]
        public void Test_GetAt_SetAt_CustomIndexer()
            {
            var Test = new CustomIndexer();

            Test.Str.Should().Be("it's just a test");

            Test.Count().Should().Be(expected: 16);
            Test.HasIndex(Index: 3).ShouldBeTrue();
            Test.GetAt(Index: 0).Should().Be(expected: 'i');
            Test.GetAt(Index: 1).Should().Be(expected: 't');
            Test.GetAt(Index: 2).Should().Be(expected: '\'');
            Test.GetAt(Index: 3).Should().Be(expected: 's');
            Test.SetAt(Index: 3, Value: 'd');
            Test.GetAt(Index: 3).Should().Be(expected: 'd');

            Test.Str.Should().Be("it'd just a test");

            ((IEnumerable)Test).SetAt(Index: 4, Value: '-');
            ((IEnumerable)Test).GetAt(Index: 4).Should().Be(expected: '-');
            Test.Str.Should().Be("it'd-just a test");

            var Test2 = new CustomIndexerU();

            Test2.Str.Should().Be("it's just a test");
            Test2.SetAt(Index: 12u, Value: 'v');
            Test2.GetAt(Index: 12u).Should().Be(expected: 'v');
            Test2.Str.Should().Be("it's just a vest");

            ((IEnumerable)Test2).SetAt(Index: 14u, Value: 'n');
            ((IEnumerable)Test2).GetAt(Index: 14u).Should().Be(expected: 'n');
            Test2.Str.Should().Be("it's just a vent");
            }

        #region Internal

        [ExcludeFromCodeCoverage]
        internal class TestGroup : IGrouped, INamed
            {
            public TestGroup(string Group)
                {
                this.Group = Group;
                }

            public string Group { get; }

            public string Name => this.Group;
            }

        [ExcludeFromCodeCoverage]
        internal class AmbiguousMatchCollection : ICollection
            {
            public string this[int Index]
                {
                get { return $"{Index}"; }
                // ReSharper disable once ValueParameterNotUsed
                set { }
                }

            // ReSharper disable once NotNullMemberIsNotInitialized
            public AmbiguousMatchCollection() { }

            public AmbiguousMatchCollection(object SyncRoot, bool IsSynchronized)
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

            public void Add(string Str) { }

            public void Add(string Obj, bool Test = false) { }

            public void Add<T>(string Obj) { }
            public void Add<T>(string Obj, bool Test = false) { }

            public void Add(object Obj) { }
            public void Add<T>(object Obj) { }
            }

        [ExcludeFromCodeCoverage]
        internal class BadCollection : ICollection
            {
            public string this[int Index]
                {
                get { return $"{Index}"; }
                // ReSharper disable once ValueParameterNotUsed
                set { }
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

        [ExcludeFromCodeCoverage]
        internal class CustomIndexer : IEnumerable<char>
            {
            public string Str => new string(this.Chars);
            private char[] Chars = "it's just a test".Array();

            public char this[int Index]
                {
                get { return this.Str[Index]; }
                // ReSharper disable once ValueParameterNotUsed
                set { this.Chars.SetAt(Index, value); }
                }

            public IEnumerator<char> GetEnumerator()
                {
                return (IEnumerator<char>)this.Chars.GetEnumerator();
                }

            IEnumerator IEnumerable.GetEnumerator()
                {
                return this.Chars.GetEnumerator();
                }
            }

        [ExcludeFromCodeCoverage]
        internal class CustomIndexerU : IEnumerable<char>
            {
            public string Str => new string(this.Chars);
            private char[] Chars = "it's just a test".Array();

            public char this[uint Index]
                {
                get { return this.Str[(int)Index]; }
                // ReSharper disable once ValueParameterNotUsed
                set { this.Chars.SetAt(Index, value); }
                }

            public IEnumerator<char> GetEnumerator()
                {
                return (IEnumerator<char>)this.Chars.GetEnumerator();
                }

            IEnumerator IEnumerable.GetEnumerator()
                {
                return this.Chars.GetEnumerator();
                }
            }

        [ExcludeFromCodeCoverage]
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