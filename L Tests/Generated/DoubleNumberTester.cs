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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber))]
    public partial class DoubleNumberTester : XUnitOutputTester
        {
        public DoubleNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~DoubleNumberTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.DoubleNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypePrecision))]
        public void get_TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.get_TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypeMinValue))]
        public void get_TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.get_TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypeMaxValue))]
        public void get_TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.get_TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypeDefaultValue))]
        public void get_TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.get_TypeDefaultValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Add))]
        public void Add_Double_Double_Double()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Subtract))]
        public void Subtract_Double_Double_Double()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Multiply))]
        public void Multiply_Double_Double_Double()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.Divide))]
        public void Divide_Double_Double_Object()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.New))]
        public void New_Double_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.ToString))]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypePrecision))]
        public void TypePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.TypePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypeMinValue))]
        public void TypeMinValue()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.TypeMinValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypeMaxValue))]
        public void TypeMaxValue()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.TypeMaxValue
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DoubleNumber) + "." + nameof(DoubleNumber.TypeDefaultValue))]
        public void TypeDefaultValue()
            {
            // TODO: Implement method test LCore.Numbers.DoubleNumber.TypeDefaultValue
            }

        }
    }