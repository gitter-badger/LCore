using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Singularity.Models;
using Singularity.Context;
using System.Web.Mvc;
using System.Web.Routing;
using Singularity.Filters;

namespace Singularity.Controllers
    {
    [Authorize]
    [ErrorFilter]
    public abstract class ManageController : Controller
        {
        public const String DefaultManageActionName = "Manage";
        public const String DefaultEditActionName = "Edit";
        public const String DefaultDetailViewActionName = "Details";
        public const String DefaultDeleteActionName = "Delete";
        public const String DefaultConfirmActionName = "DeleteConfirm";
        public const String DefaultCreateActionName = "Create";
        public const String DefaultDeleteFileActionName = "DeleteFile";

        public const int DefaultTableTextLength = 50;

        public const Boolean GlobalSearchAssumeStars = false;

        public const int DefaultRowsPerPage = 20;

        public abstract Type ModelType { get; }


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
                return this.ModelType.GetFriendlyTypeName().Pluralize();
                }
            }

        public virtual String ManageTitle
            {
            get
                {
                return null;
                }
            }

        public virtual String ManageActionName
            {
            get
                {
                return DefaultManageActionName;
                }
            }

        public virtual String DetailViewActionName
            {
            get
                {
                return DefaultDetailViewActionName;
                }
            }

        public virtual String EditActionName
            {
            get
                {
                return DefaultEditActionName;
                }
            }

        public virtual String DeleteActionName
            {
            get
                {
                return DefaultDeleteActionName;
                }
            }
        public virtual String DeleteConfirmActionName
            {
            get
                {
                return DefaultConfirmActionName;
                }
            }

        public virtual String DeleteFileActionName
            {
            get
                {
                return DefaultDeleteFileActionName;
                }
            }

        public virtual String CreateActionName
            {
            get
                {
                return DefaultCreateActionName;
                }
            }


        public virtual int RowsPerPage
            {
            get
                {
                return DefaultRowsPerPage;
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
        }

    public abstract class ReadOnlyManageController<T> : ManageController<T>
        where T : class, IModel
        {
        public override ModelPermissions OverridePermissions
            {
            get
                {
                return new ModelPermissions()
                {
                    View = true,
                    ViewInactive = true,
                    Export = true,
                };
                }
            }
        }
    public abstract class ManageController<T> : ManageController
        where T : class, IModel
        {
        public override Type ModelType
            {
            get { return typeof(T); }
            }

        #region Manage
        public virtual ActionResult Manage(
            int Page = 1,
            String SortTerm = null,
            String SortDirection = "ASC",
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            Boolean ShowInactiveRecords = false,
            String InlineEdit = null)
            {
            ManageViewModel m = new ManageViewModel(this);

            try
                {
                if (SortDirection != "ASC" && SortDirection != "DESC")
                    throw new ArgumentException("Invalid SortType");

                GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
                FieldSearchTerms = (FieldSearchTerms ?? "").Trim();

                m.Page = (Page - 1);
                m.TypeName = typeof(T).Name;
                m.ModelType = typeof(T);
                m.ShowInactiveRecords = ShowInactiveRecords;
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
                    ShowInactiveRecords))
                    {
                    return new HttpUnauthorizedResult();
                    }

                m.FieldSearchTerms = ExtractSearchTerms(ref FieldSearchTerms, m.ModelType);
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

                m.Models = ListExt.List<IModel>(
                    GetModels(out TotalItems, Page, m.OverrideSort, m.OverrideSortDirection, m.GlobalSearchTerm, m.FieldSearchTerms, m.ShowInactiveRecords, false));

                m.TotalItems = TotalItems;
                m.TotalPages = (int)Math.Ceiling((double)TotalItems / (double)RowsPerPage);
                }
            catch (Exception e)
                {
                throw new Exception("", e);
                ModelState.AddModelError(string.Empty, "An unexpected error has occured");
                }

            return View(m);
            }
        #endregion

        #region Search
        [Route("Search/{TypeName}")]
        [HttpPost]
        public virtual ActionResult Search(
            int Page = 1,
            String SortTerm = null,
            String SortDirection = "ASC",
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            Boolean ShowInactiveRecords = false)
            {
            ManageViewModel m = new ManageViewModel(this);

            try
                {
                m.Page = (Page - 1);
                m.TypeName = typeof(T).Name;
                m.ModelType = typeof(T);
                m.ShowInactiveRecords = ShowInactiveRecords;

                GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
                FieldSearchTerms = (FieldSearchTerms ?? "").Trim();

                if (!String.IsNullOrEmpty(FieldSearchTerms) &&
                    !String.IsNullOrEmpty(GlobalSearchTerm))
                    {
                    GlobalSearchTerm = FieldSearchTerms + "|" + GlobalSearchTerm;
                    FieldSearchTerms = "";
                    }

                m.FieldSearchTerms = ExtractSearchTerms(ref GlobalSearchTerm, m.ModelType);
                m.GlobalSearchTerm = GlobalSearchTerm;

                return RedirectToAction(this.ManageActionName, this.Name, new
                {
                    TypeName = m.TypeName,
                    Page = m.Page + 1,
                    SortDirection = SortDirection,
                    SortTerm = SortTerm,
                    GlobalSearchTerm = GlobalSearchTerm,
                    FieldSearchTerms = m.GetGlobalSearchCombined("Global"),
                    ShowInactiveRecords = m.ShowInactiveRecords,
                });
                }
            catch (Exception e)
                {
                ModelState.AddModelError(string.Empty, "An unexpected error has occured");
                }

            return RedirectToAction(this.ManageActionName, this.Name, new
            {
                TypeName = m.TypeName
            });
            }
        #endregion

        #region Export
        public virtual void Export(
            int Page = 1,
            String SortTerm = null,
            String SortDirection = "ASC",
            String GlobalSearchTerm = null,
            String FieldSearchTerms = null,
            Boolean ShowInactiveRecords = false)
            {
            if (SortDirection != "ASC" && SortDirection != "DESC")
                throw new ArgumentException("Invalid SortType");

            GlobalSearchTerm = (GlobalSearchTerm ?? "").Trim();
            FieldSearchTerms = (FieldSearchTerms ?? "").Trim();


            ManageViewModel m = new ManageViewModel(this);
            m.Page = (Page - 1);
            m.TypeName = typeof(T).Name;
            m.ModelType = typeof(T);
            m.ShowInactiveRecords = ShowInactiveRecords;

            if (m.ModelType == null)
                throw new ArgumentException("TypeName");

            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, m.ModelType).Export != true)
                {
                return;
                }

            if (Session == null ||
                (ContextProviderFactory.GetCurrent().GetModelPermissions(Session, m.ModelType).ViewInactive != true &&
                ShowInactiveRecords))
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

            m.FieldSearchTerms = ExtractSearchTerms(ref FieldSearchTerms, m.ModelType);
            m.GlobalSearchTerm = GlobalSearchTerm;

            int TotalItems = 0;

            IEnumerable<T> Models = GetModels(out TotalItems, Page, m.OverrideSort, m.OverrideSortDirection, m.GlobalSearchTerm, m.FieldSearchTerms, m.ShowInactiveRecords, true);

            String FileName = m.ModelType.Name + "-" + DateTime.Now.ToString().ReplaceAll("/", "-").ReplaceAll("\\", "-").ReplaceAll(":", "-");

            List<System.Web.ModelBinding.ModelMetadata> Columns = new List<System.Web.ModelBinding.ModelMetadata>();
            List<String> ColumnNames = new List<String>();
            //List<MemberInfo> Members = new List<MemberInfo>();
            //List<Delegate> Accessors = new List<Delegate>();
            List<Func<Object, Object>> Functions = new List<Func<Object, Object>>();

            foreach (System.Web.ModelBinding.ModelMetadata Meta in m.ModelType.Meta().Properties)
                {
                if (!Meta.HasAttribute<ExportDisabledAttribute>())
                    {
                    Columns.Add(Meta);
                    ColumnNames.Add(Meta.DisplayName ?? Meta.PropertyName);
                    // Members.Add(Meta.GetMember());
                    //  Accessors.Add(Meta.GetDelegate());
                    Functions.Add(Meta.GetFunc());
                    }
                }

            if (m.FieldSearchTerms != null)
                {
                foreach (SearchOperation Op in m.FieldSearchTerms.Values)
                    {
                    if (Op.Property.Contains("."))
                        {
                        System.Web.ModelBinding.ModelMetadata Meta = null;
                        String[] FullProperty = null;

                        LambdaExpression Lambda = m.ModelType.FindSubProperty(out Meta, out FullProperty, Op.Property.Split("."));

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
                    else if (!Columns.Has(c => { return (c.DisplayName ?? c.PropertyName) == Op.Property; }))
                        {
                        System.Web.ModelBinding.ModelMetadata Meta = m.ModelType.Meta(Op.Property);

                        Columns.Add(Meta);
                        ColumnNames.Add(Meta.DisplayName ?? Meta.PropertyName);
                        // Members.Add(Meta.GetMember());
                        //  Accessors.Add(Meta.GetDelegate());
                        Functions.Add(Meta.GetFunc());
                        }
                    }
                }

            StringWriter sw = new StringWriter();

            // CSV Column Headers
            for (int i = 0; i < ColumnNames.Count; i++)
                {
                sw.Write("\"" + ColumnNames[i] + "\"");

                if (i < ColumnNames.Count - 1)
                    sw.Write(",");
                }

            sw.Write("\r\n");

            DateTime Start = DateTime.Now;
            int Progress = 0;

            // CSV Body
            foreach (IModel Model in Models)
                {
                for (int i = 0; i < Functions.Count; i++)
                    {
                    sw.Write("\"" + (Functions[i](Model) ?? "").ToString().ReplaceAll("\"", "'") + "\"");
                    //sw.Write("\"" + (((delegate)(Accessors[i]))(Model) ?? "").ToString() + "\"");
                    //sw.Write("\"" + (Members[i].GetValue(Model) ?? "").ToString() + "\"");
                    if (i < Columns.Count - 1)
                        sw.Write(",");
                    }
                sw.Write("\r\n");
                Progress++;
                }

            DateTime End = DateTime.Now;
            TimeSpan TimeLen = End.Subtract(Start);
            double Time = TimeLen.TotalMilliseconds;

            Response.WriteCSV(sw, FileName);
            }
        #endregion

        #region Details
        public virtual ActionResult Details(int id, String ReturnURL)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).View != true)
                {
                return new HttpUnauthorizedResult();
                }

