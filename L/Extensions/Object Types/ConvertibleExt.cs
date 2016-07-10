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
        /// Returns whether or not an IConvertible object [In] can be, safely and without 
        /// any data loss, converted to type [T]
        /// </summary>
        [Tested]
        public static bool CanConvertTo<T>(this IConvertible In)
            where T : IConvertible
            {
            if (In == null)
                return false;

            try
                {
                var Out = In.ConvertTo<T>();
                var Verify = Out.ConvertTo(In.GetType());


                return Equals(Verify, In);
                }
            catch
                {
                return false;
                }
            }
        #endregion

        #region ConvertTo
        /// <summary>
        /// Converts an IConvertible to type [t], if it is capable.
        /// </summary>
        /// <exception cref="System.FormatException">Throws a format exception if the format is not correct for the output type.</exception>
        [Tested]
        public static object ConvertTo(this IConvertible In, Type t)
            {
            return In == null ? null : Convert.ChangeType(In, t);
            }

        /// <summary>
        /// Converts an IConvertible to type [T], if it is capable.
        /// </summary>
        /// <exception cref="System.FormatException">Throws a format exception if the format is not correct for the output type.</exception>
        [Tested]
        public static T ConvertTo<T>(this IConvertible In) where T : IConvertible
            {
            if (In == null)
                return default(T);

            return (T)Convert.ChangeType(In, typeof(T));
            }
        #endregion

        #region TryConvertTo
        /// <summary>
        /// Converts an IConvertible to type [t], if it is capable.
        /// </summary>
        /// <exception cref="System.FormatException">Throws a format exception if the format is not correct for the output type.</exception>
        [Tested]
        public static IConvertible TryConvertTo<T>(this IConvertible In)
            where T : IConvertible
            {
            if (In == null)
                return null;

            return In.CanConvertTo<T>() ? In.ConvertTo<T>() : In;
            }
        #endregion

        #endregion
        }
    }