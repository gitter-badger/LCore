using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Tools
    {
    /// <summary>
    /// An interface to contain the information within XML comment metadata
    /// </summary>
    public interface ICodeComment
        {
        /// <summary>
        /// Returns comment
        /// </summary>
        string Summary { get; set; }

        /// <summary>
        /// Summary comment
        /// </summary>
        string Returns { get; set; }

        /// <summary>
        /// Type parameter comments
        /// </summary>
        Dictionary<string, string> TypeParams { get; set; }
        }

    /// <summary>
    /// Stores XML comment metadata.
    /// </summary>
    public struct CodeComment : ICodeComment
        {
        /// <summary>
        /// Summary comment
        /// </summary>
        public string Returns { get; set; }

        /// <summary>
        /// Returns comment
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Type parameter comments
        /// </summary>
        public Dictionary<string, string> TypeParams { get; set; }
        }
    }