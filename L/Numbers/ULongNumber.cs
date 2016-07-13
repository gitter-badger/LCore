using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for ulong
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class ULongNumber : Number<ulong>
        {
        /// <summary>
        /// Implicitally convert a ulong to a ULongNumber
        /// </summary>
        /// <param name="i">The ulong to convert</param>
        public static implicit operator ULongNumber(ulong i)
            {
            return new ULongNumber(i);
            }
        /// <summary>
        /// Implicitally convert a ULongNumber to a ulong
        /// </summary>
        /// <param name="i">The ULongNumber to convert</param>
        public static implicit operator ulong(ULongNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override ulong Add(ulong Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override ulong Subtract(ulong Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override ulong Multiply(ulong Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(ulong Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new ULongNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public ULongNumber(ulong Value)
            : base(Value)
            {

            }
        }
    }