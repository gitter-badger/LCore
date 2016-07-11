
using System;

namespace LCore.Naming
    {
    /// <summary>
    /// Tag model properties with this Attribute to designate the field's
    /// Friendly Name
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class)]
    public class FriendlyNameAttribute : Attribute, IFriendlyName
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
