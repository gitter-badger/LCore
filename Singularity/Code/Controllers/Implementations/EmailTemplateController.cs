using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using LCore.Extensions;
using Singularity.Account;
using Singularity.Context;
using Singularity.Annotations;
using Singularity.Extensions;

namespace Singularity.Controllers
    {
    [Authorize]
    public class EmailTemplateController : ManageController<EmailTemplate>
        {
        public ActionResult EmailSavedSearch(int? SavedSearchID, int? TemplateID)
            {
            List<EmailTemplate> Templates = this.HttpContext.GetModelData<EmailTemplate>()
                .Where(Template => Template.Active &&
                    (TemplateID == null ||
                    Template.EmailTemplateID == TemplateID))
                .OrderBy(Template => Template.Subject)
                .List();

            List<SavedSearch> Searches = this.HttpContext.GetModelData<SavedSearch>()
                .Where(Search => Search.Active &&
                    (SavedSearchID == null ||
                    Search.SavedSearchID == SavedSearchID))
                .OrderBy(Search => Search.Name)
                .List();

            Searches = Searches.Select(Search =>
            {
                var Type = L.Ref.FindType(Search.SearchType);
                return Type.HasInterface<IEmailable>();
            });

            var Model = new EmailTemplateSavedSearchViewModel
                {
                Searches = Searches,
                Templates = Templates
                };

            if (SavedSearchID != null)
                {
                Model.SavedSearch = this.HttpContext.GetModelData<SavedSearch>().Find(SavedSearchID);
                }

            if (TemplateID != null)
                {
                Model.Template = this.HttpContext.GetModelData<EmailTemplate>().Find(TemplateID);
                }

            return this.View(Model);
            }

        [HttpPost]
        public virtual ActionResult EmailSavedSearchTemplate(int EmailJobID, string ReturnUrl, FormCollection Form)
            {
            var DbContext = this.HttpContext.GetModelContext();

            var Job = EmailJob.Find(DbContext, EmailJobID);


            string AllUserIDs = Form["EmailUsers[]"];

            int[] UserIDs = AllUserIDs.Split(',').Convert(UserID => Convert.ToInt32(UserID.Trim())).Array();

            DbSet<EmailHistory> EmailHistorySet = DbContext.GetDBSet<EmailHistory>();

            var EmailModelType = ContextProviderFactory.GetCurrent().GetManageController(this.Session, Job.SavedSearch.ControllerName).ModelType;

            var EmailSet = DbContext.GetDBSet(EmailModelType);

            int AddedCount = 0;

            foreach (int UserID in UserIDs)
                {
                var SendEmail = new EmailHistory();
                SendEmail.Initialize();

                SendEmail.ReplyToAddress = this.Session.CurrentUser().GetEmails().FirstOrDefault();

                SendEmail.Subject = Job.EmailTemplate.Subject;

                // TODO: MVC: fill tokens.
                SendEmail.Body = Job.EmailTemplate.Body;

                SendEmail.UserID = UserID;

                SendEmail.EmailJob = Job;

                SendEmail.EmailTemplate = Job.EmailTemplate;

                var EmailUser = (IEmailable)EmailSet.Find(UserID);

                SendEmail.ToAddresses = EmailUser.GetEmails(Job.EmailToField).JoinLines(",");

                var Existing = EmailHistory.FindEmail(DbContext, SendEmail);

                if (Existing == null)
                    {
                    AddedCount++;

                    EmailHistorySet.Add(SendEmail);
                    }
                }

            if (AddedCount > 0)
                Job.LastSent = DateTime.Now;

            this.AddStatusMessage($"{AddedCount} {"Email".Pluralize(AddedCount)} sent.");
            
            try
                {
                DbContext.SaveChanges();
                }
            catch (Exception Ex)
                {
                ControllerHelper.HandleError(this.HttpContext, Ex);

                this.AddStatusMessages_Error("An error has occured.");
                }

            return this.Redirect(ReturnUrl);
            }


        public override string PageGroup => ControllerHelper.Menu_Admin;

        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Edit;
        public EmailTemplateController(IAuthenticationService Auth) : base(Auth) { }
        }

    public class EmailTemplateSavedSearchViewModel : IModel
        {
        public EmailTemplate Template { get; set; }
        public SavedSearch SavedSearch { get; set; }

        public IEnumerable<EmailTemplate> Templates { get; set; }
        public IEnumerable<SavedSearch> Searches { get; set; }

        [FieldTypeDropdownSource("EmailTo")]
        public string[] EmailToIDs { get; set; }

        public IEnumerable<IEmailable> EmailTo { get; set; }
        }
    }