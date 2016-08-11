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
    public partial class LongNumberTester : XUnitOutputTester, IDisposable
        {
        public LongNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.LongNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.LongNumber.op_Implicit
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

        }
    }