
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using LCore;

using Singularity;
using Singularity.Controllers;
using Singularity.Context;
using Singularity.Models;
using Singularity.Extensions;

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextModelFields : FieldType_DropdownOptions
        {
        public FieldType_DropdownContextModelFields(String FieldTypeField, Boolean MultiSelect = false, Boolean RecursiveFields = false)
            : base(new String[] { }, MultiSelect)
            {
            this.FieldTypeField = FieldTypeField;
            this.RecursiveFields = RecursiveFields;
            }

        public FieldType_DropdownContextModelFields(Type ModelType, Boolean MultiSelect = false, Boolean RecursiveFields = false)
            : base(new String[] { }, MultiSelect)
            {
            this.ModelType = ModelType;
            this.RecursiveFields = RecursiveFields;
            }

        private String FieldTypeField { get; set; }

        private Boolean RecursiveFields { get; set; }

        protected Type ModelType { get; set; }

        protected virtual Boolean IncludeField(String MetaProperty, ModelMetadata Meta)
            {
            return true;
            }

        public virtual Type GetModelType(ViewContext Context)
            {
            if (ModelType != null)
                {
                return ModelType;
                }
            else
                {
                IModel Model = (IModel)Context.Controller.ViewBag.EditModel;

                if (Model != null)
                    {
                    ModelMetadata Meta = Model.Meta(FieldTypeField);

                    if (Meta != null)
                        {
                        Object Out = Model.GetProperty(FieldTypeField);

                        if (Out is String)
                            {
                            return TypeExt.FindType((String)Out);
                            }
                        }
                    }

                // Get model type from model field value
                return null;
                }
            }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            Type ModelType = this.GetModelType(Context);

            if (ModelType != null)
                {
                Dictionary<String, ModelMetadata> Properties = null;

                if (RecursiveFields)
                    Properties = ModelType.Meta().Properties.Map((p) =>
                        {
                            return p.PropertyName;
                        });
                else
                    Properties = ModelType.GetMeta();

                List<KeyValuePair<String, String>> Keys = new List<KeyValuePair<String, String>>();

                Properties.Each((k) =>
                {
                    if (IncludeField(k.Key, k.Value))
                        Keys.Add(new KeyValuePair<String, String>(k.Value.PropertyName.Humanize(), k.Value.PropertyName));
                });

                Keys = Keys.OrderBy(k => k.Key).List();

                return Keys;
                }

            return new List<KeyValuePair<String, String>>();
            }
        }
    }