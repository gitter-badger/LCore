using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Data.Entity;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Models;
using Singularity.Context;
using Singularity.Extensions;
using System.Web.Helpers;
using Singularity.Account;
using Singularity.Annotations;
using Singularity.Utilities;
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace Singularity.Controllers
    {
    public abstract class ManageController<T> : ManageController
        where T : class, IModel
        {
        public override Type ModelType => typeof(T);

        #region Manage
        public override ActionResult Manage(
            int Page = 1,
            string SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal,
            string InlineEdit = null,
            bool DefaultManageSearch = false)
            {
            var m = new ManageViewModel(this);

            var DefaultSearch = SavedSearch.FindDefault(this.DBContext, this.ModelType.FullName, this.Name, true);

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

                m.Page = Page - 1;
                m.TypeName = typeof(T).Name;
                m.ModelType = typeof(T);
                m.ViewType = ViewType;
                m.InlineEditID = InlineEdit;

                if (m.ModelType == null)
                    throw new ArgumentException("TypeName");

                if (this.Session == null ||
                    ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, m.ModelType).View != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                if (this.Session == null ||
                    (ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, m.ModelType).ViewInactive != true &&
                    ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)))
                    {
                    return new HttpUnauthorizedResult();
                    }

                m.FieldSearchTerms = this.Helper_T.ExtractSearchTerms(ref FieldSearchTerms, m.ModelType);
                m.GlobalSearchTerm = GlobalSearchTerm;

                if (string.IsNullOrEmpty(SortTerm))
                    {
                    this.SetDefaultSort(m);
                    }
                else
                    {
                    m.OverrideSort = SortTerm;
                    m.OverrideSortDirection = SortDirection;
                    }

                int TotalItems;

                m.Models = this.Helper_T.GetModels(out TotalItems,
                    Page, this.RowsPerPage,
                    m.OverrideSort, m.OverrideSortDirection,
                    m.GlobalSearchTerm, m.FieldSearchTerms,
                    m.ViewType);

                m.TotalItems = TotalItems;
                m.TotalPages = (int)Math.Ceiling(TotalItems / (double)this.RowsPerPage);
                }
            catch (Exception e)
                {
                this.ModelState.AddModelError(string.Empty,
                    this.Session.IsAdmin() ? $"An error has occured - {e}" :
                    "An unexpected error has occured");
                }

            return this.View(m);
            }
        #endregion

        #region Search
        [Route("Search/{TypeName}")]
        [HttpPost]
        public override ActionResult Search(
            int Page = 1,
            string SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.Normal)
            {
            var m = new ManageViewModel(this);

            try
                {
                m.Page = Page - 1;
                m.TypeName = typeof(T).Name;
                m.ModelType = typeof(T);
                m.ViewType = ViewType;

                GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
                FieldSearchTerms = (FieldSearchTerms ?? "").Trim();

                if (!string.IsNullOrEmpty(FieldSearchTerms) &&
                    !string.IsNullOrEmpty(GlobalSearchTerm))
                    {
                    GlobalSearchTerm = $"{FieldSearchTerms}|{GlobalSearchTerm}";
                    }

                m.FieldSearchTerms = this.Helper_T.ExtractSearchTerms(ref GlobalSearchTerm, m.ModelType);
                m.GlobalSearchTerm = GlobalSearchTerm;

                return this.RedirectToAction(nameof(ManageController.Manage), this.Name, new
                    {
                    m.TypeName,
                    Page = m.Page + 1,
                    SortDirection,
                    SortTerm,
                    GlobalSearchTerm,
                    FieldSearchTerms = m.GetGlobalSearchCombined("Global"),
                    m.ViewType
                    });
                }
            catch (Exception e)
                {
                this.ModelState.AddModelError(string.Empty,
                    this.Session.IsAdmin() ? $"An error has occured - {e}" : "An unexpected error has occured");
                }

            return this.RedirectToAction(nameof(ManageController.Manage), this.Name, new
                {
                m.TypeName
                });
            }
        #endregion

        #region Export
        public override void Export(
            int Page = 1,
            string SortTerm = null,
            SortDirection SortDirection = SortDirection.Ascending,
            string GlobalSearchTerm = null,
            string FieldSearchTerms = null,
            ControllerHelper.ManageViewType ViewType = ControllerHelper.ManageViewType.All,
            int CustomExportID = -1)
            {
            GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
            FieldSearchTerms = (FieldSearchTerms ?? "").Trim();


            var m = new ManageViewModel(this)
                {
                Page = Page - 1,
                TypeName = typeof(T).Name,
                ModelType = typeof(T),
                ViewType = ViewType
                };

            if (m.ModelType == null)
                throw new ArgumentException("TypeName");

            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, m.ModelType).Export != true)
                {
                return;
                }

            if (this.Session == null ||
                (ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, m.ModelType).ViewInactive != true &&
                m.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)))
                {
                return;
                }

            if (string.IsNullOrEmpty(SortTerm))
                {
                this.SetDefaultSort(m);
                }
            else
                {
                m.OverrideSort = SortTerm;
                m.OverrideSortDirection = SortDirection;
                }

            m.FieldSearchTerms = this.Helper_T.ExtractSearchTerms(ref FieldSearchTerms, m.ModelType);
            m.GlobalSearchTerm = GlobalSearchTerm;

            int TotalItems;

            var ColumnNames = new List<string>();

            //List<MemberInfo> Members = new List<MemberInfo>();
            //List<Delegate> Accessors = new List<Delegate>();
            var Functions = new List<Func<object, object>>();

            string FileName = $"{m.ModelType.Name}-{DateTime.Now.ToString().ReplaceAll("/", "-").ReplaceAll("\\", "-").ReplaceAll(":", "-")}";

            var Columns = new List<ModelMetadata>();

            if (CustomExportID >= 0)
                {
                var Export = CustomExport.Find(this.DBContext, CustomExportID);

                if (!string.IsNullOrEmpty(Export.OverrideSort))
                    {
                    m.OverrideSort = Export.OverrideSort;
                    m.OverrideSortDirection = SortDirection.Ascending;

                    if (Export.OverrideSortDirection == SortDirection.Descending)
                        m.OverrideSortDirection = SortDirection.Descending;
                    }

                ColumnNames.AddRange(Export.Fields.Lines());

                Dictionary<string, ModelMetadata> AllMeta = m.ModelType.GetMeta();

                ColumnNames = ColumnNames.Select(c => AllMeta.Keys.Has(c));

                ColumnNames.Each(c =>
                {
                    var Meta = AllMeta[c];

                    if (c.Contains("."))
                        {
                        if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                            {
                            var Lambda = m.ModelType.GetTokenExpression(c, out Meta);

                            Func<object, object> F = ((Expression<Func<object, object>>)Lambda).Compile();

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
                foreach (var Meta in m.ModelType.Meta().Properties)
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
                    foreach (var Op in m.FieldSearchTerms.Values)
                        {
                        if (Op.Property.Contains("."))
                            {
                            ModelMetadata Meta;
                            string[] FullProperty;

                            var Lambda = m.ModelType.FindSubProperty(out Meta, out FullProperty, Op.Property.Split("."));

                            if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                                {
                                var Param = Lambda.Parameters[0];
                                Expression AsObject = Expression.TypeAs(Lambda.Body, typeof(object));
                                var Lambda2 = Expression.Lambda(AsObject, Param);

                                var Param2 = Expression.Parameter(typeof(object), "b");
                                Expression AsT = Expression.TypeAs(Param2, m.ModelType);

                                var Invoke = Expression.Invoke(Lambda2, AsT);
                                var Lambda3 = Expression.Lambda(Invoke, Param2);

                                //                        if (Lambda2.CanReduce)
                                //                            Lambda2 = Lambda2.Reduce();

                                Func<object, object> F = ((Expression<Func<object, object>>)Lambda3).Compile();

                                Columns.Add(Meta);
                                ColumnNames.Add(FullProperty.JoinLines(" "));
                                // Members.Add(Meta.GetMember());
                                //  Accessors.Add(Meta.GetDelegate());
                                Functions.Add(F);
                                }
                            }
                        else if (!Columns.Has(c => (c.DisplayName ?? c.PropertyName) == Op.Property))
                            {
                            var Meta = m.ModelType.Meta(Op.Property);

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

            IEnumerable<T> Models = this.Helper_T.GetModels_T(out TotalItems,
                Page,
                -1, // All records
                m.OverrideSort,
                m.OverrideSortDirection,
                m.GlobalSearchTerm,
                m.FieldSearchTerms,
                m.ViewType);

            var sw = new StringWriter();

            // CSV Column Headers
            for (int i = 0; i < ColumnNames.Count; i++)
                {
                sw.Write($"\"{ColumnNames[i]}\"");

                if (i < ColumnNames.Count - 1)
                    sw.Write(",");
                }

            sw.Write("\r\n");

            // CSV Body
            foreach (var Model in Models)
                {
                for (int i = 0; i < Functions.Count; i++)
                    {
                    var Obj = Functions[i](Model);

                    if ((Obj as DateTime?)?.Ticks == ((DateTime)Obj).Date.Ticks)
                        {
                        Obj = ((DateTime)Obj).ToShortDateString();
                        }

                    sw.Write($"\"{Obj.ToString().ReplaceAll("\"", "'")}\"");
                    //sw.Write($"\"{(((delegate )(Accessors[i]))(Model) ?? "").ToString()}\"");
                    //sw.Write($"\"{(Members[i].GetValue(Model) ?? "").ToString()}\"");
                    if (i < Columns.Count - 1)
                        sw.Write(",");
                    }
                sw.Write("\r\n");
                }

            this.Response.WriteCSV(sw, FileName);
            }
        #endregion

        #region Details
        public override ActionResult Details(int id, string ReturnURL)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).View != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = this.GetModelQuery().Find(id);

            if (!this.Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            this.ViewBag.ReturnURL = ReturnURL;
            this.ViewBag.ManageController = this;

            return this.View(Model);
            }
        #endregion

        #region Edit
        public override ActionResult Edit(int id, string ReturnURL, bool Create = false)
            {

            if (Create)
                {
                if (this.Session == null ||
                     ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).Create != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                IModel Model = this.GetModel(0, true, null);

                return this.Edit(Model, ReturnURL, true);
                }
            else
                {
                if (this.Session == null ||
                     ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).Edit != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                IModel Model = this.GetModelQuery().Find(id);

                return !this.Session.CurrentRole().AllowAccess(Model) ? new HttpUnauthorizedResult() : this.Edit(Model, ReturnURL);
                }
            }

        protected virtual ActionResult Edit(IModel Model, string ReturnURL, bool Create = false)
            {
            this.ViewBag.ReturnURL = ReturnURL;

            this.ViewBag.ControllerName = this.Name;

            this.ViewBag.AllowAdminRandomize = this.AllowAdminRandomize;

            this.ViewBag.Route_Edit = new
                {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL,
                Create
                };
            this.ViewBag.Route_Update = new
                {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL,
                Create
                };

            this.ViewBag.EditModel = Model;

            this.ViewBag.Create = !Model.HasID();

            this.ViewBag.Title = $"{(this.ViewBag.Create ? "Create" : "Edit")} {Model.GetFriendlyTypeName()}: {Model}";

            return this.View(Model);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public override ActionResult Edit(int id, string ReturnURL, FormCollection Form, bool Create = false)
            {
            bool UpdateMode = !string.IsNullOrEmpty(Form["UpdateButton"]);

            if (this.Session == null ||
                 ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).Edit != true)
                {
                return new HttpUnauthorizedResult();
                }

            this.ViewBag.ControllerName = this.Name;

            var Model = this.GetModel(id, Create, null);

            bool Errors;

            Errors = this.ModelBindingBefore(Form, this.DBContext, Model);

            Form.Keys.List<string>().Each(Key =>
            {
                Errors = Errors || this.SetModelField(Form, Model, Key);
            });

            Errors = Errors || this.ModelBindingAfter(Form, this.DBContext, Model, Errors);

            if (!Errors)
                {
                try
                    {
                    if (Create)
                        {
                        // Attach related models so they don't get duplicated
                        foreach (var Meta in Model.Properties())
                            {
                            if (Meta.ModelType.HasInterface<IModel>())
                                {
                                var Set = this.DBContext.GetDBSet(Meta.ModelType);

                                Set?.Attach(Model.GetProperty(Meta.PropertyName));
                                }
                            }

                        this.DBContext.GetDBSet<T>().Add(Model);
                        }

                    if (UpdateMode)
                        {
                        bool Before = this.DBContext.Configuration.ValidateOnSaveEnabled;
                        this.DBContext.Configuration.ValidateOnSaveEnabled = false;

                        this.DBContext.SaveChanges();

                        this.DBContext.Configuration.ValidateOnSaveEnabled = Before;
                        }
                    else
                        {
                        this.DBContext.SaveChanges();
                        }
                    }
                catch (Exception e)
                    {
                    Errors = true;

                    string Message = "An error occurred while saving data";

                    if (ContextProviderFactory.GetCurrent().CurrentUser(this.Session).IsAdmin)
                        {
                        Message += $" - {e.Message} {e}";
                        }

                    this.ModelState.AddModelError("", Message);
                    }
                }

            if (!Errors)
                {
                this.AddStatusMessage($"Successfully {(Create ? "Created" : "Updated")} - {Model.GetFriendlyTypeName()}");

                if (!UpdateMode)
                    {
                    if (Create && this.ActionAfterCreate == ControllerHelper.ViewType.Edit)
                        {
                        return this.RedirectToAction(nameof(ManageController.Edit),
                            Routes.Controllers.Manage.Actions.Route_Edit(Model, ReturnURL));
                        }
                    if (Create && this.ActionAfterCreate == ControllerHelper.ViewType.Display)
                        {
                        return this.RedirectToAction(nameof(ManageController.Details),
                            Routes.Controllers.Manage.Actions.Route_DetailView(Model, ReturnURL));
                        }
                    return this.Redirect(ReturnURL);
                    }
                }

            return this.Edit(Model, ReturnURL, Create);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public override ActionResult Update(int id, string ReturnURL, FormCollection Form, bool Create = false)
            {
            this.Edit(id, ReturnURL, Form, Create);

            return this.RedirectToAction(nameof(ManageController.Edit), new
                {
                id,
                ReturnURL,
                Create
                });
            }
        #endregion

        #region Create
        public override ActionResult Create(string ReturnURL)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).Create != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = this.GetModel(0, true, null);

            return this.Edit(Model, ReturnURL, true);
            }

        [HttpPost]
        public override ActionResult Create(string ReturnURL, FormCollection Form)
            {
            return this.Edit(0, ReturnURL, Form, true);
            }
        #endregion

        #region Delete
        public override ActionResult Delete(int id, string ReturnURL)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = this.GetModelQuery().Find(id);

            if (!this.Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            this.ViewBag.ReturnURL = ReturnURL;

            return this.View(Model);
            }

        [IgnoreValidation]
        public override ActionResult DeleteConfirm(int id, string ReturnURL, FormCollection collection, bool Restore = false)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T)).Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

            DbSet DBSet = this.GetModelQuery();

            var Model = (T)DBSet.Find(id);

            if (!this.Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            bool Before = this.DBContext.Configuration.ValidateOnSaveEnabled;

            this.DBContext.Configuration.ValidateOnSaveEnabled = false;

            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active))
                {
                bool Val = Restore;

                if (Model.Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(bool?))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, (bool?)Val);
                else
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, Val);

                foreach (var Value in this.ModelState.Values)
                    {
                    Value.Errors.Clear();
                    }

                this.DBContext.SaveChanges();
                }
            else
                {
                DBSet.Remove(Model);
                this.DBContext.SaveChanges();
                }

            this.DBContext.Configuration.ValidateOnSaveEnabled = Before;

            return this.Redirect(ReturnURL);
            }
        #endregion

        #region UploadFile
        [HttpPost]
        public override ActionResult UploadFile(
            FormCollection Form,
            string ReturnURL,
            string RelationType,
            string RelationProperty,
            int RelationID)
            {
            List<HttpPostedFileBase> UploadFiles = (from string name in this.Request.Files where name == $"UploadFile{RelationProperty}" select this.Request.Files[name] into file where file != null && file.ContentLength > 0 select file).ToList();

            if (UploadFiles.Count == 1)
                {
                var Result = this.UploadSingleFile(Form, RelationType, RelationProperty, RelationID, UploadFiles[0]);

                this.DBContext.SaveChanges();

                if (Result != null)
                    return Result;
                }
            else if (!UploadFiles.IsEmpty())
                {
                foreach (var File in UploadFiles)
                    {
                    this.UploadSingleFile(Form, RelationType, RelationProperty, RelationID, File);
                    }

                this.DBContext.SaveChanges();
                }

            return this.Redirect(ReturnURL);
            }

        protected virtual ActionResult UploadSingleFile(FormCollection Form, string RelationType, string RelationProperty, int RelationID, HttpPostedFileBase File)
            {
            var FileUp = this.GetFileUpload(File, Form, RelationType, RelationProperty, RelationID);

            this.DBContext.GetDBSet<FileUpload>().Add(FileUp);

            return null;
            }

        // ReSharper disable once UnusedParameter.Global
        protected virtual FileUpload GetFileUpload(HttpPostedFileBase UploadFile, FormCollection Form, string RelationType, string RelationProperty, int RelationID)
            {
            var Provider = ContextProviderFactory.GetCurrent();
            string RootPath = Provider.GetFileUploadRootPath(this.Session, UploadFile, RelationType, RelationProperty, RelationID);
            string FilePath = Provider.GetFileUploadFilePath(this.Session, UploadFile, RelationType, RelationProperty, RelationID);

            string FullPath = L.File.CombinePaths(RootPath, FilePath);

            if (FullPath != null && !Directory.Exists(Path.GetDirectoryName(FullPath)))
                {
                Directory.CreateDirectory(Path.GetDirectoryName(FullPath));
                }

            var FileUp = new FileUpload(UploadFile, Provider.GetFileUploadCloudContainer(), FilePath)
                {
                RelationType = RelationType,
                RelationProperty = RelationProperty,
                RelationID = RelationID
                };


            return FileUp;
            }
        #endregion

        #region DownloadFile
        public override void DownloadFile(int FileID)
            {
            var FileUp = FileUpload.FindFileUpload(this.DBContext, FileID, typeof(T));

            if (!this.Session.CurrentRole().AllowAccess(FileUp))
                {
                throw new ArgumentException("FileID");
                }

            if (FileUp == null)
                {
                throw new ArgumentException("FileID");
                }

            byte[] FileBytes = FileUp.GetCloudBytes();

            this.Response.Clear();
            this.Response.AddHeader("Content-Disposition", $"attachment; filename={FileUp.FilePath}");
            this.Response.AddHeader("Content-Length", FileBytes.Length.ToString());

            //Response.ContentType = "application/binary";
            this.Response.BinaryWrite(FileBytes);
            this.Response.End();
            }
        #endregion}

        #region DeleteFile
        public override void DeleteFile(int id, string ReturnURL)
            {
            var File = FileUpload.FindFileUpload(this.DBContext, id, typeof(T));

            if (!this.Session.CurrentRole().AllowAccess(File))
                {
                throw new ArgumentException("FileID");
                }

            if (File == null)
                {
                throw new ArgumentException("FileID");
                }

            File.Active = false;
            this.DBContext.SaveChanges();

            this.Response.Redirect(ReturnURL);
            }
        #endregion

        private void SetDefaultSort(ManageViewModel ManageModel)
            {
            var attr = ManageModel.ModelType.GetAttribute<DisplayColumnAttribute>(false);

            if (!string.IsNullOrEmpty(attr?.SortColumn))
                {
                ManageModel.OverrideSort = attr.SortColumn;
                ManageModel.OverrideSortDirection = attr.SortDescending ? SortDirection.Descending : SortDirection.Ascending;
                }
            }

        public override bool AllowAdminRandomize => false;

        protected virtual T GetModel(int id, bool Create, T Model)
            {
            if (Create)
                {
                Model = typeof(T).New<T>();

                Model.Initialize();
                }
            else
                {
                Model = this.GetModelQuery().Find(id);

                if (Model.HasProperty(ControllerHelper.AutomaticFields.Updated))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Updated, DateTime.Now);
                }

            // Load fields from query string
            List<ModelMetadata> MetaData = Model.Properties().List();

            MetaData.Each(m =>
            {
                if (m.HasAttribute<IFieldLoadFromQueryStringAttribute>())
                    {
                    if (StringConverter.IsTypeSupported(m))
                        {
                        string QS = this.Request.QueryString[m.PropertyName];

                        if (!string.IsNullOrEmpty(QS))
                            {
                            var Converter = new StringConverter(this.Session);

                            var Value = Converter.PerformAction(QS, m.ModelType);

                            Model.SetProperty(m.PropertyName, Value);
                            }
                        }
                    else if (m.ModelType.HasInterface<IConvertible>())
                        {
                        }
                    else if (m.ModelType.HasInterface<IModel>())
                        {
                        string QS = this.Request.QueryString[m.PropertyName];

                        var Context = this.DBContext.GetDBSet(m.ModelType);
                        var QSModel = (IModel)Context.Find(QS);

                        if (QSModel != null)
                            {
                            Model.SetProperty(m.PropertyName, QSModel);
                            }
                        }
                    }
            });

            return Model;
            }

        // ReSharper disable UnusedParameter.Global
        protected virtual bool ModelBindingBefore(FormCollection Form, ModelContext Context, T Model)
        // ReSharper restore UnusedParameter.Global
            {
            return false;
            }

        // ReSharper disable UnusedParameter.Global
        protected virtual bool ModelBindingAfter(FormCollection Form, ModelContext Context, T Model, bool Errors)
        // ReSharper restore UnusedParameter.Global
            {
            return false;
            }

        protected virtual bool SetModelField(FormCollection Form, T Model, string Key)
            {
            bool Errors = false;

            try
                {
                IEnumerable<ModelMetadata> CustomKeyMeta = Model.Properties().Where(
                    pr => pr.HasAttribute<FieldFormKeyAttribute>() &&
                        pr.GetAttribute<FieldFormKeyAttribute>().CustomKey == Key);

                string Property = Key;

                IEnumerable<ModelMetadata> customKeyMeta = CustomKeyMeta as ModelMetadata[] ?? CustomKeyMeta.ToArray();
                if (customKeyMeta.Count() == 1)
                    {
                    Property = customKeyMeta.FirstOrDefault()?.PropertyName;
                    }

                string Value = Form[Key];

                if (!Model.TrueModelType().HasProperty(Property))
                    return false;

                var Meta = Model.Meta(Property);

                // Fix for Boolean Checkbox fields from HtmlHelper
                if (Value == "true,false" &&
                    (Meta.ModelType == typeof(bool) ||
                    Meta.ModelType == typeof(bool?)))
                    {
                    Value = "true";
                    }

                if (Meta.HasAttribute<KeyAttribute>(true))
                    return false;

                if (Meta.HasAttribute<ISetFormField>())
                    return Meta.GetAttribute<ISetFormField>().SetFormField(Form, Model, Meta, Value);

                var Convert = new StringConverter(this.Session);

                // LambdaExpression Lambda = Meta.GetExpression();

                var p = Model.TrueModelType().GetProperty(Property);

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

                var Obj = Convert.PerformAction(Value, Meta.ModelType);


                p?.SetValue(Model, Obj);

                if (!this.ModelState.IsValidField(Key))
                    {
                    throw new ValidationException(this.ModelState[Key].Errors.List().CollectStr((i, e) => e.ErrorMessage));
                    }
                }
            catch (ValidationException e)
                {
                this.ModelState.AddModelError(Key, e.Message);
                }
            catch (Exception e)
                {
                Errors = true;

                string Message = "An error occurred while saving this field";

                var UserProfile = ContextProviderFactory.GetCurrent().CurrentUser(this.Session);

                if (UserProfile?.IsAdmin == true)
                    {
                    Message += $" - {e.Message}";
                    }

                this.ModelState.AddModelError(Key, Message);
                }

            return Errors;
            }

        public override bool ArchiveActive => this.GetArchivedCondition(true) != null;

        // ReSharper disable once MemberCanBeProtected.Global
        public virtual TimeSpan ArchiveTimeSpan => ControllerHelper.DefaultArchiveTimeSpan;

        public virtual Expression<Func<T, bool>> GetArchivedCondition(bool Archived)
            {
            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Archived) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Archived).ModelType == typeof(bool))
                {
                Expression<Func<T, bool>> Exp = typeof(T).GetExpression<T, bool>(ControllerHelper.AutomaticFields.Active);
                Expression Equal = Archived ?
                    Expression.Equal(Exp.Body, Expression.Constant(true)) :
                    Expression.Equal(Exp.Body, Expression.Constant(false));
                Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                return (Expression<Func<T, bool>>)Lambda;
                }
            if (this.ArchiveTimeSpan != default(TimeSpan) &&
                typeof(T).HasProperty(ControllerHelper.AutomaticFields.Created) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Created).ModelType == typeof(DateTime))
                {
                var Cutoff = DateTime.Now.Subtract(this.ArchiveTimeSpan);

                Expression<Func<T, DateTime>> Exp = typeof(T).GetExpression<T, DateTime>(ControllerHelper.AutomaticFields.Created);
                Expression LessThan = Archived ?
                    Expression.LessThan(Exp.Body, Expression.Constant(Cutoff)) :
                    Expression.GreaterThanOrEqual(Exp.Body, Expression.Constant(Cutoff));

                Expression Lambda = Expression.Lambda(LessThan, Exp.Parameters[0]);

                return (Expression<Func<T, bool>>)Lambda;
                }
            return null;
            }

        [NonAction]
        public override int GetTotalCount()
            {
            Func<int> Count = () =>
            {
                IQueryable<T> Set = this.GetModelQuery();

                Set = this.RestrictScope(Set);

                Set = QueryExt.FilterSet_Active(Set);

                return Set.Count();
            };

            return Count.Cache($"{this.GetType().FullName}TotalCountCache")();
            }

        [NonAction]
        public virtual DbSet<T> GetModelQuery()
            {
            return this.DBContext.GetDBSet<T>();
            }

        [NonAction]
        public virtual IQueryable<T> RestrictScope(IQueryable<T> Query)
            {
            return Query;
            }


        public override ControllerHelper Helper => this.Helper_T;
        public ControllerHelper<T> Helper_T { get; }

        protected ManageController(IAuthenticationService Auth) : base(Auth)
            {

            this.Helper_T = new ControllerHelper<T>(this);
            }
        }
    }
