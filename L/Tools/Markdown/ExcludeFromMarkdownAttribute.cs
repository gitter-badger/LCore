using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Tools
    {
    [AttributeUsage(AttributeTargets.All)]
    public class ExcludeFromMarkdownAttribute : Attribute, IExcludeFromMarkdownAttribute
        {

        }
    }