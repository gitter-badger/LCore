
using System;

namespace LCore.Naming
    {
    /// <summary>
    /// Tag model properties with this Attribute to designate the field's
    /// Friendly Name
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FriendlyNameAttribute : Attribute, IL_FriendlyName
        {
        /// <summary>
        /// Friendly name for the object described.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Create a new FriendlyNameAttribute
        /// </summary>
        /// <param name="FriendlyName">Friendly name text</param>
        public FriendlyNameAttribute(string FriendlyName)
            {
            this.FriendlyName = FriendlyName;
            }
        }
    }
