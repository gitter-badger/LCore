using LMVC.Controllers;
using System.Web.Mvc;
using JetBrains.Annotations;
using LMVC.Routes;

namespace LMVC.Annotations
    {
    public class FieldTypeHidden : CustomPartialAttribute, IMetadataAware
        {
        public FieldTypeHidden()
            : base(PartialViews.Manage.Fields.Edit.Hidden, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
            {
            }

        public virtual void OnMetadataCreated([CanBeNull] ModelMetadata Metadata)
            {
            if (Metadata != null)
                Metadata.AdditionalValues[FieldHideLabelAttribute.HideLabel] = true;
            }
        }
    }