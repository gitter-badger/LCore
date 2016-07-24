using System;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace LMVC.Annotations
    {
    public abstract class AdditionalValueAttribute : Attribute, IMetadataAware
        {
        public abstract string ValueKey { get; }
        public abstract object ValueData { get; }

        public virtual void OnMetadataCreated([CanBeNull]ModelMetadata Metadata)
            {
            if (Metadata != null)
                Metadata.AdditionalValues[this.ValueKey] = this.ValueData;
            }
        }
    }
