using System;
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LCore.Numbers
    {
    /// <summary>
    /// Base class to extend for native (and potentially non-native) number types
    /// </summary>
    /// <typeparam name="T">The Type of the number object</typeparam>
    public abstract class Number<T>
        : INumber<T>
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public abstract T Add(T Value);

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public abstract T Subtract(T Value);

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public abstract T Multiply(T Value);

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public abstract double Divide(T Value);

        /// <summary>
        /// The base number object
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Create a new Number wrapper for a native number type
        /// </summary>
        /// <param name="Value">The number value</param>
        protected Number(T Value)
            {
            this.Value = Value;
            }
        }
    /*
    public static class NumberStatic
        {
        public static int[] Combine(int DesiredSum, int[] In)
            {
            In.Sort();

            Boolean[] Include = new Boolean[In.Length];

            int TotalSelected = 0;

            for (int i = 0; i < In.Length; i++)
                {
                if (In[i] == DesiredSum)
                    {
                    return new int[] { In[i] };
                    }

                if (TotalSelected + In[i] == DesiredSum)
                    {
                    return In.SelectI<int>((j, j2) => { return Include[j2] == true; }).Array();
                    }
                }
            }
        }
     * */
    }
