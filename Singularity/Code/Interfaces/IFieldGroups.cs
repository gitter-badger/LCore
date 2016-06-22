
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
        public static IEnumerable<ModelMetadata> GetFieldGroup(HttpContextBase Context, Type t, ControllerHelper.ViewType ViewType)
            {
            return t.Meta().Properties.Select(m =>
            {
                if (m.GetAttributes<IVisibility>().Count(i => i.GetVisibility(Context, ViewType) == false) > 0)
                    {
                    return false;
                    }
                if (ViewType == ControllerHelper.ViewType.Display &&
                    !m.ShowForDisplay)
                    {
                    return false;
                    }
                if (ViewType == ControllerHelper.ViewType.Edit &&
                    !m.ShowForEdit)
                    {
                    return false;
                    }
                if (m.HasAttribute<KeyAttribute>())
                    {
                    return false;
                    }
                return !ViewType.HasFlag(ControllerHelper.ViewType.TableCell) || !m.AdditionalValues.ContainsKey(HideManageViewColumnAttribute.Key) || m.AdditionalValues[HideManageViewColumnAttribute.Key] as bool? != true;
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