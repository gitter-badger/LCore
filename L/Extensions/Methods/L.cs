using System;
using System.Collections.Generic;
using LCore.Dynamic;
using LCore.Interfaces;

// ReSharper disable UnusedMember.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// L provides a shorthand to common functions and method manipulation functions.
    /// </summary>
    [ExtensionProvider]
    [CodeExplodeExtend("Method Extensions", "Logic_Extension", "LCore.Extensions")]
    [CodeExplodeLogic("Method Explosions", "LX", "LCore", new[] { typeof(bool) })]
    public static partial class L
        {

        /// <summary>
        /// Empty method. Takes no parameters and performs no actions.
        /// </summary>
        public static readonly Action Empty = () => { };
        /// <summary>
        /// Empty method. Takes no parameters and performs no actions.
        /// Alias of L.Empty
        /// </summary>
        public static readonly Action E = Empty;


        internal static Type[] LUsedGenericOutputTypes = { typeof(bool) };

        #region Method Creators - Shorthand
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Action A()
            {
            return E;
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Action<T1> A<T1>()
            {
            return Logic.Action<T1>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Action<T1, T2> A<T1, T2>()
            {
            return Logic.Action<T1, T2>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Action<T1, T2, T3> A<T1, T2, T3>()
            {
            return Logic.Action<T1, T2, T3>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4> A<T1, T2, T3, T4>()
            {
            return Logic.Action<T1, T2, T3, T4>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5> A<T1, T2, T3, T4, T5>()
            {
            return Logic.Action<T1, T2, T3, T4, T5>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6> A<T1, T2, T3, T4, T5, T6>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7> A<T1, T2, T3, T4, T5, T6, T7>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> A<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> A<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
            }
        /// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return Logic.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
            }


        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        public static Func<U> F<U>()
            {
            return Logic.Do<U>();
            }

        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        public static Func<T1, U> F<T1, U>()
            {
            return Logic.Do<T1, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        public static Func<T1, T2, U> F<T1, T2, U>()
            {
            return Logic.Do<T1, T2, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <returns></returns>
        public static Func<T1, T2, T3, U> F<T1, T2, T3, U>()
            {
            return Logic.Do<T1, T2, T3, U>();
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
        public static Func<T1, T2, T3, T4, U> F<T1, T2, T3, T4, U>()
            {
            return Logic.Do<T1, T2, T3, T4, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, U> F<T1, T2, T3, T4, T5, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, U> F<T1, T2, T3, T4, T5, T6, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> F<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> F<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>();
            }
        /// <summary>
        /// Creates an empty method using the specified Type Arguments.
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return Logic.Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>();
            }

        #endregion

        #region Method Retrievers - Shorthand
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Action A(Action In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Action<T1> A<T1>(Action<T1> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Action<T1, T2> A<T1, T2>(Action<T1, T2> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Action<T1, T2, T3> A<T1, T2, T3>(Action<T1, T2, T3> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4> A<T1, T2, T3, T4>(Action<T1, T2, T3, T4> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5> A<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6> A<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7> A<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> A<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> A<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In)
            {
            return Logic.Action(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> A<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In)
            {
            return Logic.Action(In);
            }

        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Func<U> F<U>(Func<U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Func<T1, U> F<T1, U>(Func<T1, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Func<T1, T2, U> F<T1, T2, U>(Func<T1, T2, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <returns></returns>
        public static Func<T1, T2, T3, U> F<T1, T2, T3, U>(Func<T1, T2, T3, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, U> F<T1, T2, T3, T4, U>(Func<T1, T2, T3, T4, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, U> F<T1, T2, T3, T4, T5, U>(Func<T1, T2, T3, T4, T5, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, U> F<T1, T2, T3, T4, T5, T6, U>(Func<T1, T2, T3, T4, T5, T6, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> F<T1, T2, T3, T4, T5, T6, T7, U>(Func<T1, T2, T3, T4, T5, T6, T7, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> F<T1, T2, T3, T4, T5, T6, T7, T8, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
            {
            return Logic.Function(In);
            }
        /// <summary>
        /// Returns a method from a static or instance reference
        /// </summary>
        /// <returns></returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
            {
            return Logic.Function(In);
            }
        #endregion

        /// <summary>
        /// Contains strings and data for unit test purposes.
        /// </summary>
        public static class Test
            {
            /// <summary>
            /// Unit test categories
            /// </summary>
            public static class Categories
                {
                /// <summary>
                /// Attribute test category name
                /// </summary>
                public const string AttributeTests = nameof(AttributeTests);
                /// <summary>
                /// Tools test category name
                /// </summary>
                public const string Tools = nameof(Tools);
                /// <summary>
                /// Unit Tests category name
                /// </summary>
                public const string UnitTests = nameof(UnitTests);
                /// <summary>
                /// Internal category name
                /// </summary>
                public const string Internal = nameof(Internal);
                /// <summary>
                /// NullabilityTests category name
                /// </summary>
                public const string NullabilityTests = nameof(NullabilityTests);


                }
            }
        }
    }