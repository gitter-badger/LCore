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
                .Where(t => t.Active &&
                    (TemplateID == null ||
                    t.EmailTemplateID == TemplateID))
                .OrderBy(t => t.Subject)
                .List();

            List<SavedSearch> Searches = this.HttpContext.GetModelData<SavedSearch>()
                .Where(s => s.Active &&
                    (SavedSearchID == null ||
                    s.SavedSearchID == SavedSearchID))
                .OrderBy(s => s.Name)
                .List();

            Searches = Searches.Select(s =>
            {
                var t = L.Ref.FindType(s.SearchType);
                return t.HasInterface<IEmailable>();
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

            int[] UserIDs = AllUserIDs.Split(',').Convert(s => Convert.ToInt32(s.Trim())).Array();

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

            DbContext.SaveChanges();

            return this.Redirect(ReturnUrl);
            }


        public override string PageGroup => ControllerHelper.Menu_Admin;

        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Edit;
        public EmailTemplateController(IAuthenticationService Auth) : base(Auth) {}
        }

    public class EmailTemplateSavedSearchViewModel : IModel
        {
        public EmailTemplate Template { get; set; }
        public SavedSearch SavedSearch { get; set; }

        public IEnumerable<EmailTemplate> Templates { get; set; }
        public IEnumerable<SavedSearch> Searches { get; set; }

        [FieldType_DropdownSource("EmailTo")]
        public string[] EmailToIDs { get; set; }

        public IEnumerable<IEmailable> EmailTo { get; set; }
        }
    }