#warning Restrict access by Role Scope
            IModel Model = (IModel)GetModelQuery().Find(id);

            ViewBag.ReturnURL = ReturnURL;
            ViewBag.ManageController = this;

            return View(Model);
            }
        #endregion

        #region Edit
        public virtual ActionResult Edit(int id, String ReturnURL, Boolean Create = false)
            {
            if (Session == null ||
                 ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Edit != true)
                {
                return new HttpUnauthorizedResult();
                }

            if (Create)
                {
                IModel Model = GetModel(0, true, null);

                return Edit(Model, ReturnURL, Create);
                }
            else
                {
#warning Restrict access by Role Scope
                IModel Model = (IModel)GetModelQuery().Find(id);

                return Edit(Model, ReturnURL);
                }
            }

        protected virtual ActionResult Edit(IModel Model, String ReturnURL, Boolean Create = false)
            {
            ViewBag.ReturnURL = ReturnURL;
            ViewBag.EditActionName = this.EditActionName;
            ViewBag.DeleteActionName = this.DeleteActionName;
            ViewBag.CreateActionName = this.CreateActionName;
            ViewBag.ControllerName = this.Name;

            ViewBag.AllowAdminRandomize = this.AllowAdminRandomize;

            ViewBag.Route_Edit = new
            {
                id = Model == null ? "" : Model.GetID(),
                ReturnURL = ReturnURL,
                Create = Create,
            };

            return View(Model);
            }

        [HttpPost]
        [Route("Manage/{id}/{ReturnURL}")]
        public virtual ActionResult Edit(int id, String ReturnURL, FormCollection Form, Boolean Create = false)
            {
            if (Session == null ||
                 ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Edit != true)
                {
                return new HttpUnauthorizedResult();
                }

            ViewBag.DeleteActionName = this.DeleteActionName;
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
                        DBContext.GetDBSet<T>().Add(Model);

                    DBContext.SaveChanges();
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
                TempData.Add(ControllerHelper.StatusMessage, "Successfully " + (Create ? "Created" : "Updated") + " - " + Model.GetFriendlyTypeName());

                return Redirect(ReturnURL);
                }
            else
                {
                return Edit(Model, ReturnURL, Create);
                }
            }

        #endregion

        #region Create
        public virtual ActionResult Create(String ReturnURL)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Edit != true)
                {
                return new HttpUnauthorizedResult();
                }

