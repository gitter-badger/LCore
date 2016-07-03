using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LCore.Interfaces;

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
        /// Adds [AddNum] to each item in the list [In]
        /// </summary>
        public static List<int> AddEach(this List<int> In, int AddNum)
            {
            return In.Collect(i => i + AddNum);
            }

        #endregion

        #region Abs

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static int Abs(this int In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static long Abs(this long In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static short Abs(this short In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static double Abs(this double In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static float Abs(this float In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static sbyte Abs(this sbyte In)
            {
            return Math.Abs(In);
            }

        /// <summary>
        /// Returns the absolute value of [In]
        /// </summary>
        public static decimal Abs(this decimal In)
            {
            return Math.Abs(In);
            }

        #endregion

        #region AsPercent

        /// <summary>
        /// Returns the float [In], multiplied by 100 and converted to an int.
        /// </summary>
        public static int AsPercent(this float In)
            {
            return (int)(In * 100);
            }

        /// <summary>
        /// Returns the double [In], multiplied by 100 and converted to an int.
        /// </summary>
        public static int AsPercent(this double In)
            {
            return (int)(In * 100);
            }

        #endregion

        #region Average

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        public static double Average(this IEnumerable<int> In)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));

            IEnumerable<int> enumerable = In as int[] ?? In.ToArray();
            return enumerable.Sum() / (double)enumerable.Count();
            }

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        public static double Average(this IEnumerable<long> In)
            {
            IEnumerable<long> enumerable = In as long[] ?? In.ToArray();
            return enumerable.Sum() / (double)enumerable.Count();
            }

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        public static double Average(this IEnumerable<float> In)
            {
            IEnumerable<float> enumerable = In as float[] ?? In.ToArray();
            return enumerable.Sum() / (double)enumerable.Count();
            }

        /// <summary>
        /// Returns the average of all numbers in the source.
        /// </summary>
        public static double Average(this IEnumerable<double> In)
            {
            IEnumerable<double> enumerable = In as double[] ?? In.ToArray();
            return enumerable.Sum() / enumerable.Count();
            }

        #endregion

        #region Floor

        /// <summary>
        /// Returns the floor of the float [In]
        /// </summary>
        public static int Floor(this float In)
            {
            return (int)Math.Round(In);
            }

        /// <summary>
        /// Returns the floor of the float [In].
        /// [Decimals] must be at least 0.
        /// </summary>
        public static float Floor(this float In, int Decimals)
            {
            if (Decimals <= 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            float Power = (float)Math.Pow(10, Decimals);
            float Out = (int)Math.Floor(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }

        /// <summary>
        /// Returns the floor of the double [In]
        /// </summary>
        public static long Floor(this double In)
            {
            return (long)Math.Floor(In);
            }

        /// <summary>
        /// Returns the floor of the float [In].
        /// [Decimals] must be at least 0.
        /// </summary>
        public static double Floor(this double In, int Decimals)
            {
            if (Decimals <= 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

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
        public static bool IsEven(this int In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        public static bool IsEven(this long In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        public static bool IsEven(this short In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        public static bool IsEven(this uint In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        public static bool IsEven(this ulong In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        public static bool IsEven(this byte In)
            {
            return In % 2 == 0;
            }

        /// <summary>
        /// Returns whether the supplied number is Even
        /// </summary>
        public static bool IsEven(this sbyte In)
            {
            return In % 2 == 0;
            }

        #endregion

        #region Round

        /// <summary>
        /// Returns the rounded integer of the float [In]
        /// </summary>
        public static int Round(this float In)
            {
            return (int)Math.Round(In);
            }

        /// <summary>
        /// Returns the rounded integer of the float [In]
        /// [Decimals] must be at least 0.
        /// </summary>
        public static float Round(this float In, int Decimals)
            {
            if (Decimals <= 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            float Power = (float)Math.Pow(10, Decimals);
            float Out = (int)Math.Round(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }

        /// <summary>
        /// Returns the rounded integer of the float [In]
        /// </summary>
        public static long Round(this double In)
            {
            return (long)Math.Round(In);
            }

        /// <summary>
        /// Returns the rounded integer of the float [In]
        /// [Decimals] must be at least 0.
        /// </summary>
        public static double Round(this double In, int Decimals)
            {
            if (Decimals <= 0) throw new ArgumentOutOfRangeException(nameof(Decimals));

            double Power = Math.Pow(10, Decimals);
            double Out = (int)Math.Round(In * Power);
            double Out2 = Out / Power;
            return Out2;
            }

        #endregion

        #region SquareRoot

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this int In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this long In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this short In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this double In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this float In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this uint In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this ulong In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this ushort In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this byte In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this sbyte In)
            {
            return Math.Sqrt(In);
            }

        /// <summary>
        /// Returns the square root of the supplied number
        /// </summary>
        public static double SquareRoot(this decimal In)
            {
            return Math.Sqrt((double)In);
            }

        #endregion

        #region SubtractEach

        /// <summary>
        /// Subtracts [SubtractNum] to each item in the list [In]
        /// </summary>
        public static List<int> SubtractEach(this List<int> In, int SubtractNum)
            {
            return In.AddEach(-SubtractNum);
            }

        #endregion

        #region Sum

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        public static int Sum(this IEnumerable<int> In)
            {
            int Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        public static long Sum(this IEnumerable<long> In)
            {
            long Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        public static float Sum(this IEnumerable<float> In)
            {
            float Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        /// <summary>
        /// Returns the sum of all numbers in the source list.
        /// </summary>
        public static double Sum(this IEnumerable<double> In)
            {
            double Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        #endregion

        #endregion
        }
    }