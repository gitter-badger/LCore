using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(CommentExt))]
    public partial class CommentExtTester : XUnitOutputTester
        {
        public CommentExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~CommentExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(CommentExt) + "." + nameof(CommentExt.GetComments))]
        public void GetComments()
            {
            // TODO: Implement method test LCore.Extensions.CommentExt.GetComments
            }

        }
    }