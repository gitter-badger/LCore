
using Singularity.Controllers;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCore;
using Singularity.Context;
using System.Web.UI.WebControls;
using Singularity.Annotations;
using Singularity.Extensions;

namespace Singularity.Controllers
    {
    [Authorize]
    public class EmailTemplateController : ManageController<EmailTemplate>
        {
        public ActionResult EmailSavedSearch(int? SavedSearchID, int? TemplateID)
            {
            List<EmailTemplate> Templates = HttpContext.GetModelData<EmailTemplate>()
                .Where(t => t.Active &&
                    (TemplateID == null ||
                    t.EmailTemplateID == TemplateID))
                .OrderBy(t => t.Subject)
                .List();

            List<SavedSearch> Searches = HttpContext.GetModelData<SavedSearch>()
                .Where(s => s.Active &&
                    (SavedSearchID == null ||
                    s.SavedSearchID == SavedSearchID))
                .OrderBy(s => s.Name)
                .List();

            Searches = Searches.Select((s) =>
            {
                Type t = TypeExt.FindType(s.SearchType);
                return t.HasInterface<IEmailable>();
            });

            EmailTemplateSavedSearchViewModel Model = new EmailTemplateSavedSearchViewModel()
            {
                Searches = Searches,
                Templates = Templates,
            };

            if (SavedSearchID != null)
                {
                Model.SavedSearch = HttpContext.GetModelData<SavedSearch>().Find(SavedSearchID);
                }

            if (TemplateID != null)
                {
                Model.Template = HttpContext.GetModelData<EmailTemplate>().Find(TemplateID);
                }

            return View(Model);
            }

        [HttpPost]
        public virtual ActionResult EmailSavedSearchTemplate(int EmailJobID, String ReturnURL, FormCollection Form)
            {
            ModelContext DbContext = this.HttpContext.GetModelContext();

            EmailJob Job = EmailJob.Find(DbContext, EmailJobID);


            String AllUserIDs = Form["EmailUsers[]"];

            int[] UserIDs = AllUserIDs.Split(',').Convert((s) =>
                {
                    return Convert.ToInt32(s.Trim());
                }).Array();

            DbSet<EmailHistory> EmailHistorySet = DbContext.GetDBSet<EmailHistory>();

            Type ModelType = ContextProviderFactory.GetCurrent().GetManageController(Session, Job.SavedSearch.ControllerName).ModelType;

            DbSet EmailSet = DbContext.GetDBSet(ModelType);

            int AddedCount = 0;

            foreach (int UserID in UserIDs)
                {
                EmailHistory SendEmail = new EmailHistory();
                SendEmail.Initialize();

                SendEmail.ReplyToAddress = Session.CurrentUser().GetEmails().FirstOrDefault();

                SendEmail.Subject = Job.EmailTemplate.Subject;

                // TODO fill tokens.
                SendEmail.Body = Job.EmailTemplate.Body;

                SendEmail.UserID = UserID;

                SendEmail.EmailJob = Job;

                SendEmail.EmailTemplate = Job.EmailTemplate;

                IEmailable User = (IEmailable)EmailSet.Find(UserID);

                SendEmail.ToAddresses = User.GetEmails(Job.EmailToField).JoinLines(",");

                EmailHistory Existing = EmailHistory.FindEmail(DbContext, SendEmail);

                if (Existing == null)
                    {
                    AddedCount++;

                    EmailHistorySet.Add(SendEmail);
                    }
                }

            if (AddedCount > 0)
                Job.LastSent = DateTime.Now;

            this.AddStatusMessage(AddedCount + " " + "Email".Pluralize(AddedCount) + " sent.");

            DbContext.SaveChanges();

            return Redirect(ReturnURL);
            }


        public override string PageGroup
            {
            get
                {
                return ControllerHelper.Menu_Admin;
                }
            }

        public override ControllerHelper.ViewType? ActionAfterCreate
            {
            get
                {
                return ControllerHelper.ViewType.Edit;
                }
            }
        }

    public class EmailTemplateSavedSearchViewModel : IModel
        {
        public EmailTemplate Template { get; set; }
        public SavedSearch SavedSearch { get; set; }

        public IEnumerable<EmailTemplate> Templates { get; set; }
        public IEnumerable<SavedSearch> Searches { get; set; }

        [FieldType_DropdownSource("EmailTo")]
        public String[] EmailToIDs { get; set; }

        public IEnumerable<IEmailable> EmailTo { get; set; }
        }
    }