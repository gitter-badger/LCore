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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber))]
    public partial class DecimalNumberTester : XUnitOutputTester
        {
        public DecimalNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~DecimalNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.DecimalNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.get_TypeDefaultValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Add))]
        public void Add_Decimal_Decimal_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Subtract))]
        public void Subtract_Decimal_Decimal_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Multiply))]
        public void Multiply_Decimal_Decimal_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Divide))]
        public void Divide_Decimal_Decimal_Object()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.New))]
        public void New_Decimal_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.ToString))]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.TypeDefaultValue
            }

        }
    }