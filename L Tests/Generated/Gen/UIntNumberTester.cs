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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber))]
    public partial class UIntNumberTester : XUnitOutputTester, IDisposable
        {
        public UIntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.UIntNumber.op_Implicit(UInt32) => UIntNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Add) + "(UInt32, UInt32) => UInt32")]
        public void Add_UInt32_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Subtract) + "(UInt32, UInt32) => UInt32")]
        public void Subtract_UInt32_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Multiply) + "(UInt32, UInt32) => UInt32")]
        public void Multiply_UInt32_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Divide) + "(UInt32, UInt32) => Object")]
        public void Divide_UInt32_UInt32_Object()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.New) + "(UInt32) => Number`1<UInt32>")]
        public void New_UInt32_Number_1_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.New
            }

        }
    }