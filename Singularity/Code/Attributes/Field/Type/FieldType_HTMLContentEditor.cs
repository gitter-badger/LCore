using Singularity.Controllers;
using Singularity.Routes;

namespace Singularity.Annotations
    {
    public class FieldType_HTMLContentEditor : CustomPartialAttribute
        {
        public FieldType_HTMLContentEditor()
            : base(PartialViews.Manage.Fields.Edit.HTMLContent, ControllerHelper.ViewType.All)
            {
            }
        }
    }