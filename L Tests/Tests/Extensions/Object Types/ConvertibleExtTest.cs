using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Tests;
using Xunit;
using Xunit.Abstractions;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class ConvertibleExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] {typeof(ConvertibleExt)};


        [Fact]
        public void Test_ConvertTo()
            {
            const string Test = "-5.5555";

            Func<Type, object> ConvertTo = L.F<Type, object>(Type => Test.ConvertTo(Type));

            ConvertTo(typeof(int)).Should().Be((int?) null);
            ConvertTo(typeof(uint)).Should().Be((uint?) null);
            ConvertTo(typeof(long)).Should().Be((long?) null);
            ConvertTo(typeof(short)).Should().Be((short?) null);
            ConvertTo(typeof(ushort)).Should().Be((ushort?) null);
            ConvertTo(typeof(byte)).Should().Be((byte?) null);
            ConvertTo(typeof(char)).Should().Be((char?) null);

            var Result1 = Test.ConvertTo(typeof(double));
            var Result2 = Test.ConvertTo(typeof(float));

            Result1.Should().Be((double) -5.5555);
            Result2.Should().Be((float) -5.5555);


            const string Test2 = "5";

            Test2.ConvertTo(typeof(int)).Should().Be(5);
            Test2.ConvertTo(typeof(uint)).Should().Be((uint) 5);
            Test2.ConvertTo(typeof(long)).Should().Be((long) 5);
            Test2.ConvertTo(typeof(short)).Should().Be((short) 5);
            Test2.ConvertTo(typeof(ushort)).Should().Be((ushort) 5);
            Test2.ConvertTo(typeof(byte)).Should().Be((byte) 5);
            Test2.ConvertTo(typeof(char)).Should().Be('5');
            Test2.ConvertTo(typeof(string)).Should().Be("5");

            long.MaxValue.ConvertTo<int>().Should().Be(null);
            long.MaxValue.ConvertTo(typeof(int)).Should().Be(null);


            "5.000".ConvertTo(typeof(double)).Should().Be(5d);
            "5.000".ConvertTo(typeof(int)).Should().Be(5);
            }


        [Fact]
        public void Test_ConvertTo_T()
            {
            const string Test = "-5.5555";

            Test.ConvertTo<int>().Should().Be((int?) null);
            Test.ConvertTo<uint>().Should().Be((uint?) null);
            Test.ConvertTo<long>().Should().Be((long?) null);
            Test.ConvertTo<short>().Should().Be((short?) null);
            Test.ConvertTo<ushort>().Should().Be((ushort?) null);
            Test.ConvertTo<byte>().Should().Be((byte?) null);
            Test.ConvertTo<char>().Should().Be((char?) null);

            double? Result1 = Test.ConvertTo<double>();
            float? Result2 = Test.ConvertTo<float>();

            Result1.Should().Be(-5.5555);
            Result2.Should().Be((float) -5.5555);


            const string Test2 = "5";

            Test2.ConvertTo<int>().Should().Be(5);
            Test2.ConvertTo<uint>().Should().Be((uint) 5);
            Test2.ConvertTo<long>().Should().Be((long) 5);
            Test2.ConvertTo<short>().Should().Be((short) 5);
            Test2.ConvertTo<ushort>().Should().Be((ushort) 5);
            Test2.ConvertTo<byte>().Should().Be((byte) 5);
            Test2.ConvertTo<char>().Should().Be('5');
            Test2.ConvertToString().Should().Be("5");

            ConvertibleExt.ConvertTo<int>(null).Should().Be(default(int));

            ConvertibleExt.ConvertToString(null).Should().Be((string) null);

            new BadConverter().ConvertToString().Should().Be((string) null);

            "5.000".ConvertTo<double>().Should().Be(5d);
            "5.000".ConvertTo<int>().Should().Be(5);
            }

        [Fact]
        public void Test_CanConvertTo()
            {
            IConvertible Test = "5";

            new[]
                {
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(true);

            Test = 5.5f;

            new[]
                {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[]
                {
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>(),
                Test.CanConvertTo<int>()
                }.ShouldAllBeEquivalentTo(false);

            Test = -5;

            new[]
                {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[]
                {
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(false);


            Test = -5.5f;

            new[]
                {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[]
                {
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(false);

            Test = null;

            // ReSharper disable ExpressionIsAlwaysNull
            new[]
                {
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>(),
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(false);
            // ReSharper restore ExpressionIsAlwaysNull

            DateTime.Now.CanConvertToString().Should().BeFalse();
            DateTime.Now.Date.CanConvertToString().Should().BeTrue();

            55.0m.CanConvertTo<int>().Should().BeTrue();

            "55000.0".CanConvertTo<double>().Should().BeTrue();
            "55000.0".CanConvertTo<int>().Should().BeTrue();
            "55000.5".CanConvertTo<int>().Should().BeFalse();
            "55000.5".CanConvertTo<double>().Should().BeTrue();

            0.002753.CanConvertTo<decimal>().Should().BeTrue();
            0.002753.CanConvertTo<float>().Should().BeTrue();

            0.0027503.CanConvertTo<decimal>().Should().BeTrue();
            0.0027503.CanConvertTo<float>().Should().BeTrue();

            0.00275003.CanConvertTo<decimal>().Should().BeTrue();
            0.00275003.CanConvertTo<float>().Should().BeTrue();

            0.002750003.CanConvertTo<decimal>().Should().BeTrue();
            0.002750003.CanConvertTo<float>().Should().BeTrue();

            0.0027500003.CanConvertTo<decimal>().Should().BeTrue();
            // Limitations of floating point conversion set in for float
            0.0027500003.CanConvertTo<float>().Should().BeFalse();

            0.00275000003.CanConvertTo<decimal>().Should().BeTrue();
            0.00275000003.CanConvertTo<float>().Should().BeFalse();

            0.002750000003.CanConvertTo<decimal>().Should().BeTrue();
            0.002750000003.CanConvertTo<float>().Should().BeFalse();

            0.0027500000003.CanConvertTo<decimal>().Should().BeTrue();
            0.0027500000003.CanConvertTo<float>().Should().BeFalse();

            0.00275000000003.CanConvertTo<decimal>().Should().BeTrue();
            0.00275000000003.CanConvertTo<float>().Should().BeFalse();

            0.002750000000003.CanConvertTo<decimal>().Should().BeTrue();
            0.002750000000003.CanConvertTo<float>().Should().BeFalse();

            0.0027500000000003.CanConvertTo<decimal>().Should().BeTrue();
            0.0027500000000003.CanConvertTo<float>().Should().BeFalse();

            0.00275000000000003.CanConvertTo<decimal>().Should().BeTrue();
            0.00275000000000003.CanConvertTo<float>().Should().BeFalse();

            // Limitations of floating point conversion set in for double
            0.002750000000000003.CanConvertTo<decimal>().Should().BeFalse();
            0.002750000000000003.CanConvertTo<float>().Should().BeFalse();

            /*0.0027500000000000003.CanConvertTo<decimal>().Should().BeFalse();
            0.0027500000000000003.CanConvertTo<float>().Should().BeFalse();

            0.0027500000000000003m.CanConvertTo<double>().Should().BeTrue();
            0.0027500000000000003m.CanConvertTo<float>().Should().BeTrue();

            0.0027500000000000003f.CanConvertTo<double>().Should().BeTrue();
            0.0027500000000000003f.CanConvertTo<decimal>().Should().BeFalse();*/
            }

        [Fact]
        public void Test_CanConvertTo_Type()
            {
            IConvertible Test = "5";

            new[]
                {
                Test.CanConvertTo(typeof(int)),
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(short)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertTo(typeof(long)),
                Test.CanConvertTo(typeof(byte)),
                Test.CanConvertTo(typeof(char)),
                Test.CanConvertTo(typeof(uint)),
                Test.CanConvertTo(typeof(ushort)),
                Test.CanConvertTo(typeof(ulong))
                }.ShouldAllBeEquivalentTo(true);

            Test = 5.5f;

            new[]
                {
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[]
                {
                Test.CanConvertTo(typeof(ushort)),
                Test.CanConvertTo(typeof(uint)),
                Test.CanConvertTo(typeof(char)),
                Test.CanConvertTo(typeof(short)),
                Test.CanConvertTo(typeof(long)),
                Test.CanConvertTo(typeof(byte)),
                Test.CanConvertTo(typeof(ulong)),
                Test.CanConvertTo(typeof(int))
                }.ShouldAllBeEquivalentTo(false);

            Test = -5;

            new[]
                {
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertTo(typeof(short)),
                Test.CanConvertTo(typeof(long)),
                Test.CanConvertTo(typeof(int)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[]
                {
                Test.CanConvertTo(typeof(ushort)),
                Test.CanConvertTo(typeof(char)),
                Test.CanConvertTo(typeof(uint)),
                Test.CanConvertTo(typeof(byte)),
                Test.CanConvertTo(typeof(ulong))
                }.ShouldAllBeEquivalentTo(false);


            Test = -5.5f;

            new[]
                {
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[]
                {
                Test.CanConvertTo(typeof(short)),
                Test.CanConvertTo(typeof(long)),
                Test.CanConvertTo(typeof(int)),
                Test.CanConvertTo(typeof(ushort)),
                Test.CanConvertTo(typeof(char)),
                Test.CanConvertTo(typeof(uint)),
                Test.CanConvertTo(typeof(byte)),
                Test.CanConvertTo(typeof(ulong))
                }.ShouldAllBeEquivalentTo(false);

            Test = null;

            // ReSharper disable ExpressionIsAlwaysNull
            new[]
                {
                Test.CanConvertTo(typeof(short)),
                Test.CanConvertTo(typeof(long)),
                Test.CanConvertTo(typeof(int)),
                Test.CanConvertTo(typeof(ushort)),
                Test.CanConvertTo(typeof(char)),
                Test.CanConvertTo(typeof(uint)),
                Test.CanConvertTo(typeof(byte)),
                Test.CanConvertTo(typeof(ulong)),
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(false);
            // ReSharper restore ExpressionIsAlwaysNull

            DateTime.Now.CanConvertToString().Should().BeFalse();
            DateTime.Now.Date.CanConvertToString().Should().BeTrue();

            55.0m.CanConvertTo(typeof(int)).Should().BeTrue();

            "55000.0".CanConvertTo(typeof(double)).Should().BeTrue();
            "55000.0".CanConvertTo(typeof(int)).Should().BeTrue();
            "55000.5".CanConvertTo(typeof(int)).Should().BeFalse();
            "55000.5".CanConvertTo(typeof(double)).Should().BeTrue();

            0.002753.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.002753.CanConvertTo(typeof(float)).Should().BeTrue();

            0.0027503.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.0027503.CanConvertTo(typeof(float)).Should().BeTrue();

            0.00275003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.00275003.CanConvertTo(typeof(float)).Should().BeTrue();

            0.002750003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.002750003.CanConvertTo(typeof(float)).Should().BeTrue();

            0.0027500003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            // Limitations of floating point conversion set in for float
            0.0027500003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.00275000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.00275000003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.002750000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.002750000003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.0027500000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.0027500000003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.00275000000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.00275000000003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.002750000000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.002750000000003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.0027500000000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.0027500000000003.CanConvertTo(typeof(float)).Should().BeFalse();

            0.00275000000000003.CanConvertTo(typeof(decimal)).Should().BeTrue();
            0.00275000000000003.CanConvertTo(typeof(float)).Should().BeFalse();

            // Limitations of floating point conversion set in for double
            0.002750000000000003.CanConvertTo(typeof(decimal)).Should().BeFalse();
            0.002750000000000003.CanConvertTo(typeof(float)).Should().BeFalse();

            /*0.0027500000000000003.CanConvertTo<decimal>().Should().BeFalse();
            0.0027500000000000003.CanConvertTo<float>().Should().BeFalse();

            0.0027500000000000003m.CanConvertTo<double>().Should().BeTrue();
            0.0027500000000000003m.CanConvertTo<float>().Should().BeTrue();

            0.0027500000000000003f.CanConvertTo<double>().Should().BeTrue();
            0.0027500000000000003f.CanConvertTo<decimal>().Should().BeFalse();*/
            }

        [Fact]
        public void Test_TryConvertTo()
            {
            IConvertible Test = "5";

            Test.TryConvertTo<short>().Should().Be((short) 5);
            Test.TryConvertTo<long>().Should().Be((long) 5);
            Test.TryConvertTo<int>().Should().Be((int) 5);
            Test.TryConvertTo<ushort>().Should().Be((ushort) 5);
            Test.TryConvertTo<ulong>().Should().Be((ulong) 5);
            Test.TryConvertTo<uint>().Should().Be((uint) 5);
            Test.TryConvertTo<float>().Should().Be((float) 5);
            Test.TryConvertTo<double>().Should().Be((double) 5);
            Test.TryConvertTo<char>().Should().Be('5');
            Test.TryConvertToString().Should().Be("5");

            Test = "-5.5";

            Test.TryConvertTo<short>().Should().Be("-5.5");
            Test.TryConvertTo<long>().Should().Be("-5.5");
            Test.TryConvertTo<int>().Should().Be("-5.5");
            Test.TryConvertTo<ushort>().Should().Be("-5.5");
            Test.TryConvertTo<ulong>().Should().Be("-5.5");
            Test.TryConvertTo<uint>().Should().Be("-5.5");
            Test.TryConvertTo<char>().Should().Be("-5.5");
            Test.TryConvertToString().Should().Be("-5.5");
            Test.TryConvertTo<float>().Should().Be(-5.5f);
            Test.TryConvertTo<double>().Should().Be((double) -5.5);

            Test = null;

            Test.TryConvertToString().Should().Be(null);


            ((string) null).TryConvertToString().Should().Be(null);
            ((string) null).TryConvertTo<int>().Should().Be(null);
            }

        #region Helpers

        /// <exception cref="Exception">Condition.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Test_Internal()
            {
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            var Test = new BadConverter();
            Test.GetTypeCode();
            Test.ToBoolean(null);
            Test.ToChar(null);
            Test.ToSByte(null);
            Test.ToByte(null);
            Test.ToInt16(null);
            Test.ToUInt16(null);
            Test.ToInt32(null);
            Test.ToUInt32(null);
            Test.ToInt64(null);
            Test.ToUInt64(null);
            Test.ToSingle(null);
            Test.ToDouble(null);
            Test.ToDecimal(null);
            Test.ToDateTime(null);
            Test.ToType(null, null);
            L.F(() => Test.ToString(null)).ShouldFail();
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            }

        internal class BadConverter : IConvertible
            {
            public TypeCode GetTypeCode()
                {
                return default(TypeCode);
                }

            public bool ToBoolean([CanBeNull] IFormatProvider Provider)
                {
                return default(bool);
                }

            public char ToChar([CanBeNull] IFormatProvider Provider)
                {
                return default(char);
                }

            public sbyte ToSByte([CanBeNull] IFormatProvider Provider)
                {
                return default(sbyte);
                }

            public byte ToByte([CanBeNull] IFormatProvider Provider)
                {
                return default(byte);
                }

            public short ToInt16([CanBeNull] IFormatProvider Provider)
                {
                return default(short);
                }

            public ushort ToUInt16([CanBeNull] IFormatProvider Provider)
                {
                return default(ushort);
                }

            public int ToInt32([CanBeNull] IFormatProvider Provider)
                {
                return default(int);
                }

            public uint ToUInt32([CanBeNull] IFormatProvider Provider)
                {
                return default(uint);
                }

            public long ToInt64([CanBeNull] IFormatProvider Provider)
                {
                return default(long);
                }

            public ulong ToUInt64([CanBeNull] IFormatProvider Provider)
                {
                return default(ulong);
                }

            public float ToSingle([CanBeNull] IFormatProvider Provider)
                {
                return default(float);
                }

            public double ToDouble([CanBeNull] IFormatProvider Provider)
                {
                return default(double);
                }

            public decimal ToDecimal([CanBeNull] IFormatProvider Provider)
                {
                return default(decimal);
                }

            public DateTime ToDateTime([CanBeNull] IFormatProvider Provider)
                {
                return default(DateTime);
                }

            /// <exception cref="Exception">Condition.</exception>
            public string ToString([CanBeNull] IFormatProvider Provider)
                {
                throw new Exception();
                }

            public object ToType([CanBeNull] Type ConversionType, [CanBeNull] IFormatProvider Provider)
                {
                return default(object);
                }
            }

        #endregion

        public ConvertibleExtTest([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }