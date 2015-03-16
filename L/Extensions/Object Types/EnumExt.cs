using System;
using System.Collections.Generic;
using System.Reflection;
using LCore.UnitTesting;

namespace LCore
{
    public partial class L
    {
        public enum Align { Left, Center, Right };
        public enum Align_Vertical { Top, Middle, Bottom };
    }
    public static class EnumExt
    {
        public static Func<Type, String, Object> EnumParser = Enum.Parse;

        #region ParseEnum
        /// <summary>
        /// Takes a String and returns and Enum of Type T.
        /// This method will fail if the String is null, empty, or does not match a value of the enum.
        /// </summary>
        [TestMethodGenerics(typeof(L.Align))]
        [TestFails(new Object[] { null })]
        [TestFails(new Object[] { "" })]
        [TestFails(new Object[] { "WRONG" })]
        [TestFails(new Object[] { "left" })]
        [TestResult(new Object[] { "Left" }, L.Align.Left)]
        [TestResult(new Object[] { "Right" }, L.Align.Right)]
        public static T ParseEnum<T>(this String s)
        {
            return EnumParser.Supply(typeof(T), s).Cast<Object, T>()();
        }
        public static Enum ParseEnum(this String s, Type t)
        {
            return (Enum)EnumParser(t, s);
        }
        /// <summary>
        /// Takes an Enum of any type and converts it to an enum of the specified type T.
        /// This method will fail if the source enum is null or the String value of the source enum is not found in type T.
        /// </summary>
        [TestMethodGenerics(typeof(L.Align))]
        [TestFails(new Object[] { null })]
        [TestFails(new Object[] { EnumExt.Test.TestEnum.Top })]
        [TestResult(new Object[] { EnumExt.Test.TestEnum.Left }, L.Align.Left)]
        [TestResult(new Object[] { EnumExt.Test.TestEnum.Right }, L.Align.Right)]
        [TestResult(new Object[] { EnumExt.Test.TestEnum.Top }, L.Align_Vertical.Top, GenericTypes = new Type[] { typeof(L.Align_Vertical) })]
        public static T ParseEnum<T>(this Enum e)
        {
            return e.ToString().ParseEnum<T>();
        }
        #endregion

        public static Enum ParseEnum_FriendlyName(this String s, Type t)
        {
            Enum Out = Enum.GetValues(t).Array<Enum>().First((e) =>
                {
                    return e.ToString() == s ||
                        e.GetFriendlyName() == s;
                });

            if (Out == null)
                throw new Exception("Invalid Enum Friendly name: " + t + " " + s);

            return Out;
        }

        public static Boolean Flag(this Enum In, Enum Flag)
        {
            return In.HasFlag(Flag);
        }
        public static String GetFriendlyName(this Enum In)
        {
            Type t = In.GetType();
            MemberInfo[] Members = t.GetMembers();
            MemberInfo Member = Members.First((o) => { return o.Name == In.ToString(); });
            if (Member != null)
            {
                IL_FriendlyName Attr = Member.MemberGetAttribute<IL_FriendlyName>(true);
                if (Attr != null)
                {
                    return Attr.FriendlyName;
                }
            }
            return In.ToString().Humanize();
        }
        /*
        public static Enum EnumOr(this IEnumerable<Enum> Enums)
            {
            Enums = Enums ?? new Enum[] { };

            Enum Out = null;
            if (!Enums.IsEmpty())
                {                
                Type EnumType = Enums[0].GetType();
                Enum.GetValues(EnumType);
                Enum.Parse
                    Enums.Each<Enum>((e) =>
                    {
                        if (Out == null)
                            Out = e;
                        else
                            Out = Out
                    });
                }
            return Out;
            }
        */

        internal static class Test
        {
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
            };
        }
    }
}