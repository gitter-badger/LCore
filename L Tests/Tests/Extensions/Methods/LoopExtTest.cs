using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class LoopExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(LoopExt) };


        [Fact]
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

            Result.Should().Be(11);

            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

            //Reset
            Result = 0;

            var Test2 = new Func<int>(() =>
                {
                    Result++;
                    return Result;
                });

            Result2 = Begin.To(Begin, Test2);

            Result.Should().Be(1);
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1 });

            //Reset
            Result = 0;

            Result2 = Begin.To(Begin + 1, Test2);

            Result.Should().Be(2);
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2 });
            }

        [Fact]
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

            Result.Should().Be(11);

            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

            //Reset
            Result = 0;

            var Test2 = new Func<int, int>(i =>
            {
                i.Should().Be(Result);

                Result++;
                 return Result;
             });

            Result2 = Begin.To(Begin, Test2);

            Result.Should().Be(1);
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1 });

            //Reset
            Result = 0;

            Result2 = Begin.To(Begin + 1, Test2);

            Result.Should().Be(2);
            Result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2 });
            }
        }
    }
