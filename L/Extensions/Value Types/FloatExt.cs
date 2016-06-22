using System;
using System.Collections.Generic;
using System.Linq;

namespace LCore.Extensions
    {
    public partial class Logic
        {
        }
    public static class FloatExt
        {
        public static int Sum<T>(this IEnumerable<T> In, Func<T, int> IntRetriever)
            {
            return In.Convert(IntRetriever).Sum();
            }
        public static long Sum<T>(this IEnumerable<T> In, Func<T, long> LongRetriever)
            {
            return In.Convert(LongRetriever).Sum();
            }
        public static float Sum<T>(this IEnumerable<T> In, Func<T, float> FloatRetriever)
            {
            return In.Convert(FloatRetriever).Sum();
            }
        public static double Sum<T>(this IEnumerable<T> In, Func<T, double> DoubleRetriever)
            {
            return In.Convert(DoubleRetriever).Sum();
            }

        public static int Sum(this IEnumerable<int> In)
            {
            int Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }
        public static long Sum(this IEnumerable<long> In)
            {
            long Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }
        public static float Sum(this IEnumerable<float> In)
            {
            float Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }
        public static double Sum(this IEnumerable<double> In)
            {
            double Out = 0;
            In.Each(i => { Out += i; });
            return Out;
            }

        public static double Average<T>(this IEnumerable<T> In, Func<T, int> IntRetriever)
            {
            return In.Convert(IntRetriever).Average();
            }
        public static double Average<T>(this IEnumerable<T> In, Func<T, long> LongRetriever)
            {
            return In.Convert(LongRetriever).Average();
            }
        public static double Average<T>(this IEnumerable<T> In, Func<T, float> FloatRetriever)
            {
            return In.Convert(FloatRetriever).Average();
            }
        public static double Average<T>(this IEnumerable<T> In, Func<T, double> DoubleRetriever)
            {
            return In.Convert(DoubleRetriever).Average();
            }

        public static double Average(this IEnumerable<int> In)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));

            IEnumerable<int> enumerable = In as int[] ?? In.ToArray();
            return enumerable.Sum() / (double)enumerable.Count();
            }

        public static double Average(this IEnumerable<long> In)
            {
            IEnumerable<long> enumerable = In as long[] ?? In.ToArray();
            return enumerable.Sum() / (double)enumerable.Count();
            }

        public static double Average(this IEnumerable<float> In)
            {
            IEnumerable<float> enumerable = In as float[] ?? In.ToArray();
            return enumerable.Sum() / (double)enumerable.Count();
            }

        public static double Average(this IEnumerable<double> In)
            {
            IEnumerable<double> enumerable = In as double[] ?? In.ToArray();
            return enumerable.Sum() / enumerable.Count();
            }

        public static int AsPercent(this float In)
            {
            return (int)(In * 100);
            }
        public static int AsPercent(this double In)
            {
            return (int)(In * 100);
            }

        public static int Round(this float In)
            {
            return (int)Math.Round(In);
            }
        public static float Round(this float In, int Decimals)
            {
            float Power = (float)Math.Pow(10, Decimals);
            float Out = (int)Math.Round(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }
        public static long Round(this double In)
            {
            return (long)Math.Round(In);
            }
        public static double Round(this double In, int Decimals)
            {
            double Power = Math.Pow(10, Decimals);
            double Out = (int)Math.Round(In * Power);
            double Out2 = Out / Power;
            return Out2;
            }
        public static int Floor(this float In)
            {
            return (int)Math.Round(In);
            }
        public static float Floor(this float In, int Decimals)
            {
            float Power = (float)Math.Pow(10, Decimals);
            float Out = (int)Math.Floor(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }
        public static long Floor(this double In)
            {
            return (long)Math.Floor(In);
            }
        public static double Floor(this double In, int Decimals)
            {
            double Power = Math.Pow(10, Decimals);
            double Out = (int)Math.Floor(In * Power);
            double Out2 = Out / Power;
            return Out2;
            }
        }
    }