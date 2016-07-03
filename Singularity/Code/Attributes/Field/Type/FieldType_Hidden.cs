using Singularity.Controllers;
using System.Web.Mvc;
using Singularity.Routes;

namespace Singularity.Annotations
    {
    public class FieldType_Hidden : CustomPartialAttribute, IMetadataAware
        {
        public FieldType_Hidden()
            : base(PartialViews.Manage.Fields.Edit.Hidden, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
            {
            }

        public virtual void OnMetadataCreated(ModelMetadata metadata)
            {
            metadata.AdditionalValues[FieldHideLabelAttribute.HideLabel] = true;
            }
        }
    }