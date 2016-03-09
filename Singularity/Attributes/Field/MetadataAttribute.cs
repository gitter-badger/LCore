using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class MetadataAttribute : AdditionalValueAttribute
        {
        public const String AdditionalData_RelationForeignKey = "RelationForeignKey";

        public MetadataAttribute(String ValueKey, Object ValueData)
            {
            _ValueKey = ValueKey;
            _ValueData = ValueData;
            }

        protected string _ValueKey;
        public override string ValueKey
            {
            get
                {
                return _ValueKey;
                }
            }

        protected Object _ValueData;
        public override Object ValueData
            {
            get
                {
                return _ValueData;
                }
            }
        }
    }
