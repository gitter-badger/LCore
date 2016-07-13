using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for uint
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class UIntNumber : Number<uint>
        {
        /// <summary>
        /// Implicitally convert a uint to a UIntNumber
        /// </summary>
        /// <param name="i">The uint to convert</param>
        public static implicit operator UIntNumber(uint i)
            {
            return new UIntNumber(i);
            }
        /// <summary>
        /// Implicitally convert a UIntNumber to a uint
        /// </summary>
        /// <param name="i">The UIntNumber to convert</param>
        public static implicit operator uint(UIntNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override uint Add(uint Value)
            {
            return this.Value + Value;
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override uint Subtract(uint Value)
            {
            return this.Value - Value;
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override uint Multiply(uint Value)
            {
            return this.Value * Value;
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(uint Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new UIntNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public UIntNumber(uint Value)
            : base(Value)
            {

            }
        }
    }