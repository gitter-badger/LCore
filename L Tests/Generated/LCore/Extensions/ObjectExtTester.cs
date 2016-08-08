using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class ObjectExtTester : XUnitOutputTester
        {
        public ObjectExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ObjectExtTester()
            {
            }

        [Fact]
        public void HasProperty()
            {
            // TODO: Implement method Test LCore.Extensions.ObjectExt.HasProperty
            }

        [Fact]
        public void Objects_ToString()
            {
            // TODO: Implement method Test LCore.Extensions.ObjectExt.Objects_ToString
            }

        [Fact]
        public void Type()
            {
            // TODO: Implement method Test LCore.Extensions.ObjectExt.Type
            }

        }
    }

namespace L_Tests.LCore.Extensions.Optional
    {
    public class ObjectExtTester
        {
        public ObjectExtTester()
            {
            }

        ~ObjectExtTester()
            {
            }

        [Fact]
        public void IsNull()
            {
            // TODO: Implement method Test LCore.Extensions.Optional.ObjectExt.IsNull
            }

        }
    }