using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LCore.Extensions;
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable CollectionNeverQueried.Global

namespace LCore.Tests
    {
    /// <summary>
    /// TypeTests contains data about a class and its unit test coverage.
    /// </summary>
    public class TypeTests
        {
        /// <summary>
        /// All Attributes of type ITestAttribute declared on the Type
        /// </summary>
        public List<ITestAttribute> TestAttributes { get; protected set; }

        /// <summary>
        /// An int from 0 to 100, the percentage of test coverage for the Type.
        /// </summary>
        public uint CoveragePercent { get; protected set; }

        /// <summary>
        /// The total number of tests present
        /// </summary>
        public uint TestsPresent { get; protected set; }

        /// <summary>
        /// The total number of unit tests (non-attribute tests)
        /// </summary>
        public uint UnitTestCount { get; protected set; }

        /// <summary>
        /// The number of members missing tests
        /// </summary>
        public uint TestsMissing { get; protected set; }

        /// <summary>
        /// The total number of testable members
        /// </summary>
        public uint MembersPresent { get; protected set; }

        /// <summary>
        /// Creating a TypeTests object for a type will scan it and 
        /// return information about the total unit test coverage.
        /// </summary>
        public TypeTests(Type Test)
            {
            IEnumerable<MemberInfo> TestMembers = Test.GetMembers().Select(Member => Member.DeclaringType == Test);
            this.MembersPresent = TestMembers.Count();

            this.TestsMissing = TestMembers.Select(Member => Member.DeclaringType == Test)
                .WithoutAttribute<ITestAttribute>().Count();

            this.UnitTestCount = TestMembers.WithAttribute<TestedAttribute>().Count();
            this.TestsPresent = this.MembersPresent - this.TestsMissing;

            this.CoveragePercent = ((double)this.TestsPresent / this.MembersPresent).AsPercent().Abs();

            IEnumerable<MemberInfo> TestedMembers = TestMembers.WithAttribute<ITestAttribute>();
            this.TestAttributes = new List<ITestAttribute>();

            foreach (var Member in TestedMembers)
                {
                this.TestAttributes.AddRange(
                    Member.GetAttributes<ITestAttribute>(false));
                }
            }
        }
    }