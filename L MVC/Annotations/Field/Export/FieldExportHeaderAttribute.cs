using System;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public class FieldExportHeaderAttribute : Attribute, ISubClassPersistentAttribute
        {
        public string HeaderText { get; set; }

        public FieldExportHeaderAttribute(string HeaderText)
            {
            this.HeaderText = HeaderText;
            }
        }
    }
