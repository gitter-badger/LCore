using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class ConvertibleExtTester : XUnitOutputTester
        {
        public ConvertibleExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~ConvertibleExtTester() { }

        [Fact]
        public void CanConvertTo_IConvertible_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertTo
            }

        [Fact]
        public void CanConvertTo_IConvertible_Type_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertTo
            }

        [Fact]
        public void CanConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.CanConvertToString
            }

        [Fact]
        public void ConvertTo_IConvertible_Type_Object()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertTo
            }

        [Fact]
        public void ConvertTo_IConvertible_Nullable_1()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertTo
            }

        [Fact]
        public void ConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.ConvertToString
            }

        [Fact]
        public void TryConvertTo()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.TryConvertTo
            }

        [Fact]
        public void TryConvertToString()
            {
            // TODO: Implement method test LCore.Extensions.ConvertibleExt.TryConvertToString
            }

        }
    }