
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class FieldType_DropdownContextModelTypes : FieldType_DropdownOptions
        {
        public FieldType_DropdownContextModelTypes(Boolean MultiSelect = false, Type TypeFilter = null)
            : base(new String[] { }, MultiSelect)
            {
            this.TypeFilter = TypeFilter;
            }

        public Type TypeFilter { get; set; }

        public override IEnumerable<KeyValuePair<String, String>> KeyValues(ViewContext Context)
            {
            Type[] Types = Context.HttpContext.GetModelContext().ContextTypes;

            if (TypeFilter != null)
                Types = Types.Where(t => t.IsType(TypeFilter)).Array();

            List<KeyValuePair<String, String>> Keys = Types.Convert((t) =>
            {
                return new KeyValuePair<String, String>(t.GetFriendlyTypeName(), t.FullName);
            }).List();

            Keys = Keys.OrderBy(k => k.Key).List();

            return Keys;
            }
        }
    }