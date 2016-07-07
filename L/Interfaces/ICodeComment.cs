using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Tools;

namespace LCore.Interfaces
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
        /// Value comment
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Examples comment
        /// </summary>
        string[] Examples { get; set; }

        /// <summary>
        /// Remarks comment
        /// </summary>
        string Remarks { get; set; }

        /// <summary>
        /// Parameters comment
        /// </summary>
        Set<string, string>[] Parameters { get; set; }

        /// <summary>
        /// Exceptions comment
        /// </summary>
        Set<string, string>[] Exceptions { get; set; }

        /// <summary>
        /// Permissions comment
        /// </summary>
        Set<string, string>[] Permissions { get; set; }

        /// <summary>
        /// Type Parameter comment
        /// </summary>
        Set<string, string>[] TypeParameters { get; set; }

        /// <summary>
        /// Includes comment
        /// </summary>
        Set<string, string>[] Includes { get; set; }
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
        /// Value comment
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns comment
        /// </summary>
        public string Summary { get; set; }
        // para (paragraph)
        // paramref[name]
        // typeparamref[name]
        // see[cref=member], seealso[cref=member]
        // list / item / description

        /// <summary>
        /// Remarks comment
        /// </summary>
        public string Remarks { get; set; }


        /// <summary>
        /// Examples comment
        /// </summary>
        public string[] Examples { get; set; }
        // code

        /// <summary>
        /// Parameters comment
        /// </summary>
        public Set<string, string>[] Parameters { get; set; }
        // name, description

        /// <summary>
        /// Exceptions comment
        /// </summary>
        public Set<string, string>[] Exceptions { get; set; }
        // cref, description

        /// <summary>
        /// Permissions comment
        /// </summary>
        public Set<string, string>[] Permissions { get; set; }
        // cref, description

        /// <summary>
        /// Type Parameter comment
        /// </summary>
        public Set<string, string>[] TypeParameters { get; set; }
        // name, description

        /// <summary>
        /// Includes comment
        /// </summary>
        public Set<string, string>[] Includes { get; set; }
        }
    }