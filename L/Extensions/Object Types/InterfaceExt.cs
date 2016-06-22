using System;

namespace LCore.Extensions
    {
    public static class InterfaceExt
        {
        /* TODO: L: Interface: Test All Below */
        /* TODO: L: Interface: Comment All Below */
        /* TODO: L: Interface: Sort All Below */

        #region Extensions

        #region ConvertTo
        public static object ConvertTo(this IConvertible In, Type t)
            {
            return In == null ? null : Convert.ChangeType(In, t);
            }

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