using System;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public class FieldType_SortableListAttribute : MetadataAttribute, ISubClassPersistentAttribute
        {
        public const string SortableList = "SortableList";

        public FieldType_SortableListAttribute()
            : base(SortableList, true)
            {
            }
        }
    }