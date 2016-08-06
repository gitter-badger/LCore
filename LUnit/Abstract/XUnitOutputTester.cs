using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Xunit.Abstractions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Extend this class to be given access to Xunit's ITestOutputHelper to send text to the Output window.
    /// </summary>
    public abstract class XUnitOutputTester
        {
        /// <summary>
        /// Write text to the Test Output window.
        /// </summary>
        [NotNull]
        protected ITestOutputHelper _Output { get; }

        /// <summary>
        /// Output will be injected by Xunit
        /// </summary>
        protected XUnitOutputTester([NotNull] ITestOutputHelper Output)
            {
            this._Output = Output;
            }
        }
    }