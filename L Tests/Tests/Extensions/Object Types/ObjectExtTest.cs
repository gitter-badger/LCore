﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable RedundantCast
#pragma warning disable 169

namespace L_Tests.LCore.Extensions.Optional
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt))]
    public partial class ObjectExtTester : XUnitOutputTester, IDisposable
        {
        public ObjectExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.CopyFieldsTo) + "(T, Object)")]
        public void CopyFieldsTo_0()
            {
            var Test = new TestClass
                {
                A = -1,
                B = -2,
                C = -3
                };
            var Test2 = new TestSubclass
                {
                A = 1,
                B = 2,
                C = 3,
                D = 4,
                E = null
                };

            // subclass CopyFieldsTo parent class
            Test2.CopyFieldsTo(Test);

            Test.A.Should().Be(expected: 1);
            Test.B.Should().Be(expected: 2);
            Test.C.Should().Be(expected: 3);

            var Test3 = new TestClass
                {
                A = -1,
                B = -2,
                C = -3
                };
            var Test4 = new TestSubclass
                {
                A = 1,
                B = 2,
                C = 3,
                D = 4,
                E = null
                };

            // parent CopyFieldsTo subclass 
            Test3.CopyFieldsTo(Test4);

            Test4.A.Should().Be(-1);
            Test4.B.Should().Be(-2);
            Test4.C.Should().Be(-3);
            Test4.D.Should().Be(expected: 4);
            Test4.E.Should().Be(expected: null);

            // subclass CopyFieldsTo subclass 
            Test4.CopyFieldsTo(Test4);

            Test4.A.Should().Be(-1);
            Test4.B.Should().Be(-2);
            Test4.C.Should().Be(-3);
            Test4.D.Should().Be(expected: 4);
            Test4.E.Should().Be(expected: null);

            // anonymous type CopyFieldsTo subclass 
            var Test5 = new
                {
                A = -1,
                B = -2,
                C = -3
                };
            var Test6 = new TestClass
                {
                A = 1,
                B = 2,
                C = 3
                };

            Test5.CopyFieldsTo(Test6);

            Test6.A.Should().Be(-1);
            Test6.B.Should().Be(-2);
            Test6.C.Should().Be(-3);

            // read only fields CopyFieldsTo subclass 
            var Test7 = new TestClassReadOnly(-1, -2, -3);
            var Test8 = new TestClass
                {
                A = 1,
                B = 2,
                C = 3
                };

            Test7.CopyFieldsTo(Test8);

            Test8.A.Should().Be(-1);
            Test8.B.Should().Be(-2);
            Test8.C.Should().Be(-3);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.CopyFieldsTo) + "(T, Object, Dictionary`2<String, String>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.CopyFieldsTo) + "(T, Object, Func`2<String, String>)")]
        public void CopyFieldsTo_1()
            {
            var Mapper = new Dictionary<string, string>
                {
                ["A"] = "B",
                ["E"] = "A"
                };

            var Test = new TestClass
                {
                A = -1,
                B = -2,
                C = -3
                };
            var Test2 = new TestSubclass
                {
                A = 1,
                B = 2,
                C = 3,
                D = 4,
                E = null
                };

            // subclass CopyFieldsTo parent class
            Test2.CopyFieldsTo(Test, Mapper);

            Test.A.Should().Be(expected: null);
            Test.B.Should().Be(expected: 1);
            Test.C.Should().Be(expected: 3);

            var Test3 = new TestClass
                {
                A = -1,
                B = -2,
                C = -3
                };
            var Test4 = new TestSubclass
                {
                A = 1,
                B = 2,
                C = 3,
                D = 4,
                E = null
                };

            var Mapper2 = new Dictionary<string, string>
                {
                ["A"] = "ggg"
                };

            // parent CopyFieldsTo subclass 
            Test3.CopyFieldsTo(Test4, Mapper2);

            Test4.A.Should().Be(expected: 1);
            Test4.B.Should().Be(-2);
            Test4.C.Should().Be(-3);
            Test4.D.Should().Be(expected: 4);
            Test4.E.Should().Be(expected: null);

            // subclass CopyFieldsTo subclass 
            Test4.CopyFieldsTo(Test4, Mapper2);

            Test4.A.Should().Be(expected: 1);
            Test4.B.Should().Be(-2);
            Test4.C.Should().Be(-3);
            Test4.D.Should().Be(expected: 4);
            Test4.E.Should().Be(expected: null);


            var Test5 = new TestSubclass();
            // copy using null dictionary
            Test4.CopyFieldsTo(Test5, (Dictionary<string, string>)null);

            Test5.A.Should().Be(expected: 1);
            Test5.B.Should().Be(-2);
            Test5.C.Should().Be(-3);
            Test4.D.Should().Be(expected: 4);
            Test5.E.Should().Be(expected: null);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.InitProperties) + "(Object, T)")]
        public void InitProperties()
            {
            var Test = new TestMaster();

            Test.InitProperties<TestClass>();

            // subclasses were initialized.
            Test.A.Should().NotBeNull();
            Test.B.Should().NotBeNull();

            // but they are not the same object.
            Test.B.Should().NotBeSameAs(Test.A);

            var Test2 = new TestMaster();
            Test2.InitProperties(new TestClass());

            // subclasses were initialized.
            Test2.A.Should().NotBeNull();
            Test2.B.Should().NotBeNull();

            // and they ARE the same object.
            Test2.B.Should().BeSameAs(Test2.A);
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateArray) + "(T) => Func`1<T[]>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateArray) + "(T, Int32) => Func`1<T[]>")]
        public void FN_CreateArray()
            {
            Func<int[]> Test = 5.FN_CreateArray();

            int[] Test2 = Test();

            Test2.Should().Equal(5);

            Func<string[]> Test3 = "5".FN_CreateArray(Count: 5);

            string[] Test4 = Test3();

            Test4.Should().Equal("5", "5", "5", "5", "5");

            L.F<string, int, Func<string[]>>(global::LCore.Extensions.Optional.ObjectExt.FN_CreateArray).ShouldFail("5", -1);

            Func<string[]> Test5 = "5".FN_CreateArray(Count: 0);

            string[] Test6 = Test5();

            Test6.Should().Equal();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateList) + "(T) => Func`1<List`1<T>>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateList) + "(T, Int32) => Func`1<List`1<T>>")]
        public void FN_CreateList()
            {
            Func<List<int>> Test = 5.FN_CreateList();

            List<int> Test2 = Test();

            Test2.Should().Equal(5);

            Func<List<string>> Test3 = "5".FN_CreateList(Count: 5);

            List<string> Test4 = Test3();

            Test4.Should().Equal("5", "5", "5", "5", "5");

            L.F<string, int, Func<List<string>>>(global::LCore.Extensions.Optional.ObjectExt.FN_CreateList).ShouldFail("5", -1);

            Func<List<string>> Test5 = "5".FN_CreateList(Count: 0);

            List<string> Test6 = Test5();

            Test6.Should().Equal();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.Details) + "(T, Boolean) => String")]
        public void Details()
            {
            var Test = new TestClass
                {
                A = 1,
                B = 2,
                C = 3
                };

            Test.Details().Should().Be("L_Tests.LCore.Extensions.ObjectExtTester+TestClass {\r\nA: 1\r\nB: 2\r\nC: 3\r\n}");


            var Test2 = new TestClassError
                {
                A = 1,
                B = 2
                };

            Test2.Details()
                .Should().Be("L_Tests.LCore.Extensions.ObjectExtTester+TestClassError {\r\nA: 1\r\nB: 2\r\nD: 5\r\nE: 7\r\n}");
            Test2.Details(ShowErrorFields: false)
                .Should().Be("L_Tests.LCore.Extensions.ObjectExtTester+TestClassError {\r\nA: 1\r\nB: 2\r\nD: 5\r\nE: 7\r\n}");
            Test2.Details(ShowErrorFields: true)
                .Should().Be("L_Tests.LCore.Extensions.ObjectExtTester+TestClassError {\r\nA: 1\r\nB: 2\r\nC: Exception has been thrown by the target of an invocation.\r\nD: 5\r\nE: 7\r\n}");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_If) + "(T) => Func`2<T, Boolean>")]
        public void FN_If()
            {
            const int Test = 5;

            Func<int, bool> Test2 = Test.FN_If();

            Test2(arg: 0).ShouldBeFalse();
            Test2(arg: 1).ShouldBeFalse();
            Test2(arg: 2).ShouldBeFalse();
            Test2(arg: 3).ShouldBeFalse();
            Test2(arg: 4).ShouldBeFalse();
            Test2(arg: 5).ShouldBeTrue();
            Test2(arg: 6).ShouldBeFalse();

            string Test3 = null;

            Func<string, bool> Test4 = Test3.FN_If();

            Test4("").ShouldBeFalse();
            Test4("aaa").ShouldBeFalse();
            Test4(arg: null).ShouldBeTrue();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_Func) + "(T) => Func`1<T>")]
        public void FN_Func()
            {
            5.FN_Func()().Should().Be(expected: 5);
            5f.FN_Func()().Should().Be(expected: 5f);
            "nice".FN_Func()().Should().Be("nice");
            ((string)null).FN_Func()().Should().Be((string)null);

            new TestClass().FN_Func()()
                .Should().BeOfType<TestClass>()
                .And.NotBeNull();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.SafeEquals) + "(Object, Object) => Boolean")]
        public void SafeEquals()
            {
            4.SafeEquals(Obj: 5).ShouldBeFalse();
            5.SafeEquals(Obj: 5).ShouldBeTrue();
            5f.SafeEquals(Obj: 5.5f).ShouldBeFalse();
            5f.SafeEquals(Obj: 5f).ShouldBeTrue();
            "nice".SafeEquals("nice").ShouldBeTrue();
            ((string)null).SafeEquals("nice").ShouldBeFalse();
            ((string)null).SafeEquals(Obj: null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.ToS) + "(Object) => String")]
        public void ToS()
            {
            4.ToS().Should().Be("4");
            5.ToS().Should().Be("5");
            5f.ToS().Should().Be("5");
            5.5f.ToS().Should().Be("5.5");
            "nice".ToS().Should().Be("nice");
            ((string)null).ToS().Should().Be("");
            new[] { 4 }.ToS().Should().Be("Int32[] { 4 }");
            new[] { "a", "b", "c" }.ToS().Should().Be("String[] { a, b, c }");
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.Traverse) + "(Object, Func`2<Object, Object>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.Traverse) + "(T, Func`2<T, T>)")]
        public void Traverse()
            {
            object Test = new
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

            object Result = null;

            Test.Traverse(o =>
                {
                    if (o.HasProperty("link"))
                        return o.GetProperty("link");

                    Result = o.GetProperty("data");
                    return null;
                });

            Result.Should().Be(expected: 1);

            // Exceptions are not hidden.
            L.A<object, Func<object, object>>(global::LCore.Extensions.Optional.ObjectExt.Traverse).ShouldFail(Test, o =>
                {
                    if (o.HasProperty("link"))
                        return o.GetProperty("link");

                    throw new Exception();
                });


            var Test2 = new TestMaster
                {
                C = new TestMaster
                    {
                    C = new TestMaster
                        {
                        C = new TestMaster
                            {
                            C = new TestMaster
                                {
                                C = new TestMaster
                                    {
                                    A = new TestClass
                                        {
                                        A = 5
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            object Result2 = null;

            Test2.Traverse(o =>
                {
                    if (o.C != null)
                        return o.C;

                    Result2 = o.A.A;
                    return null;
                });

            Result2.Should().Be(expected: 5);

            // Exceptions are not hidden.
            L.A<TestMaster, Func<TestMaster, TestMaster>>(global::LCore.Extensions.Optional.ObjectExt.Traverse)
                .ShouldFail(Test2, o =>
                    {
                        if (o.C != null)
                            return o.C;

                        throw new Exception();
                    });
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.SupplyTo) + "(T, Action`1<T>) => Action")]
        public void SupplyTo_Action()
            {
            const int Test = 5;

            int Result = 0;

            var Test2 = new Action<int>(i => Result = i);

            var Test3 = Test.SupplyTo(Test2);

            Result.Should().Be(expected: 0);
            Test3();

            // value was supplied.
            Result.Should().Be(expected: 5);

            var Test4 = new Func<int, int>(i => { throw new Exception(); });

            Func<int> Test5 = Test.SupplyTo(Test4);

            // Exceptions are not hidden.
            L.A(() => Test5()).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.SupplyTo) + "(T, Func`2<T, U>) => Func`1<U>")]
        public void SupplyTo_Func()
            {
            const int Test = 5;

            var Test2 = new Func<int, int>(i => i + 1);

            Func<int> Test3 = Test.SupplyTo(Test2);

            int Result = Test3();

            // value was supplied.
            Result.Should().Be(expected: 6);


            var Test4 = new Func<int, int>(i => { throw new Exception(); });

            Func<int> Test5 = Test.SupplyTo(Test4);

            // Exceptions are not hidden.
            L.A(() => Test5()).ShouldFail();
            }


        #region Helper classes

        private class TestMaster
            {
            public TestClass A { get; set; }
            public TestClass B { get; set; }
            public TestMaster C { get; set; }
            }

        private class TestClass
            {
            public int? A { get; set; }
            public int? B { get; set; }
            public int? C { get; set; }
            }

        private class TestSubclass : TestClass
            {
            public int? D { get; set; }
            public int? E { get; set; }
            }

        private class TestClassReadOnly
            {
            public int? A { get; private set; }
            public int? B { get; private set; }
            public int? C { get; private set; }

            public TestClassReadOnly(int A, int B, int C)
                {
                this.A = A;
                this.B = B;
                this.C = C;
                }
            }


        private class TestClassError
            {
            public int? A { get; set; }
            public int? B { get; set; }

            /// <exception cref="Exception" accessor="get">oh no</exception>
            public int? C
                {
                get { throw new Exception("oh no"); }
                }

            public int D = 5;
            public int E = 7;
            }

        #endregion
        }
    }