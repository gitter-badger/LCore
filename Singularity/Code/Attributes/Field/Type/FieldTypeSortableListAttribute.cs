using System;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public class FieldTypeSortableListAttribute : MetadataAttribute, ISubClassPersistentAttribute
        {
        public const string SortableList = "SortableList";

        public FieldTypeSortableListAttribute()
            : base(SortableList, true)
            {
            }
        }
    }