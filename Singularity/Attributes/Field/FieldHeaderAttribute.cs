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
    public class FieldHeaderAttribute : FieldPartialBeforeAttribute
        {
        public int HeaderType { get; set; }

        public String HeaderTitle { get; set; }

        public Boolean HorizontalRule { get; set; }

        public FieldHeaderAttribute(String HeaderTitle, int HeaderType = 3, Boolean HorizontalRule = false) :
            base(Singularity.Routes.PartialViews.FieldHeader, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit, ControllerHelper.ViewType.Display)
            {
            this.HeaderType = HeaderType;
            this.HeaderTitle = HeaderTitle;
            this.HorizontalRule = HorizontalRule;
            }
        }
    }