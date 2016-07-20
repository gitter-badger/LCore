using LMVC.Controllers;
using LMVC.Models;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public interface ICustomPartial : ISubClassPersistentAttribute
        {
        void RenderPartial(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        bool IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        }

    public class CustomPartialAttribute : ViewTypedAttribute, ICustomPartial
        {
        public virtual bool IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            return this.AffectsViewTypes(Type);
            }

        public void RenderPartial(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            if (this.IsActive(Html, Model, Type))
                Html.RenderPartial(this.PartialView, Model);
            }

        public string PartialView { get; }

        public CustomPartialAttribute(string PartialView, params ControllerHelper.ViewType[] Type)
            : base(Type)
            {
            this.PartialView = PartialView;
            }
        }
    }