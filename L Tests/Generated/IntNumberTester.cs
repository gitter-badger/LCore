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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber))]
    public partial class IntNumberTester : XUnitOutputTester
        {
        public IntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~IntNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.IntNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.get_TypeDefaultValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Add))]
        public void Add_Int32_Int32_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Subtract))]
        public void Subtract_Int32_Int32_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Multiply))]
        public void Multiply_Int32_Int32_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Divide))]
        public void Divide_Int32_Int32_Object()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.New))]
        public void New_Int32_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.TypeDefaultValue
            }

        }
    }