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
    public class FieldFocusAttribute : FieldHtmlAttribute
        {
        public const String FocusAttr = "focus-first";
        public const String FocusValue = "input, textarea";

        public FieldFocusAttribute() :
            base(FocusAttr, FocusValue, ControllerHelper.ViewType.All)
            {
            }

        public FieldFocusAttribute(params ControllerHelper.ViewType[] ViewTypes) :
            base(FocusAttr, FocusValue, ViewTypes)
            {
            }
        }
    }