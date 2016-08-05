using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Xunit.Abstractions;

namespace LCore.LUnit
    {
    public abstract class XUnitOutputTester
        {
        [NotNull]
        protected ITestOutputHelper _Output { get; }

        protected XUnitOutputTester(ITestOutputHelper Output)
            {
            this._Output = Output;
            }
        }
    }