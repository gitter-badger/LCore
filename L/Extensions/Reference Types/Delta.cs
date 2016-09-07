using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

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
        public Dictionary<string, object> Changes { get; set; } = new Dictionary<string, object>();

        public void ApplyTo<T>(T Object)
            {
            foreach (KeyValuePair<string, object> Property in this.Changes)
                Object.SetProperty(Property.Key, Property.Value);
            }

        /// <summary>
        /// Returns whether there was any change in object properties
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty => this.Changes.Keys.Count == 0;

        public string[] GetChangeDescriptions<T>([CanBeNull] T Object)
            {
            return this.Changes.Convert(Property =>

                {
                bool NoObject = Object == null;

                var CurrentValue = Object?.GetProperty(Property.Key);
                var NewValue = Property.Value;

                if (CurrentValue == null)
                    {
                    if (NoObject)
                        {
                        return null;
                        }

                    if (NewValue is IConvertible)
                        return $"{Property.Key} was set to '{NewValue}'.";

                    return $"{Property.Key} was set.";
                    }

                if (Property.Value == null)
                    {
                    return $"{Property.Key} was removed.";
                    }

                if (!(NewValue is string) &&
                    (NewValue is Array || NewValue is IEnumerable))
                    {
                    // TODO describe IEnumerable element changes
                    // TODO describe IEnumerable element additions
                    // TODO describe IEnumerable element removals
                    }

                // TODO describe numerical changes style "was increased / decreased"
                // TODO describe numerical changes style "[items] were added removed"

                if (CurrentValue is IConvertible && NewValue != null)
                    return $"{Property.Key} was changed from '{CurrentValue}' to '{NewValue}'";
                return $"{Property.Key} was changed.";
                }).Array();
            }
        }
    }