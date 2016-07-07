using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
using System.Reflection;
using LCore.Extensions.Optional;

// ReSharper disable UnusedMember.Global

namespace LCore.Tests
    {
    /// <summary>
    /// Provides extensions to allow for method unit testing.
    /// </summary>
    public static class TestExt
        {
        #region ShouldSucceed
        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodShouldSucceed(this MethodInfo Method, object[] Params = null)
            {
            Method.MethodShouldSucceed<object>(Params, (Func<object, bool>[])null);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodShouldSucceed(this MethodInfo Method, object[] Params = null, params Func<bool>[] AdditionalChecks)
            {
            Method.MethodShouldSucceed<object>(Params, AdditionalChecks.Convert<Func<bool>, Func<object, bool>>(f => { return (o => f()); }));
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodShouldSucceed(this MethodInfo Method, object[] Params = null, params Func<object, bool>[] AdditionalChecks)
            {
            Method.MethodShouldSucceed<object>(Params, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodShouldSucceed<U>(this MethodInfo Method, object[] Params = null, params Func<U, bool>[] AdditionalResultChecks)
            {
            Method.MethodAssertSucceedes(Params, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed(this Action Act)
            {
            Act.Method.MethodShouldSucceed();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Method.MethodShouldSucceed(new object[] { o1 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Method.MethodShouldSucceed(new object[] { o1, o2 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Method.MethodShouldSucceed(new object[] { o1, o2, o3 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Method.MethodShouldSucceed(new object[] { o1, o2, o3, o4 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<U>(this Func<U> Func, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, U>(this Func<T1, U> Func, T1 o1, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1, o2 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1, o2, o3 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1, o2, o3, o4 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<U>(this Func<U> Func, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, U>(this Func<T1, U> Func, T1 o1, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1 }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1, o2 }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1, o2, o3 }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void ShouldSucceed<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldSucceed(new object[] { o1, o2, o3, o4 }, AdditionalResultChecks);
            }
        #endregion

        #region ShouldFail
        /// <summary>
        /// Assert that a metod fails with a particular type of exception [E].
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        public static void MethodShouldFail<E>(this MethodInfo Method, object[] Params, object Target, params Func<bool>[] AdditionalChecks) where E : Exception
            {
            Method.MethodShouldFail(Params, Target, typeof(E), AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod fails with a particular type of exception [EType].
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        public static void MethodShouldFail(this MethodInfo Method, object[] Params, object Target, Type EType = null, params Func<bool>[] AdditionalChecks)
            {
            Method.MethodAssertFails(Params, Target, EType, AdditionalChecks);
            }


        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail(this Action Act)
            {
            Act.Method.MethodShouldFail(new object[] { }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Method.MethodShouldFail(new object[] { o1 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Method.MethodShouldFail(new object[] { o1, o2 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Method.MethodShouldFail(new object[] { o1, o2, o3 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Method.MethodShouldFail(new object[] { o1, o2, o3, o4 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<E>(this Action Act) where E : Exception
            {
            Act.Method.MethodShouldFail<E>(new object[] { }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, E>(this Action<T1> Act, T1 o1) where E : Exception
            {
            Act.Method.MethodShouldFail<E>(new object[] { o1 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, E>(this Action<T1, T2> Act, T1 o1, T2 o2) where E : Exception
            {
            Act.Method.MethodShouldFail<E>(new object[] { o1, o2 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, E>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Act.Method.MethodShouldFail<E>(new object[] { o1, o2, o3 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
            {
            Act.Method.MethodShouldFail<E>(new object[] { o1, o2, o3, o4 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<U>(this Func<U> Func)
            {
            Func.Method.MethodShouldFail(new object[] { }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, U>(this Func<T1, U> Func, T1 o1)
            {
            Func.Method.MethodShouldFail(new object[] { o1 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
            {
            Func.Method.MethodShouldFail(new object[] { o1, o2 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
            {
            Func.Method.MethodShouldFail(new object[] { o1, o2, o3 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Func.Method.MethodShouldFail(new object[] { o1, o2, o3, o4 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<U, E>(this Func<U> Func) where E : Exception
            {
            Func.Method.MethodShouldFail<E>(new object[] { }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, U, E>(this Func<T1, U> Func, T1 o1) where E : Exception
            {
            Func.Method.MethodShouldFail<E>(new object[] { o1 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, U, E>(this Func<T1, T2, U> Func, T1 o1, T2 o2) where E : Exception
            {
            Func.Method.MethodShouldFail<E>(new object[] { o1, o2 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Func.Method.MethodShouldFail<E>(new object[] { o1, o2, o3 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void ShouldFail<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
            {
            Func.Method.MethodShouldFail<E>(new object[] { o1, o2, o3, o4 }, Func.Target);
            }
        #endregion

        #region ShouldBe
        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void MethodShouldBe(this MethodInfo Method, object[] Params = null, object ExpectedResult = null, params Func<object, bool>[] AdditionalResultChecks)
            {
            Method.MethodShouldBe<object>(Params, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void MethodShouldBe<U>(this MethodInfo Method, object[] Params = null, U ExpectedResult = default(U), params Func<object, bool>[] AdditionalResultChecks)
            {
            Method.MethodAssertResult(Params, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void ShouldBe<U>(this Func<U> Func, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldBe(new object[] { }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void ShouldBe<T1, U>(this Func<T1, U> Func, T1 o1, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldBe(new object[] { o1 }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void ShouldBe<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldBe(new object[] { o1, o2 }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void ShouldBe<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldBe(new object[] { o1, o2, o3 }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void ShouldBe<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodShouldBe(new object[] { o1, o2, o3, o4 }, ExpectedResult, AdditionalResultChecks);
            }
        #endregion


        #region AssertSucceedes
        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodAssertSucceedes(this MethodInfo Method, object[] Params = null)
            {
            Method.MethodAssertSucceedes<object>(Params, (Func<object, bool>[])null);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodAssertSucceedes(this MethodInfo Method, object[] Params = null, params Func<bool>[] AdditionalChecks)
            {
            Method.MethodAssertSucceedes<object>(Params, AdditionalChecks.Convert<Func<bool>, Func<object, bool>>(f => { return (o => f()); }));
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodAssertSucceedes(this MethodInfo Method, object[] Params = null, params Func<object, bool>[] AdditionalChecks)
            {
            Method.MethodAssertSucceedes<object>(Params, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void MethodAssertSucceedes<U>(this MethodInfo Method, object[] Params = null, params Func<U, bool>[] AdditionalResultChecks)
            {
            Params = Params ?? new object[] { };
            var Result = (U)Method.Invoke(null, Params);

            AdditionalResultChecks.Each(check =>
            {
                if (!check(Result))
                    throw new Exception($"Result did not pass additional checks.{Result.ToS()}");
            });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes(this Action Act)
            {
            Act.Method.MethodAssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Method.MethodAssertSucceedes(new object[] { o1 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Method.MethodAssertSucceedes(new object[] { o1, o2 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Method.MethodAssertSucceedes(new object[] { o1, o2, o3 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Method.MethodAssertSucceedes(new object[] { o1, o2, o3, o4 });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<U>(this Func<U> Func, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, U>(this Func<T1, U> Func, T1 o1, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1, o2 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1, o2, o3 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, params Func<bool>[] AdditionalChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1, o2, o3, o4 }, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<U>(this Func<U> Func, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, U>(this Func<T1, U> Func, T1 o1, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1 }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1, o2 }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1, o2, o3 }, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        public static void AssertSucceedes<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, params Func<U, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertSucceedes(new object[] { o1, o2, o3, o4 }, AdditionalResultChecks);
            }
        #endregion

        #region AssertFails
        /// <summary>
        /// Assert that a metod fails with a particular type of exception [E].
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        public static void MethodAssertFails<E>(this MethodInfo Method, object[] Params, object Target, params Func<bool>[] AdditionalChecks) where E : Exception
            {
            Method.MethodAssertFails(Params, Target, typeof(E), AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod fails with a particular type of exception [EType].
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        public static void MethodAssertFails(this MethodInfo Method, object[] Params, object Target, Type EType = null, params Func<bool>[] AdditionalChecks)
            {
            EType = EType ?? typeof(Exception);

            try
                {
                Params = Params ?? new object[] { };
                Method.Invoke(Target, Params);
                }
            catch (TargetInvocationException e)
                {
                if (!e.InnerException.GetType().IsType(EType))
                    throw new Exception(
                        $"Exception type {EType.FullName} did not throw.\n{e.InnerException.GetType().FullName} was thrown instead.");
                return;
                }
            catch (Exception e)
                {
                if (e.IsType(EType))
                    return;

                throw new Exception(
                    $"Exception type {EType.FullName} did not throw.\n{e.GetType().FullName} was thrown instead.");
                }

            AdditionalChecks.Each((i, check) =>
            {
                if (!check())
                    throw new Exception($"Method did not pass additional check #{i + 1}.");
            });

            throw new Exception($"Exception type {EType.FullName} did not throw.");
            }


        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails(this Action Act)
            {
            Act.Method.MethodAssertFails(new object[] { }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Method.MethodAssertFails(new object[] { o1 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Method.MethodAssertFails(new object[] { o1, o2 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Method.MethodAssertFails(new object[] { o1, o2, o3 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Method.MethodAssertFails(new object[] { o1, o2, o3, o4 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<E>(this Action Act) where E : Exception
            {
            Act.Method.MethodAssertFails<E>(new object[] { }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, E>(this Action<T1> Act, T1 o1) where E : Exception
            {
            Act.Method.MethodAssertFails<E>(new object[] { o1 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, E>(this Action<T1, T2> Act, T1 o1, T2 o2) where E : Exception
            {
            Act.Method.MethodAssertFails<E>(new object[] { o1, o2 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, E>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Act.Method.MethodAssertFails<E>(new object[] { o1, o2, o3 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
            {
            Act.Method.MethodAssertFails<E>(new object[] { o1, o2, o3, o4 }, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<U>(this Func<U> Func)
            {
            Func.Method.MethodAssertFails(new object[] { }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, U>(this Func<T1, U> Func, T1 o1)
            {
            Func.Method.MethodAssertFails(new object[] { o1 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
            {
            Func.Method.MethodAssertFails(new object[] { o1, o2 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
            {
            Func.Method.MethodAssertFails(new object[] { o1, o2, o3 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Func.Method.MethodAssertFails(new object[] { o1, o2, o3, o4 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<U, E>(this Func<U> Func) where E : Exception
            {
            Func.Method.MethodAssertFails<E>(new object[] { }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, U, E>(this Func<T1, U> Func, T1 o1) where E : Exception
            {
            Func.Method.MethodAssertFails<E>(new object[] { o1 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, U, E>(this Func<T1, T2, U> Func, T1 o1, T2 o2) where E : Exception
            {
            Func.Method.MethodAssertFails<E>(new object[] { o1, o2 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Func.Method.MethodAssertFails<E>(new object[] { o1, o2, o3 }, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        public static void AssertFails<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
            {
            Func.Method.MethodAssertFails<E>(new object[] { o1, o2, o3, o4 }, Func.Target);
            }
        #endregion

        #region AssertResult
        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void MethodAssertResult(this MethodInfo Method, object[] Params = null, object ExpectedResult = null, params Func<object, bool>[] AdditionalResultChecks)
            {
            Method.MethodAssertResult<object>(Params, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void MethodAssertResult<U>(this MethodInfo Method, object[] Params = null, U ExpectedResult = default(U), params Func<object, bool>[] AdditionalResultChecks)
            {
            Params = Params ?? new object[] { };

            Exception Error = null;
            var Actual = default(U);
            try
                {
                Actual = (U)Method.Invoke(null, Params);
                }
            catch (Exception e)
                {
                Error = e;
                }

            bool Passed;
            var result = ExpectedResult as IEnumerable;
            if (result != null && Actual is IEnumerable)
                {
                Passed = result.Equivalent((IEnumerable)Actual);
                if (!Passed)
                    {
                    }
                }
            else if (ExpectedResult is IComparable && Actual is IComparable)
                {
                Passed = ((IComparable)ExpectedResult).CompareTo((IComparable)Actual) == 0;
                if (!Passed)
                    {
                    }
                }
            else if (Error != null && !(ExpectedResult is Exception))
                {
                Passed = false;
                }
            else
                {
                string Details1 = ExpectedResult.Details();

                string Details2 = Error == null ? Actual.Details() : Error.Details();

                Passed = Details1 == Details2;
                //throw new Exception($"Could not determine if result matched expected. \n{ExpectedResult.Type().ToS()}");
                }

            if (Actual != null)
                {
                AdditionalResultChecks.Each(check =>
                {
                    Passed = Passed && check(Actual);
                    if (!Passed)
                        {
                        string s;
                        try
                            {
                            string collectStr = Params.CollectStr((i, p) =>
                            {
                                try
                                    {
                                    return $"{p.ToS()}\n";
                                    }
                                catch
                                    {
                                    return "null\n";
                                    }
                            });
                            s =
                                $"Result did not pass additional checks.\n Params:\n {collectStr}\nExpected: \'{ExpectedResult.ToS()}\'\nActual: \'{(Error ?? (object)Actual).ToS()}\'";
                            }
                        catch
                            {
                            s = "Result did not pass additional checks.";
                            }

                        throw new Exception(s.ReplaceAll("\r", ""));
                        }
                });
                }


            if (!Passed)
                {
                string s;
                try
                    {
                    string collectStr = Params.CollectStr((i, p) =>
                    {
                        try
                            {
                            return $"{p.ToS()}\n";
                            }
                        catch
                            {
                            return "null\n";
                            }
                    });
                    s =
                        $"Result did not match value. \nParams:\n {collectStr}\nExpected: \'{ExpectedResult.ToS()}\'\nActual: \'{(Error ?? (object)Actual).ToS()}\'";
                    }
                catch
                    {
                    s = "Result did not match value.";
                    }
                throw new Exception(s.ReplaceAll("\r", ""));
                }
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void AssertResult<U>(this Func<U> Func, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertResult(new object[] { }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void AssertResult<T1, U>(this Func<T1, U> Func, T1 o1, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertResult(new object[] { o1 }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void AssertResult<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertResult(new object[] { o1, o2 }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void AssertResult<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertResult(new object[] { o1, o2, o3 }, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match [ExpectedResult].
        /// Optionally, pass in [AdditionalResultChecks] to check the result further.
        /// </summary>
        public static void AssertResult<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, U ExpectedResult, params Func<object, bool>[] AdditionalResultChecks)
            {
            Func.Method.MethodAssertResult(new object[] { o1, o2, o3, o4 }, ExpectedResult, AdditionalResultChecks);
            }
        #endregion

        #region AssertSource
        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void MethodAssertSource(this MethodInfo Method, object[] Params = null, object ExpectedSource = null, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Method.MethodAssertSource<object>(Params, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void MethodAssertSource<U>(this MethodInfo Method, object[] Params = null, U ExpectedSource = default(U), params Func<object, bool>[] AdditionalSourceChecks)
            {
            Params = Params ?? new object[] { };

            var Source = (U)Params[0];


            Method.Invoke(null, Params);

            bool Passed = true;
            if (ExpectedSource == null)
                { }
            else
                if (ExpectedSource is IEnumerable)
                Passed = ((IEnumerable)ExpectedSource).Equivalent((IEnumerable)Source);
            else
                    if (ExpectedSource is IComparable)
                Passed = ((IComparable)ExpectedSource).CompareTo((IComparable)Source) == 0;
            else
                {
                string Details1 = ExpectedSource.Details();
                string Details2 = Source.Details();

                Passed = Details1 == Details2;

                //throw new Exception($"Could not determine if result matched expected. {ExpectedSource.Type().ToS()}");
                }

            AdditionalSourceChecks.Each(check =>
            {
                Passed = Passed && check(Source);
                if (!Passed)
                    throw new Exception(
                        $"Result did not pass additional checks.\nExpected: {ExpectedSource.ToS()}\nActual: {Source.ToS()}");
            });

            if (!Passed)
                throw new Exception(
                    $"Result did not match value.\nExpected: {ExpectedSource.ToS()}\nActual: {Source.ToS()}");
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1>(this Action<T1> Act, T1 o1, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Act.Method.MethodAssertSource(new object[] { o1 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Act.Method.MethodAssertSource(new object[] { o1, o2 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Act.Method.MethodAssertSource(new object[] { o1, o2, o3 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Act.Method.MethodAssertSource(new object[] { o1, o2, o3, o4 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, U>(this Func<T1, U> Func, T1 o1, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Func.Method.MethodAssertSource(new object[] { o1 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Func.Method.MethodAssertSource(new object[] { o1, o2 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Func.Method.MethodAssertSource(new object[] { o1, o2, o3 }, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match [ExpectedSource].
        /// Optionally, pass in [AdditionalSourceChecks] to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        public static void AssertSource<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, T1 ExpectedSource, params Func<object, bool>[] AdditionalSourceChecks)
            {
            Func.Method.MethodAssertSource(new object[] { o1, o2, o3, o4 }, ExpectedSource, AdditionalSourceChecks);
            }
        #endregion



        /// <summary>
        /// Runs unit tests that are active for a particular Type [t]
        /// </summary>
        public static int RunUnitTests(this Type t)
            {
            int TestsRan = 0;

            Dictionary<MemberInfo, List<TestAttribute>> Tests = t.GetTestMembers();

            Tests.Each(tests =>
            {
                int CurrentTest = 1;
                try
                    {
                    var key = tests.Key as MethodInfo;
                    if (key != null)
                        {

                        tests.Value.Each(test =>
                        {
                            var m = key;

                            if (m.ContainsGenericParameters)
                                {
                                var Generics = m.GetAttribute<TestMethodGenerics>();

                                if (!test.GenericTypes.IsEmpty())
                                    {
                                    m = m.MakeGenericMethod(test.GenericTypes);
                                    }
                                else
                                    if (Generics != null)
                                    {
                                    m = m.MakeGenericMethod(Generics.GenericTypes);
                                    }
                                else if (m.HasAttribute<TestedAttribute>())
                                    {

                                    }
                                else
                                    {
                                    throw new Exception("Unable to find generics for Test Attribute");
                                    }
                                }

                            test.FixParameterTypes(m);
                            test.RunTest(m);

                            TestsRan++;
                            CurrentTest++;
                        });
                        }
                    else
                        throw new Exception($"Member {tests.Key.Name} is not a method.");
                    }
                catch (Exception e)
                    {
                    throw new Exception($"Testing for Member: {tests.Key.FullyQualifiedName()} Test #{CurrentTest} failed.\n{e.ToS()}", e);
                    }
            });

            return TestsRan;
            }

        /// <summary>
        /// Retrieves TestAttributes for type [t]
        /// </summary>
        public static Dictionary<MemberInfo, List<TestAttribute>> GetTestMembers(this Type t)
            {
            var Tests = new Dictionary<MemberInfo, List<TestAttribute>>();

            t.GetMembers().Each(m =>
            {
                if (!(m is MethodInfo) || !((MethodInfo)m).IsStatic)
                    {
                    return;
                    }

                if (!Tests.ContainsKey(m))
                    Tests.Add(m, new List<TestAttribute>());

                m.GetAttributes<TestAttribute>(false).Each(attr =>
                {
                    Tests[m].Add(attr);
                });
            });

            return Tests;
            }
        }
    }