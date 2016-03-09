using Singularity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using LCore;
using Singularity.Context;

namespace Singularity.Annotations
    {
    public class FieldType_Hidden : CustomPartialAttribute, IMetadataAware
        {
        public FieldType_Hidden()
            : base(ControllerHelper.PartialViews.Field_Edit_Hidden, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit)
            {
            }

        public virtual void OnMetadataCreated(ModelMetadata metadata)
            {
            metadata.AdditionalValues[FieldHideLabelAttribute.HideLabel] = true;
            }
        }
    }