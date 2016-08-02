using LCore.Extensions;
using System;
using FluentAssertions;
using Xunit;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    public class StrTest
        {
        [Fact]
        public void Test_L_Str()
            {
            L.Str.Empty().Should().Be("");
            }
        }
    }