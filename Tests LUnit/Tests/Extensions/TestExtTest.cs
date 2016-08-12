using LCore.Extensions;
using System;
using FluentAssertions;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable RedundantCast

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace LCore.LUnit.Tests.Extensions
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
        public void Test_BoundAttribute()
            {
            var Attr = new TestBoundAttribute(Minimum: 1, Maximum: 2);

            Attr.Minimum.Should().Be(expected: 1);
            Attr.Maximum.Should().Be(expected: 2);
            Attr.ValueType.Should().Be(typeof(int));

            //////

            Attr = new TestBoundAttribute(Minimum: 1u, Maximum: 2u);

            Attr.Minimum.Should().Be(expected: 1u);
            Attr.Maximum.Should().Be(expected: 2u);
            Attr.ValueType.Should().Be(typeof(uint));

            //////

            Attr = new TestBoundAttribute((short)1, (short)2);

            Attr.Minimum.Should().Be((short)1);
            Attr.Maximum.Should().Be((short)2);
            Attr.ValueType.Should().Be(typeof(short));
            //////

            Attr = new TestBoundAttribute((ushort)1, (ushort)2);

            Attr.Minimum.Should().Be((ushort)1);
            Attr.Maximum.Should().Be((ushort)2);
            Attr.ValueType.Should().Be(typeof(ushort));


            //////

            Attr = new TestBoundAttribute((byte)1, (byte)2);

            Attr.Minimum.Should().Be((byte)1);
            Attr.Maximum.Should().Be((byte)2);
            Attr.ValueType.Should().Be(typeof(byte));

            //////

            Attr = new TestBoundAttribute((sbyte)1, (sbyte)2);

            Attr.Minimum.Should().Be((sbyte)1);
            Attr.Maximum.Should().Be((sbyte)2);
            Attr.ValueType.Should().Be(typeof(sbyte));

            //////

            Attr = new TestBoundAttribute((decimal)1, (decimal)2);

            Attr.Minimum.Should().Be((decimal)1);
            Attr.Maximum.Should().Be((decimal)2);
            Attr.ValueType.Should().Be(typeof(decimal));

            //////

            Attr = new TestBoundAttribute((double)1, (double)2);

            Attr.Minimum.Should().Be((double)1);
            Attr.Maximum.Should().Be((double)2);
            Attr.ValueType.Should().Be(typeof(double));

            //////

            Attr = new TestBoundAttribute((float)1, (float)2);

            Attr.Minimum.Should().Be((float)1);
            Attr.Maximum.Should().Be((float)2);
            Attr.ValueType.Should().Be(typeof(float));


            //////

            /* Attr = new TestBoundAttribute((object)1, (object)2);

             Attr.Minimum.Should().Be((object)1);
             Attr.Maximum.Should().Be((object)2);
             Attr.ValueType.Should().Be(typeof(int));*/
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