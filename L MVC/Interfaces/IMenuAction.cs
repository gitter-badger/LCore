using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore;
using LMVC.Controllers;
using LMVC.Extensions;

// ReSharper disable RedundantArgumentDefaultValue

namespace LMVC.Models
    {
    public interface IMenuAction : IMenuItem
        {
        string ParentAction { get; set; }
        string ParentController { get; set; }
        string MethodName { get; set; }
        }

    [AttributeUsage(AttributeTargets.Method)]
    public class MenuAction : Attribute, IMenuAction
        {
        public MvcHtmlString Icon { get; set; }

        public string PageGroup { get; set; }

        public string MenuText { get; set; }

        public string MenuTitle { get; set; }

        public string Action { get; set; }
        public string ControllerName { get; set; }

        public int? TotalCount { get; set; }

        public string ParentAction { get; set; }
        public string ParentController { get; set; }

        public string MethodName { get; set; }

        public MenuAction()
            : this(ParentAction: null, Icon: FontAwesomeIcon.question) {}

        public MenuAction(string ParentAction = null, FontAwesomeIcon Icon = FontAwesomeIcon.question, string ActionFriendlyTitle = null)
            {
            this.ParentAction = ParentAction;
            this.Icon = FontAwesomeExt.FontAwesome(Html: null, Icon: Icon);
            }

        public MenuAction(string ParentAction = null, GlyphIcon Icon = GlyphIcon.question_sign, string ActionFriendlyTitle = null)
            {
            this.ParentAction = ParentAction;
            this.Icon = GlyphIconExt.Glyph(Html: null, Icon: Icon);
            }
        }
    }