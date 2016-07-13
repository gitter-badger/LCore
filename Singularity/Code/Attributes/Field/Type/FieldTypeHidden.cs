using Singularity.Controllers;
using System.Web.Mvc;
using Singularity.Routes;

namespace Singularity.Annotations
    {
    public class FieldTypeHidden : CustomPartialAttribute, IMetadataAware
        {
        public FieldTypeHidden()
            : base(PartialViews.Manage.Fields.Edit.Hidden, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
            {
            }

        public virtual void OnMetadataCreated(ModelMetadata Metadata)
            {
            Metadata.AdditionalValues[FieldHideLabelAttribute.HideLabel] = true;
            }
        }
    }