
using System;

namespace LCore.Naming
    {
    public class FriendlyNameAttribute : Attribute, IL_FriendlyName
        {
        public string FriendlyName { get; set; }

        public FriendlyNameAttribute(string FriendlyName)
            {
            this.FriendlyName = FriendlyName;
            }
        }
    }
