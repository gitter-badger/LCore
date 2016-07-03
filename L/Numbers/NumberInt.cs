using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for int
    /// </summary>
    public class NumberInt : Number<int>
        {
        /// <summary>
        /// Implicitally convert a int to a NumberInt
        /// </summary>
        /// <param name="i">The int to convert</param>
        public static implicit operator NumberInt(int i)
            {
            return new NumberInt(i);
            }
        /// <summary>
        /// Implicitally convert a NumberInt to a int
        /// </summary>
        /// <param name="i">The NumberInt to convert</param>
        public static implicit operator int(NumberInt i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override int Add(int Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override int Subtract(int Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override int Multiply(int Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(int Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new NumberInt wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public NumberInt(int Value)
            : base(Value)
            {

            }
        }
    }