using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Singularity.Models
    {
    public interface IViewField
        {
        string[] ModelFieldClasses { get; }
        string[] ModelFieldHtmlAttributes { get; }

        string ColumnClass { get; }
        Type FieldType { get; set; }
        ModelMetadata Meta { get; }
        string PropertyName { get; set; }

        ViewContext Context { get; set; }

        object PropertyData { get; }

        ControllerHelper.ViewType[] ViewTypes { get; set; }
        IModel ModelData { get; }

        T GetModelData<T>()
            where T : IModel;

        List<SelectListItem> GetRelationItems(Type Type, object CurrentValue);
        string Route_FieldManyRelation(string ControllerName);
        string Route_FieldRelation(string ControllerName);
        }
    }
