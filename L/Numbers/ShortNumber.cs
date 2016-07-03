using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for short
    /// </summary>
    public class ShortNumber : Number<short>
        {
        /// <summary>
        /// Implicitally convert a short to a ShortNumber
        /// </summary>
        /// <param name="i">The short to convert</param>
        public static implicit operator ShortNumber(short i)
            {
            return new ShortNumber(i);
            }
        /// <summary>
        /// Implicitally convert a ShortNumber to a short
        /// </summary>
        /// <param name="i">The ShortNumber to convert</param>
        public static implicit operator short(ShortNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override short Add(short Value)
            {
            return (short)(this.Value + Value);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override short Subtract(short Value)
            {
            return (short)(this.Value - Value);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override short Multiply(short Value)
            {
            return (short)(this.Value * Value);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(short Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new ShortNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public ShortNumber(short Value)
            : base(Value)
            {

            }
        }
    }