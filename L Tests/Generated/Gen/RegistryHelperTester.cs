using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper))]
    public partial class RegistryHelperTester : XUnitOutputTester, IDisposable
        {
        public RegistryHelperTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.RemoveAll) + "()")]
        public void RemoveAll()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.RemoveAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Remove) + "(String[])")]
        public void Remove()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, Object)")]
        public void Save_String_Object()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, String)")]
        public void Save_String_String()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, IConvertible)")]
        public void Save_String_IConvertible()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, Byte[])")]
        public void Save_String_Byte()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save) + "(String, IEnumerable`1<Object>)")]
        public void Save_String_IEnumerable_1_Object()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadObject) + "(String) => Object")]
        public void LoadObject()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadObject
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadString) + "(String) => String")]
        public void LoadString()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadInt) + "(String) => Nullable`1<Int32>")]
        public void LoadInt()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadInt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadLong) + "(String) => Nullable`1<Int64>")]
        public void LoadLong()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadLong
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadFloat) + "(String) => Nullable`1<Single>")]
        public void LoadFloat()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadFloat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadDouble) + "(String) => Nullable`1<Double>")]
        public void LoadDouble()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadDouble
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadChar) + "(String) => Nullable`1<Char>")]
        public void LoadChar()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadChar
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadBool) + "(String) => Nullable`1<Boolean>")]
        public void LoadBool()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadBool
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadBinary) + "(String) => Byte[]")]
        public void LoadBinary()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadBinary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadList) + "(String) => List`1<Object>")]
        public void LoadList()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadList
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadAll) + "() => List`1<Set`2<String, Object>>")]
        public void LoadAll()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadAll
            }

        }
    }