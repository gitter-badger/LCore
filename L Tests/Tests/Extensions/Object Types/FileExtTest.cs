
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

        /// <exception cref="IOException">A file with the same name and location specified by <paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     exists.-or-The directory is the application's current working directory.-or-The directory specified by <paramref>
        ///         <name>path</name>
        ///     </paramref>
        ///     is not empty.-or-The directory is read-only or contains a read-only file.-or-The directory is being used by another process.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission. </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///         <paramref>
        ///             <name>path</name>
        ///         </paramref>
        ///     does not exist or could not be found.-or-The specified path is invalid (for example, it is on an unmapped drive). </exception>
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
