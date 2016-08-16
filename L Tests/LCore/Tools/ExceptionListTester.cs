using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions.Optional;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(ExceptionList))]
    public partial class ExceptionListTester : XUnitOutputTester, IDisposable
        {
        public ExceptionListTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit(ExceptionList) => Exception[]")]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit(Exception[]) => ExceptionList")]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit(ExceptionList) => List`1<Exception>")]
        [Trait(Traits.TargetMember, "LCore.Tools.ExceptionList.op_Implicit(List`1<Exception>) => ExceptionList")]
        public void ExceptionList()
            {
            var Ex = new ExceptionList(new[]
                {
                new Exception("1"),
                // ReSharper disable once NotResolvedInText
                new ArgumentNullException("2"),
                new FormatException("3")
                });

            Ex.Exceptions.ToS().ShouldBe("List`1<Exception> { System.Exception: 1, System.ArgumentNullException: Value cannot be null.\r\nParameter name: 2, System.FormatException: 3 }");

            Ex.StackTrace.ShouldBe("");

            Ex.ToString().ShouldBe("LCore.Tools.ExceptionList: 1\r\nValue cannot be null.\r\nParameter name: 2\r\n3");

            Exception[] TestImplicit = Ex;
            ExceptionList TestImplicit2 = TestImplicit;

            Ex.Exceptions.ToS().ShouldBe(TestImplicit2.Exceptions.ToS());

            // ReSharper disable once RedundantAssignment
            List<Exception> TestImplicit3 = Ex;
            // ReSharper disable once RedundantAssignment
            // ReSharper disable once RedundantCast
            TestImplicit3 = (List<Exception>)Ex;
            TestImplicit3 = Ex;

            ExceptionList TestImplicit4 = TestImplicit3;

            Ex.Exceptions.ToS().ShouldBe(TestImplicit4.Exceptions.ToS());
            }

        }
    }