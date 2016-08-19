using Xunit.Abstractions;
using Xunit;
using System;
using LCore.LUnit;
namespace LUnit_Tests.LCore.LUnit
{
    /*
    Covering class: LCore.LUnit.MethodCoverage
    
    LUnit has Autogenerated 1 method stubs:
    */
    public partial class MethodCoverageTester : XUnitOutputTester, IDisposable
    {
        public MethodCoverageTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,nameof(LCore)+ "." + nameof(global::LCore.LUnit)+ "." + nameof(MethodCoverage)+ "." + nameof(MethodCoverage.GetTestStub) + "(List&<String>) => String[]")]
        public void GetTestStub()
        {
            // TODO: Implement method test LCore.LUnit.MethodCoverage.GetTestStub
        }

    }
}
