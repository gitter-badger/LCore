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
    public abstract class FieldType_Dropdown : CustomPartialAttribute, ISetFormField
        {
        protected FieldType_Dropdown()
            : base(PartialViews.Field_Edit_Dropdown, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
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

    public class FieldType_DropdownOptions : FieldType_Dropdown
        {
        public string[] Values { get; set; }

        public FieldType_DropdownOptions(string[] Values, bool MultiSelect = false)
            {
            this.Values = Values;
            this._MultiSelect = MultiSelect;
            }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            return this.Values.Convert(var => new KeyValuePair<string, string>(var, var));
            }
        }

    public class FieldType_DropdownSource : FieldType_Dropdown
        {
        public string SourceField { get; set; }

        public FieldType_DropdownSource(string SourceField, bool MultiSelect = false)
            {
            this.SourceField = SourceField;
            this._MultiSelect = MultiSelect;
            }

        public IEnumerable GetSourceData(ViewContext Context)
            {
            IModel Model = (IModel)Context.Controller.ViewBag.EditModel;

            ModelMetadata Meta = Model?.Meta(this.SourceField);

            if (Meta != null)
                {
                object Out = Model.GetProperty(this.SourceField);

                IEnumerable @out = Out as IEnumerable;
                if (@out != null)
                    {
                    return @out;
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