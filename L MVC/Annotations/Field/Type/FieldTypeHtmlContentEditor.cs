using Singularity.Controllers;
using Singularity.Routes;

namespace Singularity.Annotations
    {
    public class FieldTypeHtmlContentEditor : CustomPartialAttribute
        {
        public FieldTypeHtmlContentEditor()
            : base(PartialViews.Manage.Fields.Edit.HTMLContent, ControllerHelper.ViewType.All)
            {
            }
        }
    }