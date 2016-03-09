using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class FieldTabAttribute : AdditionalValueAttribute
        {
        public const String Key = "FieldTab";

        public String TabText { get; set; }

        public FieldTabAttribute(String TabText)
            {
            this.TabText = TabText;
            }

        public override String ValueKey
            {
            get
                {
                return FieldTabAttribute.Key;
                }
            }

        public override object ValueData
            {
            get
                {
                return TabText;
                }
            }
        }
    }