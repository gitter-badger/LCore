using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using LCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Singularity.Controllers;
using Singularity.Context;
using Singularity.Extensions;
using System.Data.Entity;
using Singularity.Annotations;

namespace Singularity.Models
    {
    public class ViewField : IViewField
        {
        public ViewContext Context { get; set; }

        public Type FieldType { get; set; }

        private ModelMetadata _Meta;
        public ModelMetadata Meta
            {
            get
                {
                return Logic.Cache(ref this._Meta, () =>
                {
                    ModelMetadata OutMeta;

                    if (this.PropertyName.Contains("."))
                        {
                        string[] FullProperties;

                        this.ModelData.TrueModelType().FindSubProperty(out OutMeta, out FullProperties, this.PropertyName.Split("."));
                        }
                    else
                        {
                        OutMeta = this.ModelData.TrueModelType().Meta(this.PropertyName);
                        }

                    return OutMeta;
                });
                }
            }

        private object _PropertyData;
        public object PropertyData
            {
            get
                {
                return Logic.Cache(ref this._PropertyData, () =>
                {
                    ModelMetadata MyMeta;

                    LambdaExpression Lambda = null;

                    object ValueData;

                    if (this.PropertyName.Contains("."))
                        {
                        string[] FullProperties;

                        Lambda = this.ModelData.TrueModelType().FindSubProperty(out MyMeta, out FullProperties, this.PropertyName.Split("."));
                        }
                    else
                        {
                        MyMeta = this.ModelData.TrueModelType().Meta(this.PropertyName);
                        }

                    if (Lambda == null)
                        {
                        ValueData = this.ModelData.GetProperty(MyMeta.PropertyName);
                        }
                    else
                        {
                        Delegate d = Lambda.Compile();
                        ValueData = d.DynamicInvoke(this.ModelData);
                        }

                    return ValueData;
                });
                }
            }

        public string PropertyName { get; set; }

        public IModel ModelData { get; set; }

        public T GetModelData<T>()
            where T : IModel
            {
            return (T)this.ModelData;
            }

        public ControllerHelper.ViewType[] ViewTypes { get; set; }


        public string[] ModelFieldHtmlAttributes
            {
            get
                {
                return this.Meta.GetAttributes<FieldHtmlAttribute>().Convert(
                    f => f.AffectsViewTypes(this.ViewTypes) ?
                        $"{f.FieldAttr}=\"{f.FieldAttrValue}\"" :
                        null
                        ).Flatten<string>().Array();
                }
            }

        public string[] ModelFieldClasses
            {
            get
                {
                return this.Meta.GetAttributes<FieldClassAttribute>().Convert(
                    f =>
                        f.AffectsViewTypes(this.ViewTypes) ?
                        f.FieldClasses :
                        null
                        ).Flatten<string>().Array();
                }
            }

        public string ColumnClass => this.PropertyName.ToUrlSlug();

        public List<SelectListItem> GetRelationItems(Type t, object CurrentValue)
            {
            ContextProvider MyContext = ContextProviderFactory.GetCurrent();

            if (!MyContext.GetContextTypes(this.Context.HttpContext.Session).Has(t))
                {
                throw new Exception(t.Name);
                }

            DbSet Objects = MyContext.GetDBSet(this.Context.HttpContext.Session, t);

            List<IModel> Models;

            if (t.HasProperty(ControllerHelper.AutomaticFields.Active) &&
                t.Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(bool))
                {
                string TableName = MyContext.GetContext(this.Context.HttpContext.Session).GetTableName(t);

                Models = Objects.SqlQuery(
                    $"SELECT * FROM {TableName} WHERE {ControllerHelper.AutomaticFields.Active} = \'true\'")
                    .List<IModel>();
                }
            else
                {
                Models = Objects.List<IModel>();
                }

            return Models.Select(m => new SelectListItem
                {
                Text = m.ToString(),
                Value = m.GetID(),
                Selected = (CurrentValue ?? "").ToString() == (m.GetID() ?? "").ToString()
                }).ToList();
            }

        public string Route_FieldRelation(string ControllerName)
            {
            if (ContextProviderFactory.GetCurrent().GetModelPermissions(this.Context.HttpContext.Session, this.FieldType).View == true)
                {
                ManageController Manage = ContextProviderFactory.GetCurrent().AllManageControllers(this.Context.HttpContext.Session)
                    .First(m => m.ModelType == this.Meta.ModelType);

                if (Manage != null && this.Context.AllowView(this.Meta.ContainerType))
                    {
                    if (this.ModelData.TrueModelType().MemberHasAttribute<DisplayColumnAttribute>(false) && this.ModelData.TrueModelType().MemberGetAttribute<DisplayColumnAttribute>(false).DisplayColumn == this.Meta.PropertyName)
                        {
                        object ThisModel = this.ModelData.GetProperty(this.PropertyName);

                        if (ThisModel != null)
                            {
                            return new UrlHelper(this.Context.HttpContext.Request.RequestContext).Action(Routes.Controllers.Manage.Actions.Details, Manage.Name, new
                                {
                                id = this.ModelData.GetID(),
                                ReturnURL = this.Context.HttpContext.Request.Url
                                });
                            }
                        }
                    else
                        {
                        object RelatedModel = this.ModelData.GetProperty(this.PropertyName);

                        IModel Model = RelatedModel as IModel;
                        if (Model != null)
                            {
                            return new UrlHelper(this.Context.HttpContext.Request.RequestContext).Action(Routes.Controllers.Manage.Actions.Details, Manage.Name, new
                                {
                                id = Model.GetID(),
                                ReturnURL = this.Context.HttpContext.Request.Url
                                });
                            }
                        }
                    }
                }

            return null;
            }

        public string Route_FieldManyRelation(string ControllerName)
            {
            if (ContextProviderFactory.GetCurrent()
                .GetModelPermissions(this.Context.HttpContext.Session, this.Meta.ModelType.PreferGeneric()).View == true
                && this.Meta.AdditionalValues.ContainsKey(MetadataAttribute.AdditionalData_RelationForeignKey))
                {
                ManageController Manage = ContextProviderFactory.GetCurrent().AllManageControllers(this.Context.HttpContext.Session).First(m => m.ModelType == this.Meta.ModelType.PreferGeneric());

                if (this.Context.AllowView(this.Meta.ModelType.PreferGeneric()))
                    {
                    object RelatedModel = this.ModelData.GetProperty(this.PropertyName);

                    if (RelatedModel is IEnumerable)
                        {
                        return new UrlHelper(this.Context.HttpContext.Request.RequestContext).Action(Routes.Controllers.Manage.Actions.Manage, Manage.Name, new
                            {
                            FieldSearchTerms =
                                $"{(string)this.Meta.AdditionalValues[MetadataAttribute.AdditionalData_RelationForeignKey]}:{this.ModelData}"
                            });
                        }
                    }
                }

            return null;
            }


        public ViewField(ViewContext Context, Type FieldType, string PropertyName, IModel ModelData,
            params ControllerHelper.ViewType[] ViewTypes)
            {
            if (PropertyName == null)
                throw new ArgumentException("PropertyName");

            this.Context = Context;

            this.FieldType = FieldType;
            this.PropertyName = PropertyName;
            this.ModelData = ModelData;
            this.ViewTypes = ViewTypes;
            }
        }
    }
