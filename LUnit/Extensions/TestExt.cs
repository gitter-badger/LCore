using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Reflection;
using JetBrains.Annotations;
using LCore.LUnit.Assert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable UnusedMember.Global

namespace LCore.LUnit
    {
    /// <summary>
    /// Provides extensions to allow for method unit testing.
    /// </summary>
    public static class TestExt
        {
        #region GetTestMembers

        /// <summary>
        /// Retrieves TestAttributes for type <paramref name="Type" />
        /// </summary>
        [NotNull]
        public static Dictionary<MemberInfo, List<ILUnitAttribute>> GetTestMembers([CanBeNull] this Type Type)
            {
            var Tests = new Dictionary<MemberInfo, List<ILUnitAttribute>>();

            Type?.GetMembers().Each(Member =>
                {
                if (!(Member is MethodInfo) || !((MethodInfo) Member).IsStatic)
                    {
                    return;
                    }

                if (!Tests.ContainsKey(Member))
                    Tests.Add(Member, new List<ILUnitAttribute>());

                Member.GetAttributes<ILUnitAttribute>(false).Each(Attr => { Tests[Member].Add(Attr); });
                });

            return Tests;
            }

        #endregion

        #region RunTest

        /// <summary>
        /// Execute an ITestResultAttribute and compare ActualResult with ExpectedResult.
        /// </summary>
        public static void RunTest(this ITestResultAttribute Attr, MethodInfo Method)
            {
            Func<object, bool>[] Checks = Attr.AdditionalResultChecks.Convert(
                L.F<MethodInfo, string, Func<object, bool>>(LUnit.GetCheckMethodArg).Supply(Method));

            //            Method.AssertResult(Parameters, ExpectedResult, Checks);

            //var Info = typeof(TestExt).GetMethods().First((Func<MethodInfo, bool>) (MethodInfo =>
            //    MethodInfo.Name == nameof(AssertionExt.AssertResult) &&
            //    MethodInfo.ContainsGenericParameters));

            //if (Info != null)
            //   {
            var ExpectedResult = Attr.ExpectedResult;
            object[] Parameters = Attr.Parameters;

            LUnit.FixParameterTypes(Method, Parameters);
            LUnit.FixObject(Method, Method.ReturnType, ref ExpectedResult);


            Method.AssertResult(null, Parameters, ExpectedResult, Checks);

            //Info = Info.MakeGenericMethod(ExpectedResult.GetType());

            //Info.Invoke(null, new[] {Method, null, Parameters, ExpectedResult, Checks});
            //   }
            }

        /// <summary>
        /// Execute an ITestFailsAttribute test and ensure failure matches the conditions defined.
        /// </summary>
        public static void RunTest(this ITestFailsAttribute Attr, MethodInfo Method)
            {
            Func<bool>[] Checks = Attr.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(LUnit.GetCheckMethod).Supply(Method));

            Method.AssertFails(Attr.Parameters, Method.ReflectedType, Attr.ExceptionType, Checks);
            }

        /// <summary>
        /// Execute an ITestFailsAttribute test and ensures the method succeeds.
        /// </summary>
        public static void RunTest(this ITestSucceedsAttribute Attr, MethodInfo Method)
            {
            Func<bool>[] Checks = Attr.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(LUnit.GetCheckMethod).Supply(Method));

            object[] Parameters = Attr.Parameters;

            LUnit.FixParameterTypes(Method, Parameters);

            Method.AssertSucceedes(null, Parameters, Checks);
            }

        /// <summary>
        /// Execute an ITestSourceAttribute test and perform tests on the calling object (for extension methods).
        /// </summary>
        public static void RunTest(this ITestSourceAttribute Attr, MethodInfo Method)
            {
            Func<object, bool>[] Checks =
                Attr.AdditionalSourceChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(LUnit.GetCheckMethodArg).Supply(Method));

            //    Method.AssertSource(Parameters, ExpectedSource);

            var OutMethod = typeof(TestExt).GetMethods().First((Func<MethodInfo, bool>) (MethodInfo =>
                MethodInfo.Name == nameof(AssertionExt.AssertSource) && MethodInfo.ContainsGenericParameters));

            if (Attr.ExpectedSource != null)
                {
                OutMethod = OutMethod?.MakeGenericMethod(Attr.ExpectedSource.GetType());
                }
            else if (Attr.Parameters[0] != null)
                {
                OutMethod = OutMethod?.MakeGenericMethod(Attr.Parameters[0].GetType());
                }
            else
                {
                OutMethod = OutMethod?.MakeGenericMethod(typeof(object));
                }

            var ExpectedSource = Attr.ExpectedSource;
            object[] Parameters = Attr.Parameters;

            LUnit.FixParameterTypes(Method, Parameters);
            LUnit.FixObject(Method, Method.GetParameters()[0].ParameterType, ref ExpectedSource);

            OutMethod?.Invoke(null, new[] {Method, null, Parameters, ExpectedSource, Checks});
            }

        /// <summary>
        /// Validates an IValidateAttribute, throwing a testing error if validation has any errors.
        /// </summary>
        public static void RunTest(this IValidateAttribute Attr, MemberInfo Member)
            {
            string[] Out = Attr.Validate(Member);

            if (Out.IsEmpty())
                return;

            throw new InternalTestFailureException(
                $"Attribute validation failed: {Attr.GetType()} {Member.FullyQualifiedName()}\r\n{Out.JoinLines()}");
            }

        #endregion

        #region GetTestData

        /// <summary>
        /// Creates a new TypeTests object, detailing the test coverage of the provided type.
        /// </summary>
        [Tested]
        public static TypeTests GetTestData([CanBeNull] this Type In)
            {
            return new TypeTests(In);
            }

        #endregion
        }
    }