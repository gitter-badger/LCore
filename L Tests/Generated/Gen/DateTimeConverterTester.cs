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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter))]
    public partial class DateTimeConverterTester : XUnitOutputTester
        {
        public DateTimeConverterTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~DateTimeConverterTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Rfc3339DateTimeFormat))]
        public void get_Rfc3339DateTimeFormat()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.get_Rfc3339DateTimeFormat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Rfc3339DateTimePatterns))]
        public void get_Rfc3339DateTimePatterns()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.get_Rfc3339DateTimePatterns
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Parse))]
        public void Parse()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.Parse
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.ToString))]
        public void ToString_DateTime_String()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.ToString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.TryParse))]
        public void TryParse()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.TryParse
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Rfc3339DateTimeFormat))]
        public void Rfc3339DateTimeFormat()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.Rfc3339DateTimeFormat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Rfc3339DateTimePatterns))]
        public void Rfc3339DateTimePatterns()
            {
            // TODO: Implement method test LCore.Tools.DateTimeConverter.Rfc3339DateTimePatterns
            }

        }
    }