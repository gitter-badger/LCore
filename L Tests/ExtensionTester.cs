using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Global

// ReSharper disable VirtualMemberNeverOverriden.Global
// ReSharper disable RedundantCast

namespace L_Tests
    {
    public abstract class ExtensionTester
        {
        public static readonly int RequireCoveragePercent = 1;

        protected abstract Type[] TestType { get; }

        [TestMethod]
        public virtual void RunTests()
            {
            foreach (var Test in this.TestType)
                {
                var TestData = Test.GetTestData();

                Debug.Write("--------------------------------------------------------\r\n");
                Debug.Write($"Testing {TestData.TestsPresent} {Test.FullName} methods. \r\n");
                Debug.Write($"      Total attribute tests:  {TestData.TestAttributes.Count - TestData.UnitTestCount} (~{(TestData.TestAttributes.Count / ((double)TestData.TestsPresent - TestData.UnitTestCount)).Round(1)} per method) \r\n");
                Debug.Write($"      Unit tests:             {TestData.UnitTestCount}. \r\n");
                Debug.Write("\r\n");
                Debug.Write($"Missing: {TestData.TestsMissing} methods                  {TestData.CoveragePercent}% Coverage\r\n");

                Test.RunTypeTests();

                if (RequireCoveragePercent > 0)
                    TestData.CoveragePercent.Should().BeGreaterOrEqualTo(RequireCoveragePercent, $"{RequireCoveragePercent}% coverage required");
                }
            }
        }
    }
