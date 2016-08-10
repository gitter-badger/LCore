using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for decimal
    /// </summary>
   // [Number(typeof(decimal), decimal.MinValue, decimal.MaxValue, decimal.One)]
    public class DecimalNumber : Number<decimal, DecimalNumber>
        {
        /// <summary>
        /// Implicitally convert a decimal to a DecimalNumber
        /// </summary>
        /// <param name="i">The decimal to convert</param>
        public static implicit operator DecimalNumber(decimal i)
            {
            return new DecimalNumber(i);
            }

        /// <summary>
        /// Create a new DecimalNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public DecimalNumber(decimal Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new DecimalNumber wrapper for a decimal
        /// </summary>
        public DecimalNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type decimal.
        /// </summary>
        public override Number<decimal> TypePrecision => (DecimalNumber)(decimal)0.0000000000000000000000000001m;

        /// <summary>
        /// The lowest possible value for type decimal.
        /// </summary>
        public override Number<decimal> TypeMinValue => (DecimalNumber)decimal.MinValue;

        /// <summary>
        /// The highest possible value for type decimal.
        /// </summary>
        public override Number<decimal> TypeMaxValue => (DecimalNumber)decimal.MaxValue;

        /// <summary>
        /// The default value for type decimal.
        /// </summary>
        public override Number<decimal> TypeDefaultValue => (DecimalNumber)default(decimal);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (DecimalNumber)(decimal)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a decimal.
        /// </summary>
        public override decimal Add(decimal Number1, decimal Number2)
            {
            return (decimal)((decimal)Number1 + (decimal)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a decimal.
        /// </summary>
        public override decimal Subtract(decimal Number1, decimal Number2)
            {
            return (decimal)((decimal)Number1 - (decimal)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a decimal.
        /// </summary>
        public override decimal Multiply(decimal Number1, decimal Number2)
            {
            return (decimal)((decimal)Number1 * (decimal)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(decimal Number1, decimal Number2)
            {
            return (double)((decimal)Number1 / (decimal)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<decimal> New(decimal In)
            {
            return new DecimalNumber(In);
            }


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
            {
            string Out = this.Value.ToString("0." + new string(c: '#', count: 339));

            if (Out.Contains("."))
                Out = Out.TrimEnd("0");

            return Out;
            }
        }
    }