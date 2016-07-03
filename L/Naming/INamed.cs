namespace LCore.Naming
    {
    /// <summary>
    /// Interface to tell if a class has a Name property.
    /// </summary>
    public interface INamed
        {
        /// <summary>
        /// Get the name of the object
        /// </summary>
        string Name { get; }
        }
    }