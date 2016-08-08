using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class FileExtTester : XUnitOutputTester
        {
        public FileExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }



        ~FileExtTester()
            {
            }


        [Fact]
        public void EnsurePathExists()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.EnsurePathExists
            }

        [Fact]
        public void CleanFileName()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.CleanFileName
            }

        [Fact]
        public void EveryOtherByte()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.EveryOtherByte
            }

        [Fact]
        public void GetFileStream()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetFileStream
            }

        [Fact]
        public void GetFileHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetFileHash
            }

        [Fact]
        public void GetMemoryStream()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetMemoryStream
            }

        [Fact]
        public void GetStreamHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetStreamHash
            }

        [Fact]
        public void GetStringHash()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.GetStringHash
            }

        [Fact]
        public void ReadAllBytes()
            {
            // TODO: Implement method test LCore.Extensions.FileExt.ReadAllBytes
            }

        }
    }