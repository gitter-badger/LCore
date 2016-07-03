namespace LCore.Interfaces
    {
    /// <summary>
    /// Allows for grouping. 
    /// Apply the IGrouped tag to a model to allow for grouping.
    /// </summary>
    public interface IGrouped
        {
        /// <summary>
        /// The group field
        /// </summary>
        string Group { get; }
        }
    }