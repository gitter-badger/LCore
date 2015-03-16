using MVCL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVCL
    {
    public interface ICustomPartial
        {
        void RenderPartial(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        Boolean IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type);
        }

    public class CustomPartialAttribute : ViewTypedAttribute, ICustomPartial
        {
        public virtual Boolean IsActive(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            return base.AffectsViewTypes(Type);
            }

        public void RenderPartial(HtmlHelper Html, IViewField Model, params ControllerHelper.ViewType[] Type)
            {
            if (IsActive(Html, Model, Type))
                Html.RenderPartial(PartialView, Model);
            }

        public String PartialView { get; private set; }

        public CustomPartialAttribute(String PartialView, params ControllerHelper.ViewType[] Type)
            : base(Type)
            {
            this.PartialView = PartialView;
            }
        }
    }