using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Dynamic;
using LCore.LUnit;
using LCore.Tools;

// ReSharper disable UnusedMember.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions methods for logical methods: 
    /// Action and Func
    /// </summary>
    public static class LogicExt
        {
        #region Extensions +

        #region Surround +
        #region Surround - Action_T

        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action Surround<U>([CanBeNull]this Action<U> In, [CanBeNull]Func<U> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return () => { In(Func()); };
            }

        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1> Surround<T1, U>([CanBeNull]this Action<U> In, [CanBeNull]Func<T1, U> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return o => { In(Func(o)); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2> Surround<T1, T2, U>([CanBeNull]this Action<U> In, [CanBeNull]Func<T1, T2, U> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => { In(Func(o1, o2)); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        public static Action<T1, T2, T3> Surround<T1, T2, T3, U>([CanBeNull]this Action<U> In, [CanBeNull] Func<T1, T2, T3, U> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(Func(o1, o2, o3)); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T3, T4> Surround<T1, T2, T3, T4, U>([CanBeNull]this Action<U> In, [CanBeNull]Func<T1, T2, T3, T4, U> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(Func(o1, o2, o3, o4)); };
            }
        #endregion
        #region Surround - Action_T_T
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2> Surround<T1, T2>([CanBeNull]this Action<T1, T2> In, [CanBeNull]Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return o => { In(Func(), o); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1> Surround2<T1, T2>([CanBeNull]this Action<T1, T2> In, [CanBeNull]Func<T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return o => { In(o, Func()); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3> Surround<T1, T2, T3>([CanBeNull]this Action<T1, T2> In, [CanBeNull]Func<T3, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => { In(Func(o2), o1); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3> Surround2<T1, T2, T3>([CanBeNull]this Action<T1, T2> In, [CanBeNull]Func<T3, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => { In(o1, Func(o2)); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3, T4> Surround<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2> In, [CanBeNull]Func<T3, T4, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(Func(o2, o3), o1); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3, T4> Surround2<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2> In, [CanBeNull] Func<T3, T4, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(o1, Func(o2, o3)); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3, T4, T5> Surround<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2> In, [CanBeNull]Func<T3, T4, T5, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(Func(o2, o3, o4), o1); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3, T4, T5> Surround2<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2> In, [CanBeNull] Func<T3, T4, T5, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(o1, Func(o2, o3, o4)); };
            }
        #endregion
        #region Surround - Action_T_T_T
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3> Surround<T1, T2, T3>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => { In(Func(), o1, o2); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3> Surround2<T1, T2, T3>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull]Func<T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => { In(o1, Func(), o2); };
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2> Surround3<T1, T2, T3>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => { In(o1, o2, Func()); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3, T4> Surround<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T4, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(Func(o3), o1, o2); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3, T4> Surround2<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T4, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(o1, Func(o3), o2); };
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T4> Surround3<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T4, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(o1, o2, Func(o3)); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3, T4, T5> Surround<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T4, T5, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(Func(o3, o4), o1, o2); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3, T4, T5> Surround2<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T4, T5, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(o1, Func(o3, o4), o2); };
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T4, T5> Surround3<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3> In, [CanBeNull] Func<T4, T5, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(o1, o2, Func(o3, o4)); };
            }
        #endregion
        #region Surround - Action_T_T_T_T
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3, T4> Surround<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(Func(), o1, o2, o3); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3, T4> Surround2<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(o1, Func(), o2, o3); };
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T4> Surround3<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(o1, o2, Func(), o3); };
            }
        /// <summary>
        /// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T3> Surround4<T1, T2, T3, T4>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T4> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => { In(o1, o2, o3, Func()); };
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T2, T3, T4, T5> Surround<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T5, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(Func(o4), o1, o2, o3); };
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T3, T4, T5> Surround2<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T5, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(o1, Func(o4), o2, o3); };
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T4, T5> Surround3<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T5, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(o1, o2, Func(o4), o3); };
            }
        /// <summary>
        /// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Action<T1, T2, T3, T5> Surround4<T1, T2, T3, T4, T5>([CanBeNull]this Action<T1, T2, T3, T4> In, [CanBeNull] Func<T5, T4> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => { In(o1, o2, o3, Func(o4)); };
            }
        #endregion
        #region Surround - Func_T_U
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<U> Surround<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull] Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return () => In(Func());
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> or <paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, U> Surround<T1, T2, U>([CanBeNull]this Func<T2, U> In, [CanBeNull] Func<T1, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return o => In(Func(o));
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> or is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, U> Surround<T1, T2, T3, U>([CanBeNull]this Func<T3, U> In, [CanBeNull] Func<T1, T2, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => In(Func(o1, o2));
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T3, U> Surround<T1, T2, T3, T4, U>([CanBeNull]this Func<T4, U> In, [CanBeNull] Func<T1, T2, T3, T4> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(Func(o1, o2, o3));
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T3, T4, U> Surround<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T5, U> In, [CanBeNull] Func<T1, T2, T3, T4, T5> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(Func(o1, o2, o3, o4));
            }
        #endregion
        #region Surround - Func_T_T_U
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, U> Surround<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return o => In(Func(), o);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, U> Surround2<T1, T2, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return o => In(o, Func());
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, U> Surround<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T3, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => In(Func(o2), o1);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, U> Surround2<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T3, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => In(o1, Func(o2));
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, T4, U> Surround<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T3, T4, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(Func(o2, o3), o1);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, T4, U> Surround2<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T3, T4, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(o1, Func(o2, o3));
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, T4, T5, U> Surround<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T3, T4, T5, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(Func(o2, o3, o4), o1);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, T4, T5, U> Surround2<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, U> In, [CanBeNull] Func<T3, T4, T5, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(o1, Func(o2, o3, o4));
            }
        #endregion
        #region Surround - Func_T_T_T_U
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, U> Surround<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => In(Func(), o1, o2);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, U> Surround2<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => In(o1, Func(), o2);
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, U> Surround3<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2) => In(o1, o2, Func());
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, T4, U> Surround<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T4, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(Func(o3), o1, o2);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, T4, U> Surround2<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T4, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(o1, Func(o3), o2);
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T4, U> Surround3<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T4, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(o1, o2, Func(o3));
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, T4, T5, U> Surround<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T4, T5, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(Func(o3, o4), o1, o2);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, T4, T5, U> Surround2<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T4, T5, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(o1, Func(o3, o4), o2);
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T4, T5, U> Surround3<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, U> In, [CanBeNull] Func<T4, T5, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(o1, o2, Func(o3, o4));
            }
        #endregion
        #region Surround - Func_T_T_T_T_U
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, T4, U> Surround<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(Func(), o1, o2, o3);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, T4, U> Surround2<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(o1, Func(), o2, o3);
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T4, U> Surround3<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(o1, o2, Func(), o3);
            }
        /// <summary>
        /// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T3, U> Surround4<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T4> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3) => In(o1, o2, o3, Func());
            }
        /// <summary>
        /// Returns a method with the first parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T2, T3, T4, T5, U> Surround<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T5, T1> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(Func(o4), o1, o2, o3);
            }
        /// <summary>
        /// Returns a method with the second parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T3, T4, T5, U> Surround2<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T5, T2> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(o1, Func(o4), o2, o3);
            }
        /// <summary>
        /// Returns a method with the third parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T4, T5, U> Surround3<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T5, T3> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(o1, o2, Func(o4), o3);
            }
        /// <summary>
        /// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter lists are merged.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="In"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="Func"/> is <see langword="null" />.</exception>
        [Tested]
        public static Func<T1, T2, T3, T5, U> Surround4<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, T4, U> In, [CanBeNull] Func<T5, T4> Func)
            {
            if (In == null) throw new ArgumentNullException(nameof(In));
            if (Func == null) throw new ArgumentNullException(nameof(Func));
            return (o1, o2, o3, o4) => In(o1, o2, o3, Func(o4));
            }
        #endregion
        #endregion

        #region Enclose +
        #region Enclose - Action_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action Enclose<T1>([CanBeNull]this Func<T1> Func, [CanBeNull] Action<T1> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2> Enclose<T1, T2>([CanBeNull]this Func<T2, T1> Func, [CanBeNull] Action<T1> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3> Enclose<T1, T2, T3>([CanBeNull]this Func<T2, T3, T1> Func, [CanBeNull] Action<T1> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>([CanBeNull]this Func<T2, T3, T4, T1> Func, [CanBeNull] Action<T1> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>([CanBeNull]this Func<T2, T3, T4, T5, T1> Func, [CanBeNull] Action<T1> Outer)
            {
            return Outer.Surround(Func);
            }
        #endregion
        #region Enclose - Action_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2> Enclose<T1, T2>([CanBeNull]this Func<T1> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1> Enclose2<T1, T2>([CanBeNull]this Func<T2> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3> Enclose<T1, T2, T3>([CanBeNull]this Func<T3, T1> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3> Enclose2<T1, T2, T3>([CanBeNull]this Func<T3, T2> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>([CanBeNull]this Func<T3, T4, T1> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3, T4> Enclose2<T1, T2, T3, T4>([CanBeNull]this Func<T3, T4, T2> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>([CanBeNull]this Func<T3, T4, T5, T1> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3, T4, T5> Enclose2<T1, T2, T3, T4, T5>([CanBeNull]this Func<T3, T4, T5, T2> Func, [CanBeNull] Action<T1, T2> Outer)
            {
            return Outer.Surround2(Func);
            }
        #endregion
        #region Enclose - Action_T_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3> Enclose<T1, T2, T3>([CanBeNull]this Func<T1> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3> Enclose2<T1, T2, T3>([CanBeNull]this Func<T2> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2> Enclose3<T1, T2, T3>([CanBeNull]this Func<T3> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>([CanBeNull]this Func<T4, T1> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3, T4> Enclose2<T1, T2, T3, T4>([CanBeNull]this Func<T4, T2> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2, T4> Enclose3<T1, T2, T3, T4>([CanBeNull]this Func<T4, T3> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>([CanBeNull]this Func<T4, T5, T1> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3, T4, T5> Enclose2<T1, T2, T3, T4, T5>([CanBeNull]this Func<T4, T5, T2> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2, T4, T5> Enclose3<T1, T2, T3, T4, T5>([CanBeNull]this Func<T4, T5, T3> Func, [CanBeNull] Action<T1, T2, T3> Outer)
            {
            return Outer.Surround3(Func);
            }
        #endregion
        #region Enclose - Action_T_T_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>([CanBeNull]this Func<T1> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3, T4> Enclose2<T1, T2, T3, T4>([CanBeNull]this Func<T2> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2, T4> Enclose3<T1, T2, T3, T4>([CanBeNull]this Func<T3> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2, T3> Enclose4<T1, T2, T3, T4>([CanBeNull]this Func<T4> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround4(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>([CanBeNull]this Func<T5, T1> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T3, T4, T5> Enclose2<T1, T2, T3, T4, T5>([CanBeNull]this Func<T5, T2> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2, T4, T5> Enclose3<T1, T2, T3, T4, T5>([CanBeNull]this Func<T5, T3> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Action<T1, T2, T3, T5> Enclose4<T1, T2, T3, T4, T5>([CanBeNull]this Func<T5, T4> Func, [CanBeNull] Action<T1, T2, T3, T4> Outer)
            {
            return Outer.Surround4(Func);
            }
        #endregion
        #region Enclose - Func_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        [Tested]
        public static Func<U> Enclose<T1, U>([CanBeNull]this Func<T1> Func, [CanBeNull] Func<T1, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, U> Enclose<T1, T2, U>([CanBeNull]this Func<T1, T2> Func, [CanBeNull] Func<T2, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, U> Enclose<T1, T2, T3, U>([CanBeNull]this Func<T1, T2, T3> Func, [CanBeNull] Func<T3, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T3, U> Enclose<T1, T2, T3, T4, U>([CanBeNull]this Func<T1, T2, T3, T4> Func, [CanBeNull] Func<T4, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T3, T4, U> Enclose<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T1, T2, T3, T4, T5> Func, [CanBeNull] Func<T5, U> Outer)
            {
            return Outer.Surround(Func);
            }
        #endregion
        #region Enclose - Func_T_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, U> Enclose<T1, T2, U>([CanBeNull]this Func<T1> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, U> Enclose2<T1, T2, U>([CanBeNull]this Func<T2> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, U> Enclose<T1, T2, T3, U>([CanBeNull]this Func<T3, T1> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, U> Enclose2<T1, T2, T3, U>([CanBeNull]this Func<T3, T2> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, T4, U> Enclose<T1, T2, T3, T4, U>([CanBeNull]this Func<T3, T4, T1> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, T4, U> Enclose2<T1, T2, T3, T4, U>([CanBeNull]this Func<T3, T4, T2> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, T4, T5, U> Enclose<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T3, T4, T5, T1> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, T4, T5, U> Enclose2<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T3, T4, T5, T2> Func, [CanBeNull] Func<T1, T2, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        #endregion
        #region Enclose - Func_T_T_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, U> Enclose<T1, T2, T3, U>([CanBeNull]this Func<T1> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, U> Enclose2<T1, T2, T3, U>([CanBeNull]this Func<T2> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, U> Enclose3<T1, T2, T3, U>([CanBeNull]this Func<T3> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, T4, U> Enclose<T1, T2, T3, T4, U>([CanBeNull]this Func<T4, T1> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, T4, U> Enclose2<T1, T2, T3, T4, U>([CanBeNull]this Func<T4, T2> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T4, U> Enclose3<T1, T2, T3, T4, U>([CanBeNull]this Func<T4, T3> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, T4, T5, U> Enclose<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T4, T5, T1> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, T4, T5, U> Enclose2<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T4, T5, T2> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T4, T5, U> Enclose3<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T4, T5, T3> Func, [CanBeNull] Func<T1, T2, T3, U> Outer)
            {
            return Outer.Surround3(Func);
            }
        #endregion
        #region Enclose - Func_T_T_T_T_T
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, T4, U> Enclose<T1, T2, T3, T4, U>([CanBeNull]this Func<T1> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, T4, U> Enclose2<T1, T2, T3, T4, U>([CanBeNull]this Func<T2> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T4, U> Enclose3<T1, T2, T3, T4, U>([CanBeNull]this Func<T3> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T3, U> Enclose4<T1, T2, T3, T4, U>([CanBeNull]this Func<T4> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround4(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, T3, T4, T5, U> Enclose<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T5, T1> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T3, T4, T5, U> Enclose2<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T5, T2> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround2(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T4, T5, U> Enclose3<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T5, T3> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround3(Func);
            }
        /// <summary>
        /// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="Func"></param>
        /// <param name="Outer"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T1, T2, T3, T5, U> Enclose4<T1, T2, T3, T4, T5, U>([CanBeNull]this Func<T5, T4> Func, [CanBeNull] Func<T1, T2, T3, T4, U> Outer)
            {
            return Outer.Surround4(Func);
            }
        #endregion
        #endregion

        #region Cast
        /// <summary>
        /// Returns a function that takes a Casts the paramater of the Action to U1
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>

        [Tested]
        public static Action<U1> Cast<T1, U1>([CanBeNull]this Action<T1> In) where U1 : T1
            {
            return L.Logic.L_Cast_A<T1, U1>()(In);
            }
        /// <summary>
        /// Returns a function that takes a Casts the paramaters of the Action to U1, U2
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>

        [Tested]
        public static Action<U1, U2> Cast<T1, T2, U1, U2>([CanBeNull]this Action<T1, T2> In)
            where U1 : T1
            where U2 : T2
            {
            return L.Logic.L_Cast_A<T1, T2, U1, U2>()(In);
            }
        /// <summary>
        /// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <typeparam name="U3"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Action<U1, U2, U3> Cast<T1, T2, T3, U1, U2, U3>(this Action<T1, T2, T3> In)
            where U1 : T1
            where U2 : T2
            where U3 : T3
            {
            return L.Logic.L_Cast_A<T1, T2, T3, U1, U2, U3>()(In);
            }
        /// <summary>
        /// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3, U4
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <typeparam name="U3"></typeparam>
        /// <typeparam name="U4"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Action<U1, U2, U3, U4> Cast<T1, T2, T3, T4, U1, U2, U3, U4>(this Action<T1, T2, T3, T4> In)
            where U1 : T1
            where U2 : T2
            where U3 : T3
            where U4 : T4
            {
            return L.Logic.L_Cast_A<T1, T2, T3, T4, U1, U2, U3, U4>()(In);
            }
        /// <summary>
        /// Returns a function that Casts the output of the Func to U2
        /// </summary>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Func<U2> Cast<U1, U2>([CanBeNull]this Func<U1> In)
            {
            return L.Logic.L_Cast_F<U1, U2>()(In);
            }
        /// <summary>
        /// Returns a function that Casts the output of the Func to U2 and the input to T2
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T2, U2> Cast<T1, U1, T2, U2>([CanBeNull]this Func<T1, U1> In)
            where T2 : T1
            where U2 : U1
            {
            return L.Logic.L_Cast_F<T1, U1, T2, U2>()(In);
            }
        /// <summary>
        /// Returns a function that Casts the output of the Func to U2 and the inputs to T3, T4
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T3, T4, U2> Cast<T1, T2, U1, T3, T4, U2>([CanBeNull]this Func<T1, T2, U1> In)
            where T3 : T1
            where T4 : T2
            where U2 : U1
            {
            return L.Logic.L_Cast_F<T1, T2, U1, T3, T4, U2>()(In);
            }
        /// <summary>
        /// Returns a function that Casts the output of the Func to U2 and the inputs to T4, T5, T6
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T4, T5, T6, U2> Cast<T1, T2, T3, U1, T4, T5, T6, U2>([CanBeNull]this Func<T1, T2, T3, U1> In)
            where T4 : T1
            where T5 : T2
            where T6 : T3
            where U2 : U1
            {
            return L.Logic.L_Cast_F<T1, T2, T3, U1, T4, T5, T6, U2>()(In);
            }
        /// <summary>
        /// Returns a function that Casts the output of the Func to U2 and the inputs to T6, T7, T8, T9
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="U1"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="U2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        [Tested]
        public static Func<T5, T6, T7, T8, U2> Cast<T1, T2, T3, T4, U1, T5, T6, T7, T8, U2>([CanBeNull]this Func<T1, T2, T3, T4, U1> In)
            where T5 : T1
            where T6 : T2
            where T7 : T3
            where T8 : T4
            where U2 : U1
            {
            return L.Logic.L_Cast_F<T1, T2, T3, T4, U1, T5, T6, T7, T8, U2>()(In);
            }
        #endregion

        #endregion
        }

    public static partial class L
        {
        /// <summary>
        /// Contains static methods and lambdas pertaining to logical operations.
        /// (Action and Func)
        /// </summary>
        public static class Logic
            {
            #region Static Methods +

            #region Do

            /// <summary>
            /// Returns an Action from the supplied Func. The return value is discarded.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Do", new[] { "In" }, Comments.Do, false, true)]
            [CodeExplodeGenerics("Do", Comments.Do)]
            public static Func<Func /*GF*/<U>, Action> L_Do /*MF*/<U>()
                {
                return In =>
                    {
                        return () => { In(); };
                    };
                }

            #endregion

            #region Cache

            internal static readonly Dictionary<string, Dictionary<string, CacheData>> ResultCacheData = new Dictionary<string, Dictionary<string, CacheData>>();


            /// <summary>
            /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Cache", new[] { "In", "CacheID" }, Comments.Cache, false, true)]
            [CodeExplodeGenerics("Cache", Comments.Cache)]
            public static Func<Func<U>, string, Func<U>> L_Cache /*MF*/<U>()
                {
                return (In, CacheID) =>
                    {
                        Dictionary<string, CacheData> CacheDict;
                        if (!ResultCacheData.ContainsKey(CacheID))
                            {
                            CacheDict = new Dictionary<string, CacheData>( /**/);
                            ResultCacheData.Add(CacheID, CacheDict);
                            }
                        else
                            {
                            CacheDict = ResultCacheData[CacheID];
                            }

                        return () =>
                            {
                                var Start = DateTime.Now;

                                string Key = Obj.Objects_ToString(Ary.Array<object>( /*A*/)());
                                lock (CacheDict)
                                    {
                                    bool Exists = CacheDict.ContainsKey(Key);
                                    if (Exists)
                                        {
                                        var CachedResult = CacheDict[Key];

                                        if (CachedResult.Data is U)
                                            {
                                            var End = DateTime.Now;

                                            CachedResult.AddTime(
                                            (long)
                                                (CachedResult.OriginalTimeMS - (End - Start).Ticks * Date.TicksToMilliseconds));

                                            return (U)CachedResult.Data;
                                            }
                                        }
                                    var Out = In();
                                    var End2 = DateTime.Now;
                                    if (!Exists)
                                        CacheDict.Add(Key,
                                        new CacheData(Out, (long)((End2 - Start).Ticks * Date.TicksToMilliseconds)));
                                    return Out;
                                    }
                            };
                    };
                }

            /// <summary>
            /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
            /// </summary>

            public static T Cache<T>(ref object CacheStore, [CanBeNull] Func<T> Default)
                {
                if (!(CacheStore is T))
                    CacheStore = Default();
                return (T)CacheStore;
                }

            /// <summary>
            /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
            /// </summary>

            public static T Cache<T>(ref T CacheStore, [CanBeNull] Func<T> Default)
                {
                // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                if (CacheStore == null)
                    CacheStore = Default();
                return CacheStore;
                }

            /// <summary>
            /// Return an array of all L.Logic.ResultCacheData Keys
            /// </summary>
            public static string[] DataCaches => ResultCacheData.Keys.Array();

            /// <summary>
            /// Returns the set of CacheData for the L.Logic.ResultCacheData Key.
            /// </summary>
            public static Dictionary<string, CacheData> GetCacheData(string Key)
                {
                return ResultCacheData.ContainsKey(Key) ? ResultCacheData[Key] : null;
                }

            /// <summary>
            /// Clear data for an L.Logic.ResultCacheData Key.
            /// </summary>
            public static void ClearCache(string Key)
                {
                ResultCacheData.SafeRemove(Key);
                }

            #endregion

            #region Set Func

            #region Set Func 1

            /// <summary>
            /// Returns a function that sets (overrides) the first parameter in Func with the result of In
            /// </summary>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 0 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Action<T1>, Func<T1>, Action<T1>> L_SetFunc_A<T1>()
                {
                return (Func, In) =>
                    {
                        return o1 => { Func(In()); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the first parameter in Func with the result of In
            /// </summary>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 0 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Func<T1, U>, Func<T1>, Func<T1, U>> L_SetFunc_F /*MF*/<T1, U>()
                {
                return (Func, In) =>
                    {
                        return o1 => Func(In());
                    };
                }

            #endregion

            #region Set Func 2

            /// <summary>
            /// Returns a function that sets (overrides) the second parameter in Func with the result of In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 1 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Action<T1, T2>, Func<T2>, Action<T1, T2>> L_SetFunc_A2<T1, T2>()
                {
                return (Func, In) =>
                    {
                        return (o1, o2) => { Func(o1, In()); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the second parameter in Func with the result of In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 1 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Func<T1, T2, U>, Func<T2>, Func<T1, T2, U>> L_SetFunc_F2 /*MF*/<T1, T2, U>()
                {
                return (Func, In) =>
                    {
                        return (o1, o2) => Func(o1, In());
                    };
                }

            #endregion

            #region Set Func 3

            /// <summary>
            /// Returns a function that sets (overrides) the third parameter in Func with the result of In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 2 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Action<T1, T2, T3>, Func<T3>, Action<T1, T2, T3>> L_SetFunc_A3<T1, T2, T3>()
                {
                return (Func, In) =>
                    {
                        return (o1, o2, o3) => { Func(o1, o2, In()); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the third parameter in Func with the result of In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 2 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Func<T1, T2, T3, U>, Func<T3>, Func<T1, T2, T3, U>> L_SetFunc_F3 /*MF*/<T1, T2, T3, U>()
                {
                return (Func, In) =>
                    {
                        return (o1, o2, o3) => Func(o1, o2, In());
                    };
                }

            #endregion

            #region Set Func 4

            /// <summary>
            /// Returns a function that sets (overrides) the fourth parameter in Func with the result of In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 3 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Action<T1, T2, T3, T4>, Func<T4>, Action<T1, T2, T3, T4>> L_SetFunc_A4<T1, T2, T3, T4>()
                {
                return (Func, In) =>
                    {
                        return (o1, o2, o3, o4) => Func(o1, o2, o3, In());
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the fourth parameter in Func with the result of In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 3 }, new[] { "In()" }, Comments.SetFunc)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<T4>, Func<T1, T2, T3, T4, U>> L_SetFunc_F4 /*MF*/
                <T1, T2, T3, T4, U>()
                {
                return (Func, In) =>
                    {
                        return (o1, o2, o3, o4) => Func(o1, o2, o3, In());
                    };
                }

            #endregion
            /*

                        #region Set Func 5

                        /// <summary>
                        /// Returns a function that sets (overrides) the fifth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 4 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Action<T1, T2, T3, T4, T5>,[CanBeNull] Func<T5>,[CanBeNull] Action<T1, T2, T3, T4, T5>> L_SetFunc_A5
                            <T1, T2, T3, T4, T5>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5) => { Func(o1, o2, o3, o4, In()); };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the fifth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 4 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Func<T1, T2, T3, T4, T5, U>,[CanBeNull] Func<T5>,[CanBeNull] Func<T1, T2, T3, T4, T5, U>> L_SetFunc_F5 /*MF#1#
                            <T1, T2, T3, T4, T5, U>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5) => Func(o1, o2, o3, o4, In());
                                };
                            }

                        #endregion

                        #region Set Func 6

                        /// <summary>
                        /// Returns a function that sets (overrides) the sixth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 5 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Action<T1, T2, T3, T4, T5, T6>,[CanBeNull] Func<T6>,[CanBeNull] Action<T1, T2, T3, T4, T5, T6>> L_SetFunc_A6
                            <T1, T2, T3, T4, T5, T6>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6) => { Func(o1, o2, o3, o4, o5, In()); };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the sixth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 5 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Func<T1, T2, T3, T4, T5, T6, U>,[CanBeNull] Func<T6>,[CanBeNull] Func<T1, T2, T3, T4, T5, T6, U>> L_SetFunc_F6
                            /*MF#1#<T1, T2, T3, T4, T5, T6, U>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6) => Func(o1, o2, o3, o4, o5, In());
                                };
                            }

                        #endregion

                        #region Set Func 7

                        /// <summary>
                        /// Returns a function that sets (overrides) the seventh parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 6 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>,[CanBeNull] Func<T7>,[CanBeNull] Action<T1, T2, T3, T4, T5, T6, T7>>
                            L_SetFunc_A7<T1, T2, T3, T4, T5, T6, T7>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7) => { Func(o1, o2, o3, o4, o5, o6, In()); };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the seventh parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 6 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>,[CanBeNull] Func<T7>,[CanBeNull] Func<T1, T2, T3, T4, T5, T6, T7, U>>
                            L_SetFunc_F7 /*MF#1#<T1, T2, T3, T4, T5, T6, T7, U>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7) => Func(o1, o2, o3, o4, o5, o6, In());
                                };
                            }

                        #endregion

                        #region Set Func 8

                        /// <summary>
                        /// Returns a function that sets (overrides) the eighth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 7 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>,[CanBeNull] Func<T8>,[CanBeNull] Action<T1, T2, T3, T4, T5, T6, T7, T8>>
                            L_SetFunc_A8<T1, T2, T3, T4, T5, T6, T7, T8>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { Func(o1, o2, o3, o4, o5, o6, o7, In()); };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the eighth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 7 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>,[CanBeNull] Func<T8>,[CanBeNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, U>>
                            L_SetFunc_F8 /*MF#1#<T1, T2, T3, T4, T5, T6, T7, T8, U>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7, o8) => Func(o1, o2, o3, o4, o5, o6, o7, In());
                                };
                            }

                        #endregion

                        #region Set Func 9

                        /// <summary>
                        /// Returns a function that sets (overrides) the ninth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 8 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>,[CanBeNull] Func<T9>,[CanBeNull] Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
                            L_SetFunc_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { Func(o1, o2, o3, o4, o5, o6, o7, o8, In()); };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the eighth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 8 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>,[CanBeNull] Func<T9>,[CanBeNull] Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>>
                            L_SetFunc_F9 /*MF#1#<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => Func(o1, o2, o3, o4, o5, o6, o7, o8, In());
                                };
                            }

                        #endregion

                        #region Set Func 10

                        /// <summary>
                        /// Returns a function that sets (overrides) the tenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 9 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>,[CanBeNull] Func<T10>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_SetFunc_A10
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, In()); };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the tenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 9 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>,[CanBeNull] Func<T10>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_SetFunc_F10 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
                            {
                            return (Func, In) =>
                                {
                                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, In());
                                };
                            }

                        #endregion

                        #region Set Func 11

                        /// <summary>
                        /// Returns a function that sets (overrides) the eleventh parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 10 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>,[CanBeNull] Func<T11>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_SetFunc_A11
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                                            {
                                                Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, In());
                                            };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the eleventh parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 10 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>,[CanBeNull] Func<T11>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_SetFunc_F11 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                                            Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, In());
                                };
                            }

                        #endregion

                        #region Set Func 12

                        /// <summary>
                        /// Returns a function that sets (overrides) the twelfth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 11 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>,[CanBeNull] Func<T12>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_SetFunc_A12 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                                            {
                                                Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, In());
                                            };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the twelfth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 11 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>,[CanBeNull] Func<T12>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_SetFunc_F12 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                                            Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, In());
                                };
                            }

                        #endregion

                        #region Set Func 13

                        /// <summary>
                        /// Returns a function that sets (overrides) the thirteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 12 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>,[CanBeNull] Func<T13>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_SetFunc_A13 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                                            {
                                                Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, In());
                                            };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the thirteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 12 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>,[CanBeNull] Func<T13>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_SetFunc_F13 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                                            Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, In());
                                };
                            }

                        #endregion

                        #region Set Func 14

                        /// <summary>
                        /// Returns a function that sets (overrides) the fourteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 13 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>,[CanBeNull] Func<T14>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_SetFunc_A14 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                                            {
                                                Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, In());
                                            };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the fourteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 13 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>,[CanBeNull] Func<T14>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_SetFunc_F14 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                                            Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, In());
                                };
                            }

                        #endregion

                        #region Set Func 15

                        /// <summary>
                        /// Returns a function that sets (overrides) the fifteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 14 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>,[CanBeNull] Func<T15>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_SetFunc_A15 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                                            {
                                                Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, In());
                                            };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the fifteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 14 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>,[CanBeNull] Func<T15>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_SetFunc_F15 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                                            Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, In());
                                };
                            }

                        #endregion

                        #region Set Func 16

                        /// <summary>
                        /// Returns a function that sets (overrides) the sixteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 15 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>,[CanBeNull] Func<T16>,
                                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_SetFunc_A16 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                                            {
                                                Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, In());
                                            };
                                };
                            }

                        /// <summary>
                        /// Returns a function that sets (overrides) the fifteenth parameter in Func with the result of In
                        /// </summary>
                        [CodeExplodeGenericsReplaceArguments("Set", new[] { 15 }, new[] { "In()" }, Comments.SetFunc)]
                        [CodeExplodeExtensionMethod("Set", new[] { "Func", "In" }, Comments.SetFunc, false, true)]
                        public static
                        Func
                            <Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>,[CanBeNull] Func<T16>,
                                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_SetFunc_F16 /*MF#1#
                            <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
                            {
                            return (Func, In) =>
                                {
                                    return
                                        (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                                            Func(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, In());
                                };
                            }

                        #endregion
            */

            #endregion

            #region Set

            #region Set 1

            /// <summary>
            /// Returns a function that sets (overrides) the first parameter in Func with In
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 0 }, new[] { "Obj" }, Comments.Set)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "Obj" }, Comments.Set, false, true)]
            public static Func<Action<T1>, T1, Action<T1>> L_Set_A<T1>()
                {
                return (Func, Obj) =>
                    {
                        return o1 => { Func(Obj); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the first parameter in Func with In
            /// </summary>

            [CodeExplodeGenericsReplaceArguments("Set", new[] { 0 }, new[] { "Obj" }, Comments.Set)]
            [CodeExplodeExtensionMethod("Set", new[] { "Func", "Obj" }, Comments.Set, false, true)]
            public static Func<Func<T1, U>, T1, Func<T1, U>> L_Set_F /*MF*/<T1, U>()
                {
                return (Func, Obj) =>
                    {
                        return o1 => Func(Obj);
                    };
                }

            #endregion

            #region Set 2

            /// <summary>
            /// Returns a function that sets (overrides) the second parameter in Func with In
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set2", new[] { 1 }, new[] { "Obj" }, Comments.Set2)]
            [CodeExplodeExtensionMethod("Set2", new[] { "Func", "Obj" }, Comments.Set2, false, true)]
            public static Func<Action<T1, T2>, T2, Action<T1, T2>> L_Set2_A<T1, T2>()
                {
                return (Func, Obj) =>
                    {
                        return (o1, o2) => { Func(o1, Obj); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the second parameter in Func with In
            /// </summary>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set2", new[] { 1 }, new[] { "Obj" }, Comments.Set2)]
            [CodeExplodeExtensionMethod("Set2", new[] { "Func", "Obj" }, Comments.Set2, false, true)]
            public static Func<Func<T1, T2, U>, T2, Func<T1, T2, U>> L_Set2_F /*MF*/<T1, T2, U>()
                {
                return (Func, Obj) =>
                    {
                        return (o1, o2) => Func(o1, Obj);
                    };
                }

            #endregion

            #region Set 3

            /// <summary>
            /// Returns a function that sets (overrides) the third parameter in Func with In
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set3", new[] { 2 }, new[] { "Obj" }, Comments.Set3)]
            [CodeExplodeExtensionMethod("Set3", new[] { "Func", "Obj" }, Comments.Set3, false, true)]
            public static Func<Action<T1, T2, T3>, T3, Action<T1, T2, T3>> L_Set3_A<T1, T2, T3>()
                {
                return (Func, Obj) =>
                    {
                        return (o1, o2, o3) => { Func(o1, o2, Obj); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the third parameter in Func with In
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set3", new[] { 2 }, new[] { "Obj" }, Comments.Set3)]
            [CodeExplodeExtensionMethod("Set3", new[] { "Func", "Obj" }, Comments.Set3, false, true)]
            public static Func<Func<T1, T2, T3, U>, T3, Func<T1, T2, T3, U>> L_Set3_F /*MF*/<T1, T2, T3, U>()
                {
                return (Func, Obj) =>
                    {
                        return (o1, o2, o3) => Func(o1, o2, Obj);
                    };
                }

            #endregion

            #region Set 4

            /// <summary>
            /// Returns a function that sets (overrides) the fourth parameter in Func with In
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set4", new[] { 3 }, new[] { "Obj" }, Comments.Set4)]
            [CodeExplodeExtensionMethod("Set4", new[] { "Func", "Obj" }, Comments.Set4, false, true)]
            public static Func<Action<T1, T2, T3, T4>, T4, Action<T1, T2, T3, T4>> L_Set4_A<T1, T2, T3, T4>()
                {
                return (Func, Obj) =>
                    {
                        return (o1, o2, o3, o4) => { Func(o1, o2, o3, Obj); };
                    };
                }

            /// <summary>
            /// Returns a function that sets (overrides) the fourth parameter in Func with In
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeGenericsReplaceArguments("Set4", new[] { 3 }, new[] { "Obj" }, Comments.Set4)]
            [CodeExplodeExtensionMethod("Set4", new[] { "Func", "Obj" }, Comments.Set4, false, true)]
            public static Func<Func<T1, T2, T3, T4, U>, T4, Func<T1, T2, T3, T4, U>> L_Set4_F /*MF*/<T1, T2, T3, T4, U>()
                {
                return (Func, Obj) =>
                    {
                        return (o1, o2, o3, o4) => Func(o1, o2, o3, Obj);
                    };
                }

            #endregion

            #endregion

            #region Return

            /// <summary>
            /// Returns a function that converts an action to a Func, returning the specified value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Action, U, Func<U>> L_Return_A<U>()
                {
                return (In, Obj) =>
                    {
                        return () =>
                            {
                                In();
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that converts an action to a Func, returning the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Action<T1>, U, Func<T1, U>> L_Return_A<T1, U>()
                {
                return (In, Obj) =>
                    {
                        return o1 =>
                            {
                                In(o1);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that converts an action to a Func, returning the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Action<T1, T2>, U, Func<T1, T2, U>> L_Return_A<T1, T2, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that converts an action to a Func, returning the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Action<T1, T2, T3>, U, Func<T1, T2, T3, U>> L_Return_A<T1, T2, T3, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that converts an action to a Func, returning the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Action<T1, T2, T3, T4>, U, Func<T1, T2, T3, T4, U>> L_Return_A<T1, T2, T3, T4, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Overrides the return value of In with the specified value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.ReturnFunc)]
            public static Func<Func<U>, U, Func<U>> L_Return_F<U>()
                {
                return (In, Obj) =>
                    {
                        return () =>
                            {
                                In();
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Overrides the return value of In with the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Func<T1, U>, U, Func<T1, U>> L_Return_F<T1, U>()
                {
                return (In, Obj) =>
                    {
                        return o1 =>
                            {
                                In(o1);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Overrides the return value of In with the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Func<T1, T2, U>, U, Func<T1, T2, U>> L_Return_F<T1, T2, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Overrides the return value of In with the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Func<T1, T2, T3, U>, U, Func<T1, T2, T3, U>> L_Return_F<T1, T2, T3, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return Obj;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Overrides the return value of In with the specified value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Return", new[] { "In", "Obj = default(U)" }, Comments.Return)]
            public static Func<Func<T1, T2, T3, T4, U>, U, Func<T1, T2, T3, T4, U>> L_Return_F<T1, T2, T3, T4, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return Obj;
                            };
                    };
                }

            #endregion

            #region Rotate

            /// <summary>
            /// Returns a function that rotates the list of parameters to the right.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Rotate", new[] { "In" }, Comments.Rotate)]
            public static Func<Action<T1, T2>, Action<T2, T1>> L_Rotate_A<T1, T2>()
                {
                return In => { return (o1, o2) => { In(o2, o1); }; };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the right.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Rotate", new[] { "In" }, Comments.Rotate)]
            public static Func<Action<T1, T2, T3>, Action<T3, T1, T2>> L_Rotate_A<T1, T2, T3>()
                {
                return In => { return (o3, o1, o2) => { In(o1, o2, o3); }; };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the right.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Rotate", new[] { "In" }, Comments.Rotate)]
            public static Func<Action<T1, T2, T3, T4>, Action<T4, T1, T2, T3>> L_Rotate_A<T1, T2, T3, T4>()
                {
                return In => { return (o4, o1, o2, o3) => { In(o1, o2, o3, o4); }; };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the right.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Rotate", new[] { "In" }, Comments.Rotate)]
            public static Func<Func<T1, T2, U>, Func<T2, T1, U>> L_Rotate_F<T1, T2, U>()
                {
                return In => { return (o2, o1) => In(o1, o2); };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the right.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Rotate", new[] { "In" }, Comments.Rotate)]
            public static Func<Func<T1, T2, T3, U>, Func<T3, T1, T2, U>> L_Rotate_F<T1, T2, T3, U>()
                {
                return In => { return (o3, o1, o2) => In(o1, o2, o3); };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the right.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Rotate", new[] { "In" }, Comments.Rotate)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<T4, T1, T2, T3, U>> L_Rotate_F<T1, T2, T3, T4, U>()
                {
                return In => { return (o4, o1, o2, o3) => In(o1, o2, o3, o4); };
                }

            #endregion

            #region RotateBack

            /// <summary>
            /// Returns a function that rotates the list of parameters to the left.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RotateBack", new[] { "In" }, Comments.RotateBack)]
            public static Func<Action<T1, T2>, Action<T2, T1>> L_RotateBack_A<T1, T2>()
                {
                return In => { return (o1, o2) => { In(o2, o1); }; };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the left.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2, T3>, Action<T2, T3, T1>> L_RotateBack_A<T1, T2, T3>()
                {
                return In => { return (o1, o2, o3) => { In(o3, o1, o2); }; };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the left.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2, T3, T4>, Action<T2, T3, T4, T1>> L_RotateBack_A<T1, T2, T3, T4>()
                {
                return In => { return (o1, o2, o3, o4) => { In(o4, o1, o2, o3); }; };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the left.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, T2, U>, Func<T2, T1, U>> L_RotateBack_F<T1, T2, U>()
                {
                return In => { return (o1, o2) => In(o2, o1); };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the left.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, T2, T3, U>, Func<T2, T3, T1, U>> L_RotateBack_F<T1, T2, T3, U>()
                {
                return In => { return (o2, o3, o1) => In(o1, o2, o3); };
                }

            /// <summary>
            /// Returns a function that rotates the list of parameters to the left.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, T2, T3, T4, U>, Func<T2, T3, T4, T1, U>> L_RotateBack_F<T1, T2, T3, T4, U>()
                {
                return In => { return (o2, o3, o4, o1) => In(o1, o2, o3, o4); };
                }

            #endregion

            #region Default

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Action<T1>, T1, Action<T1>> L_Default_A<T1>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return o1 =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                In(o1);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Action<T1, T2>, T1, Action<T1, T2>> L_Default_A<T1, T2>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return (o1, o2) =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// If the second argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default2", new[] { "In", "Default" }, Comments.Default2)]
            public static Func<Action<T1, T2>, T2, Action<T1, T2>> L_Default2_A<T1, T2>()
                {
                return (In, Default2) =>
                    {
                        Func<T2, bool> NullFunc = Obj.IsNull<T2>();
                        return (o1, o2) =>
                            {
                                if (NullFunc(o2))
                                    {
                                    o2 = Default2;
                                    }
                                In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Action<T1, T2, T3>, T1, Action<T1, T2, T3>> L_Default_A<T1, T2, T3>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the second argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default2", new[] { "In", "Default2" }, Comments.Default2)]
            public static Func<Action<T1, T2, T3>, T2, Action<T1, T2, T3>> L_Default2_A<T1, T2, T3>()
                {
                return (In, Default2) =>
                    {
                        Func<T2, bool> NullFunc = Obj.IsNull<T2>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o2))
                                    {
                                    o2 = Default2;
                                    }
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the third argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default3", new[] { "In", "Default3" }, Comments.Default3)]
            public static Func<Action<T1, T2, T3>, T3, Action<T1, T2, T3>> L_Default3_A<T1, T2, T3>()
                {
                return (In, Default3) =>
                    {
                        Func<T3, bool> NullFunc = Obj.IsNull<T3>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o3))
                                    {
                                    o3 = Default3;
                                    }
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Action<T1, T2, T3, T4>, T1, Action<T1, T2, T3, T4>> L_Default_A<T1, T2, T3, T4>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the second argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default2", new[] { "In", "Default2" }, Comments.Default2)]
            public static Func<Action<T1, T2, T3, T4>, T2, Action<T1, T2, T3, T4>> L_Default2_A<T1, T2, T3, T4>()
                {
                return (In, Default2) =>
                    {
                        Func<T2, bool> NullFunc = Obj.IsNull<T2>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o2))
                                    {
                                    o2 = Default2;
                                    }
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the third argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default3", new[] { "In", "Default3" }, Comments.Default3)]
            public static Func<Action<T1, T2, T3, T4>, T3, Action<T1, T2, T3, T4>> L_Default3_A<T1, T2, T3, T4>()
                {
                return (In, Default3) =>
                    {
                        Func<T3, bool> NullFunc = Obj.IsNull<T3>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o3))
                                    {
                                    o3 = Default3;
                                    }
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the fourth argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default4", new[] { "In", "Default4" }, Comments.Default4)]
            public static Func<Action<T1, T2, T3, T4>, T4, Action<T1, T2, T3, T4>> L_Default4_A<T1, T2, T3, T4>()
                {
                return (In, Default4) =>
                    {
                        Func<T4, bool> NullFunc = Obj.IsNull<T4>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o4))
                                    {
                                    o4 = Default4;
                                    }
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Func<T1, U>, T1, Func<T1, U>> L_Default_F<T1, U>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return o1 =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                return In(o1);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Func<T1, T2, U>, T1, Func<T1, T2, U>> L_Default_F<T1, T2, U>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return (o1, o2) =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                return In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// If the second argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default2", new[] { "In", "Default2" }, Comments.Default2)]
            public static Func<Func<T1, T2, U>, T2, Func<T1, T2, U>> L_Default2_F<T1, T2, U>()
                {
                return (In, Default) =>
                    {
                        Func<T2, bool> NullFunc = Obj.IsNull<T2>();
                        return (o1, o2) =>
                            {
                                if (NullFunc(o2))
                                    {
                                    o2 = Default;
                                    }
                                return In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Func<T1, T2, T3, U>, T1, Func<T1, T2, T3, U>> L_Default_F<T1, T2, T3, U>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the second argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default2", new[] { "In", "Default2" }, Comments.Default2)]
            public static Func<Func<T1, T2, T3, U>, T2, Func<T1, T2, T3, U>> L_Default2_F<T1, T2, T3, U>()
                {
                return (In, Default) =>
                    {
                        Func<T2, bool> NullFunc = Obj.IsNull<T2>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o2))
                                    {
                                    o2 = Default;
                                    }
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the third argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default3", new[] { "In", "Default3" }, Comments.Default3)]
            public static Func<Func<T1, T2, T3, U>, T3, Func<T1, T2, T3, U>> L_Default3_F<T1, T2, T3, U>()
                {
                return (In, Default) =>
                    {
                        Func<T3, bool> NullFunc = Obj.IsNull<T3>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o3))
                                    {
                                    o3 = Default;
                                    }
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the first argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default", new[] { "In", "Default" }, Comments.Default)]
            public static Func<Func<T1, T2, T3, T4, U>, T1, Func<T1, T2, T3, T4, U>> L_Default_F<T1, T2, T3, T4, U>()
                {
                return (In, Default) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o1))
                                    {
                                    o1 = Default;
                                    }
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the second argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default2", new[] { "In", "Default2" }, Comments.Default2)]
            public static Func<Func<T1, T2, T3, T4, U>, T2, Func<T1, T2, T3, T4, U>> L_Default2_F<T1, T2, T3, T4, U>()
                {
                return (In, Default) =>
                    {
                        Func<T2, bool> NullFunc = Obj.IsNull<T2>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o2))
                                    {
                                    o2 = Default;
                                    }
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the third argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default3", new[] { "In", "Default3" }, Comments.Default3)]
            public static Func<Func<T1, T2, T3, T4, U>, T3, Func<T1, T2, T3, T4, U>> L_Default3_F<T1, T2, T3, T4, U>()
                {
                return (In, Default) =>
                    {
                        Func<T3, bool> NullFunc = Obj.IsNull<T3>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o3))
                                    {
                                    o3 = Default;
                                    }
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the fourth argument passed is null or empty, the Default value is used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Default4", new[] { "In", "Default4" }, Comments.Default4)]
            public static Func<Func<T1, T2, T3, T4, U>, T4, Func<T1, T2, T3, T4, U>> L_Default4_F<T1, T2, T3, T4, U>()
                {
                return (In, Default) =>
                    {
                        Func<T4, bool> NullFunc = Obj.IsNull<T4>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o4))
                                    {
                                    o4 = Default;
                                    }
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            #endregion

            #region Defaults

            /// <summary>
            /// If the arguments passed are null or empty, the Default values are used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Defaults", new[] { "In", "Default", "Default2" }, Comments.Defaults)]
            public static Func<Action<T1, T2>, T1, T2, Action<T1, T2>> L_Defaults_A<T1, T2>()
                {
                return (In, Default, Default2) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        Func<T2, bool> NullFunc2 = Obj.IsNull<T2>();
                        return (o1, o2) =>
                            {
                                if (NullFunc(o1))
                                    o1 = Default;
                                if (NullFunc2(o2))
                                    o2 = Default2;
                                In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// If the arguments passed are null or empty, the Default values are used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Defaults", new[] { "In", "Default", "Default2", "Default3" }, Comments.Defaults)]
            public static Func<Action<T1, T2, T3>, T1, T2, T3, Action<T1, T2, T3>> L_Defaults_A<T1, T2, T3>()
                {
                return (In, Default, Default2, Default3) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        Func<T2, bool> NullFunc2 = Obj.IsNull<T2>();
                        Func<T3, bool> NullFunc3 = Obj.IsNull<T3>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o1))
                                    o1 = Default;
                                if (NullFunc2(o2))
                                    o2 = Default2;
                                if (NullFunc3(o3))
                                    o3 = Default3;
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the arguments passed are null or empty, the Default values are used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Defaults", new[] { "In", "Default", "Default2", "Default3", "Default4" },
                Comments.Defaults)]
            public static Func<Action<T1, T2, T3, T4>, T1, T2, T3, T4, Action<T1, T2, T3, T4>> L_Defaults_A
                <T1, T2, T3, T4>()
                {
                return (In, Default, Default2, Default3, Default4) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        Func<T2, bool> NullFunc2 = Obj.IsNull<T2>();
                        Func<T3, bool> NullFunc3 = Obj.IsNull<T3>();
                        Func<T4, bool> NullFunc4 = Obj.IsNull<T4>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o1))
                                    o1 = Default;
                                if (NullFunc2(o2))
                                    o2 = Default2;
                                if (NullFunc3(o3))
                                    o3 = Default3;
                                if (NullFunc4(o4))
                                    o4 = Default4;
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// If the arguments passed are null or empty, the Default values are used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Defaults", new[] { "In", "Default", "Default2" }, Comments.Defaults)]
            public static Func<Func<T1, T2, U>, T1, T2, Func<T1, T2, U>> L_Defaults_F<T1, T2, U>()
                {
                return (In, Default, Default2) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        Func<T2, bool> NullFunc2 = Obj.IsNull<T2>();
                        return (o1, o2) =>
                            {
                                if (NullFunc(o1))
                                    o1 = Default;
                                if (NullFunc2(o2))
                                    o2 = Default2;
                                return In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// If the arguments passed are null or empty, the Default values are used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Defaults", new[] { "In", "Default", "Default2", "Default3" }, Comments.Defaults)]
            public static Func<Func<T1, T2, T3, U>, T1, T2, T3, Func<T1, T2, T3, U>> L_Defaults_F<T1, T2, T3, U>()
                {
                return (In, Default, Default2, Default3) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        Func<T2, bool> NullFunc2 = Obj.IsNull<T2>();
                        Func<T3, bool> NullFunc3 = Obj.IsNull<T3>();
                        return (o1, o2, o3) =>
                            {
                                if (NullFunc(o1))
                                    o1 = Default;
                                if (NullFunc2(o2))
                                    o2 = Default2;
                                if (NullFunc3(o3))
                                    o3 = Default3;
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// If the arguments passed are null or empty, the Default values are used instead.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Defaults", new[] { "In", "Default", "Default2", "Default3", "Default4" },
                Comments.Defaults)]
            public static Func<Func<T1, T2, T3, T4, U>, T1, T2, T3, T4, Func<T1, T2, T3, T4, U>> L_Defaults_F
                <T1, T2, T3, T4, U>()
                {
                return (In, Default, Default2, Default3, Default4) =>
                    {
                        Func<T1, bool> NullFunc = Obj.IsNull<T1>();
                        Func<T2, bool> NullFunc2 = Obj.IsNull<T2>();
                        Func<T3, bool> NullFunc3 = Obj.IsNull<T3>();
                        Func<T4, bool> NullFunc4 = Obj.IsNull<T4>();
                        return (o1, o2, o3, o4) =>
                            {
                                if (NullFunc(o1))
                                    o1 = Default;
                                if (NullFunc2(o2))
                                    o2 = Default2;
                                if (NullFunc3(o3))
                                    o3 = Default3;
                                if (NullFunc4(o4))
                                    o4 = Default4;
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            #endregion

            #region Require

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Action<T1>, string, Action<T1>> L_Require_A<T1>()
                {
                return (In, ParameterName) =>
                    {
                        return o1 =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                In(o1);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Action<T1, T2>, string, Action<T1, T2>> L_Require_A<T1, T2>()
                {
                return (In, ParameterName) =>
                    {
                        return (o1, o2) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require2", new[] { "In", "ParameterName2 = null" }, Comments.Require2)]
            public static Func<Action<T1, T2>, string, Action<T1, T2>> L_Require2_A<T1, T2>()
                {
                return (In, ParameterName2) =>
                    {
                        return (o1, o2) =>
                            {
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Action<T1, T2, T3>, string, Action<T1, T2, T3>> L_Require_A<T1, T2, T3>()
                {
                return (In, ParameterName) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require2", new[] { "In", "ParameterName2 = null" }, Comments.Require2)]
            public static Func<Action<T1, T2, T3>, string, Action<T1, T2, T3>> L_Require2_A<T1, T2, T3>()
                {
                return (In, ParameterName2) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require3", new[] { "In", "ParameterName3 = null" }, Comments.Require3)]
            public static Func<Action<T1, T2, T3>, string, Action<T1, T2, T3>> L_Require3_A<T1, T2, T3>()
                {
                return (In, ParameterName3) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Action<T1, T2, T3, T4>, string, Action<T1, T2, T3, T4>> L_Require_A<T1, T2, T3, T4>()
                {
                return (In, ParameterName) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require2", new[] { "In", "ParameterName2 = null" }, Comments.Require2)]
            public static Func<Action<T1, T2, T3, T4>, string, Action<T1, T2, T3, T4>> L_Require2_A<T1, T2, T3, T4>()
                {
                return (In, ParameterName2) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require3", new[] { "In", "ParameterName3 = null" }, Comments.Require3)]
            public static Func<Action<T1, T2, T3, T4>, string, Action<T1, T2, T3, T4>> L_Require3_A<T1, T2, T3, T4>()
                {
                return (In, ParameterName3) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the fourth parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require4", new[] { "In", "ParameterName4 = null" }, Comments.Require4)]
            public static Func<Action<T1, T2, T3, T4>, string, Action<T1, T2, T3, T4>> L_Require4_A<T1, T2, T3, T4>()
                {
                return (In, ParameterName4) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o4 == null)
                                    throw new ArgumentNullException(ParameterName4 ?? $"Parameter 4 - {typeof(T4).Name}");
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Func<T1, U>, string, Func<T1, U>> L_Require_F<T1, U>()
                {
                return (In, ParameterName) =>
                    {
                        return o1 =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                return In(o1);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Func<T1, T2, U>, string, Func<T1, T2, U>> L_Require_F<T1, T2, U>()
                {
                return (In, ParameterName) =>
                    {
                        return (o1, o2) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                return In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require2", new[] { "In", "ParameterName2 = null" }, Comments.Require2)]
            public static Func<Func<T1, T2, U>, string, Func<T1, T2, U>> L_Require2_F<T1, T2, U>()
                {
                return (In, ParameterName2) =>
                    {
                        return (o1, o2) =>
                            {
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                return In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Func<T1, T2, T3, U>, string, Func<T1, T2, T3, U>> L_Require_F<T1, T2, T3, U>()
                {
                return (In, ParameterName) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require2", new[] { "In", "ParameterName2 = null" }, Comments.Require2)]
            public static Func<Func<T1, T2, T3, U>, string, Func<T1, T2, T3, U>> L_Require2_F<T1, T2, T3, U>()
                {
                return (In, ParameterName2) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require3", new[] { "In", "ParameterName3 = null" }, Comments.Require3)]
            public static Func<Func<T1, T2, T3, U>, string, Func<T1, T2, T3, U>> L_Require3_F<T1, T2, T3, U>()
                {
                return (In, ParameterName3) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require", new[] { "In", "ParameterName = null" }, Comments.Require)]
            public static Func<Func<T1, T2, T3, T4, U>, string, Func<T1, T2, T3, T4, U>> L_Require_F<T1, T2, T3, T4, U>()
                {
                return (In, ParameterName) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require2", new[] { "In", "ParameterName2 = null" }, Comments.Require2)]
            public static Func<Func<T1, T2, T3, T4, U>, string, Func<T1, T2, T3, T4, U>> L_Require2_F<T1, T2, T3, T4, U>
                ()
                {
                return (In, ParameterName2) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require3", new[] { "In", "ParameterName3 = null" }, Comments.Require3)]
            public static Func<Func<T1, T2, T3, T4, U>, string, Func<T1, T2, T3, T4, U>> L_Require3_F<T1, T2, T3, T4, U>
                ()
                {
                return (In, ParameterName3) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires the fourth parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Require4", new[] { "In", "ParameterName4 = null" }, Comments.Require4)]
            public static Func<Func<T1, T2, T3, T4, U>, string, Func<T1, T2, T3, T4, U>> L_Require4_F<T1, T2, T3, T4, U>
                ()
                {
                return (In, ParameterName4) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o4 == null)
                                    throw new ArgumentNullException(ParameterName4 ?? $"Parameter 4 - {typeof(T4).Name}");
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            #endregion

            #region RequireAll

            /// <summary>
            /// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RequireAll", new[] { "In", "ParameterName = null", "ParameterName2 = null" },
                Comments.RequireAll)]
            public static Func<Action<T1, T2>, string, string, Action<T1, T2>> L_RequireAll_A<T1, T2>()
                {
                return (In, ParameterName, ParameterName2) =>
                    {
                        return (o1, o2) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RequireAll",
                new[] { "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null" },
                Comments.RequireAll)]
            public static Func<Action<T1, T2, T3>, string, string, string, Action<T1, T2, T3>> L_RequireAll_A
                <T1, T2, T3>()
                {
                return (In, ParameterName, ParameterName2, ParameterName3) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RequireAll",
                new[]
                    {
                    "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null",
                    "ParameterName4 = null"
                    }, Comments.RequireAll)]
            public static Func<Action<T1, T2, T3, T4>, string, string, string, string, Action<T1, T2, T3, T4>>
                L_RequireAll_A<T1, T2, T3, T4>()
                {
                return (In, ParameterName, ParameterName2, ParameterName3, ParameterName4) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                if (o4 == null)
                                    throw new ArgumentNullException(ParameterName4 ?? $"Parameter 4 - {typeof(T4).Name}");
                                In(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RequireAll", new[] { "In", "ParameterName = null", "ParameterName2 = null" },
                Comments.RequireAll)]
            public static Func<Func<T1, T2, U>, string, string, Func<T1, T2, U>> L_RequireAll_F<T1, T2, U>()
                {
                return (In, ParameterName, ParameterName2) =>
                    {
                        return (o1, o2) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                return In(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RequireAll",
                new[] { "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null" },
                Comments.RequireAll)]
            public static Func<Func<T1, T2, T3, U>, string, string, string, Func<T1, T2, T3, U>> L_RequireAll_F
                <T1, T2, T3, U>()
                {
                return (In, ParameterName, ParameterName2, ParameterName3) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                return In(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("RequireAll",
                new[]
                    {
                    "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null",
                    "ParameterName4 = null"
                    }, Comments.RequireAll)]
            public static Func<Func<T1, T2, T3, T4, U>, string, string, string, string, Func<T1, T2, T3, T4, U>>
                L_RequireAll_F<T1, T2, T3, T4, U>()
                {
                return (In, ParameterName, ParameterName2, ParameterName3, ParameterName4) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                if (o1 == null)
                                    throw new ArgumentNullException(ParameterName ?? $"Parameter 1 - {typeof(T1).Name}");
                                if (o2 == null)
                                    throw new ArgumentNullException(ParameterName2 ?? $"Parameter 2 - {typeof(T2).Name}");
                                if (o3 == null)
                                    throw new ArgumentNullException(ParameterName3 ?? $"Parameter 3 - {typeof(T3).Name}");
                                if (o4 == null)
                                    throw new ArgumentNullException(ParameterName4 ?? $"Parameter 4 - {typeof(T4).Name}");
                                return In(o1, o2, o3, o4);
                            };
                    };
                }

            #endregion

            #region Yield

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Action<U>, Func<U, U>> L_Yield_A<U>()
                {
                return In =>
                    {
                        return o =>
                            {
                                In(o);
                                return o;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Action<U, T1>, Func<U, T1, U>> L_Yield_A<T1, U>()
                {
                return In =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return o1;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield2", new[] { "In" }, Comments.Yield2)]
            public static Func<Action<T1, U>, Func<T1, U, U>> L_Yield2_A<T1, U>()
                {
                return In =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return o2;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Action<U, T1, T2>, Func<U, T1, T2, U>> L_Yield_A<T1, T2, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return o1;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield2", new[] { "In" }, Comments.Yield2)]
            public static Func<Action<T1, U, T2>, Func<T1, U, T2, U>> L_Yield2_A<T1, T2, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return o2;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield3", new[] { "In" }, Comments.Yield3)]
            public static Func<Action<T1, T2, U>, Func<T1, T2, U, U>> L_Yield3_A<T1, T2, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return o3;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Action<U, T1, T2, T3>, Func<U, T1, T2, T3, U>> L_Yield_A<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o1;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield2", new[] { "In" }, Comments.Yield2)]
            public static Func<Action<T1, U, T2, T3>, Func<T1, U, T2, T3, U>> L_Yield2_A<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o2;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield3", new[] { "In" }, Comments.Yield3)]
            public static Func<Action<T1, T2, U, T3>, Func<T1, T2, U, T3, U>> L_Yield3_A<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o3;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the fourth parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield4", new[] { "In" }, Comments.Yield4)]
            public static Func<Action<T1, T2, T3, U>, Func<T1, T2, T3, U, U>> L_Yield4_A<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o4;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Func<U, U>, Func<U, U>> L_Yield_F<U>()
                {
                return In =>
                    {
                        return o =>
                            {
                                In(o);
                                return o;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Func<U, T1, U>, Func<U, T1, U>> L_Yield_F<T1, U>()
                {
                return In =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return o1;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield2", new[] { "In" }, Comments.Yield2)]
            public static Func<Func<T1, U, U>, Func<T1, U, U>> L_Yield2_F<T1, U>()
                {
                return In =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return o2;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Func<U, T1, T2, U>, Func<U, T1, T2, U>> L_Yield_F<T1, T2, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return o1;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield2", new[] { "In" }, Comments.Yield2)]
            public static Func<Func<T1, U, T2, U>, Func<T1, U, T2, U>> L_Yield2_F<T1, T2, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return o2;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield3", new[] { "In" }, Comments.Yield3)]
            public static Func<Func<T1, T2, U, U>, Func<T1, T2, U, U>> L_Yield3_F<T1, T2, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return o3;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield", new[] { "In" }, Comments.Yield)]
            public static Func<Func<U, T1, T2, T3, U>, Func<U, T1, T2, T3, U>> L_Yield_F<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o1;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield2", new[] { "In" }, Comments.Yield2)]
            public static Func<Func<T1, U, T2, T3, U>, Func<T1, U, T2, T3, U>> L_Yield2_F<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o2;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield3", new[] { "In" }, Comments.Yield3)]
            public static Func<Func<T1, T2, U, T3, U>, Func<T1, T2, U, T3, U>> L_Yield3_F<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o3;
                            };
                    };
                }

            /// <summary>
            /// Takes an Action and returns a Func that returns the fourth parameter after the action is performed.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Yield4", new[] { "In" }, Comments.Yield4)]
            public static Func<Func<T1, T2, T3, U, U>, Func<T1, T2, T3, U, U>> L_Yield4_F<T1, T2, T3, U>()
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return o4;
                            };
                    };
                }

            #endregion

            #region Execute

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Action>, Action> L_Execute_A()
                {
                return Act =>
                    {
                        return () =>
                            {
                                Act()();
                            };
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Action<T1>>, Action<T1>> L_Execute_A<T1>()
                {
                return Act =>
                    {
                        return o1 =>
                            {
                                Act()(o1);
                            };
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Action<T1, T2>>, Action<T1, T2>> L_Execute_A<T1, T2>()
                {
                return Act =>
                    {
                        return (o1, o2) =>
                            {
                                Act()(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Action<T1, T2, T3>>, Action<T1, T2, T3>> L_Execute_A<T1, T2, T3>()
                {
                return Act =>
                    {
                        return (o1, o2, o3) =>
                            {
                                Act()(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Action<T1, T2, T3, T4>>, Action<T1, T2, T3, T4>> L_Execute_A<T1, T2, T3, T4>()
                {
                return Act =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                Act()(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Func<U>>, Func<U>> L_Execute_F<U>()
                {
                return Act =>
                    {
                        return () => Act()();
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Func<T1, U>>, Func<T1, U>> L_Execute_F<T1, U>()
                {
                return Act =>
                    {
                        return o1 => Act()(o1);
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Func<T1, T2, U>>, Func<T1, T2, U>> L_Execute_F<T1, T2, U>()
                {
                return Act =>
                    {
                        return (o1, o2) => Act()(o1, o2);
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Func<T1, T2, T3, U>>, Func<T1, T2, T3, U>> L_Execute_F<T1, T2, T3, U>()
                {
                return Act =>
                    {
                        return (o1, o2, o3) => Act()(o1, o2, o3);
                    };
                }

            /// <summary>
            /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Execute", new[] { "Act" }, Comments.Execute)]
            public static Func<Func<Func<T1, T2, T3, T4, U>>, Func<T1, T2, T3, T4, U>> L_Execute_F<T1, T2, T3, T4, U>()
                {
                return Act =>
                    {
                        return (o1, o2, o3, o4) => Act()(o1, o2, o3, o4);
                    };
                }

            #endregion

            #region Cast

            /// <summary>
            /// Returns a function that takes a Casts the paramater of the Action to U1
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1>, Action<U1>> L_Cast_A<T1, U1>()
                where U1 : T1
                {
                return In =>
                    {
                        return o => { In(o); };
                    };
                }

            /// <summary>
            /// Returns a function that takes a Casts the paramaters of the Action to U1, U2
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2>, Action<U1, U2>> L_Cast_A<T1, T2, U1, U2>()
                where U1 : T1
                where U2 : T2
                {
                return In =>
                    {
                        return (o1, o2) => { In(o1, o2); };
                    };
                }

            /// <summary>
            /// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <typeparam name="U3"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2, T3>, Action<U1, U2, U3>> L_Cast_A<T1, T2, T3, U1, U2, U3>()
                where U1 : T1
                where U2 : T2
                where U3 : T3
                {
                return In =>
                    {
                        return (o1, o2, o3) => { In(o1, o2, o3); };
                    };
                }


            /// <summary>
            /// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3, U4
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <typeparam name="U3"></typeparam>
            /// <typeparam name="U4"></typeparam>
            /// <returns></returns>
            public static Func<Action<T1, T2, T3, T4>, Action<U1, U2, U3, U4>> L_Cast_A<T1, T2, T3, T4, U1, U2, U3, U4>()
                where U1 : T1
                where U2 : T2
                where U3 : T3
                where U4 : T4
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); };
                    };
                }

            /// <summary>
            /// Returns a function that Casts the output of the Func to U2
            /// </summary>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <returns></returns>

            public static Func<Func<U1>, Func<U2>> L_Cast_F<U1, U2>()
                {
                return In =>
                    {
                        return () => (U2)(object)In();
                    };
                }

            /// <summary>
            /// Returns a function that Casts the output of the Func to U2 and the input to T2
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, U1>, Func<T2, U2>> L_Cast_F<T1, U1, T2, U2>()
                where T2 : T1
                where U2 : U1
                {
                return In =>
                    {
                        return o1 => (U2)In(o1);
                    };
                }

            /// <summary>
            /// Returns a function that Casts the output of the Func to U2 and the inputs to T3, T4
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, T2, U1>, Func<T3, T4, U2>> L_Cast_F<T1, T2, U1, T3, T4, U2>()
                where T3 : T1
                where T4 : T2
                where U2 : U1
                {
                return In =>
                    {
                        return (o1, o2) => (U2)In(o1, o2);
                    };
                }

            /// <summary>
            /// Returns a function that Casts the output of the Func to U2 and the inputs to T4, T5, T6
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="T5"></typeparam>
            /// <typeparam name="T6"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, T2, T3, U1>, Func<T4, T5, T6, U2>> L_Cast_F<T1, T2, T3, U1, T4, T5, T6, U2>()
                where T4 : T1
                where T5 : T2
                where T6 : T3
                where U2 : U1
                {
                return In =>
                    {
                        return (o1, o2, o3) => (U2)In(o1, o2, o3);
                    };
                }

            /// <summary>
            /// Returns a function that Casts the output of the Func to U2 and the inputs to T7, T8, T9
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U1"></typeparam>
            /// <typeparam name="T5"></typeparam>
            /// <typeparam name="T6"></typeparam>
            /// <typeparam name="T7"></typeparam>
            /// <typeparam name="T8"></typeparam>
            /// <typeparam name="U2"></typeparam>
            /// <returns></returns>

            public static Func<Func<T1, T2, T3, T4, U1>, Func<T5, T6, T7, T8, U2>> L_Cast_F
                <T1, T2, T3, T4, U1, T5, T6, T7, T8, U2>()
                where T5 : T1
                where T6 : T2
                where T7 : T3
                where T8 : T4
                where U2 : U1
                {
                return In =>
                    {
                        return (o1, o2, o3, o4) => (U2)In(o1, o2, o3, o4);
                    };
                }

            #endregion

            #region Then

            /// <summary>
            /// Joins two methods together, performing one then another.
            /// </summary>

            [CodeExplodeExtensionMethod("Then", new[] { "Action1", "Action2" }, Comments.Then)]
            public static readonly Func<Action, Action, Action> Then = (Action1, Action2) =>
                    {
                        return () =>
                            {
                                Action1();
                                Action2();
                            };
                    };

            /// <summary>
            /// Joins multiple actions together, performing them in order.
            /// </summary>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action, Action[], Action> Then_A()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action => { In = Then(In, Action); });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple actions together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1>, Action<T1>[], Action<T1>> Then_A<T1>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = o =>
                                {
                                    In(o);
                                    Action(o);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1, T2>, Action<T1, T2>[], Action<T1, T2>> Then_A<T1, T2>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    Action(o1, o2);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple actions together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1, T2, T3>, Action<T1, T2, T3>[], Action<T1, T2, T3>> Then_A<T1, T2, T3>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    Action(o1, o2, o3);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>[], Action<T1, T2, T3, T4>> Then_A
                <T1, T2, T3, T4>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    Action(o1, o2, o3, o4);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action, Func<U>[], Func<U>> Then_A_F<U>()
                {
                return (In, Acts) => In.Return<U>().Then(Acts);
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1>, Func<T1, U>[], Func<T1, U>> Then_A_F<T1, U>()
                {
                return (In, Acts) => In.Return<T1, U>().Then(Acts);
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1, T2>, Func<T1, T2, U>[], Func<T1, T2, U>> Then_A_F<T1, T2, U>()
                {
                return (In, Acts) => In.Return<T1, T2, U>().Then(Acts);
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1, T2, T3>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, U>> Then_A_F<T1, T2, T3, U>
                ()
                {
                return (In, Acts) => In.Return<T1, T2, T3, U>().Then(Acts);
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, U>[], Func<T1, T2, T3, T4, U>> Then_A_F
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) => In.Return<T1, T2, T3, T4, U>().Then(Acts);
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<U>, Action[], Func<U>> Then_F<U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = () =>
                                {
                                    var Out = In();
                                    Action();
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, U>, Action<T1>[], Func<T1, U>> Then_F<T1, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = o1 =>
                                {
                                    var Out = In(o1);
                                    Action(o1);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, T2, U>, Action<T1, T2>[], Func<T1, T2, U>> Then_F<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    var Out = In(o1, o2);
                                    Action(o1, o2);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, T2, T3, U>, Action<T1, T2, T3>[], Func<T1, T2, T3, U>> Then_F<T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    var Out = In(o1, o2, o3);
                                    Action(o1, o2, o3);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2, T3, T4>[], Func<T1, T2, T3, T4, U>> Then_F
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    var Out = In(o1, o2, o3, o4);
                                    Action(o1, o2, o3, o4);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<U>, Func<U>[], Func<U>> L_Then_F_F<U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = () =>
                                {
                                    In();
                                    return Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, U>, Func<T1, U>[], Func<T1, U>> L_Then_F_F<T1, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, U> Out = In;
                        Acts.Each(Action =>
                            {
                                Out = o1 =>
                                {
                                    Out(o1);
                                    return Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, T2, U>, Func<T1, T2, U>[], Func<T1, T2, U>> L_Then_F_F<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    return Action(o1, o2);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, T2, T3, U>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, U>> L_Then_F_F<T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action(o1, o2, o3);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMultiple)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>[], Func<T1, T2, T3, T4, U>> L_Then_F_F
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1, o2, o3, o4);
                                };
                            });
                        return In;
                    };
                }

            #endregion

            #region Then - Missing

            #region Then - Missing - Action - Action

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1>, Action[], Action<T1>> L_ThenMissing_A<T1>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = o =>
                                {
                                    In(o);
                                    Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2>, Action<T1>[], Action<T1, T2>> L_ThenMissing_A<T1, T2>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2>, Action[], Action<T1, T2>> L_ThenMissing_A2<T1, T2>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3>, Action<T1, T2>[], Action<T1, T2, T3>> L_ThenMissing_A<T1, T2, T3>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    Action(o1, o2);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3>, Action<T1>[], Action<T1, T2, T3>> L_ThenMissing_A2<T1, T2, T3>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3>, Action[], Action<T1, T2, T3>> L_ThenMissing_A3<T1, T2, T3>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3>[], Action<T1, T2, T3, T4>> L_ThenMissing_A
                <T1, T2, T3, T4>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    Action(o1, o2, o3);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3, T4>, Action<T1, T2>[], Action<T1, T2, T3, T4>> L_ThenMissing_A2
                <T1, T2, T3, T4>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    Action(o1, o2);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3, T4>, Action<T1>[], Action<T1, T2, T3, T4>> L_ThenMissing_A3
                <T1, T2, T3, T4>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Action<T1, T2, T3, T4>, Action[], Action<T1, T2, T3, T4>> L_ThenMissing_A4
                <T1, T2, T3, T4>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    Action();
                                };
                            });
                        return In;
                    };
                }

            #endregion

            #region Then - Missing - Action - Func

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1>, Func<U>[], Func<T1, U>> L_ThenMissing_A_F<T1, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, U> Out = In.Return<T1, U>();
                        Acts.Each(Action =>
                            {
                                Out = o1 =>
                                {
                                    In(o1);
                                    return Action();
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2>, Func<T1, U>[], Func<T1, T2, U>> L_ThenMissing_A_F<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, U> Out = In.Return<T1, T2, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    return Action(o1);
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3>, Func<T1, T2, U>[], Func<T1, T2, T3, U>> L_ThenMissing_A_F
                <T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, U> Out = In.Return<T1, T2, T3, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action(o1, o2);
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2>, Func<U>[], Func<T1, T2, U>> L_ThenMissing_A_F2<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, U> Out = In.Return<T1, T2, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    return Action();
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3>, Func<U>[], Func<T1, T2, T3, U>> L_ThenMissing_A_F3<T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, U> Out = In.Return<T1, T2, T3, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action();
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3>, Func<T1, U>[], Func<T1, T2, T3, U>> L_ThenMissing_A_F2<T1, T2, T3, U>
                ()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, U> Out = In.Return<T1, T2, T3, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action(o1);
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1, o2, o3);
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F2
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1, o2);
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3, T4>, Func<T1, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F3
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1);
                                };
                            });
                        return Out;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Action<T1, T2, T3, T4>, Func<U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F4
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
                        Acts.Each(Action =>
                            {
                                Out = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action();
                                };
                            });
                        return Out;
                    };
                }

            #endregion

            #region Then - Missing - Func - Action

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, U>, Action[], Func<T1, U>> L_ThenMissing_F_A<T1, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = o =>
                                {
                                    var Out = In(o);
                                    Action();
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, U>, Action<T1>[], Func<T1, T2, U>> L_ThenMissing_F_A<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    var Out = In(o1, o2);
                                    Action(o1);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, U>, Action[], Func<T1, T2, U>> L_ThenMissing_F_A2<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    var Out = In(o1, o2);
                                    Action();
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, U>, Action<T1, T2>[], Func<T1, T2, T3, U>> L_ThenMissing_F_A
                <T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    var Out = In(o1, o2, o3);
                                    Action(o1, o2);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, U>, Action<T1>[], Func<T1, T2, T3, U>> L_ThenMissing_F_A2<T1, T2, T3, U>
                ()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    var Out = In(o1, o2, o3);
                                    Action(o1);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, U>, Action[], Func<T1, T2, T3, U>> L_ThenMissing_F_A3<T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    var Out = In(o1, o2, o3);
                                    Action();
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2, T3>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    var Out = In(o1, o2, o3, o4);
                                    Action(o1, o2, o3);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A2
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    var Out = In(o1, o2, o3, o4);
                                    Action(o1, o2);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, T4, U>, Action<T1>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A3
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    var Out = In(o1, o2, o3, o4);
                                    Action(o1);
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissing)]
            public static Func<Func<T1, T2, T3, T4, U>, Action[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A4
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    var Out = In(o1, o2, o3, o4);
                                    Action();
                                    return Out;
                                };
                            });
                        return In;
                    };
                }

            #endregion

            #region Then - Missing - Func - Func

            /// <summary>
            /// Returns a method that Success In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, U>, Func<U>[], Func<T1, U>> L_ThenMissing_F_F<T1, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = o =>
                                {
                                    In(o);
                                    return Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, U>, Func<T1, U>[], Func<T1, T2, U>> L_ThenMissing_F_F<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    return Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, U>, Func<U>[], Func<T1, T2, U>> L_ThenMissing_F_F2<T1, T2, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2) =>
                                {
                                    In(o1, o2);
                                    return Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, U>, Func<T1, U>[], Func<T1, T2, T3, U>> L_ThenMissing_F_F2
                <T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, U>, Func<U>[], Func<T1, T2, T3, U>> L_ThenMissing_F_F3<T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action();
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, U>, Func<T1, T2, U>[], Func<T1, T2, T3, U>> L_ThenMissing_F_F
                <T1, T2, T3, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3) =>
                                {
                                    In(o1, o2, o3);
                                    return Action(o1, o2);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, T4, U>>
                L_ThenMissing_F_F<T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1, o2, o3);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F2
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1, o2);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<T1, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F3
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action(o1);
                                };
                            });
                        return In;
                    };
                }

            /// <summary>
            /// Returns a method that concatenates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Then", new[] { "In", "params Acts" }, Comments.ThenMissingFunc)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F4
                <T1, T2, T3, T4, U>()
                {
                return (In, Acts) =>
                    {
                        Acts.Each(Action =>
                            {
                                In = (o1, o2, o3, o4) =>
                                {
                                    In(o1, o2, o3, o4);
                                    return Action();
                                };
                            });
                        return In;
                    };
                }

            #endregion

            #endregion

            #region Merge

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge, false, true)]
            [CodeExplodeGenerics("Merge", Comments.Merge)]
            public static Func<Action /*X2GA*/, Action /*GA*/ /*X2-TI*/, Action> L_Merge /*MA*/()
                {
                return (In, Merge) =>
                    {
                        return () =>
                            {
                                In( /*X2A*/);
                                Merge( /*A*/ /*X2-OI*/);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge, false, true)]
            [CodeExplodeGenerics("Merge", Comments.Merge)]
            public static Func<Action /*X2GA*/, Func /*GF*/<U> /*X2-TI*/, Func<U>> L_Merge_A_F /*MF*/<U>()
                {
                return (In, Merge) =>
                    {
                        return () =>
                            {
                                In( /*X2A*/);
                                return Merge( /*A*/ /*X2-OI*/);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Action, Func<U>> L_Merge_F_A<U>()
                {
                return (In, Merge) =>
                    {
                        return () =>
                            {
                                var Out = In();
                                Merge();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Action<T1>, Func<T1, U>> L_Merge_F_A1<T1, U>()
                {
                return (In, Merge) =>
                    {
                        return o =>
                            {
                                var Out = In();
                                Merge(o);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Action<T1, T2>, Func<T1, T2, U>> L_Merge_F_A2<T1, T2, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2) =>
                            {
                                var Out = In();
                                Merge(o1, o2);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Action<T1, T2, T3>, Func<T1, T2, T3, U>> L_Merge_F_A3<T1, T2, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                var Out = In();
                                Merge(o1, o2, o3);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, U>> L_Merge_F_A4<T1, T2, T3, T4, U>
                ()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                var Out = In();
                                Merge(o1, o2, o3, o4);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Action, Func<T1, U>> L_Merge_F1_A<T1, U>()
                {
                return (In, Merge) =>
                    {
                        return o1 =>
                            {
                                var Out = In(o1);
                                Merge();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Action<T2>, Func<T1, T2, U>> L_Merge_F1_A1<T1, T2, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2) =>
                            {
                                var Out = In(o1);
                                Merge(o2);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Action<T2, T3>, Func<T1, T2, T3, U>> L_Merge_F1_A2<T1, T2, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                var Out = In(o1);
                                Merge(o2, o3);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Action<T2, T3, T4>, Func<T1, T2, T3, T4, U>> L_Merge_F1_A3
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                var Out = In(o1);
                                Merge(o2, o3, o4);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, U>, Action, Func<T1, T2, U>> L_Merge_F2_A<T1, T2, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2) =>
                            {
                                var Out = In(o1, o2);
                                Merge();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, U>, Action<T3>, Func<T1, T2, T3, U>> L_Merge_F2_A1<T1, T2, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                var Out = In(o1, o2);
                                Merge(o3);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, U>, Action<T3, T4>, Func<T1, T2, T3, T4, U>> L_Merge_F2_A2
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                var Out = In(o1, o2);
                                Merge(o3, o4);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, T3, U>, Action, Func<T1, T2, T3, U>> L_Merge_F3_A<T1, T2, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                var Out = In(o1, o2, o3);
                                Merge();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, T3, U>, Action<T4>, Func<T1, T2, T3, T4, U>> L_Merge_F3_A1
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                var Out = In(o1, o2, o3);
                                Merge(o4);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, T3, T4, U>, Action, Func<T1, T2, T3, T4, U>> L_Merge_F3_A<T1, T2, T3, T4, U>
                ()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                var Out = In(o1, o2, o3, o4);
                                Merge();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Func<U>, Func<U>> L_Merge_F_F<U>()
                {
                return (In, Merge) =>
                    {
                        return () =>
                            {
                                In();
                                return Merge();
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Func<T1, U>, Func<T1, U>> L_Merge_F_F1<T1, U>()
                {
                return (In, Merge) =>
                    {
                        return o1 =>
                            {
                                In();
                                return Merge(o1);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Func<T1, T2, U>, Func<T1, T2, U>> L_Merge_F_F2<T1, T2, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2) =>
                            {
                                In();
                                return Merge(o1, o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Func<T1, T2, T3, U>, Func<T1, T2, T3, U>> L_Merge_F_F3<T1, T2, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In();
                                return Merge(o1, o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<U>, Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F_F4
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In();
                                return Merge(o1, o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Func<U>, Func<T1, U>> L_Merge_F1_F<T1, U>()
                {
                return (In, Merge) =>
                    {
                        return o1 =>
                            {
                                In(o1);
                                return Merge();
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Func<T3, U>, Func<T1, T3, U>> L_Merge_F1_F1<T1, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1);
                                return Merge(o2);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Func<T3, T4, U>, Func<T1, T3, T4, U>> L_Merge_F1_F2<T1, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1);
                                return Merge(o2, o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, U>, Func<T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F1_F3
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1);
                                return Merge(o2, o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, U>, Func<U>, Func<T1, T2, U>> L_Merge_F2_F<T1, T2, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2) =>
                            {
                                In(o1, o2);
                                return Merge();
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, U>, Func<T4, U>, Func<T1, T2, T4, U>> L_Merge_F2_F1<T1, T2, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2);
                                return Merge(o3);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, U>, Func<T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F2_F2
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2);
                                return Merge(o3, o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, T3, U>, Func<U>, Func<T1, T2, T3, U>> L_Merge_F3_F<T1, T2, T3, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                In(o1, o2, o3);
                                return Merge();
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, T3, U>, Func<T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F3_F1
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3);
                                return Merge(o4);
                            };
                    };
                }

            /// <summary>
            /// Returns a function that Performs In, then Merge. Parameter lists are merged.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Merge", new[] { "In", "Merge" }, Comments.Merge)]
            public static Func<Func<T1, T2, T3, T4, U>, Func<U>, Func<T1, T2, T3, T4, U>> L_Merge_F4_F
                <T1, T2, T3, T4, U>()
                {
                return (In, Merge) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                In(o1, o2, o3, o4);
                                return Merge();
                            };
                    };
                }

            #endregion

            #region Supply Action

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Action<T1>, T1, Action> L_Supply_A<T1>()
                {
                return (In, Obj) =>
                    {
                        return () => { In(Obj); };
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Action<T1, T2>, T1, Action<T2>> L_Supply_A<T1, T2>()
                {
                return (In, Obj) =>
                    {
                        return o => { In(Obj, o); };
                    };
                }

            /// <summary>
            /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply2", new[] { "In", "Obj" }, Comments.Supply_2)]
            public static Func<Action<T1, T2>, T2, Action<T1>> L_Supply_A2<T1, T2>()
                {
                return (In, Obj) =>
                    {
                        return o => { In(o, Obj); };
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Action<T1, T2, T3>, T1, Action<T2, T3>> L_Supply_A<T1, T2, T3>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) => { In(Obj, o1, o2); };
                    };
                }

            /// <summary>
            /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply2", new[] { "In", "Obj" }, Comments.Supply_2)]
            public static Func<Action<T1, T2, T3>, T2, Action<T1, T3>> L_Supply_A2<T1, T2, T3>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) => { In(o1, Obj, o2); };
                    };
                }

            /// <summary>
            /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply3", new[] { "In", "Obj" }, Comments.Supply_3)]
            public static Func<Action<T1, T2, T3>, T3, Action<T1, T2>> L_Supply_A3<T1, T2, T3>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) => { In(o1, o2, Obj); };
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Action<T1, T2, T3, T4>, T1, Action<T2, T3, T4>> L_Supply_A<T1, T2, T3, T4>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => { In(Obj, o1, o2, o3); };
                    };
                }

            /// <summary>
            /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply2", new[] { "In", "Obj" }, Comments.Supply_2)]
            public static Func<Action<T1, T2, T3, T4>, T2, Action<T1, T3, T4>> L_Supply_A2<T1, T2, T3, T4>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => { In(o1, Obj, o2, o3); };
                    };
                }

            /// <summary>
            /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply3", new[] { "In", "Obj" }, Comments.Supply_3)]
            public static Func<Action<T1, T2, T3, T4>, T3, Action<T1, T2, T4>> L_Supply_A3<T1, T2, T3, T4>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => { In(o1, o2, Obj, o3); };
                    };
                }

            /// <summary>
            /// Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply4", new[] { "In", "Obj" }, Comments.Supply_4)]
            public static Func<Action<T1, T2, T3, T4>, T4, Action<T1, T2, T3>> L_Supply_A4<T1, T2, T3, T4>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => { In(o1, o2, o3, Obj); };
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Func<T1, U>, T1, Func<U>> L_Supply_F<T1, U>()
                {
                return (In, Obj) =>
                    {
                        return () => In(Obj);
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Func<T1, T2, U>, T1, Func<T2, U>> L_Supply_F<T1, T2, U>()
                {
                return (In, Obj) =>
                    {
                        return o => In(Obj, o);
                    };
                }

            /// <summary>
            /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply2", new[] { "In", "Obj" }, Comments.Supply_2)]
            public static Func<Func<T1, T2, U>, T2, Func<T1, U>> L_Supply_F2<T1, T2, U>()
                {
                return (In, Obj) =>
                    {
                        return o => In(o, Obj);
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Func<T1, T2, T3, U>, T1, Func<T2, T3, U>> L_Supply_F<T1, T2, T3, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) => In(Obj, o1, o2);
                    };
                }

            /// <summary>
            /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply2", new[] { "In", "Obj" }, Comments.Supply_2)]
            public static Func<Func<T1, T2, T3, U>, T2, Func<T1, T3, U>> L_Supply_F2<T1, T2, T3, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) => In(o1, Obj, o2);
                    };
                }

            /// <summary>
            /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply3", new[] { "In", "Obj" }, Comments.Supply_3)]
            public static Func<Func<T1, T2, T3, U>, T3, Func<T1, T2, U>> L_Supply_F3<T1, T2, T3, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2) => In(o1, o2, Obj);
                    };
                }

            /// <summary>
            /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply", new[] { "In", "Obj" }, Comments.Supply)]
            public static Func<Func<T1, T2, T3, T4, U>, T1, Func<T2, T3, T4, U>> L_Supply_F<T1, T2, T3, T4, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => In(Obj, o1, o2, o3);
                    };
                }

            /// <summary>
            /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply2", new[] { "In", "Obj" }, Comments.Supply_2)]
            public static Func<Func<T1, T2, T3, T4, U>, T2, Func<T1, T3, T4, U>> L_Supply_F2<T1, T2, T3, T4, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => In(o1, Obj, o2, o3);
                    };
                }

            /// <summary>
            /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply3", new[] { "In", "Obj" }, Comments.Supply_3)]
            public static Func<Func<T1, T2, T3, T4, U>, T3, Func<T1, T2, T4, U>> L_Supply_F3<T1, T2, T3, T4, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => In(o1, o2, Obj, o3);
                    };
                }

            /// <summary>
            /// Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Supply4", new[] { "In", "Obj" }, Comments.Supply_4)]
            public static Func<Func<T1, T2, T3, T4, U>, T4, Func<T1, T2, T3, U>> L_Supply_F4<T1, T2, T3, T4, U>()
                {
                return (In, Obj) =>
                    {
                        return (o1, o2, o3) => In(o1, o2, o3, Obj);
                    };
                }

            #endregion

            #region Action

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1> Action<T1>()
                {
                return o1 => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>
            public static Action<T1, T2> Action<T1, T2>()
                {
                return (o1, o2) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>
            public static Action<T1, T2, T3> Action<T1, T2, T3>()
                {
                return (o1, o2, o3) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4> Action<T1, T2, T3, T4>()
                {
                return (o1, o2, o3, o4) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5> Action<T1, T2, T3, T4, T5>()
                {
                return (o1, o2, o3, o4, o5) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6> Action<T1, T2, T3, T4, T5, T6>()
                {
                return (o1, o2, o3, o4, o5, o6) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7> Action<T1, T2, T3, T4, T5, T6, T7>()
                {
                return (o1, o2, o3, o4, o5, o6, o7) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Action<T1, T2, T3, T4, T5, T6, T7, T8>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { };
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { };
                }

            #endregion

            #region Do

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            public static Func<U> Do<U>()
                {
                return () => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            public static Func<T1, U> Do<T1, U>()
                {
                return o1 => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            public static Func<T1, T2, U> Do<T1, T2, U>()
                {
                return (o1, o2) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            public static Func<T1, T2, T3, U> Do<T1, T2, T3, U>()
                {
                return (o1, o2, o3) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, U> Do<T1, T2, T3, T4, U>()
                {
                return (o1, o2, o3, o4) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, U> Do<T1, T2, T3, T4, T5, U>()
                {
                return (o1, o2, o3, o4, o5) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, U> Do<T1, T2, T3, T4, T5, T6, U>()
                {
                return (o1, o2, o3, o4, o5, o6) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, U> Do<T1, T2, T3, T4, T5, T6, T7, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Do<T1, T2, T3, T4, T5, T6, T7, T8, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => default(U);
                }

            /// <summary>
            /// Creates an empty method using the specified Type Arguments.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Do
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
                {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => default(U);
                }

            #region Action

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action Action(Action In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1> Action<T1>(Action<T1> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2> Action<T1, T2>(Action<T1, T2> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3> Action<T1, T2, T3>(Action<T1, T2, T3> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4> Action<T1, T2, T3, T4>(Action<T1, T2, T3, T4> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5> Action<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6> Action<T1, T2, T3, T4, T5, T6>(
                Action<T1, T2, T3, T4, T5, T6> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7> Action<T1, T2, T3, T4, T5, T6, T7>(
                Action<T1, T2, T3, T4, T5, T6, T7> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Action<T1, T2, T3, T4, T5, T6, T7, T8>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Action
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
                {
                return In;
                }

            #endregion

            #endregion

            #region Function

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<U> Function<U>(Func<U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, U> Function<T1, U>(Func<T1, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, U> Function<T1, T2, U>(Func<T1, T2, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, U> Function<T1, T2, T3, U>(Func<T1, T2, T3, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, U> Function<T1, T2, T3, T4, U>(Func<T1, T2, T3, T4, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, U> Function<T1, T2, T3, T4, T5, U>(Func<T1, T2, T3, T4, T5, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, U> Function<T1, T2, T3, T4, T5, T6, U>(
                Func<T1, T2, T3, T4, T5, T6, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, U> Function<T1, T2, T3, T4, T5, T6, T7, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Function<T1, T2, T3, T4, T5, T6, T7, T8, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Function<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
                {
                return In;
                }

            /// <summary>
            /// Returns a method from a static or instance reference
            /// </summary>
            public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Function
                <T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
                {
                return In;
                }

            #region Return

            /// <summary>
            /// Returns a function that returns an empty object of Type U
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            public static Func<U> Return<U>()
                {
                return Do<U>();
                }

            /// <summary>
            /// Returns a function that returns the supplied Object
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <param name="In"></param>
            /// <returns></returns>
            public static Func<U> Return<U>(U In)
                {
                return () => In;
                }

            #endregion

            #endregion

            #region Pass

            /// <summary>
            /// Returns a function that takes a Typed value and returns it, performing no action.
            /// </summary>
            /// <returns></returns>
            public static Func<T1, T1> Pass<T1>()
                {
                return o => o;
                }

            #endregion

            // Do
            //[CodeExplodeExtensionMethod("Cast", new String[] { "In" }, L.Comments.Cast)]
            /*        public static Func<Action<T1>,[CanBeNull] Action<U1>> L_Cast<T1, U1>()
                        where U1 : T1
                        {
                        return In => L_Cast_A<T1, U1>()(In);
                        }*/



            // Refactor

            /*

                    #region Failover
                    public static Action Failover<T>(this Action<T> In, IEnumerable<T> Tries)
                        {
                        return () =>
                            {
                                List<Exception> Errors = new List<Exception>();

                                bool Success = Tries.While(t =>
                                    {
                                        try
                                            {
                                            In(t);
                                            return false;
                                            }
                                        catch (Exception e)
                                            {
                                            Errors.Add(e);
                                            return true;
                                            }
                                    });

                                if (!Success && !Errors.IsEmpty())
                                    {
                                    throw new ExceptionList(Errors);
                                    }
                            };
                        }
                    public static Func<U> Failover<T, U>([CanBeNull]this Func<T, U> In, IEnumerable<T> Tries)
                        {
                        return () =>
                        {
                            List<Exception> Errors = new List<Exception>();
                            U Out = default(U);

                            Tries.While(t =>
                            {
                                try
                                    {
                                    Out = In(t);
                                    return false;
                                    }
                                catch
                                    {
                                    return true;
                                    }
                            });

                            if (Out == null && !Errors.IsEmpty())
                                {
                                throw new ExceptionList(Errors);
                                }

                            return Out;
                        };
                        }
                    #endregion
            */

            #endregion

            internal static class Comments
                {
                #region Comments +
                public const string Return = "Returns a function that converts an action to a Func, returning the specified value.";
                public const string ReturnFunc = "Returns a function that Overrides the return value of In with the specified value.";
                public const string Rotate = "Returns a function that rotates the list of parameters to the right.";
                public const string RotateBack = "Returns a function that rotates the list of parameters to the left.";
                public const string Default = "If the first argument passed is null or empty, the Default value is used instead.";
                public const string Default2 = "If the second argument passed is null or empty, the Default value is used instead.";
                public const string Default3 = "If the third argument passed is null or empty, the Default value is used instead.";
                public const string Default4 = "If the fourth argument passed is null or empty, the Default value is used instead.";
                public const string Defaults = "If the arguments passed are null or empty, the Default values are used instead.";
                public const string Require = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
                public const string Require2 = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
                public const string Require3 = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
                public const string Require4 = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
                public const string RequireAll = "Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.";
                public const string Do = "Returns an Action from the supplied Func. The return value is discarded.";
                public const string Cache = "Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.";
                public const string Yield = "Takes an Action and returns a Func that returns the first parameter after the action is performed.";
                public const string Yield2 = "Takes an Action and returns a Func that returns the second parameter after the action is performed.";
                public const string Yield3 = "Takes an Action and returns a Func that returns the third parameter after the action is performed.";
                public const string Yield4 = "Takes an Action and returns a Func that returns the fourth parameter after the action is performed.";
                public const string Execute = "For a method Act that returns a method, Returns a method that executes the Method passed and its result.";
                public const string ExecuteMerge = "For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.";
                public const string Then = "Joins two methods together, performing one then another.";
                public const string ThenMultiple = "Joins multiple actions together, performing them in order.";
                public const string ThenMissing = "Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.";
                public const string ThenMissingFunc = "Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.";
                public const string Merge = "Returns a function that Performs In, then Merge. Parameter lists are merged.";
                // ReSharper disable InconsistentNaming
                public const string Supply = "Returns a method with the first parameter removed. When the method is called, Obj will be supplied.";
                public const string Supply_2 = "Returns a method with the second parameter removed. When the method is called, Obj will be supplied.";
                public const string Supply_3 = "Returns a method with the third parameter removed. When the method is called, Obj will be supplied.";
                public const string Supply_4 = "Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.";
                public const string Supply2 = "Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.";
                public const string Supply2_2 = "Returns a method with the second two parameters removed. When the method is called, Obj and Obj2 will be supplied.";
                public const string Supply2_3 = "Returns a method with the third two parameters removed. When the method is called, Obj and Obj2 will be supplied.";
                public const string Supply3 = "Returns a method with the first three parameters removed. When the method is called, Obj and Obj2 will be supplied.";
                public const string Supply3_2 = "Returns a method with the second three parameters removed. When the method is called, Obj and Obj2 will be supplied.";
                public const string Supply4 = "Returns a method with the first four parameters removed. When the method is called, Obj and Obj2 will be supplied.";
                // ReSharper restore InconsistentNaming
                public const string Cast = "Returns a function that takes a Casts the paramater of the Action to U1";
                public const string Set = "Returns a function that sets (overrides) the first parameter in Func with In";
                public const string Set2 = "Returns a function that sets (overrides) the second parameter in Func with In";
                public const string Set3 = "Returns a function that sets (overrides) the third parameter in Func with In";
                public const string Set4 = "Returns a function that sets (overrides) the fourth parameter in Func with In";
                public const string SetFunc = "Returns a function that sets (overrides) the first parameter in Func with the result of In";
                #endregion
                }
            }
        }
    }