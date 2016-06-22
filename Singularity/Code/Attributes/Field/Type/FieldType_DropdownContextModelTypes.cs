
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Extensions;

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextModelTypes : FieldType_DropdownOptions
        {
        public FieldType_DropdownContextModelTypes(bool MultiSelect = false, Type TypeFilter = null)
            : base(new string[] { }, MultiSelect)
            {
            this.TypeFilter = TypeFilter;
            }

        public Type TypeFilter { get; set; }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            Type[] Types = Context.HttpContext.GetModelContext().ContextTypes;

            if (this.TypeFilter != null)
                Types = Types.Where(t => t.IsType(this.TypeFilter)).Array();

            List<KeyValuePair<string, string>> Keys = Types.Convert(
                t => new KeyValuePair<string, string>(t.GetFriendlyTypeName(), t.FullName)).List();

            Keys = Keys.OrderBy(k => k.Key).List();

            return Keys;
            }
        }
    }