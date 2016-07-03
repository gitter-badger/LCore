using System;
using System.Collections.Generic;
using System.Web;
using Singularity.Controllers;
using Singularity.Models;
using Microsoft.WindowsAzure.StorageClient;
using LCore.Extensions;

namespace Singularity.Context
    {
    public class SingularityContextProvider : ContextProvider
        {
        public override string GetFileUploadRootPath(HttpSessionStateBase Session, HttpPostedFileBase File, string RelationType, string RelationProperty, int RelationID)
            {
            return this.GetSettings(Session).StorageFolder;
            }

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

        public override IMenuController[] AllMenuControllers(HttpSessionStateBase Session)
            {
            var Out = new List<IMenuController>();

            Out.AddRange(this.AllManageControllers(Session));

            // TODO: Extend: Add Custom controllers here so they are seen and included in the menu
            // Out.Add(new MyController(Session));

            return Out.Array();
            }


        public override ManageController[] AllManageControllers(HttpSessionStateBase Session)
            {
            if (Session?[ContextSession] == null || (string)Session[ContextSession] == SingularityContext.Name)
                {
                return new ManageController[]{
                    new EmailJobController(),
                    new EmailHistoryController(),
                    new CustomExportController(),
                    new SavedSearchController(),
                    new TextContentController(),
                    new TemplateController(),
                    new ErrorsController()
                };
                }

            return new ManageController[] { };
            }

        public override UserAccount CurrentUser(HttpSessionStateBase Session)
            {
            return (UserAccount)Session[ControllerHelper.Session_User];
            }

        public override AccountRole CurrentRole(HttpSessionStateBase Session)
            {
            return (AccountRole)(Session[ControllerHelper.Session_Role] ?? this.GetAnonymousRole());
            }

        public override AccountRole GetAnonymousRole()
            {
            return new AccountRole();
            }

        public override Type[] GetContextTypes(HttpSessionStateBase Session)
            {
            return ((SingularityContext)this.GetContext(Session)).ContextTypes;
            }

        public override ModelContext GetContext(HttpSessionStateBase Session)
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
