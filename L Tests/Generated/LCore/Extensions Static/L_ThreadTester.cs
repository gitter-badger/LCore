using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_ThreadTester : XUnitOutputTester
        {
        public L_ThreadTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~L_ThreadTester()
            {
            }

        [Fact]
        public void MethodProfileData_Get()
            {
            // TODO: Implement method Test LCore.Extensions.L.Thread.MethodProfileData_Get
            }

        [Fact]
        public void MethodProfileData_Remove()
            {
            // TODO: Implement method Test LCore.Extensions.L.Thread.MethodProfileData_Remove
            }

        [Fact]
        public void MethodProfileData_Add()
            {
            // TODO: Implement method Test LCore.Extensions.L.Thread.MethodProfileData_Add
            }

        [Fact]
        public void MethodProfileData_Has()
            {
            // TODO: Implement method Test LCore.Extensions.L.Thread.MethodProfileData_Has
            }

        }
    }