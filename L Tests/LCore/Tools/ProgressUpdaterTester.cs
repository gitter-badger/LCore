using System;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
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
                    Progress.ShouldBe(Compare: 0);
                    Max.ShouldBe(Compare: 0);

                    Updater.Maximum(Maximum: 100);

                    Max.ShouldBe(Compare: 0);
                    Thread.Sleep(millisecondsTimeout: 20);
                    Max.ShouldBe(Compare: 100);

                    Updater.Progress(Progress: 5);
                    Thread.Sleep(millisecondsTimeout: 20);
                    Progress.ShouldBe(Compare: 5);

                    Updater.Status("hi");
                    Thread.Sleep(millisecondsTimeout: 20);
                    Status.ShouldBe("hi");

                    Updater.Log("hi again");
                    Thread.Sleep(millisecondsTimeout: 20);
                    Log.ShouldBe("hi again");

                    Status.ShouldBe("hi");
                    Log.ShouldBe("hi again");
                    Progress.ShouldBe(Compare: 5);
                    Max.ShouldBe(Compare: 100);
                    }
            })();
            }
        }
    }