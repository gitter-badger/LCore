using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for ushort
    /// </summary>
    public class UShortNumber : Number<ushort>
        {
        /// <summary>
        /// Implicitally convert a ushort to a UShortNumber
        /// </summary>
        /// <param name="i">The ushort to convert</param>
        public static implicit operator UShortNumber(ushort i)
            {
            return new UShortNumber(i);
            }
        /// <summary>
        /// Implicitally convert a UShortNumber to a ushort
        /// </summary>
        /// <param name="i">The UShortNumber to convert</param>
        public static implicit operator ushort(UShortNumber i)
            {
            return i.Value;
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override ushort Add(ushort Value)
            {
            return (ushort)(this.Value + Value);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override ushort Subtract(ushort Value)
            {
            return (ushort)(this.Value - Value);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override ushort Multiply(ushort Value)
            {
            return (ushort)(this.Value * Value);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a double.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        public override double Divide(ushort Value)
            {
            return this.Value / Value;
            }

        /// <summary>
        /// Create a new UShortNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public UShortNumber(ushort Value)
            : base(Value)
            {

            }
        }
    }