using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;
// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for float
    /// </summary>
    public class FloatNumber : Number<float, FloatNumber>
        {
        /// <summary>
        /// Implicitally convert a float to a FloatNumber
        /// </summary>
        /// <param name="i">The float to convert</param>
        public static implicit operator FloatNumber(float i)
            {
            return new FloatNumber(i);
            }

        /// <summary>
        /// Create a new FloatNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public FloatNumber(float Value)
            : base(Value)
            {

            }

        /// <summary>
        /// Create a new FloatNumber wrapper for a float
        /// </summary>
        public FloatNumber()
            {
            }

        /// <summary>
        /// The smallest storable change in value for type float.
        /// </summary>
        public override Number<float> TypePrecision => (FloatNumber)float.Epsilon;

        /// <summary>
        /// The lowest possible value for type float.
        /// </summary>
        public override Number<float> TypeMinValue => (FloatNumber)float.MinValue;

        /// <summary>
        /// The highest possible value for type float.
        /// </summary>
        public override Number<float> TypeMaxValue => (FloatNumber)float.MaxValue;

        /// <summary>
        /// The default value for type float.
        /// </summary>
        public override Number<float> TypeDefaultValue => (FloatNumber)default(float);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (FloatNumber)((double)10).Pow(-this.Value.DecimalPlaces());
            }


        /// <summary>
        /// Applies the addition operation and returns the result as a float.
        /// </summary>
        public override float Add(float Number1, float Number2)
            {
            return (float)((float)Number1 + (float)Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a float.
        /// </summary>
        public override float Subtract(float Number1, float Number2)
            {
            return (float)((float)Number1 - (float)Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a float.
        /// </summary>
        public override float Multiply(float Number1, float Number2)
            {
            return (float)((float)Number1 * (float)Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a float.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(float Number1, float Number2)
            {
            return (double)((float)Number1 / (float)Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<float> New(float In)
            {
            return new FloatNumber(In);
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