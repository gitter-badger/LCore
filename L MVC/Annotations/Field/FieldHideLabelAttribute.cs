using System;

namespace Singularity.Annotations
    {
    public class FieldHideLabelAttribute : MetadataAttribute
        {
        public const string HideLabel = "HideLabel";

        public FieldHideLabelAttribute()
            : base(HideLabel, true)
            {
            }
        }
    }