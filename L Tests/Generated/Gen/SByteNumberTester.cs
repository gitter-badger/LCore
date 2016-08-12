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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber))]
    public partial class SByteNumberTester : XUnitOutputTester, IDisposable
        {
        public SByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.SByteNumber.op_Implicit(SByte) => SByteNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Add) + "(SByte, SByte) => SByte")]
        public void Add_SByte_SByte_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Subtract) + "(SByte, SByte) => SByte")]
        public void Subtract_SByte_SByte_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Multiply) + "(SByte, SByte) => SByte")]
        public void Multiply_SByte_SByte_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.Divide) + "(SByte, SByte) => Object")]
        public void Divide_SByte_SByte_Object()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(SByteNumber) + "." + nameof(SByteNumber.New) + "(SByte) => Number`1<SByte>")]
        public void New_SByte_Number_1_SByte()
            {
            // TODO: Implement method test LCore.Numbers.SByteNumber.New
            }

        }
    }