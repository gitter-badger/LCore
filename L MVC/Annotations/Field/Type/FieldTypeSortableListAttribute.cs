using System;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public class FieldTypeSortableListAttribute : MetadataAttribute, ISubClassPersistentAttribute
        {
        public const string SortableList = "SortableList";

        public FieldTypeSortableListAttribute()
            : base(SortableList, ValueData: true)
            {
            }
        }
    }