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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber))]
    public partial class LongNumberTester : XUnitOutputTester
        {
        public LongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~LongNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.LongNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.get_TypeDefaultValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Add))]
        public void Add_Int64_Int64_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Subtract))]
        public void Subtract_Int64_Int64_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Multiply))]
        public void Multiply_Int64_Int64_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Divide))]
        public void Divide_Int64_Int64_Object()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.New))]
        public void New_Int64_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.TypeDefaultValue
            }

        }
    }