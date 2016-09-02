using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    public partial class CommentExtTester : XUnitOutputTester
        {
        public CommentExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~CommentExtTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(CommentExt) + "." + nameof(CommentExt.GetComments) + "(MemberInfo) => ICodeComment")]
        public void GetComments()
            {
            // ReSharper disable once RedundantAssignment
            var Comments = typeof(L.Comment).GetComments();

            // Test xml member cache
            Comments = typeof(L.Comment).GetComments();

            Comments.Summary.ShouldBe(@"
            Contains values and test members for CommentExt
            ");


            var Comments2 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestMethod)).First().GetComments();

            Comments2.Summary.ShouldBe(@"
            Test class
            ");
            Comments2.Returns.ShouldBe("Returns");
            Comments2.Value.ShouldBe("value");
            Comments2.Remarks.ShouldBe("Remark");
            Comments2.Examples.Should().Equal("some code", "more code");
            Comments2.Parameters.Should().Equal(
                new Set<string, string>("A", "param1"),
                new Set<string, string>("B", "param2"));
            Comments2.Exceptions.Should().Equal(
                new Set<string, string>("T:System.Exception", "exception 1"),
                new Set<string, string>("T:System.ArgumentException", "exception 2"));
            Comments2.Permissions.Should().Equal(
                new Set<string, string>("T:System.Security.PermissionSet", "permission 1"),
                new Set<string, string>("T:System.Security.CodeAccessPermission", "permission 2"));
            Comments2.TypeParameters.Should().Equal(new Set<string, string>("T", "Type"));

            var Comments3 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestProperty)).First().GetComments();

            Comments3.Summary.ShouldBe(@"
            TestProperty 
            ");

            var Comments4 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestField)).First().GetComments();

            Comments4.Summary.ShouldBe(@"
            TestField
            ");

            Comments.Features.Should().Equal("1", "a");
            Comments.ClassFeatures.Should().Equal("2");
            Comments.ProjectFeatures.Should().Equal("3");
            Comments.TestedFeatures.Should().Equal("4");

            Comments2.Features.Should().Equal("1", "a");
            Comments2.ClassFeatures.Should().Equal("2");
            Comments2.ProjectFeatures.Should().Equal("3");
            Comments2.TestedFeatures.Should().Equal("4");

            Comments3.Features.Should().Equal("1", "a");
            Comments3.ClassFeatures.Should().Equal("2");
            Comments3.ProjectFeatures.Should().Equal("3");
            Comments3.TestedFeatures.Should().Equal("4");

            Comments4.Features.Should().Equal("1", "a");
            Comments4.ClassFeatures.Should().Equal("2");
            Comments4.ProjectFeatures.Should().Equal("3");
            Comments4.TestedFeatures.Should().Equal("4");

            typeof(CommentExtTester).GetComments().Should().BeNull();

            var Test = new TestInvalidMemberInfo();
            Test.GetCustomAttributes(Inherit: false).Should().BeNull();
            Test.IsDefined(AttributeType: null, Inherit: false).ShouldBeFalse();
            Test.GetCustomAttributes(AttributeType: null, Inherit: false).Should().BeNull();
            Test.MemberType.ShouldBe(default(MemberTypes));
            Test.Name.Should().BeNull();
            Test.DeclaringType.Should().BeNull();
            Test.ReflectedType.Should().BeNull();

            Test.GetComments().Should().BeNull();

            var Comments5 = typeof(L.Comment.Test).GetMember(nameof(L.Comment.Test.TestMethod2)).First().GetComments();
            Comments5.Includes.Should().Equal(new Set<string, string>("filepath", "[@name=\"filename\"]"));

            typeof(L.Ref).GetMethod(nameof(L.Ref.GetSolutionRootPath)).GetComments().Should().NotBeNull();
            }

        [ExcludeFromCodeCoverage]
        private class TestInvalidMemberInfo : MemberInfo
            {
            public override object[] GetCustomAttributes(bool Inherit)
                {
                return null;
                }

            public override bool IsDefined(Type AttributeType, bool Inherit)
                {
                return false;
                }

            public override object[] GetCustomAttributes(Type AttributeType, bool Inherit)
                {
                return null;
                }
            
            // ReSharper disable UnassignedGetOnlyAutoProperty
            public override MemberTypes MemberType { get; }
            public override string Name { get; }
            public override Type DeclaringType { get; }
            public override Type ReflectedType { get; }
            // ReSharper restore UnassignedGetOnlyAutoProperty
            }
        }
    }