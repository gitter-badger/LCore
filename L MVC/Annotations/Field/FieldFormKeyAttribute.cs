using System;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public class FieldFormKeyAttribute : AdditionalValueAttribute, ISubClassPersistentAttribute
        {
        public const string FieldFormKey = "FieldFormKey";

        public string CustomKey { get; set; }

        public FieldFormKeyAttribute(string CustomKey)
            {
            this.CustomKey = CustomKey;
            }

        public override object ValueData => this.CustomKey;

        public override string ValueKey => FieldFormKey;
        }
    }