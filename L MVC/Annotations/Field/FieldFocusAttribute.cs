﻿using LMVC.Controllers;
using System;

namespace LMVC.Annotations
    {
    public class FieldFocusAttribute : FieldHtmlAttribute
        {
        public const string FocusAttr = "focus-first";
        public const string FocusValue = "input, textarea";

        public FieldFocusAttribute() :
            base(FocusAttr, FocusValue, ControllerHelper.ViewType.All)
            {
            }

        public FieldFocusAttribute(params ControllerHelper.ViewType[] ViewTypes) :
            base(FocusAttr, FocusValue, ViewTypes)
            {
            }
        }
    }