using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for uint
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class UIntNumber : Number<uint, UIntNumber>
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
        /// Create a new UIntNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public UIntNumber(uint Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new UIntNumber wrapper for a uint
        /// </summary>
        public UIntNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type uint.
        /// </summary>
        public override Number<uint> TypePrecision => (UIntNumber)(uint)1;

        /// <summary>
        /// The lowest possible value for type uint.
        /// </summary>
        public override Number<uint> TypeMinValue => (UIntNumber)uint.MinValue;

        /// <summary>
        /// The highest possible value for type uint.
        /// </summary>
        public override Number<uint> TypeMaxValue => (UIntNumber)uint.MaxValue;

        /// <summary>
        /// The default value for type uint.
        /// </summary>
        public override Number<uint> TypeDefaultValue => (UIntNumber)default(uint);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (UIntNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a uint.
        /// </summary>
        public override uint Add(uint Number1, uint Number2)
            {
            return (uint)((uint)Number1 + (uint)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a uint.
        /// </summary>
        public override uint Subtract(uint Number1, uint Number2)
            {
            return (uint)((uint)Number1 - (uint)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a uint.
        /// </summary>
        public override uint Multiply(uint Number1, uint Number2)
            {
            return (uint)((uint)Number1 * (uint)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(uint Number1, uint Number2)
            {
            return (double)((uint)Number1 / (uint)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<uint> New(uint In)
            {
            return new UIntNumber(In);
            }
        }
    }