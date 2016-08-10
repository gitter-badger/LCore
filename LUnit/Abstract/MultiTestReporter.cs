using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using Xunit;
using Xunit.Abstractions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Tracks and reports up to 10 testing errors from a single RunTests method.
    /// </summary>
    [Collection("MultiTest")]
    public abstract class MultiTestReporter : XUnitOutputTester
        {
        /// <summary>
        /// Implement RunTests to perform all testing
        /// </summary>
        protected abstract void RunTests();

        /// <summary>
        /// Reports Exception #1, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure01()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 0);
            }


        /// <summary>
        /// Reports Exception #2, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure02()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 1);
            }


        /// <summary>
        /// Reports Exception #3, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure03()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 2);
            }


        /// <summary>
        /// Reports Exception #4, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure04()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 3);
            }


        /// <summary>
        /// Reports Exception #5, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure05()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 4);
            }


        /// <summary>
        /// Reports Exception #6, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure06()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 5);
            }


        /// <summary>
        /// Reports Exception #7, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure07()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 6);
            }


        /// <summary>
        /// Reports Exception #8, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure08()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 7);
            }


        /// <summary>
        /// Reports Exception #9, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure09()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 8);
            }


        /// <summary>
        /// Reports Exception #10, if it exists.
        /// </summary>
        [Fact]
        public void TestFailure10()
            {
            this.PerformTestsOnce();
            this.ThrowException(Number: 9);
            }

        private void ThrowException(int Number)
            {
            var Ex = _AssemblyExceptions.HasIndex(Number)
                ? _AssemblyExceptions.GetAt(Number)
                : null;

            if (Ex != null)
                throw Ex;
            }

        /// <summary>
        /// Add an exception to the list so it can be reported correctly.
        /// </summary>
        protected void AddException(Exception Ex)
            {
            if (!_AssemblyExceptions.Has(Ex2 => Ex.ToS() == Ex2.ToS()))
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

        /// <summary>
        /// MultiTestReporter constructor
        /// </summary>
        protected MultiTestReporter([NotNull] ITestOutputHelper Output) : base(Output) {}
        }
    }