using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_NumTester : XUnitOutputTester
        {
        public L_NumTester([NotNull] ITestOutputHelper Output) : base(Output) { }


        ~L_NumTester()
            {
            }

        [Fact]
        public void get_MostPreciseType()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.get_MostPreciseType
            }

        [Fact]
        public void get_NumberTypes()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.get_NumberTypes
            }

        [Fact]
        public void ScientificNotationToNumber()
            {
            // TODO: Implement method test LCore.Extensions.L.Num.ScientificNotationToNumber
            }

        }
    }