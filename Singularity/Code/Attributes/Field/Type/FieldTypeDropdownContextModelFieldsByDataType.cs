
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Singularity.Annotations
    {
    public class FieldTypeDropdownContextModelFieldsByDataType : FieldTypeDropdownContextModelFields
        {
        public DataType ShowType { get; set; }

        protected override bool IncludeField(string MetaProperty, ModelMetadata Meta)
            {
            return Meta.DataTypeName == this.ShowType.ToString();
            }

        public FieldTypeDropdownContextModelFieldsByDataType(DataType ShowType, Type ModelType, bool MultiSelect = false, bool RecursiveFields = false)
            : base(ModelType, MultiSelect, RecursiveFields)
            {
            this.ShowType = ShowType;
            }

        public FieldTypeDropdownContextModelFieldsByDataType(DataType ShowType, string FieldTypeField, bool MultiSelect = false, bool RecursiveFields = false)
            : base(FieldTypeField, MultiSelect, RecursiveFields)
            {
            this.ShowType = ShowType;
            }
        }
    }