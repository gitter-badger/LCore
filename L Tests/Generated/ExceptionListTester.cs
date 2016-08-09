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
    public partial class ExceptionListTester : XUnitOutputTester
        {
        public ExceptionListTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ExceptionListTester() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit")]
        public void op_Implicit_ExceptionList_Exception()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit")]
        public void op_Implicit_Exception_ExceptionList()
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

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList) + "." + nameof(ExceptionList.Exceptions))]
        public void get_Exceptions()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.get_Exceptions
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList) + "." + nameof(ExceptionList.Message))]
        public void get_Message()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.get_Message
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList) + "." + nameof(ExceptionList.StackTrace))]
        public void get_StackTrace()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.get_StackTrace
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList) + "." + nameof(ExceptionList.Exceptions))]
        public void Exceptions()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.Exceptions
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList) + "." + nameof(ExceptionList.Message))]
        public void Message()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.Message
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList) + "." + nameof(ExceptionList.StackTrace))]
        public void StackTrace()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.StackTrace
            }

        }
    }