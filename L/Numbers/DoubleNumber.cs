using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for double
    /// </summary>
    public class DoubleNumber : Number<double>
        {
        /// <summary>
        /// Implicitally convert a double to a DoubleNumber
        /// </summary>
        /// <param name="i">The double to convert</param>
        public static implicit operator DoubleNumber(double i)
            {
            return new DoubleNumber(i);
            }
        /// <summary>
        /// Implicitally convert a DoubleNumber to a double
        /// </summary>
        /// <param name="i">The DoubleNumber to convert</param>
        public static implicit operator double(DoubleNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Add(double Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Subtract(double Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Multiply(double Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(double Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new DoubleNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public DoubleNumber(double Value)
            : base(Value)
            {

            }
        }
    }