using LMVC.Controllers;
using System;

namespace LMVC.Annotations
    {
    public class FieldUpdateRefreshPageAttribute : FieldClassAttribute
        {
        public const string FieldUpdateRefreshPageClass = "field-update-refresh-page";

        public FieldUpdateRefreshPageAttribute(params ControllerHelper.ViewType[] ViewTypes)
            : base(ViewTypes, FieldUpdateRefreshPageClass)
            {

            }
        public FieldUpdateRefreshPageAttribute()
            : base(new[] { ControllerHelper.ViewType.All }, FieldUpdateRefreshPageClass)
            {

            }
        }
    }