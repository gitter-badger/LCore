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
        public void get_Rfc3339DateTimeFormat()
            {
            // TODO: Implement method Test LCore.Tools.DateTimeConverter.get_Rfc3339DateTimeFormat
            }

        [Fact]
        public void get_Rfc3339DateTimePatterns()
            {
            // TODO: Implement method Test LCore.Tools.DateTimeConverter.get_Rfc3339DateTimePatterns
            }

        }
    }