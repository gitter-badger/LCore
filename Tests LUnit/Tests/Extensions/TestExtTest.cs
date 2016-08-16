using LCore.Extensions;
using LCore.LUnit.Fluent;
using System;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

// ReSharper disable UnusedMethodReturnValue.Global

// ReSharper disable RedundantCast

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace LCore.LUnit.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class TestExtTest
        {
        [Fact]
        public void BoundAttribute()
            {
            var Attr = new TestBoundAttribute(Minimum: 1, Maximum: 2);

            Attr.Minimum.ShouldBe(Compare: 1);
            Attr.Maximum.ShouldBe(Compare: 2);
            Attr.ValueType.ShouldBe(typeof(int));

            //////

            Attr = new TestBoundAttribute(Minimum: 1u, Maximum: 2u);

            Attr.Minimum.ShouldBe(Compare: 1u);
            Attr.Maximum.ShouldBe(Compare: 2u);
            Attr.ValueType.ShouldBe(typeof(uint));

            //////

            Attr = new TestBoundAttribute((short) 1, (short) 2);

            Attr.Minimum.ShouldBe((short) 1);
            Attr.Maximum.ShouldBe((short) 2);
            Attr.ValueType.ShouldBe(typeof(short));
            //////

            Attr = new TestBoundAttribute((ushort) 1, (ushort) 2);

            Attr.Minimum.ShouldBe((ushort) 1);
            Attr.Maximum.ShouldBe((ushort) 2);
            Attr.ValueType.ShouldBe(typeof(ushort));


            //////

            Attr = new TestBoundAttribute((byte) 1, (byte) 2);

            Attr.Minimum.ShouldBe((byte) 1);
            Attr.Maximum.ShouldBe((byte) 2);
            Attr.ValueType.ShouldBe(typeof(byte));

            //////

            Attr = new TestBoundAttribute((sbyte) 1, (sbyte) 2);

            Attr.Minimum.ShouldBe((sbyte) 1);
            Attr.Maximum.ShouldBe((sbyte) 2);
            Attr.ValueType.ShouldBe(typeof(sbyte));

            //////

            Attr = new TestBoundAttribute((decimal) 1, (decimal) 2);

            Attr.Minimum.ShouldBe((decimal) 1);
            Attr.Maximum.ShouldBe((decimal) 2);
            Attr.ValueType.ShouldBe(typeof(decimal));

            //////

            Attr = new TestBoundAttribute((double) 1, (double) 2);

            Attr.Minimum.ShouldBe((double) 1);
            Attr.Maximum.ShouldBe((double) 2);
            Attr.ValueType.ShouldBe(typeof(double));

            //////

            Attr = new TestBoundAttribute((float) 1, (float) 2);

            Attr.Minimum.ShouldBe((float) 1);
            Attr.Maximum.ShouldBe((float) 2);
            Attr.ValueType.ShouldBe(typeof(float));


            //////

            /* Attr = new TestBoundAttribute((object)1, (object)2);

             Attr.Minimum.ShouldBe((object)1);
             Attr.Maximum.ShouldBe((object)2);
             Attr.ValueType.ShouldBe(typeof(int));*/
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