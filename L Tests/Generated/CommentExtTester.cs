using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class CommentExtTester : XUnitOutputTester
        {
        public CommentExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~CommentExtTester() { }

        [Fact]
        public void GetComments()
            {
            // TODO: Implement method Test LCore.Extensions.CommentExt.GetComments
            }

        }
    }