using System;
using System.Reflection;
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
        [TestFails(new object[] { null })]
        [TestFails(new object[] { "" })]
        [TestFails(new object[] { "WRONG" })]
        [TestFails(new object[] { "left" })]
        [TestResult(new object[] { "Left" }, L.Align.Left)]
        [TestResult(new object[] { "Right" }, L.Align.Right)]
        public static T ParseEnum<T>(this string s)
            {
            return (T)Enum.Parse(typeof(T), s);
            }
        /// <summary>
        /// Takes a String and returns and Enum of Type [t].
        /// This method will fail if the String is null, empty, 
        /// or does not match a value of the enum.
        /// </summary>
        public static Enum ParseEnum(this string s, Type t)
            {
            return (Enum)Enum.Parse(t, s);
            }
        /// <summary>
        /// Takes an Enum of any type and converts it to an enum of the specified type T.
        /// This method will fail if the source enum is null or the String value of the source enum is not found in type T.
        /// </summary>
        [TestMethodGenerics(typeof(L.Align))]
        [TestFails(new object[] { null })]
        [TestFails(new object[] { Test.TestEnum.Top })]
        [TestResult(new object[] { Test.TestEnum.Left }, L.Align.Left)]
        [TestResult(new object[] { Test.TestEnum.Right }, L.Align.Right)]
        [TestResult(new object[] { Test.TestEnum.Top }, L.Align_Vertical.Top, GenericTypes = new[] { typeof(L.Align_Vertical) })]
        public static T ParseEnum<T>(this Enum e)
            {
            return e.ToString().ParseEnum<T>();
            }
        #endregion

        #region ParseEnum_FriendlyName
        /// <summary>
        /// Returns the friendly name of the value of an enum type.
        /// Add a friendly name by adding a [FriendlyName("")] attribute
        /// to the Enum element.
        /// </summary> 
        public static Enum ParseEnum_FriendlyName(this string s, Type t)
            {
            var Out = Enum.GetValues(t).Array<Enum>().First(
                e => e.ToString() == s ||
                    e.GetFriendlyName() == s);

            if (Out == null)
                throw new Exception($"Invalid Enum Friendly name: {t} {s}");

            return Out;
            }
        #endregion

        #region Flag
        /// <summary>
        /// Determines whether a flaggable enum contains a particular flag
        /// </summary>
        public static bool Flag(this Enum In, Enum Flag)
            {
            return In.HasFlag(Flag);
            }
        #endregion

        #region GetFriendlyName
        /// <summary>
        /// Returns the friendly name of the value of an enum type.
        /// Add a friendly name by adding a [FriendlyName("")] attribute
        /// to the Enum element.
        /// </summary> 
        public static string GetFriendlyName(this Enum In)
            {
            var t = In.GetType();
            MemberInfo[] Members = t.GetMembers();
            var Member = Members.First(o => o.Name == In.ToString());

            var Attr = Member?.GetAttribute<IL_FriendlyName>();

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

        public enum Align_Vertical
            {
            Top, Middle, Bottom
            }
#pragma warning restore 1591
        }
    }