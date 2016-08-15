using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt))]
    public partial class LoopExtTester : XUnitOutputTester, IDisposable
        {
        public LoopExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt) + "." + nameof(LoopExt.To) +
            "(Int32, Int32, Func`1<U>) => List`1<U>")]
        public void Test_To_0()
            {
            const int Begin = 0;
            const int End = 10;

            int Result = 0;

            List<int> Result2 = Begin.To(End, () =>
                {
                    Result++;
                    return Result;
                });

            Result.Should().Be(expected: 11);

            // ReSharper disable ArgumentsStyleLiteral
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            // ReSharper restore ArgumentsStyleLiteral

            //Reset
            Result = 0;

            var Test2 = new Func<int>(() =>
                {
                    Result++;
                    return Result;
                });

            Result2 = Begin.To(Begin, Test2);

            Result.Should().Be(expected: 1);
            // ReSharper disable once ArgumentsStyleLiteral
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1 });

            //Reset
            Result = 0;

            Result2 = Begin.To(Begin + 1, Test2);

            Result.Should().Be(expected: 2);
            // ReSharper disable ArgumentsStyleLiteral
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2 });
            // ReSharper restore ArgumentsStyleLiteral
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LoopExt) + "." + nameof(LoopExt.To) +
            "(Int32, Int32, Func`2<Int32, T>) => List`1<T>")]
        public void Test_To_1()
            {
            const int Begin = 0;
            const int End = 10;

            int Result = 0;

            List<int> Result2 = Begin.To(End, i =>
                {
                    i.Should().Be(Result);

                    Result++;
                    return Result;
                });

            Result.Should().Be(expected: 11);

            // ReSharper disable ArgumentsStyleLiteral
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            // ReSharper restore ArgumentsStyleLiteral

            //Reset
            Result = 0;

            var Test2 = new Func<int, int>(i =>
                {
                    i.Should().Be(Result);

                    Result++;
                    return Result;
                });

            Result2 = Begin.To(Begin, Test2);

            Result.Should().Be(expected: 1);
            // ReSharper disable once ArgumentsStyleLiteral
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1 });

            //Reset
            Result = 0;

            Result2 = Begin.To(Begin + 1, Test2);

            Result.Should().Be(expected: 2);
            // ReSharper disable ArgumentsStyleLiteral
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2 });
            // ReSharper restore ArgumentsStyleLiteral
            }
        }
    }