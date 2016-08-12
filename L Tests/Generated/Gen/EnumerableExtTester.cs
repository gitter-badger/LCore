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
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt))]
    public partial class EnumerableExtTester : XUnitOutputTester, IDisposable
        {
        public EnumerableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicates) + "(T[]) => T[]")]
        public void RemoveDuplicates_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicates
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicates) + "(IEnumerable) => List`1<T>")]
        public void RemoveDuplicates_IEnumerable_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicates
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Mirror) + "(T[]) => T[]")]
        public void Mirror_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Mirror
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Mirror) + "(IEnumerable`1<T>) => List`1<T>")]
        public void Mirror_IEnumerable_1_T_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Mirror
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Mirror) + "(IEnumerable) => List`1<T>")]
        public void Mirror_IEnumerable_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Mirror
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(T[], Func`2<T, Boolean>) => T[]")]
        public void Select_T_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => List`1<T>")]
        public void Select_IEnumerable_1_T_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(IEnumerable, Func`2<T, Boolean>) => List`1<T>")]
        public void Select_IEnumerable_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(IEnumerable, Func`3<Int32, T, Boolean>) => List`1<T>")]
        public void Select_IEnumerable_Func_3_Int32_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(T[], Func`3<Int32, T, Boolean>) => T[]")]
        public void Select_T_Func_3_Int32_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(List`1<T>, Func`3<Int32, T, Boolean>) => List`1<T>")]
        public void Select_List_1_T_Func_3_Int32_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => List`1<T>")]
        public void Select_IEnumerable_1_T_Func_3_Int32_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt) + "(IEnumerable, Int32, T)")]
        public void SetAt_IEnumerable_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt) + "(IEnumerable, UInt32, T)")]
        public void SetAt_IEnumerable_UInt32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt) + "(IEnumerable`1<T>, Int32, T)")]
        public void SetAt_IEnumerable_1_T_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt) + "(IEnumerable`1<T>, UInt32, T)")]
        public void SetAt_IEnumerable_1_T_UInt32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Shuffle) + "(IEnumerable`1<T>) => List`1<T>")]
        public void Shuffle_IEnumerable_1_T_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Shuffle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Shuffle) + "(T[]) => T[]")]
        public void Shuffle_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Shuffle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Shuffle) + "(IEnumerable) => List`1<T>")]
        public void Shuffle_IEnumerable_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Shuffle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sort) + "(IList)")]
        public void Sort_IList()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sort
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sort) + "(IList`1<T>, Func`3<T, T, Int32>)")]
        public void Sort_IList_1_T_Func_3_T_T_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sort
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sort) + "(IList`1<T>, Func`2<T, IComparable>)")]
        public void Sort_IList_1_T_Func_2_T_IComparable()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sort
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sum) + "(IEnumerable`1<T>, Func`2<T, U>) => UInt32")]
        public void Sum()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Swap) + "(T[], Int32, Int32)")]
        public void Swap_T_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Swap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Swap) + "(IList, Int32, Int32)")]
        public void Swap_IList_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Swap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.TotalCount) + "(IEnumerable) => Int32")]
        public void TotalCount()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.TotalCount
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While) + "(IEnumerable, Func`2<T, Boolean>) => Boolean")]
        public void While_IEnumerable_Func_2_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While) + "(IEnumerable, Func`3<Int32, T, Boolean>) => Boolean")]
        public void While_IEnumerable_Func_3_Int32_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Boolean")]
        public void While_IEnumerable_1_T_Func_2_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => Boolean")]
        public void While_IEnumerable_1_T_Func_3_Int32_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While) + "(Action`1<T>, Func`1<Boolean>, IEnumerable`1<T>)")]
        public void While_Action_1_T_Func_1_Boolean_IEnumerable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable`1<T>, Int32, Func`2<T, Boolean>) => List`1<T>")]
        public void First_IEnumerable_1_T_Int32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable`1<T>, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        public void First_IEnumerable_1_T_UInt32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(T[], Int32, Func`2<T, Boolean>) => T[]")]
        public void First_T_Int32_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(T[], UInt32, Func`2<T, Boolean>) => T[]")]
        public void First_T_UInt32_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable, T) => T")]
        public void First_IEnumerable_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Flatten) + "(IEnumerable) => List`1<T>")]
        public void Flatten()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Flatten
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt) + "(IEnumerable, Int32) => Object")]
        public void GetAt_IEnumerable_Int32_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt) + "(IEnumerable, UInt32) => Object")]
        public void GetAt_IEnumerable_UInt32_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt) + "(IEnumerable`1<T>, Int32) => T")]
        public void GetAt_IEnumerable_1_T_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt) + "(IEnumerable`1<T>, UInt32) => T")]
        public void GetAt_IEnumerable_1_T_UInt32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAtIndices) + "(T[], Int32[]) => T[]")]
        public void GetAtIndices_T_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAtIndices
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAtIndices) + "(IEnumerable, Int32[]) => List`1<T>")]
        public void GetAtIndices_IEnumerable_Int32_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAtIndices
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAtIndices) + "(IEnumerable`1<T>, Int32[]) => List`1<T>")]
        public void GetAtIndices_IEnumerable_1_T_Int32_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAtIndices
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Group) + "(IEnumerable`1<T>) => Dictionary`2<String, List`1<T>>")]
        public void Group_IEnumerable_1_T_Dictionary_2_String_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Group
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Group) + "(IEnumerable`1<TValue>, Func`2<TValue, TKey>) => Dictionary`2<TKey, List`1<TValue>>")]
        public void Group_IEnumerable_1_TValue_Func_2_TValue_TKey_Dictionary_2_TKey_List_1_TValue()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Group
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GroupTwice) + "(IEnumerable`1<T>, Func`2<T, U>, Func`2<T, V>) => Dictionary`2<U, Dictionary`2<V, List`1<T>>>")]
        public void GroupTwice()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GroupTwice
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has) + "(IEnumerable, T) => Boolean")]
        public void Has_IEnumerable_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has) + "(IEnumerable, Int32, T) => Boolean")]
        public void Has_IEnumerable_Int32_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has) + "(IEnumerable, UInt32, T) => Boolean")]
        public void Has_IEnumerable_UInt32_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny) + "(IEnumerable, IEnumerable) => Boolean")]
        public void HasAny_IEnumerable_IEnumerable_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny) + "(IEnumerable`1<T>, IEnumerable`1<T>) => Boolean")]
        public void HasAny_IEnumerable_1_T_IEnumerable_1_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny) + "(IEnumerable, Object[]) => Boolean")]
        public void HasAny_IEnumerable_Object_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny) + "(IEnumerable`1<T>, T[]) => Boolean")]
        public void HasAny_IEnumerable_1_T_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has) + "(IEnumerable, Func`2<T, Boolean>) => Boolean")]
        public void Has_IEnumerable_Func_2_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Boolean")]
        public void Has_IEnumerable_1_T_Func_2_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasIndex) + "(IEnumerable, Int32) => Boolean")]
        public void HasIndex_IEnumerable_Int32_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasIndex
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasIndex) + "(IEnumerable, UInt32) => Boolean")]
        public void HasIndex_IEnumerable_UInt32_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasIndex
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Index) + "(IEnumerable, Func`2<Object, U>) => Dictionary`2<U, Object>")]
        public void Index_IEnumerable_Func_2_Object_U_Dictionary_2_U_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Index
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Index) + "(IEnumerable`1<T>, Func`2<T, U>) => Dictionary`2<U, T>")]
        public void Index_IEnumerable_1_T_Func_2_T_U_Dictionary_2_U_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Index
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IndexTwice) + "(IEnumerable`1<T>, Func`2<T, U>, Func`2<T, V>) => Dictionary`2<U, Dictionary`2<V, T>>")]
        public void IndexTwice()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IndexTwice
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IndexOf) + "(IEnumerable, Func`2<T, Boolean>) => Nullable`1<Int32>")]
        public void IndexOf_IEnumerable_Func_2_T_Boolean_Nullable_1_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IndexOf
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IndexOf) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Nullable`1<Int32>")]
        public void IndexOf_IEnumerable_1_T_Func_2_T_Boolean_Nullable_1_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IndexOf
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IsEmpty) + "(IEnumerable) => Boolean")]
        public void IsEmpty()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IsEmpty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable, Func`2<T, Boolean>) => T")]
        public void Last_IEnumerable_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(T[], Func`2<Object, Boolean>) => T")]
        public void Last_T_Func_2_Object_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => T")]
        public void Last_IEnumerable_1_T_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable, Int32, Func`2<T, Boolean>) => List`1<T>")]
        public void Last_IEnumerable_Int32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        public void Last_IEnumerable_UInt32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable`1<T>, Int32, Func`2<T, Boolean>) => List`1<T>")]
        public void Last_IEnumerable_1_T_Int32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable`1<T>, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        public void Last_IEnumerable_1_T_UInt32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(T[], Int32, Func`2<T, Boolean>) => T[]")]
        public void Last_T_Int32_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(T[], UInt32, Func`2<T, Boolean>) => T[]")]
        public void Last_T_UInt32_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last) + "(IEnumerable, T) => T")]
        public void Last_IEnumerable_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.List) + "(IEnumerable, Boolean) => List`1<Object>")]
        public void List_IEnumerable_Boolean_List_1_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.List
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.List) + "(IEnumerable`1<T>, Boolean) => List`1<T>")]
        public void List_IEnumerable_1_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.List
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.List) + "(IEnumerable, Boolean) => List`1<T>")]
        public void List_IEnumerable_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.List
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.List) + "(IEnumerable`1<T>, Boolean) => List`1<U>")]
        public void List_IEnumerable_1_T_Boolean_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.List
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Move) + "(T[], Int32, Int32)")]
        public void Move_T_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Move
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Move) + "(IList, Int32, Int32)")]
        public void Move_IList_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Move
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named) + "(IEnumerable, String) => List`1<INamed>")]
        public void Named_IEnumerable_String_List_1_INamed()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named) + "(T[], String) => T[]")]
        public void Named_T_String_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named) + "(IEnumerable`1<T>, String) => IEnumerable`1<T>")]
        public void Named_IEnumerable_1_T_String_IEnumerable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named) + "(IEnumerable, String, Func`2<Object, String>) => List`1<Object>")]
        public void Named_IEnumerable_String_Func_2_Object_String_List_1_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named) + "(IEnumerable`1<T>, String, Func`2<T, String>) => List`1<T>")]
        public void Named_IEnumerable_1_T_String_Func_2_T_String_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named) + "(T[], String, Func`2<T, String>) => T[]")]
        public void Named_T_String_Func_2_T_String_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random) + "(IEnumerable`1<T>, Int32, Boolean) => List`1<T>")]
        public void Random_IEnumerable_1_T_Int32_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random) + "(IEnumerable`1<T>, UInt32, Boolean) => List`1<T>")]
        public void Random_IEnumerable_1_T_UInt32_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random) + "(T[], Int32, Boolean) => T[]")]
        public void Random_T_Int32_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random) + "(T[], UInt32, Boolean) => T[]")]
        public void Random_T_UInt32_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random) + "(IEnumerable`1<T>) => T")]
        public void Random_IEnumerable_1_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Remove) + "(IEnumerable`1<T>, T[]) => List`1<T>")]
        public void Remove_IEnumerable_1_T_T_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Remove) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => List`1<T>")]
        public void Remove_IEnumerable_1_T_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Remove) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => List`1<T>")]
        public void Remove_IEnumerable_1_T_Func_3_Int32_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveAt) + "(IEnumerable`1<T>, Int32[]) => List`1<T>")]
        public void RemoveAt_IEnumerable_1_T_Int32_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveAt) + "(T[], Int32[]) => T[]")]
        public void RemoveAt_T_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicate) + "(IEnumerable`1<T>, Func`2<T, U>) => List`1<T>")]
        public void RemoveDuplicate_IEnumerable_1_T_Func_2_T_U_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicate) + "(T[], Func`2<T, U>) => T[]")]
        public void RemoveDuplicate_T_Func_2_T_U_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicate) + "(IEnumerable, Func`2<T, U>) => List`1<T>")]
        public void RemoveDuplicate_IEnumerable_Func_2_T_U_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicates) + "(IEnumerable`1<T>) => List`1<T>")]
        public void RemoveDuplicates_IEnumerable_1_T_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicates
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add) + "(T[], IEnumerable`1<T>) => T[]")]
        public void Add_T_IEnumerable_1_T_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add) + "(T[], T[]) => T[]")]
        public void Add_T_T_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add) + "(List`1<T>, T[])")]
        public void Add_List_1_T_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add) + "(List`1<T>, IEnumerable`1<T>)")]
        public void Add_List_1_T_IEnumerable_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.AddTo) + "(IEnumerable`1<T>, ICollection)")]
        public void AddTo()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.AddTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All) + "(IEnumerable, Func`2<Object, Boolean>) => Boolean")]
        public void All_IEnumerable_Func_2_Object_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => Boolean")]
        public void All_IEnumerable_1_T_Func_2_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All) + "(IEnumerable, Func`3<Int32, Object, Boolean>) => Boolean")]
        public void All_IEnumerable_Func_3_Int32_Object_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All) + "(IEnumerable, Func`3<Int32, T, Boolean>) => Boolean")]
        public void All_IEnumerable_Func_3_Int32_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All) + "(IEnumerable`1<T>, Func`3<Int32, T, Boolean>) => Boolean")]
        public void All_IEnumerable_1_T_Func_3_Int32_T_Boolean_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Append) + "(T[], T[]) => T[]")]
        public void Append()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Append
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array) + "(IEnumerable) => Object[]")]
        public void Array_IEnumerable_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array) + "(IEnumerable) => T[]")]
        public void Array_IEnumerable_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array) + "(IEnumerable`1<T>) => T[]")]
        public void Array_IEnumerable_1_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array) + "(IEnumerable`1<T>) => U[]")]
        public void Array_IEnumerable_1_T_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(IEnumerable, Func`2<T, T>) => List`1<T>")]
        public void Collect_IEnumerable_Func_2_T_T_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(IEnumerable`1<T>, Func`2<T, T>) => List`1<T>")]
        public void Collect_IEnumerable_1_T_Func_2_T_T_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(T[], Func`2<T, T>) => T[]")]
        public void Collect_T_Func_2_T_T_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(List`1<T>, Func`2<T, T>) => List`1<T>")]
        public void Collect_List_1_T_Func_2_T_T_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(IEnumerable, Func`3<Int32, Object, Object>) => List`1<Object>")]
        public void Collect_IEnumerable_Func_3_Int32_Object_Object_List_1_Object()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(IEnumerable, Func`3<Int32, T, T>) => List`1<T>")]
        public void Collect_IEnumerable_Func_3_Int32_T_T_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(IEnumerable`1<T>, Func`3<Int32, T, T>) => List`1<T>")]
        public void Collect_IEnumerable_1_T_Func_3_Int32_T_T_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(T[], Func`3<Int32, T, T>) => T[]")]
        public void Collect_T_Func_3_Int32_T_T_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(List`1<T>, Func`3<Int32, T, T>) => List`1<T>")]
        public void Collect_List_1_T_Func_3_Int32_T_T_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(Func`1<T>, Int32) => List`1<T>")]
        public void Collect_Func_1_T_Int32_List_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect) + "(Func`2<Int32, T>, Int32) => List`1<T>")]
        public void Collect_Func_2_Int32_T_Int32_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr) + "(String, Func`2<Char, Char>) => String")]
        public void CollectStr_String_Func_2_Char_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.CollectStr
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr) + "(List`1<T>, Func`3<Int32, T, String>) => String")]
        public void CollectStr_List_1_T_Func_3_Int32_T_String_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.CollectStr
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr) + "(T[], Func`3<Int32, T, String>) => String")]
        public void CollectStr_T_Func_3_Int32_T_String_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.CollectStr
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr) + "(U, Func`3<Int32, T, String>) => String")]
        public void CollectStr_U_Func_3_Int32_T_String_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine) + "(IEnumerable`1<String>) => String")]
        public void Combine_IEnumerable_1_String_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine) + "(IEnumerable`1<String>, Char) => String")]
        public void Combine_IEnumerable_1_String_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine) + "(IEnumerable`1<T>, String) => String")]
        public void Combine_IEnumerable_1_T_String_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Combine
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine) + "(IEnumerable`1<T>, Char) => String")]
        public void Combine_IEnumerable_1_T_Char_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Combine
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(IEnumerable, Func`2<Object, Object>) => List`1<Object>")]
        public void Convert_IEnumerable_Func_2_Object_Object_List_1_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(T[], Func`2<T, U>) => U[]")]
        public void Convert_T_Func_2_T_U_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(List`1<T>, Func`2<T, U>) => List`1<U>")]
        public void Convert_List_1_T_Func_2_T_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(IEnumerable`1<T>, Func`2<T, U>) => List`1<U>")]
        public void Convert_IEnumerable_1_T_Func_2_T_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll) + "(IEnumerable, Func`2<Object, IEnumerable`1<Object>>) => List`1<Object>")]
        public void ConvertAll_IEnumerable_Func_2_Object_IEnumerable_1_Object_List_1_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll) + "(IEnumerable, Func`2<T, IEnumerable`1<U>>) => List`1<U>")]
        public void ConvertAll_IEnumerable_Func_2_T_IEnumerable_1_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll) + "(IEnumerable`1<T>, Func`2<T, IEnumerable`1<U>>) => List`1<U>")]
        public void ConvertAll_IEnumerable_1_T_Func_2_T_IEnumerable_1_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll) + "(T[], Func`2<T, IEnumerable`1<U>>) => U[]")]
        public void ConvertAll_T_Func_2_T_IEnumerable_1_U_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll) + "(List`1<T>, Func`2<T, IEnumerable`1<U>>) => List`1<U>")]
        public void ConvertAll_List_1_T_Func_2_T_IEnumerable_1_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(IEnumerable, Func`3<Int32, Object, Object>) => List`1<Object>")]
        public void Convert_IEnumerable_Func_3_Int32_Object_Object_List_1_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(T[], Func`3<Int32, T, U>) => U[]")]
        public void Convert_T_Func_3_Int32_T_U_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(List`1<T>, Func`3<Int32, T, U>) => List`1<U>")]
        public void Convert_List_1_T_Func_3_Int32_T_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert) + "(IEnumerable`1<T>, Func`3<Int32, T, U>) => List`1<U>")]
        public void Convert_IEnumerable_1_T_Func_3_Int32_T_U_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Count) + "(T) => UInt32")]
        public void Count_T_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Count) + "(IEnumerable`1<T>, T) => UInt32")]
        public void Count_IEnumerable_1_T_T_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Count) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => UInt32")]
        public void Count_IEnumerable_1_T_Func_2_T_Boolean_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Cycle) + "(IEnumerable, Func`2<Object, Boolean>)")]
        public void Cycle_IEnumerable_Func_2_Object_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Cycle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Cycle) + "(IEnumerable`1<T>, Func`2<T, Boolean>)")]
        public void Cycle_IEnumerable_1_T_Func_2_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Cycle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each) + "(IEnumerable, Action`1<Object>)")]
        public void Each_IEnumerable_Action_1_Object()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each) + "(IEnumerable, Action`1<T>)")]
        public void Each_IEnumerable_Action_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each) + "(IEnumerable`1<T>, Action`1<T>)")]
        public void Each_IEnumerable_1_T_Action_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each) + "(IEnumerable, Action`2<Int32, Object>)")]
        public void Each_IEnumerable_Action_2_Int32_Object()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each) + "(IEnumerable`1<T>, Action`2<Int32, T>)")]
        public void Each_IEnumerable_1_T_Action_2_Int32_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each) + "(Action`1<T>, IEnumerable`1<T>)")]
        public void Each_Action_1_T_IEnumerable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Each
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Equivalent) + "(IEnumerable, IEnumerable) => Boolean")]
        public void Equivalent()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Equivalent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Fill) + "(T[], T) => T[]")]
        public void Fill_T_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Fill) + "(List`1<T>, T) => List`1<T>")]
        public void Fill_List_1_T_T_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Fill) + "(T[], Func`2<T, T>) => T[]")]
        public void Fill_T_Func_2_T_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Filter) + "(IEnumerable, Boolean) => List`1<T>")]
        public void Filter_IEnumerable_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Filter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Filter) + "(T[], Boolean) => U[]")]
        public void Filter_T_Boolean_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Filter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Filter) + "(List`1<T>, Boolean) => List`1<U>")]
        public void Filter_List_1_T_Boolean_List_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Filter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable, Func`2<T, Boolean>) => T")]
        public void First_IEnumerable_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(T[], Func`2<Object, Boolean>) => T")]
        public void First_T_Func_2_Object_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable`1<T>, Func`2<T, Boolean>) => T")]
        public void First_IEnumerable_1_T_Func_2_T_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable, Int32, Func`2<T, Boolean>) => List`1<T>")]
        public void First_IEnumerable_Int32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First) + "(IEnumerable, UInt32, Func`2<T, Boolean>) => List`1<T>")]
        public void First_IEnumerable_UInt32_Func_2_T_Boolean_List_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        }
    }