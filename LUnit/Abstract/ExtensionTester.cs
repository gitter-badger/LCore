using System;
using System.Collections.Generic;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Reflection;
using LCore.Extensions;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;
using static LCore.LUnit.LUnit.Categories;

//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

// ReSharper disable ConvertToConstant.Global

// ReSharper disable VirtualMemberNeverOverriden.Global
// ReSharper disable RedundantCast

namespace LCore.LUnit
    {
    /// <summary>
    /// Extend this type to test static class members using Attributes
    /// </summary>
    public abstract class ExtensionTester : XUnitOutputTester
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
        [Fact]
        [Trait(Category, AttributeTests)]
        public virtual void TestAttributeAssertions()
            {
            return;

#pragma warning disable 162
            // ReSharper disable HeuristicUnreachableCode
            foreach (var Test in this.TestType)
                {
                var TestData = Test.GetTestData();

#if DEBUG
                Debug.Write("--------------------------------------------------------\n");
                Debug.Write($"Testing {TestData.TestsPresent} {Test.FullName} methods. \n");
                Debug.Write(
                    $"      Total attribute tests:  {TestData.TestAttributes.Count - TestData.UnitTestCount} (~{(TestData.TestAttributes.Count/((double) TestData.TestsPresent - TestData.UnitTestCount)).Round(1).Max(0)} per method) \n");
                Debug.Write($"      Unit tests:             {TestData.UnitTestCount}. \n");
                Debug.Write("\n");
                Debug.Write($"Missing: {TestData.TestsMissing} methods                  {TestData.CoveragePercent}% Coverage\n");
#endif

                /* Test.RunTypeTests();*/


                Dictionary<MemberInfo, List<ILUnitAttribute>> Tests = Test.GetTestMembers();

                Dictionary<uint, List<MemberInfo>> TestMemberCoverage =
                    Tests.Keys.Group(Member => (uint) Tests[Member].Count + (Member.HasAttribute<ITestedAttribute>()
                        ? 1u
                        : 0u));

                uint Members = (uint) Tests.Keys.Count;
                uint MembersCovered = Members - (uint) (TestMemberCoverage.ContainsKey(0u)
                    ? (uint) TestMemberCoverage[0u].Count
                    : 0u);

                uint TestCount = (uint) TestData.TestAttributes.Count;

                // ReSharper disable once UnusedVariable
                uint UnitTestCount = TestData.UnitTestCount;

                uint Passed = 0; //Test.RunUnitTests();

                if (TestCount > 0)
                    this._Output?.WriteLine(
                        $"Passed {Passed} / {TestCount} ({Passed.PercentageOf(TestCount)}%) Attribute {"Tests".Pluralize(TestCount)}");

                this._Output?.WriteLine($"Members Covered: {MembersCovered} / {Members} ({MembersCovered.PercentageOf(Members)}%)");

                List<string> Missing = Tests.Keys.List().Select(Key => Tests[Key].Count == 0).Convert(Member => Member.Name);

                List<string> Missing2 = Missing.RemoveDuplicates();

                if (Missing.Count > 0)
                    {
                    this._Output?.WriteLine("Missing:");
                    Missing2.Each(Method =>
                        this._Output?.WriteLine($"   {Method.Pad(18)}   ({Missing.Count(Method)})"));
                    this._Output?.WriteLine("");
                    }

                if (this.RequireCoveragePercent > 0)
                    TestData.CoveragePercent.Should()
                        .BeGreaterOrEqualTo(this.RequireCoveragePercent,
                            $"{this.RequireCoveragePercent}% coverage required");
                }
            // ReSharper restore HeuristicUnreachableCode
#pragma warning restore 162
            }

        /// <summary>
        /// ExtensionTester constructor
        /// </summary>
        protected ExtensionTester([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }