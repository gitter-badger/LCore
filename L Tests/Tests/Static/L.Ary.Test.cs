﻿using LCore.Extensions;
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
    public class AryTest
        {
        [Fact]
        public void Test_Array()
            {
            L.Ary.Array<int>()().Should().BeOfType<int[]>().And.Subject.ToS().Should().Be("System.Int32[] {  }");
            L.Ary.Array<string>()().Should().BeOfType<string[]>().And.Subject.ToS().Should().Be("System.String[] {  }");
            }
        }
    }