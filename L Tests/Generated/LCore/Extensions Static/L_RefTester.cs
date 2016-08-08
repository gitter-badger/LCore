using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_RefTester : XUnitOutputTester
        {
        public L_RefTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~L_RefTester()
            {
            }

        [Fact]
        public void Constant()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Constant
            }

        [Fact]
        public void Constructor()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Constructor
            }

        [Fact]
        public void FindType()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.FindType
            }

        [Fact]
        public void FindMember()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.FindMember
            }

        [Fact]
        public void GetNamespaceTypes_String_Type_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        public void GetNamespaceTypes_Type_String_Type_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        public void GetNamespaceTypes_Assembly_String_Type_Type()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.GetNamespaceTypes
            }

        [Fact]
        public void Member()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Member
            }

        [Fact]
        public void Method()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Method
            }

        [Fact]
        public void StaticMethod()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.StaticMethod
            }

        [Fact]
        public void Event()
            {
            // TODO: Implement method test LCore.Extensions.L.Ref.Event
            }

        }
    }