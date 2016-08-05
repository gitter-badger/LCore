using System;
using System.Threading;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable ObjectCreationAsStatement

namespace L_Tests.Tests.Tools
    {
    [Trait(Category, LCore.LUnit.LUnit.Categories.Tools)]
    public class StopWatchTest
        {
        [Fact]
        public void Test_StopWatch()
            {
            var Test = new StopWatch();

            lock (Test)
                {
                Test.Start();
                Thread.Sleep(200);

                Test.Stop().Should().BeInRange(190, 225);

                Test.Start();
                Thread.Sleep(20);
                Test.Stop().Should().BeInRange(15, 25);
                }
            }
        }
    }