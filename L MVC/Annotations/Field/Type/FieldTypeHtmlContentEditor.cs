using LMVC.Controllers;
using LMVC.Routes;

namespace LMVC.Annotations
    {
    public class FieldTypeHtmlContentEditor : CustomPartialAttribute
        {
        public FieldTypeHtmlContentEditor()
            : base(PartialViews.Manage.Fields.Edit.HTMLContent, ControllerHelper.ViewType.All)
            {
            }
        }
    }