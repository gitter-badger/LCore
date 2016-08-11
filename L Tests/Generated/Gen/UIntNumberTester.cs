using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Numbers
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber))]
    public partial class UIntNumberTester : XUnitOutputTester, IDisposable
        {
        public UIntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.UIntNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Add))]
        public void Add_UInt32_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Subtract))]
        public void Subtract_UInt32_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Multiply))]
        public void Multiply_UInt32_UInt32_UInt32()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.Divide))]
        public void Divide_UInt32_UInt32_Object()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.New))]
        public void New_UInt32_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.New
            }

        }
    }