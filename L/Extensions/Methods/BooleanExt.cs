using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Dynamic;
using LCore.Extensions.Optional;
using LCore.Interfaces;
using LCore.LUnit;

// ReSharper disable ClassNeverInstantiated.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Extends booleans, conditional statements, and bitwise logic.
    /// </summary>
    [ExtensionProvider]
    public static class BooleanExt
        {
        #region Extensions +

        #region Not

        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        public static Func<bool> Not([CanBeNull]this Func<bool> Condition)
            {
            return L.Bool.Not.Surround(Condition);
            }

        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        public static Func<T1, bool> Not<T1>([CanBeNull]this Func<T1, bool> Condition)
            {
            return L.Bool.Not.Surround(Condition);
            }

        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        public static Func<T1, T2, bool> Not<T1, T2>([CanBeNull]this Func<T1, T2, bool> Condition)
            {
            return L.Bool.Not.Surround(Condition);
            }

        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        public static Func<T1, T2, T3, bool> Not<T1, T2, T3>([CanBeNull]this Func<T1, T2, T3, bool> Condition)
            {
            return L.Bool.Not.Surround(Condition);
            }

        /// <summary>
        /// Inverts the output on a method returning a Boolean.
        /// </summary>
        public static Func<T1, T2, T3, T4, bool> Not<T1, T2, T3, T4>([CanBeNull]this Func<T1, T2, T3, T4, bool> Condition)
            {
            return L.Bool.Not.Surround(Condition);
            }

        #endregion

        #region If

        #region If - Action

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the action passed is executed.
        /// </summary>
        public static Func<bool> If([CanBeNull]this Action In, [CanBeNull]Func<bool> Condition)
            {
            Condition = Condition ?? (() => false);
            In = In ?? (() => { });

            return () =>
                {
                    if (Condition())
                        {
                        In();
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the action passed is executed.
        /// </summary>
        public static Func<T, bool> If<T>([CanBeNull]this Action In, [CanBeNull]Func<T, bool> Condition)
            {
            Condition = Condition ?? (o => false);
            In = In ?? (() => { });

            return o =>
                {
                    if (Condition(o))
                        {
                        In();
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, bool> If<T1, T2>([CanBeNull]this Action In, [CanBeNull]Func<T1, T2, bool> Condition)
            {
            Condition = Condition ?? ((o1, o2) => false);
            In = In ?? (() => { });

            return (o1, o2) =>
                {
                    if (Condition(o1, o2))
                        {
                        In();
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>([CanBeNull]this Action In, [CanBeNull]Func<T1, T2, T3, bool> Condition)
            {
            Condition = Condition ?? ((o1, o2, o3) => false);
            In = In ?? (() => { });

            return (o1, o2, o3) =>
                {
                    if (Condition(o1, o2, o3))
                        {
                        In();
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>([CanBeNull]this Action In, [CanBeNull] Func<T1, T2, T3, T4, bool> Condition)
            {
            Condition = Condition ?? ((o1, o2, o3, o4) => false);
            In = In ?? (() => { });

            return (o1, o2, o3, o4) =>
                {
                    if (Condition(o1, o2, o3, o4))
                        {
                        In();
                        return true;
                        }
                    return false;
                };
            }

        #endregion

        #region If - Func_T

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the function passed is executed.
        /// </summary>
        public static Func<T> If<T>([CanBeNull]this Func<T> In, [CanBeNull]Func<bool> Condition)
            {
            Condition = Condition ?? (() => false);
            In = In ?? (() => default(T));

            return () => Condition()
                ? In()
                : default(T);
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the function passed is executed.
        /// </summary>
        public static Func<T2, T1> If<T1, T2>([CanBeNull]this Func<T1> In, [CanBeNull]Func<T2, bool> Condition)
            {
            Condition = Condition ?? (o => false);
            In = In ?? (() => default(T1));

            return o => Condition(o)
                ? In()
                : default(T1);
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the function passed is executed.
        /// </summary>
        public static Func<T2, T3, T1> If<T1, T2, T3>([CanBeNull]this Func<T1> In, [CanBeNull]Func<T2, T3, bool> Condition)
            {
            Condition = Condition ?? ((o1, o2) => false);
            In = In ?? (() => default(T1));

            return (o1, o2) => Condition(o1, o2)
                ? In()
                : default(T1);
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the function passed is executed.
        /// </summary>
        public static Func<T2, T3, T4, T1> If<T1, T2, T3, T4>([CanBeNull]this Func<T1> In, [CanBeNull]Func<T2, T3, T4, bool> Condition)
            {
            Condition = Condition ?? ((o1, o2, o3) => false);
            In = In ?? (() => default(T1));

            return (o1, o2, o3) => Condition(o1, o2, o3)
                ? In()
                : default(T1);
            }

        /// <summary>
        /// Logical If Statement. If the <paramref name="Condition" /> passed is true, the function passed is executed.
        /// </summary>
        public static Func<T2, T3, T4, T5, T1> If<T1, T2, T3, T4, T5>([CanBeNull]this Func<T1> In,
            [CanBeNull]Func<T2, T3, T4, T5, bool> Condition)
            {
            Condition = Condition ?? ((o1, o2, o3, o4) => false);
            In = In ?? (() => default(T1));

            return (o1, o2, o3, o4) => Condition(o1, o2, o3, o4)
                ? In()
                : default(T1);
            }

        #endregion

        #endregion

        #region If - Multiple

        #region If - Multiple - Action

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<bool> If([CanBeNull]this Action In, [CanBeNull]params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T, bool> If<T>([CanBeNull]this Action In, [CanBeNull]params Func<T, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T1, T2, bool> If<T1, T2>([CanBeNull]this Action In, [CanBeNull]params Func<T1, T2, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T1, T2, T3, bool> If<T1, T2, T3>([CanBeNull]this Action In, [CanBeNull]params Func<T1, T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>([CanBeNull]this Action In,
            [CanBeNull]params Func<T1, T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        #endregion

        /*

                #region If - Multiple - Action_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T, bool> If<T>(this Action<T> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, bool> If<T1, T2>(this Action<T1> In, params Func<T2, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1> In, params Func<T2, T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1> In,
                    params Func<T2, T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion

                #region If - Multiple - Action_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, bool> If<T1, T2>(this Action<T1, T2> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1, T2> In, params Func<T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2> In,
                    params Func<T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion

                #region If - Multiple - Action_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, bool> If<T1, T2, T3>(this Action<T1, T2, T3> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2, T3> In,
                    params Func<T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion

                #region If - Multiple - Action_T_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> If<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In,
                    params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion
        */

        #region If - Multiple - Func_T

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T> If<T>([CanBeNull]this Func<T> In, [CanBeNull]params Func<bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T2, T1> If<T1, T2>([CanBeNull]this Func<T1> In, [CanBeNull]params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T2, T3, T1> If<T1, T2, T3>([CanBeNull]this Func<T1> In, [CanBeNull] params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T2, T3, T4, T1> If<T1, T2, T3, T4>([CanBeNull]this Func<T1> In,
            [CanBeNull]params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// AND operation is applied if multiple conditions are passed.
        /// </summary>
        public static Func<T2, T3, T4, T5, T1> If<T1, T2, T3, T4, T5>([CanBeNull]this Func<T1> In,
            [CanBeNull]params Func<T2, T3, T4, T5, bool>[] Conditions)
            {
            return In.If(Conditions.And());
            }

        #endregion

        /*
                #region If - Multiple - Func_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, U> If<T1, U>(this Func<T1, U> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, U> In, params Func<T2, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, U> In, params Func<T2, T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, U> In,
                    params Func<T2, T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion

                #region If - Multiple - Func_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, T2, U> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, U> In, params Func<T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, U> In,
                    params Func<T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion

                #region If - Multiple - Func_T_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In,
                    params Func<T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion

                #region If - Multiple - Func_T_T_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// AND operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In,
                    params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And());
                    }

                #endregion*/

        #endregion

        #region ElseIf

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        public static Func<bool> ElseIf([CanBeNull]this Func<bool> In, [CanBeNull] Func<bool> Condition, [CanBeNull]Action Act)
            {
            Condition = Condition ?? (() => false);
            Act = Act ?? (() => { });
            In = In ?? (() => false);

            return () =>
                {
                    if (In())
                        {
                        return true;
                        }
                    if (Condition())
                        {
                        Act();
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        public static Func<T, bool> ElseIf<T>([CanBeNull]this Func<T, bool> In, [CanBeNull]Func<T, bool> Condition, [CanBeNull] Action<T> Act)
            {
            Condition = Condition ?? (o => false);
            Act = Act ?? (o => { });
            In = In ?? (o => false);

            return o =>
                {
                    if (In(o))
                        {
                        return true;
                        }
                    if (Condition(o))
                        {
                        Act(o);
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        public static Func<T1, T2, bool> ElseIf<T1, T2>([CanBeNull]this Func<T1, T2, bool> In, [CanBeNull]Func<T1, T2, bool> Condition,
            [CanBeNull]Action<T1, T2> Act)
            {
            Condition = Condition ?? ((o1, o2) => false);
            Act = Act ?? ((o1, o2) => { });
            In = In ?? ((o1, o2) => false);

            return (o1, o2) =>
                {
                    if (In(o1, o2))
                        {
                        return true;
                        }
                    if (Condition(o1, o2))
                        {
                        Act(o1, o2);
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<T1, T2, T3, bool> ElseIf<T1, T2, T3>([CanBeNull]this Func<T1, T2, T3, bool> In,
            [CanBeNull]Func<T1, T2, T3, bool> Condition, [CanBeNull]Action<T1, T2, T3> Act)
            {
            Condition = Condition ?? ((o1, o2, o3) => false);
            Act = Act ?? ((o1, o2, o3) => { });
            In = In ?? ((o1, o2, o3) => false);

            return (o1, o2, o3) =>
                {
                    if (In(o1, o2, o3))
                        {
                        return true;
                        }
                    if (Condition(o1, o2, o3))
                        {
                        Act(o1, o2, o3);
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, bool> ElseIf<T1, T2, T3, T4>([CanBeNull]this Func<T1, T2, T3, T4, bool> In,
            [CanBeNull]Func<T1, T2, T3, T4, bool> Condition, [CanBeNull]Action<T1, T2, T3, T4> Act)
            {
            Condition = Condition ?? ((o1, o2, o3, o4) => false);
            Act = Act ?? ((o1, o2, o3, o4) => { });
            In = In ?? ((o1, o2, o3, o4) => false);

            return (o1, o2, o3, o4) =>
                {
                    if (In(o1, o2, o3, o4))
                        {
                        return true;
                        }
                    if (Condition(o1, o2, o3, o4))
                        {
                        Act(o1, o2, o3, o4);
                        return true;
                        }
                    return false;
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<U> ElseIf<U>([CanBeNull]this Func<U> In, [CanBeNull]Func<bool> Condition, [CanBeNull]Func<U> Act)
            {
            Condition = Condition ?? (() => false);
            Act = Act ?? (() => default(U));
            In = In ?? (() => default(U));

            return () =>
                {
                    var Out = In();
                    if (Out != null && !Out.SafeEquals(default(U)) && (!(Out is bool) || (bool)(object)Out))
                        {
                        return Out;
                        }
                    return Condition()
                        ? Act()
                        : default(U);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<T, U> ElseIf<T, U>([CanBeNull]this Func<T, U> In, [CanBeNull]Func<T, bool> Condition, [CanBeNull] Func<T, U> Act)
            {
            Condition = Condition ?? (o => false);
            Act = Act ?? (o => default(U));
            In = In ?? (o => default(U));

            return o =>
                {
                    var Out = In(o);
                    if (Out != null && !Out.SafeEquals(default(U)) && (!(Out is bool) || (bool)(object)Out))
                        {
                        return Out;
                        }
                    return Condition(o)
                        ? Act(o)
                        : default(U);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<T1, T2, U> ElseIf<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull]Func<T1, T2, bool> Condition,
            [CanBeNull]Func<T1, T2, U> Act)
            {
            Condition = Condition ?? ((o1, o2) => false);
            In = In ?? ((o1, o2) => default(U));
            Act = Act ?? ((o1, o2) => default(U));

            return (o1, o2) =>
                {
                    var Out = In(o1, o2);
                    if (Out != null && !Out.SafeEquals(default(U)) && (!(Out is bool) || (bool)(object)Out))
                        {
                        return Out;
                        }
                    return Condition(o1, o2)
                        ? Act(o1, o2)
                        : default(U);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<T1, T2, T3, U> ElseIf<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In,
            [CanBeNull]Func<T1, T2, T3, bool> Condition, [CanBeNull] Func<T1, T2, T3, U> Act)
            {
            Condition = Condition ?? ((o1, o2, o3) => false);
            In = In ?? ((o1, o2, o3) => default(U));
            Act = Act ?? ((o1, o2, o3) => default(U));

            return (o1, o2, o3) =>
                {
                    var Out = In(o1, o2, o3);
                    if (Out != null && !Out.SafeEquals(default(U)) && (!(Out is bool) || (bool)(object)Out))
                        {
                        return Out;
                        }
                    return Condition(o1, o2, o3)
                        ? Act(o1, o2, o3)
                        : default(U);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false and the result of <paramref name="Condition" /> is true.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, U> ElseIf<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In,
            [CanBeNull]Func<T1, T2, T3, T4, bool> Condition, [CanBeNull]Func<T1, T2, T3, T4, U> Act)
            {
            Condition = Condition ?? ((o1, o2, o3, o4) => false);
            In = In ?? ((o1, o2, o3, o4) => default(U));
            Act = Act ?? ((o1, o2, o3, o4) => default(U));

            return (o1, o2, o3, o4) =>
                {
                    var Out = In(o1, o2, o3, o4);
                    if (Out != null && !Out.SafeEquals(default(U)) && (!(Out is bool) || (bool)(object)Out))
                        {
                        return Out;
                        }
                    return Condition(o1, o2, o3, o4)
                        ? Act(o1, o2, o3, o4)
                        : default(U);
                };
            }

        #endregion

        #region Else +

        #region Else - Action

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Action Else([CanBeNull]this Func<bool> In, [CanBeNull]Action Act)
            {
            In = In ?? (() => false);
            Act = Act ?? (() => { });
            return () =>
                {
                    if (!In())
                        Act();
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Action<T1> Else<T1>([CanBeNull]this Func<T1, bool> In, [CanBeNull]Action<T1> Act)
            {
            In = In ?? (o => false);
            Act = Act ?? (o => { });
            return o =>
                {
                    if (!In(o))
                        Act(o);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Action<T1, T2> Else<T1, T2>([CanBeNull]this Func<T1, T2, bool> In, [CanBeNull]Action<T1, T2> Act)
            {
            In = In ?? ((o1, o2) => false);
            Act = Act ?? ((o1, o2) => { });

            return (o1, o2) =>
                {
                    if (!In(o1, o2))
                        Act(o1, o2);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Action<T1, T2, T3> Else<T1, T2, T3>([CanBeNull]this Func<T1, T2, T3, bool> In, [CanBeNull]Action<T1, T2, T3> Act)
            {
            In = In ?? ((o1, o2, o3) => false);
            Act = Act ?? ((o1, o2, o3) => { });

            return (o1, o2, o3) =>
                {
                    if (!In(o1, o2, o3))
                        Act(o1, o2, o3);
                };
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Action<T1, T2, T3, T4> Else<T1, T2, T3, T4>([CanBeNull]this Func<T1, T2, T3, T4, bool> In, [CanBeNull]Action<T1, T2, T3, T4> Act)
            {
            In = In ?? ((o1, o2, o3, o4) => false);
            Act = Act ?? ((o1, o2, o3, o4) => { });

            return (o1, o2, o3, o4) =>
                {
                    if (!In(o1, o2, o3, o4))
                        Act(o1, o2, o3, o4);
                };
            }

        #endregion

        #region Else - Func

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<U> Else<U>([CanBeNull]this Func<U> In, [CanBeNull]Func<U> Act)
            {
            return In.ElseIf(L.Bool.True, Act);
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, U> Else<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Func<T1, U> Act)
            {
            return In.ElseIf(o => true, Act);
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, T2, U> Else<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T1, T2, U> Act)
            {
            return In.ElseIf((o1, o2) => true, Act);
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull]Func<T1, T2, T3, U> Act)
            {
            return In.ElseIf((o1, o2, o3) => true, Act);
            }

        /// <summary>
        /// Executes <paramref name="Act" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In,
           [CanBeNull] Func<T1, T2, T3, T4, U> Act)
            {
            return In.ElseIf((o1, o2, o3, o4) => true, Act);
            }

        #endregion

        #region Else - Result

        /// <summary>
        /// Returns <paramref name="Result" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<U> Else<U>([CanBeNull]this Func<U> In, [CanBeNull]U Result)
            {
            return In.Else(Result.FN_Func());
            }

        /// <summary>
        /// Returns <paramref name="Result" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, U> Else<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]U Result)
            {
            return In.Else(o => Result);
            }

        /// <summary>
        /// Returns <paramref name="Result" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, T2, U> Else<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull]U Result)
            {
            return In.Else((o1, o2) => Result);
            }

        /// <summary>
        /// Returns <paramref name="Result" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, T2, T3, U> Else<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull]U Result)
            {
            return In.Else((o1, o2, o3) => Result);
            }

        /// <summary>
        /// Returns <paramref name="Result" /> if the result of <paramref name="In" /> is false.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, U> Else<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull]U Result)
            {
            return In.Else((o1, o2, o3, o4) => Result);
            }

        #endregion

        #endregion

        #region Unless- Multiple

        #region Unless - Multiple - Action

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<bool> Unless([CanBeNull]this Action In, [CanBeNull]params Func<bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T, bool> Unless<T>([CanBeNull]this Action In, [CanBeNull]params Func<T, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T1, T2, bool> Unless<T1, T2>([CanBeNull]this Action In, [CanBeNull]params Func<T1, T2, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>([CanBeNull]this Action In,
            [CanBeNull]params Func<T1, T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>([CanBeNull]this Action In,
            [CanBeNull]params Func<T1, T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        #endregion

        /*

                #region Unless - Multiple - Action_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T, bool> Unless<T>(this Action<T> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, bool> Unless<T1, T2>(this Action<T1> In, params Func<T2, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1> In,
                    params Func<T2, T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1> In,
                    params Func<T2, T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion

                #region Unless - Multiple - Action_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, bool> Unless<T1, T2>(this Action<T1, T2> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1, T2> In,
                    params Func<T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2> In,
                    params Func<T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion

                #region Unless - Multiple - Action_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, bool> Unless<T1, T2, T3>(this Action<T1, T2, T3> In,
                    params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3> In,
                    params Func<T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion

                #region Unless - Multiple - Action_T_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, bool> Unless<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In,
                    params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion
        */

        #region Unless - Multiple - Func_T

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T> Unless<T>(this Func<T> In, params Func<bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T2, T1> Unless<T1, T2>(this Func<T1> In, params Func<T2, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T2, T3, T1> Unless<T1, T2, T3>(this Func<T1> In, params Func<T2, T3, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T2, T3, T4, T1> Unless<T1, T2, T3, T4>(this Func<T1> In,
            params Func<T2, T3, T4, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        /// <summary>
        /// Surrounds the method with multiple condition methods.
        /// OR operation is applied if multiple conditions are passed.
        /// </summary>
        
        public static Func<T2, T3, T4, T5, T1> Unless<T1, T2, T3, T4, T5>(this Func<T1> In,
            params Func<T2, T3, T4, T5, bool>[] Conditions)
            {
            return In.If(Conditions.Or().Not());
            }

        #endregion

        /*

                #region Unless - Multiple - Func_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, U> Unless<T1, U>(this Func<T1, U> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, U> Unless<T1, T2, U>(this Func<T1, U> In, params Func<T2, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, U> In,
                    params Func<T2, T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, U> In,
                    params Func<T2, T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion

                #region Unless - Multiple - Func_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, U> Unless<T1, T2, U>(this Func<T1, T2, U> In, params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, T2, U> In,
                    params Func<T3, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, U> In,
                    params Func<T3, T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion

                #region Unless - Multiple - Func_T_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, U> Unless<T1, T2, T3, U>(this Func<T1, T2, T3, U> In,
                    params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In,
                    params Func<T4, bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion

                #region Unless - Multiple - Func_T_T_T_T_T

                /// <summary>
                /// Surrounds the method with multiple condition methods.
                /// OR operation is applied if multiple conditions are passed.
                /// </summary>
                public static Func<T1, T2, T3, T4, U> Unless<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In,
                    params Func<bool>[] Conditions)
                    {
                    return In.If(Conditions.And().Not());
                    }

                #endregion
        */

        #endregion

        #region And

        /// <summary>
        /// Combines the conditions using the AND operation.
        /// </summary>
        
        public static Func<bool> And([CanBeNull]this IEnumerable<Func<bool>> Conditions)
            {
            return () =>
                {
                    bool Out = true;
                    Conditions.While(o =>
                        {
                            Out = o();
                            return Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the AND operation.
        /// </summary>
        
        public static Func<T1, bool> And<T1>([CanBeNull]this IEnumerable<Func<T1, bool>> Conditions)
            {
            return o1 =>
                {
                    bool Out = true;
                    Conditions.While(o2 =>
                        {
                            Out = o2(o1);
                            return Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the AND operation.
        /// </summary>
        
        public static Func<T1, T2, bool> And<T1, T2>([CanBeNull]this IEnumerable<Func<T1, T2, bool>> Conditions)
            {
            return (o1, o2) =>
                {
                    bool Out = true;
                    Conditions.While(o3 =>
                        {
                            Out = o3(o1, o2);
                            return Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the AND operation.
        /// </summary>
        
        public static Func<T1, T2, T3, bool> And<T1, T2, T3>([CanBeNull]this IEnumerable<Func<T1, T2, T3, bool>> Conditions)
            {
            return (o1, o2, o3) =>
                {
                    bool Out = true;
                    Conditions.While(o4 =>
                        {
                            Out = o4(o1, o2, o3);
                            return Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the AND operation.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, bool> And<T1, T2, T3, T4>(
            [CanBeNull]this IEnumerable<Func<T1, T2, T3, T4, bool>> Conditions)
            {
            return (o1, o2, o3, o4) =>
                {
                    bool Out = true;
                    Conditions.While(o5 =>
                        {
                            Out = o5(o1, o2, o3, o4);
                            return Out;
                        });
                    return Out;
                };
            }

        #endregion

        #region Or

        /// <summary>
        /// Combines the conditions using the OR operation.
        /// </summary>
        
        public static Func<bool> Or([CanBeNull]this IEnumerable<Func<bool>> Conditions)
            {
            return () =>
                {
                    bool Out = false;
                    Conditions.While(o =>
                        {
                            Out = o();
                            return !Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the OR operation.
        /// </summary>
        
        public static Func<T1, bool> Or<T1>([CanBeNull]this IEnumerable<Func<T1, bool>> Conditions)
            {
            return o1 =>
                {
                    bool Out = false;
                    Conditions.While(o2 =>
                        {
                            Out = o2(o1);
                            return !Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the OR operation.
        /// </summary>
        
        public static Func<T1, T2, bool> Or<T1, T2>([CanBeNull]this IEnumerable<Func<T1, T2, bool>> Conditions)
            {
            return (o1, o2) =>
                {
                    bool Out = false;
                    Conditions.While(o3 =>
                        {
                            Out = o3(o1, o2);
                            return !Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the OR operation.
        /// </summary>
        
        public static Func<T1, T2, T3, bool> Or<T1, T2, T3>([CanBeNull]this IEnumerable<Func<T1, T2, T3, bool>> Conditions)
            {
            return (o1, o2, o3) =>
                {
                    bool Out = false;
                    Conditions.While(o4 =>
                        {
                            Out = o4(o1, o2, o3);
                            return !Out;
                        });
                    return Out;
                };
            }

        /// <summary>
        /// Combines the conditions using the OR operation.
        /// </summary>
        
        public static Func<T1, T2, T3, T4, bool> Or<T1, T2, T3, T4>(
            [CanBeNull]this IEnumerable<Func<T1, T2, T3, T4, bool>> Conditions)
            {
            return (o1, o2, o3, o4) =>
                {
                    bool Out = false;
                    Conditions.While(o5 =>
                        {
                            Out = o5(o1, o2, o3, o4);
                            return !Out;
                        });
                    return Out;
                };
            }

        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains System.Boolean static methods and lambdas.
        /// </summary>
        public static class Bool
            {
            #region Boolean Lambdas - Shorthand +

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
            public static readonly Func<bool, bool, bool> And = (o1, o2) => o1 && o2;

            /// <summary>
            /// Returns a function that ORs the booleans that are sent
            /// </summary>
            public static readonly Func<bool, bool, bool> Or = (o1, o2) => o1 || o2;

            /// <summary>
            /// Returns a function that XORs the booleans that are sent
            /// </summary>
            public static readonly Func<bool, bool, bool> Xor = (o1, o2) => o1 ^ o2;

            #endregion

            #region Logic Lambdas +

            #region If

            /// <summary>
            /// Logical If Statement. If the condition passed is true, the action passed is executed.
            /// </summary>
            [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
            public static Func<Func /*GF*/<bool>, Action, Func /*GF*/<bool>> L_If_A /*MF*/()
                {
                return (Condition, Action) =>
                    {
                        return () =>
                            {
                                if (Condition())
                                    {
                                    Action();
                                    return true;
                                    }
                                return false;
                            };
                    };
                }

            /// <summary>
            /// Logical If Statement. If the condition passed is true, the action passed is executed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
            public static Func<Func<T1, bool>, Action<T1>, Func<T1, bool>> L_If_A<T1>()
                {
                return (Condition, Action) =>
                    {
                        return o =>
                            {
                                if (Condition(o))
                                    {
                                    Action(o);
                                    return true;
                                    }
                                return false;
                            };
                    };
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
                return (Condition, Action) =>
                    {
                        return (o1, o2) =>
                            {
                                if (Condition(o1, o2))
                                    {
                                    Action(o1, o2);
                                    return true;
                                    }
                                return false;
                            };
                    };
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
                return (Condition, Action) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (Condition(o1, o2, o3))
                                    {
                                    Action(o1, o2, o3);
                                    return true;
                                    }
                                return false;
                            };
                    };
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
                return (Condition, Action) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (Condition(o1, o2, o3, o4))
                                    {
                                    Action(o1, o2, o3, o4);
                                    return true;
                                    }
                                return false;
                            };
                    };
                }

            /// <summary>
            /// Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("If", new[] { "Condition", "Action" }, Comments.If)]
            public static Func<Func<bool>, Func<U>, Func<U>> L_If_F<U>()
                {
                return (Condition, Action) =>
                    {
                        return () => Condition()
                            ? Action()
                            : default(U);
                    };
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
                return (Condition, Action) =>
                    {
                        return o1 => Condition(o1)
                            ? Action(o1)
                            : default(U);
                    };
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
                return (Condition, Action) =>
                    {
                        return (o1, o2) => Condition(o1, o2)
                            ? Action(o1, o2)
                            : default(U);
                    };
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
                return (Condition, Action) =>
                    {
                        return (o1, o2, o3) => Condition(o1, o2, o3)
                            ? Action(o1, o2, o3)
                            : default(U);
                    };
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
                return (Condition, Action) =>
                    {
                        return (o1, o2, o3, o4) => Condition(o1, o2, o3, o4)
                            ? Action(o1, o2, o3, o4)
                            : default(U);
                    };
                }

            #endregion

            #region If Else

            /// <summary>
            /// Logical If Else Statement. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
            /// </summary>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
            public static Func<Func<bool>, Action, Action, Action> L_IfElse()
                {
                return (Condition, Action, Else) =>
                    {
                        return () =>
                            {
                                if (Condition())
                                    Action();
                                else
                                    Else();
                            };
                    };
                }

            /// <summary>
            /// Logical If Else Statement. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
            public static Func<Func<T1, bool>, Action<T1>, Action<T1>, Action<T1>> L_IfElse<T1>()
                {
                return (Condition, Action, Else) =>
                    {
                        return o1 =>
                            {
                                if (Condition(o1))
                                    Action(o1);
                                else
                                    Else(o1);
                            };
                    };
                }

            /// <summary>
            /// Logical If Else Statement. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
            public static Func<Func<T1, T2, bool>, Action<T1, T2>, Action<T1, T2>, Action<T1, T2>> L_IfElse<T1, T2>()
                {
                return (Condition, Action, Else) =>
                    {
                        return (o1, o2) =>
                            {
                                if (Condition(o1, o2))
                                    Action(o1, o2);
                                else
                                    Else(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Logical If Else Statement. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
            public static Func<Func<T1, T2, T3, bool>, Action<T1, T2, T3>, Action<T1, T2, T3>, Action<T1, T2, T3>> L_IfElse<T1, T2, T3>()
                {
                return (Condition, Action, Else) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (Condition(o1, o2, o3))
                                    Action(o1, o2, o3);
                                else
                                    Else(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Logical If Else Statement. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("IfElse", new[] { "Condition", "Action", "Else" }, Comments.IfElse)]
            public static Func<Func<T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_IfElse
                <T1, T2, T3, T4>()
                {
                return (Condition, Action, Else) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (Condition(o1, o2, o3, o4))
                                    Action(o1, o2, o3, o4);
                                else
                                    Else(o1, o2, o3, o4);
                            };
                    };
                }

            #endregion

            #endregion

            internal class Comments
                {
                #region Comments +

                internal const string If =
                    "Logical If Statement. If the condition passed is true, the action passed is executed.";

                internal const string IfFunc =
                    "Logical If Statement for a Func. If the condition passed is true, the action passed is executed and its result returned. Otherwise, the result will be the default value for U.";

                internal const string IfElse =
                    "Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.";

                #endregion
                }
            }
        }
    }