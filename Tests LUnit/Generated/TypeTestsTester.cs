using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests))]
    public partial class TypeTestsTester : XUnitOutputTester
        {
        public TypeTestsTester(ITestOutputHelper Output) : base(Output) { }

        ~TypeTestsTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.TestAttributes))]
        public void get_TestAttributes()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.get_TestAttributes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.CoveragePercent))]
        public void get_CoveragePercent()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.get_CoveragePercent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.TestsPresent))]
        public void get_TestsPresent()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.get_TestsPresent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.UnitTestCount))]
        public void get_UnitTestCount()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.get_UnitTestCount
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.TestsMissing))]
        public void get_TestsMissing()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.get_TestsMissing
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.MembersPresent))]
        public void get_MembersPresent()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.get_MembersPresent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.TestAttributes))]
        public void TestAttributes()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.TestAttributes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.CoveragePercent))]
        public void CoveragePercent()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.CoveragePercent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.TestsPresent))]
        public void TestsPresent()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.TestsPresent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.UnitTestCount))]
        public void UnitTestCount()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.UnitTestCount
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.TestsMissing))]
        public void TestsMissing()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.TestsMissing
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(TypeTests) + "." + nameof(TypeTests.MembersPresent))]
        public void MembersPresent()
            {
            // TODO: Implement method test LCore.LUnit.TypeTests.MembersPresent
            }

        }
    }