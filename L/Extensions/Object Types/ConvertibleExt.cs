using System;
using LCore.Interfaces;
using LCore.Tests;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods to common Interface types:
    /// IConvertible
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
        public static bool CanConvertTo<T>(this IConvertible In)
            where T : struct, IConvertible
            {
            if (In == null)
                return false;

            try
                {
                T? Out = In.ConvertTo<T>();

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
        public static bool CanConvertToString(this IConvertible In)
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
        public static object ConvertTo(this IConvertible In, Type Type)
            {
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
        public static T? ConvertTo<T>(this IConvertible In)
            where T : struct, IConvertible
            {
            if (In == null)
                return default(T);

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
        public static string ConvertToString(this IConvertible In)
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
        public static IConvertible TryConvertTo<T>(this IConvertible In)
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
        public static IConvertible TryConvertToString(this IConvertible In)
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