using LCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCore
{
    public class FriendlyNameAttribute : Attribute, IL_FriendlyName
    {
        public String FriendlyName { get; set; }

        public FriendlyNameAttribute(String FriendlyName)
        {
            this.FriendlyName = FriendlyName;
        }
    }
}
