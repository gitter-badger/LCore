using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LCore.Extensions;
using System.Diagnostics;
using System.Linq;
using LCore.Tests;
using LCore.Extensions;
// ReSharper disable VirtualMemberNeverOverriden.Global
// ReSharper disable RedundantCast

namespace L_Tests
    {
    public abstract class ExtensionTester
        {
        protected abstract Type TestType { get; }

        [TestMethod]
        public virtual void RunTests()
            {
            int MembersPresent = this.TestType.GetMembers().Length;
            int TestsMissing = this.TestType.GetMembers().WithoutAttribute<ITestAttribute>().Count();
            int TestsPresent = MembersPresent - TestsMissing;

            int Coverage = ((double)TestsPresent / ((double)MembersPresent)).AsPercent();

            Debug.Write($"Testing {TestsPresent} {this.TestType.FullName} methods. \r\n");
            Debug.Write($"Missing: {TestsMissing} methods\r\n");
            Debug.Write($"{ Coverage }% Coverage\r\n");

            this.TestType.RunTypeTests();
            }
        }
    }
