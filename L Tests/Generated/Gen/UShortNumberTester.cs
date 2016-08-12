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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber))]
    public partial class UShortNumberTester : XUnitOutputTester, IDisposable
        {
        public UShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.UShortNumber.op_Implicit(UInt16) => UShortNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Add) + "(UInt16, UInt16) => UInt16")]
        public void Add_UInt16_UInt16_UInt16()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Subtract) + "(UInt16, UInt16) => UInt16")]
        public void Subtract_UInt16_UInt16_UInt16()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Multiply) + "(UInt16, UInt16) => UInt16")]
        public void Multiply_UInt16_UInt16_UInt16()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.Divide) + "(UInt16, UInt16) => Object")]
        public void Divide_UInt16_UInt16_Object()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(UShortNumber) + "." + nameof(UShortNumber.New) + "(UInt16) => Number`1<UInt16>")]
        public void New_UInt16_Number_1_UInt16()
            {
            // TODO: Implement method test LCore.Numbers.UShortNumber.New
            }

        }
    }