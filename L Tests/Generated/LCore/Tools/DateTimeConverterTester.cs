using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    public class DateTimeConverterTester : XUnitOutputTester
        {
        public DateTimeConverterTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~DateTimeConverterTester()
            {
            }

        [Fact]
        public void Parse()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.Parse
            }

        [Fact]
        public void ToString_DateTime_String()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.ToString
            }

        [Fact]
        public void TryParse()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.TryParse
            }

        [Fact]
        public void get_Rfc3339DateTimeFormat()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.get_Rfc3339DateTimeFormat
            }

        [Fact]
        public void get_Rfc3339DateTimePatterns()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.get_Rfc3339DateTimePatterns
            }

        }
    }