using Singularity.Controllers;
using System;
using System.Web;

namespace Singularity.Annotations
    {
    public interface IVisibility
        {
        bool? GetVisibility(HttpContextBase Context, params ControllerHelper.ViewType[] Types);
        }

    public class FieldVisibilityAttribute : ViewTypedAttribute, IVisibility
        {
        public bool Visible { get; }

        public virtual bool? GetVisibility(HttpContextBase Context, params ControllerHelper.ViewType[] Types)
            {
            if (this.AffectsViewTypes(Types))
                return this.Visible;

            return null;
            }

        public FieldVisibilityAttribute(bool Visible, params ControllerHelper.ViewType[] ViewTypes)
            : base(ViewTypes)
            {
            this.Visible = Visible;
            }
        }
    }