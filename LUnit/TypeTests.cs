using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LCore.Extensions;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable CollectionNeverQueried.Global

namespace LCore.LUnit
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
            List<MethodInfo> TestMembers = Test.GetMembers().Select(Member => Member.DeclaringType == Test)
                .Filter<MethodInfo>();

            this.MembersPresent = TestMembers.Count();

            this.TestsMissing = TestMembers.Select(Member => Member.DeclaringType == Test)
                .WithoutAttribute<ITestAttribute>().WithoutAttribute<ITestedAttribute>().Count();

            this.UnitTestCount = TestMembers.WithAttribute<ITestedAttribute>().Count();
            this.TestsPresent = this.MembersPresent - this.TestsMissing;

            this.CoveragePercent = ((double) this.TestsPresent/this.MembersPresent).AsPercent().Abs();

            List<MemberInfo> TestedMembers = TestMembers.WithAttribute<ITestAttribute>();
            TestedMembers.AddRange(TestMembers.WithAttribute<ITestedAttribute>());

            this.TestAttributes = new List<ITestAttribute>();

            foreach (var Member in TestedMembers)
                {
                this.TestAttributes.AddRange(
                    Member.GetAttributes<ITestAttribute>(IncludeBaseTypes: false));
                }
            }
        }
    }