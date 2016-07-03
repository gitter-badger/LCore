using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for byte
    /// </summary>
    public class NumberByte : Number<byte>
        {
        /// <summary>
        /// Implicitally convert a byte to a NumberByte
        /// </summary>
        /// <param name="i">The byte to convert</param>
        public static implicit operator NumberByte(byte i)
            {
            return new NumberByte(i);
            }
        /// <summary>
        /// Implicitally convert a NumberByte to a byte
        /// </summary>
        /// <param name="i">The NumberByte to convert</param>
        public static implicit operator byte(NumberByte i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override byte Add(byte Value)
            {
            return (byte)(this.Value + Value);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override byte Subtract(byte Value)
            {
            return (byte)(this.Value - Value);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override byte Multiply(byte Value)
            {
            return (byte)(this.Value * Value);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(byte Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new NumberByte wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public NumberByte(byte Value)
            : base(Value)
            {

            }
        }
    }