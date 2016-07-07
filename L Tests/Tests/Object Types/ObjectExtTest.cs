using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.Tests;
using ObjectExt = LCore.Extensions.ObjectExt;
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable RedundantCast
#pragma warning disable 169

namespace L_Tests
    {
    [TestClass]
    public class ObjectExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ObjectExt), typeof(LCore.Extensions.Optional.ObjectExt) };

        [TestMethod]
        public void Test_CopyFieldsTo_0()
            {
            var test = new TestClass
                {
                a = -1,
                b = -2,
                c = -3
                };
            var test2 = new TestSubclass
                {
                a = 1,
                b = 2,
                c = 3,
                d = 4,
                e = null
                };

            // subclass CopyFieldsTo parent class
            test2.CopyFieldsTo(test);

            test.a.Should().Be(1);
            test.b.Should().Be(2);
            test.c.Should().Be(3);

            var test3 = new TestClass
                {
                a = -1,
                b = -2,
                c = -3
                };
            var test4 = new TestSubclass
                {
                a = 1,
                b = 2,
                c = 3,
                d = 4,
                e = null
                };

            // parent CopyFieldsTo subclass 
            test3.CopyFieldsTo(test4);

            test4.a.Should().Be(-1);
            test4.b.Should().Be(-2);
            test4.c.Should().Be(-3);
            test4.d.Should().Be(4);
            test4.e.Should().Be(null);

            // subclass CopyFieldsTo subclass 
            test4.CopyFieldsTo(test4);

            test4.a.Should().Be(-1);
            test4.b.Should().Be(-2);
            test4.c.Should().Be(-3);
            test4.d.Should().Be(4);
            test4.e.Should().Be(null);

            // anonymous type CopyFieldsTo subclass 
            var test5 = new
                {
                a = -1,
                b = -2,
                c = -3
                };
            var test6 = new TestClass
                {
                a = 1,
                b = 2,
                c = 3
                };

            test5.CopyFieldsTo(test6);

            test6.a.Should().Be(-1);
            test6.b.Should().Be(-2);
            test6.c.Should().Be(-3);

            // read only fields CopyFieldsTo subclass 
            var test7 = new TestClassReadOnly(-1, -2, -3);
            var test8 = new TestClass
                {
                a = 1,
                b = 2,
                c = 3
                };

            test7.CopyFieldsTo(test8);

            test8.a.Should().Be(-1);
            test8.b.Should().Be(-2);
            test8.c.Should().Be(-3);
            }

        [TestMethod]
        public void Test_CopyFieldsTo_1()
            {
            var mapper = new Dictionary<string, string>
                {
                ["a"] = "b",
                ["e"] = "a"
                };

            var test = new TestClass
                {
                a = -1,
                b = -2,
                c = -3
                };
            var test2 = new TestSubclass
                {
                a = 1,
                b = 2,
                c = 3,
                d = 4,
                e = null
                };

            // subclass CopyFieldsTo parent class
            test2.CopyFieldsTo(test, mapper);

            test.a.Should().Be(null);
            test.b.Should().Be(1);
            test.c.Should().Be(3);

            var test3 = new TestClass
                {
                a = -1,
                b = -2,
                c = -3
                };
            var test4 = new TestSubclass
                {
                a = 1,
                b = 2,
                c = 3,
                d = 4,
                e = null
                };

            var mapper2 = new Dictionary<string, string>
                {
                ["a"] = "ggg"
                };

            // parent CopyFieldsTo subclass 
            test3.CopyFieldsTo(test4, mapper2);

            test4.a.Should().Be(1);
            test4.b.Should().Be(-2);
            test4.c.Should().Be(-3);
            test4.d.Should().Be(4);
            test4.e.Should().Be(null);

            // subclass CopyFieldsTo subclass 
            test4.CopyFieldsTo(test4, mapper2);

            test4.a.Should().Be(1);
            test4.b.Should().Be(-2);
            test4.c.Should().Be(-3);
            test4.d.Should().Be(4);
            test4.e.Should().Be(null);


            var test5 = new TestSubclass();
            // copy using null dictionary
            test4.CopyFieldsTo(test5, (Dictionary<string, string>)null);

            test5.a.Should().Be(1);
            test5.b.Should().Be(-2);
            test5.c.Should().Be(-3);
            test4.d.Should().Be(4);
            test5.e.Should().Be(null);
            }

        [TestMethod]
        public void Test_InitProperties()
            {
            var test = new TestMaster();

            test.InitProperties<TestClass>();

            // subclasses were initialized.
            test.a.Should().NotBeNull();
            test.b.Should().NotBeNull();

            // but they are not the same object.
            test.b.Should().NotBeSameAs(test.a);

            var test2 = new TestMaster();
            test2.InitProperties(new TestClass());

            // subclasses were initialized.
            test2.a.Should().NotBeNull();
            test2.b.Should().NotBeNull();

            // and they ARE the same object.
            test2.b.Should().BeSameAs(test2.a);
            }

        [TestMethod]
        public void Test_FN_CreateArray()
            {
            Func<int[]> test = 5.FN_CreateArray();

            int[] test2 = test();

            test2.ShouldBeEquivalentTo(new[] { 5 });

            Func<string[]> test3 = "5".FN_CreateArray(5);

            string[] test4 = test3();

            test4.ShouldBeEquivalentTo(new[] { "5", "5", "5", "5", "5" });

            L.F<string, int, Func<string[]>>(LCore.Extensions.Optional.ObjectExt.FN_CreateArray).ShouldFail("5", -1);

            Func<string[]> test5 = "5".FN_CreateArray(0);

            string[] test6 = test5();

            test6.ShouldBeEquivalentTo(new string[] { });

            }

        [TestMethod]
        public void Test_FN_CreateList()
            {
            Func<List<int>> test = 5.FN_CreateList();

            List<int> test2 = test();

            test2.ShouldBeEquivalentTo(new[] { 5 });

            Func<List<string>> test3 = "5".FN_CreateList(5);

            List<string> test4 = test3();

            test4.ShouldBeEquivalentTo(new[] { "5", "5", "5", "5", "5" });

            L.F<string, int, Func<List<string>>>(LCore.Extensions.Optional.ObjectExt.FN_CreateList).ShouldFail("5", -1);

            Func<List<string>> test5 = "5".FN_CreateList(0);

            List<string> test6 = test5();

            test6.ShouldBeEquivalentTo(new string[] { });

            }

        [TestMethod]
        public void Test_Details()
            {
            var test = new TestClass
                {
                a = 1,
                b = 2,
                c = 3
                };

            test.Details().ShouldBeEquivalentTo("L_Tests.ObjectExtTest+TestClass {\r\na: 1\r\nb: 2\r\nc: 3\r\n}");


            var test2 = new TestClassError
                {
                a = 1,
                b = 2
                };

            test2.Details().ShouldBeEquivalentTo("L_Tests.ObjectExtTest+TestClassError {\r\na: 1\r\nb: 2\r\nd: 5\r\ne: 7\r\n}");
            test2.Details(false).ShouldBeEquivalentTo("L_Tests.ObjectExtTest+TestClassError {\r\na: 1\r\nb: 2\r\nd: 5\r\ne: 7\r\n}");
            test2.Details(true).ShouldBeEquivalentTo("L_Tests.ObjectExtTest+TestClassError {\r\na: 1\r\nb: 2\r\nc: Exception has been thrown by the target of an invocation.\r\nd: 5\r\ne: 7\r\n}");
            }

        [TestMethod]
        public void Test_FN_If()
            {
            const int test = 5;

            Func<int, bool> test2 = test.FN_If();

            test2(0).Should().BeFalse();
            test2(1).Should().BeFalse();
            test2(2).Should().BeFalse();
            test2(3).Should().BeFalse();
            test2(4).Should().BeFalse();
            test2(5).Should().BeTrue();
            test2(6).Should().BeFalse();

            string test3 = null;

            Func<string, bool> test4 = test3.FN_If();

            test4("").Should().BeFalse();
            test4("aaa").Should().BeFalse();
            test4(null).Should().BeTrue();
            }


        [TestMethod]
        public void Test_FN_Func()
            {
            5.FN_Func()().Should().Be(5);
            5f.FN_Func()().Should().Be(5f);
            "nice".FN_Func()().Should().Be("nice");
            ((string)null).FN_Func()().Should().Be((string)null);

            new TestClass().FN_Func()()
                .Should().BeOfType<TestClass>()
                .And.NotBeNull();
            }

        [TestMethod]
        public void Test_SafeEquals()
            {
            4.SafeEquals(5).Should().BeFalse();
            5.SafeEquals(5).Should().BeTrue();
            5f.SafeEquals(5.5f).Should().BeFalse();
            5f.SafeEquals(5f).Should().BeTrue();
            "nice".SafeEquals("nice").Should().BeTrue();
            ((string)null).SafeEquals("nice").Should().BeFalse();
            ((string)null).SafeEquals(null).Should().BeTrue();
            }

        [TestMethod]
        public void Test_ToS()
            {
            4.ToS().Should().Be("4");
            5.ToS().Should().Be("5");
            5f.ToS().Should().Be("5");
            5.5f.ToS().Should().Be("5.5");
            "nice".ToS().Should().Be("nice");
            ((string)null).ToS().Should().Be("");
            new[] { 4 }.ToS().Should().Be("System.Int32[] { 4 }");
            new[] { "a", "b", "c" }.ToS().Should().Be("System.String[] { a, b, c }");
            }

        [TestMethod]
        public void Test_Traverse()
            {
            object test = new
                {
                link = new
                    {
                    link = new
                        {
                        link = new
                            {
                            link = new
                                {
                                data = 1
                                },
                            data = 0
                            },
                        data = 0
                        },
                    data = 0
                    },
                data = 0
                };

            object result = null;

            test.Traverse(o =>
                {
                    if (o.HasProperty("link"))
                        return o.GetProperty("link");

                    result = o.GetProperty("data");
                    return null;
                });

            result.Should().Be(1);

            // Exceptions are not hidden.
            L.A<object, Func<object, object>>(LCore.Extensions.Optional.ObjectExt.Traverse).ShouldFail(test, o =>
              {
                  if (o.HasProperty("link"))
                      return o.GetProperty("link");

                  throw new Exception();
              });


            var test2 = new TestMaster
                {
                c = new TestMaster
                    {
                    c = new TestMaster
                        {
                        c = new TestMaster
                            {
                            c = new TestMaster
                                {
                                c = new TestMaster
                                    {
                                    a = new TestClass
                                        {
                                        a = 5
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            object result2 = null;

            test2.Traverse(o =>
                {
                    if (o.c != null)
                        return o.c;

                    result2 = o.a.a;
                    return null;
                });

            result2.Should().Be(5);

            // Exceptions are not hidden.
            L.A<TestMaster, Func<TestMaster, TestMaster>>(LCore.Extensions.Optional.ObjectExt.Traverse).ShouldFail(test2, o =>
            {
                if (o.c != null)
                    return o.c;

                throw new Exception();
            });
            }

        [TestMethod]
        public void Test_SupplyTo_Action()
            {
            const int test = 5;

            int result = 0;

            var test2 = new Action<int>(i => result = i);

            var test3 = test.SupplyTo(test2);

            result.Should().Be(0);
            test3();

            // value was supplied.
            result.Should().Be(5);

            var test4 = new Func<int, int>(i =>
            {
                throw new Exception();
            });

            Func<int> test5 = test.SupplyTo(test4);

            // Exceptions are not hidden.
            L.A(() => test5()).ShouldFail();
            }

        [TestMethod]
        public void Test_SupplyTo_Func()
            {
            const int test = 5;

            var test2 = new Func<int, int>(i => i + 1);

            Func<int> test3 = test.SupplyTo(test2);

            int result = test3();

            // value was supplied.
            result.Should().Be(6);


            var test4 = new Func<int, int>(i =>
                {
                    throw new Exception();
                });

            Func<int> test5 = test.SupplyTo(test4);

            // Exceptions are not hidden.
            L.A(() => test5()).ShouldFail();
            }

        #region Helper classes

        private class TestMaster
            {
            public TestClass a { get; set; }
            public TestClass b { get; set; }
            public TestMaster c { get; set; }
            }

        private class TestClass
            {
            public int? a { get; set; }
            public int? b { get; set; }
            public int? c { get; set; }
            }

        private class TestSubclass : TestClass
            {
            public int? d { get; set; }
            public int? e { get; set; }
            }

        private class TestClassReadOnly
            {
            public int? a { get; private set; }
            public int? b { get; private set; }
            public int? c { get; private set; }

            public TestClassReadOnly(int a, int b, int c)
                {
                this.a = a;
                this.b = b;
                this.c = c;
                }
            }


        private class TestClassError
            {
            public int? a { get; set; }
            public int? b { get; set; }
            public int? c
                {
                get
                    {
                    throw new Exception("oh no");
                    }
                }

            public int d = 5;
            public int e = 7;
            }
        #endregion
        }
    }
