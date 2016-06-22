using System;

namespace Singularity.Annotations
    {
    public class SearchColumnsAttribute : Attribute
        {
        public string[] SearchColumns { get; set; }

        public SearchColumnsAttribute(string[] SearchColumns)
            {
            this.SearchColumns = SearchColumns;
            }
        }
    }