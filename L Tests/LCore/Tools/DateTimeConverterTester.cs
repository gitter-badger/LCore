using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter))]
    public partial class DateTimeConverterTester : XUnitOutputTester, IDisposable
        {
        public DateTimeConverterTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Parse) + "(String) => DateTime")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.ToString) + "(DateTime) => String")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.TryParse) + "(String, DateTime&) => Boolean")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Rfc3339DateTimeFormat))]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(DateTimeConverter) + "." + nameof(DateTimeConverter.Rfc3339DateTimePatterns))]
        public void TestAll()
            {
            // ReSharper disable StringLiteralTypo
            DateTimeConverter.Rfc3339DateTimeFormat.ShouldBe("yyyy-MM-dd'T'HH:mm:ss.fffK");
            // ReSharper disable once RedundantExplicitParamsArrayCreation
            DateTimeConverter.Rfc3339DateTimePatterns.Should().Equal(new[]
                {
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffffK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ssK",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK",
                "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
                });
            // ReSharper restore StringLiteralTypo
            var Date = DateTime.Now.ToUniversalTime();
            string Str = DateTimeConverter.ToString(Date);

            DateTime Test;

            DateTimeConverter.TryParse(Str, out Test).ShouldBeTrue();

            Test.Ticks.Should().BeInRange(Date.Ticks - 150000, Date.Ticks + 150000);

            // Works without universal time conversion
            Date = DateTime.Now;

            Str = DateTimeConverter.ToString(Date);

            DateTimeConverter.TryParse(Str, out Test).ShouldBeTrue();

            Test.Ticks.Should().BeInRange(Date.ToUniversalTime().Ticks - 150000, Date.ToUniversalTime().Ticks + 150000);

            DateTimeConverter.Parse(Str).Ticks.Should()
                .BeInRange(Date.ToUniversalTime().Ticks - 150000, Date.ToUniversalTime().Ticks + 150000);

            L.A(() => DateTimeConverter.Parse(Str: null)).ShouldFail();
            L.A(() => DateTimeConverter.Parse("nope not a date")).ShouldFail();
            }
        }
    }