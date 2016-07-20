using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for ulong
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class ULongNumber : Number<ulong, ULongNumber>
        {
        /// <summary>
        /// Implicitally convert a ulong to a ULongNumber
        /// </summary>
        /// <param name="i">The ulong to convert</param>
        public static implicit operator ULongNumber(ulong i)
            {
            return new ULongNumber(i);
            }

        /// <summary>
        /// Create a new ULongNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public ULongNumber(ulong Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new ULongNumber wrapper for a ulong
        /// </summary>
        public ULongNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type ulong.
        /// </summary>
        public override Number<ulong> TypePrecision => (ULongNumber)(ulong)1;

        /// <summary>
        /// The lowest possible value for type ulong.
        /// </summary>
        public override Number<ulong> TypeMinValue => (ULongNumber)ulong.MinValue;

        /// <summary>
        /// The highest possible value for type ulong.
        /// </summary>
        public override Number<ulong> TypeMaxValue => (ULongNumber)ulong.MaxValue;

        /// <summary>
        /// The default value for type ulong.
        /// </summary>
        public override Number<ulong> TypeDefaultValue => (ULongNumber)default(ulong);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (ULongNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a ulong.
        /// </summary>
        public override ulong Add(ulong Number1, ulong Number2)
            {
            return (ulong)((ulong)Number1 + (ulong)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a ulong.
        /// </summary>
        public override ulong Subtract(ulong Number1, ulong Number2)
            {
            return (ulong)((ulong)Number1 - (ulong)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a ulong.
        /// </summary>
        public override ulong Multiply(ulong Number1, ulong Number2)
            {
            return (ulong)((ulong)Number1 * (ulong)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(ulong Number1, ulong Number2)
            {
            return (double)((ulong)Number1 / (ulong)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<ulong> New(ulong In)
            {
            return new ULongNumber(In);
            }
        }
    }