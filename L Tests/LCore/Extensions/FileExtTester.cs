using System;
using System.IO;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable PossibleNullReferenceException

namespace L_Tests.LCore.Extensions
    {
    public partial class FileExtTester : XUnitOutputTester, IDisposable
        {
        private const string Str = @"c:\temporary_testEnsurePathExists\test\file.txt";
        private const string Str2 = @"c:\temporary_testEnsurePathExists\test";
        private const string Str3 = @"c:\temporary_testEnsurePathExists";
        private readonly byte[] _TestBytes = { 5, 7, 3, 67, 2, 5, 88, 42, 2, 6, 99, 4, 3, 7 };

        public FileExtTester([NotNull] ITestOutputHelper Output) : base(Output)
            {
            Str.EnsurePathExists();
            File.WriteAllBytes(Str, this._TestBytes);
            }

        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." +
            nameof(FileExt.EnsurePathExists) + "(String)")]
        public void Dispose()
            {
            File.Delete(Str);
            Directory.Delete(Str2);
            Directory.Delete(Str3);

            Directory.Exists(Str3).ShouldBeFalse();
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." +
            nameof(FileExt.GetFileHash) + "(String) => Byte[]")]
        public void GetFileHash()
            {
            Str.GetFileHash()
                .Should()
                .Equal(111, 162, 116, 34, 129, 211, 2, 8, 193, 143, 255, 155, 154, 182, 221, 107, 27, 107, 59, 157, 211, 90, 242, 94, 8, 153,
                    212, 59, 149, 171, 160, 119);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." +
            nameof(FileExt.GetMemoryStream) + "(Stream) => MemoryStream")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." +
            nameof(FileExt.ReadAllBytes) + "(Stream) => Byte[]")]
        public void GetMemoryStream()
            {
            var File = Str.GetFileStream();

            var MemStream = File.GetMemoryStream();

            File.Close();

            MemStream.Length.ShouldBe(Expected: 14);
            MemStream.ReadAllBytes().Should().Equal(5, 7, 3, 67, 2, 5, 88, 42, 2, 6, 99, 4, 3, 7);
            }
        }
    }