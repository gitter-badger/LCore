using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for short
    /// </summary>
    public class ShortNumber : Number<short, ShortNumber>
        {
        /// <summary>
        /// Implicitally convert a short to a ShortNumber
        /// </summary>
        /// <param name="i">The short to convert</param>
        public static implicit operator ShortNumber(short i)
            {
            return new ShortNumber(i);
            }

        /// <summary>
        /// Create a new ShortNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public ShortNumber(short Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new ShortNumber wrapper for a short
        /// </summary>
        public ShortNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type short.
        /// </summary>
        public override Number<short> TypePrecision => (ShortNumber)(short)1;

        /// <summary>
        /// The lowest possible value for type short.
        /// </summary>
        public override Number<short> TypeMinValue => (ShortNumber)short.MinValue;

        /// <summary>
        /// The highest possible value for type short.
        /// </summary>
        public override Number<short> TypeMaxValue => (ShortNumber)short.MaxValue;

        /// <summary>
        /// The default value for type short.
        /// </summary>
        public override Number<short> TypeDefaultValue => (ShortNumber)default(short);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (ShortNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a short.
        /// </summary>
        public override short Add(short Number1, short Number2)
            {
            return (short)((short)Number1 + (short)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a short.
        /// </summary>
        public override short Subtract(short Number1, short Number2)
            {
            return (short)((short)Number1 - (short)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a short.
        /// </summary>
        public override short Multiply(short Number1, short Number2)
            {
            return (short)((short)Number1 * (short)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(short Number1, short Number2)
            {
            return (double)((short)Number1 / (short)Number2);
            }


        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<short> New(short In)
            {
            return new ShortNumber(In);
            }
        }
    }