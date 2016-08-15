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