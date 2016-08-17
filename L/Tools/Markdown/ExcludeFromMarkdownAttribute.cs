using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Tools
    {
    /// <summary>
    /// Excludes a class or member from being included in GitHub Markdown autogeneration.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ExcludeFromMarkdownAttribute : Attribute, IExcludeFromMarkdownAttribute
        {

        }
    }