#warning Restrict access by Role Scope
            IModel Model = GetModel(0, true, null);

            return Edit(Model, ReturnURL, Create: true);
            }

        [HttpPost]
        public virtual ActionResult Create(String ReturnURL, FormCollection Form)
            {
            return Edit(0, ReturnURL, Form, true);
            }
        #endregion

        #region Delete
        public virtual ActionResult Delete(int id, String ReturnURL)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }
#warning Restrict access by Role Scope
            IModel Model = (IModel)GetModelQuery().Find(id);

            ViewBag.ReturnURL = ReturnURL;

            return View(Model);
            }

        [IgnoreValidation]
        public virtual ActionResult DeleteConfirm(int id, String ReturnURL, FormCollection collection, Boolean Restore = false)
            {
            if (Session == null ||
                ContextProviderFactory.GetCurrent().GetModelPermissions(Session, typeof(T)).Deactivate != true)
                {
                return new HttpUnauthorizedResult();
                }

#warning Restrict access by Role Scope
            DbSet DBSet = GetModelQuery();

            DBContext.Configuration.ValidateOnSaveEnabled = false;

            T Model = (T)DBSet.Find(id);

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
            // TODO: Add delete logic here

            return Redirect(ReturnURL);
            }
        #endregion

        #region UploadFile
        [HttpPost]
        public virtual ActionResult UploadFile(
            FormCollection Form,
            String ReturnURL,
            String RelationType,
            String RelationProperty,
            int RelationID)
            {
#warning Restrict access by Role Scope
            List<HttpPostedFileBase> UploadFiles = new List<HttpPostedFileBase>();

            foreach (String name in Request.Files)
                {
                if (name != "UploadFile" + RelationProperty)
                    continue;

                HttpPostedFileBase file = Request.Files[name];
                if (file.ContentLength > 0)
                    UploadFiles.Add(file);
                }

            if (!UploadFiles.IsEmpty())
                {
                foreach (HttpPostedFileBase File in UploadFiles)
                    {
                    UploadSingleFile(Form, RelationType, RelationProperty, RelationID, File);
                    }

                DBContext.SaveChanges();
                }

            return Redirect(ReturnURL);
            }

        protected virtual void UploadSingleFile(FormCollection Form, String RelationType, String RelationProperty, int RelationID, HttpPostedFileBase File)
            {
            FileUpload FileUp = GetFileUpload(File, Form, RelationType, RelationProperty, RelationID);

            DBContext.GetDBSet<FileUpload>().Add(FileUp);
            }

        protected virtual FileUpload GetFileUpload(HttpPostedFileBase UploadFile, FormCollection Form, String RelationType, String RelationProperty, int RelationID)
            {
            String RootPath = ContextProviderFactory.GetCurrent().GetFileUploadRootPath(Session, UploadFile, RelationType, RelationProperty, RelationID);
            String FilePath = ContextProviderFactory.GetCurrent().GetFileUploadFilePath(Session, UploadFile, RelationType, RelationProperty, RelationID);

            String FullPath = L.CombinePaths(RootPath, FilePath);

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(FullPath)))
                {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FullPath));
                }

            FileUpload FileUp = new FileUpload(UploadFile, FullPath);

            FileUp.RelationType = RelationType;
            FileUp.RelationProperty = RelationProperty;
            FileUp.RelationID = RelationID;

            return FileUp;
            }
        #endregion

        #region DownloadFile
        public void DownloadFile(int FileID)
            {
#warning Restrict access by Role Scope
            FileUpload FileUp = FindFileUpload(FileID);

            if (FileUp == null)
                {
                throw new ArgumentException("FileID");
                }

            Response.WriteFile(FileUp.FilePath);
            }
        #endregion

        #region DeleteFile
        public void DeleteFile(int id, String ReturnURL)
            {
#warning Restrict access by Role Scope

            FileUpload File = FindFileUpload(id);

            if (File == null)
                {
                throw new ArgumentException("FileID");
                }

            File.Active = false;
            DBContext.SaveChanges();

            Response.Redirect(ReturnURL);
            }
        #endregion

        private void SetDefaultSort(ManageViewModel Model)
            {
            DisplayColumnAttribute attr = Model.ModelType.MemberGetAttribute<DisplayColumnAttribute>(false);

            if (attr != null)
                {
                if (!String.IsNullOrEmpty(attr.SortColumn))
                    {
                    Model.OverrideSort = attr.SortColumn;
                    Model.OverrideSortDirection = attr.SortDescending ? "DESC" : "ASC";
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

                if (Model.HasProperty(ControllerHelper.AutomaticFields.Active))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Active, true);

                if (Model.HasProperty(ControllerHelper.AutomaticFields.Created))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Created, DateTime.Now);
                }
            else
                {
#warning Restrict access by Role Scope
                Model = (T)GetModelQuery().Find(id);

                if (Model.HasProperty(ControllerHelper.AutomaticFields.Updated))
                    Model.SetProperty(ControllerHelper.AutomaticFields.Updated, DateTime.Now);
                }
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
                String Value = Form[Key];

                System.Web.ModelBinding.ModelMetadata Meta = Model.Meta(Key);

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

                StringConverter Convert = null;

                if (Meta.ModelType.HasInterface(typeof(IModel), false))
                    {
                    Convert = new StringConverter(DBContext.GetDBSet<T>());
                    }
                else
                    {
                    Convert = new StringConverter();
                    }

                LambdaExpression Lambda = Meta.GetExpression();

                PropertyInfo p = Model.TrueModelType().GetProperty(Key);

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

                if (ContextProviderFactory.GetCurrent().CurrentUser(Session).IsAdmin == true)
                    {
                    Message += " - " + e.Message;
                    }

                ModelState.AddModelError(Key, Message);
                }

            return Errors;
            }

        protected virtual DbSet<T> GetModelQuery()
            {
            return DBContext.GetDBSet<T>();
            }

        public virtual IQueryable<T> RestrictScope(IQueryable<T> Query)
            {
            return Query;
            }

        protected virtual FileUpload FindFileUpload(int FileID)
            {
            FileUpload File = DBContext.GetDBSet<FileUpload>().Where(
                f => f.Active == true &&
                    f.RelationType == typeof(T).Name &&
                    f.FileUploadID == FileID).FirstOrDefault();

            return File;
            }

        private Dictionary<string, SearchOperation> ExtractSearchTerms(ref string GlobalSearchTerm, Type ModelType)
            {
            Dictionary<string, SearchOperation> Out = new Dictionary<string, SearchOperation>();

            String[] Split = null;

            if (GlobalSearchTerm.Contains("|"))
                Split = GlobalSearchTerm.Split("|");
            else
                Split = new[] { GlobalSearchTerm };

            GlobalSearchTerm = "";

            List<String> Keys = QueryExt.BinaryOps.Keys.List();

            foreach (String SearchTerm in Split)
                {
                Boolean KeyFound = false;

                foreach (String Key in Keys)
                    {
                    if (SearchTerm.Contains(Key))
                        {
                        String[] Split2 = SearchTerm.Split(Key);

                        String Property = Split2[0].RemoveAll(" ");

                        if (Property == null)
                            continue;

                        if (!ModelType.Meta().Properties.Has(p => p.PropertyName == Property))
                            {
                            if (Property.Contains("."))
                                {
                                // Corrects abbreviated properties so they display completely
                                String[] FullProperties = null;
                                System.Web.ModelBinding.ModelMetadata Meta = null;

                                var Accessor = ModelType.FindSubProperty(out Meta, out FullProperties, Property.Split("."));

                                Property = FullProperties.JoinLines(".");
                                }
                            else
                                {
                                Property = ModelType.SearchForProperty(Property);
                                }
                            }

                        String OperatorStr = Key;
                        Func<Expression, Expression, Expression> Operator = QueryExt.BinaryOps[Key];

                        String Search = Split2[1].Trim();

                        SearchOperation Op = new SearchOperation()
                            {
                                Property = Property,
                                OperatorStr = OperatorStr,
                                Operator = Operator,
                                Search = Search
                            };

                        if (Property == null)
                            continue;

                        if (Out.ContainsKey(Property))
                            {
                            Out[Property] = Op;
                            }
                        else
                            {
                            Out.Add(Property, Op);
                            }

                        KeyFound = true;
                        break;
                        }
                    }

                if (!KeyFound)
                    GlobalSearchTerm = SearchTerm;
                }

            return Out;
            }

        private IEnumerable<T> GetModels(out int TotalItems,
            int Page,
            String SortTerm,
            String SortDirection,
            String GlobalSearchTerm,
            Dictionary<String, SearchOperation> FieldSearchOperations,
            Boolean ShowInactiveRecords,
            Boolean ReturnAll)
            {
            IQueryable<T> Set = (IQueryable<T>)GetModelQuery().AsQueryable();

            Set = RestrictScope(Set);

            IEnumerable<T> Out = null;

            if (!String.IsNullOrEmpty(GlobalSearchTerm))
                {
                if (ManageController<T>.GlobalSearchAssumeStars && !GlobalSearchTerm.Contains("*"))
                    GlobalSearchTerm = "*" + GlobalSearchTerm + "*";

                Set = Set.GlobalSearch(GlobalSearchTerm);
                }

            if (typeof(T).HasProperty(ControllerHelper.AutomaticFields.Active) &&
                typeof(T).Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Boolean))
                {
                if (ShowInactiveRecords)
                    {
                    Expression<Func<T, Boolean>> Exp = typeof(T).GetExpression<T, Boolean>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.NotEqual(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, Boolean>>)Lambda);
                    }
                else
                    {
                    Expression<Func<T, Boolean>> Exp = typeof(T).GetExpression<T, Boolean>(ControllerHelper.AutomaticFields.Active);
                    Expression Equal = Expression.Equal(Exp.Body, Expression.Constant(true));
                    Expression Lambda = Expression.Lambda(Equal, Exp.Parameters[0]);

                    Set = Set.Where((Expression<Func<T, Boolean>>)Lambda);
                    }
                }

            if (FieldSearchOperations != null &&
                FieldSearchOperations.Keys.Count > 0)
                {
                foreach (String Property in FieldSearchOperations.Keys)
                    {
                    Set = Set.FilterBy(FieldSearchOperations[Property]);
                    }
                }

            if (!String.IsNullOrEmpty(SortTerm))
                {
                if (typeof(T).Meta(SortTerm).ModelType.HasInterface(typeof(IModel), false))
                    {
                    Type t = typeof(T).Meta(SortTerm).ModelType;
                    DisplayColumnAttribute display = t.GetAttribute<DisplayColumnAttribute>();

                    if (display != null)
                        SortTerm = SortTerm + "." + display.SortColumn;
                    else
                        SortTerm = SortTerm + "." + System.Linq.Enumerable.First(t.Meta().Properties).PropertyName;
                    }

                if (SortDirection == "ASC")
                    {
                    Out = Set.OrderBy(SortTerm);
                    }
                else
                    {
                    Out = Set.OrderByDescending(SortTerm);
                    }
                }
            else
                {
                Out = Set;
                }

            TotalItems = Out.Count();

            if (!ReturnAll)
                Out = Out.Skip((Page - 1) * this.RowsPerPage).Take(this.RowsPerPage);
            //      else
            //         Out = Out.Take(10000);

            return System.Linq.Enumerable.ToList(Out);
            }
        }
    }
