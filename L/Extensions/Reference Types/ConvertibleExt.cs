using System;
using JetBrains.Annotations;
using LCore.Interfaces;
using LCore.Numbers;
using LCore.Tests;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods to IConvertible objects.
    /// </summary>
    [ExtensionProvider]
    public static class ConvertibleExt
        {
        #region Extensions +

        #region CanConvertTo
        /// <summary>
        /// Returns whether or not an IConvertible object <paramref name="In" /> can be, safely and without 
        /// any data loss, converted to type <typeparamref name="T" />
        /// </summary>
        [Tested]
        public static bool CanConvertTo<T>([CanBeNull]this IConvertible In)
            where T : struct, IConvertible
            {
            if (In == null)
                return false;

            try
                {
                // If [In] is a string, then we need to make sure to trim off unneeded 0's and decimal point, 
                // otherwise equality test will fail.
                while (In is string &&
                    ((string)In).Length > 1 &&
                    ((string)In).Contains(".") &&
                    (((string)In).EndsWith("0") || ((string)In).EndsWith(".")))
                    In = ((string)In).Sub(0, ((string)In).Length - 1);

                T? Out = In.ConvertTo<T>();

                var Verify = Out.ConvertTo(In.GetType());

                return Equals(Verify, In);
                }
            catch
                {
                return false;
                }
            }
        /// <summary>
        /// Returns whether or not an IConvertible object <paramref name="In" /> can be, safely and without 
        /// any data loss, converted to type <paramref name="Type"/>
        /// </summary>
        public static bool CanConvertTo([CanBeNull]this IConvertible In, [CanBeNull]Type Type)
            {
            if (In == null || Type == null)
                return false;

            try
                {
                var Out = (IConvertible)In.ConvertTo(Type);

                // If [In] is a string, then we need to make sure to trim off unneeded 0's and decimal point, 
                // otherwise equality test will fail.
                while (Out is string &&
                    ((string)Out).Length > 1 &&
                    ((string)In).Contains(".") &&
                    (((string)Out).EndsWith("0") || ((string)Out).EndsWith(".")))
                    Out = ((string)Out).Sub(0, ((string)Out).Length - 1);

                var Verify = Out.ConvertTo(In.GetType());

                return Equals(Verify, In);
                }
            catch
                {
                return false;
                }
            }
        #endregion

        #region CanConvertToString

        /// <summary>
        /// Returns whether or not an IConvertible object <paramref name="In" /> can be, safely and without 
        /// any data loss, converted to a string.
        /// </summary>
        [Tested]
        public static bool CanConvertToString([CanBeNull]this IConvertible In)
            {
            if (In == null)
                return false;

            string Out = In.ConvertToString();

            var Verify = Out.ConvertTo(In.GetType());

            return Equals(Verify, In);
            }

        #endregion

        #region ConvertTo
        /// <summary>
        /// Converts an IConvertible to type <paramref name="Type"/>, if it is capable.
        /// </summary>
        /// <exception cref="System.FormatException">Throws a format exception if the format is not correct for the output type.</exception>
        [Tested]
        public static object ConvertTo([CanBeNull]this IConvertible In, [CanBeNull]Type Type)
            {
            if (In is double)
                In = ((DoubleNumber)(double)In).ToString();
            if (In is float)
                In = ((FloatNumber)(float)In).ToString();
            if (In is decimal)
                In = ((DecimalNumber)(decimal)In).ToString();

            // If [In] is a string, then we need to make sure to trim off unneeded 0's and decimal point, 
            // otherwise equality test will fail.
            while (In is string &&
                ((string)In).Length > 1 &&
                ((string)In).Contains(".") &&
                (((string)In).EndsWith("0") || ((string)In).EndsWith(".")))
                In = ((string)In).Sub(0, ((string)In).Length - 1);

            try
                {
                return In == null ? null : Convert.ChangeType(In, Type);
                }
            catch (InvalidCastException)
                {
                }
            catch (OverflowException)
                {
                }

            return null;
            }

        /// <summary>
        /// Converts an IConvertible to type <typeparamref name="T" />, if it is capable.
        /// </summary>
        /// <exception cref="System.FormatException">Throws a format exception if the format is not correct for the output type.</exception>
        [Tested]
        public static T? ConvertTo<T>([CanBeNull]this IConvertible In)
            where T : struct, IConvertible
            {
            if (In == null)
                return default(T);

            if (In is double)
                In = ((DoubleNumber)(double)In).ToString();
            if (In is float)
                In = ((FloatNumber)(float)In).ToString();
            if (In is decimal)
                In = ((DecimalNumber)(decimal)In).ToString();

            // If [In] is a string, then we need to make sure to trim off unneeded 0's and decimal point, 
            // otherwise equality test will fail.
            while (In is string &&
                ((string)In).Length > 1 &&
                ((string)In).Contains(".") &&
                (((string)In).EndsWith("0") || ((string)In).EndsWith(".")))
                In = ((string)In).Sub(0, ((string)In).Length - 1);

            try
                {
                return (T)Convert.ChangeType(In, typeof(T));
                }
            catch (InvalidCastException) { }
            catch (OverflowException) { }

            return default(T);
            }
        #endregion

        #region ConvertToString

        /// <summary>
        /// Converts an IConvertible to a string, if it is capable.
        /// </summary>
        [Tested]
        [CanBeNull]
        public static string ConvertToString([CanBeNull]this IConvertible In)
            {
            if (In == null)
                return null;

            try
                {
                return (string)Convert.ChangeType(In, typeof(string));
                }
            catch { }

            return null;
            }

        #endregion

        #region TryConvertTo
        /// <summary>
        /// Converts an IConvertible to type <typeparamref name="T" />, if it is capable.
        /// If <paramref name="In" /> cannot be converted, the source will be returned.
        /// </summary>
        /// <exception cref="System.FormatException">Throws a format exception if the format is not correct for the output type.</exception>
        [Tested]
        public static IConvertible TryConvertTo<T>([CanBeNull]this IConvertible In)
            where T : struct, IConvertible
            {
            if (In == null)
                return null;

            return In.CanConvertTo<T>() ? In.ConvertTo<T>() : In;
            }
        #endregion

        #region TryConvertToString

        /// <summary>
        /// Converts an IConvertible to a string, if it is capable.
        /// If <paramref name="In" /> cannot be converted, the source will be returned.
        /// </summary>
        [Tested]
        public static IConvertible TryConvertToString([CanBeNull]this IConvertible In)
            {
            if (In == null)
                return null;

            return In.CanConvertToString()
                ? In.ConvertToString()
                : In;
            }

        #endregion

        #endregion
        }
    }