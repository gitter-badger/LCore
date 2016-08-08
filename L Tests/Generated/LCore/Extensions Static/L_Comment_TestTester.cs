using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_Comment_TestTester : XUnitOutputTester
        {
        public L_Comment_TestTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~L_Comment_TestTester() { }

        [Fact]
        public void TestMethod()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.TestMethod
            }

        [Fact]
        public void TestMethod2()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.TestMethod2
            }

        [Fact]
        public void get_TestProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.get_TestProperty
            }

        [Fact]
        public void set_TestProperty()
            {
            // TODO: Implement method test LCore.Extensions.L.Comment.Test.set_TestProperty
            }

        }
    }