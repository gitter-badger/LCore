using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

namespace L_Tests.Tests.Tools
    {
    [Trait(Category, LCore.LUnit.LUnit.Categories.Tools)]
    public class ProgressUpdaterTest
        {
        [Fact]
        public void Test_ProgressUpdater()
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

                    Status.Should().Be("");
                    Log.Should().Be("");
                    Progress.Should().Be(0);
                    Max.Should().Be(0);

                    Updater.Maximum(100);

                    Max.Should().Be(0);
                    Thread.Sleep(20);
                    Max.Should().Be(100);

                    Updater.Progress(5);
                    Thread.Sleep(20);
                    Progress.Should().Be(5);

                    Updater.Status("hi");
                    Thread.Sleep(20);
                    Status.Should().Be("hi");

                    Updater.Log("hi again");
                    Thread.Sleep(20);
                    Log.Should().Be("hi again");

                    Status.Should().Be("hi");
                    Log.Should().Be("hi again");
                    Progress.Should().Be(5);
                    Max.Should().Be(100);
                    }
                })();
            }
        }
    }