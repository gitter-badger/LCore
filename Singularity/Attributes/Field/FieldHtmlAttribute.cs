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
    public class FieldHtmlAttribute : ViewTypedAttribute
        {
        public String FieldAttr { get; set; }
        public String FieldAttrValue { get; set; }

        public FieldHtmlAttribute(String FieldAttr, String FieldAttrValue) :
            this(FieldAttr, FieldAttrValue, ControllerHelper.ViewType.All)
            {
            }

        public FieldHtmlAttribute(String FieldAttr, String FieldAttrValue, params ControllerHelper.ViewType[] ViewTypes) :
            base(ViewTypes)
            {
            this.FieldAttr = FieldAttr;
            this.FieldAttrValue = FieldAttrValue;
            }
        }
    }