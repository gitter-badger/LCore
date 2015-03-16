using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace MVCL
    {
    public class HideManageViewColumnAttribute : AdditionalValueAttribute
        {
        public const String Key = "HiddenColumn";

        public override String ValueKey
            {
            get
                {
                return HideManageViewColumnAttribute.Key;
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