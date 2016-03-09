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
    public class FieldClassAttribute : ViewTypedAttribute
        {
        public String[] FieldClasses { get; set; }

        public FieldClassAttribute(ControllerHelper.ViewType[] ViewTypes, params String[] FieldClasses) :
            base(ViewTypes)
            {
            this.FieldClasses = FieldClasses ?? new String[] { };
            }

        public FieldClassAttribute(params String[] FieldClasses) :
            base(ControllerHelper.ViewType.All)
            {
            this.FieldClasses = FieldClasses ?? new String[] { };
            }
        }
    }