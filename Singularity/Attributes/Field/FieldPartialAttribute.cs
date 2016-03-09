using Singularity.Controllers;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity.Annotations
    {
    public interface IFieldPartial
        {
        void RenderPartial_Before(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        void RenderPartial_After(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);

        Boolean IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        }

    public class FieldPartialBeforeAttribute : FieldPartialAttribute, IFieldPartial
        {
        public FieldPartialBeforeAttribute(String PartialView_Before, params ControllerHelper.ViewType[] Type)
            : base(PartialView_Before, null, Type)
            {
            }
        }

    public class FieldPartialAfterAttribute : FieldPartialAttribute, IFieldPartial
        {
        public FieldPartialAfterAttribute(String PartialView_After, params ControllerHelper.ViewType[] Type)
            : base(null, PartialView_After, Type)
            {
            }
        }

    public class FieldPartialAttribute : ViewTypedAttribute, IFieldPartial
        {
        public virtual Boolean IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            return base.AffectsViewTypes(Type);
            }

        public void RenderPartial_Before(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            if (!String.IsNullOrEmpty(PartialView_Before) &&
                IsActive(Html, Model, Type))
                Html.RenderPartial(PartialView_Before, Model);
            }

        public void RenderPartial_After(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            if (!String.IsNullOrEmpty(PartialView_After) &&
                IsActive(Html, Model, Type))
                Html.RenderPartial(PartialView_After, Model);
            }

        public String PartialView_Before { get; private set; }
        public String PartialView_After { get; private set; }

        public FieldPartialAttribute(String PartialView_Before, String PartialView_After, params ControllerHelper.ViewType[] Type)
            : base(Type)
            {
            this.PartialView_Before = PartialView_Before;
            this.PartialView_After = PartialView_After;
            }
        }
    }