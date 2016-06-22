using System;
using LCore.Naming;

namespace Singularity.Annotations
    {
    public class FriendlyModelName : Attribute, IL_FriendlyName
        {
        public string FriendlyName { get; set; }

        public FriendlyModelName(string Name)
            {
            this.FriendlyName = Name;
            }
        }
    }
