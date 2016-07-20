
using LCore.Extensions;
using System;
using FluentAssertions;
using LCore.Numbers;
using Xunit;
// ReSharper disable UnusedVariable

// ReSharper disable ThrowingSystemException
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable ConvertToConstant.Local
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests.Tests.Extensions
    {
    public class NumberTest
        {
        /// <exception cref="OverflowException">
        ///         <paramref>
        ///             <name>value</name>
        ///         </paramref>
        ///     is greater than <see cref="F:System.Decimal.MaxValue" /> or less than <see cref="F:System.Decimal.MinValue" />.-or- <paramref>
        ///         <name>value</name>
        ///     </paramref>
        ///     is <see cref="F:System.Double.NaN" />, <see cref="F:System.Double.PositiveInfinity" />, or <see cref="F:System.Double.NegativeInfinity" />. </exception>
        [Fact]
        public void Test_DecimalNumber()
            {
            decimal Dec = new decimal(5.5);

            // Test implicits
            DecimalNumber TempNumber = Dec;
            Dec = TempNumber;

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(decimal));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            TempNumber.GetValuePrecision().Should().Be((DecimalNumber)0.1m);

            TempNumber.Add((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((DecimalNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);

            TempNumber.Add((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);
            }
        [Fact]
        public void Test_DoubleNumber()
            {
            double Dec = 5.5;

            // Test implicits
            DoubleNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(double));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((DoubleNumber)0.1d);

            TempNumber.Add((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((DoubleNumber)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);

            TempNumber.Add((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)10.5);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)0.5);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)27.5);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)(decimal)1.1);
            }
        [Fact]
        public void Test_FloatNumber()
            {
            float Dec = 5f;

            // Test implicits
            FloatNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(float));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((FloatNumber)1f);

            TempNumber.Add((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)10);
            TempNumber.Subtract((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)0);
            TempNumber.Multiply((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)25);
            TempNumber.Divide((FloatNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)1);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)10);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)0);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)25);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)1);
            }
        [Fact]
        public void Test_LongNumber()
            {
            long Dec = 5000000;

            // Test implicits
            LongNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(long));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((LongNumber)1);

            TempNumber.Add((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)5000005);
            TempNumber.Subtract((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)4999995);
            TempNumber.Multiply((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)25000000);
            TempNumber.Divide((LongNumber)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)1000000);

            TempNumber.Add((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)5000005);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)4999995);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)25000000);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<IntNumber>().And.Be((IntNumber)(int)1000000);
            }
        [Fact]
        public void Test_IntNumber()
            {
            int Dec = 65;

            // Test implicits
            IntNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(int));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((IntNumber)1);

            TempNumber.Add((IntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IntNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        [Fact]
        public void Test_UShortNumber()
            {
            ushort Dec = 65;

            // Test implicits
            UShortNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(ushort));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((UShortNumber)1);

            TempNumber.Add((UShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((UShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((UShortNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((UShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        [Fact]
        public void Test_ULongNumber()
            {
            ulong Dec = 65;

            // Test implicits
            ULongNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(ulong));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((ULongNumber)1);

            TempNumber.Add((ULongNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((ULongNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((ULongNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((ULongNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        [Fact]
        public void Test_UIntNumber()
            {
            uint Dec = 65;

            // Test implicits
            UIntNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(uint));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((UIntNumber)1);

            TempNumber.Add((UIntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((UIntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((UIntNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((UIntNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        [Fact]
        public void Test_ShortNumber()
            {
            short Dec = 65;

            // Test implicits
            ShortNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(short));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((ShortNumber)1);

            TempNumber.Add((ShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((ShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((ShortNumber)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((ShortNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)70);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)60);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ShortNumber>().And.Be((ShortNumber)(short)325);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)13);
            }
        [Fact]
        public void Test_ByteNumber()
            {
            byte Dec = 35;

            // Test implicits
            ByteNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(byte));

            TempNumber.New().Should().BeOfType<ByteNumber>().And.Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((ByteNumber)1);

            TempNumber.Add((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)40);
            TempNumber.Subtract((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Multiply((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)175);
            TempNumber.Divide((ByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)7);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)40);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)175);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)7);
            }
        [Fact]
        public void Test_SByteNumber()
            {
            sbyte Dec = 25;

            // Test implicits
            SByteNumber TempNumber = Dec;
            Dec = TempNumber;

            TempNumber.GetHashCode().Should().Be(Dec.GetHashCode());
            TempNumber.NumberType.Should().Be(typeof(sbyte));

            TempNumber.New().Should().Be(TempNumber.DefaultValue);

            INumber Temp2 = TempNumber.New(Dec);
            Temp2.GetValue().Should().Be(Dec);

            TempNumber.GetValuePrecision().Should().Be((SByteNumber)1);

            TempNumber.Add((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Subtract((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)20);
            TempNumber.Multiply((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)125);
            TempNumber.Divide((SByteNumber)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)5);

            TempNumber.Add((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)30);
            TempNumber.Subtract((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)20);
            TempNumber.Multiply((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)125);
            TempNumber.Divide((IConvertible)5).Should().BeOfType<ByteNumber>().And.Be((ByteNumber)(byte)5);

            ((ByteNumber)5 + "3").Should().Be((ByteNumber)8);
            ((ByteNumber)5 + "3.5").Should().Be((FloatNumber)8.5f);

            ((ByteNumber)5 + "3" + "2").Should().Be((ByteNumber)10);
            ((ByteNumber)5 * "5.5" + "3" + "5000.101").Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5030.601m);
            ((ByteNumber)5 * "5.5e4" + "3" + "5000.101").Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)280003.101m);
            
            // ((ByteNumber)5 * "4.0443e-2").Should().Be((FloatNumber)5030.601);
            // ((ByteNumber)5 * "5.5e-3" + "3" + "5000.101").Should().BeOfType<DecimalNumber>().And.Be((DecimalNumber)5030.601m);
            }

        // TODO: L: Number: Implement robust overflow tests.
        }
    }

