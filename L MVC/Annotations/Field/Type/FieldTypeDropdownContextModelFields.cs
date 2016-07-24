
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JetBrains.Annotations;
using LCore.Extensions;
using LMVC.Models;
using LMVC.Extensions;

namespace LMVC.Annotations
    {
    public class FieldTypeDropdownContextModelFields : FieldTypeDropdownOptions
        {
        public FieldTypeDropdownContextModelFields(string FieldTypeField, bool MultiSelect = false, bool RecursiveFields = false)
            : base(new string[] { }, MultiSelect)
            {
            this.FieldTypeField = FieldTypeField;
            this.RecursiveFields = RecursiveFields;
            }

        // ReSharper disable once MemberCanBeProtected.Global
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

        [CanBeNull]
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

                string Str = Out as string;
                if (Str != null)
                    {
                    return L.Ref.FindType(Str);
                    }
                }

            // Get model type from model field value
            return null;
            }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues([CanBeNull]ViewContext Context)
            {
            var ContextModelType = this.GetModelType(Context);

            if (ContextModelType != null)
                {
                Dictionary<string, ModelMetadata> Properties = this.RecursiveFields ?
                    ContextModelType.Meta()?.Properties.Index(Prop => Prop.PropertyName) :
                    ContextModelType.GetMeta();

                List<KeyValuePair<string, string>>[] Keys = { new List<KeyValuePair<string, string>>() };

                Properties.Each(Prop =>
                {
                    if (this.IncludeField(Prop.Key, Prop.Value))
                        Keys[0].Add(new KeyValuePair<string, string>(Prop.Value.PropertyName.Humanize(), Prop.Value.PropertyName));
                });

                Keys[0] = Keys[0].OrderBy(Key => Key.Key).List();

                return Keys[0];
                }

            return new List<KeyValuePair<string, string>>();
            }
        }
    }