using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LCore;
using Singularity.Context;
using System.Collections;
using Singularity.Models;
using Singularity.Extensions;

namespace Singularity.Annotations
    {
    public abstract class FieldType_Dropdown : CustomPartialAttribute, ISetFormField
        {
        public FieldType_Dropdown()
            : base(ControllerHelper.PartialViews.Field_Edit_Dropdown, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
            {
            }

        public abstract IEnumerable<KeyValuePair<String, String>> KeyValues(ViewContext Context);

        protected Boolean _MultiSelect { get; set; }
        public virtual Boolean MultiSelect
            {
            get
                {
                return _MultiSelect;
                }
            }

        public virtual String EmptyKey
            {
            get
                {
                return "- None -";
                }
            }
        public virtual String EmptyValue
            {
            get
                {
                return "";
                }
            }

        public Boolean SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, String Value)
            {
            Value = Value ?? "";

            Value = Value.Trim();

            if (Value.StartsWith(","))
                Value = Value.Substring(1);

            if (Value.EndsWith(","))
                Value = Value.Substring(0, Value.Length - 1);

            Model.SetProperty(Meta.PropertyName, Value);

            return false;
            }
        }

    public class FieldType_DropdownOptions : FieldType_Dropdown
        {
        public String[] Values { get; set; }

        public FieldType_DropdownOptions(String[] Values, Boolean MultiSelect = false)
            : base()
            {
            this.Values = Values;
            this._MultiSelect = MultiSelect;
            }

        public override IEnumerable<KeyValuePair<String, String>> KeyValues(ViewContext Context)
            {
            return (IEnumerable<KeyValuePair<String, String>>)Values.Convert((var) =>
            {
                return new KeyValuePair<String, String>(var, var);
            });
            }
        }

    public class FieldType_DropdownSource : FieldType_Dropdown
        {
        public String SourceField { get; set; }

        public FieldType_DropdownSource(String SourceField, Boolean MultiSelect = false)
            : base()
            {
            this.SourceField = SourceField;
            this._MultiSelect = MultiSelect;
            }

        public IEnumerable GetSourceData(ViewContext Context)
            {
            IModel Model = (IModel)Context.Controller.ViewBag.EditModel;

            if (Model != null)
                {
                ModelMetadata Meta = Model.Meta(SourceField);

                if (Meta != null)
                    {
                    Object Out = Model.GetProperty(SourceField);

                    if (Out is IEnumerable)
                        {
                        return (IEnumerable)Out;
                        }
                    }
                }

            // Get model type from model field value
            return new Object[] { };
            }

        public override IEnumerable<KeyValuePair<String, String>> KeyValues(ViewContext Context)
            {
            return (IEnumerable<KeyValuePair<String, String>>)GetSourceData(Context).Convert((var) =>
            {
                if (var == null)
                    {
                    return null;
                    }
                else if (var is IModel)
                    {
                    return new KeyValuePair<String, String>(((IModel)var).GetID(), var.ToString());
                    }
                else if (var is String)
                    {
                    return new KeyValuePair<String, String>((String)var, (String)var);
                    }
                else
                    {
                    return new KeyValuePair<String, String>(var.ToString(), var.ToString());
                    }
            });
            }
        }
    }