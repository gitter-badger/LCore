using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using LCore;
using System.Linq.Expressions;

namespace Singularity
    {
    public class FriendlyModelName : Attribute, IL_FriendlyName
        {
        public string FriendlyName { get; set; }

        public FriendlyModelName(String Name)
            {
            this.FriendlyName = Name;
            }
        }
    }
