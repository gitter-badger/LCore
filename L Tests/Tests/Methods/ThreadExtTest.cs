
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using FluentAssertions;

namespace L_Tests
    {
    [TestClass]
    public class ThreadExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ThreadExt) };

        [TestMethod]
        public void Test_Async()
            {
            bool success = false;
            var test_act = new Action(() => { success = true; });

            test_act.Async()();
            success.Should().BeFalse();

            Thread.Sleep(10);

            success.Should().BeTrue();
            }
        }
    }
