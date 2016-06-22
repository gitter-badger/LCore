using System;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    public partial class Logic
        {
        }
    public static class IntExt
        {
        public static List<int> AddEach(this List<int> In, int AddNum)
            {
            return In.Collect(i => i + AddNum);
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

        public static bool IsEven(this int In)
            {
            return In % 2 == 0;
            }
        public static bool IsEven(this long In)
            {
            return In % 2 == 0;
            }
        public static bool IsEven(this short In)
            {
            return In % 2 == 0;
            }
        public static bool IsEven(this uint In)
            {
            return In % 2 == 0;
            }
        public static bool IsEven(this ulong In)
            {
            return In % 2 == 0;
            }
        public static bool IsEven(this byte In)
            {
            return In % 2 == 0;
            }
        public static bool IsEven(this sbyte In)
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