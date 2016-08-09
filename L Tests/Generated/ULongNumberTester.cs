using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Numbers;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Numbers
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber))]
    // ReSharper disable once InconsistentNaming
    public partial class ULongNumberTester : XUnitOutputTester
        {
        public ULongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ULongNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ULongNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.get_TypeDefaultValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Add))]
        public void Add_UInt64_UInt64_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Subtract))]
        public void Subtract_UInt64_UInt64_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Multiply))]
        public void Multiply_UInt64_UInt64_UInt64()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.Divide))]
        public void Divide_UInt64_UInt64_Object()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.New))]
        public void New_UInt64_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ULongNumber) + "." + nameof(ULongNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.ULongNumber.TypeDefaultValue
            }

        }
    }