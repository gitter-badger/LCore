
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Controllers;
using Singularity.Context;

namespace Singularity.Annotations
    {
    public class FieldType_DropdownContextManageControllers : FieldType_DropdownOptions
        {
        public FieldType_DropdownContextManageControllers(Type TypeFilter = null, bool MultiSelect = false)
            : base(new string[] { }, MultiSelect)
            {
            this.TypeFilter = TypeFilter;
            }

        public Type TypeFilter { get; set; }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            ManageController[] Controllers = ContextProviderFactory.GetCurrent().AllManageControllers(Context.HttpContext.Session);

            if (this.TypeFilter != null)
                Controllers = Controllers.Where(c => c.ModelType.IsType(this.TypeFilter)).Array();

            List<KeyValuePair<string, string>> Keys = Controllers.Convert(
                c => new KeyValuePair<string, string>(c.Name, c.GetType().FullName)).List();

            Keys = Keys.OrderBy(k => k.Key).List();

            return Keys;
            }
        }
    }