
using System;
using System.Collections.Generic;
using LCore;
using MVCL;
using MVCL.Models;
using MVCL.Controllers;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCL
    {
    public interface IFieldGroups : IModel
        {
        IEnumerable<System.Web.ModelBinding.ModelMetadata> GetFieldGroup(HttpContextBase Context, String CustomType);
        IEnumerable<System.Web.ModelBinding.ModelMetadata> GetFieldGroup(HttpContextBase Context, ControllerHelper.ViewType ViewType);
        }

    public static class FieldGroups
        {
        public static IEnumerable<System.Web.ModelBinding.ModelMetadata> GetFieldGroup(HttpContextBase Context, Type t, ControllerHelper.ViewType ViewType)
            {
            return ListExt.Select(t.Meta().Properties, (m) =>
            {
                if (m.GetAttributes<IVisibility>().Count<IVisibility>((i) => { return i.GetVisibility(Context, ViewType) == false; }) > 0)
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
                if (ViewType.HasFlag(ControllerHelper.ViewType.TableCell) &&
                    m.AdditionalValues.ContainsKey(HideManageViewColumnAttribute.Key)
                    && m.AdditionalValues[HideManageViewColumnAttribute.Key] as Boolean? == true)
                    {
                    return false;
                    }

                return true;
            });
            }
        }

    public class FieldGroups<T> : IFieldGroups
        where T : FieldGroups<T>
        {
        public virtual IEnumerable<System.Web.ModelBinding.ModelMetadata> GetFieldGroup(HttpContextBase Context, String CustomType)
            {
            return new System.Web.ModelBinding.ModelMetadata[] { };
            }

        public virtual IEnumerable<System.Web.ModelBinding.ModelMetadata> GetFieldGroup(HttpContextBase Context, ControllerHelper.ViewType ViewType)
            {
            return FieldGroups.GetFieldGroup(Context, typeof(T), ViewType);
            }
        }
    }