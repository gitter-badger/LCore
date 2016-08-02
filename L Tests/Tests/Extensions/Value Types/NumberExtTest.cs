
using LCore.Extensions;
using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Numbers;
using Xunit;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class NumberExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(NumberExt) };


        [Fact]
        
        public void Test_Max()
            {
            ((IComparable)null).Max().Should().Be(null);
            ((IComparable)null).Max(1, 2, 3, 14, 5, 6, 7).Should().Be(14);

            50.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(50);
            5.Max(1, 2, 3, 14, 5, 6, 7).Should().Be(14);

            50.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(50.55);
            5.55.Max(1, 2, 3, 14.55, 5, 6, 7).Should().Be(14.55);

            "zzzbc".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("zzzbc");
            "aab".Max("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("ttt");
            }

        [Fact]
        
        public void Test_Min()
            {
            ((IComparable)null).Min().Should().Be(null);
            ((IComparable)null).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(1);

            50.Min(1, 2, 3, 14, 5, 6, 7).Should().Be(1);
            (-5).Min(1, 2, 3, 14, 5, 6, 7).Should().Be(-5);

            50.55.Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(1);
            (-5.55).Min(1, 2, 3, 14.55, 5, 6, 7).Should().Be(-5.55);

            "_aaa".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("_aaa");
            "ccc".Min("baa", "caff", "acl", "aegeg", "grgg", "ttt").Should().Be("acl");
            }

        [Fact]
        public void Test_NumericalCompare()
            {
            L.Str.CompareNumberString("5", "10").Should().BeLessThan(0);
            L.Str.CompareNumberString("15", "10").Should().BeGreaterThan(0);
            L.Str.CompareNumberString("-5", "10").Should().BeLessThan(0);
            L.Str.CompareNumberString("5", "-10").Should().BeGreaterThan(0);
            L.Str.CompareNumberString("-5", "-10").Should().BeGreaterThan(0);
            L.Str.CompareNumberString("-5", "-5").Should().Be(0);
            L.Str.CompareNumberString("-5000.00000", "-5000.000").Should().Be(0);

            L.Str.CompareNumberString("-5000.000001", "-5000.000").Should().BeLessThan(0);
            L.Str.CompareNumberString("-5000.000001", "-5000.0001").Should().BeGreaterThan(0);


            L.Str.CompareNumberString("55", "501").Should().BeLessThan(0);
            L.Str.CompareNumberString("501", "55").Should().BeGreaterThan(0);

            L.Str.CompareNumberString(int.MaxValue.ToString(), "4").Should().BeGreaterThan(0);
            }

        [Fact]
        public void Test_ScientificNotationConversion()
            {
            L.Num.ScientificNotationToNumber("1.0e5").Should().Be("100000.0");
            }

        [Fact]
        public void Test_Wrap()
            {
            5.Wrap().Should().BeOfType<IntNumber>().And.Be((IntNumber)5);
            5u.Wrap().Should().BeOfType<UIntNumber>().And.Be((UIntNumber)5u);
            5L.Wrap().Should().BeOfType<LongNumber>().And.Be((LongNumber)5L);
            ((short)5).Wrap().Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)5);
            ((ushort)5).Wrap().Should().BeOfType<UShortNumber>().And.Be((UShortNumber)(ushort)5);
            ((byte)5).Wrap().Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)5);
            ((sbyte)5).Wrap().Should().BeOfType<SByteNumber>().And.Be((SByteNumber)(sbyte)5);
            5uL.Wrap().Should().BeOfType<ULongNumber>().And.Be((ULongNumber)5uL);
            5m.Wrap().Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5m);
            ((double)5).Wrap().Should().BeOfType<DoubleNumber>().And.Be((DoubleNumber)5d);
            5f.Wrap().Should().BeOfType<FloatNumber>().And.Be((FloatNumber)5f);

            new TestClass().Wrap().Should().Be(null);
            }

        [Fact]
        public void Test_WrapString()
            {
            ((string)null).Wrap().Should().BeNull();
            "".Wrap().Should().BeNull();

            "0".Wrap().Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)0);
            "5".Wrap().Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)5);
            "5.3".Wrap().Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5.3m);
            "-5".Wrap().Should().BeOfType<SByteNumber>().And.Be((SByteNumber)(sbyte)-5);
            "-5.5".Wrap().Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(-5.5m));
            }

        [Fact]
        public void Test_DecimalPlaces()
            {
            1.DecimalPlaces().Should().Be(0);
            ((short)1).DecimalPlaces().Should().Be(0);
            1L.DecimalPlaces().Should().Be(0);
            1uL.DecimalPlaces().Should().Be(0);
            ((char)0).DecimalPlaces().Should().Be(0);
            ((char)0).DecimalPlaces().Should().Be(0);
            ((byte)0).DecimalPlaces().Should().Be(0);
            ((sbyte)0).DecimalPlaces().Should().Be(0);

            5.5m.DecimalPlaces().Should().Be(1);
            5.50032m.DecimalPlaces().Should().Be(5);
            5.50042032m.DecimalPlaces().Should().Be(8);
            5.501042032m.DecimalPlaces().Should().Be(9);

            (-5.5m).DecimalPlaces().Should().Be(1);
            (-5.50032m).DecimalPlaces().Should().Be(5);
            (-5.50042032m).DecimalPlaces().Should().Be(8);
            (-5.501042032m).DecimalPlaces().Should().Be(9);

            5.5d.DecimalPlaces().Should().Be(1);
            5.50032d.DecimalPlaces().Should().Be(5);
            5.50042032d.DecimalPlaces().Should().Be(8);
            5.501042032d.DecimalPlaces().Should().Be(9);

            (-5.5d).DecimalPlaces().Should().Be(1);
            (-5.50032d).DecimalPlaces().Should().Be(5);
            (-5.50042032d).DecimalPlaces().Should().Be(8);
            (-5.501042032d).DecimalPlaces().Should().Be(9);

            5.5f.DecimalPlaces().Should().Be(1);
            5.50032f.DecimalPlaces().Should().Be(5);
            5.50042032f.DecimalPlaces().Should().Be(5);
            5.501042032f.DecimalPlaces().Should().Be(6);
            (-5.5f).DecimalPlaces().Should().Be(1);
            (-5.50032f).DecimalPlaces().Should().Be(5);
            (-5.50042032f).DecimalPlaces().Should().Be(5);
            (-5.501042032f).DecimalPlaces().Should().Be(6);

            float.MinValue.DecimalPlaces().Should().Be(0);
            double.MinValue.DecimalPlaces().Should().Be(0);
            decimal.MinValue.DecimalPlaces().Should().Be(0);

            float.Epsilon.DecimalPlaces().Should().Be(51);
            double.Epsilon.DecimalPlaces().Should().Be(338);
            ((IConvertible)new DecimalNumber().TypePrecision.GetValue()).ConvertTo<decimal>()?.DecimalPlaces().Should().Be(28);

            50d.DecimalPlaces().Should().Be(0);
            50.0m.DecimalPlaces().Should().Be(0);
            50f.DecimalPlaces().Should().Be(0);
            }
        #region Helpers

        [ExcludeFromCodeCoverage]
        internal struct TestClass : IComparable,
            IComparable<TestClass>,
            IConvertible,
            IEquatable<TestClass>,
            IFormattable
            {
            public int CompareTo(TestClass Obj)
                {
                return 0;
                }

            int IComparable<TestClass>.CompareTo(TestClass Other)
                {
                return this.CompareTo(Other);
                }

            public TypeCode GetTypeCode()
                {
                return default(TypeCode);
                }

            public bool ToBoolean([CanBeNull]IFormatProvider Provider)
                {
                return false;
                }

            public char ToChar([CanBeNull]IFormatProvider Provider)
                {
                return (char)0;
                }

            public sbyte ToSByte([CanBeNull]IFormatProvider Provider)
                {
                return 0;
                }

            public byte ToByte([CanBeNull]IFormatProvider Provider)
                {
                return 0;
                }

            public short ToInt16([CanBeNull]IFormatProvider Provider)
                {
                return 0;
                }

            public ushort ToUInt16([CanBeNull]IFormatProvider Provider)
                {
                return 0;
                }

            public int ToInt32([CanBeNull]IFormatProvider Provider)
                {
                return 0;
                }

            public uint ToUInt32([CanBeNull]IFormatProvider Provider)
                {
                return 0u;
                }

            public long ToInt64([CanBeNull]IFormatProvider Provider)
                {
                return 0L;
                }

            public ulong ToUInt64([CanBeNull]IFormatProvider Provider)
                {
                return 0uL;
                }

            public float ToSingle([CanBeNull]IFormatProvider Provider)
                {
                return 0;
                }

            public double ToDouble([CanBeNull]IFormatProvider Provider)
                {
                return 0d;
                }

            public decimal ToDecimal([CanBeNull]IFormatProvider Provider)
                {
                return 0m;
                }

            public DateTime ToDateTime([CanBeNull]IFormatProvider Provider)
                {
                return DateTime.Now;
                }

            public string ToString([CanBeNull]IFormatProvider Provider)
                {
                return null;
                }

            public object ToType([CanBeNull]Type ConversionType, [CanBeNull]IFormatProvider Provider)
                {
                return null;
                }

            public string ToString([CanBeNull]string Format, [CanBeNull] IFormatProvider FormatProvider)
                {
                return null;
                }

            public int CompareTo([CanBeNull]object Obj)
                {
                return 0;
                }

            public bool Equals(TestClass Other)
                {
                return false;
                }
            }

        #endregion
        }
    }
