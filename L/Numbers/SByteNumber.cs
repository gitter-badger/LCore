using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for sbyte
    /// </summary>
    public class SByteNumber : Number<sbyte>
        {
        /// <summary>
        /// Implicitally convert a sbyte to a SByteNumber
        /// </summary>
        /// <param name="i">The sbyte to convert</param>
        public static implicit operator SByteNumber(sbyte i)
            {
            return new SByteNumber(i);
            }
        /// <summary>
        /// Implicitally convert a SByteNumber to a sbyte
        /// </summary>
        /// <param name="i">The SByteNumber to convert</param>
        public static implicit operator sbyte(SByteNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override sbyte Add(sbyte Value)
            {
            return (sbyte)(this.Value + Value);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override sbyte Subtract(sbyte Value)
            {
            return (sbyte)(this.Value - Value);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override sbyte Multiply(sbyte Value)
            {
            return (sbyte)(this.Value * Value);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(sbyte Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new SByteNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public SByteNumber(sbyte Value)
            : base(Value)
            {

            }
        }
    }