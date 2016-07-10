
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Models;
using Singularity.Extensions;

namespace Singularity.Annotations
    {
    public class FieldTypeDropdownContextModelFields : FieldType_DropdownOptions
        {
        public FieldTypeDropdownContextModelFields(string FieldTypeField, bool MultiSelect = false, bool RecursiveFields = false)
            : base(new string[] { }, MultiSelect)
            {
            this.FieldTypeField = FieldTypeField;
            this.RecursiveFields = RecursiveFields;
            }

        public FieldTypeDropdownContextModelFields(Type ModelType, bool MultiSelect = false, bool RecursiveFields = false)
            : base(new string[] { }, MultiSelect)
            {
            this.ModelType = ModelType;
            this.RecursiveFields = RecursiveFields;
            }

        private string FieldTypeField { get; }

        private bool RecursiveFields { get; }

        protected Type ModelType { get; set; }

        protected virtual bool IncludeField(string MetaProperty, ModelMetadata Meta)
            {
            return true;
            }

        public virtual Type GetModelType(ViewContext Context)
            {
            if (this.ModelType != null)
                {
                return this.ModelType;
                }
            var Model = (IModel)Context.Controller.ViewBag.EditModel;

            var Meta = Model?.Meta(this.FieldTypeField);

            if (Meta != null)
                {
                var Out = Model.GetProperty(this.FieldTypeField);

                string s = Out as string;
                if (s != null)
                    {
                    return L.Ref.FindType(s);
                    }
                }

            // Get model type from model field value
            return null;
            }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            var ContextModelType = this.GetModelType(Context);

            if (ContextModelType != null)
                {
                Dictionary<string, ModelMetadata> Properties = this.RecursiveFields ?
                    ContextModelType.Meta().Properties.Index(p => p.PropertyName) :
                    ContextModelType.GetMeta();

                List<KeyValuePair<string, string>>[] Keys = { new List<KeyValuePair<string, string>>() };

                Properties.Each(k =>
                {
                    if (this.IncludeField(k.Key, k.Value))
                        Keys[0].Add(new KeyValuePair<string, string>(k.Value.PropertyName.Humanize(), k.Value.PropertyName));
                });

                Keys[0] = Keys[0].OrderBy(k => k.Key).List();

                return Keys[0];
                }

            return new List<KeyValuePair<string, string>>();
            }
        }
    }