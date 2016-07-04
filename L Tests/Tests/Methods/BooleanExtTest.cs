
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local

namespace L_Tests
    {
    [TestClass]
    public class BooleanExtTest : ExtensionTester
        {
        private const string HiddenException = "Inner exception was hidden";
        private const string TestString = "AC51F0CE-2DC6-4587-9407-2E4D586A5F8F";

        protected override Type TestType => typeof(BooleanExt);

        [TestMethod]
        public void Test_Not_0()
            {
            // True works 
            Func<bool> f = L.Bool.True;
            Assert.AreEqual(f.Not()(), false);

            // False works
            Func<bool> f2 = () => false;
            Assert.AreEqual(f2.Not()(), true);

            // Exceptions are not hidden
            try
                {
                Func<bool> f3 = () => { throw new Exception(); };
                f3.Not()();
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_Not_1()
            {
            // True works 
            Func<object, bool> f = o =>
                {
                    // Variables are passed.
                    Assert.AreEqual(o, TestString);
                    return true;
                };
            Assert.AreEqual(f.Not()(TestString), false);

            // False works
            Func<object, bool> f2 = o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return false;
            };
            Assert.AreEqual(f2.Not()(TestString), true);

            // Exceptions are not hidden
            try
                {
                Func<object, bool> f3 = o => { throw new Exception(); };
                f3.Not()(null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_Not_2()
            {
            // True works 
            Func<object, object, bool> f = (o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return true;
            };
            Assert.AreEqual(f.Not()(TestString, TestString), false);

            // False works
            Func<object, object, bool> f2 = (o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return false;
            };
            Assert.AreEqual(f2.Not()(TestString, TestString), true);

            // Exceptions are not hidden
            try
                {
                Func<object, object, bool> f3 = (o1, o2) => { throw new Exception(); };
                f3.Not()(null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_Not_3()
            {
            // True works 
            Func<object, object, object, bool> f = (o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return true;
            };
            Assert.AreEqual(f.Not()(TestString, TestString, TestString), false);

            // False works
            Func<object, object, object, bool> f2 = (o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return false;
            };
            Assert.AreEqual(f2.Not()(TestString, TestString, TestString), true);

            // Exceptions are not hidden
            try
                {
                Func<object, object, object, bool> f3 = (o1, o2, o3) => { throw new Exception(); };
                f3.Not()(null, null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_Not_4()
            {
            // True works 
            Func<object, object, object, object, bool> f = (o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return true;
            };
            Assert.AreEqual(f.Not()(TestString, TestString, TestString, TestString), false);

            // False works
            Func<object, object, object, object, bool> f2 = (o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return false;
            };
            Assert.AreEqual(f2.Not()(TestString, TestString, TestString, TestString), true);

            // Exceptions are not hidden
            try
                {
                Func<object, object, object, object, bool> f3 = (o1, o2, o3, o4) => { throw new Exception(); };
                f3.Not()(null, null, null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }

        [TestMethod]
        public void Test_If_Action_0()
            {
            // False works
            bool result = true;
            var act = new Action(() => { result = false; });

            act.If(L.Bool.False)();
            Assert.AreEqual(result, true);

            // true works
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(L.Bool.True)();
            Assert.AreEqual(result2, true);

            // Exceptions are not hidden
            try
                {
                Action act3 = () => { throw new Exception(); };
                act3.If(L.Bool.True)();
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_1()
            {
            var condition = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return false;
            });
            // False works
            bool result = true;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString);
            Assert.AreEqual(result, true);

            // true works
            var condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString);
            Assert.AreEqual(result2, true);

            // Exceptions are not hidden
            try
                {
                Action act3 = () => { throw new Exception(); };
                act3.If(condition)(null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_2()
            {
            var condition = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return false;
            });
            // False works
            bool result = true;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString, TestString);
            Assert.AreEqual(result, true);

            // true works
            var condition2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString, TestString);
            Assert.AreEqual(result2, true);

            // Exceptions are not hidden
            try
                {
                Action act3 = () => { throw new Exception(); };
                act3.If(condition)(null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_3()
            {
            var condition = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return false;
            });
            // False works
            bool result = true;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // true works
            var condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString, TestString, TestString);
            Assert.AreEqual(result2, true);

            // Exceptions are not hidden
            try
                {
                Action act3 = () => { throw new Exception(); };
                act3.If(condition)(null, null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_4()
            {
            var condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return false;
            });
            // False works
            bool result = true;
            var act = new Action(() => { result = true; });

            act.If(condition)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // true works
            var condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return true;
            });
            bool result2 = false;
            var act2 = new Action(() => { result2 = true; });

            act2.If(condition2)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result2, true);

            // Exceptions are not hidden
            try
                {
                Action act3 = () => { throw new Exception(); };
                act3.If(condition)(null, null, null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }

        [TestMethod]
        public void Test_If_Func_0()
            {
            // False works
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(L.Bool.False)();
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(L.Bool.True)();
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(L.Bool.True)();
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_1()
            {
            // False works
            var condition = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(condition)(TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works
            var condition2 = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(condition2)(null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_2()
            {
            // False works
            var condition = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(condition)(TestString, TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works
            var condition2 = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(condition2)(null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_3()
            {
            // False works
            var condition = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(condition)(TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works
            var condition2 = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString, TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(condition2)(null, null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_4()
            {
            // False works
            var condition = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return false;
            });
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(condition)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works
            var condition2 = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return true;
            });
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(condition2)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(condition2)(null, null, null, null);
                Assert.Fail(HiddenException);
                }
            catch { }
            }

        [TestMethod]
        public void Test_If_Action_Multiple_0()
            {
            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(L.Bool.True, L.Bool.True, L.Bool.True)();
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return true;
            });

            var False = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() => { result = false; });

            bool result2 = act.If(True, True, False)(TestString);
            Assert.AreEqual(result, true);

            // Result works
            Assert.AreEqual(result2, false);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString);
            Assert.AreEqual(result3, true);

            // Result works
            Assert.AreEqual(result4, true);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return true;
            });

            var False = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() => { result = false; });

            bool result2 = act.If(True, True, False)(TestString, TestString);
            Assert.AreEqual(result, true);

            // Result works
            Assert.AreEqual(result2, false);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result works
            Assert.AreEqual(result4, true);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString, TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return true;
            });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() => { result = false; });

            bool result2 = act.If(True, True, False)(TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // Result works
            Assert.AreEqual(result2, false);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString, TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result works
            Assert.AreEqual(result4, true);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString, TestString, TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Action_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return true;
            });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Action(() => { result = false; });

            bool result2 = act.If(True, True, False)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // Result works
            Assert.AreEqual(result2, false);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Action(() => { result3 = true; });

            bool result4 = act2.If(True, True, True)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result works
            Assert.AreEqual(result4, true);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString, TestString, TestString, TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }


        [TestMethod]
        public void Test_If_Func_Multiple_0()
            {
            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(L.Bool.True, L.Bool.True, L.Bool.False)();
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(L.Bool.True, L.Bool.True, L.Bool.True)();
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(L.Bool.True, L.Bool.True, L.Bool.True)();
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_Multiple_1()
            {
            var True = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return true;
            });

            var False = new Func<object, bool>(o =>
            {
                // Variables are passed.
                Assert.AreEqual(o, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(True, True, False)(TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_Multiple_2()
            {
            var True = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return true;
            });

            var False = new Func<object, object, bool>((o1, o2) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(True, True, False)(TestString, TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString, TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_Multiple_3()
            {
            var True = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return true;
            });

            var False = new Func<object, object, object, bool>((o1, o2, o3) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(True, True, False)(TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString, TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString, TestString, TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        [TestMethod]
        public void Test_If_Func_Multiple_4()
            {
            var True = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return true;
            });

            var False = new Func<object, object, object, object, bool>((o1, o2, o3, o4) =>
            {
                // Variables are passed.
                Assert.AreEqual(o1, TestString);
                Assert.AreEqual(o2, TestString);
                Assert.AreEqual(o3, TestString);
                Assert.AreEqual(o4, TestString);
                return false;
            });

            // False works - AND is applied
            bool result = true;
            var act = new Func<string>(() => { result = false; return TestString; });

            string result2 = act.If(True, True, False)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result, true);

            // Result does not pass through
            Assert.IsNull(result2);

            // true works - AND is applied
            bool result3 = false;
            var act2 = new Func<string>(() => { result3 = true; return TestString; });

            string result4 = act2.If(True, True, True)(TestString, TestString, TestString, TestString);
            Assert.AreEqual(result3, true);

            // Result passes through
            Assert.AreEqual(result4, TestString);

            // Exceptions are not hidden
            try
                {
                Func<string> act3 = () => { throw new Exception(); };
                act3.If(True, True, True)(TestString, TestString, TestString, TestString);
                Assert.Fail(HiddenException);
                }
            catch { }
            }
        }
    }

