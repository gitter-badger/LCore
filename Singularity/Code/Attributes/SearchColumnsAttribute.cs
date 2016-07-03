using System;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public class SearchColumnsAttribute : Attribute, ISubClassPersistentAttribute
        {
        public string[] SearchColumns { get; set; }

        public SearchColumnsAttribute(string[] SearchColumns)
            {
            this.SearchColumns = SearchColumns;
            }
        }
    }