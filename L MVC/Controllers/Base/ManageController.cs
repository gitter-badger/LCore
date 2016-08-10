using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using LCore.Extensions;
using LMVC.Context;
using LMVC.Extensions;
using LMVC.Account;
using LMVC.Filters;
using LMVC.Models;

namespace LMVC.Controllers
    {
    [Authorize]
    [SecurityFilter]
    public abstract class ManageController : SingularityController, IMenuController, IManageController
        {
        public abstract Type ModelType { get; }

        public virtual Expression<Func<IManageController, Func<string, ActionResult>>> CreateAction
            {
            get
                {
                return Controller => Controller.Create;
                }
            }

        public abstract ActionResult Create(string ReturnUrl);
        public abstract ActionResult Create(string ReturnUrl, FormCollection Form);


        public abstract ActionResult Update(int ID, string ReturnUrl, FormCollection Form, bool Create = false);

        public abstract ActionResult Edit(int ID, string ReturnUrl, bool Create = false);

        public abstract ActionResult UploadFile(
            FormCollection Form,
            string ReturnUrl,
            string RelationType,
            string RelationProperty,
            int RelationID);

        public abstract ActionResult Search(
            int Page = 1,
            string SortTerm = null,
            System.Web.Helpers.SortDirection SortDirection = System.Web.Helpers.SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal);

        public abstract ActionResult Manage(
            int Page = 1,
            string SortTerm = null,
            System.Web.Helpers.SortDirection SortDirection = System.Web.Helpers.SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal,
            string InlineEdit = null,
            bool DefaultManageSearch = false);

        public abstract void Export(
            int Page = 1,
            string SortTerm = null,
            System.Web.Helpers.SortDirection SortDirection = System.Web.Helpers.SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.All,
            int CustomExportID = -1);

        public abstract void DeleteFile(int ID, string ReturnUrl);
        public abstract void DownloadFile(int FileID);

        public abstract ActionResult Details(int ID, string ReturnUrl);
        public abstract ActionResult Edit(int ID, string ReturnUrl, FormCollection Form, bool Create = false);
        public abstract ActionResult Delete(int ID, string ReturnUrl);
        public abstract ActionResult DeleteConfirm(int ID, string ReturnUrl, FormCollection Collection, bool Restore = false);


        public virtual string Name
            {
            get
                {
                string Out = this.GetType().Name;

                Out = Out.Sub(Start: 0, Length: Out.IndexOf("Controller"));

                return Out;
                }
            }

        public virtual string MenuText => this.Name.Humanize().Pluralize();

        public virtual string ManageTitle => null;

        public virtual bool ShowMenuTotalCount => true;

        public abstract int GetTotalCount();

        public virtual IMenuItem[] GetMenuItems(ViewContext Context)
            {
            if (Context.AllowView(this.ModelType))
                {
                return new IMenuItem[]
                {
                new MenuItem
                    {
                    MenuText= this.MenuText,
                    PageGroup= this.PageGroup,
                    ControllerName= this.Name,
                    Action= nameof(this.Manage),
                    TotalCount = this.GetTotalCount()
                    }
                };
                }
            return new IMenuItem[] { };
            }

        public virtual int RowsPerPage => SingularityControllerHelper.DefaultRowsPerPage;

        public virtual string PageGroup => null;

        public virtual IModelPermissions OverridePermissions => ModelPermissions.AllowAll;

        public virtual ControllerHelper.ViewType? ActionAfterCreate => null;

        public virtual bool ViewSavedSearches => true;

        public abstract bool AllowAdminRandomize { get; }

        private IModelContext _DbContext;
        public IModelContext DbContext
            {
            get
                {
                return L.Logic.Cache(ref this._DbContext, () => ContextProviderFactory.GetCurrent().GetContext(this.Session));
                }
            }

        public abstract bool ArchiveActive { get; }

        public abstract SingularityControllerHelper Helper { get; }

        protected void AddStatusMessage(string Message)
            {
            this.TempData.Add(SingularityControllerHelper.StatusMessage_Temporary, Message);
            }

        protected ManageController(IAuthenticationService Auth) : base(Auth)
            {
            }
        protected ManageController()
            {
            }
        }
    }
