using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt))]
    public partial class FileExtTester : XUnitOutputTester, IDisposable
        {
        public FileExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.CleanFileName) + "(String) => String")]
        public void CleanFileName()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.CleanFileName
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.EnsurePathExists) + "(String)")]
        public void EnsurePathExists()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.EnsurePathExists
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.EveryOtherByte) + "(Byte[]) => Byte[]")]
        public void EveryOtherByte()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.EveryOtherByte
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetFileStream) + "(String) => FileStream")]
        public void GetFileStream()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetFileStream
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetFileHash) + "(String) => Byte[]")]
        public void GetFileHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetFileHash
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetMemoryStream) + "(Stream) => MemoryStream")]
        public void GetMemoryStream()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetMemoryStream
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetStreamHash) + "(Stream) => Byte[]")]
        public void GetStreamHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetStreamHash
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.GetStringHash) + "(String) => Byte[]")]
        public void GetStringHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetStringHash
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(FileExt) + "." + nameof(FileExt.ReadAllBytes) + "(Stream) => Byte[]")]
        public void ReadAllBytes()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.ReadAllBytes
            }

        }
    }