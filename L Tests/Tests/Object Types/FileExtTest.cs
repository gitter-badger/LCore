
using LCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using FluentAssertions;

namespace L_Tests
    {
    [TestClass]
    public class FileExtTest : ExtensionTester
        {
        protected override Type[] TestType => new[] { typeof(FileExt) };

        [TestMethod]
        public void Test_EnsurePathExists()
            {
            const string str = @"c:\temporary_testEnsurePathExists\test\file.txt";
            const string str2 = @"c:\temporary_testEnsurePathExists\test";
            const string str3 = @"c:\temporary_testEnsurePathExists";

            str.EnsurePathExists();

            Directory.Exists(str2).Should().BeTrue();
            Directory.Exists(str3).Should().BeTrue();

            Directory.Delete(str2);
            Directory.Delete(str3);

            Directory.Exists(str2).Should().BeFalse();
            Directory.Exists(str3).Should().BeFalse();
            }

        }
    }
