﻿using System;
using System.Collections.Generic;
using LCore.Dynamic;
using LCore.Extensions.ObjectExt;
// ReSharper disable ClassNeverInstantiated.Global

namespace LCore.Extensions
    {
    public partial class L
        {
        #region Boolean Lambdas - Shorthand
        /// <summary>
        /// Returns a function that returns true
        /// </summary>
        public static readonly Func<bool> True = () => true;
        /// <summary>
        /// Returns a function that returns false
        /// </summary>
        public static readonly Func<bool> False = () => false;
        /// <summary>
        /// Returns a function that inverts the boolean it is sent.
        /// </summary>
        public static readonly Func<bool, bool> Not = o => !o;
        /// <summary>
        /// Returns a function that ANDs the booleans that are sent
        /// </summary>
        public static readonly Func<bool, bool, bool> And = (b1, b2) => b1 && b2;
        /// <summary>
        /// Returns a function that ORs the booleans that are sent
        /// </summary>
        public static readonly Func<bool, bool, bool> Or = (b1, b2) => b1 || b2;
        /// <summary>
        /// Returns a function that XORs the booleans that are sent
        /// </summary>
        public static readonly Func<bool, bool, bool> Xor = (b1, b2) => b1 ^ b2;
        #endregion

        #region Base Lambdas
        #region Boolean
        public static Func<string> Boolean_GetTrueString = () => bool.TrueString;
        public static Func<string> Boolean_GetFalseString = () => bool.FalseString;
        public static Func<bool, int> Boolean_GetHashCode = b => b.GetHashCode();
        public static Func<bool, string> Boolean_ToString = b => b.ToString();
        public static Func<bool, IFormatProvider, string> Boolean_ToString2 = (b, provider) => b.ToString(provider);
        public static Func<bool, object, bool> Boolean_Equals = (b, obj) => b.Equals(obj);
        public static Func<bool, bool, bool> Boolean_Equals2 = (b, obj) => b.Equals(obj);
        public static Func<bool, object, int> Boolean_CompareTo = (b, obj) => b.CompareTo(obj);
        public static Func<bool, bool, int> Boolean_CompareTo2 = (b, value) => b.CompareTo(value);
        public static Func<string, bool> Boolean_Parse = value => bool.Parse(value);
        public static Func<bool, TypeCode> Boolean_GetTypeCode = b => b.GetTypeCode();
        /* No Ref or Out Types 
        public static Func<String, Boolean&, Boolean> Boolean_TryParse = (value, result) => { return Boolean.TryParse(value, result); };
        */
        #endregion
        #endregion
        }
    public partial class Logic
        {
        #region Boolean Conditions
        /// <summary>
        /// Returns a function that returns true
        /// </summary>
        public static readonly Func<bool> Boolean_True = () => true;
        /// <summary>
        /// Returns a function that returns false
        /// </summary>
        public static readonly Func<bool> Boolean_False = () => false;
        /// <summary>
        /// Returns a function that inverts the boolean it is sent.
        /// </summary>
        public static readonly Func<bool, bool> Boolean_Not = o => !o;
        /// <summary>
        /// Returns a function that ANDs the booleans that are sent
        /// </summary>
        public static readonly Func<bool, bool, bool> Boolean_And = (b1, b2) => b1 && b2;
        /// <summary>
        /// Returns a function that ORs the booleans that are sent
        /// </summary>
        public static readonly Func<bool, bool, bool> Boolean_Or = (b1, b2) => b1 || b2;
        /// <summary>
        /// Returns a function that XORs the booleans that are sent
        /// </summary>
        public static Func<bool, bool, bool> Boolean_Xor = (b1, b2) => b1 ^ b2;
        #endregion

        // Explode
        #region Logic Lambdas
        #region If
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<bool>, Action, Func<bool>> L_If_A()
            {
            return (c, a) => { return () => { if (c()) { a(); return true; } return false; }; };
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, bool>, Action<T1>, Func<T1, bool>> L_If_A<T1>()
            {
            return (c, a) => { return o => { if (c(o)) { a(o); return true; } return false; }; };
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, T2, bool>, Action<T1, T2>, Func<T1, T2, bool>> L_If_A<T1, T2>()
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
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, T2, T3, bool>, Action<T1, T2, T3>, Func<T1, T2, T3, bool>> L_If_A<T1, T2, T3>()
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
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, bool>> L_If_A<T1, T2, T3, T4>()
            {
            return (c, a) => { return (o1, o2, o3, o4) => { if (c(o1, o2, o3, o4)) { a(o1, o2, o3, o4); return true; } return false; }; };
            }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<bool>, Func<U>, Func<U>> L_If_F<U>()
            {
            return (c, a) => { return () => c() ? a() : default(U); };
            }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, bool>, Func<T1, U>, Func<T1, U>> L_If_F<T1, U>()
            {
            return (c, a) => { return o1 => c(o1) ? a(o1) : default(U); };
            }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, T2, bool>, Func<T1, T2, U>, Func<T1, T2, U>> L_If_F<T1, T2, U>()
            {
            return (c, a) => { return (o1, o2) => c(o1, o2) ? a(o1, o2) : default(U); };
            }
        /// <summary>
        /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, T2, T3, bool>, Func<T1, T2, T3, U>, Func<T1, T2, T3, U>> L_If_F<T1, T2, T3, U>()
            {
            return (c, a) => { return (o1, o2, o3) => c(o1, o2, o3) ? a(o1, o2, o3) : default(U); };
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
        [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
        public static Func<Func<T1, T2, T3, T4, bool>, Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_If_F<T1, T2, T3, T4, U>()
            {
            return (c, a) => { return (o1, o2, o3, o4) => c(o1, o2, o3, o4) ? a(o1, o2, o3, o4) : default(U); };
            }
        #endregion
        #region If Else
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
        public static Func<Func<bool>, Action, Action, Action> L_IfElse()
            {
            return (c, a, b) => { return () => { if (c()) a(); else b(); }; };
            }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
        public static Func<Func<T1, bool>, Action<T1>, Action<T1>, Action<T1>> L_IfElse<T1>()
            {
            return (c, a, b) => { return o1 => { if (c(o1)) a(o1); else b(o1); }; };
            }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
        public static Func<Func<T1, T2, bool>, Action<T1, T2>, Action<T1, T2>, Action<T1, T2>> L_IfElse<T1, T2>()
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
        [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
        public static Func<Func<T1, T2, T3, bool>, Action<T1, T2, T3>, Action<T1, T2, T3>, Action<T1, T2, T3>> L_IfElse<T1, T2, T3>()
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
        [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
        public static Func<Func<T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_IfElse<T1, T2, T3, T4>()
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
        public static Func<bool> Not(this Func<bool> Condition)
            {
            return L.Not.Surround(Condition);
            }
        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static Func<T1, bool> Not<T1>(this Func<T1, bool> Condition)
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
        public static Func<T1, T2, bool> Not<T1, T2>(this Func<T1, T2, bool> Condition)
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
        public static Func<T1, T2, T3, bool> Not<T1, T2, T3>(this Func<T1, T2, T3, bool> Condition)
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
        public static Func<T1, T2, T3, T4, bool> Not<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> Condition)
            {
            return L.Not.Surround(Condition);
            }
        #endregion
        // Refactor
        // Comment

        // Surrounds the method in a conditional method
        #region If
        #region If - Action
        public static Func<bool> If(this Action In, Func<bool> Condition)
            {
            return () => { if (Condition()) { In(); return true; } return false; };
            }
        public static Func<T, bool> If<T>(this Action In, Func<T, bool> Condition)
            {
            return o => { if (Condition(o)) { In(); return true; } return false; };
            }
        public static Func<T1, T2, bool> If<T1, T2>(this Action In, Func<T1, T2, bool> Condition)
            {
            return (o1, o2) => { if (Condition(o1, o2)) { In(); return true; } return false; };
            }
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action In, Func<T1, T2, T3, bool> Condition)
            {
            return (o1, o2, o3) => { if (Condition(o1, o2, o3)) { In(); return true; } return false; };
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action In, Func<T1, T2, T3, T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => { if (Condition(o1, o2, o3, o4)) { In(); return true; } return false; };
            }
        #endregion
        #region If - Action_T
        public static Func<T, bool> If<T>(this Action<T> In, Func<bool> Condition)
            {
            return o => { if (Condition()) { In(o); return true; } return false; };
            }
        public static Func<T1, bool> If<T1>(this Action<T1> In, Func<T1, bool> Condition)
            {
            return o1 => { if (Condition(o1)) { In(o1); return true; } return false; };
            }
        public static Func<T1, T2, bool> If<T1, T2>(this Action<T1> In, Func<T2, bool> Condition)
            {
            return (o1, o2) => { if (Condition(o2)) { In(o1); return true; } return false; };
            }
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1> In, Func<T2, T3, bool> Condition)
            {
            return (o1, o2, o3) => { if (Condition(o2, o3)) { In(o1); return true; } return false; };
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1> In, Func<T2, T3, T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => { if (Condition(o2, o3, o4)) { In(o1); return true; } return false; };
            }
        #endregion
        #region If - Action_T_T
        public static Func<T1, T2, bool> If<T1, T2>(this Action<T1, T2> In, Func<bool> Condition)
            {
            return (o1, o2) => { if (Condition()) { In(o1, o2); return true; } return false; };
            }
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1, T2> In, Func<T3, bool> Condition)
            {
            return (o1, o2, o3) => { if (Condition(o3)) { In(o1, o2); return true; } return false; };
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2> In, Func<T3, T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => { if (Condition(o3, o4)) { In(o1, o2); return true; } return false; };
            }
        #endregion
        #region If - Action_T_T_T
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1, T2, T3> In, Func<bool> Condition)
            {
            return (o1, o2, o3) => { if (Condition()) { In(o1, o2, o3); return true; } return false; };
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2, T3> In, Func<T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => { if (Condition(o4)) { In(o1, o2, o3); return true; } return false; };
            }
        #endregion
        #region If - Action_T_T_T_T
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<bool> Condition)
            {
            return (o1, o2, o3, o4) => { if (Condition()) { In(o1, o2, o3, o4); return true; } return false; };
            }
        #endregion
        #region If - Func_T
        public static Func<T> If<T>(this Func<T> In, Func<bool> Condition)
            {
            return () => Condition() ? In() : default(T);
            }
        public static Func<T2, T1> If<T1, T2>(this Func<T1> In, Func<T2, bool> Condition)
            {
            return o => Condition(o) ? In() : default(T1);
            }
        public static Func<T2, T3, T1> If<T1, T2, T3>(this Func<T1> In, Func<T2, T3, bool> Condition)
            {
            return (o1, o2) => Condition(o1, o2) ? In() : default(T1);
            }
        public static Func<T2, T3, T4, T1> If<T1, T2, T3, T4>(this Func<T1> In, Func<T2, T3, T4, bool> Condition)
            {
            return (o1, o2, o3) => Condition(o1, o2, o3) ? In() : default(T1);
            }
        public static Func<T2, T3, T4, T5, T1> If<T1, T2, T3, T4, T5>(this Func<T1> In, Func<T2, T3, T4, T5, bool> Condition)
            {
            return (o1, o2, o3, o4) => Condition(o1, o2, o3, o4) ? In() : default(T1);
            }
        #endregion
        #region If - Func_T_T
        public static Func<T1, U> If<T1, U>(this Func<T1, U> In, Func<bool> Condition)
            {
            return o => Condition() ? In(o) : default(U);
            }
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, U> In, Func<T2, bool> Condition)
            {
            return (o1, o2) => Condition(o2) ? In(o1) : default(U);
            }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, U> In, Func<T2, T3, bool> Condition)
            {
            return (o1, o2, o3) => Condition(o2, o3) ? In(o1) : default(U);
            }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, U> In, Func<T2, T3, T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => Condition(o2, o3, o4) ? In(o1) : default(U);
            }
        #endregion
        #region If - Func_T_T_T
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, T2, U> In, Func<bool> Condition)
            {
            return (o1, o2) => Condition() ? In(o1, o2) : default(U);
            }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, U> In, Func<T3, bool> Condition)
            {
            return (o1, o2, o3) => Condition(o3) ? In(o1, o2) : default(U);
            }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, Func<T3, T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => Condition(o3, o4) ? In(o1, o2) : default(U);
            }
        #endregion
        #region If - Func_T_T_T_T
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<bool> Condition)
            {
            return (o1, o2, o3) => Condition() ? In(o1, o2, o3) : default(U);
            }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Func<T4, bool> Condition)
            {
            return (o1, o2, o3, o4) => Condition(o4) ? In(o1, o2, o3) : default(U);
            }
        #endregion
        #region If - Func_T_T_T_T_T
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<bool> Condition)
            {
            return (o1, o2, o3, o4) => Condition() ? In(o1, o2, o3, o4) : default(U);
            }
        #endregion
        #endregion
        // Chains a conditional method with an If Else
        #region ElseIf
        public static Func<bool> ElseIf(this Func<bool> In, Func<bool> Condition, Action Act)
            {
            return () =>
            {
                if (In()) { return true; }
                if (Condition()) { Act(); return true; }
                return false;
            };
            }
        public static Func<T, bool> ElseIf<T>(this Func<T, bool> In, Func<T, bool> Condition, Action<T> Act)
            {
            return o =>
            {
                if (In(o)) { return true; }
                if (Condition(o)) { Act(o); return true; }
                return false;
            };
            }
        public static Func<T1, T2, bool> ElseIf<T1, T2>(this Func<T1, T2, bool> In, Func<T1, T2, bool> Condition, Action<T1, T2> Act)
            {
            return (o1, o2) =>
            {
                if (In(o1, o2)) { return true; }
                if (Condition(o1, o2)) { Act(o1, o2); return true; }
                return false;
            };
            }
        public static Func<T1, T2, T3, bool> ElseIf<T1, T2, T3>(this Func<T1, T2, T3, bool> In, Func<T1, T2, T3, bool> Condition, Action<T1, T2, T3> Act)
            {
            return (o1, o2, o3) =>
            {
                if (In(o1, o2, o3)) { return true; }
                if (Condition(o1, o2, o3)) { Act(o1, o2, o3); return true; }
                return false;
            };
            }
        public static Func<T1, T2, T3, T4, bool> ElseIf<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> In, Func<T1, T2, T3, T4, bool> Condition, Action<T1, T2, T3, T4> Act)
            {
            return (o1, o2, o3, o4) =>
            {
                if (In(o1, o2, o3, o4)) { return true; }
                if (Condition(o1, o2, o3, o4)) { Act(o1, o2, o3, o4); return true; }
                return false;
            };
            }
        public static Func<U> ElseIf<U>(this Func<U> In, Func<bool> Condition, Func<U> Act)
            {
            return () =>
            {
                U Out = In();
                if (Out != null) { return Out; }
                return Condition() ? Act() : default(U);
            };
            }
        public static Func<T, U> ElseIf<T, U>(this Func<T, U> In, Func<T, bool> Condition, Func<T, U> Act)
            {
            return o =>
            {
                U Out = In(o);
                if (Out != null) { return Out; }
                return Condition(o) ? Act(o) : default(U);
            };
            }
        public static Func<T1, T2, U> ElseIf<T1, T2, U>(this Func<T1, T2, U> In, Func<T1, T2, bool> Condition, Func<T1, T2, U> Act)
            {
            return (o1, o2) =>
            {
                U Out = In(o1, o2);
                if (Out != null) { return Out; }
                return Condition(o1, o2) ? Act(o1, o2) : default(U);
            };
            }
        public static Func<T1, T2, T3, U> ElseIf<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1, T2, T3, bool> Condition, Func<T1, T2, T3, U> Act)
            {
            return (o1, o2, o3) =>
            {
                U Out = In(o1, o2, o3);
                if (Out != null) { return Out; }
                return Condition(o1, o2, o3) ? Act(o1, o2, o3) : default(U);
            };
            }
        public static Func<T1, T2, T3, T4, U> ElseIf<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1, T2, T3, T4, bool> Condition, Func<T1, T2, T3, T4, U> Act)
            {
            return (o1, o2, o3, o4) =>
            {
                U Out = In(o1, o2, o3, o4);
                if (Out != null) { return Out; }
                return Condition(o1, o2, o3, o4) ? Act(o1, o2, o3, o4) : default(U);
            };
            }
        #endregion
        // Chains a conditional method with an Else
        #region Else
        public static Action Else(this Func<bool> In, Action Act)
            {
            return In.ElseIf(L.True, Act).Do();
            }
        public static Action<T1> Else<T1>(this Func<T1, bool> In, Action Act)
            {
            return In.Else(o => Act());
            }
        public static Action<T1> Else<T1>(this Func<T1, bool> In, Action<T1> Act)
            {
            return In.ElseIf(o => true, Act).Do();
            }
        public static Action<T1, T2> Else<T1, T2>(this Func<T1, T2, bool> In, Action Act)
            {
            return In.Else((o1, o2) => Act());
            }
        public static Action<T1, T2> Else<T1, T2>(this Func<T1, T2, bool> In, Action<T1, T2> Act)
            {
            return In.ElseIf((o1, o2) => true, Act).Do();
            }
        public static Action<T1, T2, T3> Else<T1, T2, T3>(this Func<T1, T2, T3, bool> In, Action Act)
            {
            return In.Else((o1, o2, o3) => Act());
            }
        public static Action<T1, T2, T3> Else<T1, T2, T3>(this Func<T1, T2, T3, bool> In, Action<T1, T2, T3> Act)
            {
            return In.ElseIf((o1, o2, o3) => true, Act).Do();
            }
        public static Action<T1, T2, T3, T4> Else<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> In, Action Act)
            {
            return In.Else((o1, o2, o3, o4) => Act());
            }
        public static Action<T1, T2, T3, T4> Else<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> In, Action<T1, T2, T3, T4> Act)
            {
            return In.ElseIf((o1, o2, o3, o4) => true, Act).Do();
            }
        public static Func<U> Else<U>(this Func<U> In, U Result)
            {
            return In.Else(Result.FN_Func());
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
            return In.Else(o => Result);
            }
        public static Func<T1, U> Else<T1, U>(this Func<T1, U> In, Action Act)
            {
            return In.Else(o => { Act(); return default(U); });
            }
        public static Func<T1, U> Else<T1, U>(this Func<T1, U> In, Func<T1, U> Act)
            {
            return In.ElseIf(o => true, Act);
            }
        public static Func<T1, T2, U> Else<T1, T2, U>(this Func<T1, T2, U> In, U Result)
            {
            return In.Else((o1, o2) => Result);
            }
        public static Func<T1, T2, U> Else<T1, T2, U>(this Func<T1, T2, U> In, Action Act)
            {
            return In.Else((o1, o2) => { Act(); return default(U); });
            }
        public static Func<T1, T2, U> Else<T1, T2, U>(this Func<T1, T2, U> In, Func<T1, T2, U> Act)
            {
            return In.ElseIf((o1, o2) => true, Act);
            }
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, U Result)
            {
            return In.Else((o1, o2, o3) => Result);
            }
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Action Act)
            {
            return In.Else((o1, o2, o3) => { Act(); return default(U); });
            }
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1, T2, T3, U> Act)
            {
            return In.ElseIf((o1, o2, o3) => true, Act);
            }
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, U Result)
            {
            return In.Else((o1, o2, o3, o4) => Result);
            }
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Action Act)
            {
            return In.Else((o1, o2, o3, o4) => { Act(); return default(U); });
            }
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1, T2, T3, T4, U> Act)
            {
            return In.ElseIf((o1, o2, o3, o4) => true, Act);
            }
        #endregion
        // Chains a conditional method with a Case statement. The case uses the first parameter as its value.
        #region Case
        // Broken - disabled.

        public static Func<T, U> Case<T, U>(this Func<T, U> In, T Obj, U Result)
            {
            return In.Case(Obj, o => Result);
            }

        public static Func<T, bool> Case<T>(this Func<T, bool> In, T Obj, Action<T> Act)
            {
            return In.ElseIf(Obj.FN_If(), Act);
            }
        public static Func<T1, T2, bool> Case<T1, T2>(this Func<T1, T2, bool> In, T1 Obj, Action<T1, T2> Act)
            {
            return In.ElseIf((o1, o2) => Logic.Object_SafeEquals(o1, Obj), Act);
            }
        public static Func<T1, T2, T3, bool> Case<T1, T2, T3>(this Func<T1, T2, T3, bool> In, T1 Obj, Action<T1, T2, T3> Act)
            {
            return In.ElseIf((o1, o2, o3) => Logic.Object_SafeEquals(o1, Obj), Act);
            }
        public static Func<T1, T2, T3, T4, bool> Case<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> In, T1 Obj, Action<T1, T2, T3, T4> Act)
            {
            return In.ElseIf((o1, o2, o3, o4) => Logic.Object_SafeEquals(o1, Obj), Act);
            }


        public static Func<T, U> Case<T, U>(this Func<T, U> In, T Obj, Func<T, U> Act)
            {
            return In.ElseIf(Obj.FN_If(), Act);
            }
        public static Func<T1, T2, U> Case<T1, T2, U>(this Func<T1, T2, U> In, T1 Obj, Func<T1, T2, U> Act)
            {
            return In.ElseIf((o1, o2) => Logic.Object_SafeEquals(o1, Obj), Act);
            }
        public static Func<T1, T2, T3, U> Case<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T1 Obj, Func<T1, T2, T3, U> Act)
            {
            return In.ElseIf((o1, o2, o3) => Logic.Object_SafeEquals(o1, Obj), Act);
            }
        public static Func<T1, T2, T3, T4, U> Case<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T1 Obj, Func<T1, T2, T3, T4, U> Act)
            {
            return In.ElseIf((o1, o2, o3, o4) => Logic.Object_SafeEquals(o1, Obj), Act);
            }

        #endregion
        // Surrounds the method with multiple condition methods - ANDing them together
        #region If - Multiple
        #region If - Multiple - Action
        public static Func<bool> If(this Action In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T, bool> If<T>(this Action In, params Func<T, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, bool> If<T1, T2>(this Action In, params Func<T1, T2, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action In, params Func<T1, T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action In, params Func<T1, T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Action_T
        public static Func<T, bool> If<T>(this Action<T> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, bool> If<T1, T2>(this Action<T1> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1> In, params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Action_T_T
        public static Func<T1, T2, bool> If<T1, T2>(this Action<T1, T2> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1, T2> In, params Func<T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2> In, params Func<T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Action_T_T_T
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1, T2, T3> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2, T3> In, params Func<T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Action_T_T_T_T
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Func_T
        public static Func<T> If<T>(this Func<T> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T2, T1> If<T1, T2>(this Func<T1> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T2, T3, T1> If<T1, T2, T3>(this Func<T1> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T2, T3, T4, T1> If<T1, T2, T3, T4>(this Func<T1> In, params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T2, T3, T4, T5, T1> If<T1, T2, T3, T4, T5>(this Func<T1> In, params Func<T2, T3, T4, T5, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Func_T_T
        public static Func<T1, U> If<T1, U>(this Func<T1, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, U> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, U> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, U> In, params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Func_T_T_T
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, T2, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, U> In, params Func<T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, params Func<T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Func_T_T_T_T
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, params Func<T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #region If - Multiple - Func_T_T_T_T_T
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }
        #endregion
        #endregion
        // Surrounds the method in an inverted conditional method
        #region Unless
        public static Func<bool> Unless(this Action In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T, bool> Unless<T>(this Action<T> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2, bool> Unless<T1, T2>(this Action<T1, T2> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1, T2, T3> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T> Unless<T>(this Func<T> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2> Unless<T1, T2>(this Func<T1, T2> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2, T3> Unless<T1, T2, T3>(this Func<T1, T2, T3> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2, T3, T4> Unless<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        public static Func<T1, T2, T3, T4, T5> Unless<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> In, Func<bool> Condition)
            {
            return In.If(Condition.Not());
            }
        #endregion
        // Surrounds the method with multiple inverted condition methods - ORing them together (and*not=nor)
        #region Unless- Multiple
        #region Unless - Multiple - Action
        public static Func<bool> Unless(this Action In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T, bool> Unless<T>(this Action In, params Func<T, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, bool> Unless<T1, T2>(this Action In, params Func<T1, T2, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action In, params Func<T1, T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action In, params Func<T1, T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Action_T
        public static Func<T, bool> Unless<T>(this Action<T> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, bool> Unless<T1, T2>(this Action<T1> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1> In, params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Action_T_T
        public static Func<T1, T2, bool> Unless<T1, T2>(this Action<T1, T2> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1, T2> In, params Func<T3, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2> In, params Func<T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Action_T_T_T
        public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1, T2, T3> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3> In, params Func<T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Action_T_T_T_T
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Func_T
        public static Func<T> Unless<T>(this Func<T> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T2, T1> Unless<T1, T2>(this Func<T1> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T2, T3, T1> Unless<T1, T2, T3>(this Func<T1> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T2, T3, T4, T1> Unless<T1, T2, T3, T4>(this Func<T1> In, params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T2, T3, T4, T5, T1> Unless<T1, T2, T3, T4, T5>(this Func<T1> In, params Func<T2, T3, T4, T5, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Func_T_T
        public static Func<T1, U> Unless<T1, U>(this Func<T1, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, U> Unless<T1, T2, U>(this Func<T1, U> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, U> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, U> In, params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Func_T_T_T
        public static Func<T1, T2, U> Unless<T1, T2, U>(this Func<T1, T2, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, T2, U> In, params Func<T3, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, params Func<T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Func_T_T_T_T
        public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, params Func<T4, bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #region Unless - Multiple - Func_T_T_T_T_T
        public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And().Not());
            }
        #endregion
        #endregion
        // And takes a list of conditions and combines them using AND logic
        #region And
        public static Func<bool> And(this IEnumerable<Func<bool>> Conditions)
            {
            return () =>
            {
                bool Out = true;
                Conditions.While(o => { Out = o(); return Out; });
                return Out;
            };
            }
        public static Func<T1, bool> And<T1>(this IEnumerable<Func<T1, bool>> Conditions)
            {
            return o1 =>
            {
                bool Out = true;
                Conditions.While(o2 => { Out = o2(o1); return Out; });
                return Out;
            };
            }
        public static Func<T1, T2, bool> And<T1, T2>(this IEnumerable<Func<T1, T2, bool>> Conditions)
            {
            return (o1, o2) =>
            {
                bool Out = true;
                Conditions.While(o3 => { Out = o3(o1, o2); return Out; });
                return Out;
            };
            }
        public static Func<T1, T2, T3, bool> And<T1, T2, T3>(this IEnumerable<Func<T1, T2, T3, bool>> Conditions)
            {
            return (o1, o2, o3) =>
            {
                bool Out = true;
                Conditions.While(o4 => { Out = o4(o1, o2, o3); return Out; });
                return Out;
            };
            }
        public static Func<T1, T2, T3, T4, bool> And<T1, T2, T3, T4>(this IEnumerable<Func<T1, T2, T3, T4, bool>> Conditions)
            {
            return (o1, o2, o3, o4) =>
            {
                bool Out = true;
                Conditions.While(o5 => { Out = o5(o1, o2, o3, o4); return Out; });
                return Out;
            };
            }
        #endregion
        // Or takes a list of conditions and combines them using OR logic
        #region Or
        public static Func<bool> Or(this IEnumerable<Func<bool>> Conditions)
            {
            return () =>
            {
                bool Out = false;
                Conditions.While(o => { Out = o(); return !Out; });
                return Out;
            };
            }
        public static Func<T1, bool> Or<T1>(this IEnumerable<Func<T1, bool>> Conditions)
            {
            return o1 =>
            {
                bool Out = false;
                Conditions.While(o2 => { Out = o2(o1); return !Out; });
                return Out;
            };
            }
        public static Func<T1, T2, bool> Or<T1, T2>(this IEnumerable<Func<T1, T2, bool>> Conditions)
            {
            return (o1, o2) =>
            {
                bool Out = false;
                Conditions.While(o3 => { Out = o3(o1, o2); return !Out; });
                return Out;
            };
            }
        public static Func<T1, T2, T3, bool> Or<T1, T2, T3>(this IEnumerable<Func<T1, T2, T3, bool>> Conditions)
            {
            return (o1, o2, o3) =>
            {
                bool Out = false;
                Conditions.While(o4 => { Out = o4(o1, o2, o3); return !Out; });
                return Out;
            };
            }
        public static Func<T1, T2, T3, T4, bool> Or<T1, T2, T3, T4>(this IEnumerable<Func<T1, T2, T3, T4, bool>> Conditions)
            {
            return (o1, o2, o3, o4) =>
            {
                bool Out = false;
                Conditions.While(o5 => { Out = o5(o1, o2, o3, o4); return !Out; });
                return Out;
            };
            }
        #endregion
        }
    }