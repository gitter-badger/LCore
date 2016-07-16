using System;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace L_Tests.Tests.Tools
    {
    public class SetTest
        {
        [Fact]
        [TestCategory(L.Test.Categories.Tools)]
        public void TestSets()
            {
            var Test = new Set<int, string>(5, "4");

            Test.Obj1.Should().Be(5);
            Test.Obj2.Should().Be("4");

            var Test2 = new Set<int?, string>(null, null);

            Test2.Obj1.Should().Be(null);
            Test2.Obj2.Should().Be(null);
            }
        }
    }
