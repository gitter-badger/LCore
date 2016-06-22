using System;
using System.Web.Mvc;

namespace Singularity.Annotations
    {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IgnoreValidationAttribute : FilterAttribute, IAuthorizationFilter
        {
        public void OnAuthorization(AuthorizationContext filterContext)
            {
            if (filterContext?.HttpContext != null)
                {
                string itemKey = this.CreateKey(filterContext.ActionDescriptor);
                if (!filterContext.HttpContext.Items.Contains(itemKey))
                    {
                    filterContext.HttpContext.Items.Add(itemKey, true);
                    }
                }
            }

        private string CreateKey(ActionDescriptor actionDescriptor)
            {
            string action = actionDescriptor.ActionName.ToLower();
            string controller = actionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            return $"IgnoreValidation_{controller}_{action}";
            }
        }
    }