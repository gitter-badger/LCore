using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for long
    /// </summary>
    public class LongNumber : Number<long, LongNumber>
        {
        /// <summary>
        /// Implicitally convert a long to a LongNumber
        /// </summary>
        /// <param name="i">The long to convert</param>
        public static implicit operator LongNumber(long i)
            {
            return new LongNumber(i);
            }

        /// <summary>
        /// Create a new LongNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public LongNumber(long Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new LongNumber wrapper for a long
        /// </summary>
        public LongNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type long.
        /// </summary>
        public override Number<long> TypePrecision => (LongNumber)(long)1;

        /// <summary>
        /// The lowest possible value for type long.
        /// </summary>
        public override Number<long> TypeMinValue => (LongNumber)long.MinValue;

        /// <summary>
        /// The highest possible value for type long.
        /// </summary>
        public override Number<long> TypeMaxValue => (LongNumber)long.MaxValue;

        /// <summary>
        /// The default value for type long.
        /// </summary>
        public override Number<long> TypeDefaultValue => (LongNumber)default(long);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (LongNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a long.
        /// </summary>
        public override long Add(long Number1, long Number2)
            {
            return (long)((long)Number1 + (long)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a long.
        /// </summary>
        public override long Subtract(long Number1, long Number2)
            {
            return (long)((long)Number1 - (long)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a long.
        /// </summary>
        public override long Multiply(long Number1, long Number2)
            {
            return (long)((long)Number1 * (long)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(long Number1, long Number2)
            {
            return (double)((long)Number1 / (long)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<long> New(long In)
            {
            return new LongNumber(In);
            }
        }
    }