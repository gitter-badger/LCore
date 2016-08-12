using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Numbers
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber))]
    public partial class ULongNumberTester : XUnitOutputTester, IDisposable
        {
        public ULongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ULongNumber.op_Implicit(UInt64) => ULongNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Add) + "(UInt64, UInt64) => UInt64")]
        public void Add_UInt64_UInt64_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Subtract) + "(UInt64, UInt64) => UInt64")]
        public void Subtract_UInt64_UInt64_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Multiply) + "(UInt64, UInt64) => UInt64")]
        public void Multiply_UInt64_UInt64_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Divide) + "(UInt64, UInt64) => Object")]
        public void Divide_UInt64_UInt64_Object()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.New) + "(UInt64) => Number`1<UInt64>")]
        public void New_UInt64_Number_1_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.New
            }

        }
    }