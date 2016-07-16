using System;
using System.Web.Mvc;

namespace Singularity.Annotations
    {
    public abstract class AdditionalValueAttribute : Attribute, IMetadataAware
        {
        public abstract string ValueKey { get; }
        public abstract object ValueData { get; }

        public virtual void OnMetadataCreated(ModelMetadata Metadata)
            {
            Metadata.AdditionalValues[this.ValueKey] = this.ValueData;
            }
        }
    }
