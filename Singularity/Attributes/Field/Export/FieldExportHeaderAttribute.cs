using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class FieldExportHeaderAttribute : Attribute
        {
        public String HeaderText { get; set; }

        public FieldExportHeaderAttribute(String HeaderText)
            {
            this.HeaderText = HeaderText;
            }
        }
    }
