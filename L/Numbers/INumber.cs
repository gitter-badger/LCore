using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Numbers
    {
    /// <summary>
    /// Provides an abstraction layer to all number types
    /// </summary>
    /// <typeparam name="T">Native number type</typeparam>
    public interface INumber<T> : INumber
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
        /// <summary>
        /// The smallest storable change in value for type <typeparamref name="T"/>.
        /// </summary>
        Number<T> TypePrecision { get; }
        /// <summary>
        /// The lowest possible value for type <typeparamref name="T"/>.
        /// </summary>
        Number<T> TypeMinValue { get; }
        /// <summary>
        /// The highest possible value for type <typeparamref name="T"/>.
        /// </summary>
        Number<T> TypeMaxValue { get; }
        /// <summary>
        /// The default value for type <typeparamref name="T"/>.
        /// </summary>
        Number<T> TypeDefaultValue { get; }

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        Number<T> New(T In);

        /// <summary>
        /// The base number object
        /// </summary>
        T Value { get; }
        }

    /// <summary>
    /// Provides an abstraction layer to all number types
    /// </summary>
    public interface INumber : IComparable
        {
        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        Number New(object In);

        /// <summary>
        /// The smallest storable change in value for the type.
        /// </summary>
        Number Precision { get; }
        /// <summary>
        /// The lowest possible value for the type.
        /// </summary>
        Number MinValue { get; }
        /// <summary>
        /// The highest possible value for the type.
        /// </summary>
        Number MaxValue { get; }
        /// <summary>
        /// The default value for the type.
        /// </summary>
        Number DefaultValue { get; }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Divide(Number Value);
        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Multiply(Number Value);
        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Subtract(Number Value);
        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Add(Number Value);

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        /// 
        Number Divide(IConvertible Value);
        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Multiply(IConvertible Value);
        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Subtract(IConvertible Value);
        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// <returns>A double result</returns>
        Number Add(IConvertible Value);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        Number GetValuePrecision();

        /// <summary>
        /// Gets the underlying value
        /// </summary>
        object GetValue();
        }
    }