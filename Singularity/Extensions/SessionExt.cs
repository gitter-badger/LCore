using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using LCore;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Singularity.Models;
using Singularity.Routes;
using Singularity.Controllers;
using Singularity.Context;
using System.IO;
using WebMatrix.WebData;

namespace Singularity.Extensions
    {
    public static class SessionExt
        {
        public static Boolean IsLoggedIn(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();
            return WebSecurity.HasUserId &&
                Provider.CurrentUser(Session) != null &&
                Provider.CurrentRole(Session) != null;
            }

        public static IModelUser CurrentUser(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();

            if (WebSecurity.HasUserId)
                {
                return Provider.CurrentUser(Session);
                }

            return null;
            }
        public static IModelRole CurrentRole(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();

            if (WebSecurity.HasUserId)
                {
                return Provider.CurrentRole(Session);
                }

            return null;
            }

        public static Boolean IsAdmin(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId &&
                Provider.CurrentUser(Session) != null &&
                Provider.CurrentUser(Session).IsAdmin != null;
            }

        public static ModelContext GetContext(this HttpSessionStateBase Session)
            {
            return ContextProviderFactory.GetCurrent().GetContext(Session);
            }
        }
    }