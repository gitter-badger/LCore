using System;
using JetBrains.Annotations;
using LCore.Interfaces;
using LCore.Tests;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extension methods to IComparable objects.
    /// </summary>
    [ExtensionProvider]
    public static class ComparableExt
        {
        #region Extensions +

        #region IsEqualTo
        /// <summary>
        /// Use this fluent extension method to compare IComparable equality.
        /// </summary>
        public static bool IsEqualTo(this IComparable In, IComparable Obj)
            {
            return In.CompareTo(Obj) == 0;
            }

        #endregion

        #region IsNotEqualTo
        /// <summary>
        /// Use this fluent extension method to compare IComparable inequality.
        /// </summary>
        public static bool IsNotEqualTo(this IComparable In, IComparable Obj)
            {
            return In.CompareTo(Obj) != 0;
            }

        #endregion

        #region IsLessThan
        /// <summary>
        /// Use this fluent extension method to compare one IComparable to another.
        /// </summary>
        public static bool IsLessThan(this IComparable In, IComparable Obj)
            {
            return In.CompareTo(Obj) < 0;
            }

        #endregion

        #region IsLessThanOrEqual
        /// <summary>
        /// Use this fluent extension method to compare one IComparable to another.
        /// </summary>
        public static bool IsLessThanOrEqual(this IComparable In, IComparable Obj)
            {
            return In.CompareTo(Obj) <= 0;
            }

        #endregion

        #region IsGreaterThan
        /// <summary>
        /// Use this fluent extension method to compare one IComparable to another.
        /// </summary>
        public static bool IsGreaterThan(this IComparable In, IComparable Obj)
            {
            return In.CompareTo(Obj) > 0;
            }

        #endregion

        #region IsGreaterThanOrEqual
        /// <summary>
        /// Use this fluent extension method to compare one IComparable to another.
        /// </summary>
        public static bool IsGreaterThanOrEqual(this IComparable In, IComparable Obj)
            {
            return In.CompareTo(Obj) >= 0;
            }

        #endregion

        #region Max
        /// <summary>
        /// Returns the largest of <paramref name="In" /> and all items in <paramref name="Others" />
        /// </summary>
        [Tested]
        public static T Max<T>([CanBeNull]this T In, params T[] Others)
            where T : IComparable
            {
            var Out = In;

            foreach (var Item in Others)
                {
                if (Out == null ||
                    (Item != null && Item.CompareTo(Out) > 0))
                    Out = Item;
                }

            return Out;
            }
        #endregion

        #region Min
        /// <summary>
        /// Returns the smallest of <paramref name="In" /> and all items in <paramref name="Others" />
        /// </summary>
        [Tested]
        public static T Min<T>([CanBeNull]this T In, params T[] Others)
            where T : IComparable
            {
            var Out = In;

            foreach (var Item in Others)
                {
                if (Out == null ||
                    (Item != null && Item.CompareTo(Out) < 0))
                    Out = Item;
                }

            return Out;
            }
        #endregion

        #endregion
        }
    }