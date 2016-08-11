using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList))]
    public partial class ExceptionListTester : XUnitOutputTester, IDisposable
        {
        public ExceptionListTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit")]
        public void op_Implicit_ExceptionList_Exception()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit")]
        public void op_Implicit_ExceptionArray_ExceptionList()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit")]
        public void op_Implicit_ExceptionList_List_1()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit")]
        public void op_Implicit_List_1_ExceptionList()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        }
    }