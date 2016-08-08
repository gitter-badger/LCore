using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_FileTester : XUnitOutputTester
        {
        public L_FileTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~L_FileTester()
            {
            }

        [Fact]
        public void add_BufferedMoveProgress()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.add_BufferedMoveProgress
            }

        [Fact]
        public void remove_BufferedMoveProgress()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.remove_BufferedMoveProgress
            }

        [Fact]
        public void BufferedMove()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.BufferedMove
            }

        [Fact]
        public void CombinePaths_String_String()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.CombinePaths
            }

        [Fact]
        public void CombinePaths_Char_String_String()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.CombinePaths
            }

        [Fact]
        public void GetFileContents()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.GetFileContents
            }

        [Fact]
        public void SafeCopyFile()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.SafeCopyFile
            }

        [Fact]
        public void SafeMoveFile()
            {
            // TODO: Implement method Test LCore.Extensions.L.File.SafeMoveFile
            }

        }
    }