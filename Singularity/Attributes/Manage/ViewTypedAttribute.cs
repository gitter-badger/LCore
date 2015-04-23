using Singularity.Controllers;
using System;
using LCore;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity
    {
    public interface IViewTyped
        {
        Boolean AffectsViewTypes(ControllerHelper.ViewType[] Type);
        }

    public abstract class ViewTypedAttribute : Attribute, IViewTyped
        {
        public ViewTypedAttribute(params ControllerHelper.ViewType[] ViewTypes)
            {
            this.ViewTypes = ViewTypes ?? new ControllerHelper.ViewType[] { };
            }

        public ControllerHelper.ViewType[] ViewTypes { get; private set; }

        public Boolean AffectsViewTypes(ControllerHelper.ViewType[] Types)
            {
            return ViewTypes.Has(ControllerHelper.ViewType.All) ||
                ViewTypes.HasAny(Types);
            }
        }
    }