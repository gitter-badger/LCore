using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Tools
    {
    /// <summary>
    /// Excludes a class or member from being included in GitHub Markdown autogeneration.
    /// </summary>
    public interface IExcludeFromMarkdownAttribute : IPersistAttribute {}
    }