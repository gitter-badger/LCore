using System;

namespace LMVC.Annotations
    {
    public class FieldStringFormatAttribute : AdditionalValueAttribute
        {
        public const string Key = "StringFormat";

        public FieldStringFormatAttribute(string Format)
            {
            this.Format = Format;
            }

        private string Format { get; }

        public override string ValueKey => Key;

        public override object ValueData => this.Format;
        }
    }