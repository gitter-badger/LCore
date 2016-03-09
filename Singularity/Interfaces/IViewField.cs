using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Models
    {
    public interface IViewField
        {
        String[] ModelFieldClasses { get; }
        String[] ModelFieldHtmlAttributes { get; }

        String ColumnClass { get; }
        Type FieldType { get; set; }
        ModelMetadata Meta { get; }
        String PropertyName { get; set; }

        ViewContext Context { get; set; }

        Object PropertyData { get; }

        ControllerHelper.ViewType[] ViewTypes { get; set; }
        IModel ModelData { get; }

        T GetModelData<T>()
            where T : IModel;

        List<SelectListItem> GetRelationItems(Type t, Object CurrentValue);
        String Route_FieldManyRelation(String ControllerName);
        String Route_FieldRelation(String ControllerName);
        }
    }
