using System;
using System.Collections;
using JetBrains.Annotations;
using LCore.Interfaces;
using LCore.LUnit;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for method exception handling
    /// </summary>
    [ExtensionProvider]
    public static class ExceptionExt
        {
        #region Extensions + 

        #region Try

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<bool> Try([CanBeNull]this Action In)
            {
            return () =>
                {
                try
                    {
                    In();
                    return true;
                    }
                catch
                    {
                    return false;
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, bool> Try<T1>([CanBeNull]this Action<T1> In)
            {
            return o =>
                {
                try
                    {
                    In(o);
                    return true;
                    }
                catch
                    {
                    return false;
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, T2, bool> Try<T1, T2>([CanBeNull]this Action<T1, T2> In)
            {
            return (o1, o2) =>
                {
                try
                    {
                    In(o1, o2);
                    return true;
                    }
                catch
                    {
                    return false;
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, T2, T3, bool> Try<T1, T2, T3>([CanBeNull]this Action<T1, T2, T3> In)
            {
            return (o1, o2, o3) =>
                {
                try
                    {
                    In(o1, o2, o3);
                    return true;
                    }
                catch
                    {
                    return false;
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, T2, T3, T4, bool> Try<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3, T4> In)
            {
            return (o1, o2, o3, o4) =>
                {
                try
                    {
                    In(o1, o2, o3, o4);
                    return true;
                    }
                catch
                    {
                    return false;
                    }
                };
            }

        /*        /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, bool> Try<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> In)
                    {
                    return (o1, o2, o3, o4, o5) => { try { In(o1, o2, o3, o4, o5); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, bool> Try<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => { try { In(o1, o2, o3, o4, o5, o6); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, bool> Try<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => { try { In(o1, o2, o3, o4, o5, o6, o7); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); return true; } catch { return false; } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, bool> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); return true; } catch { return false; } };
                    }*/

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<U> Try<U>([CanBeNull]this Func<U> In)
            {
            return () =>
                {
                try
                    {
                    return In();
                    }
                catch
                    {
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, U> Try<T1, U>([CanBeNull]this Func<T1, U> In)
            {
            return o1 =>
                {
                try
                    {
                    return In(o1);
                    }
                catch
                    {
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, T2, U> Try<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In)
            {
            return (o1, o2) =>
                {
                try
                    {
                    return In(o1, o2);
                    }
                catch
                    {
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, T2, T3, U> Try<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In)
            {
            return (o1, o2, o3) =>
                {
                try
                    {
                    return In(o1, o2, o3);
                    }
                catch
                    {
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Try<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In)
            {
            return (o1, o2, o3, o4) =>
                {
                try
                    {
                    return In(o1, o2, o3, o4);
                    }
                catch
                    {
                    return default(U);
                    }
                };
            }

        /*        /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, U> Try<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In)
                    {
                    return (o1, o2, o3, o4, o5) => { try { return In(o1, o2, o3, o4, o5); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, U> Try<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6) => { try { return In(o1, o2, o3, o4, o5, o6); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, U> Try<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => { try { return In(o1, o2, o3, o4, o5, o6, o7); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); } catch { return default(U); } };
                    }
                /// <summary>
                /// Surrounds a method in a try, ignoring exceptions. If an action is used, the result is a Boolean of whether or not the method succeeded.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Try<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); } catch { return default(U); } };
                    }*/

        #endregion

        #region Catch (All Exception Types)

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Action Catch([CanBeNull] this Action In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Action<T1> Catch<T1>([CanBeNull] this Action<T1> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Action<T1, T2> Catch<T1, T2>([CanBeNull] this Action<T1, T2> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, T2, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Action<T1, T2, T3> Catch<T1, T2, T3>([CanBeNull] this Action<T1, T2, T3> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, T2, T3, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Action<T1, T2, T3, T4> Catch<T1, T2, T3, T4>([CanBeNull] this Action<T1, T2, T3, T4> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, T2, T3, T4, Exception>(Catch);
            }

        /*        /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5> Catch<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6> Catch<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7> Catch<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Catch<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Exception>(Catch);
                    }*/

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Func<U> Catch<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<U, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Func<T1, U> Catch<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, U, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Func<T1, T2, U> Catch<T1, T2, U>([CanBeNull] this Func<T1, T2, U> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, T2, U, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U>([CanBeNull] this Func<T1, T2, T3, U> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, T2, T3, U, Exception>(Catch);
            }

        /// <summary>
        /// Catches exceptions of all types, using Exception as the base type.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U>([CanBeNull] this Func<T1, T2, T3, T4, U> In, [CanBeNull] Action<Exception> Catch)
            {
            return In.Catch<T1, T2, T3, T4, U, Exception>(Catch);
            }

        /*        /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, U> Catch<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, U> Catch<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, U> Catch<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U, Exception>(Catch);
                    }
                /// <summary>
                /// Catches exceptions of all types, using Exception as the base type.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In, Action<Exception> Catch)
                    {
                    return In.Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U, Exception>(Catch);
                    }*/

        #endregion

        #region Catch

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Action Catch<E>(this Action In, Action<E> Catch) where E : Exception
            {
            return () =>
                {
                try
                    {
                    In();
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Action<T1> Catch<T1, E>(this Action<T1> In, Action<E> Catch) where E : Exception
            {
            return o =>
                {
                try
                    {
                    In(o);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Action<T1, T2> Catch<T1, T2, E>(this Action<T1, T2> In, Action<E> Catch) where E : Exception
            {
            return (o1, o2) =>
                {
                try
                    {
                    In(o1, o2);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Action<T1, T2, T3> Catch<T1, T2, T3, E>(this Action<T1, T2, T3> In, Action<E> Catch) where E : Exception
            {
            return (o1, o2, o3) =>
                {
                try
                    {
                    In(o1, o2, o3);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Action<T1, T2, T3, T4> Catch<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In, Action<E> Catch) where E : Exception
            {
            return (o1, o2, o3, o4) =>
                {
                try
                    {
                    In(o1, o2, o3, o4);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    }
                };
            }

        /*        /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5> Catch<T1, T2, T3, T4, T5, E>(this Action<T1, T2, T3, T4, T5> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5) => { try { In(o1, o2, o3, o4, o5); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6> Catch<T1, T2, T3, T4, T5, T6, E>(this Action<T1, T2, T3, T4, T5, T6> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6) => { try { In(o1, o2, o3, o4, o5, o6); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7> Catch<T1, T2, T3, T4, T5, T6, T7, E>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => { try { In(o1, o2, o3, o4, o5, o6, o7); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Catch<T1, T2, T3, T4, T5, T6, T7, T8, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); } catch (E e) { Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { try { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); } catch (E e) { Catch(e); } };
                    }*/

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<U> Catch<U, E>(this Func<U> In, Action<E> Catch) where E : Exception
            {
            return () =>
                {
                try
                    {
                    return In();
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, U> Catch<T1, U, E>(this Func<T1, U> In, Action<E> Catch) where E : Exception
            {
            return o =>
                {
                try
                    {
                    return In(o);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, T2, U> Catch<T1, T2, U, E>(this Func<T1, T2, U> In, Action<E> Catch) where E : Exception
            {
            return (o1, o2) =>
                {
                try
                    {
                    return In(o1, o2);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, Action<E> Catch) where E : Exception
            {
            return (o1, o2, o3) =>
                {
                try
                    {
                    return In(o1, o2, o3);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    return default(U);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, Action<E> Catch)
            where E : Exception
            {
            return (o1, o2, o3, o4) =>
                {
                try
                    {
                    return In(o1, o2, o3, o4);
                    }
                catch (E Ex)
                    {
                    Catch(Ex);
                    return default(U);
                    }
                };
            }

        /*        /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, U> Catch<T1, T2, T3, T4, T5, U, E>(this Func<T1, T2, T3, T4, T5, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5) => { try { return In(o1, o2, o3, o4, o5); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, U> Catch<T1, T2, T3, T4, T5, T6, U, E>(this Func<T1, T2, T3, T4, T5, T6, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6) => { try { return In(o1, o2, o3, o4, o5, o6); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, U> Catch<T1, T2, T3, T4, T5, T6, T7, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => { try { return In(o1, o2, o3, o4, o5, o6, o7); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In, Action<E> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); } catch (E e) { Catch(e); return default(U); } };
                    }*/

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<U> Catch<U, E>(this Func<U> In, Func<E, U> Catch) where E : Exception
            {
            return () =>
                {
                try
                    {
                    return In();
                    }
                catch (E Ex)
                    {
                    return Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, U> Catch<T1, U, E>(this Func<T1, U> In, Func<E, U> Catch) where E : Exception
            {
            return o =>
                {
                try
                    {
                    return In(o);
                    }
                catch (E Ex)
                    {
                    return Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, T2, U> Catch<T1, T2, U, E>(this Func<T1, T2, U> In, Func<E, U> Catch) where E : Exception
            {
            return (o1, o2) =>
                {
                try
                    {
                    return In(o1, o2);
                    }
                catch (E Ex)
                    {
                    return Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, Func<E, U> Catch) where E : Exception
            {
            return (o1, o2, o3) =>
                {
                try
                    {
                    return In(o1, o2, o3);
                    }
                catch (E Ex)
                    {
                    return Catch(Ex);
                    }
                };
            }

        /// <summary>
        /// Catches exceptions of any type. Takes the error handler as an parameter.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, Func<E, U> Catch)
            where E : Exception
            {
            return (o1, o2, o3, o4) =>
                {
                try
                    {
                    return In(o1, o2, o3, o4);
                    }
                catch (E Ex)
                    {
                    return Catch(Ex);
                    }
                };
            }

        /*        /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, U> Catch<T1, T2, T3, T4, T5, U, E>(this Func<T1, T2, T3, T4, T5, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5) => { try { return In(o1, o2, o3, o4, o5); } catch (E e) { return Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, U> Catch<T1, T2, T3, T4, T5, T6, U, E>(this Func<T1, T2, T3, T4, T5, T6, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6) => { try { return In(o1, o2, o3, o4, o5, o6); } catch (E e) { return Catch(e); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, U> Catch<T1, T2, T3, T4, T5, T6, T7, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7) => { try { return In(o1, o2, o3, o4, o5, o6, o7); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); } catch (E e) { Catch(e); return default(U); } };
                    }
                /// <summary>
                /// Catches exceptions of any type. Takes the error handler as an parameter.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U, E>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In, Func<E, U> Catch) where E : Exception
                    {
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { try { return In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); } catch (E e) { Catch(e); return default(U); } };
                    }*/

        #endregion

        #region Catch Empty

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Action Catch<E>(this Action In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Action<T1> Catch<T1, E>(this Action<T1> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Action<T1, T2> Catch<T1, T2, E>(this Action<T1, T2> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Action<T1, T2, T3> Catch<T1, T2, T3, E>(this Action<T1, T2, T3> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Action<T1, T2, T3, T4> Catch<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /*        /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5> Catch<T1, T2, T3, T4, T5, E>(this Action<T1, T2, T3, T4, T5> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6> Catch<T1, T2, T3, T4, T5, T6, E>(this Action<T1, T2, T3, T4, T5, T6> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7> Catch<T1, T2, T3, T4, T5, T6, T7, E>(this Action<T1, T2, T3, T4, T5, T6, T7> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Catch<T1, T2, T3, T4, T5, T6, T7, T8, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, E>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }*/

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Func<U> Catch<U, E>(this Func<U> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Func<T1, U> Catch<T1, U, E>(this Func<T1, U> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Func<T1, T2, U> Catch<T1, T2, U, E>(this Func<T1, T2, U> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Func<T1, T2, T3, U> Catch<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /// <summary>
        /// Catches exceptions of any type. No handler is passed, the error is ignored.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Catch<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In) where E : Exception
            {
            return In.Catch(L.A<E>());
            }

        /*        /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, U> Catch<T1, T2, T3, T4, T5, E, U>(this Func<T1, T2, T3, T4, T5, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, U> Catch<T1, T2, T3, T4, T5, T6, E, U>(this Func<T1, T2, T3, T4, T5, T6, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, U> Catch<T1, T2, T3, T4, T5, T6, T7, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }
                /// <summary>
                /// Catches exceptions of any type. No handler is passed, the error is ignored.
                /// </summary>
                public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Catch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, E, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In) where E : Exception
                    {
                    return In.Catch(L.A<E>());
                    }*/

        #endregion

        #region Retry

        /// <summary>
        /// Retries the action a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1. 
        /// The initial attempt is not counted, so the action 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Action Retry([CanBeNull] this Action In,
            [TestBound(Minimum: 1, Maximum: 100)] int Tries = 1)
            {
            In = In ?? (() => { });
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return () =>
                {
                while (true)
                    {
                    try
                        {
                        In();
                        return;
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the action a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1. 
        /// The initial attempt is not counted, so the action 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Action<T> Retry<T>([CanBeNull] this Action<T> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? (o1 => { });
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return o =>
                {
                while (true)
                    {
                    try
                        {
                        In(o);
                        return;
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the action a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1. 
        /// The initial attempt is not counted, so the action 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Action<T1, T2> Retry<T1, T2>([CanBeNull] this Action<T1, T2> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? ((o1, o2) => { });
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return (o1, o2) =>
                {
                while (true)
                    {
                    try
                        {
                        In(o1, o2);
                        return;
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the action a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1. 
        /// The initial attempt is not counted, so the action 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Action<T1, T2, T3> Retry<T1, T2, T3>([CanBeNull] this Action<T1, T2, T3> In, 
            [TestBound(Minimum: 1,Maximum: 100)]int Tries = 1)
            {
            In = In ?? ((o1, o2, o3) => { });
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return (o1, o2, o3) =>
                {
                while (true)
                    {
                    try
                        {
                        In(o1, o2, o3);
                        return;
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the action a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1. 
        /// The initial attempt is not counted, so the action 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Action<T1, T2, T3, T4> Retry<T1, T2, T3, T4>([CanBeNull] this Action<T1, T2, T3, T4> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? ((o1, o2, o3, o4) => { });
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return (o1, o2, o3, o4) =>
                {
                while (true)
                    {
                    try
                        {
                        In(o1, o2, o3, o4);
                        return;
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the function a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1.
        /// The initial attempt is not counted, so the function 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Func<U> Retry<U>([CanBeNull] this Func<U> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? (() => default(U));
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return () =>
                {
                while (true)
                    {
                    try
                        {
                        return In();
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the function a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1.
        /// The initial attempt is not counted, so the function 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Func<T1, U> Retry<T1, U>([CanBeNull] this Func<T1, U> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? (o1 => default(U));
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return o =>
                {
                while (true)
                    {
                    try
                        {
                        return In(o);
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the function a specified number of times.
        /// The default number of  <paramref name="Tries" /> is 1.
        /// The initial attempt is not counted, so the function 
        /// will be executed at most  <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> <paramref name="Tries" /> is less than 1.</exception>
        public static Func<T1, T2, U> Retry<T1, T2, U>([CanBeNull] this Func<T1, T2, U> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? ((o1, o2) => default(U));

            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return (o1, o2) =>
                {
                while (true)
                    {
                    try
                        {
                        return In(o1, o2);
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the function a specified number of times.
        /// The default number of <paramref name="Tries" /> is 1.
        /// The initial attempt is not counted, so the function 
        /// will be executed at most <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Tries" /> is less than 1.</exception>
        public static Func<T1, T2, T3, U> Retry<T1, T2, T3, U>([CanBeNull] this Func<T1, T2, T3, U> In,
            [TestBound(Minimum: 1, Maximum: 100)]int Tries = 1)
            {
            In = In ?? ((o1, o2, o3) => default(U));

            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return (o1, o2, o3) =>
                {
                while (true)
                    {
                    try
                        {
                        return In(o1, o2, o3);
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        /// <summary>
        /// Retries the function a specified number of times.
        /// The default number of <paramref name="Tries" /> is 1.
        /// The initial attempt is not counted, so the function 
        /// will be executed at most <paramref name="Tries" /> + 1 times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Tries" /> is less than 1.</exception>
        public static Func<T1, T2, T3, T4, U> Retry<T1, T2, T3, T4, U>([CanBeNull] this Func<T1, T2, T3, T4, U> In, 
            [TestBound(Minimum: 1,Maximum: 100)]int Tries = 1)
            {
            In = In ?? ((o1, o2, o3, o4) => default(U));
            if (Tries <= 0)
                throw new ArgumentOutOfRangeException(nameof(Tries));

            return (o1, o2, o3, o4) =>
                {
                while (true)
                    {
                    try
                        {
                        return In(o1, o2, o3, o4);
                        }
                    catch (Exception)
                        {
                        if (Tries > 0)
                            {
                            Tries--;
                            continue;
                            }
                        throw;
                        }
                    }
                };
            }

        #endregion

        #region Debug

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Action<T1> Debug<T1>([CanBeNull] this Action<T1> In)
            {
            return o1 => { In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1})))(o1); };
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Action<T1, T2> Debug<T1, T2>([CanBeNull] this Action<T1, T2> In)
            {
            return (o1, o2) => { In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1, o2})))(o1, o2); };
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Action<T1, T2, T3> Debug<T1, T2, T3>([CanBeNull] this Action<T1, T2, T3> In)
            {
            return (o1, o2, o3) => { In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1, o2, o3})))(o1, o2, o3); };
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Action<T1, T2, T3, T4> Debug<T1, T2, T3, T4>([CanBeNull] this Action<T1, T2, T3, T4> In)
            {
            return
                (o1, o2, o3, o4) => { In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1, o2, o3, o4})))(o1, o2, o3, o4); };
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Func<T1, U> Debug<T1, U>([CanBeNull] this Func<T1, U> In)
            {
            return o1 => In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1})))(o1);
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Func<T1, T2, U> Debug<T1, T2, U>([CanBeNull] this Func<T1, T2, U> In)
            {
            return (o1, o2) => In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1, o2})))(o1, o2);
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Func<T1, T2, T3, U> Debug<T1, T2, T3, U>([CanBeNull] this Func<T1, T2, T3, U> In)
            {
            return (o1, o2, o3) => In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1, o2, o3})))(o1, o2, o3);
            }

        /// <summary>
        /// If an exception occurs while executing <paramref name="In" />, an exception is rethrown that includes detailed parameter data
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Debug<T1, T2, T3, T4, U>([CanBeNull] this Func<T1, T2, T3, T4, U> In)
            {
            return (o1, o2, o3, o4) => In.Catch(L.Exc.Report.Supply(L.Obj.Objects_ToString(new object[] {o1, o2, o3, o4})))(o1, o2, o3, o4);
            }

        #endregion

        #region Fail

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Action Fail([CanBeNull] this Action In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Action<T> Fail<T>([CanBeNull] this Action<T> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Action<T1, T2> Fail<T1, T2>([CanBeNull] this Action<T1, T2> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Action<T1, T2, T3> Fail<T1, T2, T3>([CanBeNull] this Action<T1, T2, T3> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Action<T1, T2, T3, T4> Fail<T1, T2, T3, T4>([CanBeNull] this Action<T1, T2, T3, T4> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Func<U> Fail<U>([CanBeNull] this Func<U> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Func<T, U> Fail<T, U>([CanBeNull] this Func<T, U> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Func<T1, T2, U> Fail<T1, T2, U>([CanBeNull] this Func<T1, T2, U> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Func<T1, T2, T3, U> Fail<T1, T2, T3, U>([CanBeNull] this Func<T1, T2, T3, U> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        /// <summary>
        /// Appends an empty exception to the current method.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Fail<T1, T2, T3, T4, U>([CanBeNull] this Func<T1, T2, T3, T4, U> In)
            {
            return In.Merge(L.Exc.Fail);
            }

        #endregion

        #region Throw

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Action Throw([CanBeNull] this Action In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Action<T> Throw<T>([CanBeNull] this Action<T> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Action<T1, T2> Throw<T1, T2>([CanBeNull] this Action<T1, T2> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Action<T1, T2, T3> Throw<T1, T2, T3>([CanBeNull] this Action<T1, T2, T3> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Action<T1, T2, T3, T4> Throw<T1, T2, T3, T4>([CanBeNull] this Action<T1, T2, T3, T4> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Func<U> Throw<U>([CanBeNull] this Func<U> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Func<T, U> Throw<T, U>([CanBeNull] this Func<T, U> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Func<T1, T2, U> Throw<T1, T2, U>([CanBeNull] this Func<T1, T2, U> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Func<T1, T2, T3, U> Throw<T1, T2, T3, U>([CanBeNull] this Func<T1, T2, T3, U> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        /// <summary>
        /// Appends an exception to the current method, with a message.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Throw<T1, T2, T3, T4, U>([CanBeNull] this Func<T1, T2, T3, T4, U> In, [CanBeNull] string Message)
            {
            return In.Merge(L.Exc.Throw.Supply(Message));
            }

        #endregion

        #region Report

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Action Report<E>(this Action In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Action<T> Report<T, E>(this Action<T> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Action<T1, T2> Report<T1, T2, E>(this Action<T1, T2> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Action<T1, T2, T3> Report<T1, T2, T3, E>(this Action<T1, T2, T3> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Action<T1, T2, T3, T4> Report<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In, string Message, E Ex)
            where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Func<U> Report<U, E>(this Func<U> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Func<T, U> Report<T, U, E>(this Func<T, U> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Func<T1, T2, U> Report<T1, T2, U, E>(this Func<T1, T2, U> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Func<T1, T2, T3, U> Report<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, string Message, E Ex) where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerException <paramref name="Ex" /> and Message <paramref name="Message" />
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Report<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, string Message, E Ex)
            where E : Exception
            {
            return In.Merge(() => L.Exc.Report(Message, Ex));
            }

        #endregion

        #region Report Empty

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Action Report<E>(this Action In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Action<T> Report<T, E>(this Action<T> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Action<T1, T2> Report<T1, T2, E>(this Action<T1, T2> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Action<T1, T2, T3> Report<T1, T2, T3, E>(this Action<T1, T2, T3> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Action<T1, T2, T3, T4> Report<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Func<U> Report<U, E>(this Func<U> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Func<T, U> Report<T, U, E>(this Func<T, U> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Func<T1, T2, U> Report<T1, T2, U, E>(this Func<T1, T2, U> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Func<T1, T2, T3, U> Report<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        /// <summary>
        /// The returned action executes action <paramref name="In" /> and then throws an
        /// Exception with InnerrException <paramref name="Ex" />
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Report<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> In, E Ex) where E : Exception
            {
            return In.Merge(L.Exc.ReportEmpty.Supply(Ex));
            }

        #endregion

        #region Handle

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Action Handle([CanBeNull]this Action In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Action<T1> Handle<T1>([CanBeNull]this Action<T1> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Action<T1, T2> Handle<T1, T2>([CanBeNull]this Action<T1, T2> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Action<T1, T2, T3> Handle<T1, T2, T3>([CanBeNull]this Action<T1, T2, T3> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Action<T1, T2, T3, T4> Handle<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3, T4> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Func<U> Handle<U>([CanBeNull]this Func<U> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Func<T1, U> Handle<T1, U>([CanBeNull]this Func<T1, U> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Func<T1, T2, U> Handle<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Func<T1, T2, T3, U> Handle<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /// <summary>
        /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
        /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Handle<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In)
            {
            return In.Catch(L.Exc.DefaultExceptionHandler);
            }

        /*      /// <summary>
              /// Handle catches all exceptions, directing them to the Default Exception Handler, which you should customize.
              /// Customize the default handler by setting: L.DefaultExceptionHandler = e => { ... };
              /// </summary>
              public static Func<T1, T2, T3, T4, T5, U> Handle<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In)
                  {
                  return In.Catch(L.Exc.DefaultExceptionHandler);
                  }*/

        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains System.Exception static methods and lambdas.
        /// </summary>
        public static class Exc
            {
            #region Lambdas +

            /// <summary>
            /// The default exception handler used with Method.Handle().
            /// This should be set to your own exception handler action.
            /// </summary>
            // ReSharper disable once FieldCanBeMadeReadOnly.Global
            public static Action<Exception> DefaultExceptionHandler = A<Exception>();

            /// <summary>
            /// An action that throws an empty exception.
            /// </summary>
            public static readonly Action Fail = () => { throw new Exception(); };

            /// <summary>
            /// An action that throws an exception with a message.
            /// </summary>
            public static readonly Action<string> Throw = Str => { throw new Exception(Str); };

            /// <summary>
            /// Rethrows an exception, adding a message.
            /// </summary>
            public static readonly Action<string, Exception> Report = (Str, Ex) => { throw new Exception(Str, Ex); };

            /// <summary>
            /// Rethrows an exception and adds no message.
            /// </summary>
            public static readonly Action<Exception> ReportEmpty = Ex => { throw Ex; };

            #endregion
            }
        }
    }