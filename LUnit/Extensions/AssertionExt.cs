using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
using LCore.LUnit.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedMember.Global

namespace LCore.LUnit.Assert
    {
    /// <summary>
    /// Provides assertions in the 'Assert___' style.
    /// </summary>
    public static class AssertionExt
        {
        #region AssertSucceedes

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes(this MethodInfo Method, object Target = null, object[] Params = null)
            {
            Method.AssertSucceedes<object>(Target, Params, (Func<object, bool>[]) null);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes(this MethodInfo Method, object Target = null, object[] Params = null,
            params Func<bool>[] AdditionalChecks)
            {
            Method.AssertSucceedes<object>(Target, Params,
                AdditionalChecks.Convert<Func<bool>, Func<object, bool>>(Func => { return (o => Func()); }));
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes(this MethodInfo Method, object Target = null, object[] Params = null,
            params Func<object, bool>[] AdditionalChecks)
            {
            Method.AssertSucceedes<object>(Target, Params, AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<U>(this MethodInfo Method, object Target = null, object[] Params = null,
            params Func<U, bool>[] AdditionalResultChecks)
            {
            Params = Params ?? new object[] {};
            U Result;

            try
                {
                Result = (U) Method.Invoke(Target, Params);
                }
            catch (Exception Ex)
                {
                throw new InternalTestFailureException($"Method threw exception: {Ex.ToS()}", Ex);
                }

            AdditionalResultChecks.Each(Check =>
                {
                if (!Check(Result))
                    throw new InternalTestFailureException($"Result did not pass additional checks.{Result.ToS()}");
                });
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes(this Action Act)
            {
            try
                {
                Act();
                }
            catch (Exception Ex)
                {
                throw new InternalTestFailureException($"Method threw exception: {Ex.ToS()}", Ex);
                }
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Supply(o1).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Supply(o1).Supply(o2).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Supply(o1).Supply(o2).Supply(o3).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Supply(o1).Supply(o2).Supply(o3).Supply(o4).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<U>(this Func<U> Func)
            {
            try
                {
                Func();
                }
            catch (Exception Ex)
                {
                throw new InternalTestFailureException($"Method threw exception: {Ex.ToS()}", Ex);
                }
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, U>(this Func<T1, U> Func, T1 o1)
            {
            Func.Supply(o1).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
            {
            Func.Supply(o1).Supply(o2).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
            {
            Func.Supply(o1).Supply(o2).Supply(o3).AssertSucceedes();
            }

        /// <summary>
        /// Assert that a metod succeeds (does not throw an exception)
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSucceedes<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Func.Supply(o1).Supply(o2).Supply(o3).Supply(o4).AssertSucceedes();
            }

        #endregion

        #region AssertFails

        /// <summary>
        /// Assert that a metod fails with a particular type of exception <typeparamref name="E" />.
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<E>(this MethodInfo Method, object[] Params, object Target, params Func<bool>[] AdditionalChecks)
            where E : Exception
            {
            Method.AssertFails(Params, Target, typeof(E), AdditionalChecks);
            }

        /// <summary>
        /// Assert that a metod fails with a particular type of exception <paramref name="EType" />.
        /// Optionally, pass in additional checks to test additional parameters.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails(this MethodInfo Method, [CanBeNull] object[] Params, object Target, Type EType = null,
            params Func<bool>[] AdditionalChecks)
            {
            EType = EType ?? typeof(Exception);

            try
                {
                Params = Params ?? new object[] {};
                Method.Invoke(Target, Params);
                }
            catch (TargetInvocationException Ex)
                {
                if (!Ex.InnerException.GetType().IsType(EType))
                    throw new InternalTestFailureException(
                        $"Exception type {EType.FullName} did not throw.\n{Ex.InnerException.GetType().FullName} was thrown instead.", Ex);
                return;
                }
            catch (Exception Ex)
                {
                if (Ex.IsType(EType))
                    return;

                throw new InternalTestFailureException(
                    $"Exception type {EType.FullName} did not throw.\n{Ex.GetType().FullName} was thrown instead.", Ex);
                }

            AdditionalChecks.Each((i, Check) =>
                {
                if (!Check())
                    throw new InternalTestFailureException($"Method did not pass additional check #{i + 1}.");
                });

            throw new InternalTestFailureException($"Exception type {EType.FullName} did not throw.");
            }


        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails(this Action Act)
            {
            Act.Method.AssertFails(new object[] {}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1>(this Action<T1> Act, T1 o1)
            {
            Act.Method.AssertFails(new object[] {o1}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2>(this Action<T1, T2> Act, T1 o1, T2 o2)
            {
            Act.Method.AssertFails(new object[] {o1, o2}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3)
            {
            Act.Method.AssertFails(new object[] {o1, o2, o3}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Act.Method.AssertFails(new object[] {o1, o2, o3, o4}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<E>(this Action Act) where E : Exception
            {
            Act.Method.AssertFails<E>(new object[] {}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, E>(this Action<T1> Act, T1 o1) where E : Exception
            {
            Act.Method.AssertFails<E>(new object[] {o1}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, E>(this Action<T1, T2> Act, T1 o1, T2 o2) where E : Exception
            {
            Act.Method.AssertFails<E>(new object[] {o1, o2}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, E>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Act.Method.AssertFails<E>(new object[] {o1, o2, o3}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, T4, E>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4) where E : Exception
            {
            Act.Method.AssertFails<E>(new object[] {o1, o2, o3, o4}, Act.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<U>(this Func<U> Func)
            {
            Func.Method.AssertFails(new object[] {}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, U>(this Func<T1, U> Func, T1 o1)
            {
            Func.Method.AssertFails(new object[] {o1}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2)
            {
            Func.Method.AssertFails(new object[] {o1, o2}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3)
            {
            Func.Method.AssertFails(new object[] {o1, o2, o3}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            {
            Func.Method.AssertFails(new object[] {o1, o2, o3, o4}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<U, E>(this Func<U> Func) where E : Exception
            {
            Func.Method.AssertFails<E>(new object[] {}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, U, E>(this Func<T1, U> Func, T1 o1) where E : Exception
            {
            Func.Method.AssertFails<E>(new object[] {o1}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, U, E>(this Func<T1, T2, U> Func, T1 o1, T2 o2) where E : Exception
            {
            Func.Method.AssertFails<E>(new object[] {o1, o2}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, U, E>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3) where E : Exception
            {
            Func.Method.AssertFails<E>(new object[] {o1, o2, o3}, Func.Target);
            }

        /// <summary>
        /// Assert that a metod fails with any type of exception.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertFails<T1, T2, T3, T4, U, E>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4)
            where E : Exception
            {
            Func.Method.AssertFails<E>(new object[] {o1, o2, o3, o4}, Func.Target);
            }

        #endregion

        #region AssertResult

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// Optionally, pass in <paramref name="AdditionalResultChecks" /> to check the result further.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult(this MethodInfo Method, object Target = null, object[] Params = null,
            object ExpectedResult = null,
            params Func<object, bool>[] AdditionalResultChecks)
            {
            Method.AssertResult<object>(Target, Params, ExpectedResult, AdditionalResultChecks);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// Optionally, pass in <paramref name="AdditionalResultChecks" /> to check the result further.
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult<U>(this MethodInfo Method, object Target = null, object[] Params = null,
            U ExpectedResult = default(U),
            params Func<object, bool>[] AdditionalResultChecks)
            {
            var ExpectedType = ExpectedResult?.GetType() ?? typeof(U);

            Params = Params ?? new object[] {};

            Exception Error = null;
            var Actual = default(U);
            try
                {
                var MethodResult = Method.Invoke(Target, Params);

                if (MethodResult.IsType(ExpectedType))
                    Actual = (U) MethodResult;
                else if (MethodResult == null && (ExpectedType.IsNullable() || !ExpectedType.IsValueType))
                    Actual = default(U);
                else
                    throw new InternalTestFailureException(
                        $"Expected object of type {ExpectedType.FullName} but received {MethodResult.Type().FullName}: {MethodResult}");
                }
            catch (Exception Ex)
                {
                Error = Ex;
                }

            bool Passed;
            var Result = ExpectedResult as IEnumerable;

            if (ExpectedResult is IComparable && Actual is IComparable)
                {
                Passed = ((IComparable) ExpectedResult).CompareTo((IComparable) Actual) == 0;
                if (!Passed) {}
                }
            else if (Result != null && Actual is IEnumerable)
                {
                Passed = Result.Equivalent((IEnumerable) Actual);
                if (!Passed) {}
                }
            else if (Error != null && !(ExpectedResult is Exception))
                {
                Passed = false;
                }
            else
                {
                string Details1 = ExpectedResult.Details();

                string Details2 = Error?.Details() ?? Actual.Details();

                Passed = Details1 == Details2;
                //throw new Exception($"Could not determine if result matched expected. \n{ExpectedResult.Type().ToS()}");
                }

            if (Actual != null)
                {
                AdditionalResultChecks.Each(Check =>
                    {
                    Passed = Passed && Check(Actual);
                    if (!Passed)
                        {
                        string Str;
                        try
                            {
                            string CollectStr = Params.CollectStr((i, Param) =>
                                {
                                try
                                    {
                                    return $"{Param.ToS()}\n";
                                    }
                                catch
                                    {
                                    return "null\n";
                                    }
                                });
                            Str =
                                $"\nResult did not pass additional checks.\n\n Params:\n {CollectStr}\nExpected: \'{ExpectedResult.ToS()}\'\nActual:   \'{(Error ?? (object) Actual).ToS()}\'\n\n";
                            }
                        catch
                            {
                            Str = "Result did not pass additional checks.";
                            }

                        throw new InternalTestFailureException(Str.ReplaceAll("\r", ""));
                        }
                    });
                }


            if (!Passed)
                {
                string Str;
                try
                    {
                    string CollectStr = Params.CollectStr((i, Param) =>
                        {
                        try
                            {
                            return $"{Param.ToS()}\n";
                            }
                        catch
                            {
                            return "null\n";
                            }
                        });
                    Str = $"Result did not match value. \nParams:\n {CollectStr}\nExpected: \'{ExpectedResult.ToS()}\'\n";
                    Str +=
                        $"Actual: \'{(Error ?? (object) Actual ?? "").ToString().RemoveAll("System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. --->", "System.Exception: ")}\'";
                    }
                catch
                    {
                    Str = "Result did not match value.";
                    }


                throw new InternalTestFailureException(Str.ReplaceAll("\r", ""));
                }
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult<U>(this Func<U> Func, U ExpectedResult)
            {
            Func.ShouldBe(ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult<T1, U>(this Func<T1, U> Func, T1 o1, U ExpectedResult)
            {
            Func.ShouldBe(o1, ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult<T1, T2, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, U ExpectedResult)
            {
            Func.ShouldBe(o1, o2, ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, U ExpectedResult)
            {
            Func.ShouldBe(o1, o2, o3, ExpectedResult);
            }

        /// <summary>
        /// Asserts that a method's result will match <paramref name="ExpectedResult" />.
        /// </summary>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertResult<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, U ExpectedResult)
            {
            Func.ShouldBe(o1, o2, o3, o4, ExpectedResult);
            }

        #endregion

        #region AssertSource

        /// <summary>
        /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
        /// Optionally, pass in <paramref name="AdditionalSourceChecks" /> to check the result further.
        /// 
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSource(this MethodInfo Method, object Target = null, object[] Params = null,
            object ExpectedSource = null,
            params Func<object, bool>[] AdditionalSourceChecks)
            {
            Method.AssertSource<object>(Target, Params, ExpectedSource, AdditionalSourceChecks);
            }

        /// <summary>
        /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
        /// Optionally, pass in <paramref name="AdditionalSourceChecks" /> to check the result further.
        /// This is used for methods that manipulate the object they were called on, not the result (if any).
        /// </summary>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        public static void AssertSource<U>(this MethodInfo Method, object Target = null, object[] Params = null,
            U ExpectedSource = default(U),
            params Func<object, bool>[] AdditionalSourceChecks)
            {
            Params = Params ?? new object[] {};

            var Source = (U) Params[0];


            try
                {
                Method.Invoke(Target, Params);
                }
            catch (Exception Ex)
                {
                throw new InternalTestFailureException(
                    $"Method failed to execute\nExpected: {ExpectedSource.ToS()}\nActual: {Ex.ToS()}", Ex);
                }

            bool Passed = true;
            if (ExpectedSource == null) {}
            else if (ExpectedSource is IEnumerable)
                Passed = ((IEnumerable) ExpectedSource).Equivalent((IEnumerable) Source);
            else if (ExpectedSource is IComparable)
                Passed = ((IComparable) ExpectedSource).CompareTo((IComparable) Source) == 0;
            else
                {
                string Details1 = ExpectedSource.Details();
                string Details2 = Source.Details();

                Passed = Details1 == Details2;

                //throw new Exception($"Could not determine if result matched expected. {ExpectedSource.Type().ToS()}");
                }

            AdditionalSourceChecks.Each(Check =>
                {
                Passed = Passed && Check(Source);
                if (!Passed)
                    throw new InternalTestFailureException(
                        $"Result did not pass additional checks.\nExpected: {ExpectedSource.ToS()}\nActual: {Source.ToS()}");
                });

            if (!Passed)
                throw new InternalTestFailureException(
                    $"Result did not match value.\nExpected: {ExpectedSource.ToS()}\nActual: {Source.ToS()}");
            }

        /*
                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<TSource>(this Action Act, TSource ExpectedSource)
                    {
                    Act.Method.AssertSource(new object[] { o1 }, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, TSource>(this Action<T1> Act, T1 o1, TSource ExpectedSource)
                    {
                    Act.Method.AssertSource(new object[] {o1}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, T2, TSource>(this Action<T1, T2> Act, T1 o1, T2 o2, TSource ExpectedSource)
                    {
                    Act.Method.AssertSource(new object[] {o1, o2}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, T2, T3, TSource>(this Action<T1, T2, T3> Act, T1 o1, T2 o2, T3 o3, T1 ExpectedSource)
                    {
                    Act.Method.AssertSource(new object[] {o1, o2, o3}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, T2, T3, T4, TSource>(this Action<T1, T2, T3, T4> Act, T1 o1, T2 o2, T3 o3, T4 o4, TSource ExpectedSource)
                    {
                    Act.Method.AssertSource(new object[] {o1, o2, o3, o4}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, TSource, U>(this Func<T1, U> Func, T1 o1, TSource ExpectedSource)
                    {
                    Func.Method.AssertSource(new object[] {o1}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, T2, TSource, U>(this Func<T1, T2, U> Func, T1 o1, T2 o2, TSource ExpectedSource)
                    {
                    Func.Method.AssertSource(new object[] {o1, o2}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, T2, T3, TSource, U>(this Func<T1, T2, T3, U> Func, T1 o1, T2 o2, T3 o3, TSource ExpectedSource)
                    {
                    Func.Method.AssertSource(new object[] {o1, o2, o3}, ExpectedSource);
                    }

                /// <summary>
                /// Asserts that a method's source will match <paramref name="ExpectedSource" />.
                /// This is used for methods that manipulate the object they were called on, not the result (if any).
                /// </summary>
                /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
                /// <exception cref="InternalTestFailureException">The test fails</exception>
                public static void AssertSource<T1, T2, T3, T4, TSource, U>(this Func<T1, T2, T3, T4, U> Func, T1 o1, T2 o2, T3 o3, T4 o4, TSource ExpectedSource)
                    {
                    Func.Method.AssertSource(new object[] {o1, o2, o3, o4}, ExpectedSource);
                    }*/

        #endregion
        }
    }