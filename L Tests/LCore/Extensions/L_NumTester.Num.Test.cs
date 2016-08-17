using System;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedParameter.Global

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L))]
    public partial class L_NumTester : XUnitOutputTester, IDisposable
        {
        public L_NumTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember,
            nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(L) + "." + nameof(L.Num) + "." +
            nameof(L.Num.ScientificNotationToNumber) + "(String) => String")]
        public void ScientificNotationToNumber()
            {
            L.Num.ScientificNotationToNumber("nope not a number").ShouldBe("nope not a number");
            L.Num.ScientificNotationToNumber("553e10").ShouldBe("5530000000000");
            L.Num.ScientificNotationToNumber("553e0").ShouldBe("553");
            L.Num.ScientificNotationToNumber("553.1e1").ShouldBe("5531");
            L.Num.ScientificNotationToNumber("3.00053e10").ShouldBe("30005300000");
            L.Num.ScientificNotationToNumber("1.0e5").ShouldBe("100000");
            L.Num.ScientificNotationToNumber("1.0e-5").ShouldBe("0.00001");
            L.Num.ScientificNotationToNumber("1.0e0").ShouldBe("1");
            L.Num.ScientificNotationToNumber("5.0e-1").ShouldBe("0.5");
            }
        }
    }