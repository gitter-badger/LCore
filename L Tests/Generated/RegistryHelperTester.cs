using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.LUnit;
using LCore.Tools;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Tools
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper))]
    public partial class RegistryHelperTester : XUnitOutputTester
        {
        public RegistryHelperTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        ~RegistryHelperTester() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.RemoveAll))]
        public void RemoveAll()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.RemoveAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Remove))]
        public void Remove()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save))]
        public void Save_String_Object()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save))]
        public void Save_String_String()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save))]
        public void Save_String_IConvertible()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save))]
        public void Save_String_Byte()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.Save))]
        public void Save_String_IEnumerable_1()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.Save
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadObject))]
        public void LoadObject()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadObject
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadString))]
        public void LoadString()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadString
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadInt))]
        public void LoadInt()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadInt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadLong))]
        public void LoadLong()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadLong
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadFloat))]
        public void LoadFloat()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadFloat
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadDouble))]
        public void LoadDouble()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadDouble
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadChar))]
        public void LoadChar()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadChar
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadBool))]
        public void LoadBool()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadBool
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadBinary))]
        public void LoadBinary()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadBinary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadList))]
        public void LoadList()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadList
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Tools) + "." + nameof(RegistryHelper) + "." + nameof(RegistryHelper.LoadAll))]
        public void LoadAll()
            {
            // TODO: Implement method test LCore.Tools.RegistryHelper.LoadAll
            }

        }
    }