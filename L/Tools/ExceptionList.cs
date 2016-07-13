using System;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Tools
    {
    /// <summary>
    /// Allows an exception to contain multiple exceptions within itself.
    /// </summary>
    public class ExceptionList : Exception
        {
        /// <summary>
        /// Implicitally convert a List[Exception] to an ExceptionList
        /// </summary>
        public static implicit operator Exception[] (ExceptionList Ex)
            {
            return Ex.Exceptions.Array();
            }
        /// <summary>
        /// Implicitally convert a ExceptionList to an Exception[]
        /// </summary>
        public static implicit operator ExceptionList(Exception[] Ex)
            {
            return new ExceptionList(Ex);
            }
        /// <summary>
        /// Implicitally convert a List[Exception] to an ExceptionList
        /// </summary>
        public static implicit operator List<Exception>(ExceptionList Ex)
            {
            return Ex.Exceptions;
            }
        /// <summary>
        /// Implicitally convert a ExceptionList to a List[Exception]
        /// </summary>
        public static implicit operator ExceptionList(List<Exception> Ex)
            {
            return new ExceptionList(Ex);
            }


        /// <summary>
        /// The list of exceptions stored.
        /// </summary>
        public List<Exception> Exceptions { get; }

        /// <summary>
        /// Create a new ExceptionList
        /// </summary>
        public ExceptionList(IEnumerable<Exception> Exceptions)
            {
            this.Exceptions = Exceptions.List();
            }

        /// <summary>Gets a message that describes the current exception.</summary>
        /// <returns>The error message that explains the reason for the exception, or an empty string ("").</returns>
        /// <filterpriority>1</filterpriority>
        public override string Message => this.Exceptions.Convert(Ex => Ex.Message).JoinLines();

        /// <summary>Gets a string representation of the immediate frames on the call stack.</summary>
        /// <returns>A string that describes the immediate frames of the call stack.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        public override string StackTrace => this.Exceptions.Convert(Ex => Ex.StackTrace).JoinLines();
        }
    }