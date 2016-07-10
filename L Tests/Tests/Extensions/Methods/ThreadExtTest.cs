
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using FluentAssertions;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class ThreadExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ThreadExt) };

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Async()
            {
            bool Success = false;
            var TestAction = new Action(() => { Success = true; });

            lock (TestAction)
                {
                TestAction.Async()();
                Success.Should().BeFalse();

                Thread.Sleep(10);

                Success.Should().BeTrue();
                }
            }
        }
    }
