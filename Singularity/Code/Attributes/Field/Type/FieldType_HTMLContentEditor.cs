using Singularity.Controllers;
using Singularity.Routes;

namespace Singularity.Annotations
    {
    public class FieldType_HTMLContentEditor : CustomPartialAttribute
        {
        public FieldType_HTMLContentEditor()
            : base(PartialViews.Field_Edit_HTMLContent, ControllerHelper.ViewType.All)
            {
            }
        }
    }