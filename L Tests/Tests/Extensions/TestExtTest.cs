using LCore.Extensions;
using System;
using FluentAssertions;
using LCore.LUnit;
using LCore.LUnit.Assert;
using LCore.LUnit.Fluent;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable RedundantCast

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class TestExtTest
        {
        #region Test Variables

        private readonly Action _TestFail = () => { throw new ArgumentException(); };

        private readonly Action<object> _TestFail2 = o =>
            {
            o.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Action<object, object> _TestFail3 = (o1, o2) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Action<object, object, object> _TestFail4 = (o1, o2, o3) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Action<object, object, object, object> _TestFail5 = (o1, o2, o3, o4) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            o4.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Func<string> _TestFailFunc = () => { throw new ArgumentException(); };

        private readonly Func<object, string> _TestFailFunc2 = o =>
            {
            o.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Func<object, object, string> _TestFailFunc3 = (o1, o2) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Func<object, object, object, string> _TestFailFunc4 = (o1, o2, o3) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Func<object, object, object, object, string> _TestFailFunc5 = (o1, o2, o3, o4) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            o4.Should().Be("abc");
            throw new ArgumentException();
            };

        private readonly Action _Test = () => { };
        private readonly Action<object> _Test2 = o => { o.Should().Be("abc"); };

        private readonly Action<object, object> _Test3 = (o1, o2) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            };

        private readonly Action<object, object, object> _Test4 = (o1, o2, o3) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            };

        private readonly Action<object, object, object, object> _Test5 = (o1, o2, o3, o4) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            o4.Should().Be("abc");
            };

        private readonly Func<string> _TestFunc = () => "abc";

        private readonly Func<object, string> _TestFunc2 = o =>
            {
            o.Should().Be("abc");
            return "abc";
            };

        private readonly Func<object, object, string> _TestFunc3 = (o1, o2) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            return "abc";
            };

        private readonly Func<object, object, object, string> _TestFunc4 = (o1, o2, o3) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            return "abc";
            };

        private readonly Func<object, object, object, object, string> _TestFunc5 = (o1, o2, o3, o4) =>
            {
            o1.Should().Be("abc");
            o2.Should().Be("abc");
            o3.Should().Be("abc");
            o4.Should().Be("abc");
            return "abc";
            };

        #endregion

        [Fact]
        public void Test_ShouldFail()
            {
            this._TestFail.ShouldFail();
            this._TestFail2.ShouldFail("abc");
            this._TestFail3.ShouldFail("abc", "abc");
            this._TestFail4.ShouldFail("abc", "abc", "abc");
            this._TestFail5.ShouldFail("abc", "abc", "abc", "abc");


            this._TestFail.ShouldFail<Exception>();
            this._TestFail2.ShouldFail<object, Exception>("abc");
            this._TestFail3.ShouldFail<object, object, Exception>("abc", "abc");
            this._TestFail4.ShouldFail<object, object, object, Exception>("abc", "abc", "abc");
            this._TestFail5.ShouldFail<object, object, object, object, Exception>("abc", "abc", "abc", "abc");

            this._TestFail.ShouldFail<ArgumentException>();
            this._TestFail2.ShouldFail<object, ArgumentException>("abc");
            this._TestFail3.ShouldFail<object, object, ArgumentException>("abc", "abc");
            this._TestFail4.ShouldFail<object, object, object, ArgumentException>("abc", "abc", "abc");
            this._TestFail5.ShouldFail<object, object, object, object, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFail.ShouldFail<InvalidOperationException>()).ShouldFail();
            L.A(() => this._TestFail2.ShouldFail<object, InvalidOperationException>("abc")).ShouldFail();
            L.A(() => this._TestFail3.ShouldFail<object, object, InvalidOperationException>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFail4.ShouldFail<object, object, object, InvalidOperationException>("abc", "abc", "abc"))
                .ShouldFail();
            L.A(() => this._TestFail5.ShouldFail<object, object, object, object, InvalidOperationException>("abc", "abc", "abc",
                "abc")).ShouldFail();


            this._TestFailFunc.ShouldFail();
            this._TestFailFunc2.ShouldFail("abc");
            this._TestFailFunc3.ShouldFail("abc", "abc");
            this._TestFailFunc4.ShouldFail("abc", "abc", "abc");
            this._TestFailFunc5.ShouldFail("abc", "abc", "abc", "abc");

            this._TestFailFunc.ShouldFail<string, Exception>();
            this._TestFailFunc2.ShouldFail<object, string, Exception>("abc");
            this._TestFailFunc3.ShouldFail<object, object, string, Exception>("abc", "abc");
            this._TestFailFunc4.ShouldFail<object, object, object, string, Exception>("abc", "abc", "abc");
            this._TestFailFunc5.ShouldFail<object, object, object, object, string, Exception>("abc", "abc", "abc", "abc");

            this._TestFailFunc.ShouldFail<string, ArgumentException>();
            this._TestFailFunc2.ShouldFail<object, string, ArgumentException>("abc");
            this._TestFailFunc3.ShouldFail<object, object, string, ArgumentException>("abc", "abc");
            this._TestFailFunc4.ShouldFail<object, object, object, string, ArgumentException>("abc", "abc", "abc");
            this._TestFailFunc5.ShouldFail<object, object, object, object, string, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFailFunc.ShouldFail<string, InvalidOperationException>()).ShouldFail();
            L.A(() => this._TestFailFunc2.ShouldFail<object, string, InvalidOperationException>("abc")).ShouldFail();
            L.A(() => this._TestFailFunc3.ShouldFail<object, object, string, InvalidOperationException>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc4.ShouldFail<object, object, object, string, InvalidOperationException>("abc", "abc", "abc"))
                .ShouldFail();
            L.A(
                () =>
                    this._TestFailFunc5.ShouldFail<object, object, object, object, string, InvalidOperationException>("abc", "abc", "abc",
                        "abc"))
                .ShouldFail();


            this._TestFail.AssertFails();
            this._TestFail2.AssertFails("abc");
            this._TestFail3.AssertFails("abc", "abc");
            this._TestFail4.AssertFails("abc", "abc", "abc");
            this._TestFail5.AssertFails("abc", "abc", "abc", "abc");


            this._TestFail.AssertFails<Exception>();
            this._TestFail2.AssertFails<object, Exception>("abc");
            this._TestFail3.AssertFails<object, object, Exception>("abc", "abc");
            this._TestFail4.AssertFails<object, object, object, Exception>("abc", "abc", "abc");
            this._TestFail5.AssertFails<object, object, object, object, Exception>("abc", "abc", "abc", "abc");

            this._TestFail.AssertFails<ArgumentException>();
            this._TestFail2.AssertFails<object, ArgumentException>("abc");
            this._TestFail3.AssertFails<object, object, ArgumentException>("abc", "abc");
            this._TestFail4.AssertFails<object, object, object, ArgumentException>("abc", "abc", "abc");
            this._TestFail5.AssertFails<object, object, object, object, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFail.AssertFails<InvalidOperationException>()).AssertFails();
            L.A(() => this._TestFail2.AssertFails<object, InvalidOperationException>("abc")).AssertFails();
            L.A(() => this._TestFail3.AssertFails<object, object, InvalidOperationException>("abc", "abc")).AssertFails();
            L.A(() => this._TestFail4.AssertFails<object, object, object, InvalidOperationException>("abc", "abc", "abc"))
                .AssertFails();
            L.A(() => this._TestFail5.AssertFails<object, object, object, object, InvalidOperationException>("abc", "abc", "abc",
                "abc")).AssertFails();


            this._TestFailFunc.AssertFails();
            this._TestFailFunc2.AssertFails("abc");
            this._TestFailFunc3.AssertFails("abc", "abc");
            this._TestFailFunc4.AssertFails("abc", "abc", "abc");
            this._TestFailFunc5.AssertFails("abc", "abc", "abc", "abc");

            this._TestFailFunc.AssertFails<string, Exception>();
            this._TestFailFunc2.AssertFails<object, string, Exception>("abc");
            this._TestFailFunc3.AssertFails<object, object, string, Exception>("abc", "abc");
            this._TestFailFunc4.AssertFails<object, object, object, string, Exception>("abc", "abc", "abc");
            this._TestFailFunc5.AssertFails<object, object, object, object, string, Exception>("abc", "abc", "abc", "abc");

            this._TestFailFunc.AssertFails<string, ArgumentException>();
            this._TestFailFunc2.AssertFails<object, string, ArgumentException>("abc");
            this._TestFailFunc3.AssertFails<object, object, string, ArgumentException>("abc", "abc");
            this._TestFailFunc4.AssertFails<object, object, object, string, ArgumentException>("abc", "abc", "abc");
            this._TestFailFunc5.AssertFails<object, object, object, object, string, ArgumentException>("abc", "abc", "abc", "abc");

            L.A(() => this._TestFailFunc.AssertFails<string, InvalidOperationException>()).AssertFails();
            L.A(() => this._TestFailFunc2.AssertFails<object, string, InvalidOperationException>("abc")).AssertFails();
            L.A(() => this._TestFailFunc3.AssertFails<object, object, string, InvalidOperationException>("abc", "abc")).AssertFails();
            L.A(() => this._TestFailFunc4.AssertFails<object, object, object, string, InvalidOperationException>("abc", "abc", "abc"))
                .AssertFails();
            L.A(
                () =>
                    this._TestFailFunc5.AssertFails<object, object, object, object, string, InvalidOperationException>("abc", "abc", "abc",
                        "abc"))
                .AssertFails();
            }

        [Fact]
        public void Test_ShouldSucceed()
            {
            this._Test.ShouldSucceed();
            this._Test2.ShouldSucceed("abc");
            this._Test3.ShouldSucceed("abc", "abc");
            this._Test4.ShouldSucceed("abc", "abc", "abc");
            this._Test5.ShouldSucceed("abc", "abc", "abc", "abc");

            this._TestFunc.ShouldSucceed();
            this._TestFunc2.ShouldSucceed<string, string>("abc");
            this._TestFunc3.ShouldSucceed<string, string, string>("abc", "abc");
            this._TestFunc4.ShouldSucceed<string, string, string, string>("abc", "abc", "abc");
            this._TestFunc5.ShouldSucceed<string, string, string, string, string>("abc", "abc", "abc", "abc");


            this._Test.AssertSucceedes();
            this._Test2.AssertSucceedes("abc");
            this._Test3.AssertSucceedes("abc", "abc");
            this._Test4.AssertSucceedes("abc", "abc", "abc");
            this._Test5.AssertSucceedes("abc", "abc", "abc", "abc");

            this._TestFunc.AssertSucceedes();
            this._TestFunc2.AssertSucceedes<string, string>("abc");
            this._TestFunc3.AssertSucceedes<string, string, string>("abc", "abc");
            this._TestFunc4.AssertSucceedes<string, string, string, string>("abc", "abc", "abc");
            this._TestFunc5.AssertSucceedes<string, string, string, string, string>("abc", "abc", "abc", "abc");


            L.A(() => this._TestFail.ShouldSucceed()).ShouldFail();
            L.A(() => this._TestFail2.ShouldSucceed("abc")).ShouldFail();
            L.A(() => this._TestFail3.ShouldSucceed("abc", "abc")).ShouldFail();
            L.A(() => this._TestFail4.ShouldSucceed("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFail5.ShouldSucceed("abc", "abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc.ShouldSucceed()).ShouldFail();
            L.A(() => this._TestFailFunc2.ShouldSucceed<string, string>("abc")).ShouldFail();
            L.A(() => this._TestFailFunc3.ShouldSucceed<string, string, string>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc4.ShouldSucceed<string, string, string, string>("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc5.ShouldSucceed<string, string, string, string, string>("abc", "abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFail.AssertSucceedes()).ShouldFail();
            L.A(() => this._TestFail2.AssertSucceedes("abc")).ShouldFail();
            L.A(() => this._TestFail3.AssertSucceedes("abc", "abc")).ShouldFail();
            L.A(() => this._TestFail4.AssertSucceedes("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFail5.AssertSucceedes("abc", "abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc.AssertSucceedes()).ShouldFail();
            L.A(() => this._TestFailFunc2.AssertSucceedes<string, string>("abc")).ShouldFail();
            L.A(() => this._TestFailFunc3.AssertSucceedes<string, string, string>("abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc4.AssertSucceedes<string, string, string, string>("abc", "abc", "abc")).ShouldFail();
            L.A(() => this._TestFailFunc5.AssertSucceedes<string, string, string, string, string>("abc", "abc", "abc", "abc")).ShouldFail();
            }

        [Fact]
        public void Test_ShouldBe()
            {
            this._TestFunc.ShouldBe("abc");
            this._TestFunc2.ShouldBe("abc", "abc");
            this._TestFunc3.ShouldBe("abc", "abc", "abc");
            this._TestFunc4.ShouldBe("abc", "abc", "abc", "abc");
            this._TestFunc5.ShouldBe("abc", "abc", "abc", "abc", "abc");

            L.A(() => this._TestFunc.ShouldBe("abcd")).ShouldFail();
            L.A(() => this._TestFunc2.ShouldBe("abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc3.ShouldBe("abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc4.ShouldBe("abc", "abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc5.ShouldBe("abc", "abc", "abc", "abc", "abcd")).ShouldFail();
            }

        [Fact]
        public void Test_AssertResult_2()
            {
            this._TestFunc.AssertResult("abc");
            this._TestFunc2.AssertResult("abc", "abc");
            this._TestFunc3.AssertResult("abc", "abc", "abc");
            this._TestFunc4.AssertResult("abc", "abc", "abc", "abc");
            this._TestFunc5.AssertResult("abc", "abc", "abc", "abc", "abc");

            L.A(() => this._TestFunc.AssertResult("abcd")).ShouldFail();
            L.A(() => this._TestFunc2.AssertResult("abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc3.AssertResult("abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc4.AssertResult("abc", "abc", "abc", "abcd")).ShouldFail();
            L.A(() => this._TestFunc5.AssertResult("abc", "abc", "abc", "abc", "abcd")).ShouldFail();
            }

        [Fact]
        public void Test_AssertSucceedes()
            {
            var Target = new Helper();

            L.Ref.Method<Helper>(o => o.Test()).AssertSucceedes(Target, new object[] {});
            L.Ref.Method<Helper>(o => o.Test("")).AssertSucceedes(Target, new object[] {""});
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertSucceedes(Target, new object[] {"", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertSucceedes(Target, new object[] {"", "", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertSucceedes(Target, new object[] {"", "", "", ""});

            L.Ref.Method<Helper>(o => o.Test()).AssertSucceedes(Target, new object[] {}, o => true);
            L.Ref.Method<Helper>(o => o.Test("")).AssertSucceedes(Target, new object[] {""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertSucceedes(Target, new object[] {"", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertSucceedes(Target, new object[] {"", "", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertSucceedes(Target, new object[] {"", "", "", ""}, o => true);

            L.Ref.Method<Helper>(o => o.Test()).AssertSucceedes(Target, new object[] {}, () => true);
            L.Ref.Method<Helper>(o => o.Test("")).AssertSucceedes(Target, new object[] {""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertSucceedes(Target, new object[] {"", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertSucceedes(Target, new object[] {"", "", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertSucceedes(Target, new object[] {"", "", "", ""}, () => true);

            L.Ref.Method<Helper>(o => o.Test()).ShouldSucceed(Target, new object[] {});
            L.Ref.Method<Helper>(o => o.Test("")).ShouldSucceed(Target, new object[] {""});
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldSucceed(Target, new object[] {"", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldSucceed(Target, new object[] {"", "", ""});
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldSucceed(Target, new object[] {"", "", "", ""});

            L.Ref.Method<Helper>(o => o.Test()).ShouldSucceed(Target, new object[] {}, o => true);
            L.Ref.Method<Helper>(o => o.Test("")).ShouldSucceed(Target, new object[] {""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldSucceed(Target, new object[] {"", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldSucceed(Target, new object[] {"", "", ""}, o => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldSucceed(Target, new object[] {"", "", "", ""}, o => true);

            L.Ref.Method<Helper>(o => o.Test()).ShouldSucceed(Target, new object[] {}, () => true);
            L.Ref.Method<Helper>(o => o.Test("")).ShouldSucceed(Target, new object[] {""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldSucceed(Target, new object[] {"", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldSucceed(Target, new object[] {"", "", ""}, () => true);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldSucceed(Target, new object[] {"", "", "", ""}, () => true);
            }

        [Fact]
        public void Test_AssertResult()
            {
            var Target = new Helper();

            L.Ref.Method<Helper>(o => o.Test()).AssertResult(Target, new object[] {}, 5);
            L.Ref.Method<Helper>(o => o.Test("")).AssertResult(Target, new object[] {""}, 5);
            L.Ref.Method<Helper>(o => o.Test("", "")).AssertResult(Target, new object[] {"", ""}, 5);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).AssertResult(Target, new object[] {"", "", ""}, 5);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).AssertResult(Target, new object[] {"", "", "", ""}, 5);

            L.Ref.Method<Helper>(o => o.Test()).ShouldBe(Target, new object[] {}, 5);
            L.Ref.Method<Helper>(o => o.Test("")).ShouldBe(Target, new object[] {""}, 5);
            L.Ref.Method<Helper>(o => o.Test("", "")).ShouldBe(Target, new object[] {"", ""}, 5);
            L.Ref.Method<Helper>(o => o.Test("", "", "")).ShouldBe(Target, new object[] {"", "", ""}, 5);
            L.Ref.Method<Helper>(o => o.Test("", "", "", "")).ShouldBe(Target, new object[] {"", "", "", ""}, 5);
            }


        [Fact]
        public void Test_BoundAttribute()
            {
            var Attr = new TestBoundAttribute(0, 1, 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be(1);
            Attr.Maximum.Should().Be(2);
            Attr.ValueType.Should().Be(typeof(int));

            //////

            Attr = new TestBoundAttribute(0, 1u, 2u);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be(1u);
            Attr.Maximum.Should().Be(2u);
            Attr.ValueType.Should().Be(typeof(uint));

            //////

            Attr = new TestBoundAttribute(0, (short) 1, (short) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((short) 1);
            Attr.Maximum.Should().Be((short) 2);
            Attr.ValueType.Should().Be(typeof(short));
            //////

            Attr = new TestBoundAttribute(0, (ushort) 1, (ushort) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((ushort) 1);
            Attr.Maximum.Should().Be((ushort) 2);
            Attr.ValueType.Should().Be(typeof(ushort));


            //////

            Attr = new TestBoundAttribute(0, (byte) 1, (byte) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((byte) 1);
            Attr.Maximum.Should().Be((byte) 2);
            Attr.ValueType.Should().Be(typeof(byte));

            //////

            Attr = new TestBoundAttribute(0, (sbyte) 1, (sbyte) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((sbyte) 1);
            Attr.Maximum.Should().Be((sbyte) 2);
            Attr.ValueType.Should().Be(typeof(sbyte));

            //////

            Attr = new TestBoundAttribute(0, (decimal) 1, (decimal) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((decimal) 1);
            Attr.Maximum.Should().Be((decimal) 2);
            Attr.ValueType.Should().Be(typeof(decimal));

            //////

            Attr = new TestBoundAttribute(0, (double) 1, (double) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((double) 1);
            Attr.Maximum.Should().Be((double) 2);
            Attr.ValueType.Should().Be(typeof(double));

            //////

            Attr = new TestBoundAttribute(0, (float) 1, (float) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((float) 1);
            Attr.Maximum.Should().Be((float) 2);
            Attr.ValueType.Should().Be(typeof(float));


            //////

            Attr = new TestBoundAttribute(0, (object) 1, (object) 2);

            Attr.ParameterIndex.Should().Be(0);
            Attr.Minimum.Should().Be((object) 1);
            Attr.Maximum.Should().Be((object) 2);
            Attr.ValueType.Should().Be(typeof(int));
            }

        /*
                [Fact]
                public void Test_AssertSource()
                    {
                    var Test = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

                    var TestAdd = new Action(() => Test = Test.Add(0));
                    var TestAdd2 = new Action<int>(i => Test = Test.Add(i));
                    var TestAdd3 = new Action<int, int>((i1, i2) => Test = Test.Add(i1, i2));
                    var TestAdd4 = new Action<int, int, int>((i1, i2, i3) => Test = Test.Add(i1, i2, i3));
                    var TestAdd5 = new Action<int, int, int, int>((i1, i2, i3, i4) => Test = Test.Add(i1, i2, i3, i4));

                    TestAdd.AssertSource(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0});

                    TestAdd2.AssertSource("abc", "abc");
                    TestAdd3.AssertSource("abc", "abc", "abc");
                    TestAdd4.AssertSource("abc", "abc", "abc", "abc");
                    TestAdd5.AssertSource("abc", "abc", "abc", "abc", "abc");
                    }*/

        #region Helpers

        internal class Helper
            {
            public int Test()
                {
                return 5;
                }

            public int Test(string Str)
                {
                return 5;
                }

            public int Test(string Str, string Str2)
                {
                return 5;
                }

            public int Test(string Str, string Str2, string Str3)
                {
                return 5;
                }

            public int Test(string Str, string Str2, string Str3, string Str4)
                {
                return 5;
                }
            }

        #endregion
        }
    }