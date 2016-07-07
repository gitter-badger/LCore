
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

namespace L_Tests
    {
    [TestClass]
    public class BooleanExtTest : ExtensionTester
        {
        private static readonly string TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] { typeof(BooleanExt) };

        [TestMethod]
        public void Test_Not_0()
            {
            // True works 
            Func<bool> f = L.Bool.True;
            f.Not()().Should().BeFalse();

            // False works
            Func<bool> f2 = () => false;
            f2.Not()().Should().BeTrue();

            // Exceptions are not hidden
            Func<bool> f3 = () => { throw new Exception(); };
            f3.Not().ShouldFail();
            }
        [TestMethod]
        public void Test_Not_1()
            {
            // True works 
            Func<object, bool> f = o =>
                {
                    // Variables are passed.
                    o.Should().BeSameAs(TestString);
                    return true;
                };
            f.Not()(TestString).Should().BeFalse();

            // False works
            Func<object, bool> f2 = o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            };
            f2.Not()(TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, bool> f3 = o => { throw new Exception(); };
            f3.Not().ShouldFail(null);
            }
        [TestMethod]
        public void Test_Not_2()
            {
            // True works 
            Func<object, object, bool> f = (o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            };
            f.Not()(TestString, TestString).Should().BeFalse();

            // False works
            Func<object, object, bool> f2 = (o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            };
            f2.Not()(TestString, TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, object, bool> f3 = (o1, o2) => { throw new Exception(); };
            f3.Not().ShouldFail(null, null);
            }
        [TestMethod]
        public void Test_Not_3()
            {
            // True works 
            Func<object, object, object, bool> f = (o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            };
            f.Not()(TestString, TestString, TestString).Should().BeFalse();

            // False works
            Func<object, object, object, bool> f2 = (o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            };
            f2.Not()(TestString, TestString, TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, object, object, bool> f3 = (o1, o2, o3) => { throw new Exception(); };
            f3.Not().ShouldFail(null, null, null);
            }
        [TestMethod]
        public void Test_Not_4()
            {
            // True works 
            Func<object, object, object, object, bool> f = (o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            };
            f.Not()(TestString, TestString, TestString, TestString).Should().BeFalse();

            // False works
            Func<object, object, object, object, bool> f2 = (o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            };
            f2.Not()(TestString, TestString, TestString, TestString).Should().Be(true);

            // Exceptions are not hidden
            Func<object, object, object, object, bool> f3 = (o1, o2, o3, o4) => { throw new Exception(); };
            f3.Not().ShouldFail(null, null, null, null);
            }

        [TestMethod]
        public void Test_If_Action_0()
            {
            // False works
            bool result = true;
            var act = new Action(() => { result = false; });

            act.If(L.Bool.False)();
            result.Should().BeTrue();

            act.If(L.Bool.True)();
            result.Should().BeFalse();

            // true works
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(L.Bool.True)();
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.If(L.Bool.True).ShouldFail();
            }
        [TestMethod]
        public void Test_If_Action_1()
            {
            var condition = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            });
            // False works
            bool result = false;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString);
            result.Should().BeFalse();

            act.If(condition.Not())(TestString);
            result.Should().BeTrue();

            // true works
            var condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString);
            }
        [TestMethod]
        public void Test_If_Action_2()
            {
            var condition = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            });
            // False works
            bool result = false;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString, TestString);
            result.Should().BeFalse();

            act.If(condition.Not())(TestString, TestString);
            result.Should().BeTrue();

            // true works
            var condition2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Action_3()
            {
            var condition = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            });
            // False works
            bool result = false;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString, TestString, TestString);
            result.Should().BeFalse();

            act.If(condition.Not())(TestString, TestString, TestString);
            result.Should().BeTrue();

            // true works
            var condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString, TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Action_4()
            {
            var condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            });
            // False works
            bool result = false;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString, TestString, TestString, TestString);
            result.Should().BeFalse();

            act.If(condition.Not())(TestString, TestString, TestString, TestString);
            result.Should().BeTrue();

            // true works
            var condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString, TestString, TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        public void Test_If_Func_0()
            {
            // False works
            bool result = true;
            var act = new Func<string>(() =>
                {
                    result = false;
                    return TestString;
                });

            string result2 = act.If(L.Bool.False)();
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(L.Bool.True)();
            result2.Should().Be(TestString);

            // true works
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(L.Bool.True)();
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(L.Bool.True).ShouldFail();
            }
        [TestMethod]
        public void Test_If_Func_1()
            {
            // False works
            var condition = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() =>
            {
                result = false;
                return TestString;
            });

            string result2 = act.If(condition)(TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(condition.Not())(TestString);
            result2.Should().Be(TestString);

            // true works
            var condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString);
            }
        [TestMethod]
        public void Test_If_Func_2()
            {
            // False works
            var condition = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(condition)(TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(condition.Not())(TestString, TestString);
            result2.Should().Be(TestString);

            // true works
            var condition2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Func_3()
            {
            // False works
            var condition = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(condition)(TestString, TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(condition.Not())(TestString, TestString, TestString);
            result2.Should().Be(TestString);

            // true works
            var condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Func_4()
            {
            // False works
            var condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() =>
            {
                result = false;
                return TestString;
            });

            string result2 = act.If(condition)(TestString, TestString, TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(condition.Not())(TestString, TestString, TestString, TestString);
            result2.Should().Be(TestString);

            // true works
            var condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString, TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(condition2).ShouldFail(TestString, TestString, TestString, TestString);
            }

        [TestMethod]
        public void Test_If_Action_Multiple_0()
            {
            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
                {
                    result = false;
                    throw new Exception();
                });

            string result2 = act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();
            act.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }
        [TestMethod]
        public void Test_If_Action_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);
                return true;
            });

            var False = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() =>
            {
                result = false;
                throw new Exception();
            });

            bool result2 = act.If(True, True, False)(TestString);
            result.Should().BeTrue();
            act.If(True, True, True).ShouldFail(TestString);

            // Result works
            result2.Should().BeFalse();

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString);
            result3.Should().BeTrue();

            // Result works
            result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString);
            }
        [TestMethod]
        public void Test_If_Action_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            });

            var False = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() =>
            {
                result = false;
                throw new Exception();
            });

            bool result2 = act.If(True, True, False)(TestString, TestString);
            result.Should().BeTrue();
            act.If(True, True, True).ShouldFail(TestString, TestString);

            // Result works
            result2.Should().BeFalse();

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString, TestString);
            result3.Should().BeTrue();

            // Result works
            result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Action_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() =>
            {
                result = false;
                throw new Exception();
            });

            bool result2 = act.If(True, True, False)(TestString, TestString, TestString);
            result.Should().BeTrue();
            act.If(True, True, True).ShouldFail(TestString, TestString, TestString);

            // Result works
            result2.Should().BeFalse();

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result works
            result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Action_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() =>
                {
                    result = false;
                    throw new Exception();
                });

            bool result2 = act.If(True, True, False)(TestString, TestString, TestString, TestString);
            result.Should().BeTrue();
            act.If(True, True, True).ShouldFail(TestString, TestString, TestString, TestString);

            // Result works
            result2.Should().BeFalse();

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString, TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result works
            result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        public void Test_If_Func_Multiple_0()
            {
            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
            {
                result = false;
                return TestString;
            });

            string result2 = act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }
        [TestMethod]
        public void Test_If_Func_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);
                return true;
            });

            var False = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
            {
                result = false;
                return TestString;
            });

            string result2 = act.If(True, True, False)(TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(True, True, True)(TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString);
            }
        [TestMethod]
        public void Test_If_Func_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            });

            var False = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
            {
                result = false;
                return TestString;
            });

            string result2 = act.If(True, True, False)(TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(True, True, True)(TestString, TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Func_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
                {
                    result = false;
                    return TestString;
                });

            string result2 = act.If(True, True, False)(TestString, TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(True, True, True)(TestString, TestString, TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        public void Test_If_Func_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
                {
                    result = false;
                    return TestString;
                });

            string result2 = act.If(True, True, False)(TestString, TestString, TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.If(True, True, True)(TestString, TestString, TestString, TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString, TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(True, True, True).ShouldFail(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        public void Test_Else_If_0()
            {
            var False = new Func<bool>(() => false);
            var True = new Func<bool>(() => true);

            bool ActionRun = false;

            var actionMustNotRun = new Action(() =>
                {
                    throw new Exception();
                });
            var actionMustNotRun2 = new Func<bool>(() =>
                {
                    throw new Exception();
                });

            var actionMustRun = new Action(() => { ActionRun = true; });
            var actionMustRun2 = new Func<bool>(() => { ActionRun = true; return false; });

            // Action did not run.
            True.ElseIf(actionMustNotRun2, actionMustNotRun)();

            False.ElseIf(True, actionMustNotRun).ShouldFail();
            False.ElseIf(actionMustNotRun2, True).ShouldFail();

            // Action did run.
            False.ElseIf(True, actionMustRun)();
            ActionRun.Should().BeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun2, L.E)();
            ActionRun.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_1()
            {
            var False = new Func<object, bool>(o => false);
            var True = new Func<object, bool>(o => true);

            bool ActionRun = false;

            var actionMustNotRun = new Action<object>(o =>
                {
                    throw new Exception();
                });
            var actionMustNotRun2 = new Func<object, bool>(o =>
            {
                throw new Exception();
            });

            var actionMustRun = new Action<object>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);

                ActionRun = true;
            });
            var actionMustRun2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun2, actionMustNotRun)(TestString);

            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString);
            False.ElseIf(actionMustNotRun2, True).ShouldFail(TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString);
            ActionRun.Should().BeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun2, actionMustRun)(TestString);
            ActionRun.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_2()
            {
            var False = new Func<object, object, bool>((o1, o2) => false);
            var True = new Func<object, object, bool>((o1, o2) => true);

            bool ActionRun = false;

            var actionMustNotRun = new Action<object, object>((o1, o2) =>
            {
                throw new Exception();
            });
            var actionMustNotRun2 = new Func<object, object, bool>((o1, o2) =>
            {
                throw new Exception();
            });

            var actionMustRun = new Action<object, object>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);

                ActionRun = true;
            });
            var actionMustRun2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun2, actionMustNotRun)(TestString, TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString, TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString, TestString);
            False.ElseIf(actionMustNotRun2, True).ShouldFail(TestString, TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun2, actionMustRun)(TestString, TestString);
            ActionRun.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_3()
            {
            var False = new Func<object, object, object, bool>((o1, o2, o3) => false);
            var True = new Func<object, object, object, bool>((o1, o2, o3) => true);

            bool ActionRun = false;

            var actionMustNotRun = new Action<object, object, object>((o1, o2, o3) =>
            {
                throw new Exception();
            });
            var actionMustNotRun2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                throw new Exception();
            });

            var actionMustRun = new Action<object, object, object>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);

                ActionRun = true;
            });
            var actionMustRun2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun2, actionMustNotRun)(TestString, TestString, TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString, TestString, TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString, TestString, TestString);
            False.ElseIf(actionMustNotRun2, True).ShouldFail(TestString, TestString, TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun2, actionMustRun)(TestString, TestString, TestString);
            ActionRun.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_4()
            {
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => false);
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => true);

            bool ActionRun = false;

            var actionMustNotRun = new Action<object, object, object, object>((o1, o2, o3, o4) =>
            {
                throw new Exception();
            });
            var actionMustNotRun2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                throw new Exception();
            });

            var actionMustRun = new Action<object, object, object, object>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);

                ActionRun = true;
            });
            var actionMustRun2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun2, actionMustNotRun)(TestString, TestString, TestString, TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString, TestString, TestString, TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString, TestString, TestString, TestString);
            False.ElseIf(actionMustNotRun2, True).ShouldFail(TestString, TestString, TestString, TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun2, actionMustRun)(TestString, TestString, TestString, TestString);
            ActionRun.Should().BeTrue();
            }



        [TestMethod]
        public void Test_Else_If_Func_0()
            {
            var False = new Func<bool>(() => false);
            var True = new Func<bool>(() => true);

            bool ActionRun = false;

            var actionMustNotRun = new Func<bool>(() =>
            {
                throw new Exception();
            });

            var actionMustRun = new Func<bool>(() => { ActionRun = true; return false; });

            // Action did not run.
            True.ElseIf(actionMustNotRun, actionMustNotRun)();

            False.ElseIf(actionMustNotRun, True).ShouldFail();
            False.ElseIf(True, actionMustNotRun).ShouldFail();

            // Action did run.
            False.ElseIf(True, actionMustRun)();
            ActionRun.Should().BeTrue();

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun, L.Bool.True)();
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool result = False.ElseIf(True, True)();
            result.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_Func_1()
            {
            var False = new Func<object, bool>(o => false);
            var True = new Func<object, bool>(o => true);

            bool ActionRun = false;

            var actionMustNotRun = new Func<object, bool>(o =>
            {
                throw new Exception();
            });

            var actionMustRun = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().Be(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun, actionMustNotRun)(TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(actionMustNotRun, True).ShouldFail(TestString);
            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun, actionMustRun)(TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool result = False.ElseIf(True, True)(TestString);
            result.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_Func_2()
            {
            var False = new Func<object, object, bool>((o1, o2) => false);
            var True = new Func<object, object, bool>((o1, o2) => true);

            bool ActionRun = false;

            var actionMustNotRun = new Func<object, object, bool>((o1, o2) =>
            {
                throw new Exception();
            });

            var actionMustRun = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun, actionMustNotRun)(TestString, TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString, TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(actionMustNotRun, True).ShouldFail(TestString, TestString);
            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString, TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun, actionMustRun)(TestString, TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool result = False.ElseIf(True, True)(TestString, TestString);
            result.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_Func_3()
            {
            var False = new Func<object, object, object, bool>((o1, o2, o3) => false);
            var True = new Func<object, object, object, bool>((o1, o2, o3) => true);

            bool ActionRun = false;

            var actionMustNotRun = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                throw new Exception();
            });

            var actionMustRun = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun, actionMustNotRun)(TestString, TestString, TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString, TestString, TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(actionMustNotRun, True).ShouldFail(TestString, TestString, TestString);
            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString, TestString, TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun, actionMustRun)(TestString, TestString, TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool result = False.ElseIf(True, True)(TestString, TestString, TestString);
            result.Should().BeTrue();
            }
        [TestMethod]
        public void Test_Else_If_Func_4()
            {
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => false);
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) => true);

            bool ActionRun = false;

            var actionMustNotRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                throw new Exception();
            });

            var actionMustRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);

                ActionRun = true;
                return false;
            });

            // Action did not run.
            True.ElseIf(actionMustNotRun, actionMustNotRun)(TestString, TestString, TestString, TestString);

            // Action did run.
            False.ElseIf(True, actionMustRun)(TestString, TestString, TestString, TestString);
            ActionRun.Should().BeTrue();

            False.ElseIf(actionMustNotRun, True).ShouldFail(TestString, TestString, TestString, TestString);
            False.ElseIf(True, actionMustNotRun).ShouldFail(TestString, TestString, TestString, TestString);

            ActionRun = false;

            // Action did run.
            False.ElseIf(actionMustRun, actionMustRun)(TestString, TestString, TestString, TestString);
            ActionRun.Should().BeTrue();

            // Result was passed.
            bool result = False.ElseIf(True, True)(TestString, TestString, TestString, TestString);
            result.Should().BeTrue();
            }


        [TestMethod]
        public void Test_Unless_Action_0()
            {
            // False works
            bool result = true;
            var act = new Action(() =>
            {
                result = false;
                throw new Exception();
            });

            act.Unless(L.Bool.True)();
            result.Should().BeTrue();
            L.A(() => act.Unless(L.Bool.False)()).ShouldFail();

            // true works
            bool result2 = false;
            var act2 = new Action(() =>
                {
                    result2 = true;
                });

            act2.Unless(L.Bool.False)();
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(L.Bool.False).ShouldFail();
            }
        [TestMethod]
        public void Test_Unless_Action_1()
            {
            var condition = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return true;
            });
            // False works
            bool result = false;
            var act = new Action(() =>
                {
                    result = true;
                    throw new Exception();
                });

            act.Unless(condition)(TestString);
            result.Should().BeFalse();
            L.A(() => act.Unless(L.Bool.False)()).ShouldFail();

            // true works
            var condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.Unless(condition2)(TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2).ShouldFail(TestString);
            }
        [TestMethod]
        public void Test_Unless_Action_2()
            {
            var condition = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            });
            // False works
            bool result = false;
            var act = new Action(() =>
            {
                result = true;
                throw new Exception();
            });

            act.Unless(condition)(TestString, TestString);
            result.Should().BeFalse();
            act.Unless(condition.Not()).ShouldFail(TestString, TestString);

            // true works
            var condition2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.Unless(condition2)(TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        public void Test_Unless_Action_3()
            {
            var condition = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            });
            // False works
            bool result = false;
            var act = new Action(() =>
                {
                    result = true;
                    throw new Exception();
                });

            act.Unless(condition)(TestString, TestString, TestString);
            result.Should().BeFalse();
            act.Unless(condition.Not()).ShouldFail(TestString, TestString, TestString);

            // true works
            var condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.Unless(condition2)(TestString, TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        public void Test_Unless_Action_4()
            {
            var condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            });
            // False works
            bool result = false;
            var act = new Action(() =>
            {
                result = true;
                throw new Exception();
            });

            act.Unless(condition)(TestString, TestString, TestString, TestString);
            result.Should().BeFalse();
            act.Unless(condition.Not()).ShouldFail(TestString, TestString, TestString, TestString);

            // true works
            var condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.Unless(condition2)(TestString, TestString, TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2).ShouldFail(TestString, TestString, TestString, TestString);
            }
        }
    }

