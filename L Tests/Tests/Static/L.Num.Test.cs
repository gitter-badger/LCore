using LCore.Extensions;
using System;
using FluentAssertions;
using LCore.Extensions.Optional;
using Xunit;
using static LCore.Extensions.L.Test.Categories;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, StaticMethods)]
    public class NumTest
        {
        [Fact]
        public void Test_ScientificNotationToNumber()
            {
            L.Num.ScientificNotationToNumber("nope not a number").Should().Be("nope not a number");
            L.Num.ScientificNotationToNumber("553e10").Should().Be("5530000000000");
            L.Num.ScientificNotationToNumber("553e0").Should().Be("553");
            L.Num.ScientificNotationToNumber("553.1e1").Should().Be("5531");
            L.Num.ScientificNotationToNumber("3.00053e10").Should().Be("30005300000");
            L.Num.ScientificNotationToNumber("1.0e5").Should().Be("100000");
            L.Num.ScientificNotationToNumber("1.0e-5").Should().Be("0.00001");
            L.Num.ScientificNotationToNumber("1.0e0").Should().Be("1");
            L.Num.ScientificNotationToNumber("5.0e-1").Should().Be("0.5");



            //L.Num.ScientificNotationToNumber("1e5").Should().Be("100000");
            //L.Num.ScientificNotationToNumber("1e0").Should().Be("1");
            //L.Num.ScientificNotationToNumber("1e").Should().Be("1e");
            }
        }
    }