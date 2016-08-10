using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable InconsistentNaming

namespace L_Tests.LCore.Numbers
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber))]
    public partial class UIntNumberTester : XUnitOutputTester
        {
        public UIntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~UIntNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.UIntNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.get_TypeDefaultValue
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

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UIntNumber) + "." + nameof(UIntNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.UIntNumber.TypeDefaultValue
            }

        }
    }