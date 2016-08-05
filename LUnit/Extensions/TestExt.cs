using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
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

        /// <summary>
        /// Retrieves TestAttributes for type <paramref name="Type" />
        /// </summary>
        [NotNull]
        public static Dictionary<MemberInfo, List<ILUnitAttribute>> GetTestMembers([CanBeNull]this Type Type)
            {
            var Tests = new Dictionary<MemberInfo, List<ILUnitAttribute>>();

            Type?.GetMembers().Each(Member =>
                {
                    if (!(Member is MethodInfo) || !((MethodInfo)Member).IsStatic)
                        {
                        return;
                        }

                    if (!Tests.ContainsKey(Member))
                        Tests.Add(Member, new List<ILUnitAttribute>());

                    Member.GetAttributes<ILUnitAttribute>(false).Each(Attr => { Tests[Member].Add(Attr); });
                });

            return Tests;
            }

        public static void RunTest(this ITestResultAttribute Attr, MethodInfo Method)
            {
            Func<object, bool>[] Checks = Attr.AdditionalResultChecks.Convert(
                L.F<MethodInfo, string, Func<object, bool>>(LUnit.GetCheckMethodArg).Supply(Method));

            //            Method.AssertResult(Parameters, ExpectedResult, Checks);

            var Info = typeof(TestExt).GetMethods().First((Func<MethodInfo, bool>)(MethodInfo =>
               MethodInfo.Name == nameof(AssertionExt.AssertResult) &&
               MethodInfo.ContainsGenericParameters));

            if (Info != null)
                {
                var ExpectedResult = Attr.ExpectedResult;
                object[] Parameters = Attr.Parameters;

                LUnit.FixParameterTypes(Method, Parameters);
                LUnit.FixObject(Method, Method.ReturnType, ref ExpectedResult);

                Info = Info.MakeGenericMethod(ExpectedResult.GetType());

                Info.Invoke(null, new[] { Method, null, Parameters, ExpectedResult, Checks });
                }
            }

        public static void RunTest(this ITestFailsAttribute Attr, MethodInfo Method)
            {
            Func<bool>[] Checks = Attr.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(LUnit.GetCheckMethod).Supply(Method));
            Method.AssertFails(Attr.Parameters, Method.ReflectedType, Attr.ExceptionType, Checks);
            }

        public static void RunTest(this ITestSucceedsAttribute Attr, MethodInfo Method)
            {
            Func<bool>[] Checks = Attr.AdditionalChecks.Convert(L.F<MethodInfo, string, Func<bool>>(LUnit.GetCheckMethod).Supply(Method));
            Method.AssertSucceedes(null, Attr.Parameters, Checks);
            }

        public static void RunTest(this ITestSourceAttribute Attr, MethodInfo Method)
            {
            Func<object, bool>[] Checks =
                Attr.AdditionalSourceChecks.Convert(L.F<MethodInfo, string, Func<object, bool>>(LUnit.GetCheckMethodArg).Supply(Method));

            //    Method.AssertSource(Parameters, ExpectedSource);

            var OutMethod = typeof(TestExt).GetMethods().First((Func<MethodInfo, bool>)(MethodInfo =>
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

            LUnit.FixObject(Method, Method.GetParameters()[0].ParameterType, ref ExpectedSource);

            OutMethod?.Invoke(null, new[] { Method, null, Attr.Parameters, ExpectedSource, Checks });
            }

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