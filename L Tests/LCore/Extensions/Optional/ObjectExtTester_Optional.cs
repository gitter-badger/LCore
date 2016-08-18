using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable AssignNullToNotNullAttribute

// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable RedundantCast
#pragma warning disable 169

namespace L_Tests.LCore.Extensions.Optional
    {
    public partial class ObjectExtTester_Optional : XUnitOutputTester, IDisposable
        {
        public ObjectExtTester_Optional([NotNull] ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

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

            Test.A.ShouldBe(Expected: 1);
            Test.B.ShouldBe(Expected: 2);
            Test.C.ShouldBe(Expected: 3);

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

            Test4.A.ShouldBe(-1);
            Test4.B.ShouldBe(-2);
            Test4.C.ShouldBe(-3);
            Test4.D.ShouldBe(Expected: 4);
            Test4.E.ShouldBe(Expected: null);

            // subclass CopyFieldsTo subclass 
            Test4.CopyFieldsTo(Test4);

            Test4.A.ShouldBe(-1);
            Test4.B.ShouldBe(-2);
            Test4.C.ShouldBe(-3);
            Test4.D.ShouldBe(Expected: 4);
            Test4.E.ShouldBe(Expected: null);

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

            Test6.A.ShouldBe(-1);
            Test6.B.ShouldBe(-2);
            Test6.C.ShouldBe(-3);

            // read only fields CopyFieldsTo subclass 
            var Test7 = new TestClassReadOnly(-1, -2, -3);
            var Test8 = new TestClass
                {
                A = 1,
                B = 2,
                C = 3
                };

            Test7.CopyFieldsTo(Test8);

            Test8.A.ShouldBe(-1);
            Test8.B.ShouldBe(-2);
            Test8.C.ShouldBe(-3);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.CopyFieldsTo) + "(T, Object, Dictionary<String, String>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.CopyFieldsTo) + "(T, Object, Func<String, String>)")]
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

            Test.A.ShouldBe(Expected: null);
            Test.B.ShouldBe(Expected: 1);
            Test.C.ShouldBe(Expected: 3);

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

            Test4.A.ShouldBe(Expected: 1);
            Test4.B.ShouldBe(-2);
            Test4.C.ShouldBe(-3);
            Test4.D.ShouldBe(Expected: 4);
            Test4.E.ShouldBe(Expected: null);

            // subclass CopyFieldsTo subclass 
            Test4.CopyFieldsTo(Test4, Mapper2);

            Test4.A.ShouldBe(Expected: 1);
            Test4.B.ShouldBe(-2);
            Test4.C.ShouldBe(-3);
            Test4.D.ShouldBe(Expected: 4);
            Test4.E.ShouldBe(Expected: null);


            var Test5 = new TestSubclass();
            // copy using null dictionary
            Test4.CopyFieldsTo(Test5, (Dictionary<string, string>) null);

            Test5.A.ShouldBe(Expected: 1);
            Test5.B.ShouldBe(-2);
            Test5.C.ShouldBe(-3);
            Test4.D.ShouldBe(Expected: 4);
            Test5.E.ShouldBe(Expected: null);
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateArray) + "(T) => Func<T[]>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateArray) + "(T, Int32) => Func<T[]>")]
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateList) + "(T) => Func<List<T>>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_CreateList) + "(T, Int32) => Func<List<T>>")]
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

            Test.Details().ShouldBe("L_Tests.LCore.Extensions.Optional.ObjectExtTester_Optional+TestClass {\r\nA: 1\r\nB: 2\r\nC: 3\r\n}");


            var Test2 = new TestClassError
                {
                A = 1,
                B = 2
                };

            Test2.Details()
                .ShouldBe("L_Tests.LCore.Extensions.Optional.ObjectExtTester_Optional+TestClassError {\r\nA: 1\r\nB: 2\r\nD: 5\r\nE: 7\r\n}");
            Test2.Details(ShowErrorFields: false)
                .ShouldBe("L_Tests.LCore.Extensions.Optional.ObjectExtTester_Optional+TestClassError {\r\nA: 1\r\nB: 2\r\nD: 5\r\nE: 7\r\n}");
            Test2.Details(ShowErrorFields: true)
                .ShouldBe("L_Tests.LCore.Extensions.Optional.ObjectExtTester_Optional+TestClassError {\r\nA: 1\r\nB: 2\r\nC: Exception has been thrown by the target of an invocation.\r\nD: 5\r\nE: 7\r\n}");
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_If) + "(T) => Func<T, Boolean>")]
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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.FN_Func) + "(T) => Func<T>")]
        public void FN_Func()
            {
            5.FN_Func()().ShouldBe(Expected: 5);
            5f.FN_Func()().ShouldBe(Expected: 5f);
            "nice".FN_Func()().ShouldBe("nice");
            ((string) null).FN_Func()().ShouldBe((string) null);

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
            ((string) null).SafeEquals("nice").ShouldBeFalse();
            ((string) null).SafeEquals(Obj: null).ShouldBeTrue();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.ToS) + "(Object) => String")]
        public void ToS()
            {
            4.ToS().ShouldBe("4");
            5.ToS().ShouldBe("5");
            5f.ToS().ShouldBe("5");
            5.5f.ToS().ShouldBe("5.5");
            "nice".ToS().ShouldBe("nice");
            ((string) null).ToS().ShouldBe("");
            new[] {4}.ToS().ShouldBe("Int32[] { 4 }");
            new[] {"a", "b", "c"}.ToS().ShouldBe("String[] { a, b, c }");
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.Traverse) + "(Object, Func<Object, Object>)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.Traverse) + "(T, Func<T, T>)")]
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

            Result.ShouldBe(Expected: 1);

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

            Result2.ShouldBe(Expected: 5);

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
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.SupplyTo) + "(T, Action<T>) => Action")]
        public void SupplyTo_Action()
            {
            const int Test = 5;

            int Result = 0;

            var Test2 = new Action<int>(i => Result = i);

            var Test3 = Test.SupplyTo(Test2);

            Result.ShouldBe(Expected: 0);
            Test3();

            // value was supplied.
            Result.ShouldBe(Expected: 5);

            Test.SupplyTo(In: null)();

            var Test4 = new Func<int, int>(i => { throw new Exception(); });

            Func<int> Test5 = Test.SupplyTo(Test4);

            var Test6 = Test.SupplyTo((Action<int>) null);
            Test6();

            // Exceptions are not hidden.
            L.A(() => Test5()).ShouldFail();
            }


        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.SupplyTo) + "(T, Func<T, U>) => Func<U>")]
        public void SupplyTo_Func()
            {
            const int Test = 5;

            var Test2 = new Func<int, int>(i => i + 1);

            Func<int> Test3 = Test.SupplyTo(Test2);

            int Result = Test3();

            // value was supplied.
            Result.ShouldBe(Expected: 6);


            var Test4 = new Func<int, int>(i => { throw new Exception(); });

            Func<int> Test5 = Test.SupplyTo(Test4);

            Func<int> Test6 = Test.SupplyTo((Func<int, int>) null);
            Test6();

            // Exceptions are not hidden.
            L.A(() => Test5()).ShouldFail();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(global::LCore.Extensions.Optional) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt) + "." + nameof(global::LCore.Extensions.Optional.ObjectExt.IsNull) + "(T) => Boolean")]
        public void IsNull()
            {
            object Obj = null;
            Obj.IsNull().ShouldBeTrue();
            Obj = "";
            Obj.IsNull().ShouldBeFalse();

            string Str = null;
            Str.IsNull().ShouldBeTrue();
            Str = "";
            Str.IsNull().ShouldBeFalse();
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