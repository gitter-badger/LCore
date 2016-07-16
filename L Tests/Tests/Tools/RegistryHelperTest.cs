using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using FluentAssertions;
using LCore.Extensions;
using LCore.Tests;
using LCore.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Xunit;

// ReSharper disable ObjectCreationAsStatement
// ReSharper disable RedundantCast

namespace L_Tests.Tests.Tools
    {
    public class RegistryHelperTest
        {
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
        [Fact]
        [TestCategory(L.Test.Categories.Tools)]
        public void Test_RegistryHandler()
            {
            var Reg = new RegistryHelper("TEST_RegistryHandler", RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default));

            Reg.RemoveAll();
            Reg.LoadAll().ShouldBeEquivalentTo(new object[] { });

            /////////////////////////////

            L.A(() => new RegistryHelper(null, RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))).ShouldFail();
            L.A(() => new RegistryHelper("a", null)).ShouldFail();

            L.A(() => new RegistryHelper("#Q*()HY&)R(B)#(*)__~_~+_)JG)+&&**(@!2-09%*@:><?:\"'\r\n",
                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))).ShouldFail();

            L.A(() => Reg.Save(null, (object)5)).ShouldFail();
            L.A(() => Reg.Save("a", (object)null)).ShouldFail();

            // unsupported object type
            L.A(() => Reg.Save("a", Reg)).ShouldFail();

            /////////////////////////////

            Reg.LoadObject("a").Should().BeNull();
            Reg.LoadString("a").Should().BeNull();
            Reg.LoadBinary("a").Should().BeNull();
            Reg.LoadChar("a").Should().BeNull();
            Reg.LoadBool("a").Should().NotHaveValue();
            Reg.LoadDouble("a").Should().NotHaveValue();
            Reg.LoadFloat("a").Should().NotHaveValue();
            Reg.LoadInt("a").Should().NotHaveValue();
            Reg.LoadLong("a").Should().NotHaveValue();

            Reg.Save("a", (object)"abc");
            Reg.LoadString("a").Should().Be("abc");
            Reg.LoadObject("a").Should().Be("abc");

            Reg.Save("b", (object)55);
            Reg.LoadInt("b").Should().Be(55);
            Reg.LoadObject("b").Should().Be("55");

            Reg.Save("c", (object)-5.5f);
            Reg.LoadFloat("c").Should().Be(-5.5f);
            Reg.LoadObject("c").Should().Be("-5.5");

            Reg.Save("d", (double)-5.5);
            Reg.LoadDouble("d").Should().Be((double)-5.5);
            Reg.LoadObject("d").Should().Be("-5.5");

            Reg.Save("e", (object)new byte[] { 5, 243, 224, 21 });
            Reg.LoadBinary("e").ShouldBeEquivalentTo(new byte[] { 5, 243, 224, 21 });
            Reg.LoadObject("e").ShouldBeEquivalentTo(new byte[] { 5, 243, 224, 21 });

            Reg.Save("f", (object)'c');
            Reg.LoadChar("f").Should().Be('c');
            Reg.LoadObject("f").Should().Be("c");

            Reg.Save("g", (object)true);
            Reg.LoadBool("g").Should().Be(true);
            Reg.LoadObject("g").Should().Be("True");

            Reg.Save("h", (object)new object[] { 5, -5.5f, "abc", (double)-55, (double)double.NaN });
            Reg.LoadList("h").ShouldBeEquivalentTo(new object[] { 5, -5.5f, "abc", (double)-55, (double)double.NaN });

            Reg.LoadAll().ShouldBeEquivalentTo(new object[]
                {
                new Set<string,object>("a", "abc"),
                new Set<string,object>("b", "55"),
                new Set<string,object>("c", "-5.5"),
                new Set<string,object>("d", "-5.5"),
                new Set<string,object>("e", new byte[] {5, 243, 224, 21}),
                new Set<string,object>("f", "c"),
                new Set<string,object>("g", "True"),
                new Set<string,object>("h_Count", "5"),
                new Set<string,object>("h_1", "-5.5"),
                new Set<string,object>("h_2", "abc"),
                new Set<string,object>("h_3", "-55"),
                new Set<string,object>("h_4", "NaN"),
                new Set<string,object>("h_0", "5")
                });
            /////////////////////////////////////////////////////

            Reg.RemoveAll();

            Reg.LoadAll().ShouldBeEquivalentTo(new object[] { });
            }
        }
    }