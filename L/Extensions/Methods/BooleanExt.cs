using System;
using System.Collections.Generic;
using LCore.Dynamic;
using LCore.ObjectExtensions;

namespace LCore
{
    public partial class L : Logic
    {
        #region Boolean Lambdas - Shorthand
        /// <summary>
        /// Returns a function that returns true
        /// </summary>
        public static readonly Func<Boolean> True = () => { return true; };
        /// <summary>
        /// Returns a function that returns false
        /// </summary>
        public static readonly Func<Boolean> False = () => { return false; };
        /// <summary>
        /// Returns a function that inverts the boolean it is sent.
        /// </summary>
        public static readonly Func<Boolean, Boolean> Not = (o) => { return !o; };
        /// <summary>
        /// Returns a function that ANDs the booleans that are sent
        /// </summary>
        public static readonly Func<Boolean, Boolean, Boolean> And = (b1, b2) => { return b1 && b2; };
        /// <summary>
        /// Returns a function that ORs the booleans that are sent
        /// </summary>
        public static readonly Func<Boolean, Boolean, Boolean> Or = (b1, b2) => { return b1 || b2; };
        /// <summary>
        /// Returns a function that XORs the booleans that are sent
        /// </summary>
        public static readonly Func<Boolean, Boolean, Boolean> Xor = (b1, b2) => { return b1 ^ b2; };
        #endregion

        #region Base Lambdas
        #region Boolean
        public static Func<String> Boolean_GetTrueString = () => { return Boolean.TrueString; };
        public static Func<String> Boolean_GetFalseString = () => { return Boolean.FalseString; };
        public static Func<Boolean, Int32> Boolean_GetHashCode = (b) => { return b.GetHashCode(); };
        public static Func<Boolean, String> Boolean_ToString = (b) => { return b.ToString(); };
        public static Func<Boolean, IFormatProvider, String> Boolean_ToString2 = (b, provider) => { return b.ToString(provider); };
        public static Func<Boolean, Object, Boolean> Boolean_Equals = (b, obj) => { return b.Equals(obj); };
        public static Func<Boolean, Boolean, Boolean> Boolean_Equals2 = (b, obj) => { return b.Equals(obj); };
        public static Func<Boolean, Object, Int32> Boolean_CompareTo = (b, obj) => { return b.CompareTo(obj); };
        public static Func<Boolean, Boolean, Int32> Boolean_CompareTo2 = (b, value) => { return b.CompareTo(value); };
        public static Func<String, Boolean> Boolean_Parse = (value) => { return Boolean.Parse(value); };
        public static Func<Boolean, TypeCode> Boolean_GetTypeCode = (b) => { return b.GetTypeCode(); };
        /* No Ref or Out Types 
        public static Func<String, Boolean&, Boolean> Boolean_TryParse = (value, result) => { return Boolean.TryParse(value, result); };
        */
        #endregion
        #endregion

