using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt))]
    public partial class FileExtTester : XUnitOutputTester
        {
        public FileExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~FileExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.CleanFileName))]
        public void CleanFileName()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.CleanFileName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.EnsurePathExists))]
        public void EnsurePathExists()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.EnsurePathExists
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.EveryOtherByte))]
        public void EveryOtherByte()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.EveryOtherByte
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetFileStream))]
        public void GetFileStream()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetFileStream
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetFileHash))]
        public void GetFileHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetFileHash
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetMemoryStream))]
        public void GetMemoryStream()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetMemoryStream
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetStreamHash))]
        public void GetStreamHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetStreamHash
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetStringHash))]
        public void GetStringHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetStringHash
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.ReadAllBytes))]
        public void ReadAllBytes()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.ReadAllBytes
            }

        }
    }