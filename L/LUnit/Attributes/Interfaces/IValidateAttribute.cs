using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Implement this interface for an Attribute to have all of its implementations validated 
    /// using an implementation of LUnit's AssemblyTester.
    /// </summary>
    public interface IValidateAttribute : ILUnitAttribute
        {
        /// <summary>
        /// Return null or an empty string[] to specify a valid attribute. 
        /// Otherwise, return any errors to have them reported during testing.
        /// </summary>
        string[] Validate(MemberInfo Member);
        }
    }