        #region Boolean
        /// <summary>
        /// Returns a function that returns true
        /// </summary>
        public static readonly Func<Boolean> Boolean_True = () => { return true; };
        /// <summary>
        /// Returns a function that returns false
        /// </summary>
        public static readonly Func<Boolean> Boolean_False = () => { return false; };
        /// <summary>
        /// Returns a function that inverts the boolean it is sent.
        /// </summary>
        public static readonly Func<Boolean, Boolean> Boolean_Not = (o) => { return !o; };
        /// <summary>
        /// Returns a function that ANDs the booleans that are sent
        /// </summary>
        public static readonly Func<Boolean, Boolean, Boolean> Boolean_And = (b1, b2) => { return b1 && b2; };
        /// <summary>
        /// Returns a function that ORs the booleans that are sent
        /// </summary>
        public static readonly Func<Boolean, Boolean, Boolean> Boolean_Or = (b1, b2) => { return b1 || b2; };
        /// <summary>
        /// Returns a function that XORs the booleans that are sent
        /// </summary>
        public static Func<Boolean, Boolean, Boolean> Boolean_Xor = (b1, b2) => { return b1 ^ b2; };
        #endregion
    }
    public partial class Logic
    {
        #region Logic Lambdas
        #region If
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<Boolean>, Action, Func<Boolean>> L_If_A()
        {
            return (c, a) => { return () => { if (c()) { a(); return true; } return false; }; };
        }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, Boolean>, Action<T1>, Func<T1, Boolean>> L_If_A<T1>()
        {
            return (c, a) => { return (o) => { if (c(o)) { a(o); return true; } return false; }; };
        }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, T2, Boolean>, Action<T1, T2>, Func<T1, T2, Boolean>> L_If_A<T1, T2>()
        {
            return (c, a) => { return (o1, o2) => { if (c(o1, o2)) { a(o1, o2); return true; } return false; }; };
        }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, T2, T3, Boolean>, Action<T1, T2, T3>, Func<T1, T2, T3, Boolean>> L_If_A<T1, T2, T3>()
        {
            return (c, a) => { return (o1, o2, o3) => { if (c(o1, o2, o3)) { a(o1, o2, o3); return true; } return false; }; };
        }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, T2, T3, T4, Boolean>, Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, Boolean>> L_If_A<T1, T2, T3, T4>()
        {
            return (c, a) => { return (o1, o2, o3, o4) => { if (c(o1, o2, o3, o4)) { a(o1, o2, o3, o4); return true; } return false; }; };
        }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<Boolean>, Func<U>, Func<U>> L_If_F<U>()
        {
            return (c, a) => { return () => { if (c()) return a(); return default(U); }; };
        }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, Boolean>, Func<T1, U>, Func<T1, U>> L_If_F<T1, U>()
        {
            return (c, a) => { return (o1) => { if (c(o1)) return a(o1); return default(U); }; };
        }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, T2, Boolean>, Func<T1, T2, U>, Func<T1, T2, U>> L_If_F<T1, T2, U>()
        {
            return (c, a) => { return (o1, o2) => { if (c(o1, o2)) return a(o1, o2); return default(U); }; };
        }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, T2, T3, Boolean>, Func<T1, T2, T3, U>, Func<T1, T2, T3, U>> L_If_F<T1, T2, T3, U>()
        {
            return (c, a) => { return (o1, o2, o3) => { if (c(o1, o2, o3)) return a(o1, o2, o3); return default(U); }; };
        }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new String[] { "Condition", "Action" }, L.Comments.If)]
        public static Func<Func<T1, T2, T3, T4, Boolean>, Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_If_F<T1, T2, T3, T4, U>()
        {
            return (c, a) => { return (o1, o2, o3, o4) => { if (c(o1, o2, o3, o4))return a(o1, o2, o3, o4); return default(U); }; };
        }
        #endregion
        #region If Else
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new String[] { "Condition", "Action", "Else" }, L.Comments.IfElse)]
        public static Func<Func<Boolean>, Action, Action, Action> L_IfElse()
        {
            return (c, a, b) => { return () => { if (c()) a(); else b(); }; };
        }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new String[] { "Condition", "Action", "Else" }, L.Comments.IfElse)]
        public static Func<Func<T1, Boolean>, Action<T1>, Action<T1>, Action<T1>> L_IfElse<T1>()
        {
            return (c, a, b) => { return (o1) => { if (c(o1)) a(o1); else b(o1); }; };
        }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new String[] { "Condition", "Action", "Else" }, L.Comments.IfElse)]
        public static Func<Func<T1, T2, Boolean>, Action<T1, T2>, Action<T1, T2>, Action<T1, T2>> L_IfElse<T1, T2>()
        {
            return (c, a, b) => { return (o1, o2) => { if (c(o1, o2)) a(o1, o2); else b(o1, o2); }; };
        }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new String[] { "Condition", "Action", "Else" }, L.Comments.IfElse)]
        public static Func<Func<T1, T2, T3, Boolean>, Action<T1, T2, T3>, Action<T1, T2, T3>, Action<T1, T2, T3>> L_IfElse<T1, T2, T3>()
        {
            return (c, a, b) => { return (o1, o2, o3) => { if (c(o1, o2, o3)) a(o1, o2, o3); else b(o1, o2, o3); }; };
        }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new String[] { "Condition", "Action", "Else" }, L.Comments.IfElse)]
        public static Func<Func<T1, T2, T3, T4, Boolean>, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_IfElse<T1, T2, T3, T4>()
        {
            return (c, a, b) => { return (o1, o2, o3, o4) => { if (c(o1, o2, o3, o4)) a(o1, o2, o3, o4); else b(o1, o2, o3, o4); }; };
        }
        #endregion
        #endregion

        public partial class Comments
        {
            public const string If = "Logical If Statement. If the condition passed is true, the action passed is executed.";
            public const string If_Func = "Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.";
            public const string IfElse = "Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.";
        }
    }
    public static class BooleanExt
    {
        #region Not
        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static Func<Boolean> Not(this Func<Boolean> Condition)
        {
            return L.Not.Surround(Condition);
        }
        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static Func<T1, Boolean> Not<T1>(this Func<T1, Boolean> Condition)
        {
            return L.Not.Surround(Condition);
        }
        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static Func<T1, T2, Boolean> Not<T1, T2>(this Func<T1, T2, Boolean> Condition)
        {
            return L.Not.Surround(Condition);
        }
        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static Func<T1, T2, T3, Boolean> Not<T1, T2, T3>(this Func<T1, T2, T3, Boolean> Condition)
        {
            return L.Not.Surround(Condition);
        }
        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, Boolean> Not<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> Condition)
        {
            return L.Not.Surround(Condition);
        }
        #endregion
        // Refactor
        // Comment

        // Surrounds the method in a conditional method
        #region If
        #region If - Action
        public static Func<Boolean> If(this Action In, Func<Boolean> Condition)
        {
            return () => { if (Condition()) { In(); return true; } return false; };
        }
        public static Func<T, Boolean> If<T>(this Action In, Func<T, Boolean> Condition)
        {
            return (o) => { if (Condition(o)) { In(); return true; } return false; };
        }
        public static Func<T1, T2, Boolean> If<T1, T2>(this Action In, Func<T1, T2, Boolean> Condition)
        {
            return (o1, o2) => { if (Condition(o1, o2)) { In(); return true; } return false; };
        }
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action In, Func<T1, T2, T3, Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition(o1, o2, o3)) { In(); return true; } return false; };
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action In, Func<T1, T2, T3, T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o1, o2, o3, o4)) { In(); return true; } return false; };
        }
        #endregion
        #region If - Action_T
        public static Func<T, Boolean> If<T>(this Action<T> In, Func<Boolean> Condition)
        {
            return (o) => { if (Condition()) { In(o); return true; } return false; };
        }
        public static Func<T1, Boolean> If<T1>(this Action<T1> In, Func<T1, Boolean> Condition)
        {
            return (o1) => { if (Condition(o1)) { In(o1); return true; } return false; };
        }
        public static Func<T1, T2, Boolean> If<T1, T2>(this Action<T1> In, Func<T2, Boolean> Condition)
        {
            return (o1, o2) => { if (Condition(o2)) { In(o1); return true; } return false; };
        }
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action<T1> In, Func<T2, T3, Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition(o2, o3)) { In(o1); return true; } return false; };
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1> In, Func<T2, T3, T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o2, o3, o4)) { In(o1); return true; } return false; };
        }
        #endregion
        #region If - Action_T_T
        public static Func<T1, T2, Boolean> If<T1, T2>(this Action<T1, T2> In, Func<Boolean> Condition)
        {
            return (o1, o2) => { if (Condition()) { In(o1, o2); return true; } return false; };
        }
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action<T1, T2> In, Func<T3, Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition(o3)) { In(o1, o2); return true; } return false; };
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1, T2> In, Func<T3, T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o3, o4)) { In(o1, o2); return true; } return false; };
        }
        #endregion
        #region If - Action_T_T_T
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action<T1, T2, T3> In, Func<Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition()) { In(o1, o2, o3); return true; } return false; };
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1, T2, T3> In, Func<T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o4)) { In(o1, o2, o3); return true; } return false; };
        }
        #endregion
        #region If - Action_T_T_T_T
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition()) { In(o1, o2, o3, o4); return true; } return false; };
        }
        #endregion
        #region If - Func_T
        public static Func<T> If<T>(this Func<T> In, Func<Boolean> Condition)
        {
            return () => { if (Condition()) return In(); return default(T); };
        }
        public static Func<T2, T1> If<T1, T2>(this Func<T1> In, Func<T2, Boolean> Condition)
        {
            return (o) => { if (Condition(o)) return In(); return default(T1); };
        }
        public static Func<T2, T3, T1> If<T1, T2, T3>(this Func<T1> In, Func<T2, T3, Boolean> Condition)
        {
            return (o1, o2) => { if (Condition(o1, o2)) return In(); return default(T1); };
        }
        public static Func<T2, T3, T4, T1> If<T1, T2, T3, T4>(this Func<T1> In, Func<T2, T3, T4, Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition(o1, o2, o3)) return In(); return default(T1); };
        }
        public static Func<T2, T3, T4, T5, T1> If<T1, T2, T3, T4, T5>(this Func<T1> In, Func<T2, T3, T4, T5, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o1, o2, o3, o4)) return In(); return default(T1); };
        }
        #endregion
        #region If - Func_T_T
        public static Func<T1, U> If<T1, U>(this Func<T1, U> In, Func<Boolean> Condition)
        {
            return (o) => { if (Condition()) return In(o); return default(U); };
        }
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, U> In, Func<T2, Boolean> Condition)
        {
            return (o1, o2) => { if (Condition(o2)) return In(o1); return default(U); };
        }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, U> In, Func<T2, T3, Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition(o2, o3)) return In(o1); return default(U); };
        }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, U> In, Func<T2, T3, T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o2, o3, o4)) return In(o1); return default(U); };
        }
        #endregion
        #region If - Func_T_T_T
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, T2, U> In, Func<Boolean> Condition)
        {
            return (o1, o2) => { if (Condition()) return In(o1, o2); return default(U); };
        }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, U> In, Func<T3, Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition(o3)) return In(o1, o2); return default(U); };
        }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, Func<T3, T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o3, o4)) return In(o1, o2); return default(U); };
        }
        #endregion
        #region If - Func_T_T_T_T
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<Boolean> Condition)
        {
            return (o1, o2, o3) => { if (Condition()) return In(o1, o2, o3); return default(U); };
        }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Func<T4, Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition(o4)) return In(o1, o2, o3); return default(U); };
        }
        #endregion
        #region If - Func_T_T_T_T_T
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<Boolean> Condition)
        {
            return (o1, o2, o3, o4) => { if (Condition()) return In(o1, o2, o3, o4); return default(U); };
        }
        #endregion
        #endregion
        // Chains a conditional method with an If Else
        #region ElseIf
        public static Func<Boolean> ElseIf(this Func<Boolean> In, Func<Boolean> Condition, Action Act)
        {
            return () =>
            {
                if (In()) { return true; }
                else if (Condition()) { Act(); return true; }
                return false;
            };
        }
        public static Func<T, Boolean> ElseIf<T>(this Func<T, Boolean> In, Func<T, Boolean> Condition, Action<T> Act)
        {
            return (o) =>
            {
                if (In(o)) { return true; }
                else if (Condition(o)) { Act(o); return true; }
                return false;
            };
        }
        public static Func<T1, T2, Boolean> ElseIf<T1, T2>(this Func<T1, T2, Boolean> In, Func<T1, T2, Boolean> Condition, Action<T1, T2> Act)
        {
            return (o1, o2) =>
            {
                if (In(o1, o2)) { return true; }
                else if (Condition(o1, o2)) { Act(o1, o2); return true; }
                return false;
            };
        }
        public static Func<T1, T2, T3, Boolean> ElseIf<T1, T2, T3>(this Func<T1, T2, T3, Boolean> In, Func<T1, T2, T3, Boolean> Condition, Action<T1, T2, T3> Act)
        {
            return (o1, o2, o3) =>
            {
                if (In(o1, o2, o3)) { return true; }
                else if (Condition(o1, o2, o3)) { Act(o1, o2, o3); return true; }
                return false;
            };
        }
        public static Func<T1, T2, T3, T4, Boolean> ElseIf<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> In, Func<T1, T2, T3, T4, Boolean> Condition, Action<T1, T2, T3, T4> Act)
        {
            return (o1, o2, o3, o4) =>
            {
                if (In(o1, o2, o3, o4)) { return true; }
                else if (Condition(o1, o2, o3, o4)) { Act(o1, o2, o3, o4); return true; }
                return false;
            };
        }
        public static Func<U> ElseIf<U>(this Func<U> In, Func<Boolean> Condition, Func<U> Act)
        {
            return () =>
            {
                U Out = In();
                if (Out != null) { return Out; }
                else if (Condition()) { return Act(); }
                return default(U);
            };
        }
        public static Func<T, U> ElseIf<T, U>(this Func<T, U> In, Func<T, Boolean> Condition, Func<T, U> Act)
        {
            return (o) =>
            {
                U Out = In(o);
                if (Out != null) { return Out; }
                else if (Condition(o)) { return Act(o); }
                return default(U);
            };
        }
        public static Func<T1, T2, U> ElseIf<T1, T2, U>(this Func<T1, T2, U> In, Func<T1, T2, Boolean> Condition, Func<T1, T2, U> Act)
        {
            return (o1, o2) =>
            {
                U Out = In(o1, o2);
                if (Out != null) { return Out; }
                else if (Condition(o1, o2)) { return Act(o1, o2); }
                return default(U);
            };
        }
        public static Func<T1, T2, T3, U> ElseIf<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1, T2, T3, Boolean> Condition, Func<T1, T2, T3, U> Act)
        {
            return (o1, o2, o3) =>
            {
                U Out = In(o1, o2, o3);
                if (Out != null) { return Out; }
                else if (Condition(o1, o2, o3)) { return Act(o1, o2, o3); }
                return default(U);
            };
        }
        public static Func<T1, T2, T3, T4, U> ElseIf<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1, T2, T3, T4, Boolean> Condition, Func<T1, T2, T3, T4, U> Act)
        {
            return (o1, o2, o3, o4) =>
            {
                U Out = In(o1, o2, o3, o4);
                if (Out != null) { return Out; }
                else if (Condition(o1, o2, o3, o4)) { return Act(o1, o2, o3, o4); }
                return default(U);
            };
        }
        #endregion
        // Chains a conditional method with an Else
        #region Else
        public static Action Else(this Func<Boolean> In, Action Act)
        {
            return In.ElseIf(L.True, Act).Do();
        }
        public static Action<T1> Else<T1>(this Func<T1, Boolean> In, Action Act)
        {
            return In.Else(Act.Arg<T1>());
        }
        public static Action<T1> Else<T1>(this Func<T1, Boolean> In, Action<T1> Act)
        {
            return In.ElseIf(L.True.Arg<T1, Boolean>(), Act).Do();
        }
        public static Action<T1, T2> Else<T1, T2>(this Func<T1, T2, Boolean> In, Action Act)
        {
            return In.Else(Act.Arg<T1, T2>());
        }
        public static Action<T1, T2> Else<T1, T2>(this Func<T1, T2, Boolean> In, Action<T1, T2> Act)
        {
            return In.ElseIf(L.True.Arg<T1, T2, Boolean>(), Act).Do();
        }
        public static Action<T1, T2, T3> Else<T1, T2, T3>(this Func<T1, T2, T3, Boolean> In, Action Act)
        {
            return In.Else(Act.Arg<T1, T2, T3>());
        }
        public static Action<T1, T2, T3> Else<T1, T2, T3>(this Func<T1, T2, T3, Boolean> In, Action<T1, T2, T3> Act)
        {
            return In.ElseIf(L.True.Arg<T1, T2, T3, Boolean>(), Act).Do();
        }
        public static Action<T1, T2, T3, T4> Else<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> In, Action Act)
        {
            return In.Else(Act.Arg<T1, T2, T3, T4>());
        }
        public static Action<T1, T2, T3, T4> Else<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> In, Action<T1, T2, T3, T4> Act)
        {
            return In.ElseIf(L.True.Arg<T1, T2, T3, T4, Boolean>(), Act).Do();
        }
        public static Func<U> Else<U>(this Func<U> In, U Result)
        {
            return In.Else(Result.Func<U>());
        }
        public static Func<U> Else<U>(this Func<U> In, Action Act)
        {
            return In.Else(Act.Return<U>());
        }
        public static Func<U> Else<U>(this Func<U> In, Func<U> Act)
        {
            return In.ElseIf(L.True, Act);
        }
        public static Func<T1, U> Else<T1, U>(this Func<T1, U> In, U Result)
        {
            return In.Else(Result.Func<U>().Arg<T1, U>());
        }
        public static Func<T1, U> Else<T1, U>(this Func<T1, U> In, Action Act)
        {
            return In.Else(Act.Arg<T1>().Return<T1, U>());
        }
        public static Func<T1, U> Else<T1, U>(this Func<T1, U> In, Func<T1, U> Act)
        {
            return In.ElseIf(L.True.Arg<T1, Boolean>(), Act);
        }
        public static Func<T1, T2, U> Else<T1, T2, U>(this Func<T1, T2, U> In, U Result)
        {
            return In.Else(Result.Func<U>().Arg<T1, T2, U>());
        }
        public static Func<T1, T2, U> Else<T1, T2, U>(this Func<T1, T2, U> In, Action Act)
        {
            return In.Else(Act.Arg<T1, T2>().Return<T1, T2, U>());
        }
        public static Func<T1, T2, U> Else<T1, T2, U>(this Func<T1, T2, U> In, Func<T1, T2, U> Act)
        {
            return In.ElseIf(L.True.Arg<T1, T2, Boolean>(), Act);
        }
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, U Result)
        {
            return In.Else(Result.Func<U>().Arg<T1, T2, T3, U>());
        }
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Action Act)
        {
            return In.Else(Act.Arg<T1, T2, T3>().Return<T1, T2, T3, U>());
        }
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1, T2, T3, U> Act)
        {
            return In.ElseIf(L.True.Arg<T1, T2, T3, Boolean>(), Act);
        }
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, U Result)
        {
            return In.Else(Result.Func<U>().Arg<T1, T2, T3, T4, U>());
        }
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Action Act)
        {
            return In.Else(Act.Arg<T1, T2, T3, T4>().Return<T1, T2, T3, T4, U>());
        }
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1, T2, T3, T4, U> Act)
        {
            return In.ElseIf(L.True.Arg<T1, T2, T3, T4, Boolean>(), Act);
        }
        #endregion
        // Chains a conditional method with a Case statement. The case uses the first parameter as its value.
        #region Case
        // Broken - disabled.


        public static Func<T, Boolean> Case<T>(this Func<T, Boolean> In, T Obj, Action<T> Act)
        {
            return In.ElseIf(Obj.If(), Act);
        }
        public static Func<T1, T2, Boolean> Case<T1, T2>(this Func<T1, T2, Boolean> In, T1 Obj, Action<T1, T2> Act)
        {
            return In.ElseIf(Obj.If().Arg<T1, T2, Boolean>(), Act);
        }
        public static Func<T1, T2, T3, Boolean> Case<T1, T2, T3>(this Func<T1, T2, T3, Boolean> In, T1 Obj, Action<T1, T2, T3> Act)
        {
            return In.ElseIf(Obj.If().Arg<T1, T2, T3, Boolean>(), Act);
        }
        public static Func<T1, T2, T3, T4, Boolean> Case<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> In, T1 Obj, Action<T1, T2, T3, T4> Act)
        {
            return In.ElseIf(Obj.If().Arg<T1, T2, T3, T4, Boolean>(), Act);
        }
        public static Func<T, U> Case<T, U>(this Func<T, U> In, T Obj, U Result)
        {
            return In.Case<T, U>(Obj, Result.Func<U>().Arg<T, U>());
        }
        public static Func<T, U> Case<T, U>(this Func<T, U> In, T Obj, Func<T, U> Act)
        {
            return In.ElseIf(Obj.If(), Act);
        }
        public static Func<T1, T2, U> Case<T1, T2, U>(this Func<T1, T2, U> In, T1 Obj, Func<T1, T2, U> Act)
        {
            return In.ElseIf(Obj.If().Arg<T1, T2, Boolean>(), Act);
        }
        public static Func<T1, T2, T3, U> Case<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T1 Obj, Func<T1, T2, T3, U> Act)
        {
            return In.ElseIf(Obj.If().Arg<T1, T2, T3, Boolean>(), Act);
        }
        public static Func<T1, T2, T3, T4, U> Case<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T1 Obj, Func<T1, T2, T3, T4, U> Act)
        {
            return In.ElseIf(Obj.If().Arg<T1, T2, T3, T4, Boolean>(), Act);
        }
        #endregion
        // Surrounds the method with multiple condition methods - ANDing them together
        #region If - Multiple
        #region If - Multiple - Action
        public static Func<Boolean> If(this Action In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T, Boolean> If<T>(this Action In, params Func<T, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, Boolean> If<T1, T2>(this Action In, params Func<T1, T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action In, params Func<T1, T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action In, params Func<T1, T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Action_T
        public static Func<T, Boolean> If<T>(this Action<T> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, Boolean> If<T1, T2>(this Action<T1> In, params Func<T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action<T1> In, params Func<T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1> In, params Func<T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Action_T_T
        public static Func<T1, T2, Boolean> If<T1, T2>(this Action<T1, T2> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action<T1, T2> In, params Func<T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1, T2> In, params Func<T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Action_T_T_T
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Action<T1, T2, T3> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1, T2, T3> In, params Func<T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Action_T_T_T_T
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Func_T
        public static Func<T> If<T>(this Func<T> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T2, T1> If<T1, T2>(this Func<T1> In, params Func<T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T2, T3, T1> If<T1, T2, T3>(this Func<T1> In, params Func<T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T2, T3, T4, T1> If<T1, T2, T3, T4>(this Func<T1> In, params Func<T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T2, T3, T4, T5, T1> If<T1, T2, T3, T4, T5>(this Func<T1> In, params Func<T2, T3, T4, T5, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Func_T_T
        public static Func<T1, U> If<T1, U>(this Func<T1, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, U> In, params Func<T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, U> In, params Func<T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, U> In, params Func<T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Func_T_T_T
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, T2, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, U> In, params Func<T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, params Func<T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Func_T_T_T_T
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, params Func<T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #region If - Multiple - Func_T_T_T_T_T
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And());
        }
        #endregion
        #endregion
        // Surrounds the method in an inverted conditional method
        #region Unless
        public static Func<Boolean> Unless(this Action In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T, Boolean> Unless<T>(this Action<T> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2, Boolean> Unless<T1, T2>(this Action<T1, T2> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2, T3, Boolean> Unless<T1, T2, T3>(this Action<T1, T2, T3> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2, T3, T4, Boolean> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T> Unless<T>(this Func<T> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2> Unless<T1, T2>(this Func<T1, T2> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2, T3> Unless<T1, T2, T3>(this Func<T1, T2, T3> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2, T3, T4> Unless<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        public static Func<T1, T2, T3, T4, T5> Unless<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> In, Func<Boolean> Condition)
        {
            return In.If(Condition.Not());
        }
        #endregion
        // Surrounds the method with multiple inverted condition methods - ORing them together (and*not=nor)
        #region Unless- Multiple
        #region Unless - Multiple - Action
        public static Func<Boolean> Unless(this Action In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T, Boolean> Unless<T>(this Action In, params Func<T, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, Boolean> Unless<T1, T2>(this Action In, params Func<T1, T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, Boolean> Unless<T1, T2, T3>(this Action In, params Func<T1, T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, Boolean> Unless<T1, T2, T3, T4>(this Action In, params Func<T1, T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Action_T
        public static Func<T, Boolean> Unless<T>(this Action<T> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, Boolean> Unless<T1, T2>(this Action<T1> In, params Func<T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, Boolean> Unless<T1, T2, T3>(this Action<T1> In, params Func<T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, Boolean> Unless<T1, T2, T3, T4>(this Action<T1> In, params Func<T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Action_T_T
        public static Func<T1, T2, Boolean> Unless<T1, T2>(this Action<T1, T2> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, Boolean> Unless<T1, T2, T3>(this Action<T1, T2> In, params Func<T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, Boolean> Unless<T1, T2, T3, T4>(this Action<T1, T2> In, params Func<T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Action_T_T_T
        public static Func<T1, T2, T3, Boolean> Unless<T1, T2, T3>(this Action<T1, T2, T3> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, Boolean> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3> In, params Func<T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Action_T_T_T_T
        public static Func<T1, T2, T3, T4, Boolean> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Func_T
        public static Func<T> Unless<T>(this Func<T> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T2, T1> Unless<T1, T2>(this Func<T1> In, params Func<T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T2, T3, T1> Unless<T1, T2, T3>(this Func<T1> In, params Func<T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T2, T3, T4, T1> Unless<T1, T2, T3, T4>(this Func<T1> In, params Func<T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T2, T3, T4, T5, T1> Unless<T1, T2, T3, T4, T5>(this Func<T1> In, params Func<T2, T3, T4, T5, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Func_T_T
        public static Func<T1, U> Unless<T1, U>(this Func<T1, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, U> Unless<T1, T2, U>(this Func<T1, U> In, params Func<T2, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, U> In, params Func<T2, T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, U> In, params Func<T2, T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Func_T_T_T
        public static Func<T1, T2, U> Unless<T1, T2, U>(this Func<T1, T2, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, T2, U> In, params Func<T3, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, params Func<T3, T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Func_T_T_T_T
        public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, params Func<T4, Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #region Unless - Multiple - Func_T_T_T_T_T
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<Boolean>[] Conditions)
        {
            return In.If(Conditions.And().Not());
        }
        #endregion
        #endregion
        // And takes a list of conditions and combines them using AND logic
        #region And
        public static Func<Boolean> And(this IEnumerable<Func<Boolean>> Conditions)
        {
            return () =>
            {
                Boolean Out = true;
                Conditions.While((o) => { Out = o(); return Out; });
                return Out;
            };
        }
        public static Func<T1, Boolean> And<T1>(this IEnumerable<Func<T1, Boolean>> Conditions)
        {
            return (o1) =>
            {
                Boolean Out = true;
                Conditions.While((o2) => { Out = o2(o1); return Out; });
                return Out;
            };
        }
        public static Func<T1, T2, Boolean> And<T1, T2>(this IEnumerable<Func<T1, T2, Boolean>> Conditions)
        {
            return (o1, o2) =>
            {
                Boolean Out = true;
                Conditions.While((o3) => { Out = o3(o1, o2); return Out; });
                return Out;
            };
        }
        public static Func<T1, T2, T3, Boolean> And<T1, T2, T3>(this IEnumerable<Func<T1, T2, T3, Boolean>> Conditions)
        {
            return (o1, o2, o3) =>
            {
                Boolean Out = true;
                Conditions.While((o4) => { Out = o4(o1, o2, o3); return Out; });
                return Out;
            };
        }
        public static Func<T1, T2, T3, T4, Boolean> And<T1, T2, T3, T4>(this IEnumerable<Func<T1, T2, T3, T4, Boolean>> Conditions)
        {
            return (o1, o2, o3, o4) =>
            {
                Boolean Out = true;
                Conditions.While((o5) => { Out = o5(o1, o2, o3, o4); return Out; });
                return Out;
            };
        }
        #endregion
        // Or takes a list of conditions and combines them using OR logic
        #region Or
        public static Func<Boolean> Or(this IEnumerable<Func<Boolean>> Conditions)
        {
            return () =>
            {
                Boolean Out = false;
                Conditions.While((o) => { Out = o(); return !Out; });
                return Out;
            };
        }
        public static Func<T1, Boolean> Or<T1>(this IEnumerable<Func<T1, Boolean>> Conditions)
        {
            return (o1) =>
            {
                Boolean Out = false;
                Conditions.While((o2) => { Out = o2(o1); return !Out; });
                return Out;
            };
        }
        public static Func<T1, T2, Boolean> Or<T1, T2>(this IEnumerable<Func<T1, T2, Boolean>> Conditions)
        {
            return (o1, o2) =>
            {
                Boolean Out = false;
                Conditions.While((o3) => { Out = o3(o1, o2); return !Out; });
                return Out;
            };
        }
        public static Func<T1, T2, T3, Boolean> Or<T1, T2, T3>(this IEnumerable<Func<T1, T2, T3, Boolean>> Conditions)
        {
            return (o1, o2, o3) =>
            {
                Boolean Out = false;
                Conditions.While((o4) => { Out = o4(o1, o2, o3); return !Out; });
                return Out;
            };
        }
        public static Func<T1, T2, T3, T4, Boolean> Or<T1, T2, T3, T4>(this IEnumerable<Func<T1, T2, T3, T4, Boolean>> Conditions)
        {
            return (o1, o2, o3, o4) =>
            {
                Boolean Out = false;
                Conditions.While((o5) => { Out = o5(o1, o2, o3, o4); return !Out; });
                return Out;
            };
        }
        #endregion
    }
}