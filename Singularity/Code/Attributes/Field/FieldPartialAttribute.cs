using Singularity.Controllers;
using Singularity.Models;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public interface IFieldPartial : ISubClassPersistentAttribute
        {
        void RenderPartial_Before(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        void RenderPartial_After(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);

        bool IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        }

    public class FieldPartialBeforeAttribute : FieldPartialAttribute
        {
        public FieldPartialBeforeAttribute(string PartialView_Before, params ControllerHelper.ViewType[] Type)
            : base(PartialView_Before, null, Type)
            {
            }
        }

    public class FieldPartialAfterAttribute : FieldPartialAttribute
        {
        public FieldPartialAfterAttribute(string PartialView_After, params ControllerHelper.ViewType[] Type)
            : base(null, PartialView_After, Type)
            {
            }
        }

    public class FieldPartialAttribute : ViewTypedAttribute, IFieldPartial
        {
        public virtual bool IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            return this.AffectsViewTypes(Type);
            }

        public void RenderPartial_Before(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            if (!string.IsNullOrEmpty(this.PartialView_Before) && this.IsActive(Html, Model, Type))
                Html.RenderPartial(this.PartialView_Before, Model);
            }

        public void RenderPartial_After(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            if (!string.IsNullOrEmpty(this.PartialView_After) && this.IsActive(Html, Model, Type))
                Html.RenderPartial(this.PartialView_After, Model);
            }

        public string PartialView_Before { get; }
        public string PartialView_After { get; }

        public FieldPartialAttribute(string PartialView_Before, string PartialView_After, params ControllerHelper.ViewType[] Type)
            : base(Type)
            {
            this.PartialView_Before = PartialView_Before;
            this.PartialView_After = PartialView_After;
            }
        }
    }