using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for ushort
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class UShortNumber : Number<ushort, UShortNumber>
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
        /// Create a new UShortNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public UShortNumber(ushort Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new UShortNumber wrapper for a ushort
        /// </summary>
        public UShortNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type ushort.
        /// </summary>
        public override Number<ushort> TypePrecision => (UShortNumber)(ushort)1;

        /// <summary>
        /// The lowest possible value for type ushort.
        /// </summary>
        public override Number<ushort> TypeMinValue => (UShortNumber)ushort.MinValue;

        /// <summary>
        /// The highest possible value for type ushort.
        /// </summary>
        public override Number<ushort> TypeMaxValue => (UShortNumber)ushort.MaxValue;

        /// <summary>
        /// The default value for ushort.
        /// </summary>
        public override Number<ushort> TypeDefaultValue => (UShortNumber)default(ushort);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (UShortNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a ushort.
        /// </summary>
        public override ushort Add(ushort Number1, ushort Number2)
            {
            return (ushort)((ushort)Number1 + (ushort)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a ushort.
        /// </summary>
        public override ushort Subtract(ushort Number1, ushort Number2)
            {
            return (ushort)((ushort)Number1 - (ushort)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a ushort.
        /// </summary>
        public override ushort Multiply(ushort Number1, ushort Number2)
            {
            return (ushort)((ushort)Number1 * (ushort)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(ushort Number1, ushort Number2)
            {
            return (double)((ushort)Number1 / (ushort)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<ushort> New(ushort In)
            {
            return new UShortNumber(In);
            }
        }
    }