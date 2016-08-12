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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber))]
    public partial class DecimalNumberTester : XUnitOutputTester, IDisposable
        {
        public DecimalNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.DecimalNumber.op_Implicit(Decimal) => DecimalNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Add) + "(Decimal, Decimal) => Decimal")]
        public void Add_Decimal_Decimal_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Subtract) + "(Decimal, Decimal) => Decimal")]
        public void Subtract_Decimal_Decimal_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Multiply) + "(Decimal, Decimal) => Decimal")]
        public void Multiply_Decimal_Decimal_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.Divide) + "(Decimal, Decimal) => Object")]
        public void Divide_Decimal_Decimal_Object()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.New) + "(Decimal) => Number`1<Decimal>")]
        public void New_Decimal_Number_1_Decimal()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(DecimalNumber) + "." + nameof(DecimalNumber.ToString) + "() => String")]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Numbers.DecimalNumber.ToString
            }

        }
    }