using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for int
    /// </summary>
    public class IntNumber : Number<int, IntNumber>
        {
        /// <summary>
        /// Implicitally convert a int to a NumberInt
        /// </summary>
        /// <param name="i">The int to convert</param>
        public static implicit operator IntNumber(int i)
            {
            return new IntNumber(i);
            }

        /// <summary>
        /// Create a new NumberInt wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public IntNumber(int Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new IntNumber wrapper for a int
        /// </summary>
        public IntNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type int.
        /// </summary>
        public override Number<int> TypePrecision => (IntNumber)1;

        /// <summary>
        /// The lowest possible value for type int.
        /// </summary>
        public override Number<int> TypeMinValue => (IntNumber)int.MinValue;

        /// <summary>
        /// The highest possible value for type int.
        /// </summary>
        public override Number<int> TypeMaxValue => (IntNumber)int.MaxValue;

        /// <summary>
        /// The default value for type int.
        /// </summary>
        public override Number<int> TypeDefaultValue => (IntNumber)default(int);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (IntNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a int.
        /// </summary>
        public override int Add(int Number1, int Number2)
            {
            return (int)((int)Number1 + (int)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a int.
        /// </summary>
        public override int Subtract(int Number1, int Number2)
            {
            return (int)((int)Number1 - (int)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a int.
        /// </summary>
        public override int Multiply(int Number1, int Number2)
            {
            return (int)((int)Number1 * (int)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(int Number1, int Number2)
            {
            return (double)((int)Number1 / (int)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<int> New(int In)
            {
            return new IntNumber(In);
            }
        }
    }