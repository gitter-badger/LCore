using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LCore;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Singularity.Controllers;
using Singularity.Context;
using Singularity;
using Singularity.Extensions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
                return L.Cache(ref _Meta, () =>
                {
                    ModelMetadata Meta = null;

                    if (PropertyName.Contains("."))
                        {
                        String[] FullProperties = null;

                        LambdaExpression Lambda = null;
                        Lambda = ModelData.TrueModelType().FindSubProperty(out Meta, out FullProperties, PropertyName.Split("."));
                        }
                    else
                        {
                        Meta = ModelData.TrueModelType().Meta(PropertyName);
                        }

                    return Meta;
                });
                }
            }

        private Object _PropertyData;
        public Object PropertyData
            {
            get
                {
                return L.Cache(ref _PropertyData, () =>
                {
                    ModelMetadata Meta = this.Meta;

                    LambdaExpression Lambda = null;

                    Object ValueData = null;

                    if (PropertyName.Contains("."))
                        {
                        String[] FullProperties = null;

                        Lambda = ModelData.TrueModelType().FindSubProperty(out Meta, out FullProperties, PropertyName.Split("."));
                        }
                    else
                        {
                        Meta = ModelData.TrueModelType().Meta(PropertyName);
                        }

                    if (Lambda == null)
                        {
                        ValueData = ModelData.GetProperty(Meta.PropertyName);
                        }
                    else
                        {
                        Delegate d = Lambda.Compile();
                        ValueData = d.DynamicInvoke(ModelData);
                        }

                    return ValueData;
                });
                }
            }

        public String PropertyName { get; set; }

        public IModel ModelData { get; set; }

        public T GetModelData<T>()
            where T : IModel
            {
            return (T)ModelData;
            }

        public ControllerHelper.ViewType[] ViewTypes { get; set; }


        public String[] ModelFieldHtmlAttributes
            {
            get
                {
                return Meta.GetAttributes<FieldHtmlAttribute>().Convert((f) =>
                {
                    return f.AffectsViewTypes(this.ViewTypes) ?
                        (f.FieldAttr + "=\"" + f.FieldAttrValue + "\"") :
                        null;
                }).Flatten<String>().Array();
                }
            }

        public String[] ModelFieldClasses
            {
            get
                {
                return Meta.GetAttributes<FieldClassAttribute>().Convert((f) =>
                {
                    return f.AffectsViewTypes(this.ViewTypes) ?
                        f.FieldClasses :
                        null;
                }).Flatten<String>().Array();
                }
            }

        public String ColumnClass
            {
            get
                {
                return PropertyName.ToUrlSlug();
                }
            }

        public List<SelectListItem> GetRelationItems(Type t, Object CurrentValue)
            {
            ContextProvider Context = ContextProviderFactory.GetCurrent();

            if (!Context.GetContextTypes(this.Context.HttpContext.Session).Has(t))
                {
                throw new Exception(t.Name);
                }

            DbSet Objects = Context.GetDBSet(this.Context.HttpContext.Session, t);

            List<IModel> Models;

            if (t.HasProperty(ControllerHelper.AutomaticFields.Active) &&
                t.Meta(ControllerHelper.AutomaticFields.Active).ModelType == typeof(Boolean))
                {
                String TableName = Context.GetContext(this.Context.HttpContext.Session).GetTableName(t);

                Models = Objects.SqlQuery("SELECT * FROM " + TableName + " WHERE " + ControllerHelper.AutomaticFields.Active + " = 'true'").List<IModel>();
                }
            else
                {
                Models = Objects.List<IModel>();
                }

            List<SelectListItem> Items = new List<SelectListItem>();

            foreach (IModel m in Models)
                {
                Items.Add(new SelectListItem()
                {
                    Text = m.ToString(),
                    Value = m.GetID(),
                    Selected = (CurrentValue ?? "").ToString() == (m.GetID() ?? "").ToString(),
                });
                }

            return Items;
            }

        public String Route_FieldRelation(String ControllerName)
            {
            if (ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, FieldType).View == true)
                {
                ManageController Manage = ContextProviderFactory.GetCurrent().AllManageControllers(Context.HttpContext.Session)
                    .First((m) => { return m.ModelType == Meta.ModelType; });

                if (Manage != null &&
                    Context.AllowView(Meta.ContainerType))
                    {
                    if (ModelData.TrueModelType().MemberHasAttribute<DisplayColumnAttribute>(false) &&
                        ModelData.TrueModelType().MemberGetAttribute<DisplayColumnAttribute>(false).DisplayColumn == Meta.PropertyName)
                        {
                        Object ThisModel = ModelData.GetProperty(PropertyName);

                        if (ThisModel != null)
                            {
                            return new UrlHelper(Context.HttpContext.Request.RequestContext).Action(Singularity.Routes.Controllers.Manage.Actions.Details, Manage.Name, new
                                {
                                    id = ModelData.GetID(),
                                    ReturnURL = Context.HttpContext.Request.Url,
                                });
                            }
                        }
                    else
                        {
                        Object RelatedModel = ModelData.GetProperty(PropertyName);

                        if (RelatedModel != null && RelatedModel is IModel)
                            {
                            return new UrlHelper(Context.HttpContext.Request.RequestContext).Action(Singularity.Routes.Controllers.Manage.Actions.Details, Manage.Name, new
                                {
                                    id = ((IModel)RelatedModel).GetID(),
                                    ReturnURL = Context.HttpContext.Request.Url,
                                });
                            }
                        }
                    }
                }

            return null;
            }

        public String Route_FieldManyRelation(String ControllerName)
            {
            if (ContextProviderFactory.GetCurrent().GetModelPermissions(Context.HttpContext.Session, Meta.ModelType.PreferGeneric()).View == true &&
                Meta.AdditionalValues.ContainsKey(MetadataAttribute.AdditionalData_RelationForeignKey))
                {
                ManageController Manage = ContextProviderFactory.GetCurrent().AllManageControllers(Context.HttpContext.Session).First((m) => { return m.ModelType == Meta.ModelType.PreferGeneric(); });

                if (this.Context.AllowView(Meta.ModelType.PreferGeneric()))
                    {
                    Object RelatedModel = ModelData.GetProperty(PropertyName);

                    if (RelatedModel != null && RelatedModel is IEnumerable)
                        {
                        return new UrlHelper(Context.HttpContext.Request.RequestContext).Action(Singularity.Routes.Controllers.Manage.Actions.Manage, Manage.Name, new
                            {
                                FieldSearchTerms = (String)Meta.AdditionalValues[MetadataAttribute.AdditionalData_RelationForeignKey] + ":" + ModelData.ToString()
                            });
                        }
                    }
                }

            return null;
            }


        public ViewField(ViewContext Context, Type FieldType, String PropertyName, IModel ModelData,
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
