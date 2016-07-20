using System.Web;
using LCore.Interfaces;
using LMVC.Context;
using LMVC.Models;
using WebMatrix.WebData;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class SessionExt
        {
        public static bool IsLoggedIn(this HttpSessionStateBase Session)
            {
            var Provider = ContextProviderFactory.GetCurrent();
            return WebSecurity.HasUserId &&
                Provider.CurrentUser(Session) != null &&
                Provider.CurrentRole(Session) != null;
            }

        public static UserAccount CurrentUser(this HttpSessionStateBase Session)
            {
            var Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId ? Provider.CurrentUser(Session) : null;
            }
        public static AccountRole CurrentRole(this HttpSessionStateBase Session)
            {
            var Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId ? Provider.CurrentRole(Session) : null;
            }

        public static bool IsAdmin(this HttpSessionStateBase Session)
            {
            var Provider = ContextProviderFactory.GetCurrent();

            return WebSecurity.HasUserId &&
                Provider.CurrentUser(Session)?.IsAdmin != null;
            }

        public static ModelContext GetContext(this HttpSessionStateBase Session)
            {
            return ContextProviderFactory.GetCurrent().GetContext(Session);
            }
        }
    }