using LMVC.Controllers;
using LMVC.Routes;
using System;
using System.Web.Mvc;

namespace LMVC.Annotations
    {
    public interface IPartialAttribute
        {

        }

    public class InformationAttribute : FieldPartialBeforeAttribute, IPartialAttribute, IMetadataAware
        {
        public const string Key = "Information";

        public InformationAttribute(string Info)
            : this(Info, ControllerHelper.ViewType.Create, ControllerHelper.ViewType.Edit, ControllerHelper.ViewType.Display)
            {
            }

        public InformationAttribute(string Info, params ControllerHelper.ViewType[] Types)
            : base(PartialViews.Manage.Fields.Information, Types)
            {
            this.Info = Info;
            }


        public string Info { get; set; }

        public string ValueKey => Key;

        protected string _ValueData;
        public object ValueData => this.Info;

        public void OnMetadataCreated(ModelMetadata Metadata)
            {
            Metadata.AdditionalValues[this.ValueKey] = this.ValueData;
            }
        }
    }