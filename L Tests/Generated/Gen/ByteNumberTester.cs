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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber))]
    public partial class ByteNumberTester : XUnitOutputTester, IDisposable
        {
        public ByteNumberTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Numbers.ByteNumber.op_Implicit(Byte) => ByteNumber")]
        public void op_Implicit()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." + nameof(ByteNumber.GetValuePrecision) + "() => Number")]
        public void GetValuePrecision()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.GetValuePrecision
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." + nameof(ByteNumber.Add) + "(Byte, Byte) => Byte")]
        public void Add_Byte_Byte_Byte()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.Add
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." + nameof(ByteNumber.Subtract) + "(Byte, Byte) => Byte")]
        public void Subtract_Byte_Byte_Byte()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.Subtract
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." + nameof(ByteNumber.Multiply) + "(Byte, Byte) => Byte")]
        public void Multiply_Byte_Byte_Byte()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.Multiply
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." + nameof(ByteNumber.Divide) + "(Byte, Byte) => Object")]
        public void Divide_Byte_Byte_Object()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.Divide
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Numbers) + "." + nameof(ByteNumber) + "." + nameof(ByteNumber.New) + "(Byte) => Number`1<Byte>")]
        public void New_Byte_Number_1_Byte()
            {
            // TODO: Implement method test LCore.Numbers.ByteNumber.New
            }

        }
    }