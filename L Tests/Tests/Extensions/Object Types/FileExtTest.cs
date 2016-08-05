
using LCore.Extensions;
using System;
using System.IO;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;
using LCore.LUnit;
using static LCore.LUnit.LUnit.Categories;

namespace L_Tests.Tests.Extensions
    {
    [Trait(Category, UnitTests)]
    public class FileExtTest : ExtensionTester
        {
        private const string Str = @"c:\temporary_testEnsurePathExists\test\file.txt";
        private const string Str2 = @"c:\temporary_testEnsurePathExists\test";
        private const string Str3 = @"c:\temporary_testEnsurePathExists";
        private readonly byte[] _TestBytes = { 5, 7, 3, 67, 2, 5, 88, 42, 2, 6, 99, 4, 3, 7 };


        public FileExtTest([NotNull] ITestOutputHelper Output) : base(Output)
            {
            Str.EnsurePathExists();
            File.WriteAllBytes(Str, this._TestBytes);
            }
        ~FileExtTest()
            {
            File.Delete(Str);
            Directory.Delete(Str2);
            Directory.Delete(Str3);

            Directory.Exists(Str3).Should().BeFalse();
            }



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
        [Fact]
        
        public void Test_EnsurePathExists()
            {
            }


        [Fact]
        public void Test_GetFileHash()
            {
            Str.GetFileHash().Should().Equal(111, 162, 116, 34, 129, 211, 2, 8, 193, 143, 255, 155, 154, 182, 221, 107, 27, 107, 59, 157, 211, 90, 242, 94, 8, 153, 212, 59, 149, 171, 160, 119);

            }

        [Fact]
        public void Test_GetMemoryStream()
            {
            var File = Str.GetFileStream();

            var MemStream = File.GetMemoryStream();

            File.Close();

            MemStream.Length.Should().Be(14);
            MemStream.ReadAllBytes().Should().Equal(5, 7, 3, 67, 2, 5, 88, 42, 2, 6, 99, 4, 3, 7);
            }

        }
    }
