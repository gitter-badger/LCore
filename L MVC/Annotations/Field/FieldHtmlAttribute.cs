using LMVC.Controllers;
using System;

namespace LMVC.Annotations
    {
    public class FieldHtmlAttribute : ViewTypedAttribute
        {
        public string FieldAttr { get; set; }
        public string FieldAttrValue { get; set; }

        public FieldHtmlAttribute(string FieldAttr, string FieldAttrValue) :
            this(FieldAttr, FieldAttrValue, ControllerHelper.ViewType.All)
            {
            }

        public FieldHtmlAttribute(string FieldAttr, string FieldAttrValue, params ControllerHelper.ViewType[] ViewTypes) :
            base(ViewTypes)
            {
            this.FieldAttr = FieldAttr;
            this.FieldAttrValue = FieldAttrValue;
            }
        }
    }