using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Diagnostics;
using FluentAssertions;
using LCore.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

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
        protected virtual int RequireCoveragePercent => 1;

        /// <summary>
        /// The Type to test.
        /// </summary>
        protected abstract Type[] TestType { get; }

        /// <summary>
        /// Run all Attribute tests on the Type.
        /// </summary>
        [TestCategory(L.Test.Categories.AttributeTests)]
        [Fact]
        public virtual void AttributeTests()
            {
            foreach (var Test in this.TestType)
                {
                var TestData = Test.GetTestData();

                Debug.Write("--------------------------------------------------------\r\n");
                Debug.Write($"Testing {TestData.TestsPresent} {Test.FullName} methods. \r\n");
                Debug.Write($"      Total attribute tests:  {TestData.TestAttributes.Count - TestData.UnitTestCount} (~{(TestData.TestAttributes.Count / ((double)TestData.TestsPresent - TestData.UnitTestCount)).Round(1).Max(0)} per method) \r\n");
                Debug.Write($"      Unit tests:             {TestData.UnitTestCount}. \r\n");
                Debug.Write("\r\n");
                Debug.Write($"Missing: {TestData.TestsMissing} methods                  {TestData.CoveragePercent}% Coverage\r\n");

                Test.RunTypeTests();

                if (this.RequireCoveragePercent > 0)
                    TestData.CoveragePercent.Should()
                        .BeGreaterOrEqualTo(this.RequireCoveragePercent, 
                        $"{this.RequireCoveragePercent}% coverage required");
                }
            }
        }
    }
