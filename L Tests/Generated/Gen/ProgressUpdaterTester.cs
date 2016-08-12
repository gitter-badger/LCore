using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater))]
    public partial class ProgressUpdaterTester : XUnitOutputTester, IDisposable
        {
        public ProgressUpdaterTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Status) + "(String)")]
        public void Status()
            {
            // TODO: Implement method test LCore.Tools.ProgressUpdater.Status
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Log) + "(String)")]
        public void Log()
            {
            // TODO: Implement method test LCore.Tools.ProgressUpdater.Log
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Progress) + "(Int32)")]
        public void Progress()
            {
            // TODO: Implement method test LCore.Tools.ProgressUpdater.Progress
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Maximum) + "(Int32)")]
        public void Maximum()
            {
            // TODO: Implement method test LCore.Tools.ProgressUpdater.Maximum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Clear) + "()")]
        public void Clear()
            {
            // TODO: Implement method test LCore.Tools.ProgressUpdater.Clear
            }

        }
    }