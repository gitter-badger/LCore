using System;
using System.Collections.Generic;
using System.Globalization;

namespace LCore
    {
    public partial class Logic
        {
        #region Base Lambdas

        #region Int16
        public static Func<Int16> Int16_GetMaxValue = () => { return Int16.MaxValue; };
        public static Func<Int16> Int16_GetMinValue = () => { return Int16.MinValue; };
        public static Func<Int16, Object, Int32> Int16_CompareTo = (i, value) => { return i.CompareTo(value); };
        public static Func<Int16, Int16, Int32> Int16_CompareTo2 = (i, value) => { return i.CompareTo(value); };
        public static Func<Int16, Object, Boolean> Int16_Equals = (i, obj) => { return i.Equals(obj); };
        public static Func<Int16, Int16, Boolean> Int16_Equals2 = (i, obj) => { return i.Equals(obj); };
        public static Func<Int16, Int32> Int16_GetHashCode = (i) => { return i.GetHashCode(); };
        public static Func<Int16, String> Int16_ToString = (i) => { return i.ToString(); };
        public static Func<Int16, IFormatProvider, String> Int16_ToString2 = (i, provider) => { return i.ToString(provider); };
        public static Func<Int16, String, String> Int16_ToString3 = (i, format) => { return i.ToString(format); };
        public static Func<Int16, String, IFormatProvider, String> Int16_ToString4 = (i, format, provider) => { return i.ToString(format, provider); };
        public static Func<String, Int16> Int16_Parse = (s) => { return Int16.Parse(s); };
        public static Func<String, NumberStyles, Int16> Int16_Parse2 = (s, style) => { return Int16.Parse(s, style); };
        public static Func<String, IFormatProvider, Int16> Int16_Parse3 = (s, provider) => { return Int16.Parse(s, provider); };
        public static Func<String, NumberStyles, IFormatProvider, Int16> Int16_Parse4 = (s, style, provider) => { return Int16.Parse(s, style, provider); };
        /* No Ref or Out Types 
        public static Func<String, Int16&, Boolean> Int16_TryParse = (s, result) => { return Int16.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, NumberStyles, IFormatProvider, Int16&, Boolean> Int16_TryParse2 = (s, style, provider, result) => { return Int16.TryParse(s, style, provider, result); };
        */
        public static Func<Int16, TypeCode> Int16_GetTypeCode = (i) => { return i.GetTypeCode(); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region Int32
        public static Func<Int32> Int32_GetMaxValue = () => { return Int32.MaxValue; };
        public static Func<Int32> Int32_GetMinValue = () => { return Int32.MinValue; };
        public static Func<Int32, Object, Int32> Int32_CompareTo = (i, value) => { return i.CompareTo(value); };
        public static Func<Int32, Int32, Int32> Int32_CompareTo2 = (i, value) => { return i.CompareTo(value); };
        public static Func<Int32, Object, Boolean> Int32_Equals = (i, obj) => { return i.Equals(obj); };
        public static Func<Int32, Int32, Boolean> Int32_Equals2 = (i, obj) => { return i.Equals(obj); };
        public static Func<Int32, Int32> Int32_GetHashCode = (i) => { return i.GetHashCode(); };
        public static Func<Int32, String> Int32_ToString = (i) => { return i.ToString(); };
        public static Func<Int32, String, String> Int32_ToString2 = (i, format) => { return i.ToString(format); };
        public static Func<Int32, IFormatProvider, String> Int32_ToString3 = (i, provider) => { return i.ToString(provider); };
        public static Func<Int32, String, IFormatProvider, String> Int32_ToString4 = (i, format, provider) => { return i.ToString(format, provider); };
        public static Func<String, Int32> Int32_Parse = (s) => { return Int32.Parse(s); };
        public static Func<String, NumberStyles, Int32> Int32_Parse2 = (s, style) => { return Int32.Parse(s, style); };
        public static Func<String, IFormatProvider, Int32> Int32_Parse3 = (s, provider) => { return Int32.Parse(s, provider); };
        public static Func<String, NumberStyles, IFormatProvider, Int32> Int32_Parse4 = (s, style, provider) => { return Int32.Parse(s, style, provider); };
        /* No Ref or Out Types 
        public static Func<String, Int32&, Boolean> Int32_TryParse = (s, result) => { return Int32.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, NumberStyles, IFormatProvider, Int32&, Boolean> Int32_TryParse2 = (s, style, provider, result) => { return Int32.TryParse(s, style, provider, result); };
        */
        public static Func<Int32, TypeCode> Int32_GetTypeCode = (i) => { return i.GetTypeCode(); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion
        #region Int64
        public static Func<Int64> Int64_GetMaxValue = () => { return Int64.MaxValue; };
        public static Func<Int64> Int64_GetMinValue = () => { return Int64.MinValue; };
        public static Func<Int64, Object, Int32> Int64_CompareTo = (i, value) => { return i.CompareTo(value); };
        public static Func<Int64, Int64, Int32> Int64_CompareTo2 = (i, value) => { return i.CompareTo(value); };
        public static Func<Int64, Object, Boolean> Int64_Equals = (i, obj) => { return i.Equals(obj); };
        public static Func<Int64, Int64, Boolean> Int64_Equals2 = (i, obj) => { return i.Equals(obj); };
        public static Func<Int64, Int32> Int64_GetHashCode = (i) => { return i.GetHashCode(); };
        public static Func<Int64, String> Int64_ToString = (i) => { return i.ToString(); };
        public static Func<Int64, IFormatProvider, String> Int64_ToString2 = (i, provider) => { return i.ToString(provider); };
        public static Func<Int64, String, String> Int64_ToString3 = (i, format) => { return i.ToString(format); };
        public static Func<Int64, String, IFormatProvider, String> Int64_ToString4 = (i, format, provider) => { return i.ToString(format, provider); };
        public static Func<String, Int64> Int64_Parse = (s) => { return Int64.Parse(s); };
        public static Func<String, NumberStyles, Int64> Int64_Parse2 = (s, style) => { return Int64.Parse(s, style); };
        public static Func<String, IFormatProvider, Int64> Int64_Parse3 = (s, provider) => { return Int64.Parse(s, provider); };
        public static Func<String, NumberStyles, IFormatProvider, Int64> Int64_Parse4 = (s, style, provider) => { return Int64.Parse(s, style, provider); };
        /* No Ref or Out Types 
        public static Func<String, Int64&, Boolean> Int64_TryParse = (s, result) => { return Int64.TryParse(s, result); };
        */
        /* No Ref or Out Types 
        public static Func<String, NumberStyles, IFormatProvider, Int64&, Boolean> Int64_TryParse2 = (s, style, provider, result) => { return Int64.TryParse(s, style, provider, result); };
        */
        public static Func<Int64, TypeCode> Int64_GetTypeCode = (i) => { return i.GetTypeCode(); };
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        #endregion

        #endregion

        #region Short
        public static Func<short, short, Boolean> Short_GreaterThan = (i1, i2) => { return i1 > i2; };
        public static Func<short, short, Boolean> Short_LessThan = (i1, i2) => { return i1 < i2; };
        public static Func<short, short, Boolean> Short_Equals = (i1, i2) => { return i1 == i2; };
        public static Func<short, short> Short_Negate = (i) => { return (short)-i; };
        public static Func<short, short> Short_Increment = (i) => { return i++; };
        public static Func<short, short> Short_Decrement = (i) => { return i--; };
        public static Func<short, short, short> Short_Plus = (i1, i2) => { return (short)((short)i1 + (short)i2); };
        public static Func<short, short, short> Short_Minus = (i1, i2) => { return (short)((short)i1 - (short)i2); };
        public static Func<short, short, short> Short_Multiply = (i1, i2) => { return (short)((short)i1 * (short)i2); };
        public static Func<short, short, float> Short_Divide = (i1, i2) => { return (float)i1 / (float)i2; };
        public static Func<short, short, short> Short_Mod = (i1, i2) => { return (short)(i1 % i2); };
        public static Func<short, short> Short_ShiftLeft = (i) => { return (short)(i << 1); };
        public static Func<short, short> Short_ShiftRight = (i) => { return (short)(i >> 1); };
        #endregion
        #region Int
        public static Func<int, int, Boolean> Int_GreaterThan = (i1, i2) => { return i1 > i2; };
        public static Func<int, int, Boolean> Int_LessThan = (i1, i2) => { return i1 < i2; };
        public static Func<int, int, Boolean> Int_Equals = (i1, i2) => { return i1 == i2; };
        public static Func<int, int> Int_Negate = (i) => { return -i; };
        public static Func<int, int> Int_Increment = (i) => { return ++i; };
        public static Func<int, int> Int_Decrement = (i) => { return --i; };
        public static Func<int, int, int> Int_Plus = (i1, i2) => { return i1 + i2; };
        public static Func<int, int, int> Int_Minus = (i1, i2) => { return i1 - i2; };
        public static Func<int, int, int> Int_Multiply = (i1, i2) => { return i1 * i2; };
        public static Func<int, int, float> Int_Divide = (i1, i2) => { return (float)i1 / (float)i2; };
        public static Func<int, int, int> Int_Mod = (i1, i2) => { return i1 % i2; };
        public static Func<int, int> Int_ShiftLeft = (i) => { return i << 1; };
        public static Func<int, int> Int_ShiftRight = (i) => { return i >> 1; };
        #endregion
        #region Long
        public static Func<long, long, Boolean> Long_GreaterThan = (i1, i2) => { return i1 > i2; };
        public static Func<long, long, Boolean> Long_LessThan = (i1, i2) => { return i1 < i2; };
        public static Func<long, long, Boolean> Long_Equals = (i1, i2) => { return i1 == i2; };
        public static Func<long, long> Long_Negate = (i) => { return -i; };
        public static Func<long, long> Long_Increment = (i) => { return i++; };
        public static Func<long, long> Long_Decrement = (i) => { return i--; };
        public static Func<long, long, long> Long_Plus = (i1, i2) => { return i1 + i2; };
        public static Func<long, long, long> Long_Minus = (i1, i2) => { return i1 - i2; };
        public static Func<long, long, long> Long_Multiply = (i1, i2) => { return i1 * i2; };
        public static Func<long, long, double> Long_Divide = (i1, i2) => { return (double)i1 / (double)i2; };
        public static Func<long, long, long> Long_Mod = (i1, i2) => { return i1 % i2; };
        public static Func<long, long> Long_ShiftLeft = (i) => { return i << 1; };
        public static Func<long, long> Long_ShiftRight = (i) => { return i >> 1; };
        #endregion
        }
    public static class IntExt
        {
        public static List<int> AddEach(this List<int> In, int AddNum)
            {
            return In.Collect((i) => { return i + AddNum; });
            }
        public static List<int> SubtractEach(this List<int> In, int SubtractNum)
            {
            return In.AddEach(-SubtractNum);
            }

        public static double SquareRoot(this int In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this long In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this short In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this double In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this float In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this uint In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this ulong In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this ushort In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this byte In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this sbyte In)
            {
            return Math.Sqrt(In);
            }
        public static double SquareRoot(this decimal In)
            {
            return Math.Sqrt((double)In);
            }

        public static Boolean IsEven(this int In)
            {
            return In % 2 == 0;
            }
        public static Boolean IsEven(this long In)
            {
            return In % 2 == 0;
            }
        public static Boolean IsEven(this short In)
            {
            return In % 2 == 0;
            }
        public static Boolean IsEven(this uint In)
            {
            return In % 2 == 0;
            }
        public static Boolean IsEven(this ulong In)
            {
            return In % 2 == 0;
            }
        public static Boolean IsEven(this byte In)
            {
            return In % 2 == 0;
            }
        public static Boolean IsEven(this sbyte In)
            {
            return In % 2 == 0;
            }

        public static int AbsoluteValue(this int In)
            {
            return Math.Abs(In);
            }
        public static long AbsoluteValue(this long In)
            {
            return Math.Abs(In);
            }
        public static short AbsoluteValue(this short In)
            {
            return Math.Abs(In);
            }
        public static double AbsoluteValue(this double In)
            {
            return Math.Abs(In);
            }
        public static float AbsoluteValue(this float In)
            {
            return Math.Abs(In);
            }
        public static sbyte AbsoluteValue(this sbyte In)
            {
            return Math.Abs(In);
            }
        public static decimal AbsoluteValue(this decimal In)
            {
            return Math.Abs(In);
            }
        }
    }