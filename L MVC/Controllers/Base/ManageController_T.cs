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
using LMVC.Models;
using LMVC.Context;
using LMVC.Extensions;
using System.Web.Helpers;
using JetBrains.Annotations;
using LMVC.Account;
using LMVC.Annotations;
using LMVC.Utilities;
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LMVC.Controllers
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
            var ViewModel = new ManageViewModel(this);

            var DefaultSearch = SavedSearch.FindDefault(this.DbContext, this.ModelType.FullName, this.Name, true);

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

                ViewModel.Page = Page - 1;
                ViewModel.TypeName = typeof(T).Name;
                ViewModel.ModelType = typeof(T);
                ViewModel.ViewType = ViewType;
                ViewModel.InlineEditID = InlineEdit;

                if (ViewModel.ModelType == null)
                    throw new ArgumentException("TypeName");

                if (this.Session == null ||
                    ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, ViewModel.ModelType)?.View != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                if (this.Session == null ||
                    (ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, ViewModel.ModelType)?.ViewInactive != true &&
                    ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)))
                    {
                    return new HttpUnauthorizedResult();
                    }

                ViewModel.FieldSearchTerms = this.HelperT.ExtractSearchTerms(ref FieldSearchTerms, ViewModel.ModelType);
                ViewModel.GlobalSearchTerm = GlobalSearchTerm;

                if (string.IsNullOrEmpty(SortTerm))
                    {
                    this.SetDefaultSort(ViewModel);
                    }
                else
                    {
                    ViewModel.OverrideSort = SortTerm;
                    ViewModel.OverrideSortDirection = SortDirection;
                    }

                int TotalItems;

                ViewModel.Models = this.HelperT.GetModels(out TotalItems,
                    Page, this.RowsPerPage,
                    ViewModel.OverrideSort, ViewModel.OverrideSortDirection,
                    ViewModel.GlobalSearchTerm, ViewModel.FieldSearchTerms,
                    ViewModel.ViewType);

                ViewModel.TotalItems = TotalItems;
                ViewModel.TotalPages = (int)Math.Ceiling(TotalItems / (double)this.RowsPerPage);
                }
            catch (Exception Ex)
                {
                this.ModelState.AddModelError(string.Empty,
                    this.Session.IsAdmin() ? $"An error has occured - {Ex}" :
                    "An unexpected error has occured");
                }

            return this.View(ViewModel);
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
            var ViewModel = new ManageViewModel(this);

            try
                {
                ViewModel.Page = Page - 1;
                ViewModel.TypeName = typeof(T).Name;
                ViewModel.ModelType = typeof(T);
                ViewModel.ViewType = ViewType;

                GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
                FieldSearchTerms = (FieldSearchTerms ?? "").Trim();

                if (!string.IsNullOrEmpty(FieldSearchTerms) &&
                    !string.IsNullOrEmpty(GlobalSearchTerm))
                    {
                    GlobalSearchTerm = $"{FieldSearchTerms}|{GlobalSearchTerm}";
                    }

                ViewModel.FieldSearchTerms = this.HelperT.ExtractSearchTerms(ref GlobalSearchTerm, ViewModel.ModelType);
                ViewModel.GlobalSearchTerm = GlobalSearchTerm;

                return this.RedirectToAction(nameof(ManageController.Manage), this.Name, new
                    {
                    ViewModel.TypeName,
                    Page = ViewModel.Page + 1,
                    SortDirection,
                    SortTerm,
                    GlobalSearchTerm,
                    FieldSearchTerms = ViewModel.GetGlobalSearchCombined("Global"),
                    ViewModel.ViewType
                    });
                }
            catch (Exception Ex)
                {
                this.ModelState.AddModelError(string.Empty,
                    this.Session.IsAdmin() ? $"An error has occured - {Ex}" : "An unexpected error has occured");
                }

            return this.RedirectToAction(nameof(ManageController.Manage), this.Name, new
                {
                ViewModel.TypeName
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


            var ViewModel = new ManageViewModel(this)
                {
                Page = Page - 1,
                TypeName = typeof(T).Name,
                ModelType = typeof(T),
                ViewType = ViewType
                };

            if (ViewModel.ModelType == null)
                throw new ArgumentException("TypeName");

            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, ViewModel.ModelType)?.Export != true)
                {
                return;
                }

            if (this.Session == null ||
                (ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, ViewModel.ModelType)?.ViewInactive != true &&
                ViewModel.ViewType.HasFlag(ControllerHelper.ManageViewType.Inactive)))
                {
                return;
                }

            if (string.IsNullOrEmpty(SortTerm))
                {
                this.SetDefaultSort(ViewModel);
                }
            else
                {
                ViewModel.OverrideSort = SortTerm;
                ViewModel.OverrideSortDirection = SortDirection;
                }

            ViewModel.FieldSearchTerms = this.HelperT.ExtractSearchTerms(ref FieldSearchTerms, ViewModel.ModelType);
            ViewModel.GlobalSearchTerm = GlobalSearchTerm;

            int TotalItems;

            var ColumnNames = new List<string>();

            //List<MemberInfo> Members = new List<MemberInfo>();
            //List<Delegate> Accessors = new List<Delegate>();
            var Functions = new List<Func<object, object>>();

            string FileName = $"{ViewModel.ModelType.Name}-{DateTime.Now.ToString().ReplaceAll("/", "-").ReplaceAll("\\", "-").ReplaceAll(":", "-")}";

            var Columns = new List<ModelMetadata>();

            if (CustomExportID >= 0)
                {
                var Export = CustomExport.Find(this.DbContext, CustomExportID);

                if (!string.IsNullOrEmpty(Export.OverrideSort))
                    {
                    ViewModel.OverrideSort = Export.OverrideSort;
                    ViewModel.OverrideSortDirection = SortDirection.Ascending;

                    if (Export.OverrideSortDirection == SortDirection.Descending)
                        ViewModel.OverrideSortDirection = SortDirection.Descending;
                    }

                ColumnNames.AddRange(Export.Fields.Lines());

                Dictionary<string, ModelMetadata> AllMeta = ViewModel.ModelType.GetMeta();

                ColumnNames = ColumnNames.Select(Col => AllMeta.Keys.Has(Col));

                ColumnNames.Each(Col =>
                {
                    var Meta = AllMeta[Col];

                    if (Col.Contains("."))
                        {
                        if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                            {
                            var Lambda = ViewModel.ModelType.GetTokenExpression(Col, out Meta);

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
                IEnumerable<ModelMetadata> ModelMetadata = ViewModel.ModelType.Meta()?.Properties;
                if (ModelMetadata != null)
                    foreach (var Meta in ModelMetadata)
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
                if (ViewModel.FieldSearchTerms != null)
                    {
                    foreach (var Op in ViewModel.FieldSearchTerms.Values)
                        {
                        if (Op.Property.Contains("."))
                            {
                            ModelMetadata Meta;
                            string[] FullProperty;

                            var Lambda = ViewModel.ModelType.FindSubProperty(out Meta, out FullProperty, Op.Property.Split("."));

                            if (!Meta.HasAttribute<FieldDisableExportAttribute>())
                                {
                                var Param = Lambda.Parameters[0];
                                Expression AsObject = Expression.TypeAs(Lambda.Body, typeof(object));
                                var Lambda2 = Expression.Lambda(AsObject, Param);

                                var Param2 = Expression.Parameter(typeof(object), "b");
                                Expression AsT = Expression.TypeAs(Param2, ViewModel.ModelType);

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
                        else if (!Columns.Has(Col => (Col.DisplayName ?? Col.PropertyName) == Op.Property))
                            {
                            var Meta = ViewModel.ModelType.Meta(Op.Property);

                            if (Meta != null && !Meta.HasAttribute<FieldDisableExportAttribute>())
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

            IEnumerable<T> Models = this.HelperT.GetModels_T(out TotalItems,
                Page,
                -1, // All records
                ViewModel.OverrideSort,
                ViewModel.OverrideSortDirection,
                ViewModel.GlobalSearchTerm,
                ViewModel.FieldSearchTerms,
                ViewModel.ViewType);

            var Writer = new StringWriter();

            // CSV Column Headers
            for (int Index = 0; Index < ColumnNames.Count; Index++)
                {
                Writer.Write($"\"{ColumnNames[Index]}\"");

                if (Index < ColumnNames.Count - 1)
                    Writer.Write(",");
                }

            Writer.Write("\r\n");

            // CSV Body
            foreach (var Model in Models)
                {
                for (int Index = 0; Index < Functions.Count; Index++)
                    {
                    var Obj = Functions[Index](Model);

                    if ((Obj as DateTime?)?.Ticks == ((DateTime)Obj).Date.Ticks)
                        {
                        Obj = ((DateTime)Obj).ToShortDateString();
                        }

                    Writer.Write($"\"{Obj.ToString().ReplaceAll("\"", "'")}\"");
                    //sw.Write($"\"{(((delegate )(Accessors[i]))(Model) ?? "").ToString()}\"");
                    //sw.Write($"\"{(Members[i].GetValue(Model) ?? "").ToString()}\"");
                    if (Index < Columns.Count - 1)
                        Writer.Write(",");
                    }
                Writer.Write("\r\n");
                }

            this.Response.WriteCSV(Writer, FileName);
            }
        #endregion

        #region Details
        public override ActionResult Details(int ID, string ReturnUrl)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.View != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = this.GetModelQuery().Find(ID);

            if (!this.Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            this.ViewBag.ReturnURL = ReturnUrl;
            this.ViewBag.ManageController = this;

            return this.View(Model);
            }
        #endregion

        #region Edit
        public override ActionResult Edit(int ID, string ReturnUrl, bool Create = false)
            {

            if (Create)
                {
                if (this.Session == null ||
                     ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.Create != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                IModel Model = this.GetModel(0, true, null);

                return this.Edit(Model, ReturnUrl, true);
                }
            else
                {
                if (this.Session == null ||
                     ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.Edit != true)
                    {
                    return new HttpUnauthorizedResult();
                    }

                IModel Model = this.GetModelQuery().Find(ID);

                return !this.Session.CurrentRole().AllowAccess(Model) ? new HttpUnauthorizedResult() : this.Edit(Model, ReturnUrl);
                }
            }

        protected virtual ActionResult Edit([CanBeNull]IModel Model, string ReturnUrl, bool Create = false)
            {
            this.ViewBag.ReturnURL = ReturnUrl;

            this.ViewBag.ControllerName = this.Name;

            this.ViewBag.AllowAdminRandomize = this.AllowAdminRandomize;

            this.ViewBag.Route_Edit = new
                {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL = ReturnUrl,
                Create
                };
            this.ViewBag.Route_Update = new
                {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL = ReturnUrl,
                Create
                };

            this.ViewBag.EditModel = Model;

            this.ViewBag.Create = !Model.HasID();

            this.ViewBag.Title = $"{(this.ViewBag.Create ? "Create" : "Edit")} {Model.GetFriendlyTypeName()}: {Model}";

            return this.View(Model);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public override ActionResult Edit(int ID, string ReturnUrl, FormCollection Form, bool Create = false)
            {
            bool UpdateMode = !string.IsNullOrEmpty(Form["UpdateButton"]);

            if (this.Session == null ||
                 ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.Edit != true)
                {
                return new HttpUnauthorizedResult();
                }

            this.ViewBag.ControllerName = this.Name;

            var Model = this.GetModel(ID, Create, null);

            bool Errors;

            Errors = this.ModelBindingBefore(Form, this.DbContext, Model);

            Form.Keys.List<string>().Each(Key =>
            {
                Errors = Errors || this.SetModelField(Form, Model, Key);
            });

            Errors = Errors || this.ModelBindingAfter(Form, this.DbContext, Model, Errors);

            if (!Errors)
                {
                try
                    {
                    if (Create)
                        {
                        // Attach related models so they don't get duplicated
                        IEnumerable<ModelMetadata> Properties = Model.Properties() ?? new List<ModelMetadata>();

                        foreach (var Meta in Properties)
                            {
                            if (Meta.ModelType.HasInterface<IModel>())
                                {
                                var Set = this.DbContext.GetDBSet(Meta.ModelType);

                                Set?.Attach(Model.GetProperty(Meta.PropertyName));
                                }
                            }

                        this.DbContext.GetDBSet<T>()?.Add(Model);
                        }

                    if (UpdateMode)
                        {
                        bool Before = this.DbContext.Configuration.ValidateOnSaveEnabled;
                        this.DbContext.Configuration.ValidateOnSaveEnabled = false;

                        this.DbContext.SaveChanges();

                        this.DbContext.Configuration.ValidateOnSaveEnabled = Before;
                        }
                    else
                        {
                        this.DbContext.SaveChanges();
                        }
                    }
                catch (Exception Ex)
                    {
                    Errors = true;

                    string Message = "An error occurred while saving data";

                    if (ContextProviderFactory.GetCurrent().CurrentUser(this.Session).IsAdmin)
                        {
                        Message += $" - {Ex.Message} {Ex}";
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
                            Routes.Controllers.Manage.Actions.Route_Edit(Model, ReturnUrl));
                        }
                    if (Create && this.ActionAfterCreate == ControllerHelper.ViewType.Display)
                        {
                        return this.RedirectToAction(nameof(ManageController.Details),
                            Routes.Controllers.Manage.Actions.Route_DetailView(Model, ReturnUrl));
                        }
                    return this.Redirect(ReturnUrl);
                    }
                }

            return this.Edit(Model, ReturnUrl, Create);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public override ActionResult Update(int ID, string ReturnUrl, FormCollection Form, bool Create = false)
            {
            this.Edit(ID, ReturnUrl, Form, Create);

            return this.RedirectToAction(nameof(ManageController.Edit), new
                {
                id = ID,
                ReturnURL = ReturnUrl,
                Create
                });
            }
        #endregion

        #region Create
        public override ActionResult Create(string ReturnUrl)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.Create != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = this.GetModel(0, true, null);

            return this.Edit(Model, ReturnUrl, true);
            }

        [HttpPost]
        public override ActionResult Create(string ReturnUrl, FormCollection Form)
            {
            return this.Edit(0, ReturnUrl, Form, true);
            }
        #endregion

        #region Delete
        public override ActionResult Delete(int ID, string ReturnUrl)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

            IModel Model = this.GetModelQuery().Find(ID);

            if (!this.Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            this.ViewBag.ReturnURL = ReturnUrl;

            return this.View(Model);
            }

        [IgnoreValidation]
        public override ActionResult DeleteConfirm(int ID, string ReturnUrl, FormCollection Collection, bool Restore = false)
            {
            if (this.Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(this.Session, typeof(T))?.Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

            DbSet DbSet = this.GetModelQuery();

            var Model = (T)DbSet.Find(ID);

            if (!this.Session.CurrentRole().AllowAccess(Model))
                {
                return new HttpUnauthorizedResult();
                }

            bool Before = this.DbContext.Configuration.ValidateOnSaveEnabled;

            this.DbContext.Configuration.ValidateOnSaveEnabled = false;

            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active))
                {
                bool Val = Restore;

                if (Model.Meta(ControllerHelper.AutomaticFields.Active)?.ModelType == typeof(bool?))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, (bool?)Val);
                else
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, Val);

                foreach (var Value in this.ModelState.Values)
                    {
                    Value.Errors.Clear();
                    }

                this.DbContext.SaveChanges();
                }
            else
                {
                DbSet.Remove(Model);
                this.DbContext.SaveChanges();
                }

            this.DbContext.Configuration.ValidateOnSaveEnabled = Before;

            return this.Redirect(ReturnUrl);
            }
        #endregion

        #region UploadFile
        [HttpPost]
        public override ActionResult UploadFile(
            FormCollection Form,
            string ReturnUrl,
            string RelationType,
            string RelationProperty,
            int RelationID)
            {
            List<HttpPostedFileBase> UploadFiles =
                (from string Name
                 in this.Request.Files
                 where Name == $"UploadFile{RelationProperty}"
                 select this.Request.Files[Name]
                 into File
                 where File != null && File.ContentLength > 0
                 select File).ToList();

            if (UploadFiles.Count == 1)
                {
                var Result = this.UploadSingleFile(Form, RelationType, RelationProperty, RelationID, UploadFiles[0]);

                this.DbContext.SaveChanges();

                if (Result != null)
                    return Result;
                }
            else if (!UploadFiles.IsEmpty())
                {
                foreach (var File in UploadFiles)
                    {
                    this.UploadSingleFile(Form, RelationType, RelationProperty, RelationID, File);
                    }

                this.DbContext.SaveChanges();
                }

            return this.Redirect(ReturnUrl);
            }

        [CanBeNull]
        protected virtual ActionResult UploadSingleFile(FormCollection Form, string RelationType, string RelationProperty, int RelationID, HttpPostedFileBase File)
            {
            var FileUp = this.GetFileUpload(File, Form, RelationType, RelationProperty, RelationID);

            this.DbContext.GetDBSet<FileUpload>()?.Add(FileUp);

            return null;
            }

        [CanBeNull]
        // ReSharper disable once UnusedParameter.Global
        protected virtual FileUpload GetFileUpload(HttpPostedFileBase UploadFile, FormCollection Form, string RelationType, string RelationProperty, int RelationID)
            {
            var Provider = ContextProviderFactory.GetCurrent();
            string RootPath = Provider.GetFileUploadRootPath(this.Session, UploadFile, RelationType, RelationProperty, RelationID);
            string FilePath = Provider.GetFileUploadFilePath(this.Session, UploadFile, RelationType, RelationProperty, RelationID);

            string FullPath = L.File.CombinePaths(RootPath, FilePath);

            if (!Directory.Exists(Path.GetDirectoryName(FullPath)))
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
            var FileUp = FileUpload.FindFileUpload(this.DbContext, FileID, typeof(T));

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
        public override void DeleteFile(int ID, string ReturnUrl)
            {
            var File = FileUpload.FindFileUpload(this.DbContext, ID, typeof(T));

            if (!this.Session.CurrentRole().AllowAccess(File))
                {
                throw new ArgumentException("FileID");
                }

            if (File == null)
                {
                throw new ArgumentException("FileID");
                }

            File.Active = false;
            this.DbContext.SaveChanges();

            this.Response.Redirect(ReturnUrl);
            }
        #endregion

        private void SetDefaultSort(ManageViewModel ManageModel)
            {
            var Attr = ManageModel.ModelType.GetAttribute<DisplayColumnAttribute>(false);

            if (!string.IsNullOrEmpty(Attr?.SortColumn))
                {
                ManageModel.OverrideSort = Attr.SortColumn;
                ManageModel.OverrideSortDirection = Attr.SortDescending ? SortDirection.Descending : SortDirection.Ascending;
                }
            }

        public override bool AllowAdminRandomize => false;

        protected virtual T GetModel(int ID, bool Create, T Model)
            {
            if (Create)
                {
                Model = typeof(T).New<T>();

                Model.Initialize();
                }
            else
                {
                Model = this.GetModelQuery().Find(ID);

                if (Model.HasProperty(ControllerHelper.AutomaticFields.Updated))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Updated, DateTime.Now);
                }

            // Load fields from query string
            List<ModelMetadata> MetaData = Model.Properties().List();

            MetaData.Each(Meta =>
            {
                if (Meta.HasAttribute<IFieldLoadFromQueryStringAttribute>())
                    {
                    if (StringConverter.IsTypeSupported(Meta))
                        {
                        string QS = this.Request.QueryString[Meta.PropertyName];

                        if (!string.IsNullOrEmpty(QS))
                            {
                            var Converter = new StringConverter(this.Session);

                            var Value = Converter.PerformAction(QS, Meta.ModelType);

                            Model.SetProperty(Meta.PropertyName, Value);
                            }
                        }
                    else if (Meta.ModelType.HasInterface<IConvertible>())
                        {
                        }
                    else if (Meta.ModelType.HasInterface<IModel>())
                        {
                        string QS = this.Request.QueryString[Meta.PropertyName];

                        var Context = this.DbContext.GetDBSet(Meta.ModelType);
                        var QSModel = (IModel)Context?.Find(QS);

                        if (QSModel != null)
                            {
                            Model.SetProperty(Meta.PropertyName, QSModel);
                            }
                        }
                    }
            });

            return Model;
            }

        // ReSharper disable UnusedParameter.Global
        protected virtual bool ModelBindingBefore(FormCollection Form, IModelContext Context, T Model)
        // ReSharper restore UnusedParameter.Global
            {
            return false;
            }

        // ReSharper disable UnusedParameter.Global
        protected virtual bool ModelBindingAfter(FormCollection Form, IModelContext Context, T Model, bool Errors)
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
                    Prop => Prop.HasAttribute<FieldFormKeyAttribute>() &&
                        Prop.GetAttribute<FieldFormKeyAttribute>()?.CustomKey == Key);

                string Property = Key;

                IEnumerable<ModelMetadata> CustomKey = CustomKeyMeta as ModelMetadata[] ?? CustomKeyMeta.ToArray();
                if (CustomKey.Count() == 1)
                    {
                    Property = CustomKey.FirstOrDefault()?.PropertyName;
                    }

                string Value = Form[Key];

                if (!Model.TrueModelType().HasProperty(Property))
                    return false;

                var Meta = Model.Meta(Property);

                // Fix for Boolean Checkbox fields from HtmlHelper
                if (Value == "true,false" &&
                    (Meta?.ModelType == typeof(bool) ||
                    Meta?.ModelType == typeof(bool?)))
                    {
                    Value = "true";
                    }

                if (Meta.HasAttribute<KeyAttribute>(true))
                    return false;

                if (Meta.HasAttribute<ISetFormField>())
                    // ReSharper disable once PossibleNullReferenceException
                    return Meta.GetAttribute<ISetFormField>().SetFormField(Form, Model, Meta, Value);

                var Convert = new StringConverter(this.Session);

                // LambdaExpression Lambda = Meta.GetExpression();

                var PropertyInfo = Model.TrueModelType().GetProperty(Property);

                if (!Meta?.IsRequired == true && (Value ?? "").Trim() == "")
                    {
                    try
                        {
                        PropertyInfo.SetValue(Model, null);
                        }
                    catch
                        {
                        }

                    return false;
                    }

                var Obj = Convert.PerformAction(Value, Meta?.ModelType);

                PropertyInfo?.SetValue(Model, Obj);

                if (!this.ModelState.IsValidField(Key))
                    {
                    throw new ValidationException(this.ModelState[Key].Errors.List().CollectStr((i, Ex) => Ex.ErrorMessage));
                    }
                }
            catch (ValidationException Ex)
                {
                this.ModelState.AddModelError(Key, Ex.Message);
                }
            catch (Exception Ex)
                {
                Errors = true;

                string Message = "An error occurred while saving this field";

                var UserProfile = ContextProviderFactory.GetCurrent().CurrentUser(this.Session);

                if (UserProfile?.IsAdmin == true)
                    {
                    Message += $" - {Ex.Message}";
                    }

                this.ModelState.AddModelError(Key, Message);
                }

            return Errors;
            }

        public override bool ArchiveActive => this.GetArchivedCondition(true) != null;

        // ReSharper disable once MemberCanBeProtected.Global
        public virtual TimeSpan ArchiveTimeSpan => SingularityControllerHelper.DefaultArchiveTimeSpan;
        [CanBeNull]
        public virtual Expression<Func<T, bool>> GetArchivedCondition(bool Archived)
            {
            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Archived) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Archived)?.ModelType == typeof(bool))
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
                typeof(T).Meta(ControllerHelper.AutomaticFields.Created)?.ModelType == typeof(DateTime))
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
            return this.DbContext.GetDBSet<T>();
            }

        [NonAction]
        public virtual IQueryable<T> RestrictScope(IQueryable<T> Query)
            {
            return Query;
            }


        public override SingularityControllerHelper Helper => this.HelperT;
        public SingularityControllerHelper<T> HelperT { get; }

        protected ManageController(IAuthenticationService Auth) : base(Auth)
            {

            this.HelperT = new SingularityControllerHelper<T>(this);
            }
        }
    }
