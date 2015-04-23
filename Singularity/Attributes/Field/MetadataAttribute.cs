using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Singularity
    {
    public class MetadataAttribute : AdditionalValueAttribute
        {
        public const String AdditionalData_RelationForeignKey = "RelationForeignKey";

        public MetadataAttribute(String ValueKey, String ValueData)
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

        protected string _ValueData;
        public override object ValueData
            {
            get
                {
                return _ValueData;
                }
            }
        }
    }
