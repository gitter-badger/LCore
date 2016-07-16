
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LCore.Extensions;
using Singularity.Controllers;
using Singularity.Context;

namespace Singularity.Annotations
    {
    public class FieldTypeDropdownContextManageControllers : FieldTypeDropdownOptions
        {
        public FieldTypeDropdownContextManageControllers(Type TypeFilter = null, bool MultiSelect = false)
            : base(new string[] { }, MultiSelect)
            {
            this.TypeFilter = TypeFilter;
            }

        public Type TypeFilter { get; set; }

        public override IEnumerable<KeyValuePair<string, string>> KeyValues(ViewContext Context)
            {
            ManageController[] Controllers = ContextProviderFactory.GetCurrent().AllManageControllers(Context.HttpContext.Session);

            if (this.TypeFilter != null)
                Controllers = Controllers.Where(Controller => Controller.ModelType.IsType(this.TypeFilter)).Array();

            List<KeyValuePair<string, string>> Keys = Controllers.Convert(
                Controller => new KeyValuePair<string, string>(Controller.Name, Controller.GetType().FullName)).List();

            Keys = Keys.OrderBy(Key => Key.Key).List();

            return Keys;
            }
        }
    }