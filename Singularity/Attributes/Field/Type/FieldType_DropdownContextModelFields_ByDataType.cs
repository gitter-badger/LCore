
using System;
using System.ComponentModel.DataAnnotations;
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

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextModelFields_ByDataType : FieldType_DropdownContextModelFields
        {
        public DataType ShowType { get; set; }

        protected override bool IncludeField(String MetaProperty, ModelMetadata Meta)
            {
            return Meta.DataTypeName == ShowType.ToString();
            }

        public FieldType_DropdownContextModelFields_ByDataType(DataType ShowType, Type ModelType, Boolean MultiSelect = false, Boolean RecursiveFields = false)
            : base(ModelType, MultiSelect, RecursiveFields)
            {
            this.ShowType = ShowType;
            }

        public FieldType_DropdownContextModelFields_ByDataType(DataType ShowType, String FieldTypeField, Boolean MultiSelect = false, Boolean RecursiveFields = false)
            : base(FieldTypeField, MultiSelect, RecursiveFields)
            {
            this.ShowType = ShowType;
            }
        }
    }