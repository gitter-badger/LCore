using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace MVCL
    {
    public abstract class AdditionalValueAttribute : Attribute, IMetadataAware
        {
        public abstract String ValueKey { get; }
        public abstract Object ValueData { get; }

        public virtual void OnMetadataCreated(ModelMetadata metadata)
            {
            metadata.AdditionalValues[this.ValueKey] = this.ValueData;
            }
        }
    }
