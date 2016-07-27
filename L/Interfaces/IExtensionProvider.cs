using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Interfaces
    {
    /// <summary>
    /// Denotes that a static class provides extension methods.
    /// </summary>
    public interface IExtensionProvider
        {
        }

    /// <summary>
    /// Default Attribute for IExtensionProvider
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ExtensionProviderAttribute : Attribute, IExtensionProvider, ITopLevelAttribute
        {
        /// <summary>
        /// This determines that every method parameter will be checked for null-safety (assumed to be possibly null)
        /// </summary>
        public bool TestMethodsForNulls { get; set; }

        /// <summary>
        /// Test all method test attributes declared on static methods.
        /// Set <paramref name="TestMethodsForNulls"/> to true to enable nullability testing for all parameters.
        /// </summary>
        public ExtensionProviderAttribute(bool TestMethodsForNulls = false)
            {
            this.TestMethodsForNulls = TestMethodsForNulls;
            }
        }
    }