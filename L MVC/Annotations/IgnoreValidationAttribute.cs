using System;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace LMVC.Annotations
    {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IgnoreValidationAttribute : FilterAttribute, IAuthorizationFilter
        {
        public void OnAuthorization([CanBeNull] AuthorizationContext FilterContext)
            {
            if (FilterContext?.HttpContext != null)
                {
                string ItemKey = this.CreateKey(FilterContext.ActionDescriptor);
                if (!FilterContext.HttpContext.Items.Contains(ItemKey))
                    {
                    FilterContext.HttpContext.Items.Add(ItemKey, true);
                    }
                }
            }

        private string CreateKey(ActionDescriptor ActionDescriptor)
            {
            string Action = ActionDescriptor.ActionName.ToLower();
            string Controller = ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            return $"IgnoreValidation_{Controller}_{Action}";
            }
        }
    }