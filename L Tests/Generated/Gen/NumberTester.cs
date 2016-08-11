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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number))]
    public partial class NumberTester : XUnitOutputTester, IDisposable
        {
        public NumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Equals))]
        public void Equals()
            {
            // TODO: Implement method test LCore.Numbers.Number.Equals
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.ToString))]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Numbers.Number.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThan")]
        public void op_GreaterThan()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_GreaterThan
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThan")]
        public void op_LessThan()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_LessThan
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThanOrEqual")]
        public void op_GreaterThanOrEqual()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_GreaterThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThanOrEqual")]
        public void op_LessThanOrEqual()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_LessThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Equality")]
        public void op_Equality()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Equality
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Inequality")]
        public void op_Inequality()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Inequality
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetHashCode))]
        public new void GetHashCode()
            {
            // TODO: Implement method test LCore.Numbers.Number.GetHashCode
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division")]
        public void op_Division_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Division
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division")]
        public void op_Division_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Division
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply")]
        public void op_Multiply_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply")]
        public void op_Multiply_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction")]
        public void op_Subtraction_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Subtraction
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction")]
        public void op_Subtraction_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Subtraction
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition")]
        public void op_Addition_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Addition
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition")]
        public void op_Addition_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Addition
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.CompareTo))]
        public void CompareTo()
            {
            // TODO: Implement method test LCore.Numbers.Number.CompareTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.New))]
        public void New()
            {
            // TODO: Implement method test LCore.Numbers.Number.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Divide))]
        public void Divide_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Multiply))]
        public void Multiply_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Subtract))]
        public void Subtract_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Add))]
        public void Add_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Divide))]
        public void Divide_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Multiply))]
        public void Multiply_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Subtract))]
        public void Subtract_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Add))]
        public void Add_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.Number.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetValue))]
        public void GetValue()
            {
            // TODO: Implement method test LCore.Numbers.Number.GetValue
            }

        }
    }