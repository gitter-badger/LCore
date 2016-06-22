using System;

namespace Singularity.Annotations
    {
    public class FieldType_SortableListAttribute : MetadataAttribute
        {
        public const string SortableList = "SortableList";

        public FieldType_SortableListAttribute()
            : base(SortableList, true)
            {
            }
        }
    }