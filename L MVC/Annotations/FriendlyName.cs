using System;
using LCore.Naming;

namespace LMVC.Annotations
    {
    public class FriendlyModelName : Attribute, IFriendlyName
        {
        public string FriendlyName { get; set; }

        public FriendlyModelName(string Name)
            {
            this.FriendlyName = Name;
            }
        }
    }
