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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber))]
    public partial class LongNumberTester : XUnitOutputTester, IDisposable
        {
        public LongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.LongNumber.op_Implicit(Int64) => LongNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Add) + "(Int64, Int64) => Int64")]
        public void Add_Int64_Int64_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Subtract) + "(Int64, Int64) => Int64")]
        public void Subtract_Int64_Int64_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Multiply) + "(Int64, Int64) => Int64")]
        public void Multiply_Int64_Int64_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.Divide) + "(Int64, Int64) => Object")]
        public void Divide_Int64_Int64_Object()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(LongNumber) + "." + nameof(LongNumber.New) + "(Int64) => Number`1<Int64>")]
        public void New_Int64_Number_1_Int64()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.New
            }

        }
    }