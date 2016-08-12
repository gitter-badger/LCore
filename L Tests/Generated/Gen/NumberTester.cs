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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number))]
    public partial class NumberTester : XUnitOutputTester, IDisposable
        {
        public NumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Equals) + "(Object) => Boolean")]
        public void Equals()
            {
            // TODO: Implement method test LCore.Numbers.Number.Equals
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.ToString) + "() => String")]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Numbers.Number.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThan(Number, IComparable) => Boolean")]
        public void op_GreaterThan()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_GreaterThan
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThan(Number, IComparable) => Boolean")]
        public void op_LessThan()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_LessThan
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_GreaterThanOrEqual(Number, IComparable) => Boolean")]
        public void op_GreaterThanOrEqual()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_GreaterThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_LessThanOrEqual(Number, IComparable) => Boolean")]
        public void op_LessThanOrEqual()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_LessThanOrEqual
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Equality(Number, IComparable) => Boolean")]
        public void op_Equality()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Equality
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Inequality(Number, IComparable) => Boolean")]
        public void op_Inequality()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Inequality
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetHashCode) + "() => Int32")]
        public new void GetHashCode()
            {
            // TODO: Implement method test LCore.Numbers.Number.GetHashCode
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, IConvertible) => Number")]
        public void op_Division_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Division
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Division(Number, Number) => Number")]
        public void op_Division_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Division
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, IConvertible) => Number")]
        public void op_Multiply_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Multiply(Number, Number) => Number")]
        public void op_Multiply_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, IConvertible) => Number")]
        public void op_Subtraction_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Subtraction
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Subtraction(Number, Number) => Number")]
        public void op_Subtraction_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Subtraction
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, IConvertible) => Number")]
        public void op_Addition_Number_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Addition
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.Number.op_Addition(Number, Number) => Number")]
        public void op_Addition_Number_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.op_Addition
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.CompareTo) + "(Object) => Int32")]
        public void CompareTo()
            {
            // TODO: Implement method test LCore.Numbers.Number.CompareTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.New) + "(Object) => Number")]
        public void New()
            {
            // TODO: Implement method test LCore.Numbers.Number.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Divide) + "(Number) => Number")]
        public void Divide_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Multiply) + "(Number) => Number")]
        public void Multiply_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Subtract) + "(Number) => Number")]
        public void Subtract_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Add) + "(Number) => Number")]
        public void Add_Number_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Divide) + "(IConvertible) => Number")]
        public void Divide_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Multiply) + "(IConvertible) => Number")]
        public void Multiply_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Subtract) + "(IConvertible) => Number")]
        public void Subtract_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.Add) + "(IConvertible) => Number")]
        public void Add_IConvertible_Number()
            {
            // TODO: Implement method test LCore.Numbers.Number.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.Number.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(Number) + "." + nameof(Number.GetValue) + "() => Object")]
        public void GetValue()
            {
            // TODO: Implement method test LCore.Numbers.Number.GetValue
            }

        }
    }