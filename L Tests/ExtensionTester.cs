using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LCore.Extensions;
using System.Diagnostics;
using System.Linq;
using LCore.Tests;

namespace L_Tests
    {
    public abstract class ExtensionTester
        {
        public abstract Type TestType { get; }

        [TestMethod]
        public virtual void RunTests()
            {
            int TestsPresent = this.TestType.GetTestMembers().Keys.Count;
            int TestsMissing = this.TestType.GetMembers().WithoutAttribute<ITestAttribute>().Count();

            Debug.Write($"Testing {TestsPresent} {this.TestType.FullName} methods. Missing: {TestsMissing} methods.\r\n");

            this.TestType.RunTypeTests();
            }
        }
    }
