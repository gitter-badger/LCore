using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LCore.Extensions;
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable CollectionNeverQueried.Global

namespace LCore.Tests
    {
    public class TypeTests
        {
        public List<ITestAttribute> TestAttributes { get; set; }

        public int CoveragePercent { get; set; }

        public int TestsPresent { get; set; }

        public int UnitTestCount { get; set; }

        public int TestsMissing { get; set; }

        public int MembersPresent { get; set; }

        public TypeTests(Type Test)
            {
            IEnumerable<MemberInfo> TestMembers = Test.GetMembers().Where(m => m.DeclaringType == Test);
            this.MembersPresent = TestMembers.Count();

            this.TestsMissing = TestMembers.Where(m => m.DeclaringType == Test)
                .WithoutAttribute<ITestAttribute>().Count();

            this.UnitTestCount = TestMembers.WithAttribute<TestedAttribute>().Count();
            this.TestsPresent = this.MembersPresent - this.TestsMissing;

            this.CoveragePercent = ((double)this.TestsPresent / this.MembersPresent).AsPercent();

            IEnumerable<MemberInfo> TestedMembers = TestMembers.WithAttribute<ITestAttribute>();
            this.TestAttributes = new List<ITestAttribute>();

            foreach (var Member in TestedMembers)
                {
                this.TestAttributes.AddRange(Member.GetAttributes<ITestAttribute>(false));
                }
            }
        }
    }