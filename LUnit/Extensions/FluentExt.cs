using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Primitives;
using FluentAssertions.Types;
using JetBrains.Annotations;
using LCore.LUnit.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedMethodReturnValue.Global

// ReSharper disable UnusedMember.Global

namespace LCore.LUnit.Fluent
    {
    /// <summary>
    /// Provides assertions in the fluent 'Should____' style.
    /// </summary>
    public static class FluentExt
        {
        #region ShouldSucceed

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed(this MethodInfo Method, object Target = null, object[] Params = null)
            {
            Method.ShouldSucceed<object>(Target, Params, (Func<object, bool>[]) null);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed(this MethodInfo Method, object Target = null, object[] Params = null,
            params Func<bool>[] AdditionalChecks)
            {
            Method.ShouldSucceed<object>(Target, Params,
                AdditionalChecks.Convert<Func<bool>, Func<object, bool>>(Func => { return (o => Func()); }));
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed(this MethodInfo Method, object Target = null, object[] Params = null,
            params Func<object, bool>[] AdditionalChecks)
            {
            Method.ShouldSucceed<object>(Target, Params, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<U>(this MethodInfo Method, object Target = null, object[] Params = null,
            params Func<U, bool>[] AdditionalResultChecks)
            {
            Method.AssertSucceedes(Target, Params, AdditionalResultChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed(this Action Act)
            {
            Act.AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1>(this Action<T1> Act, T1 o1)
            {
            Act.AssertSucceedes(o1);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.AssertSucceedes(o1, o2);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.AssertSucceedes(o1, o2, o3);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.AssertSucceedes(o1, o2, o3, o4);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<U>(this Func<U> Func)
            {
            Func.AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, U>(this Func<T1, U> Func, T1 o1)
            {
            Func.Supply(o1).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
            {
            Func.Supply(o1).Supply(o2).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
            {
            Func.Supply(o1).Supply(o2).Supply(o3).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldSucceed<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Func.Supply(o1).Supply(o2).Supply(o3).Supply(o4).AssertSucceedes();
            }

        #endregion

        #region ShouldFail

        /// <summary>
        /// Assert that a metod fails with a particular type of exception <typeparamref name="E" />.
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<E>(this MethodInfo Method, object[] Params, object Target, params Func<bool>[] AdditionalChecks)
            where E : Exception
            {
            Method.ShouldFail(Params, Target, typeof(E), AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod fails with a particular type of exception <paramref name="EType" />.
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail(this MethodInfo Method, object[] Params, object Target, Type EType = null,
            params Func<bool>[] AdditionalChecks)
            {
            Method.AssertFails(Params, Target, EType, AdditionalChecks);
            }


        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail(this Action Act)
            {
            Act.Method.ShouldFail(new object[] {}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Method.ShouldFail(new object[] {o1}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Method.ShouldFail(new object[] {o1, o2}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Method.ShouldFail(new object[] {o1, o2, o3}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Method.ShouldFail(new object[] {o1, o2, o3, o4}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<E>(this Action Act) where E : Exception
            {
            Act.Method.ShouldFail<E>(new object[] {}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, E>(this Action<T1> Act, T1 o1) where E : Exception
            {
            Act.Method.ShouldFail<E>(new object[] {o1}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, E>(this Action<T1, T2> Act, T1 o1, T2 o2) where E : Exception
            {
            Act.Method.ShouldFail<E>(new object[] {o1, o2}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, E>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Act.Method.ShouldFail<E>(new object[] {o1, o2, o3}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
            {
            Act.Method.ShouldFail<E>(new object[] {o1, o2, o3, o4}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<U>(this Func<U> Func)
            {
            Func.Method.ShouldFail(new object[] {}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, U>(this Func<T1, U> Func, T1 o1)
            {
            Func.Method.ShouldFail(new object[] {o1}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
            {
            Func.Method.ShouldFail(new object[] {o1, o2}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
            {
            Func.Method.ShouldFail(new object[] {o1, o2, o3}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Func.Method.ShouldFail(new object[] {o1, o2, o3, o4}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<U, E>(this Func<U> Func) where E : Exception
            {
            Func.Method.ShouldFail<E>(new object[] {}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, U, E>(this Func<T1, U> Func, T1 o1) where E : Exception
            {
            Func.Method.ShouldFail<E>(new object[] {o1}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, U, E>(this Func<T1, T2, U> Func, T1 o1, T2 o2) where E : Exception
            {
            Func.Method.ShouldFail<E>(new object[] {o1, o2}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Func.Method.ShouldFail<E>(new object[] {o1, o2, o3}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldFail<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            where E : Exception
            {
            Func.Method.ShouldFail<E>(new object[] {o1, o2, o3, o4}, Func.Target);
            }

        #endregion

        #region ShouldBe

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// Optionally, pass in <paramref name="AdditionalResultChecks" /> to check the result further.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe(this MethodInfo Method, object Target = null, object[] Params = null, object ExpectedResult = null,
            params Func<object, bool>[] AdditionalResultChecks)
            {
            Method.ShouldBe<object>(Target, Params, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// Optionally, pass in <paramref name="AdditionalResultChecks" /> to check the result further.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe<U>(this MethodInfo Method, object Target = null, object[] Params = null,
            U ExpectedResult = default(U),
            params Func<object, bool>[] AdditionalResultChecks)
            {
            Method.AssertResult(Target, Params, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe<U>(this Func<U> Func, U ExpectedResult)
            {
            Func().Should().Be(ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe<T1, U>(this Func<T1, U> Func, T1 o1, U ExpectedResult)
            {
            Func(o1).Should().Be(ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, U ExpectedResult)
            {
            Func(o1, o2).Should().Be(ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, U ExpectedResult)
            {
            Func(o1, o2, o3).Should().Be(ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void ShouldBe<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, U ExpectedResult)
            {
            Func(o1, o2, o3, o4).Should().Be(ExpectedResult);
            }

        #endregion

        #region FluentAssertions +

        #region HaveAttribute

        /// <summary>
        /// Asserts that the current System.Type has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Type"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.
        /// </param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns>An FluentAssertions.AndConstraint`1 which can be used to chain assertions.</returns>
        public static AndConstraint<TypeAssertions> HaveAttribute<T>(this TypeAssertions Type, string Because = "", params object[] BecauseArgs)
            where T : IPersistAttribute
            {
            Type.Subject.HasAttribute<T>().ShouldBeTrue(Because, BecauseArgs);
            return new AndConstraint<TypeAssertions>(Type);
            }

        /// <summary>
        /// Asserts that the current System.Type has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Type"></param>
        /// <param name="IncludeBaseTypes"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.
        /// </param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns>An FluentAssertions.AndConstraint`1 which can be used to chain assertions.</returns>
        public static AndConstraint<TypeAssertions> HaveAttribute<T>(this TypeAssertions Type, bool IncludeBaseTypes, string Because = "", params object[] BecauseArgs)
            {
            Type.Subject.HasAttribute<T>(IncludeBaseTypes).ShouldBeTrue(Because, BecauseArgs);
            return new AndConstraint<TypeAssertions>(Type);
            }

        #endregion

        #region NotHaveAttribute

        /// <summary>
        /// Asserts that the current System.Type does not have an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Type"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.
        /// </param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns>An FluentAssertions.AndConstraint`1 which can be used to chain assertions.</returns>
        public static AndConstraint<TypeAssertions> NotHaveAttribute<T>(this TypeAssertions Type, string Because = "", params object[] BecauseArgs)
            where T : IPersistAttribute
            {
            Type.Subject.HasAttribute<T>().ShouldBeFalse(Because, BecauseArgs);
            return new AndConstraint<TypeAssertions>(Type);
            }


        /// <summary>
        /// Asserts that the current System.Type does not have an attribute of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Type"></param>
        /// <param name="IncludeBaseTypes"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.
        /// </param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns>An FluentAssertions.AndConstraint`1 which can be used to chain assertions.</returns>
        public static AndConstraint<TypeAssertions> NotHaveAttribute<T>(this TypeAssertions Type, bool IncludeBaseTypes, string Because = "", params object[] BecauseArgs)
            {
            Type.Subject.HasAttribute<T>(IncludeBaseTypes).ShouldBeFalse(Because, BecauseArgs);
            return new AndConstraint<TypeAssertions>(Type);
            }

        #endregion

        #region Abbreviations +

        #region ShouldBe

        /// <summary>
        /// Asserts that the value is null.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Compare"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<ObjectAssertions> ShouldBe<T>([CanBeNull] this T Value, [CanBeNull] T Compare, [CanBeNull] string Because = "",
            [CanBeNull] params object[] BecauseArgs)
            {
            return Value.Should().Be(Compare, Because, BecauseArgs);
            }

        #endregion

        #region ShouldBeTrue

        /// <summary>
        /// Asserts that the value is true.
        /// </summary>
        /// <param name="Boolean"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<BooleanAssertions> ShouldBeTrue(this bool Boolean, string Because = "",
            params object[] BecauseArgs)
            {
            return Boolean.Should().BeTrue(Because, BecauseArgs);
            }

        #endregion

        #region ShouldBeFalse

        /// <summary>
        /// Asserts that the value is false.
        /// </summary>
        /// <param name="Boolean"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<BooleanAssertions> ShouldBeFalse(this bool Boolean, string Because = "",
            params object[] BecauseArgs)
            {
            return Boolean.Should().BeFalse(Because, BecauseArgs);
            }

        #endregion

        #region ShouldBeNull

        /// <summary>
        /// Asserts that the value is null.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<ObjectAssertions> ShouldBeNull<T>([CanBeNull] this T Value, [CanBeNull] string Because = "",
            [CanBeNull] params object[] BecauseArgs)
            where T : class
            {
            return Value.Should().BeNull(Because, BecauseArgs);
            }

        /// <summary>
        /// Asserts that the value is null.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<ObjectAssertions> ShouldBeNull<T>([CanBeNull] this T? Value, [CanBeNull] string Because = "",
            [CanBeNull] params object[] BecauseArgs)
            where T : struct
            {
            return Value.Should().BeNull(Because, BecauseArgs);
            }

        #endregion

        #region ShouldNotBeNull

        /// <summary>
        /// Asserts that the value is null.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<ObjectAssertions> ShouldNotBeNull<T>([CanBeNull] this T Value, [CanBeNull] string Because = "",
            [CanBeNull] params object[] BecauseArgs)
            where T : class
            {
            return Value.Should().NotBeNull(Because, BecauseArgs);
            }

        /// <summary>
        /// Asserts that the value is null.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Because">A formatted phrase as is supported by System.String.Format(System.String,System.Object[])
        ///     explaining why the assertion is needed. If the phrase does not start with the
        ///     word because, it is prepended automatically.</param>
        /// <param name="BecauseArgs">Zero or more objects to format using the placeholders in because.</param>
        /// <returns></returns>
        public static AndConstraint<ObjectAssertions> ShouldNotBeNull<T>([CanBeNull] this T? Value, [CanBeNull] string Because = "",
            [CanBeNull] params object[] BecauseArgs)
            where T : struct
            {
            return Value.Should().NotBeNull(Because, BecauseArgs);
            }

        #endregion

        #endregion

        #endregion
        }
    }