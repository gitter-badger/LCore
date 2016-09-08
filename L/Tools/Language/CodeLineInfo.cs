using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace LCore.Extensions
    {
    /// <summary>
    /// Information regarding a single line of code
    /// </summary>
    public class CodeLineInfo
        {
        /// <summary>
        /// File path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Line number
        /// </summary>
        public uint LineNumber { get; set; }

        /// <summary>
        /// Line text
        /// </summary>
        public string LineText { get; set; }
        }
    }