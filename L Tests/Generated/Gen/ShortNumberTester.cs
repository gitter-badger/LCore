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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber))]
    public partial class ShortNumberTester : XUnitOutputTester, IDisposable
        {
        public ShortNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ShortNumber.op_Implicit(Int16) => ShortNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Add) + "(Int16, Int16) => Int16")]
        public void Add_Int16_Int16_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Subtract) + "(Int16, Int16) => Int16")]
        public void Subtract_Int16_Int16_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Multiply) + "(Int16, Int16) => Int16")]
        public void Multiply_Int16_Int16_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.Divide) + "(Int16, Int16) => Object")]
        public void Divide_Int16_Int16_Object()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ShortNumber) + "." + nameof(ShortNumber.New) + "(Int16) => Number`1<Int16>")]
        public void New_Int16_Number_1_Int16()
            {
            // TODO: Implement method test LCore.Numbers.ShortNumber.New
            }

        }
    }