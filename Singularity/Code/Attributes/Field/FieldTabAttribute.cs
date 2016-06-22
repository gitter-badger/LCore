using System;

namespace Singularity.Annotations
    {
    public class FieldTabAttribute : AdditionalValueAttribute
        {
        public const string Key = "FieldTab";

        public string TabText { get; set; }

        public FieldTabAttribute(string TabText)
            {
            this.TabText = TabText;
            }

        public override string ValueKey => Key;

        public override object ValueData => this.TabText;
        }
    }