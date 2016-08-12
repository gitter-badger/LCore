using System;
using System.Collections;
using System.Collections.Generic;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace LUnit_Tests.LCore.LUnit
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit))]
    public partial class LUnitTester : XUnitOutputTester, IDisposable
        {
        public LUnitTester(ITestOutputHelper Output) : base(Output) {}

        public void Dispose() {}

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." + nameof(global::LCore.LUnit.LUnit.FixParameterTypes) + "(MethodInfo, Object[])")]
        public void FixParameterTypes()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.FixParameterTypes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." + nameof(global::LCore.LUnit.LUnit.FixObject) + "(MethodInfo, Type, Object&)")]
        public void FixObject()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.FixObject
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." + nameof(global::LCore.LUnit.LUnit.GetMethodDelegate) + "(MethodInfo, Type, String) => Object")]
        public void GetMethodDelegate()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.GetMethodDelegate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." + nameof(global::LCore.LUnit.LUnit.GetCheckMethod) + "(MethodInfo, String) => Func`1<Boolean>")]
        public void GetCheckMethod()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.GetCheckMethod
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.LUnit) + "." + nameof(global::LCore.LUnit.LUnit) + "." + nameof(global::LCore.LUnit.LUnit.GetCheckMethodArg) + "(MethodInfo, String) => Func`2<Object, Boolean>")]
        public void GetCheckMethodArg()
            {
            // TODO: Implement method test LCore.LUnit.LUnit.GetCheckMethodArg
            }
        }
    }