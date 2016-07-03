using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for float
    /// </summary>
    public class FloatNumber : Number<float>
        {
        /// <summary>
        /// Implicitally convert a float to a FloatNumber
        /// </summary>
        /// <param name="i">The float to convert</param>
        public static implicit operator FloatNumber(float i)
            {
            return new FloatNumber(i);
            }
        /// <summary>
        /// Implicitally convert a FloatNumber to a float
        /// </summary>
        /// <param name="i">The FloatNumber to convert</param>
        public static implicit operator float(FloatNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override float Add(float Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override float Subtract(float Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override float Multiply(float Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(float Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new FloatNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public FloatNumber(float Value)
            : base(Value)
            {

            }
        }
    }