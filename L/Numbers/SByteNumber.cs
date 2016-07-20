using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for sbyte
    /// </summary>
    public class SByteNumber : Number<sbyte, SByteNumber>
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
        /// Create a new SByteNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public SByteNumber(sbyte Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new SByteNumber wrapper for a sbyte
        /// </summary>
        public SByteNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type sbyte.
        /// </summary>
        public override Number<sbyte> TypePrecision => (SByteNumber)(sbyte)1;

        /// <summary>
        /// The lowest possible value for type sbyte.
        /// </summary>
        public override Number<sbyte> TypeMinValue => (SByteNumber)sbyte.MinValue;

        /// <summary>
        /// The highest possible value for type sbyte.
        /// </summary>
        public override Number<sbyte> TypeMaxValue => (SByteNumber)sbyte.MaxValue;

        /// <summary>
        /// The default value for type sbyte.
        /// </summary>
        public override Number<sbyte> TypeDefaultValue => (SByteNumber)default(sbyte);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (SByteNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as an sbyte.
        /// </summary>
        public override sbyte Add(sbyte Number1, sbyte Number2)
            {
            return (sbyte)((sbyte)Number1 + (sbyte)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as an sbyte.
        /// </summary>
        public override sbyte Subtract(sbyte Number1, sbyte Number2)
            {
            return (sbyte)((sbyte)Number1 - (sbyte)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as an sbyte.
        /// </summary>
        public override sbyte Multiply(sbyte Number1, sbyte Number2)
            {
            return (sbyte)((sbyte)Number1 * (sbyte)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(sbyte Number1, sbyte Number2)
            {
            return (double)((sbyte)Number1 / (sbyte)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<sbyte> New(sbyte In)
            {
            return new SByteNumber(In);
            }
        }
    }