using LMVC.Controllers;
using System;
using JetBrains.Annotations;

namespace LMVC.Annotations
    {
    public class FieldClassAttribute : ViewTypedAttribute
        {
        public string[] FieldClasses { get; set; }

        public FieldClassAttribute(ControllerHelper.ViewType[] ViewTypes, [CanBeNull]params string[] FieldClasses) :
            base(ViewTypes)
            {
            this.FieldClasses = FieldClasses ?? new string[] { };
            }

        public FieldClassAttribute([CanBeNull]params string[] FieldClasses) :
            base(ControllerHelper.ViewType.All)
            {
            this.FieldClasses = FieldClasses ?? new string[] { };
            }
        }
    }