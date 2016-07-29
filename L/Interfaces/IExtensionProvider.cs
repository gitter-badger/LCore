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
        }
    }