using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity.Annotations
    {
    public class FieldFormKeyAttribute : AdditionalValueAttribute
        {
        public const String FieldFormKey = "FieldFormKey";

        public String CustomKey { get; set; }

        public FieldFormKeyAttribute(String CustomKey)
            {
            this.CustomKey = CustomKey;
            }

        public override object ValueData
            {
            get { return CustomKey;}
            }
        public override string ValueKey
            {
            get { return FieldFormKey; }
            }
        }
    }