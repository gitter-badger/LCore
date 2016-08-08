using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    public class ExceptionListTester : XUnitOutputTester
        {
        public ExceptionListTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~ExceptionListTester()
            {
            }

        [Fact]
        public void op_Implicit_ExceptionList_Exception()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        public void op_Implicit_Exception_ExceptionList()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        public void op_Implicit_ExceptionList_List_1()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        [Fact]
        public void op_Implicit_List_1_ExceptionList()
            {
            // TODO: Implement method test LCore.Tools.ExceptionList.op_Implicit
            }

        }
    }