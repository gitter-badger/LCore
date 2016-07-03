using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for long
    /// </summary>
    public class LongNumber : Number<long>
        {
        /// <summary>
        /// Implicitally convert a long to a LongNumber
        /// </summary>
        /// <param name="i">The long to convert</param>
        public static implicit operator LongNumber(long i)
            {
            return new LongNumber(i);
            }
        /// <summary>
        /// Implicitally convert a LongNumber to a long
        /// </summary>
        /// <param name="i">The LongNumber to convert</param>
        public static implicit operator long(LongNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override long Add(long Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override long Subtract(long Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override long Multiply(long Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(long Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new LongNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public LongNumber(long Value)
            : base(Value)
            {

            }
        }
    }