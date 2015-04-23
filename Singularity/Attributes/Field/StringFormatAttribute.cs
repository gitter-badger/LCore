using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Singularity
    {
    public class StringFormatAttribute : AdditionalValueAttribute
        {
        public const String Key = "StringFormat";

        public StringFormatAttribute(String Format)
            {
            this.Format = Format;
            }

        private String Format { get; set; }

        public override String ValueKey
            {
            get
                {
                return StringFormatAttribute.Key;
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