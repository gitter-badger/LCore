// This allows for [CanBeNull] annotations to be seen.
#define JETBRAINS_ANNOTATIONS

using System;
using System.Collections.Generic;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using LCore.Extensions;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
using LCore.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

// ReSharper disable ConvertToConstant.Global

// ReSharper disable VirtualMemberNeverOverriden.Global
// ReSharper disable RedundantCast

namespace L_Tests
    {
    /// <summary>
    /// Extend this type to test static class members using Attributes
    /// </summary>
    [Trait(Category, UnitTests)]
    public abstract class ExtensionTester
        {
        private readonly ITestOutputHelper _Output;

        protected ExtensionTester(ITestOutputHelper Output)
            {
            this._Output = Output;
            }


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
        [Fact]
        [Trait(Category, AttributeTests)]
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

                /* Test.RunTypeTests();*/


                Dictionary<MemberInfo, List<ITestAttribute>> Tests = Test.GetTestMembers();

                Dictionary<uint, List<MemberInfo>> TestMemberCoverage = Tests.Keys.Group(Member => (uint)Tests[Member].Count);

                uint Members = (uint)Tests.Keys.Count;
                uint MembersCovered = Members - (uint)(TestMemberCoverage.ContainsKey(0u) ? (uint)TestMemberCoverage[0u].Count : 0u);

                int TestCount = Tests.TotalCount();


                int Passed = Test.RunUnitTests();

                TestCount.Should().Be(Passed);

                this._Output?.WriteLine($"Passed {Passed} / {TestCount} ({Passed.PercentageOf(TestCount)}%) Attribute {"Tests".Pluralize(TestCount)}");

                this._Output?.WriteLine($"Members Covered: {MembersCovered} / {Members} ({MembersCovered.PercentageOf(Members)}%)");

                List<string> Missing = Tests.Keys.List().Select(Key => Tests[Key].Count == 0).Convert(Member => Member.Name);

                List<string> Missing2 = Missing.RemoveDuplicates();

                if (Missing.Count > 0)
                    {
                    this._Output?.WriteLine("");
                    Missing2.Each(Method =>
                        this._Output?.WriteLine($"   {Method.Pad(18)}   ({Missing.Count(Method)})"));
                    this._Output?.WriteLine("");
                    }

                if (this.RequireCoveragePercent > 0)
                    TestData.CoveragePercent.Should()
                        .BeGreaterOrEqualTo(this.RequireCoveragePercent,
                        $"{this.RequireCoveragePercent}% coverage required");
                }
            }
        
        [Fact]
        [ExcludeFromCodeCoverage]
        [Trait(Category, NullabilityTests)]
        public void TestNullability()
            {
            uint Tested = 0;

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
                        bool NullsAllowedForParameter = ParametersCanBeNull[i];

                        var Params = new object[ParameterCount];

                        var ParamBound = ParameterBounds.First(Param => Param.ParameterIndex == i);

                        for (int j = 0; j < Params.Length; j++)
                            {
                            if (i == j)
                                Params[j] = null;
                            else
                                Params[j] = Parameters[j].ParameterType.NewRandom();

                            var ParamBound2 = ParameterBounds.First(Param => Param.ParameterIndex == j);
                            if (ParamBound2 != null)
                                {
                                try
                                    {
                                    Params[j] = Parameters[j].ParameterType.NewRandom(ParamBound2.Minimum,
                                        ParamBound2.Maximum);
                                    }
                                catch (Exception Ex)
                                    {
                                    throw new InternalTestFailureException($"Method {Method.FullyQualifiedName()} could not generate random parameter #{j + 1} {Parameters[j].ParameterType.FullName}", Ex);
                                    }
                                }
                            }
                        try
                            {
                            bool Finished = false;
                            L.A(() =>
                            {
                                try
                                    {
                                    var Result = TheMethod.Invoke(null, Params);

                                    if (!NullsAllowedForParameter)
                                        {
                                        Finished = true;
                                        throw new InternalTestFailureException($"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1}, should have failed, but it passed.");
                                        }

                                    if (!MethodCanBeNull
                                        && TheMethod.ReturnType != typeof(void)
                                        && !TheMethod.ReturnType.IsNullable()
                                        && Result.IsNull())
                                        {
                                        Finished = true;
                                        throw new InternalTestFailureException(
                                        $"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1}, should not have returned null, but it did.");
                                        }
                                    }
                                catch (Exception Ex)
                                    {
                                    if (!NullsAllowedForParameter)
                                        {
                                        Finished = true;
                                        // Enforces use of ArgumentNullException on any field marked [NotNull]
                                        if (!(Ex is ArgumentNullException) ||
                                            ((ArgumentNullException)Ex).ParamName != Parameters[i].Name)
                                            {
                                            throw new InternalTestFailureException(
                                                $"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1}, should have failed with an ArgumentNullException matching the parameter name, but it threw an {Ex.GetType()}: {Ex.Message}.");
                                            }
                                        }
                                    }

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
                                throw new InternalTestFailureException($"Method {Method.FullyQualifiedName()} timed out. Passed parameters: {Params.ToS()}");
                            }
                        catch (Exception Ex)
                            {
                            throw new InternalTestFailureException($"Method {Method.FullyQualifiedName()} was passed null for parameter {i + 1} and failed with {Ex}");
                            }
                        Tested++;

                        if (ParamBound != null && ParamBound.TestWithinBounds > 0u)
                            {
                            // TODO: Implement Test Within Bounds
                            }
                        }
                    }
                }


            this._Output.WriteLine($"Ran {Tested} Nullability {"Test".Pluralize(Tested)}");
            }
        }
    }
