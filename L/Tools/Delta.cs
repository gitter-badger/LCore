using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;

// ReSharper disable CollectionNeverUpdated.Global

namespace LCore.Tools
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
        public Dictionary<string, object> Changes { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Returns whether there was any change in object properties
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty => this.Changes.Keys.Count == 0;


        /// <summary>
        /// Applies a <see cref="Delta"/> to an object, applying all changes stored.
        /// </summary>
        public void ApplyTo<T>(T Object)
            {
            foreach (KeyValuePair<string, object> Property in this.Changes)
                Object.SetProperty(Property.Key, Property.Value);
            }

        /// <summary>
        /// Retrieves friendly text describing the changes that took place
        /// </summary>
        public string[] GetChangeDescriptions<T>([CanBeNull] T Object)
            {
            var Out = new List<string>();

            this.Changes.Each(Property =>
                {
                bool NoObject = Object == null;

                var CurrentValue = Object?.GetProperty(Property.Key);
                var NewValue = Property.Value;

                if (CurrentValue == null)
                    {
                    if (NoObject)
                        return;

                    if (NewValue is IConvertible)
                        {
                        Out.Add($"{Property.Key} was set to '{NewValue}'.");
                        return;
                        }

                    Out.Add($"{Property.Key} was set.");
                    return;
                    }

                if (Property.Value == null)
                    {
                    Out.Add($"{Property.Key} was removed.");
                    return;
                    }

                if (!(NewValue is string) &&
                    NewValue is IEnumerable &&
                    CurrentValue is IEnumerable)
                    {
                    uint Count1 = ((IEnumerable) CurrentValue).Count();
                    uint Count2 = ((IEnumerable) NewValue).Count();

                    if (Count1 == Count2)
                        {
                        for (int i = 0; i < Count1; i++)
                            {
                            var Item1 = ((IEnumerable) CurrentValue).GetAt(i);
                            var Item2 = ((IEnumerable) NewValue).GetAt(i);

                            if (Item1 != null && Item2 != null)
                                {
                                var Delta = new Delta(Item1, Item2);

                                if (!Delta.IsEmpty)
                                    {
                                    Out.Add($"{Property.Key} {Delta.GetChangeDescriptions(CurrentValue)}");
                                    }
                                }
                            }
                        return;
                        }

                    // TODO describe IEnumerable element additions
                    // TODO describe IEnumerable element removals
                    // TODO describe IEnumerable element reorderings
                    return;
                    }

                // TODO describe numerical changes style "was increased / decreased TO"
                // TODO describe numerical changes style "was increased / decreased BY"
                // TODO describe numerical changes style "[items] were added removed"

                if (NewValue is bool)
                    {
                    Out.Add($"{Property.Key} was changed to '{((bool) NewValue ? "Yes" : "No")}'");
                    return;
                    }

                if (CurrentValue is IConvertible && NewValue is IConvertible)
                    {
                    Out.Add($"{Property.Key} was changed from '{CurrentValue}' to '{NewValue}'");
                    return;
                    }

                if (CurrentValue is IConvertible)
                    {
                    Out.Add($"{Property.Key} was changed from '{CurrentValue}'");
                    return;
                    }

                if (NewValue is IConvertible)
                    {
                    Out.Add($"{Property.Key} was changed to '{NewValue}'");
                    return;
                    }

                Out.Add($"{Property.Key} was changed.");
                });

            return Out.Array();
            }
        }
    }