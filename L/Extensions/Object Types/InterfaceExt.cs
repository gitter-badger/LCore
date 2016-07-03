using System;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods to common Interface types:
    /// IConvertible
    /// </summary>
    [ExtensionProvider]
    public static class InterfaceExt
        {
        #region Extensions +

        #region ConvertTo
        /// <summary>
        /// Converts an IConvertible to type [t], if it is capable.
        /// </summary>
        public static object ConvertTo(this IConvertible In, Type t)
            {
            return In == null ? null : Convert.ChangeType(In, t);
            }

        /// <summary>
        /// Converts an IConvertible to type [T], if it is capable.
        /// </summary>
        public static T ConvertTo<T>(this IConvertible In) where T : IConvertible
            {
            if (In == null)
                return default(T);

            return (T)Convert.ChangeType(In, typeof(T));
            }
        #endregion

        #endregion
        }
    }