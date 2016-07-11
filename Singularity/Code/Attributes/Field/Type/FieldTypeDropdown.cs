using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore.Extensions;
using System.Collections;
using Singularity.Models;
using Singularity.Extensions;
using Singularity.Routes;

namespace Singularity.Annotations
    {
    public abstract class FieldTypeDropdown : CustomPartialAttribute, ISetFormField
        {
        protected FieldTypeDropdown()
            : base(PartialViews.Manage.Fields.Edit.Dropdown, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
            {
            }

        public abstract IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context);

        protected bool _MultiSelect { get; set; }
        public virtual bool MultiSelect => this._MultiSelect;

        public virtual string EmptyKey => "- None -";

        public virtual string EmptyValue => "";

        public bool SetFormField(FormCollection Form, IModel Model, ModelMetadata Meta, string Value)
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

    public class FieldTypeDropdownOptions : FieldTypeDropdown
        {
        public string[] Values { get; set; }

        public FieldTypeDropdownOptions(string[] Values, bool MultiSelect = false)
            {
            this.Values = Values;
            this._MultiSelect = MultiSelect;
            }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            return this.Values.Convert(var => new KeyValuePair<string, string>(var, var));
            }
        }

    public class FieldTypeDropdownSource : FieldTypeDropdown
        {
        public string SourceField { get; set; }

        public FieldTypeDropdownSource(string SourceField, bool MultiSelect = false)
            {
            this.SourceField = SourceField;
            this._MultiSelect = MultiSelect;
            }

        public IEnumerable GetSourceData(ViewContext Context)
            {
            var Model = (IModel)Context.Controller.ViewBag.EditModel;

            var Meta = Model?.Meta(this.SourceField);

            if (Meta != null)
                {
                var Out = Model.GetProperty(this.SourceField);

                var Enumerable = Out as IEnumerable;
                if (Enumerable != null)
                    {
                    return Enumerable;
                    }
                }

            // Get model type from model field value
            return new object[] { };
            }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            return this.GetSourceData(Context).Convert(var =>
            {
                if (var == null)
                    {
                    return null;
                    }
                // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
                if (var is IModel)
                    {
                    return new KeyValuePair<string, string>(((IModel)var).GetID(), var.ToString());
                    }
                // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
                if (var is string)
                    {
                    return new KeyValuePair<string, string>((string)var, (string)var);
                    }
                return new KeyValuePair<string, string>(var.ToString(), var.ToString());
                // ReSharper disable once SuspiciousTypeConversion.Global
            }) as IEnumerable<KeyValuePair<string, string>>;
            }
        }
    }