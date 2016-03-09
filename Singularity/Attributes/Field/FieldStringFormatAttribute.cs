using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class FieldStringFormatAttribute : AdditionalValueAttribute
        {
        public const String Key = "StringFormat";

        public FieldStringFormatAttribute(String Format)
            {
            this.Format = Format;
            }

        private String Format { get; set; }

        public override String ValueKey
            {
            get
                {
                return FieldStringFormatAttribute.Key;
                }
            }

        public override object ValueData
            {
            get
                {
                return Format;
                }
            }
        }
    }