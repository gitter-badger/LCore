using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LCore.Interfaces;
using LCore.Numbers;
using LCore.Tests;
// ReSharper disable RedundantCast
// ReSharper disable RedundantExplicitArrayCreation

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for number types:
    /// int, long, short, float, double, etc.
    /// </summary>
    [ExtensionProvider]
    public static class NumberExt
        {
        #region Extensions +

        #region AddEach

        /// <summary>
        /// Adds <paramref name="AddNum" /> to each item in the list <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { null }, 0)]
        [TestResult(new object[] { new int[] { }, 0 }, 0)]
        [TestResult(new object[] { new[] { 1, 2, 3 }, 0 }, new[] { 1, 2, 3 })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, 5 }, new[] { 6, 7, 8 })]
        [TestResult(new object[] { new[] { 1, 2, 3, 55, 55, 5555, 55 }, 5 }, new[] { 6, 7, 8, 60, 60, 5560, 60 })]
        public static List<int> AddEach(this IEnumerable<int> In, int AddNum)
            {
            return In.Collect(i => i + AddNum);
            }
        #endregion

        #region Abs

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>
        /// <exception cref="OverflowException"><paramref name="In" /> equals <see cref="F:System.Int32.MinValue" />. </exception>
        [TestResult(new object[] { int.MinValue + (int)1 }, int.MaxValue)]
        [TestResult(new object[] { int.MaxValue }, int.MaxValue)]
        [TestResult(new object[] { 0 }, 0)]
        [TestResult(new object[] { 1 }, 1)]
        [TestResult(new object[] { -1 }, 1)]
        [TestResult(new object[] { -500 }, 500)]
        [TestResult(new object[] { 500 }, 500)]
        public static int Abs(this int In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>
        /// <exception cref="OverflowException"><paramref name="In" /> equals <see cref="F:System.Int64.MinValue" />. </exception>
        [TestResult(new object[] { long.MinValue + (long)1 }, long.MaxValue)]
        [TestResult(new object[] { long.MaxValue }, long.MaxValue)]
        [TestResult(new object[] { (long)0 }, (long)0)]
        [TestResult(new object[] { (long)1 }, (long)1)]
        [TestResult(new object[] { (long)-1 }, (long)1)]
        [TestResult(new object[] { (long)-500 }, (long)500)]
        [TestResult(new object[] { (long)500 }, (long)500)]
        public static long Abs(this long In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>99
        /// <exception cref="OverflowException"><paramref name="In" /> equals <see cref="F:System.Int16.MinValue" />. </exception>
        [TestResult(new object[] { short.MaxValue }, short.MaxValue)]
        [TestResult(new object[] { (short)0 }, (short)0)]
        [TestResult(new object[] { (short)1 }, (short)1)]
        [TestResult(new object[] { (short)-1 }, (short)1)]
        [TestResult(new object[] { (short)-500 }, (short)500)]
        [TestResult(new object[] { (short)500 }, (short)500)]
        public static short Abs(this short In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { double.MinValue + (double)1 }, double.MaxValue)]
        [TestResult(new object[] { double.MaxValue }, double.MaxValue)]
        [TestResult(new object[] { (double)0 }, (double)0)]
        [TestResult(new object[] { (double)1 }, (double)1)]
        [TestResult(new object[] { (double)-1 }, (double)1)]
        [TestResult(new object[] { (double)-500 }, (double)500)]
        [TestResult(new object[] { (double)500 }, (double)500)]
        public static double Abs(this double In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { float.MinValue + (float)1 }, float.MaxValue)]
        [TestResult(new object[] { float.MaxValue }, float.MaxValue)]
        [TestResult(new object[] { (float)0 }, (float)0)]
        [TestResult(new object[] { (float)1 }, (float)1)]
        [TestResult(new object[] { (float)-1 }, (float)1)]
        [TestResult(new object[] { (float)-500 }, (float)500)]
        [TestResult(new object[] { (float)500 }, (float)500)]
        public static float Abs(this float In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>
        /// <exception cref="OverflowException"><paramref name="In" /> equals <see cref="F:System.SByte.MinValue" />. </exception>
        [TestResult(new object[] { sbyte.MaxValue }, sbyte.MaxValue)]
        [TestResult(new object[] { (sbyte)0 }, (sbyte)0)]
        [TestResult(new object[] { (sbyte)1 }, (sbyte)1)]
        [TestResult(new object[] { (sbyte)-1 }, (sbyte)1)]
        [TestResult(new object[] { (sbyte)-100 }, (sbyte)100)]
        [TestResult(new object[] { (sbyte)100 }, (sbyte)100)]
        public static sbyte Abs(this sbyte In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { (double)0 }, (double)00)]
        [TestResult(new object[] { (double)1 }, (double)1)]
        [TestResult(new object[] { (double)-1 }, (double)1)]
        [TestResult(new object[] { (double)-100 }, (double)100)]
        [TestResult(new object[] { (double)100 }, (double)100)]
        public static decimal Abs(this decimal In)
            {
            return Math.Abs(In);
            }

        #endregion

        #region AsPercent

        /// <summary>
        /// Returns the float <paramref name="In" />, multiplied by 100 and converted to an int.
        /// </summary>
        [TestResult(new object[] { float.MinValue }, -2147483648)]
        [TestResult(new object[] { float.MaxValue }, -2147483648)]
        [TestResult(new object[] { (float)0.0011 }, 0)]
        [TestResult(new object[] { (float)0.011 }, 1)]
        [TestResult(new object[] { (float)0.444 }, 44)]
        [TestResult(new object[] { (float)0.555 }, 55)]
        [TestResult(new object[] { (float)0.555 }, 55)]
        [TestResult(new object[] { (float)0.999 }, 99)]
        public static int AsPercent(this float In)
            {
            return (int)(In * 100);
            }

        /// <summary>
        /// Returns the double <paramref name="In" />, multiplied by 100 and converted to an int.
        /// </summary>
        [TestResult(new object[] { double.MinValue }, -2147483648)]
        [TestResult(new object[] { double.MaxValue }, -2147483648)]
        [TestResult(new object[] { (double)0.0011 }, 0)]
        [TestResult(new object[] { (double).011 }, 1)]
        [TestResult(new object[] { (double).444 }, 44)]
        [TestResult(new object[] { (double).555 }, 55)]
        [TestResult(new object[] { (double).999 }, 99)]
        public static int AsPercent(this double In)
            {
            return (int)(In * 100);
            }

        #endregion

        #region Average

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        [TestResult(new object[] { null }, double.NaN)]
        [TestResult(new object[] { new int[] { } }, double.NaN)]
        [TestResult(new object[] { new[] { 0 } }, (double)0)]
        [TestResult(new object[] { new[] { 1 } }, (double)1)]
        [TestResult(new object[] { new[] { 1, 1 } }, (double)1)]
        [TestResult(new object[] { new[] { 1, 100 } }, (double)50.5)]
        [TestResult(new object[] { new[] { 1, 100, 55, 66 } }, (double)55.5)]
        public static double Average(this IEnumerable<int> In)
            {
            In = In ?? new int[] { };

            IEnumerable<int> Enumerable = In as int[] ?? In.Array();
            return Enumerable.Sum() / (double)Enumerable.Count();
            }

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        [TestResult(new object[] { null }, double.NaN)]
        [TestResult(new object[] { new long[] { } }, double.NaN)]
        [TestResult(new object[] { new long[] { 0 } }, (double)0)]
        [TestResult(new object[] { new long[] { 1 } }, (double)1)]
        [TestResult(new object[] { new long[] { 1, 1 } }, (double)1)]
        [TestResult(new object[] { new long[] { 1, 100 } }, (double)50.5)]
        [TestResult(new object[] { new long[] { 1, 100, 55, 66 } }, (double)55.5)]
        public static double Average(this IEnumerable<long> In)
            {
            In = In ?? new long[] { };

            IEnumerable<long> Enumerable = In as long[] ?? In.Array();
            return Enumerable.Sum() / (double)Enumerable.Count();
            }

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        [TestResult(new object[] { null }, double.NaN)]
        [TestResult(new object[] { new float[] { } }, double.NaN)]
        [TestResult(new object[] { new float[] { 0 } }, (double)0)]
        [TestResult(new object[] { new float[] { 1 } }, (double)1)]
        [TestResult(new object[] { new float[] { 1, 1 } }, (double)1)]
        [TestResult(new object[] { new float[] { 1, 100 } }, (double)50.5)]
        [TestResult(new object[] { new float[] { 1, 100, 55, 66 } }, (double)55.5)]
        public static double Average(this IEnumerable<float> In)
            {
            In = In ?? new float[] { };

            IEnumerable<float> Enumerable = In as float[] ?? In.Array();
            return Enumerable.Sum() / (double)Enumerable.Count();
            }

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        [TestResult(new object[] { null }, double.NaN)]
        [TestResult(new object[] { new double[] { } }, double.NaN)]
        [TestResult(new object[] { new double[] { 0 } }, (double)0)]
        [TestResult(new object[] { new double[] { 1 } }, (double)1)]
        [TestResult(new object[] { new double[] { 1, 1 } }, (double)1)]
        [TestResult(new object[] { new double[] { 1, 100 } }, (double)50.5)]
        [TestResult(new object[] { new double[] { 1, 100, 55, 66 } }, (double)55.5)]
        public static double Average(this IEnumerable<double> In)
            {
            In = In ?? new double[] { };

            IEnumerable<double> Enumerable = In as double[] ?? In.Array();
            return Enumerable.Sum() / Enumerable.Count();
            }

        #endregion

        #region ConvertToBestMatch

        /// <summary>
        /// Converts <paramref name="Number"/> to the most restrictive number type possible
        /// without losing any precision.
        /// </summary>
        [TestedIndirectly]
        public static Number ConvertToBestMatch(this Number Number)
            {
            Number Out = null;
            foreach (var Type in L.Num.NumberTypes.Values)
                {
                if (Out == null ||
                    (Type.MinValue.IsLessThanOrEqual(Number) &&
                    Type.MaxValue.IsGreaterThanOrEqual(Number) &&
                    Type.Precision.IsLessThanOrEqual(Number.GetValuePrecision())))
                    {
                    int Better = 0;
                    if (Out == null || Type.MinValue.IsGreaterThan(Out.MinValue))
                        Better++;
                    if (Out == null || Type.MaxValue.IsLessThan(Out.MaxValue))
                        Better++;
                    if (Out == null || Type.Precision.IsGreaterThan(Out.Precision))
                        Better += 2;

                    if (Better > 1)
                        Out = Type;
                    }
                }

            return Out?.New(Number) ?? Number;
            }

        #endregion

        #region DecimalPlaces
        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this int Int)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this short Short)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this long Long)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this uint UInt)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this ushort UShort)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this ulong ULong)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this char Char)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this byte Byte)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// For non-floating point types this value is always 0.
        /// </summary>
        [Tested]
        // ReSharper disable once UnusedParameter.Global
        public static uint DecimalPlaces(this sbyte Int)
            {
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// </summary>
        [Tested]
        public static ushort DecimalPlaces(this decimal Dec)
            {
            string Out = Dec.ToString("0." + new string('#', 339));

            if (Out.Contains("."))
                {
                Out = Out.After(".").TrimEnd("0");

                return (ushort)Out.Length;
                }
            return 0;
            }

        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// </summary>
        [Tested]
        public static ushort DecimalPlaces(this double Double)
            {
            string Out = Double.ToString("0." + new string('#', 339));

            if (Out.Contains("."))
                {
                Out = Out.After(".").TrimEnd("0");

                return (ushort)Out.Length;
                }
            return 0;
            }


        /// <summary>
        /// Returns the number of decimal places used for the provided number.
        /// </summary>
        [Tested]
        public static ushort DecimalPlaces(this float Float)
            {
            string Out = Float.ToString("0." + new string('#', 339));

            if (Out.Contains("."))
                {
                Out = Out.After(".").TrimEnd("0");

                return (ushort)Out.Length;
                }
            return 0;
            }

        #endregion

        #region Floor

        /// <summary>
        /// Returns the floor of the float <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { null }, 0)]
        [TestResult(new object[] { (float)1 }, (int)1)]
        [TestResult(new object[] { (float)1.01 }, (int)1)]
        [TestResult(new object[] { (float)1.9999999 }, (int)1)]
        [TestResult(new object[] { (float)-1.9999999 }, (int)-2)]
        [TestResult(new object[] { (float)-1.0000001 }, (int)-2)]
        public static int Floor(this float In)
            {
            return (int)Math.Floor(In);
            }

        /// <summary>
        /// Returns the floor of the float <paramref name="In" />.
        /// <paramref name="Decimals" /> must be at least 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Decimals" /> was less than 0.</exception>
        [TestFails(new object[] { (float)1, (int)-1 })]
        [TestResult(new object[] { null, 0 }, (float)0)]
        [TestResult(new object[] { (float)1, 0 }, (float)1)]
        [TestResult(new object[] { (float)1.01, 0 }, (float)1)]
        [TestResult(new object[] { (float)1.9999999, 0 }, (float)1)]
        [TestResult(new object[] { (float)-1.9999999, 0 }, (float)-2)]
        [TestResult(new object[] { (float)-1.0000001, 0 }, (float)-2)]
        [TestResult(new object[] { null, 1 }, (float)0)]
        [TestResult(new object[] { (float)1, 1 }, (float)1.0)]
        [TestResult(new object[] { (float)1.01, 1 }, (float)1.0)]
        [TestResult(new object[] { (float)1.9999999, 1 }, (float)1.9)]
        [TestResult(new object[] { (float)-1.9999999, 1 }, (float)-2)]
        [TestResult(new object[] { (float)-1.0000001, 1 }, (float)-1.1)]
        [TestResult(new object[] { null, 2 }, (float)0)]
        [TestResult(new object[] { (float)1, 2 }, (float)1.00)]
        [TestResult(new object[] { (float)1.01, 2 }, (float)1.01)]
        [TestResult(new object[] { (float)1.9999999, 2 }, (float)1.99)]
        [TestResult(new object[] { (float)-1.9999999, 2 }, (float)-2.00)]
        [TestResult(new object[] { (float)-1.0000001, 2 }, (float)-1.01)]
        public static float Floor(this float In, int Decimals)
            {
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            float Power = (float)Math.Pow(10, Decimals);
            float Out = (int)Math.Floor(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }

        /// <summary>
        /// Returns the floor of the double <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { null }, (long)0)]
        [TestResult(new object[] { (double)1 }, (long)1)]
        [TestResult(new object[] { (double)1.01 }, (long)1)]
        [TestResult(new object[] { (double)1.9999999 }, (long)1)]
        [TestResult(new object[] { (double)-1.9999999 }, (long)-2)]
        [TestResult(new object[] { (double)-1.0000001 }, (long)-2)]
        public static long Floor(this double In)
            {
            return (long)Math.Floor(In);
            }

        /// <summary>
        /// Returns the floor of the float <paramref name="In" />.
        /// <paramref name="Decimals" /> must be at least 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Decimals" /> was less than 0.</exception>
        [TestFails(new object[] { (double)1, (int)-1 })]
        [TestResult(new object[] { null, 0 }, (double)0)]
        [TestResult(new object[] { (double)1, 0 }, (double)1)]
        [TestResult(new object[] { (double)1.01, 0 }, (double)1)]
        [TestResult(new object[] { (double)1.9999999, 0 }, (double)1)]
        [TestResult(new object[] { (double)-1.9999999, 0 }, (double)-2)]
        [TestResult(new object[] { (double)-1.0000001, 0 }, (double)-2)]
        [TestResult(new object[] { null, 1 }, (double)0)]
        [TestResult(new object[] { (double)1, 1 }, (double)1.0)]
        [TestResult(new object[] { (double)1.01, 1 }, (double)1.0)]
        [TestResult(new object[] { (double)1.9999999, 1 }, (double)1.9)]
        [TestResult(new object[] { (double)-1.9999999, 1 }, (double)-2)]
        [TestResult(new object[] { (double)-1.0000001, 1 }, (double)-1.1)]
        [TestResult(new object[] { null, 2 }, (double)0)]
        [TestResult(new object[] { (double)1, 2 }, (double)1.00)]
        [TestResult(new object[] { (double)1.01, 2 }, (double)1.01)]
        [TestResult(new object[] { (double)1.9999999, 2 }, (double)1.99)]
        [TestResult(new object[] { (double)-1.9999999, 2 }, (double)-2.00)]
        [TestResult(new object[] { (double)-1.0000001, 2 }, (double)-1.01)]
        public static double Floor(this double In, int Decimals)
            {
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            double Power = Math.Pow(10, Decimals);
            double Out = (int)Math.Floor(In * Power);
            double Out2 = Out / Power;
            return Out2;
            }

        #endregion

        #region IsEven

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { int.MinValue }, true)]
        [TestResult(new object[] { int.MinValue }, true)]
        [TestResult(new object[] { 0 }, true)]
        [TestResult(new object[] { 1 }, false)]
        [TestResult(new object[] { -1 }, false)]
        [TestResult(new object[] { 55 }, false)]
        [TestResult(new object[] { -55 }, false)]
        [TestResult(new object[] { 2 }, true)]
        [TestResult(new object[] { 10 }, true)]
        [TestResult(new object[] { -2 }, true)]
        [TestResult(new object[] { -10 }, true)]
        public static bool IsEven(this int In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { long.MinValue }, true)]
        [TestResult(new object[] { long.MinValue }, true)]
        [TestResult(new object[] { (long)0 }, true)]
        [TestResult(new object[] { (long)1 }, false)]
        [TestResult(new object[] { (long)-1 }, false)]
        [TestResult(new object[] { (long)55 }, false)]
        [TestResult(new object[] { (long)-55 }, false)]
        [TestResult(new object[] { (long)2 }, true)]
        [TestResult(new object[] { (long)10 }, true)]
        [TestResult(new object[] { (long)-2 }, true)]
        [TestResult(new object[] { (long)-10 }, true)]
        public static bool IsEven(this long In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { short.MinValue }, true)]
        [TestResult(new object[] { short.MinValue }, true)]
        [TestResult(new object[] { (short)0 }, true)]
        [TestResult(new object[] { (short)1 }, false)]
        [TestResult(new object[] { (short)-1 }, false)]
        [TestResult(new object[] { (short)55 }, false)]
        [TestResult(new object[] { (short)-55 }, false)]
        [TestResult(new object[] { (short)2 }, true)]
        [TestResult(new object[] { (short)10 }, true)]
        [TestResult(new object[] { (short)-2 }, true)]
        [TestResult(new object[] { (short)-10 }, true)]
        public static bool IsEven(this short In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { uint.MinValue }, true)]
        [TestResult(new object[] { uint.MinValue }, true)]
        [TestResult(new object[] { (uint)0 }, true)]
        [TestResult(new object[] { (uint)1 }, false)]
        [TestResult(new object[] { (uint)55 }, false)]
        [TestResult(new object[] { (uint)2 }, true)]
        [TestResult(new object[] { (uint)10 }, true)]
        public static bool IsEven(this uint In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { ulong.MinValue }, true)]
        [TestResult(new object[] { ulong.MinValue }, true)]
        [TestResult(new object[] { (ulong)0 }, true)]
        [TestResult(new object[] { (ulong)1 }, false)]
        [TestResult(new object[] { (ulong)55 }, false)]
        [TestResult(new object[] { (ulong)2 }, true)]
        [TestResult(new object[] { (ulong)10 }, true)]
        public static bool IsEven(this ulong In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { byte.MinValue }, true)]
        [TestResult(new object[] { byte.MinValue }, true)]
        [TestResult(new object[] { (byte)0 }, true)]
        [TestResult(new object[] { (byte)1 }, false)]
        [TestResult(new object[] { (byte)55 }, false)]
        [TestResult(new object[] { (byte)2 }, true)]
        [TestResult(new object[] { (byte)10 }, true)]
        public static bool IsEven(this byte In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        [TestResult(new object[] { sbyte.MinValue }, true)]
        [TestResult(new object[] { sbyte.MinValue }, true)]
        [TestResult(new object[] { (sbyte)0 }, true)]
        [TestResult(new object[] { (sbyte)1 }, false)]
        [TestResult(new object[] { (sbyte)-1 }, false)]
        [TestResult(new object[] { (sbyte)55 }, false)]
        [TestResult(new object[] { (sbyte)-55 }, false)]
        [TestResult(new object[] { (sbyte)2 }, true)]
        [TestResult(new object[] { (sbyte)10 }, true)]
        [TestResult(new object[] { (sbyte)-2 }, true)]
        [TestResult(new object[] { (sbyte)-10 }, true)]
        public static bool IsEven(this sbyte In)
            {
            return In % 2 == 0;
            }

        #endregion

        #region PercentageOf
        /// <summary>
        /// Returns an int, representing a percent (<paramref name="In" /> / <paramref name="Total" />).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Total" /> was equal to 0.</exception>
        [TestFails(new object[] { 5, 0 })]
        [TestResult(new object[] { 5, 1 }, 500)]
        [TestResult(new object[] { 5, 100 }, 5)]
        [TestResult(new object[] { 22, 5 }, 440)]
        [TestResult(new object[] { -22, 5 }, -440)]
        public static int PercentageOf(this float In, float Total)
            {
            if (Total == 0) throw new ArgumentOutOfRangeException(nameof(Total));

            return ((double)In / Total).AsPercent();
            }

        /// <summary>
        /// Returns an int, representing a percent (<paramref name="In" /> / <paramref name="Total" />).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Total" /> was equal to 0.</exception>
        [TestFails(new object[] { 5d, 0d })]
        [TestResult(new object[] { 5d, 1d }, 500)]
        [TestResult(new object[] { 5d, 100d }, 5)]
        [TestResult(new object[] { 22d, 5d }, 440)]
        [TestResult(new object[] { -22d, 5d }, -440)]
        public static int PercentageOf(this double In, double Total)
            {
            if (Total == 0) throw new ArgumentOutOfRangeException(nameof(Total));

            return ((double)In / Total).AsPercent();
            }

        /// <summary>
        /// Returns an int, representing a percent (<paramref name="In" /> / <paramref name="Total" />).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Total" /> was equal to than 0.</exception>
        [TestFails(new object[] { 5, 0 })]
        [TestResult(new object[] { 5, 1 }, 500)]
        [TestResult(new object[] { 5, 100 }, 5)]
        [TestResult(new object[] { 22, 5 }, 440)]
        [TestResult(new object[] { -22, 5 }, -440)]
        public static int PercentageOf(this int In, int Total)
            {
            if (Total == 0) throw new ArgumentOutOfRangeException(nameof(Total));

            return ((double)In / Total).AsPercent();
            }

        /// <summary>
        /// Returns an int, representing a percent (<paramref name="In" /> / <paramref name="Total" />).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Total" /> was equal to than 0.</exception>
        [TestFails(new object[] { (uint)5, (uint)0 })]
        [TestResult(new object[] { (uint)5, (uint)1 }, 500)]
        [TestResult(new object[] { (uint)5, (uint)100 }, 5)]
        [TestResult(new object[] { (uint)22, (uint)5 }, 440)]
        public static int PercentageOf(this uint In, uint Total)
            {
            if (Total == 0) throw new ArgumentOutOfRangeException(nameof(Total));

            return ((double)In / Total).AsPercent();
            }

        /// <summary>
        /// Returns an int, representing a percent (<paramref name="In" /> / <paramref name="Total" />).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Total" /> was equal to 0.</exception>
        [TestFails(new object[] { (short)5, (short)0 })]
        [TestResult(new object[] { (short)5, (short)1 }, 500)]
        [TestResult(new object[] { (short)5, (short)100 }, 5)]
        [TestResult(new object[] { (short)22, (short)5 }, 440)]
        [TestResult(new object[] { (short)-22, (short)5 }, -440)]
        public static int PercentageOf(this short In, short Total)
            {
            if (Total == 0) throw new ArgumentOutOfRangeException(nameof(Total));

            return ((double)In / Total).AsPercent();
            }
        /// <summary>
        /// Returns an int, representing a percent (<paramref name="In" /> / <paramref name="Total" />).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Total" /> was equal to 0.</exception>
        [TestFails(new object[] { 5L, 0L })]
        [TestResult(new object[] { 5L, 1L }, 500)]
        [TestResult(new object[] { 5L, 100L }, 5)]
        [TestResult(new object[] { 22L, 5L }, 440)]
        [TestResult(new object[] { -22L, 5L }, -440)]
        public static int PercentageOf(this long In, long Total)
            {
            if (Total == 0) throw new ArgumentOutOfRangeException(nameof(Total));

            return ((double)In / Total).AsPercent();
            }
        #endregion

        #region Pow

        /// <summary>
        /// Raise <paramref name="Double"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { 0d, 0d }, 1d)]
        [TestResult(new object[] { 1d, 0d }, 1d)]
        [TestResult(new object[] { 2d, 1d }, 2d)]
        [TestResult(new object[] { 2d, -1d }, 0.5d)]
        [TestResult(new object[] { 2.32552d, -1.12421d }, 0.38721704119787403d)]
        [TestResult(new object[] { 2.32552d, 2.12421d }, 6.00572741531699d)]
        [TestResult(new object[] { 5d, 2d }, 25d)]
        [TestResult(new object[] { 5d, 5d }, 3125d)]
        [TestResult(new object[] { -5d, 2d }, 25d)]
        [TestResult(new object[] { -5d, 5d }, -3125d)]
        [TestResult(new object[] { -2.32552d, 2.12421d }, double.NaN)]
        [TestResult(new object[] { -2.32552d, -1.12421d }, double.NaN)]
        public static double Pow(this double Double, double Power)
            {
            return Math.Pow(Double, Power);
            }
        /// <summary>
        /// Raise <paramref name="Int"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { 0, 0 }, 1d)]
        [TestResult(new object[] { 1, 0 }, 1d)]
        [TestResult(new object[] { 2, 1 }, 2d)]
        [TestResult(new object[] { 2, -1 }, 0.5d)]
        [TestResult(new object[] { 5, 2 }, 25d)]
        [TestResult(new object[] { 5, 5d }, 3125d)]
        [TestResult(new object[] { -5, 2d }, 25d)]
        [TestResult(new object[] { -5, 5d }, -3125d)]
        public static double Pow(this int Int, double Power)
            {
            return Math.Pow(Int, Power);
            }
        /// <summary>
        /// Raise <paramref name="Int"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { 0u, 0d }, 1d)]
        [TestResult(new object[] { 1u, 0d }, 1d)]
        [TestResult(new object[] { 2u, 1d }, 2d)]
        [TestResult(new object[] { 2u, -1d }, 0.5d)]
        [TestResult(new object[] { 5u, 2d }, 25d)]
        [TestResult(new object[] { 5u, 5d }, 3125d)]
        public static double Pow(this uint Int, double Power)
            {
            return Math.Pow(Int, Power);
            }
        /// <summary>
        /// Raise <paramref name="Short"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { (short)0, 0d }, 1d)]
        [TestResult(new object[] { (short)1, 0d }, 1d)]
        [TestResult(new object[] { (short)2, 1d }, 2d)]
        [TestResult(new object[] { (short)2, -1d }, 0.5d)]
        [TestResult(new object[] { (short)5, 2d }, 25d)]
        [TestResult(new object[] { (short)5, 5d }, 3125d)]
        [TestResult(new object[] { (short)-5, 5d }, -3125d)]
        public static double Pow(this short Short, double Power)
            {
            return Math.Pow(Short, Power);
            }
        /// <summary>
        /// Raise <paramref name="UShort"/> to the power of <paramref name="Power"/>.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static double Pow(this ushort UShort, double Power)
            {
            return Math.Pow(UShort, Power);
            }
        /// <summary>
        /// Raise <paramref name="Long"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { 0L, 0d }, 1d)]
        [TestResult(new object[] { 1L, 0d }, 1d)]
        [TestResult(new object[] { 2L, 1d }, 2d)]
        [TestResult(new object[] { 2L, -1d }, 0.5d)]
        [TestResult(new object[] { 5L, 2d }, 25d)]
        [TestResult(new object[] { 5L, 5d }, 3125d)]
        [TestResult(new object[] { -5L, 5d }, -3125d)]
        public static double Pow(this long Long, double Power)
            {
            return Math.Pow(Long, Power);
            }
        /// <summary>
        /// Raise <paramref name="Long"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { 0uL, 0d }, 1d)]
        [TestResult(new object[] { 1uL, 0d }, 1d)]
        [TestResult(new object[] { 2uL, 1d }, 2d)]
        [TestResult(new object[] { 2uL, -1d }, 0.5d)]
        [TestResult(new object[] { 5uL, 2d }, 25d)]
        [TestResult(new object[] { 5uL, 5d }, 3125d)]
        // ReSharper disable once UnusedParameter.Global
        public static double Pow(this ulong Long, double Power)
            {
            return Math.Pow(Long, Power);
            }
        /// <summary>
        /// Raise <paramref name="Long"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { (sbyte)0, 0d }, 1d)]
        [TestResult(new object[] { (sbyte)1, 0d }, 1d)]
        [TestResult(new object[] { (sbyte)2, 1d }, 2d)]
        [TestResult(new object[] { (sbyte)2, -1d }, 0.5d)]
        [TestResult(new object[] { (sbyte)5, 2d }, 25d)]
        [TestResult(new object[] { (sbyte)5, 5d }, 3125d)]
        [TestResult(new object[] { (sbyte)-5, 5d }, -3125d)]
        // ReSharper disable once UnusedParameter.Global
        public static double Pow(this sbyte Long, double Power)
            {
            return Math.Pow(Long, Power);
            }
        /// <summary>
        /// Raise <paramref name="Byte"/> to the power of <paramref name="Power"/>.
        /// </summary>
        [TestResult(new object[] { (byte)0, 0d }, 1d)]
        [TestResult(new object[] { (byte)1, 0d }, 1d)]
        [TestResult(new object[] { (byte)2, 1d }, 2d)]
        [TestResult(new object[] { (byte)2, -1d }, 0.5d)]
        [TestResult(new object[] { (byte)5, 2d }, 25d)]
        [TestResult(new object[] { (byte)5, 5d }, 3125d)]
        public static double Pow(this byte Byte, double Power)
            {
            return Math.Pow(Byte, Power);
            }

        #endregion

        #region Round

        /// <summary>
        /// Returns the rounded integer of the float <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { null }, 0)]
        [TestResult(new object[] { (float)1 }, (int)1)]
        [TestResult(new object[] { (float)1.01 }, (int)1)]
        [TestResult(new object[] { (float)1.9999999 }, (int)2)]
        [TestResult(new object[] { (float)-1.9999999 }, (int)-2)]
        [TestResult(new object[] { (float)-1.0000001 }, (int)-1)]
        public static int Round(this float In)
            {
            return (int)Math.Round(In);
            }

        /// <summary>
        /// Returns the rounded integer of the float <paramref name="In" />
        /// <paramref name="Decimals" /> must be at least 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Decimals was less than 0.</exception>
        [TestFails(new object[] { (float)1, (int)-1 })]
        [TestResult(new object[] { null, 0 }, (float)0)]
        [TestResult(new object[] { (float)1, 0 }, (float)1)]
        [TestResult(new object[] { (float)1.01, 0 }, (float)1)]
        [TestResult(new object[] { (float)1.9999999, 0 }, (float)2)]
        [TestResult(new object[] { (float)-1.9999999, 0 }, (float)-2)]
        [TestResult(new object[] { (float)-1.0000001, 0 }, (float)-1)]
        [TestResult(new object[] { null, 1 }, (float)0)]
        [TestResult(new object[] { (float)1, 1 }, (float)1.0)]
        [TestResult(new object[] { (float)1.01, 1 }, (float)1.0)]
        [TestResult(new object[] { (float)1.9999999, 1 }, (float)2)]
        [TestResult(new object[] { (float)-1.9999999, 1 }, (float)-2)]
        [TestResult(new object[] { (float)-1.0000001, 1 }, (float)-1)]
        [TestResult(new object[] { null, 2 }, (float)0)]
        [TestResult(new object[] { (float)1, 2 }, (float)1.00)]
        [TestResult(new object[] { (float)1.01, 2 }, (float)1.01)]
        [TestResult(new object[] { (float)1.9999999, 2 }, (float)2)]
        [TestResult(new object[] { (float)-1.9999999, 2 }, (float)-2.00)]
        [TestResult(new object[] { (float)-1.0000001, 2 }, (float)-1.0)]
        public static float Round(this float In, int Decimals)
            {
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            float Power = (float)Math.Pow(10, Decimals);
            float Out = (int)Math.Round(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }

        /// <summary>
        /// Returns the rounded integer of the double <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { null }, (long)0)]
        [TestResult(new object[] { (double)1 }, (long)1)]
        [TestResult(new object[] { (double)1.01 }, (long)1)]
        [TestResult(new object[] { (double)1.9999999 }, (long)2)]
        [TestResult(new object[] { (double)-1.9999999 }, (long)-2)]
        [TestResult(new object[] { (double)-1.0000001 }, (long)-1)]
        public static long Round(this double In)
            {
            return (long)Math.Round(In);
            }

        /// <summary>
        /// Returns the rounded integer of the double <paramref name="In" />
        /// <paramref name="Decimals" /> must be at least 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Decimals was less than 0.</exception>
        [TestFails(new object[] { (double)1, (int)-1 })]
        [TestResult(new object[] { null, 0 }, (double)0)]
        [TestResult(new object[] { (double)1, 0 }, (double)1)]
        [TestResult(new object[] { (double)1.01, 0 }, (double)1)]
        [TestResult(new object[] { (double)1.9999999, 0 }, (double)2)]
        [TestResult(new object[] { (double)-1.9999999, 0 }, (double)-2)]
        [TestResult(new object[] { (double)-1.0000001, 0 }, (double)-1)]
        [TestResult(new object[] { null, 1 }, (double)0)]
        [TestResult(new object[] { (double)1, 1 }, (double)1.0)]
        [TestResult(new object[] { (double)1.01, 1 }, (double)1.0)]
        [TestResult(new object[] { (double)1.9999999, 1 }, (double)2)]
        [TestResult(new object[] { (double)-1.9999999, 1 }, (double)-2)]
        [TestResult(new object[] { (double)-1.0000001, 1 }, (double)-1)]
        [TestResult(new object[] { null, 2 }, (double)0)]
        [TestResult(new object[] { (double)1, 2 }, (double)1.00)]
        [TestResult(new object[] { (double)1.01, 2 }, (double)1.01)]
        [TestResult(new object[] { (double)1.9999999, 2 }, (double)2)]
        [TestResult(new object[] { (double)-1.9999999, 2 }, (double)-2.00)]
        [TestResult(new object[] { (double)-1.0000001, 2 }, (double)-1)]
        public static double Round(this double In, int Decimals)
            {
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            double Power = Math.Pow(10, Decimals);
            double Out = (int)Math.Round(In * Power);
            double Out2 = Out / Power;
            return Out2;
            }

        /// <summary>
        /// Returns the rounded integer of the float <paramref name="In" />
        /// </summary>
        /// <exception cref="OverflowException">The result is outside the range of a <see cref="T:System.Decimal" />.</exception>
        public static long Round(this decimal In)
            {
            return (long)Math.Round(In);
            }

        /// <summary>
        /// Returns the rounded integer of the float <paramref name="In" />
        /// <paramref name="Decimals" /> must be at least 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Decimals was less than 0.</exception>
        public static double Round(this decimal In, int Decimals)
            {
            if (Decimals < 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            double Power = Math.Pow(10, Decimals);
            double Out = (int)Math.Round((double)In * Power);
            double Out2 = Out / Power;
            return Out2;
            }
        #endregion

        #region SquareRoot

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (int)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { 1 }, (double)1)]
        [TestResult(new object[] { 66 }, (double)8.12403840463596)]
        [TestResult(new object[] { 567 }, (double)23.811761799581316)]
        public static double Sqrt(this int In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (int)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (long)1 }, (double)1)]
        [TestResult(new object[] { (long)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (long)567 }, (double)23.811761799581316)]
        public static double Sqrt(this long In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (short)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (short)1 }, (double)1)]
        [TestResult(new object[] { (short)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (short)567 }, (double)23.811761799581316)]
        public static double Sqrt(this short In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (double)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (double)1 }, (double)1)]
        [TestResult(new object[] { (double)1.5 }, (double)1.2247448713915889)]
        [TestResult(new object[] { (double)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (double)567 }, (double)23.811761799581316)]
        [TestResult(new object[] { (double)567.646 }, (double)23.825322663082655)]
        public static double Sqrt(this double In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (float)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (float)1 }, (double)1)]
        [TestResult(new object[] { (float)1.5 }, (double)1.2247448713915889)]
        [TestResult(new object[] { (float)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (float)567 }, (double)23.811761799581316)]
        [TestResult(new object[] { (float)567.646 }, (double)23.8253225811058)]
        public static double Sqrt(this float In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (uint)1 }, (double)1)]
        [TestResult(new object[] { (uint)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (uint)567 }, (double)23.811761799581316)]
        public static double Sqrt(this uint In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (ulong)1 }, (double)1)]
        [TestResult(new object[] { (ulong)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (ulong)567 }, (double)23.811761799581316)]
        public static double Sqrt(this ulong In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (ushort)1 }, (double)1)]
        [TestResult(new object[] { (ushort)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (ushort)567 }, (double)23.811761799581316)]
        public static double Sqrt(this ushort In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (byte)1 }, (double)1)]
        [TestResult(new object[] { (byte)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (byte)244 }, (double)15.620499351813308)]
        public static double Sqrt(this byte In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (sbyte)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (sbyte)1 }, (double)1)]
        [TestResult(new object[] { (sbyte)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (sbyte)124 }, (double)11.135528725660043)]
        // ReSharper disable once UnusedParameter.Global
        public static double Sqrt(this sbyte In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        [TestResult(new object[] { (double)-1 }, double.NaN)]
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { (double)1 }, (double)1)]
        [TestResult(new object[] { (double)66 }, (double)8.12403840463596)]
        [TestResult(new object[] { (double)244 }, (double)15.620499351813308)]
        public static double Sqrt(this decimal In)
            {
            return Math.Sqrt((double)In);
            }

        #endregion

        #region SubtractEach

        /// <summary>
        /// Subtracts <paramref name="SubtractNum" /> to each item in the list <paramref name="In" />
        /// </summary>
        [TestResult(new object[] { null }, 0)]
        [TestResult(new object[] { new int[] { }, 0 }, 0)]
        [TestResult(new object[] { new[] { 1, 2, 3 }, 0 }, new[] { 1, 2, 3 })]
        [TestResult(new object[] { new[] { 1, 2, 3 }, 5 }, new[] { -4, -3, -2 })]
        [TestResult(new object[] { new[] { 1, 2, 3, 55, 55, 5555, 55 }, 5 }, new[] { -4, -3, -2, 50, 50, 5550, 50 })]
        public static List<int> SubtractEach(this List<int> In, int SubtractNum)
            {
            return In.AddEach(-SubtractNum);
            }

        #endregion

        #region Sum

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        [TestResult(new object[] { null }, 0)]
        [TestResult(new object[] { new int[] { } }, 0)]
        [TestResult(new object[] { new[] { 0 } }, 0)]
        [TestResult(new object[] { new[] { 1 } }, 1)]
        [TestResult(new object[] { new[] { 1, 2, 3 } }, 6)]
        public static int Sum(this IEnumerable<int> In)
            {
            int Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        [TestResult(new object[] { null }, (long)0)]
        [TestResult(new object[] { new long[] { } }, (long)0)]
        [TestResult(new object[] { new long[] { 0 } }, (long)0)]
        [TestResult(new object[] { new long[] { 1 } }, (long)1)]
        [TestResult(new object[] { new long[] { 1, 2, 3 } }, (long)6)]
        public static long Sum(this IEnumerable<long> In)
            {
            long Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        [TestResult(new object[] { null }, 0f)]
        [TestResult(new object[] { new float[] { } }, 0f)]
        [TestResult(new object[] { new float[] { 0 } }, 0f)]
        [TestResult(new object[] { new float[] { 1 } }, 1f)]
        [TestResult(new object[] { new float[] { 1, 2, 3 } }, 6f)]
        [TestResult(new object[] { new float[] { 1, 2.44f, 3.33f } }, 6.77f)]
        public static float Sum(this IEnumerable<float> In)
            {
            float Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        [TestResult(new object[] { null }, (double)0)]
        [TestResult(new object[] { new double[] { } }, (double)0)]
        [TestResult(new object[] { new double[] { 0 } }, (double)0)]
        [TestResult(new object[] { new double[] { 1 } }, (double)1)]
        [TestResult(new object[] { new double[] { 1, 2, 3 } }, (double)6)]
        [TestResult(new object[] { new double[] { 1, 2.44, 3.33 } }, (double)6.77)]
        public static double Sum(this IEnumerable<double> In)
            {
            double Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        #endregion

        #region To

        /// <summary>
        /// Creates an array of increasing or decreasing numbers 
        /// starting at <paramref name="From" /> and progressing until <paramref name="To" />.
        /// Array length will be |<paramref name="From" />-<paramref name="To" />|.
        /// </summary>
        /// <exception cref="OverflowException">If the size of the range is larger than an Array can contain.</exception>
        [TestResult(new object[] { 0, 0 }, new int[] { 0 })]
        [TestResult(new object[] { 0, 10 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestResult(new object[] { 10, 0 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [TestResult(new object[] { 10, -5 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 })]
        public static int[] To(this int From, int To)
            {
            var Out = new int[(From - To).Abs() + 1];

            int Direction = From < To ? 1 : -1;
            int OutIndex = 0;

            int Index2 = From;
            do
                {
                Out[OutIndex] = Index2;
                OutIndex++;

                Index2 += Direction;
                } while (Index2 - Direction != To);

            return Out;
            }

        #endregion

        #region Wrap

        /// <summary>
        /// Wraps a number in a Number subclass, 
        /// allowing you to perform comparisons and operations across
        /// types.
        /// </summary>
        public static Number Wrap<T>(this T Number)
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
            {
            Dictionary<Type, Number> Types = L.Num.NumberTypes;
            // TODO: Add support for Nullable types
            return (Types.Values.First(Type => Type.NumberType == Number.GetType())
                ?? Types.Values.First(Type => Number.CanConvertTo(Type.NumberType)))?
                .New(Number);
            }
        /// <summary>
        /// Wraps a string in a Number subclass, 
        /// allowing you to perform comparisons and operations across
        /// types.
        /// </summary>
        public static Number Wrap(this string Str)
            {
            return Str.IsEmpty()
                ? null
                : L.Num.MostPreciseType.New(Str).ConvertToBestMatch();
            }

        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains static methods and variables used for number extensions and wrappers.
        /// </summary>
        public static class Num
            {
            /// <summary>
            /// Regular expression used to identify string numbers in Scientific Notation.
            /// </summary>
            public const string RegexScientificNotation = @"(-?(?:0|[0-9]\d*)(?:\.\d*))?(?:[eE]([+\-]?\d+))";

            /// <summary>
            /// Type of numerical operation to perform.
            /// </summary>
            public enum Operation
                {
                /// <summary>
                /// Add
                /// </summary>
                Add,
                /// <summary>
                /// Subtract
                /// </summary>
                Subtract,
                /// <summary>
                /// Multiply
                /// </summary>
                Multiply,
                /// <summary>
                /// Divide
                /// </summary>
                Divide
                }

            private static readonly Number _MostRobustType = null;
            /// <summary>
            /// The most robust type for storing numbers based on precision.
            /// </summary>
            public static Number MostRobustType
                {
                get
                    {
                    if (_MostRobustType == null)
                        {
                        // ReSharper disable once UnusedVariable
                        Dictionary<Type, Number> Temp = NumberTypes;
                        }

                    return _MostRobustType;
                    }
                }

            private static Number _MostPreciseType;
            /// <summary>
            /// The most precise type for storing numbers based on precision.
            /// </summary>
            public static Number MostPreciseType
                {
                get
                    {
                    if (_MostPreciseType == null)
                        {
                        // ReSharper disable once UnusedVariable
                        Dictionary<Type, Number> Temp = NumberTypes;
                        }

                    return _MostPreciseType;
                    }
                }


            private static Dictionary<Type, Number> _NumberTypes;

            /// <summary>
            /// All number-container types defined in this assembly.
            /// </summary>
            public static Dictionary<Type, Number> NumberTypes
                {
                get
                    {
                    return Logic.Cache(ref _NumberTypes, () =>
                    {
                        var Out = new Dictionary<Type, Number>();

                        typeof(Number).Assembly.GetTypes().Select(Type => Type.HasInterface<INumber>()).Each(Type =>
                            {
                                try
                                    {
                                    var Temp = Type.New();
                                    if (Temp is Number)
                                        Out.Add(Type, (Number)Temp);
                                    }
                                catch
                                    {
                                    }
                            });

                        Number LargestMax = null;
                        Number SmallestMin = null;
                        Number FinestPrecision = null;

                        Out.Values.Each(Number =>
                        {
                            if (LargestMax == null || Number.MaxValue.CompareTo(LargestMax.MaxValue) > 0)
                                LargestMax = Number;
                            if (SmallestMin == null || Number.MinValue.CompareTo(SmallestMin.MinValue) < 0)
                                SmallestMin = Number;
                            if (FinestPrecision == null || Number.Precision.CompareTo(FinestPrecision.Precision) < 0)
                                FinestPrecision = Number;
                        });

                        // Calculate which types are most robust and most precise.
                        // If any two match then there is a clear choice, if not, precision takes precedence.
                        if (LargestMax.GetType().TypeEquals(SmallestMin.GetType()))
                            _MostPreciseType = LargestMax;
                        else if (LargestMax.GetType().TypeEquals(FinestPrecision.GetType()))
                            _MostPreciseType = FinestPrecision;
                        else if (SmallestMin.GetType().TypeEquals(FinestPrecision.GetType()))
                            _MostPreciseType = FinestPrecision;
                        else
                            _MostPreciseType = FinestPrecision;

                        _MostPreciseType = FinestPrecision;
                        return Out;
                    });
                    }
                }

            /// <summary>
            /// Converts a string <paramref name="In"/> in Scientific Notation format
            /// to a string representing the actual number.
            /// Ex: L.Num.ScientificNotationToNumber("5.0032e2"); // "503.2"
            /// </summary>
            public static string ScientificNotationToNumber(string In)
                {
                List<Match> Matches = ((string)In).Matches(RegexScientificNotation);

                if (Matches.Count == 0 || Matches[0].Groups.Count != 3)
                    return In;

                string Out = Matches[0].Groups[1].Value;

                if (!Out.Contains("."))
                    Out += ".0";

                int DotIndex = Out.IndexOf(".");

                int? Exponent = Matches[0].Groups[2].Value.ConvertTo<int>();

                if (Exponent == null)
                    return In;

                if (Exponent == 0)
                    return Out;

                Out = Out.Sub(0, DotIndex) + Out.Sub(DotIndex + 1);

                DotIndex += (int)Exponent;

                if (DotIndex < 0)
                    {
                    try
                        {
                        Out = $"0.{"0".Times(Math.Abs(DotIndex))}{Out}";
                        }
                    catch (OverflowException) { }
                    }
                else if (DotIndex == 0)
                    {
                    Out = $"0.{Out}";
                    }
                else if (DotIndex == Out.Length)
                    {
                    Out = $"{Out}.0";
                    }
                else if (DotIndex > Out.Length)
                    {
                    try
                        {
                        Out = $"{Out}{"0".Times((Out.Length - DotIndex).Abs())}.0";
                        }
                    catch (OverflowException) { }
                    }
                else
                    {
                    Out = $"{Out.Sub(0, DotIndex)}.{Out.Sub(DotIndex)}";
                    }

                return Out;
                }
            }
        }
    }