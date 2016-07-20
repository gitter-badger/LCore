
using System;
using System.Web.Mvc;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public class FieldTypeDropdownContextModelFieldsByType : FieldTypeDropdownContextModelFields
        {
        public Type FieldType { get; set; }

        protected override bool IncludeField(string MetaProperty, ModelMetadata Meta)
            {
            return Meta.ModelType.IsType(this.FieldType);
            }

        public FieldTypeDropdownContextModelFieldsByType(Type FieldType, Type ModelType, bool MultiSelect = false, bool RecursiveFields = false)
            : base(ModelType, MultiSelect, RecursiveFields)
            {
            this.FieldType = FieldType;
            }

        public FieldTypeDropdownContextModelFieldsByType(Type FieldType, string FieldTypeField, bool MultiSelect = false, bool RecursiveFields = false)
            : base(FieldTypeField, MultiSelect, RecursiveFields)
            {
            this.FieldType = FieldType;
            }
        }
    }