using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

// ReSharper disable RedundantCast

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an implementation of INumber for double
    /// </summary>
    public class DoubleNumber : Number<double, DoubleNumber>
        {
        /// <summary>
        /// Implicitally convert a double to a DoubleNumber
        /// </summary>
        /// <param name="i">The double to convert</param>
        public static implicit operator DoubleNumber(double i)
            {
            return new DoubleNumber(i);
            }

        /// <summary>
        /// Create a new DoubleNumber wrapper for a decimal
        /// </summary>
        /// <param name="Value">Number value</param>
        public DoubleNumber(double Value)
            : base(Value) {}

        /// <summary>
        /// Create a new DoubleNumber wrapper for a double
        /// </summary>
        public DoubleNumber() {}

        /// <summary>
        /// The smallest storable change in value for type double.
        /// </summary>
        public override Number<double> TypePrecision => (DoubleNumber) double.Epsilon;

        /// <summary>
        /// The lowest possible value for type double.
        /// </summary>
        public override Number<double> TypeMinValue => (DoubleNumber) double.MinValue;

        /// <summary>
        /// The highest possible value for type double.
        /// </summary>
        public override Number<double> TypeMaxValue => (DoubleNumber) double.MaxValue;

        /// <summary>
        /// The default value for type double.
        /// </summary>
        public override Number<double> TypeDefaultValue => (DoubleNumber) default(double);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public override Number GetValuePrecision()
            {
            return (DoubleNumber) ((double) 10).Pow(-this.Value.DecimalPlaces());
            }

        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        public override double Add(double Number1, double Number2)
            {
            return (double) ((double) Number1 + (double) Number2);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        public override double Subtract(double Number1, double Number2)
            {
            return (double) ((double) Number1 - (int) Number2);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        public override double Multiply(double Number1, double Number2)
            {
            return (double) ((double) Number1*(double) Number2);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A double result</returns>
        public override object Divide(double Number1, double Number2)
            {
            return (double) ((double) Number1/(double) Number2);
            }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public override Number<double> New(double In)
            {
            return new DoubleNumber(In);
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