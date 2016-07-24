using System;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Tests;
using LCore.Naming;
using LCore.Interfaces;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions to allow for conversion and utility of Enum types.
    /// </summary>
    [ExtensionProvider]
    public static class EnumExt
        {
        #region Extensions +

        #region ParseEnum
        /// <summary>
        /// Takes a String and returns and Enum of Type T.
        /// This method will fail if the String is null, empty, or does not match a value of the enum.
        /// </summary>
        [TestMethodGenerics(typeof(L.Align))]
        [TestResult(new object[] { null }, null)]
        [TestResult(new object[] { "" }, null)]
        [TestResult(new object[] { "WRONG" }, null)]
        [TestResult(new object[] { "left" }, null)]
        [TestResult(new object[] { "Left" }, L.Align.Left)]
        [TestResult(new object[] { "Right" }, L.Align.Right)]
        public static T? ParseEnum<T>([CanBeNull]this string Str)
             where T : struct
            {
            try
                {
                return (T)Enum.Parse(typeof(T), Str);
                }
            catch { }

            return null;
            }

        /// <summary>
        /// Takes a String and returns and Enum of Type <paramref name="Type" />.
        /// This method will fail if the String is null, empty, 
        /// or does not match a value of the enum.
        /// </summary>
        [Tested]
        public static Enum ParseEnum([CanBeNull]this string Str, [CanBeNull]Type Type)
            {
            try
                {
                return (Enum)Enum.Parse(Type, Str);
                }
            catch { }

            return null;
            }
        /// <summary>
        /// Takes an Enum of any type and converts it to an enum of the specified type T.
        /// This method will fail if the source enum is null or the String value of the source enum is not found in type T.
        /// </summary>
        [TestMethodGenerics(typeof(L.Align))]
        [TestResult(new object[] { null }, null)]
        [TestResult(new object[] { Test.TestEnum.Top }, null)]
        [TestResult(new object[] { Test.TestEnum.Left }, L.Align.Left)]
        [TestResult(new object[] { Test.TestEnum.Right }, L.Align.Right)]
        [TestResult(new object[] { Test.TestEnum.Top }, L.AlignVertical.Top, GenericTypes = new[] { typeof(L.AlignVertical) })]
        public static T? ParseEnum<T>([CanBeNull]this Enum Enum)
             where T : struct
            {
            return Enum?.ToString().ParseEnum<T>();
            }

        #endregion

        #region ParseEnum_FriendlyName
        /// <summary>
        /// Returns the friendly name of the value of an enum type.
        /// Add a friendly name by adding a FriendlyNameAttribute
        /// to the Enum element.
        /// 
        /// If the enum friendly name is not found, null will be returned.
        /// </summary> 
        [Tested]
        public static Enum ParseEnum_FriendlyName(this string Str, Type Type)
            {
            var Out = Enum.GetValues(Type).Array<Enum>().First(
                Enum => Enum.ToString() == Str ||
                    Enum.GetFriendlyName() == Str);

            return Out;
            }
        #endregion

        #region GetFriendlyName
        /// <summary>
        /// Returns the friendly name of the value of an enum type.
        /// Add a friendly name by adding a FriendlyNameAttribute
        /// to the Enum element.
        /// </summary> 
        [Tested]
        public static string GetFriendlyName([CanBeNull]this Enum In)
            {
            if (In == null)
                return "";

            var Type = In.GetType();
            MemberInfo[] Members = Type.GetMembers();
            var Member = Members.First(o => o.Name == In.ToString());

            var Attr = Member?.GetAttribute<IFriendlyName>();

            return Attr != null ?
                Attr.FriendlyName :
                In.ToString().Humanize();
            }
        #endregion

        #endregion

        internal static class Test
            {
            #region Test
            public enum TestEnum
                {
                [FriendlyName("l")]
                Left,
                Center,
                Right,
                Top,
                Middle,
                Bottom,
                None
                }
            #endregion
            }
        }
    public static partial class L
        {
#pragma warning disable 1591
        public enum Align
            {
            Left, Center, Right
            }

        public enum AlignVertical
            {
            Top, Middle, Bottom
            }
#pragma warning restore 1591
        }
    }