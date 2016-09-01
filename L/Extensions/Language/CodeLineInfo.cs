using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using LCore.Interfaces;
// ReSharper disable InconsistentNaming

namespace LCore.Extensions
    {

    public class CodeLineInfo
        {
        public string FilePath { get; set; }
        public uint LineNumber { get; set; }
        public string LineText { get; set; }
        }
    }