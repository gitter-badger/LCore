using Singularity.Controllers;
using System;

namespace Singularity.Annotations
    {
    public class FieldClassAttribute : ViewTypedAttribute
        {
        public string[] FieldClasses { get; set; }

        public FieldClassAttribute(ControllerHelper.ViewType[] ViewTypes, params string[] FieldClasses) :
            base(ViewTypes)
            {
            this.FieldClasses = FieldClasses ?? new string[] { };
            }

        public FieldClassAttribute(params string[] FieldClasses) :
            base(ControllerHelper.ViewType.All)
            {
            this.FieldClasses = FieldClasses ?? new string[] { };
            }
        }
    }