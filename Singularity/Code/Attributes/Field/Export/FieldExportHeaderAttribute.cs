using System;

namespace Singularity.Annotations
    {
    public class FieldExportHeaderAttribute : Attribute
        {
        public string HeaderText { get; set; }

        public FieldExportHeaderAttribute(string HeaderText)
            {
            this.HeaderText = HeaderText;
            }
        }
    }
