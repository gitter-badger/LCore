using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using LMVC.Context;
using LMVC.Models;

namespace LMVC.Controllers
    {
    public interface IManageController
        {
        ControllerHelper.ViewType? ActionAfterCreate { get; }
        bool AllowAdminRandomize { get; }
        bool ArchiveActive { get; }
        Expression<Func<IManageController, Func<string, ActionResult>>> CreateAction { get; }
        IModelContext DbContext { get; }

        string ManageTitle { get; }
        string MenuText { get; }
        Type ModelType { get; }
        string Name { get; }
        IModelPermissions OverridePermissions { get; }
        string PageGroup { get; }
        int RowsPerPage { get; }
        bool ShowMenuTotalCount { get; }
        bool ViewSavedSearches { get; }

        ActionResult Create(string ReturnUrl);
        ActionResult Create(string ReturnUrl, FormCollection Form);
        ActionResult Delete(int ID, string ReturnUrl);
        ActionResult DeleteConfirm(int ID, string ReturnUrl, FormCollection Collection, bool Restore = false);
        void DeleteFile(int ID, string ReturnUrl);
        ActionResult Details(int ID, string ReturnUrl);
        void DownloadFile(int FileID);
        ActionResult Edit(int ID, string ReturnUrl, bool Create = false);
        ActionResult Edit(int ID, string ReturnUrl, FormCollection Form, bool Create = false);
        void Export(int Page, string SortTerm, System.Web.Helpers.SortDirection SortDirection, string GlobalSearchTerm, string FieldSearchTerms, ControllerHelper.ManageViewType ViewType, int CustomExportID);
        IMenuItem[] GetMenuItems(ViewContext Context);
        int GetTotalCount();

        ActionResult Manage(
            int Page = 1,
            string SortTerm = null,
            System.Web.Helpers.SortDirection SortDirection = System.Web.Helpers.SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal,
            string InlineEdit = null,
            bool DefaultManageSearch = false);

        ActionResult Search(
            int Page = 1,
            string SortTerm = null,
            System.Web.Helpers.SortDirection SortDirection = System.Web.Helpers.SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal);

        ActionResult Update(int ID, string ReturnUrl, FormCollection Form, bool Create);
        ActionResult UploadFile(FormCollection Form, string ReturnUrl, string RelationType, string RelationProperty, int RelationID);
        }
    }