using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable CollectionNeverUpdated.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Stores information about the change, if any, between two objects of the same type
    /// </summary>
    public class Delta
        {
        /// <summary>
        /// Create a new <see cref="Delta"/> object.
        /// </summary>
        public Delta(object Object1, object Object2)
            {
            Dictionary<string, object> Object1Properties = Object1.GetPropertyValues();
            Dictionary<string, object> Object2Properties = Object2.GetPropertyValues();

            if (Object2Properties != null)
                foreach (KeyValuePair<string, object> Property in Object2Properties)
                    {
                    var Object1Value = Object1Properties.SafeGet(Property.Key);

                    if (Object1Value != Property.Value &&
                        (Object1Value != null || Property.Value != null))
                        {
                        this.Changes.Add(Property.Key, Property.Value?.ToString());
                        }
                    }
            }

        /// <summary>
        /// Recorded time of change
        /// </summary>
        public DateTime RecordedTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The Dictionary of changes
        /// </summary>
        public Dictionary<string, IConvertible> Changes { get; set; } = new Dictionary<string, IConvertible>();

        /// <summary>
        /// Returns whether there was any change in object properties
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty => this.Changes.Keys.Count == 0;
        }
    }