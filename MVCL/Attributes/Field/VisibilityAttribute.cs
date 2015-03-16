using MVCL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVCL
    {
    public interface IVisibility
        {
        Boolean? GetVisibility(HttpContextBase Context, params ControllerHelper.ViewType[] Types);
        }

    public class VisibilityAttribute : ViewTypedAttribute, IVisibility
        {
        public Boolean Visible { get; private set; }

        public virtual Boolean? GetVisibility(HttpContextBase Context, params ControllerHelper.ViewType[] Types)
            {
            if (AffectsViewTypes(Types))
                return Visible;

            return null;
            }

        public VisibilityAttribute(Boolean Visible, params ControllerHelper.ViewType[] ViewTypes)
            : base(ViewTypes)
            {
            this.Visible = Visible;
            }
        }
    }