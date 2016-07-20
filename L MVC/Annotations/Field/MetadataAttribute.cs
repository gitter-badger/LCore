using System;

namespace LMVC.Annotations
    {
    public class MetadataAttribute : AdditionalValueAttribute
        {
        public const string AdditionalData_RelationForeignKey = "RelationForeignKey";

        public MetadataAttribute(string ValueKey, object ValueData)
            {
            this.ValueKey = ValueKey;
            this.ValueData = ValueData;
            }

        public override string ValueKey { get; }

        public override object ValueData { get; }
        }
    }
