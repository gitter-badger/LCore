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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber))]
    public partial class IntNumberTester : XUnitOutputTester, IDisposable
        {
        public IntNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.IntNumber.op_Implicit(Int32) => IntNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Add) + "(Int32, Int32) => Int32")]
        public void Add_Int32_Int32_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Subtract) + "(Int32, Int32) => Int32")]
        public void Subtract_Int32_Int32_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Multiply) + "(Int32, Int32) => Int32")]
        public void Multiply_Int32_Int32_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.Divide) + "(Int32, Int32) => Object")]
        public void Divide_Int32_Int32_Object()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(IntNumber) + "." + nameof(IntNumber.New) + "(Int32) => Number`1<Int32>")]
        public void New_Int32_Number_1_Int32()
            {
            // TODO: Implement method test LCore.Numbers.IntNumber.New
            }

        }
    }