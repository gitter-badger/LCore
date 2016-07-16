using System;
using FluentAssertions;
using Xunit;

namespace L_MVC_Tests
    {
    public class UnitTest1
        {
        [Fact]
        public void TestMethod1()
            {
            Singularity.Singularity.AppName.Should().Be("Singularity");
            }
        }
    }
