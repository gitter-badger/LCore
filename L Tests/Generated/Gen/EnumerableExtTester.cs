using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;
using LCore.LUnit;
using Xunit;
using Xunit.Abstractions;
// ReSharper disable PartialTypeWithSinglePart

namespace L_Tests.LCore.Extensions
    {
    [Trait(Traits.TargetClass, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt))]
    public partial class EnumerableExtTester : XUnitOutputTester, IDisposable
        {
        public EnumerableExtTester([NotNull] ITestOutputHelper Output) : base(Output) { }

        public void Dispose() { }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicates))]
        public void RemoveDuplicates_TArray_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicates
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicates))]
        public void RemoveDuplicates_IEnumerable_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicates
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Mirror))]
        public void Mirror_TArray_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Mirror
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Mirror))]
        public void Mirror_IEnumerable_1_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Mirror
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Mirror))]
        public void Mirror_IEnumerable_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Mirror
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_TArray_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_IEnumerable_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_IEnumerable_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_IEnumerable_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_TArray_Func_3_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_List_1_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Select))]
        public void Select_IEnumerable_1_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Select
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt))]
        public void SetAt_IEnumerable_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt))]
        public void SetAt_IEnumerable_UInt32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt))]
        public void SetAt_IEnumerable_1_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.SetAt))]
        public void SetAt_IEnumerable_1_UInt32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.SetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Shuffle))]
        public void Shuffle_IEnumerable_1_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Shuffle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Shuffle))]
        public void Shuffle_TArray_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Shuffle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Shuffle))]
        public void Shuffle_IEnumerable_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Shuffle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sort))]
        public void Sort_IList()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sort
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sort))]
        public void Sort_IList_1_Func_3()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sort
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sort))]
        public void Sort_IList_1_Func_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sort
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Sum))]
        public void Sum()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Sum
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Swap))]
        public void Swap_TArray_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Swap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Swap))]
        public void Swap_IList_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Swap
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.TotalCount))]
        public void TotalCount()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.TotalCount
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While))]
        public void While_IEnumerable_Func_2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While))]
        public void While_IEnumerable_Func_3_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While))]
        public void While_IEnumerable_1_Func_2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While))]
        public void While_IEnumerable_1_Func_3_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.While))]
        public void While_Action_1_Func_1_IEnumerable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.While
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_1_Int32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_1_UInt32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_TArray_Int32_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_TArray_UInt32_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Flatten))]
        public void Flatten()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Flatten
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt))]
        public void GetAt_IEnumerable_Int32_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt))]
        public void GetAt_IEnumerable_UInt32_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt))]
        public void GetAt_IEnumerable_1_Int32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAt))]
        public void GetAt_IEnumerable_1_UInt32_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAtIndices))]
        public void GetAtIndices_TArray_Int32Array_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAtIndices
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAtIndices))]
        public void GetAtIndices_IEnumerable_Int32Array_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAtIndices
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GetAtIndices))]
        public void GetAtIndices_IEnumerable_1_Int32Array_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GetAtIndices
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Group))]
        public void Group_IEnumerable_1_Dictionary_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Group
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Group))]
        public void Group_IEnumerable_1_Func_2_Dictionary_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Group
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.GroupTwice))]
        public void GroupTwice()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.GroupTwice
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has))]
        public void Has_IEnumerable_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has))]
        public void Has_IEnumerable_Int32_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has))]
        public void Has_IEnumerable_UInt32_T_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny))]
        public void HasAny_IEnumerable_IEnumerable_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny))]
        public void HasAny_IEnumerable_1_IEnumerable_1_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny))]
        public void HasAny_IEnumerable_ObjectArray_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasAny))]
        public void HasAny_IEnumerable_1_TArray_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasAny
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has))]
        public void Has_IEnumerable_Func_2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Has))]
        public void Has_IEnumerable_1_Func_2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Has
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasIndex))]
        public void HasIndex_IEnumerable_Int32_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasIndex
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.HasIndex))]
        public void HasIndex_IEnumerable_UInt32_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.HasIndex
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Index))]
        public void Index_IEnumerable_Func_2_Dictionary_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Index
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Index))]
        public void Index_IEnumerable_1_Func_2_Dictionary_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Index
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IndexTwice))]
        public void IndexTwice()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IndexTwice
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IndexOf))]
        public void IndexOf_IEnumerable_Func_2_Nullable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IndexOf
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IndexOf))]
        public void IndexOf_IEnumerable_1_Func_2_Nullable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IndexOf
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.IsEmpty))]
        public void IsEmpty()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.IsEmpty
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_TArray_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_1_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_Int32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_UInt32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_1_Int32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_1_UInt32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_TArray_Int32_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_TArray_UInt32_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Last))]
        public void Last_IEnumerable_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Last
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.List))]
        public void List_IEnumerable_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.List
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.List))]
        public void List_IEnumerable_1_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.List
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Move))]
        public void Move_TArray_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Move
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Move))]
        public void Move_IList_Int32_Int32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Move
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named))]
        public void Named_IEnumerable_String_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named))]
        public void Named_TArray_String_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named))]
        public void Named_IEnumerable_1_String_IEnumerable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named))]
        public void Named_IEnumerable_String_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Named
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named))]
        public void Named_IEnumerable_1_String_Func_2_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Named))]
        public void Named_TArray_String_Func_2_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random))]
        public void Random_IEnumerable_1_Int32_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random))]
        public void Random_IEnumerable_1_UInt32_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random))]
        public void Random_TArray_Int32_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random))]
        public void Random_TArray_UInt32_Boolean_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Random))]
        public void Random_IEnumerable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Random
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Remove))]
        public void Remove_IEnumerable_1_TArray_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Remove))]
        public void Remove_IEnumerable_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Remove))]
        public void Remove_IEnumerable_1_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Remove
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveAt))]
        public void RemoveAt_IEnumerable_1_Int32Array_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveAt))]
        public void RemoveAt_TArray_Int32Array_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveAt
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicate))]
        public void RemoveDuplicate_IEnumerable_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicate))]
        public void RemoveDuplicate_TArray_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicate))]
        public void RemoveDuplicate_IEnumerable_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicate
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.RemoveDuplicates))]
        public void RemoveDuplicates_IEnumerable_1_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.RemoveDuplicates
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add))]
        public void Add_TArray_IEnumerable_1_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add))]
        public void Add_TArray_TArray_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add))]
        public void Add_List_1_TArray()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Add))]
        public void Add_List_1_IEnumerable_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.AddTo))]
        public void AddTo()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.AddTo
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All))]
        public void All_IEnumerable_Func_2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All))]
        public void All_IEnumerable_1_Func_2_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All))]
        public void All_IEnumerable_Func_3_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.All))]
        public void All_IEnumerable_1_Func_3_Boolean()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.All
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Append))]
        public void Append()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Append
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array))]
        public void Array_IEnumerable_Object()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array))]
        public void Array_IEnumerable_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array))]
        public void Array_IEnumerable_1_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Array))]
        public void Array_IEnumerable_1_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Array
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_IEnumerable_Func_2_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_IEnumerable_1_Func_2_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_TArray_Func_2_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_List_1_Func_2_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_IEnumerable_Func_3_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_IEnumerable_1_Func_3_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_TArray_Func_3_T()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_List_1_Func_3_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_Func_1_Int32_List_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Collect))]
        public void Collect_Func_2_Int32_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Collect
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr))]
        public void CollectStr_String_Func_2_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.CollectStr
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr))]
        public void CollectStr_List_1_Func_3_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.CollectStr
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr))]
        public void CollectStr_TArray_Func_3_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.CollectStr
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.CollectStr))]
        public void CollectStr_U_Func_3_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine))]
        public void Combine_IEnumerable_1_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine))]
        public void Combine_IEnumerable_1_Char_String()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Combine))]
        public void Combine_IEnumerable_1_String_String()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Combine
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_IEnumerable_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_TArray_Func_2_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_List_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_IEnumerable_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll))]
        public void ConvertAll_IEnumerable_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll))]
        public void ConvertAll_IEnumerable_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll))]
        public void ConvertAll_TArray_Func_2_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.ConvertAll))]
        public void ConvertAll_List_1_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.ConvertAll
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_IEnumerable_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_TArray_Func_3_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_List_1_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Convert))]
        public void Convert_IEnumerable_1_Func_3_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Convert
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Count))]
        public void Count_T_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Count))]
        public void Count_IEnumerable_1_T_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Count))]
        public void Count_IEnumerable_1_Func_2_UInt32()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Count
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Cycle))]
        public void Cycle_IEnumerable_Func_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Cycle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Cycle))]
        public void Cycle_IEnumerable_1_Func_2()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Cycle
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each))]
        public void Each_IEnumerable_Action_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each))]
        public void Each_IEnumerable_1_Action_1()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each))]
        public void Each_IEnumerable_Action_2()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each))]
        public void Each_IEnumerable_1_Action_2()
            {
            // Attribute Tests Implemented
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Each))]
        public void Each_Action_1_IEnumerable_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Each
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Equivalent))]
        public void Equivalent()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Equivalent
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Fill))]
        public void Fill_TArray_T_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Fill))]
        public void Fill_List_1_T_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Fill))]
        public void Fill_TArray_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Fill
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Filter))]
        public void Filter_IEnumerable_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Filter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Filter))]
        public void Filter_TArray_Boolean_U()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Filter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.Filter))]
        public void Filter_List_1_Boolean_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.Filter
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_TArray_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_1_Func_2_T()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_Int32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        [Fact]
        [Trait(Traits.TargetMember, nameof(LCore) + "." + nameof(global::LCore.Extensions) + "." + nameof(EnumerableExt) + "." + nameof(EnumerableExt.First))]
        public void First_IEnumerable_UInt32_Func_2_List_1()
            {
            // TODO: Implement method test LCore.Extensions.EnumerableExt.First
            }

        }
    }