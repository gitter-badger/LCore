using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for decimal
    /// </summary>
    public class DecimalNumber : Number<decimal>
        {
        /// <summary>
        /// Implicitally convert a decimal to a DecimalNumber
        /// </summary>
        /// <param name="i">The decimal to convert</param>
        public static implicit operator DecimalNumber(decimal i)
            {
            return new DecimalNumber(i);
            }
        /// <summary>
        /// Implicitally convert a DecimalNumber to a decimal
        /// </summary>
        /// <param name="i">The DecimalNumber to convert</param>
        public static implicit operator decimal(DecimalNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override decimal Add(decimal Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override decimal Subtract(decimal Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override decimal Multiply(decimal Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(decimal Value)
            {
            return (double)(this.Value / Value);
            }

        /// <summary>
        /// Create a new DecimalNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public DecimalNumber(decimal Value)
            : base(Value)
            {

            }
        }
    }