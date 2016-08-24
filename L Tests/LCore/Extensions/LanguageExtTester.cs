using Xunit.Abstractions;
using LCore.LUnit;
using Xunit;
using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit.Fluent;

// ReSharper disable AnnotationRedundancyAtValueType
// ReSharper disable ValueParameterNotUsed

namespace L_Tests.LCore.Extensions
    {
    /// <summary>
    /// Covering class: LCore.Extensions.LanguageExt
    /// </summary>
    public partial class LanguageExtTester : XUnitOutputTester, IDisposable
        {
        public LanguageExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

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
        public void Dispose() { }

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

            // TODO Test constructors
            // TODO Test comments / attributes

            // TODO Test fields
            // TODO Test comments / attributes

            // TODO Test enum
            // TODO Test comments / attributes

            // TODO Test class
            // TODO Test comments / attributes
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCodeLineNumber) + "(MemberInfo) => Nullable<UInt32>")]
        public void FindSourceCodeLineNumber()
            {
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCodeLineNumber().ShouldBe(39u);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCodeLineNumber().ShouldBe(34u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCodeLineNumber().ShouldBe(22u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCodeLineNumber().ShouldBe(30u);
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCodeLineCount) + "(MemberInfo, Boolean, Boolean, Boolean) => UInt32")]
        public void FindSourceCodeLineCount()
            {
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode_SelfTest)).FindSourceCodeLineCount().ShouldBe(11u);
            typeof(LanguageExtTester).GetMethod(nameof(this.Dispose)).FindSourceCodeLineCount().ShouldBe(3u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty)).FindSourceCodeLineCount().ShouldBe(7u);
            typeof(LanguageExtTester).GetProperty(nameof(this.TestProperty2)).FindSourceCodeLineCount().ShouldBe(0u);
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


        private const string DisposeCode = "        public void Dispose() { }";

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
        }
    }