using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class DictionaryExtTester : XUnitOutputTester
        {
        public DictionaryExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~DictionaryExtTester()
            {
            }

        [Fact]
        public void Flip()
            {
            // TODO: Implement method Test LCore.Extensions.DictionaryExt.Flip
            }

        [Fact]
        public void SafeRemove()
            {
            // TODO: Implement method Test LCore.Extensions.DictionaryExt.SafeRemove
            }

        [Fact]
        public void ToDictionary_IEnumerable_1_Dictionary_2()
            {
            // TODO: Implement method Test LCore.Extensions.DictionaryExt.ToDictionary
            }

        }
    }