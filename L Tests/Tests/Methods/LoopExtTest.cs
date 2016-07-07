using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;

namespace L_Tests
    {
    [TestClass]
    public class LoopExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(LoopExt) };


        [TestMethod]
        public void Test_To()
            {
            const int begin = 0;
            const int end = 10;

            int result = 0;

            List<int> result2 = begin.To(end, () =>
                {
                    result++;
                    return result;
                });

            result.Should().Be(11);

            result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

            //Reset
            result = 0;

            var test2 = new Func<int>(() =>
                {
                    result++;
                    return result;
                });

            result2 = begin.To(begin, test2);

            result.Should().Be(1);
            result2.ShouldAllBeEquivalentTo(new List<int> { 1 });

            //Reset
            result = 0;

            result2 = begin.To(begin + 1, test2);

            result.Should().Be(2);
            result2.ShouldAllBeEquivalentTo(new List<int> { 1, 2 });
            }
        }
    }
