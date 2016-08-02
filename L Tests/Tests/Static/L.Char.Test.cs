using LCore.Extensions;
using System;
using FluentAssertions;
using Xunit;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    public class CharTest
        {

        [Fact]
        public void Test_CharConstants()
            {
            L.Char.LowerCaseChars.Length.Should().Be(26);
            L.Char.UpperCaseChars.Length.Should().Be(26);
            L.Char.NumberChars.Length.Should().Be(10);
            L.Char.SpecialChars.Length.Should().BeGreaterOrEqualTo(10);
            }
        }
    }