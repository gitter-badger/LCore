using Singularity.Controllers;
using System;

namespace Singularity.Annotations
    {
    public class FieldHeaderAttribute : FieldPartialBeforeAttribute
        {
        public int HeaderType { get; set; }

        public string HeaderTitle { get; set; }

        public bool HorizontalRule { get; set; }

        public FieldHeaderAttribute(string HeaderTitle, int HeaderType = 3, bool HorizontalRule = false) :
            base(Routes.PartialViews.FieldHeader, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit, ControllerHelper.ViewType.Display)
            {
            this.HeaderType = HeaderType;
            this.HeaderTitle = HeaderTitle;
            this.HorizontalRule = HorizontalRule;
            }
        }
    }