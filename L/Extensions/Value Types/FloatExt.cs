using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;

namespace LCore
    {
    public partial class Logic
        {
        #region Base Lambdas
        #region Decimal
        public static Func<Int32, Decimal> Decimal_New = (value) => { return new Decimal(value); };
        public static Func<UInt32, Decimal> Decimal_New2 = (value) => { return new Decimal(value); };
        public static Func<Int64, Decimal> Decimal_New3 = (value) => { return new Decimal(value); };
        public static Func<UInt64, Decimal> Decimal_New4 = (value) => { return new Decimal(value); };
        public static Func<Single, Decimal> Decimal_New5 = (value) => { return new Decimal(value); };
        public static Func<Double, Decimal> Decimal_New6 = (value) => { return new Decimal(value); };
        public static Func<Int32[], Decimal> Decimal_New7 = (bits) => { return new Decimal(bits); };
        public static Func<decimal, decimal, Boolean> Decimal_GreaterThan = (i1, i2) => { return i1 > i2; };
        public static Func<decimal, decimal, Boolean> Decimal_LessThan = (i1, i2) => { return i1 < i2; };
        public static Func<decimal, decimal, Boolean> Decimal_Equals = (i1, i2) => { return i1 == i2; };
        public static Func<decimal, decimal> Decimal_Negate = (i) => { return -i; };
        public static Func<decimal, decimal> Decimal_Increment = (i) => { return i++; };
        public static Func<decimal, decimal> Decimal_Decrement = (i) => { return i--; };
        public static Func<decimal, decimal, decimal> Decimal_Plus = (i1, i2) => { return i1 + i2; };
        public static Func<decimal, decimal, decimal> Decimal_Minus = (i1, i2) => { return i1 - i2; };
        public static Func<decimal, decimal, decimal> Decimal_Multiply = (i1, i2) => { return i1 * i2; };
        public static Func<decimal, decimal, float> Decimal_Divide = (i1, i2) => { return (float)i1 / (float)i2; };
        public static Func<decimal, decimal, decimal> Decimal_Mod = (i1, i2) => { return i1 % i2; };
        /* Too Many Parameters :( 
        public static Func<Int32, Int32, Int32, Boolean, Byte, Decimal> Decimal_New8 = (lo, mid, hi, isNegative, scale) => { return new Decimal(lo, mid, hi, isNegative, scale); };
        */
        #endregion
        #region Single
        public static Func<Single> Single_GetMinValue = () => { return Single.MinValue; };
        public static Func<Single> Single_GetEpsilon = () => { return Single.Epsilon; };
        public static Func<Single> Single_GetMaxValue = () => { return Single.MaxValue; };
        public static Func<Single> Single_GetPositiveInfinity = () => { return Single.PositiveInfinity; };
        public static Func<Single> Single_GetNegativeInfinity = () => { return Single.NegativeInfinity; };
        public static Func<Single> Single_GetNaN = () => { return Single.NaN; };
        public static Func<Single, Boolean> Single_IsInfinity = (f) => { return Single.IsInfinity(f); };
        public static Func<Single, Boolean> Single_IsNaN = (f) => { return Single.IsNaN(f); };
        public static Func<Single, String> Single_ToString = (s) => { return s.ToString(); };
        public static Func<Single, IFormatProvider, String> Single_ToString2 = (s, provider) => { return s.ToString(provider); };
        public static Func<Single, String, IFormatProvider, String> Single_ToString3 = (s, format, provider) => { return s.ToString(format, provider); };
        public static Func<String, Single> Single_Parse = (s) => { return Single.Parse(s); };
        public static Func<String, NumberStyles, IFormatProvider, Single> Single_Parse2 = (s, style, provider) => { return Single.Parse(s, style, provider); };
        public static Func<Single, Boolean> Single_IsPositiveInfinity = (f) => { return Single.IsPositiveInfinity(f); };
        public static Func<Single, Boolean> Single_IsNegativeInfinity = (f) => { return Single.IsNegativeInfinity(f); };
        public static Func<Single, Object, Int32> Single_CompareTo = (s, value) => { return s.CompareTo(value); };
        public static Func<Single, Single, Int32> Single_CompareTo2 = (s, value) => { return s.CompareTo(value); };
        public static Func<Single, Single, Boolean> Single_Equals = (left, right) => { return left == right; };
        public static Func<Single, Single, Boolean> Single_NotEquals = (left, right) => { return left != right; };
        public static Func<Single, Single, Boolean> Single_LessThan = (left, right) => { return left < right; };
        public static Func<Single, Single, Boolean> Single_GreaterThan = (left, right) => { return left > right; };
        public static Func<Single, Single, Boolean> Single_LessThanOrEqual = (left, right) => { return left <= right; };
        public static Func<Single, Single, Boolean> Single_GreaterThanOrEqual = (left, right) => { return left >= right; };
        public static Func<Single, Object, Boolean> Single_Equals2 = (s, obj) => { return s.Equals(obj); };
        public static Func<Single, Single, Boolean> Single_Equals3 = (s, obj) => { return s.Equals(obj); };
        public static Func<Single, Int32> Single_GetHashCode = (s) => { return s.GetHashCode(); };
        public static Func<Single, String, String> Single_ToString4 = (s, format) => { return s.ToString(format); };
        public static Func<String, NumberStyles, Single> Single_Parse3 = (s, style) => { return Single.Parse(s, style); };
        public static Func<String, IFormatProvider, Single> Single_Parse4 = (s, provider) => { return Single.Parse(s, provider); };
        /* No Ref or Out Types 
        public static Func<String, Single&, Boolean> Single_TryParse = (s, result) => { return Single.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, NumberStyles, IFormatProvider, Single&, Boolean> Single_TryParse2 = (s, style, provider, result) => { return Single.TryParse(s, style, provider, result); };
        */
        public static Func<Single, TypeCode> Single_GetTypeCode = (s) => { return s.GetTypeCode(); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region Double
        public static Func<Double> Double_GetMinValue = () => { return Double.MinValue; };
        public static Func<Double> Double_GetMaxValue = () => { return Double.MaxValue; };
        public static Func<Double> Double_GetEpsilon = () => { return Double.Epsilon; };
        public static Func<Double> Double_GetNegativeInfinity = () => { return Double.NegativeInfinity; };
        public static Func<Double> Double_GetPositiveInfinity = () => { return Double.PositiveInfinity; };
        public static Func<Double> Double_GetNaN = () => { return Double.NaN; };
        public static Func<Double, Boolean> Double_IsInfinity = (d) => { return Double.IsInfinity(d); };
        public static Func<Double, Boolean> Double_IsPositiveInfinity = (d) => { return Double.IsPositiveInfinity(d); };
        public static Func<Double, Boolean> Double_IsNegativeInfinity = (d) => { return Double.IsNegativeInfinity(d); };
        public static Func<Double, Boolean> Double_IsNaN = (d) => { return Double.IsNaN(d); };
        public static Func<Double, Object, Int32> Double_CompareTo = (d, value) => { return d.CompareTo(value); };
        public static Func<Double, Double, Int32> Double_CompareTo2 = (d, value) => { return d.CompareTo(value); };
        public static Func<Double, Object, Boolean> Double_Equals = (d, obj) => { return d.Equals(obj); };
        public static Func<Double, Double, Boolean> Double_Equals2 = (left, right) => { return left == right; };
        public static Func<Double, Double, Boolean> Double_NotEquals = (left, right) => { return left != right; };
        public static Func<Double, Double, Boolean> Double_LessThan = (left, right) => { return left < right; };
        public static Func<Double, Double, Boolean> Double_GreaterThan = (left, right) => { return left > right; };
        public static Func<Double, Double, Boolean> Double_LessThanOrEqual = (left, right) => { return left <= right; };
        public static Func<Double, Double, Boolean> Double_GreaterThanOrEqual = (left, right) => { return left >= right; };
        public static Func<Double, Double, Boolean> Double_Equals3 = (d, obj) => { return d.Equals(obj); };
        public static Func<Double, Int32> Double_GetHashCode = (d) => { return d.GetHashCode(); };
        public static Func<Double, String> Double_ToString = (d) => { return d.ToString(); };
        public static Func<Double, String, String> Double_ToString2 = (d, format) => { return d.ToString(format); };
        public static Func<Double, IFormatProvider, String> Double_ToString3 = (d, provider) => { return d.ToString(provider); };
        public static Func<Double, String, IFormatProvider, String> Double_ToString4 = (d, format, provider) => { return d.ToString(format, provider); };
        public static Func<String, Double> Double_Parse = (s) => { return Double.Parse(s); };
        public static Func<String, NumberStyles, Double> Double_Parse2 = (s, style) => { return Double.Parse(s, style); };
        public static Func<String, IFormatProvider, Double> Double_Parse3 = (s, provider) => { return Double.Parse(s, provider); };
        public static Func<String, NumberStyles, IFormatProvider, Double> Double_Parse4 = (s, style, provider) => { return Double.Parse(s, style, provider); };
        /* No Ref or Out Types 
        public static Func<String, Double&, Boolean> Double_TryParse = (s, result) => { return Double.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, NumberStyles, IFormatProvider, Double&, Boolean> Double_TryParse2 = (s, style, provider, result) => { return Double.TryParse(s, style, provider, result); };
        */
        public static Func<Double, TypeCode> Double_GetTypeCode = (d) => { return d.GetTypeCode(); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #endregion

        #region Float
        public static Func<float, float, Boolean> Float_GreaterThan = (i1, i2) => { return i1 > i2; };
        public static Func<float, float, Boolean> Float_LessThan = (i1, i2) => { return i1 < i2; };
        public static Func<float, float, Boolean> Float_Equals = (i1, i2) => { return i1 == i2; };
        public static Func<float, float> Float_Negate = (i) => { return -i; };
        public static Func<float, float> Float_Increment = (i) => { return i++; };
        public static Func<float, float> Float_Decrement = (i) => { return i--; };
        public static Func<float, float, float> Float_Plus = (i1, i2) => { return i1 + i2; };
        public static Func<float, float, float> Float_Minus = (i1, i2) => { return i1 - i2; };
        public static Func<float, float, float> Float_Multiply = (i1, i2) => { return i1 * i2; };
        public static Func<float, float, float> Float_Divide = (i1, i2) => { return (float)i1 / (float)i2; };
        public static Func<float, float, float> Float_Mod = (i1, i2) => { return i1 % i2; };
        #endregion

        #region Double
        public static Func<double, double> Double_Negate = (i) => { return -i; };
        public static Func<double, double> Double_Increment = (i) => { return i++; };
        public static Func<double, double> Double_Decrement = (i) => { return i--; };
        public static Func<double, double, double> Double_Plus = (i1, i2) => { return i1 + i2; };
        public static Func<double, double, double> Double_Minus = (i1, i2) => { return i1 - i2; };
        public static Func<double, double, double> Double_Multiply = (i1, i2) => { return i1 * i2; };
        public static Func<double, double, double> Double_Divide = (i1, i2) => { return (double)i1 / (double)i2; };
        public static Func<double, double, double> Double_Mod = (i1, i2) => { return i1 % i2; };
        #endregion
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
            In.Each((i) => { Out += i; });
            return Out;
            }
        public static long Sum(this IEnumerable<long> In)
            {
            long Out = 0;
            In.Each((i) => { Out += i; });
            return Out;
            }
        public static float Sum(this IEnumerable<float> In)
            {
            float Out = 0;
            In.Each((i) => { Out += i; });
            return Out;
            }
        public static double Sum(this IEnumerable<double> In)
            {
            double Out = 0;
            In.Each((i) => { Out += i; });
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
            return (double)In.Sum() / (double)In.Count();
            }
        public static double Average(this IEnumerable<long> In)
            {
            return (double)In.Sum() / (double)In.Count();
            }
        public static double Average(this IEnumerable<float> In)
            {
            return (double)In.Sum() / (double)In.Count();
            }
        public static double Average(this IEnumerable<double> In)
            {
            return (double)In.Sum() / (double)In.Count();
            }

        public static int AsPercent(this float In)
            {
            return (int)(In * (float)100);
            }
        public static int AsPercent(this double In)
            {
            return (int)(In * (double)100);
            }

        public static int Round(this float In)
            {
            return (int)Math.Round(In);
            }
        public static float Round(this float In, int Decimals)
            {
            float Power = (float)(Math.Pow(10, Decimals));
            float Out = (float)(int)Math.Round(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }
        public static long Round(this double In)
            {
            return (long)Math.Round(In);
            }
        public static double Round(this double In, int Decimals)
            {
            Double Power = (double)(Math.Pow(10, Decimals));
            Double Out = (Double)(int)Math.Round(In * Power);
            Double Out2 = Out / Power;
            return Out2;
            }
        public static int Floor(this float In)
            {
            return (int)Math.Round(In);
            }
        public static float Floor(this float In, int Decimals)
            {
            float Power = (float)(Math.Pow(10, Decimals));
            float Out = (float)(int)Math.Floor(In * Power);
            float Out2 = Out / Power;
            return Out2;
            }
        public static long Floor(this double In)
            {
            return (long)Math.Floor(In);
            }
        public static double Floor(this double In, int Decimals)
            {
            Double Power = (double)(Math.Pow(10, Decimals));
            Double Out = (Double)(int)Math.Floor(In * Power);
            Double Out2 = Out / Power;
            return Out2;
            }
        }
    }