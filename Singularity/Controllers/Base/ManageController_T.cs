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
using Singularity.Annotations;
using Singularity.Utilities;

namespace Singularity.Controllers
    {
    public abstract class ManageController<T> : ManageController
        where T : class, IModel
        {
        public override Type ModelType
            {
            get { return typeof(T); }
            }

        #region Manage
        public override ActionResult Manage(
            int Page = 1,
            String SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal,
            String InlineEdit = null,
            Boolean DefaultManageSearch = false)
            {
            ManageViewModel m = new ManageViewModel(this);

            SavedSearch DefaultSearch = SavedSearch.FindDefault(DBContext, ModelType.FullName, Name, true);

            if (DefaultManageSearch)
                {
                GlobalSearchTerm = DefaultSearch.GlobalSearch;
                FieldSearchTerms = DefaultSearch.FieldSearch;
                SortTerm = DefaultSearch.OverrideSort;
                SortDirection = DefaultSearch.OverrideSortDirection ?? SortDirection.Ascending;
                }

            try
                {
                GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
                FieldSearchTerms = (FieldSearchTerms ?? "").Trim();

                m.Page = (Page - 1);
                m.TypeName = typeof(T).Name;
                m.ModelType = typeof(T);
                m.ViewType = ViewType;
                m.InlineEditID = InlineEdit;

                if (m.ModelType == null)
                    throw new ArgumentException("TypeName");

                if (Session == null ||
                    ContextProviderFactory.GetCurrent().GetModelPermissions(Session, m.ModelType).View != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                if (Session == null ||
                    (ContextProviderFactory.GetCurrent().GetModelPermissions(Session, m.ModelType).ViewInactive != true &&
                    ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)))
                    {
                    return new HttpUnauthorizedResult();
                    }

                m.FieldSearchTerms = Helper_T.ExtractSearchTerms(ref FieldSearchTerms, m.ModelType);
                m.GlobalSearchTerm = GlobalSearchTerm;

                if (String.IsNullOrEmpty(SortTerm))
                    {
                    SetDefaultSort(m);
                    }
                else
                    {
                    m.OverrideSort = SortTerm;
                    m.OverrideSortDirection = SortDirection;
                    }

                int TotalItems = 0;

                m.Models = Helper_T.GetModels(out TotalItems,
                    Page, this.RowsPerPage,
                    m.OverrideSort, m.OverrideSortDirection,
                    m.GlobalSearchTerm, m.FieldSearchTerms,
                    m.ViewType);

                m.TotalItems = TotalItems;
                m.TotalPages = (int)Math.Ceiling((double)TotalItems / (double)RowsPerPage);
                }
            catch (Exception e)
                {
                if (Session.IsAdmin())
                    ModelState.AddModelError(string.Empty, "An error has occured - " + e.ToString());
                else
                    ModelState.AddModelError(string.Empty, "An unexpected error has occured");
                }

            return View(m);
            }
        #endregion

        #region Search
        [Route("Search/{TypeName}")]
        [HttpPost]
        public override ActionResult Search(
            int Page = 1,
            String SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal)
            {
            ManageViewModel m = new ManageViewModel(this);

            try
                {
                m.Page = (Page - 1);
                m.TypeName = typeof(T).Name;
                m.ModelType = typeof(T);
                m.ViewType = ViewType;

                GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
                FieldSearchTerms = (FieldSearchTerms ?? "").Trim();

                if (!String.IsNullOrEmpty(FieldSearchTerms) &&
                    !String.IsNullOrEmpty(GlobalSearchTerm))
                    {
                    GlobalSearchTerm = FieldSearchTerms + "|" + GlobalSearchTerm;
                    FieldSearchTerms = "";
                    }

                m.FieldSearchTerms = Helper_T.ExtractSearchTerms(ref GlobalSearchTerm, m.ModelType);
                m.GlobalSearchTerm = GlobalSearchTerm;

                return RedirectToAction(Singularity.Routes.Controllers.Manage.Actions.Manage, this.Name, new
                {
                    TypeName = m.TypeName,
                    Page = m.Page + 1,
                    SortDirection = SortDirection,
                    SortTerm = SortTerm,
                    GlobalSearchTerm = GlobalSearchTerm,
                    FieldSearchTerms = m.GetGlobalSearchCombined("Global"),
                    ViewType = m.ViewType,
                });
                }
            catch (Exception e)
                {
                if (Session.IsAdmin())
                    ModelState.AddModelError(string.Empty, "An error has occured - " + e.ToString());
                else
                    ModelState.AddModelError(string.Empty, "An unexpected error has occured");
                }

            return RedirectToAction(Singularity.Routes.Controllers.Manage.Actions.Manage, this.Name, new
            {
                TypeName = m.TypeName
            });
            }
        #endregion

        #region Export
        public override void Export(
            int Page = 1,
            String SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.All,
            int CustomExportID = -1)
            {
            GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
            FieldSearchTerms = (FieldSearchTerms ?? "").Trim();


            ManageViewModel m = new ManageViewModel(this);
            m.Page = (Page - 1);
            m.TypeName = typeof(T).Name;
            m.ModelType = typeof(T);
            m.ViewType = ViewType;

            if (m.ModelType == null)
                throw new ArgumentException("TypeName");

            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, m.ModelType).Export != true)
                {
                return;
                }

            if (Session == null ||
                (ContextProviderFactory.GetCurrent().GetModelPermissions(Session, m.ModelType).ViewInactive != true &&
                m.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)))
                {
                return;
                }

            if (String.IsNullOrEmpty(SortTerm))
                {
                SetDefaultSort(m);
                }
            else
                {
                m.OverrideSort = SortTerm;
                m.OverrideSortDirection = SortDirection;
                }

            m.FieldSearchTerms = Helper_T.ExtractSearchTerms(ref FieldSearchTerms, m.ModelType);
            m.GlobalSearchTerm = GlobalSearchTerm;

            int TotalItems = 0;

            List<String> ColumnNames = new List<String>();

            //List<MemberInfo> Members = new List<MemberInfo>();
            //List<Delegate> Accessors = new List<Delegate>();
            List<Func<Object, Object>> Functions = new List<Func<Object, Object>>();

            String FileName = m.ModelType.Name + "-" + DateTime.Now.ToString().ReplaceAll("/", "-").ReplaceAll("\\", "-").ReplaceAll(":", "-");

            List<ModelMetadata> Columns = new List<ModelMetadata>();

            CustomExport CustomExport = null;

            if (CustomExportID >= 0)
                {
                CustomExport = CustomExport.Find(DBContext, CustomExportID);

                if (!String.IsNullOrEmpty(CustomExport.OverrideSort))
                    {
                    m.OverrideSort = CustomExport.OverrideSort;
                    m.OverrideSortDirection = SortDirection.Ascending;

                    if (CustomExport.OverrideSortDirection == System.Web.Helpers.SortDirection.Descending)
                        m.OverrideSortDirection = SortDirection.Descending;
                    }

                ColumnNames.AddRange(CustomExport.Fields.Lines());

                Dictionary<String, ModelMetadata> AllMeta = m.ModelType.GetMeta();

                ColumnNames = ColumnNames.Select((c) =>
                    {
                        return AllMeta.Keys.Has(c);
                    });

                ColumnNames.Each((c) =>
                {
                    ModelMetadata Meta = AllMeta[c];

                    if (c.Contains("."))
                        {
                        if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                            {
                            String[] FullProperty = null;
                            Meta = null;

                            LambdaExpression Lambda = m.ModelType.GetTokenExpression(c, out Meta);

                            Func<Object, Object> F = ((Expression<Func<Object, Object>>)Lambda).Compile();

                            Columns.Add(Meta);
                            // Members.Add(Meta.GetMember());
                            //  Accessors.Add(Meta.GetDelegate());
                            Functions.Add(F);
                            }
                        }
                    else if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                        {
                        Columns.Add(Meta);
                        // Members.Add(Meta.GetMember());
                        //  Accessors.Add(Meta.GetDelegate());
                        Functions.Add(Meta.GetFunc());
                        }
                });

                }
            else
                {
                foreach (ModelMetadata Meta in m.ModelType.Meta().Properties)
                    {
                    if (Meta.ModelType.FullName.StartsWith("System.Collections.Generic.ICollection`1"))
                        {
                        // Ignore collections
                        }
                    else if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                        {
                        Columns.Add(Meta);
                        ColumnNames.Add(Meta.DisplayName ?? Meta.PropertyName);
                        // Members.Add(Meta.GetMember());
                        //  Accessors.Add(Meta.GetDelegate());
                        Functions.Add(Meta.GetFunc());
                        }
                    }

                // Add field search terms to data
                if (m.FieldSearchTerms != null)
                    {
                    foreach (SearchOperation Op in m.FieldSearchTerms.Values)
                        {
                        if (Op.Property.Contains("."))
                            {
                            ModelMetadata Meta = null;
                            String[] FullProperty = null;

                            LambdaExpression Lambda = m.ModelType.FindSubProperty(out Meta, out FullProperty, Op.Property.Split("."));

                            if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                                {
                                ParameterExpression Param = Lambda.Parameters[0];
                                Expression AsObject = Expression.TypeAs(Lambda.Body, typeof(Object));
                                LambdaExpression Lambda2 = Expression.Lambda(AsObject, Param);

                                ParameterExpression Param2 = Expression.Parameter(typeof(Object), "b");
                                Expression AsT = Expression.TypeAs(Param2, m.ModelType);

                                InvocationExpression Invoke = Expression.Invoke(Lambda2, AsT);
                                LambdaExpression Lambda3 = Expression.Lambda(Invoke, Param2);

                                //                        if (Lambda2.CanReduce)
                                //                            Lambda2 = Lambda2.Reduce();

                                Func<Object, Object> F = ((Expression<Func<Object, Object>>)Lambda3).Compile();

                                Columns.Add(Meta);
                                ColumnNames.Add(FullProperty.JoinLines(" "));
                                // Members.Add(Meta.GetMember());
                                //  Accessors.Add(Meta.GetDelegate());
                                Functions.Add(F);
                                }
                            }
                        else if (!Columns.Has(c => { return (c.DisplayName ?? c.PropertyName) == Op.Property; }))
                            {
                            ModelMetadata Meta = m.ModelType.Meta(Op.Property);

                            if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                                {
                                Columns.Add(Meta);
                                ColumnNames.Add(Meta.DisplayName ?? Meta.PropertyName);
                                // Members.Add(Meta.GetMember());
                                //  Accessors.Add(Meta.GetDelegate());
                                Functions.Add(Meta.GetFunc());
                                }
                            }
                        }
                    }
                }

            IEnumerable<T> Models = Helper_T.GetModels_T(out TotalItems,
                Page,
                -1, // All records
                m.OverrideSort,
                m.OverrideSortDirection,
                m.GlobalSearchTerm,
                m.FieldSearchTerms,
                m.ViewType);

            StringWriter sw = new StringWriter();

            // CSV Column Headers
            for (int i = 0; i < ColumnNames.Count; i++)
                {
                sw.Write("\"" + ColumnNames[i] + "\"");

                if (i < ColumnNames.Count - 1)
                    sw.Write(",");
                }

            sw.Write("\r\n");

            int Progress = 0;

            // CSV Body
            foreach (IModel Model in Models)
                {
                for (int i = 0; i < Functions.Count; i++)
                    {
                    Object Obj = Functions[i](Model);

                    if (Obj is DateTime)
                        {
                        if (((DateTime)Obj).Ticks == ((DateTime)Obj).Date.Ticks)
                            {
                            Obj = ((DateTime)Obj).ToShortDateString();
                            }
                        }

                    sw.Write("\"" + (Obj ?? "").ToString().ReplaceAll("\"", "'") + "\"");
                    //sw.Write("\"" + (((delegate)(Accessors[i]))(Model) ?? "").ToString() + "\"");
                    //sw.Write("\"" + (Members[i].GetValue(Model) ?? "").ToString() + "\"");
                    if (i < Columns.Count - 1)
                        sw.Write(",");
                    }
                sw.Write("\r\n");
                Progress++;
                }

            Response.WriteCSV(sw, FileName);
            }
        #endregion

        #region Details
        public override ActionResult Details(int id, String ReturnURL)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).View != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = (IModel)GetModelQuery().Find(id);

            if (!Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            ViewBag.ReturnURL = ReturnURL;
            ViewBag.ManageController = this;

            return View(Model);
            }
        #endregion

        #region Edit
        public override ActionResult Edit(int id, String ReturnURL, Boolean Create = false)
            {

            if (Create)
                {
                if (Session == null ||
                     ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Create != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                IModel Model = GetModel(0, true, null);

                return Edit(Model, ReturnURL, Create);
                }
            else
                {
                if (Session == null ||
                     ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Edit != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                IModel Model = (IModel)GetModelQuery().Find(id);

                if (!Session.CurrentRole().AllowAccess(Model))
                    {
                    return new HttpUnauthorizedResult();
                    }

                return Edit(Model, ReturnURL);
                }
            }

        protected virtual ActionResult Edit(IModel Model, String ReturnURL, Boolean Create = false)
            {
            ViewBag.ReturnURL = ReturnURL;

            ViewBag.ControllerName = this.Name;

            ViewBag.AllowAdminRandomize = this.AllowAdminRandomize;

            ViewBag.Route_Edit = new
            {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL = ReturnURL,
                Create = Create,
            };
            ViewBag.Route_Update = new
            {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL = ReturnURL,
                Create = Create,
            };

            ViewBag.EditModel = Model;

            ViewBag.Create = !Model.HasID();

            ViewBag.Title = (ViewBag.Create ? "Create" : "Edit") + " " + Model.GetFriendlyTypeName() + ": " + Model.ToString();

            return View(Model);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public override ActionResult Edit(int id, String ReturnURL, FormCollection Form, Boolean Create = false)
            {
            Boolean UpdateMode = !String.IsNullOrEmpty(Form["UpdateButton"]);

            if (Session == null ||
                 ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Edit != true)
                {
                return new HttpUnauthorizedResult();
                }

            ViewBag.ControllerName = this.Name;

            T Model = null;

            Model = GetModel(id, Create, Model);

            Boolean Errors = false;

            Errors = Errors || this.ModelBindingBefore(Form, DBContext, Model);

            Form.Keys.List<String>().Each((Key) =>
            {
                Errors = Errors || SetModelField(Form, Model, Key);
                return;
            });

            Errors = Errors || this.ModelBindingAfter(Form, DBContext, Model, Errors);

            if (!Errors)
                {
                try
                    {
                    if (Create)
                        {
                        // Attach related models so they don't get duplicated
                        foreach (ModelMetadata Meta in Model.Properties())
                            {
                            if (Meta.ModelType.HasInterface<IModel>(true))
                                {
                                DbSet Set = DBContext.GetDBSet(Meta.ModelType);

                                if (Set != null)
                                    {
                                    Set.Attach(Model.GetProperty(Meta.PropertyName));
                                    }
                                }
                            }

                        DBContext.GetDBSet<T>().Add(Model);
                        }

                    if (UpdateMode)
                        {
                        Boolean Before = DBContext.Configuration.ValidateOnSaveEnabled;
                        DBContext.Configuration.ValidateOnSaveEnabled = false;

                        DBContext.SaveChanges();

                        DBContext.Configuration.ValidateOnSaveEnabled = Before;
                        }
                    else
                        {
                        DBContext.SaveChanges();
                        }
                    }
                catch (Exception e)
                    {
                    Errors = true;

                    String Message = "An error occurred while saving data";

                    if (ContextProviderFactory.GetCurrent().CurrentUser(Session).IsAdmin == true)
                        {
                        Message += " - " + e.Message + " " + e.ToString();
                        }

                    ModelState.AddModelError("", Message);
                    }
                }

            if (!Errors)
                {
                this.AddStatusMessage("Successfully " + (Create ? "Created" : "Updated") + " - " + Model.GetFriendlyTypeName());

                if (!UpdateMode)
                    {
                    if (Create && this.ActionAfterCreate == ControllerHelper.ViewType.Edit)
                        {
                        return RedirectToAction(Singularity.Routes.Controllers.Manage.Actions.Edit,
                            Singularity.Routes.Controllers.Manage.Actions.Route_Edit(Model, ReturnURL));
                        }
                    else if (Create && this.ActionAfterCreate == ControllerHelper.ViewType.Display)
                        {
                        return RedirectToAction(Singularity.Routes.Controllers.Manage.Actions.Details,
                            Singularity.Routes.Controllers.Manage.Actions.Route_DetailView(Model, ReturnURL));
                        }
                    else
                        {
                        return Redirect(ReturnURL);
                        }
                    }
                }

            return Edit(Model, ReturnURL, Create);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public override ActionResult Update(int id, String ReturnURL, FormCollection Form, Boolean Create = false)
            {
            Edit(id, ReturnURL, Form, Create);

            return RedirectToAction(Singularity.Routes.Controllers.Manage.Actions.Edit, new
                {
                    id = id,
                    ReturnURL = ReturnURL,
                    Create = Create
                });
            }
        #endregion

        #region Create
        public override ActionResult Create(String ReturnURL)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Create != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = GetModel(0, true, null);

            return Edit(Model, ReturnURL, Create: true);
            }

        [HttpPost]
        public override ActionResult Create(String ReturnURL, FormCollection Form)
            {
            return Edit(0, ReturnURL, Form, true);
            }
        #endregion

        #region Delete
        public override ActionResult Delete(int id, String ReturnURL)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = (IModel)GetModelQuery().Find(id);

            if (!Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            ViewBag.ReturnURL = ReturnURL;

            return View(Model);
            }

        [IgnoreValidation]
        public override ActionResult DeleteConfirm(int id, String ReturnURL, FormCollection collection, Boolean Restore = false)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

            DbSet DBSet = GetModelQuery();

            T Model = (T)DBSet.Find(id);

            if (!Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            Boolean Before = DBContext.Configuration.ValidateOnSaveEnabled;

            DBContext.Configuration.ValidateOnSaveEnabled = false;

            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active))
                {
                Boolean Val = Restore;

                if (Model.Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Nullable<Boolean>))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, (Boolean?)Val);
                else
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, Val);

                foreach (var Value in ModelState.Values)
                    {
                    Value.Errors.Clear();
                    }

                DBContext.SaveChanges();
                }
            else
                {
                DBSet.Remove(Model);
                DBContext.SaveChanges();
                }

            DBContext.Configuration.ValidateOnSaveEnabled = Before;

            return Redirect(ReturnURL);
            }
        #endregion

        #region UploadFile
        [HttpPost]
        public override ActionResult UploadFile(
            FormCollection Form,
            String ReturnURL,
            String RelationType,
            String RelationProperty,
            int RelationID)
            {
            List<HttpPostedFileBase> UploadFiles = new List<HttpPostedFileBase>();

            foreach (String name in Request.Files)
                {
                if (name != "UploadFile" + RelationProperty)
                    continue;

                HttpPostedFileBase file = Request.Files[name];
                if (file.ContentLength > 0)
                    UploadFiles.Add(file);
                }

            if (UploadFiles.Count == 1)
                {
                ActionResult Result = UploadSingleFile(Form, RelationType, RelationProperty, RelationID, UploadFiles[0]);

                DBContext.SaveChanges();

                if (Result != null)
                    return Result;
                }
            else if (!UploadFiles.IsEmpty())
                {
                foreach (HttpPostedFileBase File in UploadFiles)
                    {
                    UploadSingleFile(Form, RelationType, RelationProperty, RelationID, File);
                    }

                DBContext.SaveChanges();
                }

            return Redirect(ReturnURL);
            }

        protected virtual ActionResult UploadSingleFile(FormCollection Form, String RelationType, String RelationProperty, int RelationID, HttpPostedFileBase File)
            {
            Singularity.Models.FileUpload FileUp = GetFileUpload(File, Form, RelationType, RelationProperty, RelationID);

            DBContext.GetDBSet<Singularity.Models.FileUpload>().Add(FileUp);

            return null;
            }

        protected virtual Singularity.Models.FileUpload GetFileUpload(HttpPostedFileBase UploadFile, FormCollection Form, String RelationType, String RelationProperty, int RelationID)
            {
            ContextProvider Provider = ContextProviderFactory.GetCurrent();
            String RootPath = Provider.GetFileUploadRootPath(Session, UploadFile, RelationType, RelationProperty, RelationID);
            String FilePath = Provider.GetFileUploadFilePath(Session, UploadFile, RelationType, RelationProperty, RelationID);

            String FullPath = L.CombinePaths(RootPath, FilePath);

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(FullPath)))
                {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FullPath));
                }

            Singularity.Models.FileUpload FileUp = new Singularity.Models.FileUpload(UploadFile, Provider.GetFileUploadCloudContainer(), FilePath);

            FileUp.RelationType = RelationType;
            FileUp.RelationProperty = RelationProperty;
            FileUp.RelationID = RelationID;

            return FileUp;
            }
        #endregion

        #region DownloadFile
        public override void DownloadFile(int FileID)
            {
            Singularity.Models.FileUpload FileUp = Singularity.Models.FileUpload.FindFileUpload(DBContext, FileID, typeof(T));

            if (!Session.CurrentRole().AllowAccess(FileUp))
                {
                throw new ArgumentException("FileID");
                }

            if (FileUp == null)
                {
                throw new ArgumentException("FileID");
                }

            Byte[] FileBytes = FileUp.GetCloudBytes();

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileUp.FilePath + "");
            Response.AddHeader("Content-Length", FileBytes.Length.ToString());

            //Response.ContentType = "application/binary";
            Response.BinaryWrite(FileBytes);
            Response.End();
            }
        #endregion}

        #region DeleteFile
        public override void DeleteFile(int id, String ReturnURL)
            {
            Singularity.Models.FileUpload File = Singularity.Models.FileUpload.FindFileUpload(DBContext, id, typeof(T));

            if (!Session.CurrentRole().AllowAccess(File))
                {
                throw new ArgumentException("FileID");
                }

            if (File == null)
                {
                throw new ArgumentException("FileID");
                }

            File.Active = false;
            DBContext.SaveChanges();

            Response.Redirect(ReturnURL);
            }
        #endregion

        private void SetDefaultSort(ManageViewModel ManageModel)
            {
            DisplayColumnAttribute attr = ManageModel.ModelType.MemberGetAttribute<DisplayColumnAttribute>(false);

            if (attr != null)
                {
                if (!String.IsNullOrEmpty(attr.SortColumn))
                    {
                    ManageModel.OverrideSort = attr.SortColumn;
                    ManageModel.OverrideSortDirection = attr.SortDescending ? SortDirection.Descending : SortDirection.Ascending;
                    }
                }

            return;
            }

        public override bool AllowAdminRandomize
            {
            get
                {
                return false;
                }
            }

        protected virtual T GetModel(int id, Boolean Create, T Model)
            {
            if (Create)
                {
                Model = typeof(T).New<T>();

                Model.Initialize();
                }
            else
                {
                Model = (T)GetModelQuery().Find(id);

                if (Model.HasProperty(ControllerHelper.AutomaticFields.Updated))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Updated, DateTime.Now);
                }

            // Load fields from query string
            List<ModelMetadata> MetaData = Model.Properties().List();

            MetaData.Each((m) =>
            {
                if (m.HasAttribute<IFieldLoadFromQueryStringAttribute>())
                    {
                    if (StringConverter.IsTypeSupported(m))
                        {
                        String QS = Request.QueryString[m.PropertyName];

                        if (!String.IsNullOrEmpty(QS))
                            {
                            StringConverter Converter = new StringConverter(Session);

                            Object Value = Converter.PerformAction(QS, m.ModelType);

                            Model.SetProperty(m.PropertyName, Value);
                            }
                        }
                    else if (m.ModelType.HasInterface<IConvertible>())
                        {
                        }
                    else if (m.ModelType.HasInterface<IModel>())
                        {
                        String QS = Request.QueryString[m.PropertyName];

                        DbSet Context = this.DBContext.GetDBSet(m.ModelType);
                        IModel QSModel = (IModel)Context.Find(QS);

                        if (QSModel != null)
                            {
                            Model.SetProperty(m.PropertyName, QSModel);
                            }
                        }
                    }
            });

            return Model;
            }

        protected virtual bool ModelBindingBefore(FormCollection Form, ModelContext Context, T Model)
            {
            return false;
            }

        protected virtual bool ModelBindingAfter(FormCollection Form, ModelContext Context, T Model, bool Errors)
            {
            return false;
            }

        protected virtual Boolean SetModelField(FormCollection Form, T Model, string Key)
            {
            Boolean Errors = false;

            try
                {
                IEnumerable<ModelMetadata> CustomKeyMeta = Model.Properties().Where(
                    pr => pr.HasAttribute<FieldFormKeyAttribute>() &&
                        pr.GetAttribute<FieldFormKeyAttribute>().CustomKey == Key);

                String Property = Key;

                if (CustomKeyMeta.Count() == 1)
                    {
                    Property = CustomKeyMeta.FirstOrDefault().PropertyName;
                    }

                String Value = Form[Key];

                if (!Model.TrueModelType().HasProperty(Property))
                    return false;

                ModelMetadata Meta = Model.Meta(Property);

                // Fix for Boolean Checkbox fields from HtmlHelper
                if (Value == "true,false" &&
                    (Meta.ModelType == typeof(Boolean) ||
                    Meta.ModelType == typeof(Boolean?)))
                    {
                    Value = "true";
                    }

                if (Meta.HasAttribute<KeyAttribute>())
                    return false;

                if (Meta.HasAttribute<ISetFormField>())
                    return Meta.GetAttribute<ISetFormField>().SetFormField(Form, Model, Meta, Value);

                StringConverter Convert = new StringConverter(Session);

                LambdaExpression Lambda = Meta.GetExpression();

                PropertyInfo p = Model.TrueModelType().GetProperty(Property);

                if (!Meta.IsRequired && (Value ?? "").Trim() == "")
                    {
                    try
                        {
                        p.SetValue(Model, null);
                        }
                    catch
                        {
                        }

                    return false;
                    }

                Object Obj = Convert.PerformAction(Value, Meta.ModelType);


                if (p != null)
                    {
                    p.SetValue(Model, Obj);
                    }

                if (!ModelState.IsValidField(Key))
                    {
                    throw new ValidationException(ListExt.List<ModelError>(ModelState[Key].Errors).CollectStr<ModelError>((i, e) => { return e.ErrorMessage; }));
                    }
                }
            catch (ValidationException e)
                {
                ModelState.AddModelError(Key, e.Message);
                }
            catch (Exception e)
                {
                Errors = true;

                String Message = "An error occurred while saving this field";

                IModelUser Profile = ContextProviderFactory.GetCurrent().CurrentUser(Session);

                if (Profile != null &&
                    Profile.IsAdmin == true)
                    {
                    Message += " - " + e.Message;
                    }

                ModelState.AddModelError(Key, Message);
                }

            return Errors;
            }

        public override Boolean ArchiveActive
            {
            get
                {
                return GetArchivedCondition(true) != null;
                }
            }

        public virtual TimeSpan ArchiveTimeSpan
            {
            get
                {
                return ControllerHelper.DefaultArchiveTimeSpan;
                }
            }

        public virtual Expression<Func<T, Boolean>> GetArchivedCondition(Boolean Archived)
            {
            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Archived) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Archived).ModelType == typeof(Boolean))
                {
                Expression<Func<T, Boolean>> Exp = typeof(T).GetExpression<T, Boolean>(ControllerHelper.AutomaticFields.Active);
                Expression Equal = Archived ?
                    Expression.Equal(Exp.Body, Expression.Constant(true)) :
                    Expression.Equal(Exp.Body, Expression.Constant(false));
                Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                return (Expression<Func<T, Boolean>>)Lambda;
                }
            else if (ArchiveTimeSpan != null &&
                typeof(T).HasProperty(ControllerHelper.AutomaticFields.Created) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Created).ModelType == typeof(DateTime))
                {
                DateTime Cutoff = DateTime.Now.Subtract(ArchiveTimeSpan);

                Expression<Func<T, DateTime>> Exp = typeof(T).GetExpression<T, DateTime>(ControllerHelper.AutomaticFields.Created);
                Expression LessThan = Archived ?
                    Expression.LessThan(Exp.Body, Expression.Constant(Cutoff)) :
                    Expression.GreaterThanOrEqual(Exp.Body, Expression.Constant(Cutoff));

                Expression Lambda = Expression.Lambda(LessThan, Exp.Parameters[0]);

                return (Expression<Func<T, Boolean>>)Lambda;
                }
            else
                {
                return null;
                }
            }

        [NonAction]
        public override int GetTotalCount()
            {
            Func<int> Count = () =>
            {
                IQueryable<T> Set = GetModelQuery();

                Set = RestrictScope(Set);

                Set = QueryExt.FilterSet_Active(Set);

                return Set.Count();
            };

            return Count.Cache(this.GetType().FullName + "TotalCountCache")();
            }

        [NonAction]
        public virtual DbSet<T> GetModelQuery()
            {
            return DBContext.GetDBSet<T>();
            }

        [NonAction]
        public virtual IQueryable<T> RestrictScope(IQueryable<T> Query)
            {
            return Query;
            }


        public override ControllerHelper Helper
            {
            get
                {
                return Helper_T;
                }
            }
        public ControllerHelper<T> Helper_T { get; private set; }

        public ManageController()
            {
            this.Helper_T = new ControllerHelper<T>(this);
            }
        }
    }
