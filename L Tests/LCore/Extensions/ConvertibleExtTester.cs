using System;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable ExpressionIsAlwaysNull

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt))]
    public partial class ConvertibleExtTester : XUnitOutputTester, IDisposable
        {
        public ConvertibleExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." +
            nameof(ConvertibleExt.ConvertTo) + "(IConvertible, Type) => Object")]
        public void ConvertTo()
            {
            const string Test = "-5.5555";

            Func<Type, object> ConvertTo = L.F<Type, object>(Type => Test.ConvertTo(Type));

            ConvertTo(typeof(int)).ShouldBe((int?)null);
            ConvertTo(typeof(uint)).ShouldBe((uint?)null);
            ConvertTo(typeof(long)).ShouldBe((long?)null);
            ConvertTo(typeof(short)).ShouldBe((short?)null);
            ConvertTo(typeof(ushort)).ShouldBe((ushort?)null);
            ConvertTo(typeof(byte)).ShouldBe((byte?)null);
            ConvertTo(typeof(char)).ShouldBe((char?)null);

            var Result1 = Test.ConvertTo(typeof(double));
            var Result2 = Test.ConvertTo(typeof(float));

            Result1.ShouldBe((double)-5.5555);
            Result2.ShouldBe((float)-5.5555);


            const string Test2 = "5";

            Test2.ConvertTo(typeof(int)).ShouldBe(Compare: 5);
            Test2.ConvertTo(typeof(uint)).ShouldBe((uint)5);
            Test2.ConvertTo(typeof(long)).ShouldBe((long)5);
            Test2.ConvertTo(typeof(short)).ShouldBe((short)5);
            Test2.ConvertTo(typeof(ushort)).ShouldBe((ushort)5);
            Test2.ConvertTo(typeof(byte)).ShouldBe((byte)5);
            Test2.ConvertTo(typeof(char)).ShouldBe(Compare: '5');
            Test2.ConvertTo(typeof(string)).ShouldBe("5");

            long.MaxValue.ConvertTo<int>().ShouldBe(Compare: null);
            long.MaxValue.ConvertTo(typeof(int)).ShouldBe(Compare: null);


            "5.000".ConvertTo(typeof(double)).ShouldBe(Compare: 5d);
            "5.000".ConvertTo(typeof(int)).ShouldBe(Compare: 5);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." +
            nameof(ConvertibleExt.ConvertTo) + "(IConvertible) => Nullable`1<T>")]
        public void ConvertTo_T()
            {
            const string Test = "-5.5555";

            Test.ConvertTo<int>().ShouldBe((int?)null);
            Test.ConvertTo<uint>().ShouldBe((uint?)null);
            Test.ConvertTo<long>().ShouldBe((long?)null);
            Test.ConvertTo<short>().ShouldBe((short?)null);
            Test.ConvertTo<ushort>().ShouldBe((ushort?)null);
            Test.ConvertTo<byte>().ShouldBe((byte?)null);
            Test.ConvertTo<char>().ShouldBe((char?)null);

            double? Result1 = Test.ConvertTo<double>();
            float? Result2 = Test.ConvertTo<float>();

            Result1.ShouldBe(-5.5555);
            Result2.ShouldBe((float)-5.5555);


            const string Test2 = "5";

            Test2.ConvertTo<int>().ShouldBe(Compare: 5);
            Test2.ConvertTo<uint>().ShouldBe((uint)5);
            Test2.ConvertTo<long>().ShouldBe((long)5);
            Test2.ConvertTo<short>().ShouldBe((short)5);
            Test2.ConvertTo<ushort>().ShouldBe((ushort)5);
            Test2.ConvertTo<byte>().ShouldBe((byte)5);
            Test2.ConvertTo<char>().ShouldBe(Compare: '5');
            Test2.ConvertToString().ShouldBe("5");

            ConvertibleExt.ConvertTo<int>(In: null).ShouldBe(default(int));

            ConvertibleExt.ConvertToString(In: null).ShouldBe((string)null);

            new BadConverter().ConvertToString().ShouldBe((string)null);

            "5.000".ConvertTo<double>().ShouldBe(Compare: 5d);
            "5.000".ConvertTo<int>().ShouldBe(Compare: 5);
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." +
            nameof(ConvertibleExt.CanConvertTo) + "(IConvertible) => Boolean")]
        public void CanConvertTo()
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
                }.ShouldAllBeEquivalentTo(expectation: true);

            Test = 5.5f;

            new[]
                {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(expectation: true);

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
                }.ShouldAllBeEquivalentTo(expectation: false);

            Test = -5;

            new[]
                {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertTo<short>(),
                Test.CanConvertTo<long>(),
                Test.CanConvertTo<int>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(expectation: true);

            new[]
                {
                Test.CanConvertTo<ushort>(),
                Test.CanConvertTo<char>(),
                Test.CanConvertTo<uint>(),
                Test.CanConvertTo<byte>(),
                Test.CanConvertTo<ulong>()
                }.ShouldAllBeEquivalentTo(expectation: false);


            Test = -5.5f;

            new[]
                {
                Test.CanConvertTo<double>(),
                Test.CanConvertTo<float>(),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(expectation: true);

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
                }.ShouldAllBeEquivalentTo(expectation: false);

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
                }.ShouldAllBeEquivalentTo(expectation: false);
            // ReSharper restore ExpressionIsAlwaysNull

            DateTime.Now.CanConvertToString().ShouldBeFalse();
            DateTime.Now.Date.CanConvertToString().ShouldBeTrue();

            55.0m.CanConvertTo<int>().ShouldBeTrue();

            "55000.0".CanConvertTo<double>().ShouldBeTrue();
            "55000.0".CanConvertTo<int>().ShouldBeTrue();
            "55000.5".CanConvertTo<int>().ShouldBeFalse();
            "55000.5".CanConvertTo<double>().ShouldBeTrue();

            0.002753.CanConvertTo<decimal>().ShouldBeTrue();
            0.002753.CanConvertTo<float>().ShouldBeTrue();

            0.0027503.CanConvertTo<decimal>().ShouldBeTrue();
            0.0027503.CanConvertTo<float>().ShouldBeTrue();

            0.00275003.CanConvertTo<decimal>().ShouldBeTrue();
            0.00275003.CanConvertTo<float>().ShouldBeTrue();

            0.002750003.CanConvertTo<decimal>().ShouldBeTrue();
            0.002750003.CanConvertTo<float>().ShouldBeTrue();

            0.0027500003.CanConvertTo<decimal>().ShouldBeTrue();
            // Limitations of floating point conversion set in for float
            0.0027500003.CanConvertTo<float>().ShouldBeFalse();

            0.00275000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.00275000003.CanConvertTo<float>().ShouldBeFalse();

            0.002750000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.002750000003.CanConvertTo<float>().ShouldBeFalse();

            0.0027500000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.0027500000003.CanConvertTo<float>().ShouldBeFalse();

            0.00275000000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.00275000000003.CanConvertTo<float>().ShouldBeFalse();

            0.002750000000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.002750000000003.CanConvertTo<float>().ShouldBeFalse();

            0.0027500000000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.0027500000000003.CanConvertTo<float>().ShouldBeFalse();

            0.00275000000000003.CanConvertTo<decimal>().ShouldBeTrue();
            0.00275000000000003.CanConvertTo<float>().ShouldBeFalse();

            // Limitations of floating point conversion set in for double
            0.002750000000000003.CanConvertTo<decimal>().ShouldBeFalse();
            0.002750000000000003.CanConvertTo<float>().ShouldBeFalse();

            /*0.0027500000000000003.CanConvertTo<decimal>().ShouldBeFalse();
            0.0027500000000000003.CanConvertTo<float>().ShouldBeFalse();

            0.0027500000000000003m.CanConvertTo<double>().ShouldBeTrue();
            0.0027500000000000003m.CanConvertTo<float>().ShouldBeTrue();

            0.0027500000000000003f.CanConvertTo<double>().ShouldBeTrue();
            0.0027500000000000003f.CanConvertTo<decimal>().ShouldBeFalse();*/
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." +
            nameof(ConvertibleExt.CanConvertTo) + "(IConvertible, Type) => Boolean")]
        public void CanConvertTo_Type()
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
                }.ShouldAllBeEquivalentTo(expectation: true);

            Test = 5.5f;

            new[]
                {
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(expectation: true);

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
                }.ShouldAllBeEquivalentTo(expectation: false);

            Test = -5;

            new[]
                {
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertTo(typeof(short)),
                Test.CanConvertTo(typeof(long)),
                Test.CanConvertTo(typeof(int)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(expectation: true);

            new[]
                {
                Test.CanConvertTo(typeof(ushort)),
                Test.CanConvertTo(typeof(char)),
                Test.CanConvertTo(typeof(uint)),
                Test.CanConvertTo(typeof(byte)),
                Test.CanConvertTo(typeof(ulong))
                }.ShouldAllBeEquivalentTo(expectation: false);


            Test = -5.5f;

            new[]
                {
                Test.CanConvertTo(typeof(double)),
                Test.CanConvertTo(typeof(float)),
                Test.CanConvertToString()
                }.ShouldAllBeEquivalentTo(expectation: true);

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
                }.ShouldAllBeEquivalentTo(expectation: false);

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
                }.ShouldAllBeEquivalentTo(expectation: false);
            // ReSharper restore ExpressionIsAlwaysNull

            DateTime.Now.CanConvertToString().ShouldBeFalse();
            DateTime.Now.Date.CanConvertToString().ShouldBeTrue();

            55.0m.CanConvertTo(typeof(int)).ShouldBeTrue();

            "55000.0".CanConvertTo(typeof(double)).ShouldBeTrue();
            "55000.0".CanConvertTo(typeof(int)).ShouldBeTrue();
            "55000.5".CanConvertTo(typeof(int)).ShouldBeFalse();
            "55000.5".CanConvertTo(typeof(double)).ShouldBeTrue();

            0.002753.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.002753.CanConvertTo(typeof(float)).ShouldBeTrue();

            0.0027503.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.0027503.CanConvertTo(typeof(float)).ShouldBeTrue();

            0.00275003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.00275003.CanConvertTo(typeof(float)).ShouldBeTrue();

            0.002750003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.002750003.CanConvertTo(typeof(float)).ShouldBeTrue();

            0.0027500003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            // Limitations of floating point conversion set in for float
            0.0027500003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.00275000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.00275000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.002750000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.002750000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.0027500000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.0027500000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.00275000000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.00275000000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.002750000000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.002750000000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.0027500000000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.0027500000000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            0.00275000000000003.CanConvertTo(typeof(decimal)).ShouldBeTrue();
            0.00275000000000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            // Limitations of floating point conversion set in for double
            0.002750000000000003.CanConvertTo(typeof(decimal)).ShouldBeFalse();
            0.002750000000000003.CanConvertTo(typeof(float)).ShouldBeFalse();

            /*0.0027500000000000003.CanConvertTo<decimal>().ShouldBeFalse();
            0.0027500000000000003.CanConvertTo<float>().ShouldBeFalse();

            0.0027500000000000003m.CanConvertTo<double>().ShouldBeTrue();
            0.0027500000000000003m.CanConvertTo<float>().ShouldBeTrue();

            0.0027500000000000003f.CanConvertTo<double>().ShouldBeTrue();
            0.0027500000000000003f.CanConvertTo<decimal>().ShouldBeFalse();*/
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(ConvertibleExt) + "." +
            nameof(ConvertibleExt.TryConvertTo) + "(IConvertible) => IConvertible")]
        public void TryConvertTo()
            {
            IConvertible Test = "5";

            Test.TryConvertTo<short>().ShouldBe((short)5);
            Test.TryConvertTo<long>().ShouldBe((long)5);
            Test.TryConvertTo<int>().ShouldBe((int)5);
            Test.TryConvertTo<ushort>().ShouldBe((ushort)5);
            Test.TryConvertTo<ulong>().ShouldBe((ulong)5);
            Test.TryConvertTo<uint>().ShouldBe((uint)5);
            Test.TryConvertTo<float>().ShouldBe((float)5);
            Test.TryConvertTo<double>().ShouldBe((double)5);
            Test.TryConvertTo<char>().ShouldBe(Compare: '5');
            Test.TryConvertToString().ShouldBe("5");

            Test = "-5.5";

            Test.TryConvertTo<short>().ShouldBe("-5.5");
            Test.TryConvertTo<long>().ShouldBe("-5.5");
            Test.TryConvertTo<int>().ShouldBe("-5.5");
            Test.TryConvertTo<ushort>().ShouldBe("-5.5");
            Test.TryConvertTo<ulong>().ShouldBe("-5.5");
            Test.TryConvertTo<uint>().ShouldBe("-5.5");
            Test.TryConvertTo<char>().ShouldBe("-5.5");
            Test.TryConvertToString().ShouldBe("-5.5");
            Test.TryConvertTo<float>().ShouldBe(-5.5f);
            Test.TryConvertTo<double>().ShouldBe((double)-5.5);

            Test = null;

            Test.TryConvertToString().ShouldBe(Compare: null);


            ((string)null).TryConvertToString().ShouldBe(Compare: null);
            ((string)null).TryConvertTo<int>().ShouldBe(Compare: null);
            }

        #region Helpers

        /// <exception cref="Exception">Condition.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        public void Internal()
            {
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            var Test = new BadConverter();
            Test.GetTypeCode();
            Test.ToBoolean(Provider: null);
            Test.ToChar(Provider: null);
            Test.ToSByte(Provider: null);
            Test.ToByte(Provider: null);
            Test.ToInt16(Provider: null);
            Test.ToUInt16(Provider: null);
            Test.ToInt32(Provider: null);
            Test.ToUInt32(Provider: null);
            Test.ToInt64(Provider: null);
            Test.ToUInt64(Provider: null);
            Test.ToSingle(Provider: null);
            Test.ToDouble(Provider: null);
            Test.ToDecimal(Provider: null);
            Test.ToDateTime(Provider: null);
            Test.ToType(ConversionType: null, Provider: null);
            L.F(() => Test.ToString(Provider: null)).ShouldFail();
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
        }
    }