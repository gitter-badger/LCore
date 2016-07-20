using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for byte
    /// </summary>
    public class ByteNumber : Number<byte, ByteNumber>
        {
        /// <summary>
        /// Implicitally convert a byte to a NumberByte
        /// </summary>
        /// <param name="i">The byte to convert</param>
        public static implicit operator ByteNumber(byte i)
            {
            return new ByteNumber(i);
            }

        /// <summary>
        /// Create a new NumberByte wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public ByteNumber(byte Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new ByteNumber wrapper for a byte
        /// </summary>
        public ByteNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type byte.
        /// </summary>
        public override Number<byte> TypePrecision => (ByteNumber)(byte)1;

        /// <summary>
        /// The lowest possible value for type byte.
        /// </summary>
        public override Number<byte> TypeMinValue => (ByteNumber)byte.MinValue;

        /// <summary>
        /// The highest possible value for type byte.
        /// </summary>
        public override Number<byte> TypeMaxValue => (ByteNumber)byte.MaxValue;

        /// <summary>
        /// The default value for type byte.
        /// </summary>
        public override Number<byte> TypeDefaultValue => (ByteNumber)default(byte);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (ByteNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a byte.
        /// </summary>
        public override byte Add(byte Number1, byte Number2)
            {
            return (byte)((byte)Number1 + (byte)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a byte.
        /// </summary>
        public override byte Subtract(byte Number1, byte Number2)
            {
            return (byte)((byte)Number1 - (byte)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a byte.
        /// </summary>
        public override byte Multiply(byte Number1, byte Number2)
            {
            return (byte)((byte)Number1 * (byte)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(byte Number1, byte Number2)
            {
            return (double)((byte)Number1 / (byte)Number2);
            }


        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<byte> New(byte In)
            {
            return new ByteNumber(In);
            }


        }
    }