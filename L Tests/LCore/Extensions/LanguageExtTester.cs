using Xunit.Abstractions;
using LCore.LUnit;
using Xunit;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit.Fluent;
// ReSharper disable PartialTypeWithSinglePart

// ReSharper disable PossibleNullReferenceException

// ReSharper disable AnnotationRedundancyAtValueType
// ReSharper disable ValueParameterNotUsed

namespace L_Tests.LCore.Extensions
    {
    /// <summary>
    /// Covering class: LCore.Extensions.LanguageExt
    /// </summary>
    public partial class LanguageExtTester : XUnitOutputTester, IDisposable
        {
        public LanguageExtTester([NotNull] ITestOutputHelper Output) : base(Output)
            {
            }

        // test comment
        [CanBeNull]
        public string TestProperty
            {
            get { return "a"; }
            set { }
            }

        // test comment
        [CanBeNull]
        public string TestProperty2 => "a";

        // test comment
        [CanBeNull]
        public void Dispose()
            {
            }

        // super meta test
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCode) + "(MemberInfo, Boolean, Boolean) => String")]
        public void FindSourceCode_SelfTest()
            {
            // Test multi-line methods
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode().ShouldBe(FindSourceCodeTestCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode(IncludeAttributes: true).ShouldBe(FindSourceCodeTestCode_WithAttributes);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).ShouldBe(FindSourceCodeTestCode_WithComments);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).ShouldBe(FindSourceCodeTestCode_WithBoth);
            }

        // super meta test
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCode) + "(MemberInfo, Boolean, Boolean) => String")]
        public void FindSourceCode()
            {
            // Test single line methods
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCode().ShouldBe(DisposeCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCode(IncludeAttributes: true).ShouldBe(AttributeLine + DisposeCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).ShouldBe(CommentLine + DisposeCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).ShouldBe(CommentLine + AttributeLine + DisposeCode);

            // Test properties with block body
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCode().ShouldBe(TestPropertyCode);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCode(IncludeAttributes: true).ShouldBe(AttributeLine + TestPropertyCode);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).ShouldBe(CommentLine + TestPropertyCode);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).ShouldBe(CommentLine + AttributeLine + TestPropertyCode);

            // Test properties with lambda
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCode().ShouldBe(TestPropertyCode2);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCode(IncludeAttributes: true).ShouldBe(AttributeLine + TestPropertyCode2);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).ShouldBe(CommentLine + TestPropertyCode2);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).ShouldBe(CommentLine + AttributeLine + TestPropertyCode2);

            // Test class
            int Expected = 1865;
            typeof(MemberDetails).FindSourceCode().Length.ShouldBe(Expected);
            typeof(MemberDetails).FindSourceCode(IncludeAttributes: true).Length.ShouldBe(Expected);
            typeof(MemberDetails).FindSourceCode(IncludeAttributes: false, IncludeComments: true).Length.ShouldBe(Expected + 90);
            typeof(MemberDetails).FindSourceCode(IncludeAttributes: true, IncludeComments: true).Length.ShouldBe(Expected + 90);

            // Test nested class
            Expected = 657;
            typeof(Test).FindSourceCode().Length.ShouldBe(Expected);
            typeof(Test).FindSourceCode(IncludeAttributes: true).Length.ShouldBe(Expected);
            typeof(Test).FindSourceCode(IncludeAttributes: false, IncludeComments: true).Length.ShouldBe(Expected);
            typeof(Test).FindSourceCode(IncludeAttributes: true, IncludeComments: true).Length.ShouldBe(Expected);

            // Test enum
            Expected = 182;
            typeof(MemberScope).FindSourceCode().Length.ShouldBe(Expected);
            typeof(MemberScope).FindSourceCode(IncludeAttributes: true).Length.ShouldBe(Expected);
            typeof(MemberScope).FindSourceCode(IncludeAttributes: false, IncludeComments: true).Length.ShouldBe(Expected + 78);
            typeof(MemberScope).FindSourceCode(IncludeAttributes: true, IncludeComments: true).Length.ShouldBe(Expected + 78);

            // Test overridden method
            Expected = 98;
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.VirtualMethod)).FindSourceCode().Length.ShouldBe(Expected);
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.VirtualMethod)).FindSourceCode(IncludeAttributes: true).Length.ShouldBe(Expected);
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.VirtualMethod)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).Length.ShouldBe(Expected);
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.VirtualMethod)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).Length.ShouldBe(Expected);

            // Test methods with line breaks
            Expected = 89;
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.LineBreakingMethod)).FindSourceCode().Length.ShouldBe(Expected);
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.LineBreakingMethod)).FindSourceCode(IncludeAttributes: true).Length.ShouldBe(Expected);
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.LineBreakingMethod)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).Length.ShouldBe(Expected);
            typeof(LanguageExtTester.Test.TestPublic).GetMethod(nameof(LanguageExtTester.Test.TestPublic.LineBreakingMethod)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).Length.ShouldBe(Expected);

            // TODO Test constructors
            // TODO Test comments / attributes

            // TODO Test fields
            // TODO Test comments / attributes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCodeLineNumber) + "(MemberInfo) => Nullable<UInt32>")]
        public void FindSourceCodeLineNumber()
            {
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCodeLineNumber().ShouldBe(Expected: 48u);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCodeLineNumber().ShouldBe(Expected: 41u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCodeLineNumber().ShouldBe(Expected: 29u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCodeLineNumber().ShouldBe(Expected: 37u);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCodeLineCount) + "(MemberInfo, Boolean, Boolean, Boolean) => UInt32")]
        public void FindSourceCodeLineCount()
            {
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCodeLineCount().ShouldBe(Expected: 9u);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCodeLineCount().ShouldBe(Expected: 3u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCodeLineCount().ShouldBe(Expected: 5u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCodeLineCount().ShouldBe(Expected: 3u);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.GetMemberDetails) + "(MemberInfo) => MemberDetails")]
        public void GetMemberDetails()
            {
            typeof(Test)
                .GetMemberDetails().ToString().ShouldBe("Public Class");
            typeof(Test.TestPublic)
                .GetMemberDetails().ToString().ShouldBe("Public Class");
            typeof(Test.TestAbstract)
                .GetMemberDetails().ToString().ShouldBe("Public Abstract Class");
            typeof(Test.TestSealed)
                .GetMemberDetails().ToString().ShouldBe("Public Sealed Class");
            typeof(Test.TestInternal)
                .GetMemberDetails().ToString().ShouldBe("Internal Class");
            typeof(TestProtected)
                .GetMemberDetails().ToString().ShouldBe("Protected Class");
            typeof(TestStatic)
                .GetMemberDetails().ToString().ShouldBe("Public Static Class");


            // TODO test sealed class


            typeof(Test.TestPublic).GetMethod(nameof(Test.TestPublic.PublicMethod))
                .GetMemberDetails().ToString().ShouldBe("Public Method");

            typeof(Test.TestPublicBase).GetMethod(nameof(Test.TestPublicBase.VirtualMethod))
                .GetMemberDetails().ToString().ShouldBe("Public Virtual Method");

            typeof(Test.TestPublicBase).GetMethod(nameof(Test.TestPublicBase.AbstractMethod))
                .GetMemberDetails().ToString().ShouldBe("Public Abstract Method");

            typeof(LanguageExtTester).GetMethod(nameof(this.PrivateMethod),
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .GetMemberDetails().ToString().ShouldBe("Private Method");

            typeof(LanguageExtTester).GetMethod(nameof(this.ProtectedMethod),
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .GetMemberDetails().ToString().ShouldBe("Protected Method");

            typeof(Test.TestPublic).GetMethod(nameof(Test.TestPublic.VirtualMethod),
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .GetMemberDetails().ToString().ShouldBe("Public Override Method");

            typeof(Test.TestPublic).GetMethod(nameof(Test.TestPublic.InternalMethod),
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .GetMemberDetails().ToString().ShouldBe("Internal Method");

            // TODO test sealed method
            // TODO test static method
            }

        #region Helpers

        [ExcludeFromCodeCoverage]
        private void PrivateMethod()
            {
            }

        [ExcludeFromCodeCoverage]
        protected void ProtectedMethod()
            {
            }


        [ExcludeFromCodeCoverage]
        protected class TestProtected
            {
            }

        [ExcludeFromCodeCoverage]
        public static class TestStatic
            {

            }

        [ExcludeFromCodeCoverage]
        private class Test
            {
            public class TestPublic : TestPublicBase
                {
                public void PublicMethod()
                    {
                    }


                internal void InternalMethod()
                    {
                    }

                public override void VirtualMethod()
                    {
                    }

                public override void AbstractMethod()
                    {
                    }

                public void LineBreakingMethod(string s1, string s2, string s3,
                    string s4, string s5)
                    {

                    }
                }

            public abstract class TestPublicBase
                {
                public virtual void VirtualMethod()
                    {
                    }

                public abstract void AbstractMethod();
                }

            public abstract class TestAbstract
                {
                }

            public sealed class TestSealed
                {
                }

            internal class TestInternal
                {
                }
            }


        public const string FindSourceCodeTestCode =
            @"        public void FindSourceCode_SelfTest()
            {
" + BlockBody + @"
            }";

        public const string FindSourceCodeTestCode_WithAttributes =
            @"        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + ""."" + nameof(global::LCore.Extensions) + ""."" + nameof(LanguageExt) + ""."" + nameof(LanguageExt.FindSourceCode) + ""(MemberInfo, Boolean, Boolean) => String"")]
        public void FindSourceCode_SelfTest()
            {
" + BlockBody + @"
            }";

        public const string FindSourceCodeTestCode_WithComments =
            @"        // super meta test
        public void FindSourceCode_SelfTest()
            {
" + BlockBody + @"
            }";

        public const string FindSourceCodeTestCode_WithBoth =
            @"        // super meta test
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + ""."" + nameof(global::LCore.Extensions) + ""."" + nameof(LanguageExt) + ""."" + nameof(LanguageExt.FindSourceCode) + ""(MemberInfo, Boolean, Boolean) => String"")]
        public void FindSourceCode_SelfTest()
            {
" + BlockBody + @"
            }";


        private const string DisposeCode = @"        public void Dispose()
            {
            }";

        private const string TestPropertyCode = @"        public string TestProperty
            {
            get { return ""a""; }
            set { }
            }";

        private const string TestPropertyCode2 = "        public string TestProperty2 => \"a\";";

        private const string CommentLine = "        // test comment\r\n";
        private const string AttributeLine = "        [CanBeNull]\r\n";

        private const string BlockBody = @"            // Test multi-line methods
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode().ShouldBe(FindSourceCodeTestCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode(IncludeAttributes: true).ShouldBe(FindSourceCodeTestCode_WithAttributes);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode(IncludeAttributes: false, IncludeComments: true).ShouldBe(FindSourceCodeTestCode_WithComments);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCode(IncludeAttributes: true, IncludeComments: true).ShouldBe(FindSourceCodeTestCode_WithBoth);";

        #endregion  }
        }
    }