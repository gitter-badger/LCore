
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using FluentAssertions;
using static LCore.Extensions.L.Test.Categories;

namespace L_Tests.Tests.Extensions
    {
    [TestClass]
    public class FileExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(FileExt) };

        [TestMethod]
        [TestCategory(UnitTests)]
        public void Test_EnsurePathExists()
            {
            const string Str = @"c:\temporary_testEnsurePathExists\test\file.txt";
            const string Str2 = @"c:\temporary_testEnsurePathExists\test";
            const string Str3 = @"c:\temporary_testEnsurePathExists";

            Str.EnsurePathExists();

            Directory.Exists(Str2).Should().BeTrue();
            Directory.Exists(Str3).Should().BeTrue();

            Directory.Delete(Str2);
            Directory.Delete(Str3);

            Directory.Exists(Str2).Should().BeFalse();
            Directory.Exists(Str3).Should().BeFalse();
            }

        }
    }
