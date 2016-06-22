
using System;
using System.Web.Mvc;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextModelFields_ByType : FieldType_DropdownContextModelFields
        {
        public Type FieldType { get; set; }

        protected override bool IncludeField(string MetaProperty, ModelMetadata Meta)
            {
            return Meta.ModelType.IsType(this.FieldType);
            }

        public FieldType_DropdownContextModelFields_ByType(Type FieldType, Type ModelType, bool MultiSelect = false, bool RecursiveFields = false)
            : base(ModelType, MultiSelect, RecursiveFields)
            {
            this.FieldType = FieldType;
            }

        public FieldType_DropdownContextModelFields_ByType(Type FieldType, string FieldTypeField, bool MultiSelect = false, bool RecursiveFields = false)
            : base(FieldTypeField, MultiSelect, RecursiveFields)
            {
            this.FieldType = FieldType;
            }
        }
    }