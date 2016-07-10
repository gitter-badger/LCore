using System;
using System.Threading;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ObjectCreationAsStatement

namespace L_Tests.Tests.Tools
    {
    [TestClass]
    public class StopWatchTest
        {
        [TestMethod]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_StopWatch()
            {
            var Test = new StopWatch();

            lock (Test)
                {
                Test.Start();
                Thread.Sleep(200);
                Test.Stop().Should().BeInRange(190, 210);

                Test.Start();
                Thread.Sleep(20);
                Test.Stop().Should().BeInRange(18, 22);
                }
            }
        }
    }
