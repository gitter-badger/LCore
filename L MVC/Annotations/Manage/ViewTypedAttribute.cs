using LMVC.Controllers;
using System;
using JetBrains.Annotations;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public interface IViewTyped
        {
        bool AffectsViewTypes(ControllerHelper.ViewType[] Type);
        }

    public abstract class ViewTypedAttribute : Attribute, IViewTyped
        {
        protected ViewTypedAttribute([CanBeNull]params ControllerHelper.ViewType[] ViewTypes)
            {
            this.ViewTypes = ViewTypes ?? new ControllerHelper.ViewType[] { };
            }

        public ControllerHelper.ViewType[] ViewTypes { get; }

        public bool AffectsViewTypes(ControllerHelper.ViewType[] Types)
            {
            return this.ViewTypes == null || 
                this.ViewTypes.Length == 0 || 
                this.ViewTypes.Has(ControllerHelper.ViewType.All) || 
                this.ViewTypes.HasAny(Types);
            }
        }
    }