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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber))]
    public partial class ShortNumberTester : XUnitOutputTester
        {
        public ShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ShortNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ShortNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.get_TypeDefaultValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Add))]
        public void Add_Int16_Int16_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Subtract))]
        public void Subtract_Int16_Int16_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Multiply))]
        public void Multiply_Int16_Int16_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Divide))]
        public void Divide_Int16_Int16_Object()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.New))]
        public void New_Int16_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.TypeDefaultValue
            }

        }
    }