using MVCL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace MVCL
    {
    public interface IPartialAttribute
        {

        }

    public class InformationAttribute : FieldPartialBeforeAttribute, IPartialAttribute, IMetadataAware
        {
        public const String Key = "Information";

        public InformationAttribute(String Info)
            : this(Info, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit, ControllerHelper.ViewType.Display)
            {
            }

        public InformationAttribute(String Info, params ControllerHelper.ViewType[] Types)
            : base(MVCL.Controllers.ControllerHelper.PartialViews.Field_Information, Types)
            {
            this.Info = Info;
            }


        public String Info { get; set; }

        public string ValueKey
            {
            get
                {
                return InformationAttribute.Key;
                }
            }

        protected string _ValueData;
        public object ValueData
            {
            get
                {
                return Info;
                }
            }

        public void OnMetadataCreated(ModelMetadata metadata)
            {
            metadata.AdditionalValues[this.ValueKey] = this.ValueData;
            }
        }
    }