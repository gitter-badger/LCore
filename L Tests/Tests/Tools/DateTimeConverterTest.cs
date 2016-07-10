using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tests;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L_Tests.Tests.Tools
    {
    [TestClass]
    public class DateTimeConverterTest
        {
        [TestMethod]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_DateTimeConverter()
            {
            // ReSharper disable StringLiteralTypo
            DateTimeConverter.Rfc3339DateTimeFormat.Should().Be("yyyy-MM-dd'T'HH:mm:ss.fffK");
            DateTimeConverter.Rfc3339DateTimePatterns.ShouldBeEquivalentTo(new[]
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

            DateTimeConverter.TryParse(Str, out Test).Should().BeTrue();

            Test.Ticks.Should().BeInRange(Date.Ticks - 150000, Date.Ticks + 150000);

            // Works without universal time conversion
            Date = DateTime.Now;

            Str = DateTimeConverter.ToString(Date);

            DateTimeConverter.TryParse(Str, out Test).Should().BeTrue();

            Test.Ticks.Should().BeInRange(Date.ToUniversalTime().Ticks - 150000, Date.ToUniversalTime().Ticks + 150000);

            DateTimeConverter.Parse(Str).Ticks.Should()
                .BeInRange(Date.ToUniversalTime().Ticks - 150000, Date.ToUniversalTime().Ticks + 150000);

            L.A(() => DateTimeConverter.Parse(null)).ShouldFail();
            L.A(() => DateTimeConverter.Parse("nope not a date")).ShouldFail();
            }
        }
    }