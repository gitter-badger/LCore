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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber))]
    public partial class FloatNumberTester : XUnitOutputTester, IDisposable
        {
        public FloatNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.FloatNumber.op_Implicit(Single) => FloatNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.Add) + "(Single, Single) => Single")]
        public void Add_Single_Single_Single()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.Subtract) + "(Single, Single) => Single")]
        public void Subtract_Single_Single_Single()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.Multiply) + "(Single, Single) => Single")]
        public void Multiply_Single_Single_Single()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.Divide) + "(Single, Single) => Object")]
        public void Divide_Single_Single_Object()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.New) + "(Single) => Number`1<Single>")]
        public void New_Single_Number_1_Single()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.New
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(FloatNumber) + "." + nameof(FloatNumber.ToString) + "() => String")]
        public new void ToString()
            {
            // TODO: Implement method test LCore.Numbers.FloatNumber.ToString
            }

        }
    }