using LMVC.Controllers;
using LMVC.Models;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public interface IFieldPartial : ISubClassPersistentAttribute
        {
        void RenderPartial_Before(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        void RenderPartial_After(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);

        // ReSharper disable UnusedParameter.Global
        bool IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        // ReSharper restore UnusedParameter.Global
        }

    public class FieldPartialBeforeAttribute : FieldPartialAttribute
        {
        public FieldPartialBeforeAttribute(string PartialViewBefore, params ControllerHelper.ViewType[] Type)
            : base(PartialViewBefore, PartialViewAfter: null, Type: Type)
            {
            }
        }

    public class FieldPartialAfterAttribute : FieldPartialAttribute
        {
        public FieldPartialAfterAttribute(string PartialViewAfter, params ControllerHelper.ViewType[] Type)
            : base(PartialViewBefore: null, PartialViewAfter: PartialViewAfter, Type: Type)
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

        public FieldPartialAttribute(string PartialViewBefore, string PartialViewAfter, params ControllerHelper.ViewType[] Type)
            : base(Type)
            {
            this.PartialView_Before = PartialViewBefore;
            this.PartialView_After = PartialViewAfter;
            }
        }
    }