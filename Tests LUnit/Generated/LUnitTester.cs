using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit))]
    public partial class LUnitTester : XUnitOutputTester
        {
        public LUnitTester(ITestOutputHelper Output) : base(Output) {}

        ~LUnitTester() {}

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." +
            nameof(global::LCore.LUnit.LUnit.FixParameterTypes))]
        public void FixParameterTypes()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.FixParameterTypes
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." +
            nameof(global::LCore.LUnit.LUnit.FixObject))]
        public void FixObject()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.FixObject
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." +
            nameof(global::LCore.LUnit.LUnit.GetMethodDelegate))]
        public void GetMethodDelegate()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.GetMethodDelegate
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." +
            nameof(global::LCore.LUnit.LUnit.GetCheckMethod))]
        public void GetCheckMethod()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.GetCheckMethod
            }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." +
            nameof(global::LCore.LUnit.LUnit.GetCheckMethodArg))]
        public void GetCheckMethodArg()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.GetCheckMethodArg
            }
        }
    }