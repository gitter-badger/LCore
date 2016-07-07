
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace L_Tests
    {
    [TestClass]
    public class ExceptionExtTest : ExtensionTester
        {
        private static readonly string TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] { typeof(ExceptionExt) };

        [TestMethod]
        public void Test_Try_0()
            {
            var a = new Action(() => { });
            var b = new Action(() => { throw new Exception(); });

            // Both actions don't fail.
            bool result = a.Try()();
            bool result2 = b.Try()();

            // Result was true
            result.Should().BeTrue();

            // Result was false
            result2.Should().BeFalse();
            }

        [TestMethod]
        public void Test_Try_1()
            {
            var a = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });
            var b = new Action<string>(o =>
                {
                    o.Should().Be(TestString);

                    throw new Exception();
                });

            // Both actions don't fail.
            bool result = a.Try()(TestString);
            bool result2 = b.Try()(TestString);

            // Result was true
            result.Should().BeTrue();

            // Result was false
            result2.Should().BeFalse();
            }

        [TestMethod]
        public void Test_Try_2()
            {
            var a = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });
            var b = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            bool result = a.Try()(TestString, TestString);
            bool result2 = b.Try()(TestString, TestString);

            // Result was true
            result.Should().BeTrue();

            // Result was false
            result2.Should().BeFalse();
            }
        }
    }
