using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Singularity
    {
    public interface IViewField
        {
        string ColumnClass { get; }
        Type FieldType { get; set; }
        System.Web.ModelBinding.ModelMetadata Meta { get; }
        string PropertyName { get; set; }


        HttpContextBase Context { get; set; }

        Object PropertyData { get; }

        ControllerHelper.ViewType[] ViewTypes { get; set; }
        IModel ModelData { get; }

        T GetModelData<T>()
            where T : IModel;

        List<SelectListItem> GetRelationItems(Type t, object CurrentValue);
        string Route_FieldManyRelation(string ControllerName);
        string Route_FieldRelation(string ControllerName);
        }
    }
