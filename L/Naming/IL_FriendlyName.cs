using LCore.Extensions;

namespace LCore.Naming
    {
    /// <summary>
    /// Interface exposes the FriendlyName property. 
    /// Extend this interface on an attribute to add friendly names 
    /// to classes and properties.
    /// </summary>
    public interface IL_FriendlyName : ISubClassPersistentAttribute
        {
        /// <summary>
        /// Friendly name for the object descibed.
        /// </summary>
        string FriendlyName { get; set; }
        }
    }