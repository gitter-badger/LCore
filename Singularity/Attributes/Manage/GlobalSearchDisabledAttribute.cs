﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class GlobalSearchDisabledAttribute : AdditionalValueAttribute
        {
        public const String Key = "GlobalSearchDisabled";

        public override String ValueKey
            {
            get
                {
                return GlobalSearchDisabledAttribute.Key;
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
