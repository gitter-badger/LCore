using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Singularity
    {
    public class FieldType_HTMLContentEditor : CustomPartialAttribute
        {
        public FieldType_HTMLContentEditor()
            : base(ControllerHelper.PartialViews.Field_Edit_HTMLContent, ControllerHelper.ViewType.All)
            {
            }
        }
    }