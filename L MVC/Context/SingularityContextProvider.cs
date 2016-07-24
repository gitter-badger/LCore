using System;
using System.Collections.Generic;
using System.Web;
using JetBrains.Annotations;
using LMVC.Controllers;
using LMVC.Models;
using Microsoft.WindowsAzure.StorageClient;
using LCore.Extensions;
using LMVC.Account;

namespace LMVC.Context
    {
    public class SingularityContextProvider : ContextProvider
        {
        [CanBeNull]
        public override string GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID)
            {
            return this.GetSettings(Session).StorageFolder;
            }

        [CanBeNull]
        public override string GetFileUploadFilePath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID)
            {
            return L.File.CombinePaths(
                "FileUploads",
                RelationType,
                RelationProperty,
                RelationID.ToString(),
                $"{DateTime.Now} - {File.FileName}".CleanFileName());
            }

        public override CloudBlobDirectory GetFileUploadCloudContainer()
            {
            return null;
            }

        public override string SiteTitle => Singularity.AppName;

        [CanBeNull]
        public override IMenuController[] AllMenuControllers(HttpSessionStateBase Session)
            {
            var Out = new List<IMenuController>();

            Out.AddRange(this.AllManageControllers(Session));

            // TODO: Extend: Add Custom controllers here so they are seen and included in the menu
            // Out.Add(new MyController(Session));

            return Out.Array();
            }


        public override ManageController[] AllManageControllers([CanBeNull]HttpSessionStateBase Session)
            {
            if (Session?[ContextSession] == null || (string)Session[ContextSession] == SingularityContext.Name)
                {
                return new ManageController[]{
                    new EmailJobController(new AuthenticationService(Session)),
                    new EmailHistoryController(new AuthenticationService(Session)),
                    new CustomExportController(new AuthenticationService(Session)),
                    new SavedSearchController(new AuthenticationService(Session)),
                    new TextContentController(new AuthenticationService(Session)),
                    new TemplateController(new AuthenticationService(Session)),
                    new ErrorsController(new AuthenticationService(Session))
                };
                }

            return new ManageController[] { };
            }

        [CanBeNull]
        public override UserAccount CurrentUser(HttpSessionStateBase Session)
            {
            return (UserAccount)Session[SingularityControllerHelper.Session_User];
            }

        [CanBeNull]
        public override AccountRole CurrentRole(HttpSessionStateBase Session)
            {
            return (AccountRole)(Session[SingularityControllerHelper.Session_Role] ?? this.GetAnonymousRole());
            }

        public override AccountRole GetAnonymousRole()
            {
            return new AccountRole();
            }

        [CanBeNull]
        public override Type[] GetContextTypes(HttpSessionStateBase Session)
            {
            return ((SingularityContext)this.GetContext(Session)).ContextTypes;
            }

        public override ModelContext GetContext([CanBeNull]HttpSessionStateBase Session)
            {
            if (Session?[ContextSession] == null || (string)Session[ContextSession] == SingularityContext.Name)
                {
                return new SingularityContext();
                }
            /* More contexts go here
            else if (
             */

            return null;
            }

        public GlobalSettings GetSettings(HttpSessionStateBase Session)
            {
            return ((SingularityContext)this.GetContext(Session)).GlobalSettings;
            }

        }
    }
