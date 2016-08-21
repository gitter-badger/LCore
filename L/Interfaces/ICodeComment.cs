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



        /// <summary>
        /// Feature comments
        /// </summary>
        string[] Features { get; set; }
        /// <summary>
        /// Class feature comments
        /// </summary>
        string[] ClassFeatures { get; set; }
        /// <summary>
        /// Project feature comments
        /// </summary>
        string[] ProjectFeatures { get; set; }
        }
    }