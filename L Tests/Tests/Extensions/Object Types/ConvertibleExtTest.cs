
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LCore.Tests;
using static LCore.Extensions.L.Test.Categories;
// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class ConvertibleExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(ConvertibleExt) };

        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_ConvertTo()
            {
            const string Test = "-5.5555";

            Func<Type, object> ConvertTo = L.F<Type, object>(Type => Test.ConvertTo(Type));

            ConvertTo.ShouldFail(typeof(int));
            ConvertTo.ShouldFail(typeof(uint));
            ConvertTo.ShouldFail(typeof(long));
            ConvertTo.ShouldFail(typeof(short));
            ConvertTo.ShouldFail(typeof(ushort));
            ConvertTo.ShouldFail(typeof(byte));
            ConvertTo.ShouldFail(typeof(char));
            ConvertTo.ShouldFail(typeof(byte));

            var Result1 = Test.ConvertTo(typeof(double));
            var Result2 = Test.ConvertTo(typeof(float));

            Result1.Should().Be((double)-5.5555);
            Result2.Should().Be((float)-5.5555);


            const string Test2 = "5";

            Test2.ConvertTo(typeof(int)).Should().Be(5);
            Test2.ConvertTo(typeof(uint)).Should().Be((uint)5);
            Test2.ConvertTo(typeof(long)).Should().Be((long)5);
            Test2.ConvertTo(typeof(short)).Should().Be((short)5);
            Test2.ConvertTo(typeof(ushort)).Should().Be((ushort)5);
            Test2.ConvertTo(typeof(byte)).Should().Be((byte)5);
            Test2.ConvertTo(typeof(char)).Should().Be('5');
            Test2.ConvertTo(typeof(string)).Should().Be("5");

            long.MaxValue.ConvertTo<int>().Should().Be(default(int));
            long.MaxValue.ConvertTo(typeof(int)).Should().Be(null);
            }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_ConvertTo_T()
            {
            const string Test = "-5.5555";

            L.F<IConvertible, int?>(ConvertibleExt.ConvertTo<int>).ShouldFail(Test);
            L.F<IConvertible, uint?>(ConvertibleExt.ConvertTo<uint>).ShouldFail(Test);
            L.F<IConvertible, long?>(ConvertibleExt.ConvertTo<long>).ShouldFail(Test);
            L.F<IConvertible, short?>(ConvertibleExt.ConvertTo<short>).ShouldFail(Test);
            L.F<IConvertible, ushort?>(ConvertibleExt.ConvertTo<ushort>).ShouldFail(Test);
            L.F<IConvertible, byte?>(ConvertibleExt.ConvertTo<byte>).ShouldFail(Test);
            L.F<IConvertible, char?>(ConvertibleExt.ConvertTo<char>).ShouldFail(Test);

            double? Result1 = Test.ConvertTo<double>();
            float? Result2 = Test.ConvertTo<float>();

            Result1.Should().Be(-5.5555);
            Result2.Should().Be((float)-5.5555);


            const string Test2 = "5";

            Test2.ConvertTo<int>().Should().Be(5);
            Test2.ConvertTo<uint>().Should().Be((uint)5);
            Test2.ConvertTo<long>().Should().Be((long)5);
            Test2.ConvertTo<short>().Should().Be((short)5);
            Test2.ConvertTo<ushort>().Should().Be((ushort)5);
            Test2.ConvertTo<byte>().Should().Be((byte)5);
            Test2.ConvertTo<char>().Should().Be('5');
            Test2.ConvertToString().Should().Be("5");

            ConvertibleExt.ConvertTo<int>(null).Should().Be(default(int));

            ConvertibleExt.ConvertToString(null).Should().Be((string)null);

            new BadConverter().ConvertToString().Should().Be((string)null);
            }

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_CanConvertTo()
            {
            IConvertible Test = "5";

            new[] {
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

            new[] {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[] {
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

            new[] {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[] {
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(false);


            Test = -5.5f;

            new[] {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(true);

            new[] {
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
            new[] {
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
            }


        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_TryConvertTo()
            {
            IConvertible Test = "5";

            Test.TryConvertTo<short>().Should().Be((short)5);
            Test.TryConvertTo<long>().Should().Be((long)5);
            Test.TryConvertTo<int>().Should().Be((int)5);
            Test.TryConvertTo<ushort>().Should().Be((ushort)5);
            Test.TryConvertTo<ulong>().Should().Be((ulong)5);
            Test.TryConvertTo<uint>().Should().Be((uint)5);
            Test.TryConvertTo<float>().Should().Be((float)5);
            Test.TryConvertTo<double>().Should().Be((double)5);
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
            Test.TryConvertTo<double>().Should().Be((double)-5.5);

            Test = null;

            Test.TryConvertToString().Should().Be(null);


            ((string)null).TryConvertToString().Should().Be(null);
            ((string)null).TryConvertTo<int>().Should().Be(null);
            }


        #region Helpers

        /// <exception cref="Exception">Condition.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [TestMethod]
        [TestCategory(Internal)]
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

            public bool ToBoolean(IFormatProvider Provider)
                {
                return default(bool);
                }

            public char ToChar(IFormatProvider Provider)
                {
                return default(char);
                }

            public sbyte ToSByte(IFormatProvider Provider)
                {
                return default(sbyte);
                }

            public byte ToByte(IFormatProvider Provider)
                {
                return default(byte);
                }

            public short ToInt16(IFormatProvider Provider)
                {
                return default(short);
                }

            public ushort ToUInt16(IFormatProvider Provider)
                {
                return default(ushort);
                }

            public int ToInt32(IFormatProvider Provider)
                {
                return default(int);
                }

            public uint ToUInt32(IFormatProvider Provider)
                {
                return default(uint);
                }

            public long ToInt64(IFormatProvider Provider)
                {
                return default(long);
                }

            public ulong ToUInt64(IFormatProvider Provider)
                {
                return default(ulong);
                }

            public float ToSingle(IFormatProvider Provider)
                {
                return default(float);
                }

            public double ToDouble(IFormatProvider Provider)
                {
                return default(double);
                }

            public decimal ToDecimal(IFormatProvider Provider)
                {
                return default(decimal);
                }

            public DateTime ToDateTime(IFormatProvider Provider)
                {
                return default(DateTime);
                }

            /// <exception cref="Exception">Condition.</exception>
            public string ToString(IFormatProvider Provider)
                {
                throw new Exception();
                }

            public object ToType(Type ConversionType, IFormatProvider Provider)
                {
                return default(object);
                }
            }
        #endregion
        }
    }
