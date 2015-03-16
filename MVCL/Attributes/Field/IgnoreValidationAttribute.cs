using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MVCL
    {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IgnoreValidationAttribute : FilterAttribute, IAuthorizationFilter
        {
        // TODO: Try to put it on another more appropriate method such as OnActionExcecuting.
        // Looks like - This is the earliest method we can interpret before an action. I really dont like this!
        public void OnAuthorization(AuthorizationContext filterContext)
            {
            //TODO: filterContext != null && filterContext.httpContext != null
            var itemKey = this.CreateKey(filterContext.ActionDescriptor);
            if (!filterContext.HttpContext.Items.Contains(itemKey))
                {
                filterContext.HttpContext.Items.Add(itemKey, true);
                }
            }

        private string CreateKey(ActionDescriptor actionDescriptor)
            {
            var action = actionDescriptor.ActionName.ToLower();
            var controller = actionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            return string.Format("IgnoreValidation_{0}_{1}", controller, action);
            }
        }
    }