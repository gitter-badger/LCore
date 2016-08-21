using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit.Abstractions;
#if DEBUG
using LCore.LUnit.Fluent;
using System.Threading;
using LCore.Tools;
using Xunit;
#endif

namespace L_Tests.LCore.Tools
    {
    public partial class ProgressUpdaterTester : XUnitOutputTester, IDisposable
        {
        public ProgressUpdaterTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

#if DEBUG

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Status) + "(String)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Log) + "(String)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Progress) + "(Int32)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Maximum) + "(Int32)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ProgressUpdater) + "." + nameof(ProgressUpdater.Clear) + "()")]
        public void TestAll()
            {
            string Status = "";
            string Log = "";
            int Progress = 0;
            int Max = 0;

            var Updater = new ProgressUpdater(
                Str => { Status = Str; },
                Str => { Log = Str; },
                NewProgress => { Progress = NewProgress; },
                NewMaximum => { Max = NewMaximum; });

            L.A(() =>
            {
                lock (Updater)
                    {
                    Updater.Clear();

                    Status.ShouldBe("");
                    Log.ShouldBe("");
                    Progress.ShouldBe(Expected: 0);
                    Max.ShouldBe(Expected: 0);

                    Updater.Maximum(Maximum: 100);

                    Max.ShouldBe(Expected: 0);
                    Thread.Sleep(millisecondsTimeout: 20);
                    Max.ShouldBe(Expected: 100);

                    Updater.Progress(Progress: 5);
                    Thread.Sleep(millisecondsTimeout: 20);
                    Progress.ShouldBe(Expected: 5);

                    Updater.Status("hi");
                    Thread.Sleep(millisecondsTimeout: 20);
                    Status.ShouldBe("hi");

                    Updater.Log("hi again");
                    Thread.Sleep(millisecondsTimeout: 20);
                    Log.ShouldBe("hi again");

                    Status.ShouldBe("hi");
                    Log.ShouldBe("hi again");
                    Progress.ShouldBe(Expected: 5);
                    Max.ShouldBe(Expected: 100);
                    }
            })();
            }
#endif

        }
    }