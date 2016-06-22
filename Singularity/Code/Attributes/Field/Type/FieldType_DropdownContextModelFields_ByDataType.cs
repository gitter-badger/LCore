
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextModelFields_ByDataType : FieldType_DropdownContextModelFields
        {
        public DataType ShowType { get; set; }

        protected override bool IncludeField(string MetaProperty, ModelMetadata Meta)
            {
            return Meta.DataTypeName == this.ShowType.ToString();
            }

        public FieldType_DropdownContextModelFields_ByDataType(DataType ShowType, Type ModelType, bool MultiSelect = false, bool RecursiveFields = false)
            : base(ModelType, MultiSelect, RecursiveFields)
            {
            this.ShowType = ShowType;
            }

        public FieldType_DropdownContextModelFields_ByDataType(DataType ShowType, string FieldTypeField, bool MultiSelect = false, bool RecursiveFields = false)
            : base(FieldTypeField, MultiSelect, RecursiveFields)
            {
            this.ShowType = ShowType;
            }
        }
    }