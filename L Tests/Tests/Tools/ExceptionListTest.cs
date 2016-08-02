using System;
using System.Collections.Generic;
using FluentAssertions;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

// ReSharper disable RedundantAssignment
// ReSharper disable RedundantCast

// ReSharper disable NotResolvedInText

namespace L_Tests.Tests.Tools
    {
    public class ExceptionListTest
        {
        [Fact]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_ExceptionList()
            {
            var Ex = new ExceptionList(new[]
                {
                new Exception("1"),
                new ArgumentNullException("2"),
                new FormatException("3")
                });

            Ex.Exceptions.ToS().Should().Be(
                "System.Collections.Generic.List`1[[System.Exception, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] { System.Exception: 1, System.ArgumentNullException: Value cannot be null.\r\nParameter name: 2, System.FormatException: 3 }");

            Ex.StackTrace.Should().Be("");

            Ex.ToString().Should().Be("LCore.Tools.ExceptionList: 1\r\nValue cannot be null.\r\nParameter name: 2\r\n3");

            Exception[] TestImplicit = Ex;
            ExceptionList TestImplicit2 = TestImplicit;

            Ex.Exceptions.ToS().Should().Be(TestImplicit2.Exceptions.ToS());

            List<Exception> TestImplicit3 = Ex;
            TestImplicit3 = (List<Exception>) Ex;
            TestImplicit3 = Ex;

            ExceptionList TestImplicit4 = TestImplicit3;

            Ex.Exceptions.ToS().Should().Be(TestImplicit4.Exceptions.ToS());
            }
        }
    }