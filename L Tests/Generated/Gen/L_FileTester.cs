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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_FileTester : XUnitOutputTester, IDisposable
        {
        public L_FileTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.BufferedMove) + "(String, String, Boolean, Int32)")]
        public void BufferedMove()
            {
            // TODO: Implement method test LCore.Extensions.L.File.BufferedMove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.CombinePaths) + "(String[]) => String")]
        public void CombinePaths_String_String()
            {
            // TODO: Implement method test LCore.Extensions.L.File.CombinePaths
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.CombinePaths) + "(Char, String[]) => String")]
        public void CombinePaths_Char_String_String()
            {
            // TODO: Implement method test LCore.Extensions.L.File.CombinePaths
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.GetFileContents) + "(String) => Byte[]")]
        public void GetFileContents()
            {
            // TODO: Implement method test LCore.Extensions.L.File.GetFileContents
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.SafeCopyFile) + "(String, String, Int32, Boolean) => Boolean")]
        public void SafeCopyFile()
            {
            // TODO: Implement method test LCore.Extensions.L.File.SafeCopyFile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.SafeMoveFile) + "(String, String, Int32, Boolean, Boolean) => Boolean")]
        public void SafeMoveFile()
            {
            // TODO: Implement method test LCore.Extensions.L.File.SafeMoveFile
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.File) + "." + nameof(L.File.BufferedMoveProgress))]
        public void BufferedMoveProgress()
            {
            // TODO: Implement method test LCore.Extensions.L.File.BufferedMoveProgress
            }

        }
    }