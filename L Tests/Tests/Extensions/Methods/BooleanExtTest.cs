
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class BooleanExtTest : ExtensionTester
        {
        private static readonly string TestString = Guid.NewGuid().ToString();

        protected override Type[] TestType => new[] { typeof(BooleanExt) };

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Not_0()
            {
            // True works 
            Func<bool> Func = L.Bool.True;
            Func.Not()().Should().BeFalse();

            // False works
            Func<bool> Func2 = () => false;
            Func2.Not()().Should().BeTrue();

            // Exceptions are not hidden
            Func<bool> Func3 = () => { throw new Exception(); };
            Func3.Not().ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Not_1()
            {
            // True works 
            Func<object, bool> Func = o =>
                {
                    // Variables are passed.
                    o.Should().BeSameAs(TestString);
                    return true;
                };
            Func.Not()(TestString).Should().BeFalse();

            // False works
            Func<object, bool> Func2 = o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            };
            Func2.Not()(TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, bool> Func3 = o => { throw new Exception(); };
            Func3.Not().ShouldFail(null);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Not_2()
            {
            // True works 
            Func<object, object, bool> Func = (o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            };
            Func.Not()(TestString, TestString).Should().BeFalse();

            // False works
            Func<object, object, bool> Func2 = (o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            };
            Func2.Not()(TestString, TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, object, bool> Func3 = (o1, o2) => { throw new Exception(); };
            Func3.Not().ShouldFail(null, null);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Not_3()
            {
            // True works 
            Func<object, object, object, bool> Func = (o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return true;
            };
            Func.Not()(TestString, TestString, TestString).Should().BeFalse();

            // False works
            Func<object, object, object, bool> Func2 = (o1, o2, o3) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                return false;
            };
            Func2.Not()(TestString, TestString, TestString).Should().BeTrue();

            // Exceptions are not hidden
            Func<object, object, object, bool> Func3 = (o1, o2, o3) => { throw new Exception(); };
            Func3.Not().ShouldFail(null, null, null);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Not_4()
            {
            // True works 
            Func<object, object, object, object, bool> Func = (o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return true;
            };
            Func.Not()(TestString, TestString, TestString, TestString).Should().BeFalse();

            // False works
            Func<object, object, object, object, bool> Func2 = (o1, o2, o3, o4) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                o3.Should().BeSameAs(TestString);
                o4.Should().BeSameAs(TestString);
                return false;
            };
            Func2.Not()(TestString, TestString, TestString, TestString).Should().Be(true);

            // Exceptions are not hidden
            Func<object, object, object, object, bool> Func3 = (o1, o2, o3, o4) => { throw new Exception(); };
            Func3.Not().ShouldFail(null, null, null, null);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_If_Action_0()
            {
            // False works
            bool Result = true;
            var Action = new Action(() => { Result = false; });

            Action.If(L.Bool.False)();
            Result.Should().BeTrue();

            Action.If(L.Bool.True)();
            Result.Should().BeFalse();

            // true works
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(L.Bool.True)();
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Action3 = () => { throw new Exception(); };
            Action3.If(L.Bool.True).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_If_Action_1()
            {
            var Condition = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            });
            // False works
            bool Result = false;
            var Action = new Action(() => { Result = true; });

            Action.If(Condition)(TestString);
            Result.Should().BeFalse();

            Action.If(Condition.Not())(TestString);
            Result.Should().BeTrue();

            // true works
            var Condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return true;
            });
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(Condition2)(TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action Action3 = () => { throw new Exception(); };
            Action3.If(Condition2).ShouldFail(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_If_Action_2()
            {
            var Condition = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return false;
            });
            // False works
            bool Result = false;
            var Action = new Action(() => { Result = true; });

            Action.If(Condition)(TestString, TestString);
            Result.Should().BeFalse();

            Action.If(Condition.Not())(TestString, TestString);
            Result.Should().BeTrue();

            // true works
            var Condition2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                o1.Should().BeSameAs(TestString);
                o2.Should().BeSameAs(TestString);
                return true;
            });
            bool Result2 = false;
            var Action2 = new Action(() => { Result2 = true; });

            Action2.If(Condition2)(TestString, TestString);
            Result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.If(Condition2).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
        public void Test_If_Action_Multiple_0()
            {
            // False works - AND is applied
            bool result = true;
            var act = new Action(() =>
                {
                    result = false;
                    throw new Exception();
                });

            bool result2 = act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeFalse();
            act.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().BeTrue();

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.If(L.Bool.True, L.Bool.True, L.Bool.True).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
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
        [TestCategory(UnitTests)]
        public void Test_Unless_Action_0()
            {
            // False works
            bool result = true;
            var act = new Action(() =>
            {
                result = false;
                throw new Exception();
            });

            act.Unless(L.Bool.True, L.Bool.False)();
            result.Should().BeTrue();
            L.A(() => act.Unless(L.Bool.False)()).ShouldFail();

            // true works
            bool result2 = false;
            var act2 = new Action(() =>
                {
                    result2 = true;
                });

            act2.Unless(L.Bool.False, L.Bool.False)();
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(L.Bool.False, L.Bool.False).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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

            act.Unless(condition, condition.Not())(TestString);
            result.Should().BeFalse();
            L.A(() => act.Unless(L.Bool.False, L.Bool.False)()).ShouldFail();

            // true works
            var condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                o.Should().BeSameAs(TestString);
                return false;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.Unless(condition2, condition2)(TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2, condition2).ShouldFail(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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

            act.Unless(condition, condition.Not())(TestString, TestString);
            result.Should().BeFalse();
            act.Unless(condition.Not(), condition.Not()).ShouldFail(TestString, TestString);

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

            act2.Unless(condition2, condition2)(TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2, condition2).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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

            act.Unless(condition, condition.Not())(TestString, TestString, TestString);
            result.Should().BeFalse();
            act.Unless(condition.Not(), condition.Not()).ShouldFail(TestString, TestString, TestString);

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

            act2.Unless(condition2, condition2)(TestString, TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2, condition2).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
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

            act.Unless(condition, condition.Not())(TestString, TestString, TestString, TestString);
            result.Should().BeFalse();
            act.Unless(condition.Not(), condition.Not()).ShouldFail(TestString, TestString, TestString, TestString);

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

            act2.Unless(condition2, condition2)(TestString, TestString, TestString, TestString);
            result2.Should().BeTrue();

            // Exceptions are not hidden
            Action act3 = () => { throw new Exception(); };
            act3.Unless(condition2, condition2).ShouldFail(TestString, TestString, TestString, TestString);
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Or_0()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);

            new[] { False, False, False, False }.Or()().Should().BeFalse();
            new[] { False, False, False, True }.Or()().Should().BeTrue();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Or_1()
            {
            var True = new Func<object, bool>(o =>
                {
                    o.Should().Be(TestString);
                    return true;
                });
            var False = new Func<object, bool>(o =>
                {
                    o.Should().Be(TestString);
                    return false;
                });
            var NotRun = new Func<object, bool>(o =>
            {
                o.Should().Be(TestString);
                throw new Exception();
            });

            new[] { False, False, False, False }.Or()(TestString).Should().BeFalse();
            new[] { False, False, False, True }.Or()(TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] { False, False, True, NotRun }.Or()(TestString).Should().BeTrue();
            L.A(() => new[] { False, False, False, NotRun }.Or()(TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Or_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, object, bool>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return false;
            });
            var NotRun = new Func<object, object, bool>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new Exception();
            });

            new[] { False, False, False, False }.Or()(TestString, TestString).Should().BeFalse();
            new[] { False, False, False, True }.Or()(TestString, TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] { False, False, True, NotRun }.Or()(TestString, TestString).Should().BeTrue();
            L.A(() => new[] { False, False, False, NotRun }.Or()(TestString, TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Or_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return false;
            });
            var NotRun = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new Exception();
            });

            new[] { False, False, False, False }.Or()(TestString, TestString, TestString).Should().BeFalse();
            new[] { False, False, False, True }.Or()(TestString, TestString, TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] { False, False, True, NotRun }.Or()(TestString, TestString, TestString).Should().BeTrue();
            L.A(() => new[] { False, False, False, NotRun }.Or()(TestString, TestString, TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Or_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return false;
            });
            var NotRun = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                throw new Exception();
            });

            new[] { False, False, False, False }.Or()(TestString, TestString, TestString, TestString).Should().BeFalse();
            new[] { False, False, False, True }.Or()(TestString, TestString, TestString, TestString).Should().BeTrue();

            // True blocks execution of later items
            new[] { False, False, True, NotRun }.Or()(TestString, TestString, TestString, TestString).Should().BeTrue();
            L.A(() => new[] { False, False, False, NotRun }.Or()(TestString, TestString, TestString, TestString)).ShouldFail();
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_0()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Act = new Action(() => { });
            var DontExecute = new Action(() => { throw new Exception(); });

            Act.If(True).ElseIf(True, DontExecute).Else(DontExecute)();

            DontExecute.If(False).ElseIf(False, DontExecute).Else(Act)();

            L.A(() => Act.If(False).ElseIf(False, DontExecute).Else(DontExecute)()).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_1()
            {
            var True = new Func<object, bool>(o =>
            {
                o.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, bool>(o =>
            {
                o.Should().Be(TestString);
                return false;
            });
            var Act = new Action<object>(o =>
            {
                o.Should().Be(TestString);
            });
            var DontExecute = new Action<object>(o =>
            {
                o.Should().Be(TestString);
                throw new Exception();
            });

            True.Else(DontExecute)(TestString);

            False.Else(Act)(TestString);

            L.A(() => False.Else(DontExecute)(TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, object, bool>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return false;
            });
            var Act = new Action<object, object>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
            });
            var DontExecute = new Action<object, object>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new Exception();
            });

            True.Else(DontExecute)(TestString, TestString);

            False.Else(Act)(TestString, TestString);

            L.A(() => False.Else(DontExecute)(TestString, TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return false;
            });
            var Act = new Action<object, object, object>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
            });
            var DontExecute = new Action<object, object, object>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new Exception();
            });

            True.Else(DontExecute)(TestString, TestString, TestString);

            False.Else(Act)(TestString, TestString, TestString);

            L.A(() => False.Else(DontExecute)(TestString, TestString, TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return true;
            });
            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                return false;
            });
            var Act = new Action<object, object, object, object>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
            });
            var DontExecute = new Action<object, object, object, object>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                o4.Should().Be(TestString);
                throw new Exception();
            });

            True.Else(DontExecute)(TestString, TestString, TestString, TestString);

            False.Else(Act)(TestString, TestString, TestString, TestString);

            L.A(() => False.Else(DontExecute)(TestString, TestString, TestString, TestString)).ShouldFail();
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_U_0()
            {
            var True = new Func<bool>(() => true);
            var False = new Func<bool>(() => false);
            var Act = new Func<int>(() => 5);
            var DontExecute = new Func<int>(() => { throw new Exception(); });
            int Result = 10;


            Act.If(True).ElseIf(True, DontExecute).Else(Result)().Should().Be(5);
            Act.If(False).ElseIf(False, DontExecute).Else(Result)().Should().Be(10);

            DontExecute.If(False).ElseIf(False, DontExecute).Else(Result)().Should().Be(10);

            L.A(() => Act.If(False).ElseIf(True, DontExecute).Else(Result)()).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_U_1()
            {
            var True = new Func<object, int>(o =>
                {
                    o.Should().Be(TestString);
                    return 1;
                });
            var False = new Func<object, int>(o =>
                {
                    o.Should().Be(TestString);
                    return default(int);
                });
            var DontExecute = new Func<object, int>(o =>
                {
                    o.Should().Be(TestString);
                    throw new Exception();
                });

            int Result = 10;

            True.Else(DontExecute)(TestString).Should().Be(1);
            False.Else(Result)(TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_U_2()
            {
            var True = new Func<object, object, int>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return 1;
            });
            var False = new Func<object, object, int>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                return default(int);
            });
            var DontExecute = new Func<object, object, int>((o1, o2) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                throw new Exception();
            });

            int Result = 10;

            True.Else(DontExecute)(TestString, TestString).Should().Be(1);
            False.Else(Result)(TestString, TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(TestString, TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_U_3()
            {
            var True = new Func<object, object, object, int>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return 1;
            });
            var False = new Func<object, object, object, int>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return default(int);
            });
            var DontExecute = new Func<object, object, object, int>((o1, o2, o3) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new Exception();
            });

            int Result = 10;

            True.Else(DontExecute)(TestString, TestString, TestString).Should().Be(1);
            False.Else(Result)(TestString, TestString, TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(TestString, TestString, TestString)).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Else_U_4()
            {
            var True = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return 1;
            });
            var False = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                return default(int);
            });
            var DontExecute = new Func<object, object, object, object, int>((o1, o2, o3, o4) =>
            {
                o1.Should().Be(TestString);
                o2.Should().Be(TestString);
                o3.Should().Be(TestString);
                throw new Exception();
            });

            int Result = 10;

            True.Else(DontExecute)(TestString, TestString, TestString, TestString).Should().Be(1);
            False.Else(Result)(TestString, TestString, TestString, TestString).Should().Be(10);

            L.A(() => False.Else(DontExecute)(TestString, TestString, TestString, TestString)).ShouldFail();
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Unless_Func_Multiple_0()
            {
            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() =>
            {
                result = false;
                return TestString;
            });

            string result2 = act.Unless(L.Bool.True, L.Bool.False, L.Bool.False)();
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.Unless(L.Bool.False, L.Bool.False, L.Bool.False)();
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.Unless(L.Bool.False, L.Bool.False, L.Bool.False)();
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.Unless(L.Bool.False, L.Bool.False, L.Bool.False).ShouldFail();
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Unless_Func_Multiple_1()
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

            string result2 = act.Unless(True, False, False)(TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.Unless(False, False, False)(TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.Unless(False, False, False)(TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.Unless(False, False, False).ShouldFail(TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Unless_Func_Multiple_2()
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

            string result2 = act.Unless(True, False, False)(TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.Unless(False, False, False)(TestString, TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.Unless(False, False, False)(TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.Unless(False, False, False).ShouldFail(TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Unless_Func_Multiple_3()
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

            string result2 = act.Unless(True, False, False)(TestString, TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.Unless(False, False, False)(TestString, TestString, TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.Unless(False, False, False)(TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> act3 = () => { throw new Exception(); };
            act3.Unless(False, False, False).ShouldFail(TestString, TestString, TestString);
            }
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_Unless_Func_Multiple_4()
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

            string result2 = act.Unless(True, False, False)(TestString, TestString, TestString, TestString);
            result.Should().BeTrue();

            // Result does not pass through
            result2.Should().BeNull();

            result2 = act.Unless(False, False, False)(TestString, TestString, TestString, TestString);
            result2.Should().Be(TestString);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string Result4 = act2.Unless(False, False, False)(TestString, TestString, TestString, TestString);
            result3.Should().BeTrue();

            // Result passes through
            Result4.Should().Be(TestString);

            // Exceptions are not hidden
            Func<string> Action3 = () => { throw new Exception(); };
            Action3.Unless(False, False, False).ShouldFail(TestString, TestString, TestString, TestString);
            }
        }
    }

