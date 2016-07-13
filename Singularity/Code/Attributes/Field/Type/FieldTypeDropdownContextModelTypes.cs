
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Extensions;

namespace Singularity.Annotations
    {
    public class FieldTypeDropdownContextModelTypes : FieldTypeDropdownOptions
        {
        public FieldTypeDropdownContextModelTypes(bool MultiSelect = false, Type TypeFilter = null)
            : base(new string[] { }, MultiSelect)
            {
            this.TypeFilter = TypeFilter;
            }

        public Type TypeFilter { get; set; }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            Type[] Types = Context.HttpContext.GetModelContext().ContextTypes;

            if (this.TypeFilter != null)
                Types = Types.Where(Type => Type.IsType(this.TypeFilter)).Array();

            List<KeyValuePair<string, string>> Keys = Types.Convert(
                Type => new KeyValuePair<string, string>(Type.GetFriendlyTypeName(), Type.FullName)).List();

            Keys = Keys.OrderBy(Key => Key.Key).List();

            return Keys;
            }
        }
    }