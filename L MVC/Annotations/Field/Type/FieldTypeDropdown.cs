using LMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore.Extensions;
using System.Collections;
using LMVC.Models;
using LMVC.Extensions;
using LMVC.Routes;

namespace LMVC.Annotations
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
                Value = Value.Sub(0, Value.Length - 1);

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
            return this.Values.Convert(Value => new KeyValuePair<string, string>(Value, Value));
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
            return this.GetSourceData(Context).Convert(DataItem =>
            {
                if (DataItem == null)
                    {
                    return null;
                    }
                // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
                if (DataItem is IModel)
                    {
                    return new KeyValuePair<string, string>(((IModel)DataItem).GetID(), DataItem.ToString());
                    }
                // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
                if (DataItem is string)
                    {
                    return new KeyValuePair<string, string>((string)DataItem, (string)DataItem);
                    }
                return new KeyValuePair<string, string>(DataItem.ToString(), DataItem.ToString());
                // ReSharper disable once SuspiciousTypeConversion.Global
            }) as IEnumerable<KeyValuePair<string, string>>;
            }
        }
    }