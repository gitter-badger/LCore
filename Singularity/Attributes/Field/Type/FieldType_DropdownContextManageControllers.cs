
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

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextManageControllers : FieldType_DropdownOptions
        {
        public FieldType_DropdownContextManageControllers(Type TypeFilter = null, Boolean MultiSelect = false)
            : base(new String[] { }, MultiSelect)
            {
            this.TypeFilter = TypeFilter;
            }

        public Type TypeFilter { get; set; }

        public override IEnumerable<KeyValuePair<String, String>> KeyValues(ViewContext Context)
            {
            ManageController[] Controllers = ContextProviderFactory.GetCurrent().AllManageControllers(Context.HttpContext.Session);

            if (TypeFilter != null)
                Controllers = Controllers.Where(c => c.ModelType.IsType(TypeFilter)).Array();

            List<KeyValuePair<String, String>> Keys = Controllers.Convert((c) =>
            {
                return new KeyValuePair<String, String>(c.Name, c.GetType().FullName);
            }).List();

            Keys = Keys.OrderBy(k => k.Key).List();

            return Keys;
            }
        }
    }