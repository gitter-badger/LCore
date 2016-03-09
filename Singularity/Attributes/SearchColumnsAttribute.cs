using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singularity.Annotations
    {
    public class SearchColumnsAttribute : Attribute
        {
        public String[] SearchColumns { get; set; }

        public SearchColumnsAttribute(String[] SearchColumns)
            {
            this.SearchColumns = SearchColumns;
            }
        }
    }