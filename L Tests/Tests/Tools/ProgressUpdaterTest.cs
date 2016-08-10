using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tools;
using Xunit;
using static LCore.LUnit.LUnit.Categories;

namespace LCore.Tests.Tools
    {
    [Trait(Category, LUnit.LUnit.Categories.Tools)]
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
                    Progress.Should().Be(expected: 0);
                    Max.Should().Be(expected: 0);

                    Updater.Maximum(Maximum: 100);

                    Max.Should().Be(expected: 0);
                    Thread.Sleep(millisecondsTimeout: 20);
                    Max.Should().Be(expected: 100);

                    Updater.Progress(Progress: 5);
                    Thread.Sleep(millisecondsTimeout: 20);
                    Progress.Should().Be(expected: 5);

                    Updater.Status("hi");
                    Thread.Sleep(millisecondsTimeout: 20);
                    Status.Should().Be("hi");

                    Updater.Log("hi again");
                    Thread.Sleep(millisecondsTimeout: 20);
                    Log.Should().Be("hi again");

                    Status.Should().Be("hi");
                    Log.Should().Be("hi again");
                    Progress.Should().Be(expected: 5);
                    Max.Should().Be(expected: 100);
                    }
                })();
            }
        }
    }