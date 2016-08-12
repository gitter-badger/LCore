using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt))]
    public partial class DictionaryExtTester : XUnitOutputTester, IDisposable
        {
        public DictionaryExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.Flip) + "(Dictionary`2<TKey, TValue>) => Dictionary`2<TValue, TKey>")]
        public void Flip()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.Flip
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.Merge) + "(IDictionary`2<TKey, TValue>, IDictionary`2<TKey, TValue>, Func`2<KeyValuePair`2<TKey, TValue>, KeyValuePair`2<TKey, TValue>>)")]
        public void Merge()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.Merge
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.AddRange) + "(IDictionary`2<TKey, TValue>, IDictionary`2<TKey, TValue>)")]
        public void AddRange()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.AddRange
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.GetAllValues) + "(Dictionary`2<TKey, TValueList>) => List`1<TValue>")]
        public void GetAllValues()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.GetAllValues
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeAdd) + "(IDictionary`2<TKey, TValue>, TKey, TValue)")]
        public void SafeAdd()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeAdd
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeSet) + "(IDictionary`2<TKey, TValue>, TKey, TValue)")]
        public void SafeSet()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeSet
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeGet) + "(IDictionary`2<TKey, TValue>, TKey) => TValue")]
        public void SafeGet()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeGet
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.SafeRemove) + "(Dictionary`2<TKey, TValue>, TKey)")]
        public void SafeRemove()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.SafeRemove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`2<TKey, TValue>>) => Dictionary`2<TKey, List`1<TValue>>")]
        public void ToDictionary_IEnumerable_1_Tuple_2_TKey_TValue_Dictionary_2_TKey_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`3<TKey, TKey2, TValue>>) => Dictionary`2<TKey, Dictionary`2<TKey2, List`1<TValue>>>")]
        public void ToDictionary_IEnumerable_1_Tuple_3_TKey_TKey2_TValue_Dictionary_2_TKey_Dictionary_2_TKey2_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`4<TKey, TKey2, TKey3, TValue>>) => Dictionary`2<TKey, Dictionary`2<TKey2, Dictionary`2<TKey3, List`1<TValue>>>>")]
        public void ToDictionary_IEnumerable_1_Tuple_4_TKey_TKey2_TKey3_TValue_Dictionary_2_TKey_Dictionary_2_TKey2_Dictionary_2_TKey3_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`5<TKey, TKey2, TKey3, TKey4, TValue>>) => Dictionary`2<TKey, Dictionary`2<TKey2, Dictionary`2<TKey3, Dictionary`2<TKey4, List`1<TValue>>>>>")]
        public void ToDictionary_IEnumerable_1_Tuple_5_TKey_TKey2_TKey3_TKey4_TValue_Dictionary_2_TKey_Dictionary_2_TKey2_Dictionary_2_TKey3_Dictionary_2_TKey4_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`6<TKey, TKey2, TKey3, TKey4, TKey5, TValue>>) => Dictionary`2<TKey, Dictionary`2<TKey2, Dictionary`2<TKey3, Dictionary`2<TKey4, Dictionary`2<TKey5, List`1<TValue>>>>>>")]
        public void ToDictionary_IEnumerable_1_Tuple_6_TKey_TKey2_TKey3_TKey4_TKey5_TValue_Dictionary_2_TKey_Dictionary_2_TKey2_Dictionary_2_TKey3_Dictionary_2_TKey4_Dictionary_2_TKey5_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`7<TKey, TKey2, TKey3, TKey4, TKey5, TKey6, TValue>>) => Dictionary`2<TKey, Dictionary`2<TKey2, Dictionary`2<TKey3, Dictionary`2<TKey4, Dictionary`2<TKey5, Dictionary`2<TKey6, List`1<TValue>>>>>>>")]
        public void ToDictionary_IEnumerable_1_Tuple_7_TKey_TKey2_TKey3_TKey4_TKey5_TKey6_TValue_Dictionary_2_TKey_Dictionary_2_TKey2_Dictionary_2_TKey3_Dictionary_2_TKey4_Dictionary_2_TKey5_Dictionary_2_TKey6_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(DictionaryExt) + "." + nameof(DictionaryExt.ToDictionary) + "(IEnumerable`1<Tuple`8<TKey, TKey2, TKey3, TKey4, TKey5, TKey6, TKey7, TValue>>) => Dictionary`2<TKey, Dictionary`2<TKey2, Dictionary`2<TKey3, Dictionary`2<TKey4, Dictionary`2<TKey5, Dictionary`2<TKey6, Dictionary`2<TKey7, List`1<TValue>>>>>>>>")]
        public void ToDictionary_IEnumerable_1_Tuple_8_TKey_TKey2_TKey3_TKey4_TKey5_TKey6_TKey7_TValue_Dictionary_2_TKey_Dictionary_2_TKey2_Dictionary_2_TKey3_Dictionary_2_TKey4_Dictionary_2_TKey5_Dictionary_2_TKey6_Dictionary_2_TKey7_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.DictionaryExt.ToDictionary
            }

        }
    }