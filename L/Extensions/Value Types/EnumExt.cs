using System;
using System.Reflection;
using LCore.Tests;
using LCore.Naming;

namespace LCore.Extensions
    {
    public static class EnumExt
        {
        #region Extensions
        #region ParseEnum
        /// <summary>
        /// Takes a String and returns and Enum of Type T.
        /// This method will fail if the String is null, empty, or does not match a value of the enum.
        /// </summary>
        [TestMethodGenerics(typeof(Logic.Align))]
        [TestFails(new object[] { null })]
        [TestFails(new object[] { "" })]
        [TestFails(new object[] { "WRONG" })]
        [TestFails(new object[] { "left" })]
        [TestResult(new object[] { "Left" }, Logic.Align.Left)]
        [TestResult(new object[] { "Right" }, Logic.Align.Right)]
        public static T ParseEnum<T>(this string s)
            {
            return (T)EnumParser(typeof(T), s);
            }

        public static Enum ParseEnum(this string s, Type t)
            {
            return (Enum)EnumParser(t, s);
            }
        /// <summary>
        /// Takes an Enum of any type and converts it to an enum of the specified type T.
        /// This method will fail if the source enum is null or the String value of the source enum is not found in type T.
        /// </summary>
        [TestMethodGenerics(typeof(Logic.Align))]
        [TestFails(new object[] { null })]
        [TestFails(new object[] { Test.TestEnum.Top })]
        [TestResult(new object[] { Test.TestEnum.Left }, Logic.Align.Left)]
        [TestResult(new object[] { Test.TestEnum.Right }, Logic.Align.Right)]
        [TestResult(new object[] { Test.TestEnum.Top }, Logic.Align_Vertical.Top, GenericTypes = new[] { typeof(Logic.Align_Vertical) })]
        public static T ParseEnum<T>(this Enum e)
            {
            return e.ToString().ParseEnum<T>();
            }
        #endregion

        /* TODO: L: Enum: Comment All Below */

        // TODO: L: Enum: Untested
        #region ParseEnum_FriendlyName
        public static Enum ParseEnum_FriendlyName(this string s, Type t)
            {
            Enum Out = Enum.GetValues(t).Array<Enum>().First(
                e => e.ToString() == s ||
                    e.GetFriendlyName() == s);

            if (Out == null)
                throw new Exception($"Invalid Enum Friendly name: {t} {s}");

            return Out;
            }
        #endregion

        // TODO: L: Enum: Untested
        #region Flag
        public static bool Flag(this Enum In, Enum Flag)
            {
            return In.HasFlag(Flag);
            }
        #endregion

        // TODO: L: Enum: Untested
        #region GetFriendlyName
        public static string GetFriendlyName(this Enum In)
            {
            Type t = In.GetType();
            MemberInfo[] Members = t.GetMembers();
            MemberInfo Member = Members.First(o => o.Name == In.ToString());

            IL_FriendlyName Attr = Member?.MemberGetAttribute<IL_FriendlyName>(true);

            return Attr != null ?
                Attr.FriendlyName :
                In.ToString().Humanize();
            }
        #endregion
        #endregion

        public static Func<Type, string, object> EnumParser = Enum.Parse;

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
    public partial class Logic
        {
        /* TODO: L: Enum: Comment All Below */
        #region Constants
        public enum Align { Left, Center, Right }
        public enum Align_Vertical { Top, Middle, Bottom }
        #endregion
        }
    }