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
    public class FieldUpdateRefreshPageAttribute : FieldClassAttribute
        {
        public const String FieldUpdateRefreshPageClass = "field-update-refresh-page";

        public FieldUpdateRefreshPageAttribute(params ControllerHelper.ViewType[] ViewTypes)
            : base(ViewTypes, new String[] { FieldUpdateRefreshPageClass })
            {

            }
        public FieldUpdateRefreshPageAttribute()
            : base(new ControllerHelper.ViewType[] { ControllerHelper.ViewType.All }, new String[] { FieldUpdateRefreshPageClass })
            {

            }
        }
    }