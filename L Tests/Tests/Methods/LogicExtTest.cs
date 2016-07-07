
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;

namespace L_Tests
    {
    [TestClass]
    public class LogicExtTest : ExtensionTester
        {
        private static readonly string TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] { typeof(LogicExt) };


        [TestMethod]
        public void Test_Cast_0()
            {
            bool result = false;
            Action<object> act = o =>
                {
                    o.Should().Be(TestString);
                    result = true;
                };
            Action<object> actFail = o =>
            {
                throw new Exception();
            };

            Action<string> act2 = act.Cast<object, string>();

            act2(TestString);

            result.Should().BeTrue();

            // Exceptions are passed.
            actFail.Cast<object, string>().ShouldFail(TestString);
            }

        [TestMethod]
        public void Test_Cast_1()
            {
            bool result = false;
            Action<object, object> act = (o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                result = true;
            };
            Action<object, object> actFail = (o1, o2) =>
            {
                throw new Exception();
            };


            Action<string, string> act2 = act.Cast<object, object, string, string>();

            act2(TestString, TestString);

            result.Should().BeTrue();

            // Exceptions are passed.
            actFail.Cast<object, object, string, string>().ShouldFail(TestString, TestString);
            }
        }
    }
