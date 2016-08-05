using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace LCore.LUnit
    {
    public abstract class MultiTestReporter : XUnitOutputTester
        {
        protected abstract void RunTests();

        [Fact]
        public void TestFailure01()
            {
            this.PerformTestsOnce();
            this.ThrowException(0);
            }

        [Fact]
        public void TestFailure02()
            {
            this.PerformTestsOnce();
            this.ThrowException(1);
            }

        [Fact]
        public void TestFailure03()
            {
            this.PerformTestsOnce();
            this.ThrowException(2);
            }

        [Fact]
        public void TestFailure04()
            {
            this.PerformTestsOnce();
            this.ThrowException(3);
            }

        [Fact]
        public void TestFailure05()
            {
            this.PerformTestsOnce();
            this.ThrowException(4);
            }

        [Fact]
        public void TestFailure06()
            {
            this.PerformTestsOnce();
            this.ThrowException(5);
            }

        [Fact]
        public void TestFailure07()
            {
            this.PerformTestsOnce();
            this.ThrowException(6);
            }

        [Fact]
        public void TestFailure08()
            {
            this.PerformTestsOnce();
            this.ThrowException(7);
            }

        [Fact]
        public void TestFailure09()
            {
            this.PerformTestsOnce();
            this.ThrowException(8);
            }

        [Fact]
        public void TestFailure10()
            {
            this.PerformTestsOnce();
            this.ThrowException(9);
            }

        private void ThrowException(int Number)
            {
            var Ex = _AssemblyExceptions.GetAt(Number);

            if (Ex != null)
                throw Ex;
            }

        protected void AddException(Exception Ex)
            {
            if (!_AssemblyExceptions.Contains(Ex))
                {
                _AssemblyExceptions.Add(Ex);
                }
            }

        private static bool _TestsPerformed;
        private static readonly List<Exception> _AssemblyExceptions = new List<Exception>();

        private void PerformTestsOnce()
            {
            if (!
                _TestsPerformed
                )
                {
                this.RunTests();

                _TestsPerformed = true;
                }
            }

        protected MultiTestReporter([NotNull] ITestOutputHelper Output) : base(Output) { }
        }
    }