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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber))]
    public partial class SByteNumberTester : XUnitOutputTester, IDisposable
        {
        public SByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.SByteNumber.op_Implicit")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.GetValuePrecision))]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Add))]
        public void Add_SByte_SByte_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Subtract))]
        public void Subtract_SByte_SByte_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Multiply))]
        public void Multiply_SByte_SByte_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Divide))]
        public void Divide_SByte_SByte_Object()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.New))]
        public void New_SByte_Number_1()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.New
            }

        }
    }