
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable ConvertToLambdaExpression

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class ExceptionExtTest : ExtensionTester
        {
        private static readonly string TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] { typeof(ExceptionExt) };

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Action_0()
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
        [TestCategory(UnitTests)]
        public void Test_Try_Action_1()
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
        [TestCategory(UnitTests)]
        public void Test_Try_Action_2()
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
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Action_3()
            {
            var a = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });
            var b = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            bool result = a.Try()(TestString, TestString, TestString);
            bool result2 = b.Try()(TestString, TestString, TestString);

            // Result was true
            result.Should().BeTrue();

            // Result was false
            result2.Should().BeFalse();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Action_4()
            {
            var a = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });
            var b = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            bool result = a.Try()(TestString, TestString, TestString, TestString);
            bool result2 = b.Try()(TestString, TestString, TestString, TestString);

            // Result was true
            result.Should().BeTrue();

            // Result was false
            result2.Should().BeFalse();
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Func_0()
            {
            var a = new Func<int>(() => { return 5; });
            var b = new Func<int>(() => { throw new Exception(); });

            // Both actions don't fail.
            int result = a.Try()();
            int result2 = b.Try()();

            // Result was true
            result.Should().Be(5);

            // Result was false
            result2.Should().Be(default(int));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Func_1()
            {
            var a = new Func<string, int>(o =>
            {
                o.Should().Be(TestString);
                return 5;
            });
            var b = new Func<string, int>(o =>
            {
                o.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            int result = a.Try()(TestString);
            int result2 = b.Try()(TestString);

            // Result was true
            result.Should().Be(5);

            // Result was false
            result2.Should().Be(default(int));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Func_2()
            {
            var a = new Func<string, string, int>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return 5;
            });
            var b = new Func<string, string, int>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            int result = a.Try()(TestString, TestString);
            int result2 = b.Try()(TestString, TestString);

            // Result was true
            result.Should().Be(5);

            // Result was false
            result2.Should().Be(default(int));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Func_3()
            {
            var a = new Func<string, string, string, int>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return 5;
            });
            var b = new Func<string, string, string, int>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            int result = a.Try()(TestString, TestString, TestString);
            int result2 = b.Try()(TestString, TestString, TestString);

            // Result was true
            result.Should().Be(5);

            // Result was false
            result2.Should().Be(default(int));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Try_Func_4()
            {
            var a = new Func<string, string, string, string, int>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return 5;
            });
            var b = new Func<string, string, string, string, int>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                throw new Exception();
            });

            // Both actions don't fail.
            int result = a.Try()(TestString, TestString, TestString, TestString);
            int result2 = b.Try()(TestString, TestString, TestString, TestString);

            // Result was true
            result.Should().Be(5);

            // Result was false
            result2.Should().Be(default(int));
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_0()
            {
            int i = 0;
            var test = new Action(() =>
            {
                i++;
                if (i < 5)
                    throw new ArgumentException();
            });

            test.Retry(3).ShouldFail<ArgumentException>();

            // Reset
            i = 0;
            test.Retry(4)();
            i.Should().Be(5);

            L.A(() => test.Retry(0)).ShouldFail();
            L.A(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Action_1()
            {
            int i = 0;
            var test = new Action<string>(o =>
                {
                    o.Should().Be(TestString);

                    i++;
                    if (i < 5)
                        throw new ArgumentException();
                });

            test.Retry(3).ShouldFail<string, ArgumentException>(TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString);
            i.Should().Be(5);

            L.A(() => test.Retry(0)).ShouldFail();
            L.A(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Action_2()
            {
            int i = 0;
            var test = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();
            });

            test.Retry(3).ShouldFail<string, string, ArgumentException>(TestString, TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString, TestString);
            i.Should().Be(5);

            L.A(() => test.Retry(0)).ShouldFail();
            L.A(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Action_3()
            {
            int i = 0;
            var test = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();
            });

            test.Retry(3).ShouldFail<string, string, string, ArgumentException>(TestString, TestString, TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString, TestString, TestString);
            i.Should().Be(5);

            L.A(() => test.Retry(0)).ShouldFail();
            L.A(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Action_4()
            {
            int i = 0;
            var test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();
            });

            test.Retry(3).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString, TestString, TestString, TestString);
            i.Should().Be(5);

            L.A(() => test.Retry(0)).ShouldFail();
            L.A(() => test.Retry(-1)).ShouldFail();
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Func_0()
            {
            int i = 0;
            var test = new Func<string>(() =>
            {
                i++;
                if (i < 5)
                    throw new ArgumentException();

                return TestString;
            });

            test.Retry(3).ShouldFail<string, ArgumentException>();

            // Reset
            i = 0;
            test.Retry(4)().Should().Be(TestString);
            i.Should().Be(5);

            L.F(() => test.Retry(0)).ShouldFail();
            L.F(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Func_1()
            {
            int i = 0;
            var test = new Func<string, string>(o =>
            {
                o.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();

                return TestString;
            });

            test.Retry(3).ShouldFail<string, string, ArgumentException>(TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString);
            i.Should().Be(5);

            L.F(() => test.Retry(0)).ShouldFail();
            L.F(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Func_2()
            {
            int i = 0;
            var test = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();

                return TestString;
            });

            test.Retry(3).ShouldFail<string, string, string, ArgumentException>(TestString, TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString, TestString);
            i.Should().Be(5);

            L.F(() => test.Retry(0)).ShouldFail();
            L.F(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Func_3()
            {
            int i = 0;
            var test = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();

                return TestString;
            });

            test.Retry(3).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString, TestString, TestString);
            i.Should().Be(5);

            L.F(() => test.Retry(0)).ShouldFail();
            L.F(() => test.Retry(-1)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Retry_Func_4()
            {
            int i = 0;
            var test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                i++;
                if (i < 5)
                    throw new ArgumentException();

                return TestString;
            });

            test.Retry(3).ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);

            // Reset
            i = 0;
            test.Retry(4)(TestString, TestString, TestString, TestString);
            i.Should().Be(5);

            L.F(() => test.Retry(0)).ShouldFail();
            L.F(() => test.Retry(-1)).ShouldFail();
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Action_0()
            {
            var test = new Action(() =>
                {
                    throw new ArgumentException();
                });
            var test2 = new Action(() =>
                {
                });
            var handler = new Action<Exception>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw e;
                });

            test.Catch(handler)();
            test2.Catch(handler)();

            test.Catch(Rethrow_Handler).ShouldFail<ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Action_1()
            {
            var test = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                    throw new ArgumentException();
                });
            var test2 = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString);
            test2.Catch(handler)(TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Action_2()
            {
            var test = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString);
            test2.Catch(handler)(TestString, TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Action_3()
            {
            var test = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Action_4()
            {
            var test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString, TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Func_0()
            {
            var test = new Func<string>(() =>
                {
                    throw new ArgumentException();
                });
            var test2 = new Func<string>(() =>
                {
                    return TestString;
                });
            var handler = new Action<Exception>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });
            var Rethrow_Handler = new Action<Exception>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw e;
                });

            test.Catch(handler)();
            test2.Catch(handler)().Should().Be(TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Func_1()
            {
            var test = new Func<string, string>(o =>
            {
                o.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string>(o =>
            {
                o.Should().Be(TestString);
                return TestString;
            });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString);
            test2.Catch(handler)(TestString).Should().Be(TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Func_2()
            {
            var test = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return TestString;
            });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString);
            test2.Catch(handler)(TestString, TestString).Should().Be(TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Func_3()
            {
            var test = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return TestString;
            });
            var Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(Handler)(TestString, TestString, TestString);
            test2.Catch(Handler)(TestString, TestString, TestString).Should().Be(TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_Exception_Func_4()
            {
            var test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return TestString;
            });
            var handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });
            var Rethrow_Handler = new Action<Exception>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString, TestString).Should().Be(TestString);

            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Action_0()
            {
            var test = new Action(() =>
            {
                throw new ArgumentException();
            });
            var test2 = new Action(() =>
            {
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)();
            test2.Catch(handler)();

            test.Catch(Wrong_Handler).ShouldFail<ArgumentException>();
            test.Catch(Rethrow_Handler).ShouldFail<ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Action_1()
            {
            var test = new Action<string>(o =>
                {
                    o.Should().Be(TestString);

                    throw new ArgumentException();
                });
            var test2 = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString);
            test2.Catch(handler)(TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>(TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Action_2()
            {
            var test = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString);
            test2.Catch(handler)(TestString, TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Action_3()
            {
            var test = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Action_4()
            {
            var test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString, TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_0()
            {
            var test = new Func<string>(() =>
                {
                    throw new ArgumentException();
                });
            var test2 = new Func<string>(() =>
                {
                    return TestString;
                });

            var handler = new Action<ArgumentException>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw e;
                });

            test.Catch(handler)();
            test2.Catch(handler)().Should().Be(TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>();
            test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_1()
            {
            var test = new Func<string, string>(o =>
            {
                o.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string>(o =>
            {
                o.Should().Be(TestString);

                return TestString;
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString);
            test2.Catch(handler)(TestString).Should().Be(TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_2()
            {
            var test = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                return TestString;
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString);
            test2.Catch(handler)(TestString, TestString).Should().Be(TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_3()
            {
            var test = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                return TestString;
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString).Should().Be(TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_4()
            {
            var test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                return TestString;
            });

            var handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
            });

            Action<FormatException> Wrong_Handler = L.A<FormatException>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString, TestString);
            test2.Catch(handler)(TestString, TestString, TestString, TestString).Should().Be(TestString);

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_Func_0()
            {
            var test = new Func<string>(() =>
            {
                throw new ArgumentException();
            });
            var test2 = new Func<string>(() =>
            {
                return $"{TestString}a";
            });

            var handler = new Func<ArgumentException, string>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                return $"{TestString}b";
            });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)().Should().Be($"{TestString}b");
            test2.Catch(handler)().Should().Be($"{TestString}a");

            test.Catch(Wrong_Handler).ShouldFail<string, ArgumentException>();
            test.Catch(Rethrow_Handler).ShouldFail<string, ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_Func_1()
            {
            var test = new Func<string, string>(o =>
                 {
                     o.Should().Be(TestString);

                     throw new ArgumentException();
                 });
            var test2 = new Func<string, string>(o =>
                {
                    o.Should().Be(TestString);

                    return $"{TestString}a";
                });

            var handler = new Func<ArgumentException, string>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    return $"{TestString}b";
                });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
                {
                    e.Should().NotBeNull()
                        .And.BeOfType<ArgumentException>();
                    throw e;
                });

            test.Catch(handler)(TestString).Should().Be($"{TestString}b");
            test2.Catch(handler)(TestString).Should().Be($"{TestString}a");

            test.Catch(Wrong_Handler).ShouldFail<string, string, ArgumentException>(TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_Func_2()
            {
            var test = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);

                return $"{TestString}a";
            });

            var handler = new Func<ArgumentException, string>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                return $"{TestString}b";
            });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString).Should().Be($"{TestString}b");
            test2.Catch(handler)(TestString, TestString).Should().Be($"{TestString}a");

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_Func_3()
            {
            var test = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);

                return $"{TestString}a";
            });

            var handler = new Func<ArgumentException, string>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                return $"{TestString}b";
            });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString).Should().Be($"{TestString}b");
            test2.Catch(handler)(TestString, TestString, TestString).Should().Be($"{TestString}a");

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_EType_Func_Func_4()
            {
            var test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);

                return $"{TestString}a";
            });

            var handler = new Func<ArgumentException, string>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                return $"{TestString}b";
            });

            Func<FormatException, string> Wrong_Handler = L.F<FormatException, string>();

            var Rethrow_Handler = new Action<ArgumentException>(e =>
            {
                e.Should().NotBeNull()
                    .And.BeOfType<ArgumentException>();
                throw e;
            });

            test.Catch(handler)(TestString, TestString, TestString, TestString).Should().Be($"{TestString}b");
            test2.Catch(handler)(TestString, TestString, TestString, TestString).Should().Be($"{TestString}a");

            test.Catch(Wrong_Handler).ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            test.Catch(Rethrow_Handler).ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Action_0()
            {
            var test = new Action(() =>
            {
                throw new ArgumentException();
            });
            var test2 = new Action(() =>
            {
            });

            test.Catch<ArgumentException>()();
            test2.Catch<ArgumentException>()();

            test.Catch<FormatException>().ShouldFail<ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Action_1()
            {
            var test = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                    throw new ArgumentException();
                });
            var test2 = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });

            test.Catch<string, ArgumentException>()(TestString);
            test2.Catch<string, ArgumentException>()(TestString);

            test.Catch<string, FormatException>().ShouldFail<string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Action_2()
            {
            var test = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });

            test.Catch<string, string, ArgumentException>()(TestString, TestString);
            test2.Catch<string, string, ArgumentException>()(TestString, TestString);

            test.Catch<string, string, FormatException>().ShouldFail<string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Action_3()
            {
            var test = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });

            test.Catch<string, string, string, ArgumentException>()(TestString, TestString, TestString);
            test2.Catch<string, string, string, ArgumentException>()(TestString, TestString, TestString);

            test.Catch<string, string, string, FormatException>().ShouldFail<string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Action_4()
            {
            var test = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });

            test.Catch<string, string, string, string, ArgumentException>()(TestString, TestString, TestString, TestString);
            test2.Catch<string, string, string, string, ArgumentException>()(TestString, TestString, TestString, TestString);

            test.Catch<string, string, string, string, FormatException>().ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Func_0()
            {
            var test = new Func<string>(() =>
            {
                throw new ArgumentException();
            });
            var test2 = new Func<string>(() =>
            {
                return $"{TestString}a";
            });

            test.Catch<string, ArgumentException>()().Should().Be(default(string));
            test2.Catch<string, ArgumentException>()().Should().Be($"{TestString}a");

            test.Catch<string, FormatException>().ShouldFail<string, ArgumentException>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Func_1()
            {
            var test = new Func<string, string>(o =>
                {
                    o.Should().Be(TestString);
                    throw new ArgumentException();
                });
            var test2 = new Func<string, string>(o =>
                {
                    o.Should().Be(TestString);
                    return $"{TestString}a";
                });

            test.Catch<string, string, ArgumentException>()(TestString).Should().Be(default(string));
            test2.Catch<string, string, ArgumentException>()(TestString).Should().Be($"{TestString}a");

            test.Catch<string, string, FormatException>().ShouldFail<string, string, ArgumentException>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Func_2()
            {
            var test = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return $"{TestString}a";
            });

            test.Catch<string, string, string, ArgumentException>()(TestString, TestString).Should().Be(default(string));
            test2.Catch<string, string, string, ArgumentException>()(TestString, TestString).Should().Be(
                $"{TestString}a");

            test.Catch<string, string, string, FormatException>().ShouldFail<string, string, string, ArgumentException>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Func_3()
            {
            var test = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return $"{TestString}a";
            });

            test.Catch<string, string, string, string, ArgumentException>()(TestString, TestString, TestString).Should().Be(default(string));
            test2.Catch<string, string, string, string, ArgumentException>()(TestString, TestString, TestString).Should().Be($"{TestString}a");

            test.Catch<string, string, string, string, FormatException>().ShouldFail<string, string, string, string, ArgumentException>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Catch_NoArgs_Func_4()
            {
            var test = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                throw new ArgumentException();
            });
            var test2 = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return $"{TestString}a";
            });

            test.Catch<string, string, string, string, string, ArgumentException>()(TestString, TestString, TestString, TestString).Should().Be(default(string));
            test2.Catch<string, string, string, string, string, ArgumentException>()(TestString, TestString, TestString, TestString).Should().Be($"{TestString}a");

            test.Catch<string, string, string, string, string, FormatException>().ShouldFail<string, string, string, string, string, ArgumentException>(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Action()
            {
            var act = new Action(() => { });

            act();
            act.Fail().ShouldFail<Exception>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Action_1()
            {
            var act = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });

            act(TestString);
            act.Fail().ShouldFail<string, Exception>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Action_2()
            {
            var act = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });

            act(TestString, TestString);
            act.Fail().ShouldFail<string, string, Exception>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Action_3()
            {
            var act = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });

            act(TestString, TestString, TestString);
            act.Fail().ShouldFail<string, string, string, Exception>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Action_4()
            {
            var act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });

            act(TestString, TestString, TestString, TestString);
            act.Fail().ShouldFail<string, string, string, string, Exception>(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Func()
            {
            var act = new Func<string>(() =>
                {
                    return TestString;
                });

            act();
            act.Fail().ShouldFail<string, Exception>();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Func_1()
            {
            var act = new Func<string, string>(o =>
            {
                o.Should().Be(TestString);
                return TestString;
            });

            act(TestString);
            act.Fail().ShouldFail<string, string, Exception>(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Func_2()
            {
            var act = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return TestString;
            });

            act(TestString, TestString);
            act.Fail().ShouldFail<string, string, string, Exception>(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Func_3()
            {
            var act = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return TestString;
            });

            act(TestString, TestString, TestString);
            act.Fail().ShouldFail<string, string, string, string, Exception>(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Fail_Func_4()
            {
            var act = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return TestString;
            });

            act(TestString, TestString, TestString, TestString);
            act.Fail().ShouldFail<string, string, string, string, string, Exception>(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Action_0()
            {
            var act = new Action(() =>
                {

                });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act();
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)();

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Action_1()
            {
            var act = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });
            var handler = new Action<ArgumentException>(e =>
                {
                    e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                    e.ParamName.Should().Be($"{TestString}b");
                });
            var handler2 = new Action<Exception>(e =>
                {
                    e.Message.Should().Be($"{TestString}c");
                });

            act(TestString);
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Action_2()
            {
            var act = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString, TestString);
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString, TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Action_3()
            {
            var act = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString, TestString, TestString);
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString, TestString, TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Action_4()
            {
            var act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString, TestString, TestString, TestString);
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString, TestString, TestString, TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Func_0()
            {
            var act = new Func<string>(() =>
                {
                    return $"{TestString}a";
                });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act().Should().Be($"{TestString}a");
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)();

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Func_1()
            {
            var act = new Func<string, string>(o =>
                 {
                     o.Should().Be(TestString);
                     return $"{TestString}a";
                 });
            var handler = new Action<ArgumentException>(e =>
                {
                    e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                    e.ParamName.Should().Be($"{TestString}b");
                });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString).Should().Be($"{TestString}a");
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Func_2()
            {
            var act = new Func<string, string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return $"{TestString}a";
            });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString, TestString).Should().Be($"{TestString}a");
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString, TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Func_3()
            {
            var act = new Func<string, string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return $"{TestString}a";
            });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString, TestString, TestString).Should().Be($"{TestString}a");
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString, TestString, TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Report_Func_4()
            {
            var act = new Func<string, string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return $"{TestString}a";
            });
            var handler = new Action<ArgumentException>(e =>
            {
                e.Message.Should().Be($"{TestString}a\r\nParameter name: {TestString}b");
                e.ParamName.Should().Be($"{TestString}b");
            });
            var handler2 = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}c");
            });

            act(TestString, TestString, TestString, TestString).Should().Be($"{TestString}a");
            act.Report(new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler)(TestString, TestString, TestString, TestString);

            act.Report($"{TestString}c", new ArgumentException($"{TestString}a", $"{TestString}b")).Catch(handler2)(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Throw_0()
            {
            var act = new Action(() =>
                {

                });
            var handler = new Action<Exception>(e =>
                {
                    e.Message.Should().Be($"{TestString}a");
                });

            act();
            act.Throw($"{TestString}a").ShouldFail();
            act.Throw($"{TestString}a").Catch(handler)();

            Func<string> func = act.Return(TestString);

            func().Should().Be(TestString);
            func.Throw($"{TestString}a").ShouldFail();
            func.Throw($"{TestString}a").Catch(handler)();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Throw_1()
            {
            var act = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });
            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}a");
            });

            act(TestString);
            act.Throw($"{TestString}a").ShouldFail(TestString);
            act.Throw($"{TestString}a").Catch(handler)(TestString);

            Func<string, string> func = act.Return(TestString);

            func(TestString).Should().Be(TestString);
            func.Throw($"{TestString}a").ShouldFail(TestString);
            func.Throw($"{TestString}a").Catch(handler)(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Throw_2()
            {
            var act = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });
            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}a");
            });

            act(TestString, TestString);
            act.Throw($"{TestString}a").ShouldFail(TestString, TestString);
            act.Throw($"{TestString}a").Catch(handler)(TestString, TestString);

            Func<string, string, string> func = act.Return(TestString);

            func(TestString, TestString).Should().Be(TestString);
            func.Throw($"{TestString}a").ShouldFail(TestString, TestString);
            func.Throw($"{TestString}a").Catch(handler)(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Throw_3()
            {
            var act = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });
            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}a");
            });

            act(TestString, TestString, TestString);
            act.Throw($"{TestString}a").ShouldFail(TestString, TestString, TestString);
            act.Throw($"{TestString}a").Catch(handler)(TestString, TestString, TestString);

            Func<string, string, string, string> func = act.Return(TestString);

            func(TestString, TestString, TestString).Should().Be(TestString);
            func.Throw($"{TestString}a").ShouldFail(TestString, TestString, TestString);
            func.Throw($"{TestString}a").Catch(handler)(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Throw_4()
            {
            var act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });
            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"{TestString}a");
            });

            act(TestString, TestString, TestString, TestString);
            act.Throw($"{TestString}a").ShouldFail(TestString, TestString, TestString, TestString);
            act.Throw($"{TestString}a").Catch(handler)(TestString, TestString, TestString, TestString);

            Func<string, string, string, string, string> func = act.Return(TestString);

            func(TestString, TestString, TestString, TestString).Should().Be(TestString);
            func.Throw($"{TestString}a").ShouldFail(TestString, TestString, TestString, TestString);
            func.Throw($"{TestString}a").Catch(handler)(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Handle_0()
            {
            lock (this)
                {
                Action<Exception> temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = e =>
                {
                    e.Should().BeOfType<ArgumentException>();
                    e.Message.Should().Be($"{TestString}a");
                };

                var Good_Act = new Action(() =>
                {
                });
                var Bad_Act = new Action(() =>
                {
                    throw new ArgumentException($"{TestString}a");
                });

                Good_Act.Handle()();
                Bad_Act.Handle()();

                Good_Act.Return(TestString).Handle()().Should().Be(TestString);
                Bad_Act.Return(TestString).Handle()().Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = temp;
                }
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Handle_1()
            {
            lock (this)
                {
                Action<Exception> temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = e =>
                    {
                        e.Should().BeOfType<ArgumentException>();
                        e.Message.Should().Be($"{TestString}a");
                    };

                var Good_Act = new Action<string>(o =>
                    {
                        o.Should().Be(TestString);
                    });
                var Bad_Act = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                    throw new ArgumentException($"{TestString}a");
                });

                Good_Act.Handle()(TestString);
                Bad_Act.Handle()(TestString);

                Good_Act.Return(TestString).Handle()(TestString).Should().Be(TestString);
                Bad_Act.Return(TestString).Handle()(TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = temp;
                }
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Handle_2()
            {
            lock (this)
                {
                Action<Exception> temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = e =>
                {
                    e.Should().BeOfType<ArgumentException>();
                    e.Message.Should().Be($"{TestString}a");
                };

                var Good_Act = new Action<string, string>((o1, o2) =>
                {
                    o1.Should().Be(TestString);
                    o2.Should().Be(TestString);
                });
                var Bad_Act = new Action<string, string>((o1, o2) =>
                {
                    o1.Should().Be(TestString);
                    o2.Should().Be(TestString);
                    throw new ArgumentException($"{TestString}a");
                });

                Good_Act.Handle()(TestString, TestString);
                Bad_Act.Handle()(TestString, TestString);

                Good_Act.Return(TestString).Handle()(TestString, TestString).Should().Be(TestString);
                Bad_Act.Return(TestString).Handle()(TestString, TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = temp;
                }
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Handle_3()
            {
            lock (this)
                {
                Action<Exception> temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = e =>
                {
                    e.Should().BeOfType<ArgumentException>();
                    e.Message.Should().Be($"{TestString}a");
                };

                var Good_Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.Should().Be(TestString);
                    o2.Should().Be(TestString);
                    o3.Should().Be(TestString);
                });
                var Bad_Act = new Action<string, string, string>((o1, o2, o3) =>
                {
                    o1.Should().Be(TestString);
                    o2.Should().Be(TestString);
                    o3.Should().Be(TestString);
                    throw new ArgumentException($"{TestString}a");
                });

                Good_Act.Handle()(TestString, TestString, TestString);
                Bad_Act.Handle()(TestString, TestString, TestString);

                Good_Act.Return(TestString).Handle()(TestString, TestString, TestString).Should().Be(TestString);
                Bad_Act.Return(TestString).Handle()(TestString, TestString, TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = temp;
                }
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Handle_4()
            {
            lock (this)
                {
                Action<Exception> temp = L.Exc.DefaultExceptionHandler;

                L.Exc.DefaultExceptionHandler = e =>
                {
                    e.Should().BeOfType<ArgumentException>();
                    e.Message.Should().Be($"{TestString}a");
                };

                var Good_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.Should().Be(TestString);
                    o2.Should().Be(TestString);
                    o3.Should().Be(TestString);
                    o4.Should().Be(TestString);
                });
                var Bad_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
                {
                    o1.Should().Be(TestString);
                    o2.Should().Be(TestString);
                    o3.Should().Be(TestString);
                    o4.Should().Be(TestString);
                    throw new ArgumentException($"{TestString}a");
                });

                Good_Act.Handle()(TestString, TestString, TestString, TestString);
                Bad_Act.Handle()(TestString, TestString, TestString, TestString);

                Good_Act.Return(TestString).Handle()(TestString, TestString, TestString, TestString).Should().Be(TestString);
                Bad_Act.Return(TestString).Handle()(TestString, TestString, TestString, TestString).Should().Be(default(string));

                L.Exc.DefaultExceptionHandler = temp;
                }
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Debug_1()
            {
            var Good_Act = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                });
            var Bad_Act = new Action<string>(o =>
                {
                    o.Should().Be(TestString);
                    throw new ArgumentException($"{TestString}a");
                });

            var handler = new Action<Exception>(e =>
                {
                    e.Message.Should().Be($"System.String:{TestString}");
                });

            Good_Act.Debug()(TestString);
            Good_Act.Debug().Catch(handler)(TestString);

            Bad_Act.Debug().Catch(handler)(TestString);

            Good_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString).Should().Be($"{TestString}a");
            Bad_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString).Should().Be(default(string));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Debug_2()
            {
            var Good_Act = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });
            var Bad_Act = new Action<string, string>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new ArgumentException($"{TestString}a");
            });

            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"System.String:{TestString}, System.String:{TestString}");
            });

            Good_Act.Debug()(TestString, TestString);
            Good_Act.Debug().Catch(handler)(TestString, TestString);

            Bad_Act.Debug().Catch(handler)(TestString, TestString);

            Good_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString, TestString).Should().Be($"{TestString}a");
            Bad_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString, TestString).Should().Be(default(string));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Debug_3()
            {
            var Good_Act = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });
            var Bad_Act = new Action<string, string, string>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new ArgumentException($"{TestString}a");
            });

            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"System.String:{TestString}, System.String:{TestString}, System.String:{TestString}");
            });

            Good_Act.Debug()(TestString, TestString, TestString);
            Good_Act.Debug().Catch(handler)(TestString, TestString, TestString);

            Bad_Act.Debug().Catch(handler)(TestString, TestString, TestString);

            Good_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString, TestString, TestString).Should().Be($"{TestString}a");
            Bad_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString, TestString, TestString).Should().Be(default(string));
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Debug_4()
            {
            var Good_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });
            var Bad_Act = new Action<string, string, string, string>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                throw new ArgumentException($"{TestString}a");
            });

            var handler = new Action<Exception>(e =>
            {
                e.Message.Should().Be($"System.String:{TestString}, System.String:{TestString}, System.String:{TestString}, System.String:{TestString}");
            });

            Good_Act.Debug()(TestString, TestString, TestString, TestString);
            Good_Act.Debug().Catch(handler)(TestString, TestString, TestString, TestString);

            Bad_Act.Debug().Catch(handler)(TestString, TestString, TestString, TestString);

            Good_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString, TestString, TestString, TestString).Should().Be($"{TestString}a");
            Bad_Act.Return($"{TestString}a").Debug().Catch(handler)(TestString, TestString, TestString, TestString).Should().Be(default(string));
            }

        }
    }
