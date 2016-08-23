using Xunit.Abstractions;
using LCore.LUnit;
using Xunit;
using System;
using JetBrains.Annotations;
using JetBrains.dotMemoryUnit.Util;
using LCore.Extensions;
using LCore.LUnit.Fluent;

namespace L_Tests.LCore.Extensions
    {
    /*
    Covering class: LCore.Extensions.LanguageExt
    */
    public partial class LanguageExtTester : XUnitOutputTester, IDisposable
        {
        public LanguageExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(LanguageExt) + "." + nameof(LanguageExt.FindSourceCode) + "(MemberInfo, Boolean) => String")]
        public void FindSourceCode()
            {
            // super meta test
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode)).FindSourceCode().ShouldBe(FindSourceCodeTestCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode)).FindSourceCode(IncludeAttributes: false).ShouldBe(FindSourceCodeTestCode_NoAttributes);
            }

        public const string FindSourceCodeTestCode =
@"        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + ""."" + nameof(global::LCore.Extensions) + ""."" + nameof(LanguageExt) + ""."" + nameof(LanguageExt.FindSourceCode) + ""(MemberInfo, Boolean) => String"")]
        public void FindSourceCode()
            {
            // super meta test
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode)).FindSourceCode().ShouldBe(FindSourceCodeTestCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode)).FindSourceCode(IncludeAttributes: false).ShouldBe(FindSourceCodeTestCode_NoAttributes);
            }";

        public const string FindSourceCodeTestCode_NoAttributes =
@"        public void FindSourceCode()
            {
            // super meta test
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode)).FindSourceCode().ShouldBe(FindSourceCodeTestCode);
            typeof(LanguageExtTester).GetMethod(nameof(this.FindSourceCode)).FindSourceCode(IncludeAttributes: false).ShouldBe(FindSourceCodeTestCode_NoAttributes);
            }";
        }
    }
