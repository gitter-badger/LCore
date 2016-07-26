using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SereneTest.Northwind
    {
    public partial class FreightFormatterAttribute : CustomFormatterAttribute
        {
        public const string Key = "SereneTest.Northwind.FreightFormatter";

        public FreightFormatterAttribute()
            : base(Key)
            {
            }
        }
    }

