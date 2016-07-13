﻿
using System;
using System.Collections.Generic;

using LCore.Extensions;
using Singularity.Models;
using Singularity.Controllers;
using Singularity.Extensions;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Annotations
    {
    public interface IFieldGroups : IModel
        {
        IEnumerable<ModelMetadata> GetFieldGroup(HttpContextBase Context, string CustomType);
        IEnumerable<ModelMetadata> GetFieldGroup(HttpContextBase Context, ControllerHelper.ViewType ViewType);
        }

    public static class FieldGroups
        {
        public static IEnumerable<ModelMetadata> GetFieldGroup(HttpContextBase Context, Type Type, ControllerHelper.ViewType ViewType)
            {
            return Type.Meta().Properties.Select(Prop =>
            {
                if (Prop.GetAttributes<IVisibility>().Count(i => i.GetVisibility(Context, ViewType) == false) > 0)
                    {
                    return false;
                    }
                if (ViewType == ControllerHelper.ViewType.Display &&
                    !Prop.ShowForDisplay)
                    {
                    return false;
                    }
                if (ViewType == ControllerHelper.ViewType.Edit &&
                    !Prop.ShowForEdit)
                    {
                    return false;
                    }
                if (Prop.HasAttribute<KeyAttribute>(true))
                    {
                    return false;
                    }
                return !ViewType.HasFlag(ControllerHelper.ViewType.TableCell) || !Prop.AdditionalValues.ContainsKey(HideManageViewColumnAttribute.Key) || Prop.AdditionalValues[HideManageViewColumnAttribute.Key] as bool? != true;
            });
            }
        }

    public class FieldGroups<T> : IFieldGroups
        where T : FieldGroups<T>
        {
        public virtual IEnumerable<ModelMetadata> GetFieldGroup(HttpContextBase Context, string CustomType)
            {
            return new ModelMetadata[] { };
            }

        public virtual IEnumerable<ModelMetadata> GetFieldGroup(HttpContextBase Context, ControllerHelper.ViewType ViewType)
            {
            return FieldGroups.GetFieldGroup(Context, typeof(T), ViewType);
            }
        }
    }