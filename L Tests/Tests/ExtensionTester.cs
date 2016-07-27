// This allows for [CanBeNull] annotations to be seen.
#define JETBRAINS_ANNOTATIONS

using System;
using System.Collections.Generic;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using LCore.Extensions;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
using LCore.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

// ReSharper disable ConvertToConstant.Global

// ReSharper disable VirtualMemberNeverOverriden.Global
// ReSharper disable RedundantCast

namespace L_Tests
    {
    /// <summary>
    /// Extend this type to test static class members using Attributes
    /// </summary>
    public abstract class ExtensionTester
        {
        /// <summary>
        /// Less than this amount of method coverage will result in a test failure.
        /// </summary>
        protected virtual uint RequireCoveragePercent => 1;

        /// <summary>
        /// The Type to test.
        /// </summary>
        protected abstract Type[] TestType { get; }

        /// <summary>
        /// Run all Attribute tests on the Type.
        /// </summary>
        [TestCategory(L.Test.Categories.AttributeTests)]
        [Fact]
        public virtual void TestAttributeAssertions()
            {
            foreach (var Test in this.TestType)
                {
                var TestData = Test.GetTestData();

#if DEBUG
                Debug.Write("--------------------------------------------------------\r\n");
                Debug.Write($"Testing {TestData.TestsPresent} {Test.FullName} methods. \r\n");
                Debug.Write($"      Total attribute tests:  {TestData.TestAttributes.Count - TestData.UnitTestCount} (~{(TestData.TestAttributes.Count / ((double)TestData.TestsPresent - TestData.UnitTestCount)).Round(1).Max(0)} per method) \r\n");
                Debug.Write($"      Unit tests:             {TestData.UnitTestCount}. \r\n");
                Debug.Write("\r\n");
                Debug.Write($"Missing: {TestData.TestsMissing} methods                  {TestData.CoveragePercent}% Coverage\r\n");
#endif

                Test.RunTypeTests();

                if (this.RequireCoveragePercent > 0)
                    TestData.CoveragePercent.Should()
                        .BeGreaterOrEqualTo(this.RequireCoveragePercent,
                        $"{this.RequireCoveragePercent}% coverage required");
                }
            }

        [TestCategory(L.Test.Categories.NullabilityTests)]
        [Fact]
        public void TestNullability()
            {
            uint Assertions = 0;

            foreach (var Test in this.TestType)
                {
                MethodInfo[] Methods = Test.GetExtensionMethods();

                foreach (var Method in Methods)
                    {
                    bool MethodCanBeNull = Method.HasAttribute<CanBeNullAttribute>(false);

                    List<TestBoundAttribute> ParameterBounds = Method.GetAttributes<TestBoundAttribute>(false);

                    var TheMethod = Method;

                    if (Method.ContainsGenericParameters)
                        {
                        try { TheMethod = Method.MakeGenericMethod(typeof(int)); }
                        catch
                            {
                            try { TheMethod = Method.MakeGenericMethod(typeof(string)); }
                            catch
                                {
                                try { TheMethod = Method.MakeGenericMethod(typeof(int), typeof(string)); }
                                catch
                                    {
                                    try { TheMethod = Method.MakeGenericMethod(typeof(string), typeof(string)); }
                                    catch
                                        {
                                        try { TheMethod = Method.MakeGenericMethod(typeof(int), typeof(int), typeof(int)); }
                                        catch
                                            {
                                            try { TheMethod = Method.MakeGenericMethod(typeof(string), typeof(string), typeof(string)); } catch { }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    // If we cant find a proper type to use to fill parameters, skip the method.
                    if (TheMethod.ContainsGenericParameters)
                        continue;


                    ParameterInfo[] Parameters = TheMethod.GetParameters();

                    bool[] ParametersCanBeNull = Parameters.Convert(
                        Param => Param.HasAttribute<CanBeNullAttribute>(false));

                    int ParameterCount = Parameters.Length;

                    for (int i = 0; i < ParametersCanBeNull.Length; i++)
                        {
                        if (ParametersCanBeNull[i])
                            {
                            var Params = new object[ParameterCount];

                            for (int j = 0; j < Params.Length; j++)
                                {
                                if (i == j)
                                    Params[j] = null;
                                else
                                    Params[j] = Parameters[j].ParameterType.NewRandom();

                                var ParamBound = ParameterBounds.First(Param => Param.ParameterIndex == j);
                                if (ParamBound != null)
                                    {
                                    Params[j] = Parameters[j].ParameterType.NewRandom(ParamBound.Minimum, ParamBound.Maximum);
                                    }
                                }

                            //var Invoker = Params[0];

                            //Params = Params.RemoveAt(0);
                            try
                                {
                                bool Finished = false;
                                L.A(() =>
                                {
                                    var Result = TheMethod.Invoke(null, Params);

                                    if (!MethodCanBeNull
                                        && TheMethod.ReturnType != typeof(void)
                                        && !TheMethod.ReturnType.IsNullable()
                                        && Result.IsNull())
                                        Assert.Fail($"Method {Method.ToInvocationSignature()} was passed null for parameter {i + 1}, should not have returned null, but it did.");


                                    Finished = true;
                                }).Async(300)();

                                uint Waited = 0;

                                while (Waited < 300)
                                    {
                                    Thread.Sleep(1);
                                    Waited += 1;

                                    if (Finished)
                                        break;
                                    }

                                if (!Finished)
                                    Assert.Fail($"Method {Method.ToInvocationSignature()} timed out. Passed parameters: {Params.ToS()}");
                                }
                            catch (Exception Ex)
                                {
                                Assert.Fail($"Method {Method.ToInvocationSignature()} was passed null for parameter {i + 1} and failed with {Ex}");
                                }

                            Assertions++;
                            }
                        }
                    }
                }

            Debug.Write($"All Passed\r\n\r\nAssertions: {Assertions}");
            }


        }
    }
