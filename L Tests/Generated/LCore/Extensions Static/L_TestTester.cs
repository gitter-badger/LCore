using JetBrains.Annotations;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    public class L_TestTester : XUnitOutputTester
        {
        public L_TestTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~L_TestTester()
            {
            }

        [Fact]
        public void TestMethod()
            {
            // TODO: Implement method Test LCore.Extensions.L.Comment.Test.TestMethod
            }

        [Fact]
        public void TestMethod2()
            {
            // TODO: Implement method Test LCore.Extensions.L.Comment.Test.TestMethod2
            }

        [Fact]
        public void get_TestProperty()
            {
            // TODO: Implement method Test LCore.Extensions.L.Comment.Test.get_TestProperty
            }

        [Fact]
        public void set_TestProperty()
            {
            // TODO: Implement method Test LCore.Extensions.L.Comment.Test.set_TestProperty
            }

        }
    }
