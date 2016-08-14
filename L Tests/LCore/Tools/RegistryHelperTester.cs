using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security;
using FluentAssertions;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.Extensions.Optional;
using LCore.LUnit;
using LCore.LUnit.Fluent;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable RedundantCast

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper))]
    public partial class RegistryHelperTester : XUnitOutputTester, IDisposable
        {
        [ExcludeFromCodeCoverage]
        public RegistryHelperTester([NotNull] ITestOutputHelper Output) : base(Output)
            {
            try
                {
                if (RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default)
                    .GetSubKeyNames()
                    .Has(TestRegKey))
                    {
                    RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).DeleteSubKeyTree(TestRegKey);

                    RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).DeleteSubKey(TestRegKey);
                    }
                }
            catch { }

            RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default)
                .GetSubKeyNames()
                .Has(TestRegKey)
                .Should()
                .BeFalse();

            this.Reg = new RegistryHelper(TestRegKey,
                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).CreateSubKey(TestRegKey));

            this.Reg.RemoveAll();
            this.Reg.LoadAll().Should().Equal();
            }
        [ExcludeFromCodeCoverage]

        public void Dispose()
            {
            this.Reg.RemoveAll();

            this.Reg.LoadAll().Should().Equal();

            RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).DeleteSubKeyTree(TestRegKey);
            try
                {
                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).DeleteSubKey(TestRegKey);
                }
            catch
                {
                }

            RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default)
                .GetSubKeyNames()
                .Has(TestRegKey)
                .Should()
                .BeFalse();
            }


        private const string TestRegKey = "TEST_RegistryHandler";

        /// <exception cref="ArgumentException">
        ///         <paramref>
        ///             <name>hKey</name>
        ///         </paramref>
        ///     or <paramref>
        ///         <name>view</name>
        ///     </paramref>
        ///     is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">The user does not have the necessary registry rights.</exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to perform this action.</exception>
        /// <exception cref="MemberAccessException">The caller does not have access to the method represented by the delegate (for example, if the method is private). </exception>
        /// <exception cref="InternalTestFailureException">The test fails</exception>
        /// <exception cref="IOException">A system error occurred; for example, the current key has been deleted.</exception>
        /// <exception cref="InvalidCastException">Count registry value is not properly set</exception>
        /// <exception cref="OverflowException">Count registry value is not properly set</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="T:Microsoft.Win32.RegistryKey" /> that contains the specified value is closed (closed keys cannot be accessed). </exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        /// <exception cref="SecurityException">The user does not have the permissions required to read from the registry key. </exception>
        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadObject) + "(String) => Object")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadString) + "(String) => String")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadInt) + "(String) => Nullable`1<Int32>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadLong) + "(String) => Nullable`1<Int64>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadFloat) + "(String) => Nullable`1<Single>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadDouble) + "(String) => Nullable`1<Double>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadChar) + "(String) => Nullable`1<Char>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadBool) + "(String) => Nullable`1<Boolean>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadBinary) + "(String) => Byte[]")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadList) + "(String) => List`1<Object>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadAll) + "() => List`1<Set`2<String, Object>>")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.RemoveAll) + "()")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Remove) + "(String[])")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, Object)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, String)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, IConvertible)")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, Byte[])")]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, IEnumerable`1<Object>)")]
        public void AllMethods()
            {
            /////////////////////////////

            // ReSharper disable ObjectCreationAsStatement
            L.A(() => new RegistryHelper(RegistrySubKey: null, RootKey: RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))).ShouldFail();
            L.A(() => new RegistryHelper("a", RootKey: null)).ShouldFail();
            L.A(() => new RegistryHelper("", RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))).ShouldFail();
            // ReSharper restore ObjectCreationAsStatement
            //
            //            L.A(() => new RegistryHelper("#Q*()HY&)R(B)#(*)__~_~+_)JG)+&&**(@!2-09%*@:><?:\"'\r\n",
            //                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))).ShouldFail();

            L.A(() => this.Reg.Save(Name: null, Obj: (object)5)).ShouldFail();
            L.A(() => this.Reg.Save("a", (object)null)).ShouldFail();

            // unsupported object type
            L.A(() => this.Reg.Save("a", this.Reg)).ShouldFail();

            /////////////////////////////

            this.Reg.LoadObject("a").Should().BeNull();
            this.Reg.LoadString("a").Should().BeNull();
            this.Reg.LoadBinary("a").Should().BeNull();
            this.Reg.LoadChar("a").Should().BeNull();
            this.Reg.LoadBool("a").Should().NotHaveValue();
            this.Reg.LoadDouble("a").Should().NotHaveValue();
            this.Reg.LoadFloat("a").Should().NotHaveValue();
            this.Reg.LoadInt("a").Should().NotHaveValue();
            this.Reg.LoadLong("a").Should().NotHaveValue();

            this.Reg.Save("a", (object)"abc");
            this.Reg.LoadString("a").Should().Be("abc");
            this.Reg.LoadObject("a").Should().Be("abc");

            this.Reg.Save("b", (object)55);
            this.Reg.LoadInt("b").Should().Be(expected: 55);
            this.Reg.LoadObject("b").Should().Be("55");

            this.Reg.Save("c", (object)-5.5f);
            this.Reg.LoadFloat("c").Should().Be(-5.5f);
            this.Reg.LoadObject("c").Should().Be("-5.5");

            this.Reg.Save("d", (double)-5.5);
            this.Reg.LoadDouble("d").Should().Be((double)-5.5);
            this.Reg.LoadObject("d").Should().Be("-5.5");

            this.Reg.Save("e", (object)new byte[] { 5, 243, 224, 21 });
            this.Reg.LoadBinary("e").Should().Equal(5, 243, 224, 21);
            this.Reg.LoadObject("e").ToS().Should().Be(new byte[] { 5, 243, 224, 21 }.ToS());

            this.Reg.Save("f", (object)'c');
            this.Reg.LoadChar("f").Should().Be(expected: 'c');
            this.Reg.LoadObject("f").Should().Be("c");

            this.Reg.Save("g", (object)true);
            this.Reg.LoadBool("g").Should().Be(expected: true);
            this.Reg.LoadObject("g").Should().Be("True");

            this.Reg.Save("h", (object)new object[] { 5, -5.5f, "abc", (double)-55, (double)double.NaN });

            // ReSharper disable once ArgumentsStyleLiteral
            this.Reg.LoadList("h").ToS().Should().Be(new List<object> { 5, -5.5f, "abc", (double)-55, (double)double.NaN }.ToS());

            this.Reg.LoadAll().ShouldBeEquivalentTo(new List<Set<string, object>>
                {
                new Set<string, object>("a", "abc"),
                new Set<string, object>("b", "55"),
                new Set<string, object>("c", "-5.5"),
                new Set<string, object>("d", "-5.5"),
                new Set<string, object>("e", new byte[] {5, 243, 224, 21}),
                new Set<string, object>("f", "c"),
                new Set<string, object>("g", "True"),
                new Set<string, object>("h_Count", "5"),
                new Set<string, object>("h_1", "-5.5"),
                new Set<string, object>("h_2", "abc"),
                new Set<string, object>("h_3", "-55"),
                new Set<string, object>("h_4", "NaN"),
                new Set<string, object>("h_0", "5")
                });

            this.Reg.Remove("a", "b", "c", "h_4", "BAD NAME");

            this.Reg.LoadAll().ShouldBeEquivalentTo(new List<Set<string, object>>
                {
                new Set<string, object>("d", "-5.5"),
                new Set<string, object>("e", new byte[] {5, 243, 224, 21}),
                new Set<string, object>("f", "c"),
                new Set<string, object>("g", "True"),
                new Set<string, object>("h_Count", "5"),
                new Set<string, object>("h_1", "-5.5"),
                new Set<string, object>("h_2", "abc"),
                new Set<string, object>("h_3", "-55"),
                new Set<string, object>("h_0", "5")
                });
            /////////////////////////////////////////////////////
            }

        private RegistryHelper Reg { get; }
        }
    }