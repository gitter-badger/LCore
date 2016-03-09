using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections;

using LCore;
using Singularity;
using Singularity.Models;
using Singularity.Context;
using Singularity.Filters;
using Singularity.Extensions;
using System.Web.Helpers;

namespace Singularity.Controllers
    {
    [Authorize]
    [SecurityFilter]
    public abstract class ManageController : SingularityController, IMenuController
        {
        public abstract Type ModelType { get; }

        public virtual Expression<Func<ManageController, Func<String, ActionResult>>> CreateAction
            {
            get
                {
                return c => c.Create;
                }
            }

        public abstract ActionResult Create(String ReturnURL);
        public abstract ActionResult Create(String ReturnURL, FormCollection Form);


        public abstract ActionResult Update(int id, String ReturnURL, FormCollection Form, Boolean Create = false);

        public abstract ActionResult Edit(int id, String ReturnURL, Boolean Create = false);

        public abstract ActionResult UploadFile(
            FormCollection Form,
            String ReturnURL,
            String RelationType,
            String RelationProperty,
            int RelationID);

        public abstract ActionResult Search(
            int Page = 1,
            String SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal);

        public abstract ActionResult Manage(
            int Page = 1,
            String SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal,
            String InlineEdit = null,
            Boolean DefaultManageSearch = false);

        public abstract void Export(
            int Page = 1,
            String SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.All,
            int CustomExportID = -1);

        public abstract void DeleteFile(int id, String ReturnURL);
        public abstract void DownloadFile(int FileID);

        public abstract ActionResult Details(int id, String ReturnURL);
        public abstract ActionResult Edit(int id, String ReturnURL, FormCollection Form, Boolean Create = false);
        public abstract ActionResult Delete(int id, String ReturnURL);
        public abstract ActionResult DeleteConfirm(int id, String ReturnURL, FormCollection collection, Boolean Restore = false);


        public virtual String Name
            {
            get
                {
                String Out = this.GetType().Name;

                Out = Out.Substring(0, Out.IndexOf("Controller"));

                return Out;
                }
            }

        public virtual String MenuText
            {
            get
                {
                return Name.Humanize().Pluralize();
                }
            }

        public virtual String ManageTitle
            {
            get
                {
                return null;
                }
            }

        public virtual Boolean ShowMenuTotalCount
            {
            get
                {
                return true;
                }
            }

        public abstract int GetTotalCount();

        public virtual IMenuItem[] GetMenuItems(ViewContext Context)
            {
            if (Context.AllowView(this.ModelType))
                {
                return new IMenuItem[] 
                {
                new MenuItem()
                    {
                    MenuText= this.MenuText,
                    PageGroup= this.PageGroup,
                    ControllerName= this.Name,
                    Action= Singularity.Routes.Controllers.Manage.Actions.Manage,
                    TotalCount= this.GetTotalCount(),
                    }
                };
                }
            else
                {
                return new IMenuItem[] { };
                }
            }

        public virtual int RowsPerPage
            {
            get
                {
                return ControllerHelper.DefaultRowsPerPage;
                }
            }

        public virtual String PageGroup
            {
            get
                {
                return null;
                }
            }

        public virtual ModelPermissions OverridePermissions
            {
            get
                {
                return ModelPermissions.AllowAll;
                }
            }

        public virtual ControllerHelper.ViewType? ActionAfterCreate
            {
            get
                {
                return null;
                }
            }

        public virtual Boolean ViewSavedSearches
            {
            get
                {
                return true;
                }
            }

        public abstract Boolean AllowAdminRandomize { get; }

        private ModelContext _DBContext = null;
        public ModelContext DBContext
            {
            get
                {
                return L.Cache(ref _DBContext, () =>
            {
                return ContextProviderFactory.GetCurrent().GetContext(Session);
            });
                }
            }

        public abstract Boolean ArchiveActive { get; }

        public abstract ControllerHelper Helper { get; }

        protected void AddStatusMessage(String Message)
            {
            TempData.Add(ControllerHelper.StatusMessage_Temporary, Message);
            }
        }
    }
