using System.Web;
using Singularity.Models;
using Singularity.Context;
using WebMatrix.WebData;

namespace Singularity.Extensions
    {
    public static class SessionExt
        {
        public static bool IsLoggedIn(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();
            return WebSecurity.HasUserId &&
                Provider.CurrentUser(Session) != null &&
                Provider.CurrentRole(Session) != null;
            }

        public static IModelUser CurrentUser(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId ? Provider.CurrentUser(Session) : null;
            }
        public static IModelRole CurrentRole(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId ? Provider.CurrentRole(Session) : null;
            }

        public static bool IsAdmin(this HttpSessionStateBase Session)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId &&
                Provider.CurrentUser(Session)?.IsAdmin != null;
            }

        public static ModelContext GetContext(this HttpSessionStateBase Session)
            {
            return ContextProviderFactory.GetCurrent().GetContext(Session);
            }
        }
    }