using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Singularity
    {
    public class ExportDisabledAttribute : AdditionalValueAttribute
        {
        public const String Key = "ExportDisabled";

        public override String ValueKey
            {
            get
                {
                return ExportDisabledAttribute.Key;
                }
            }

        public override object ValueData
            {
            get
                {
                return true;
                }
            }
        }
    }