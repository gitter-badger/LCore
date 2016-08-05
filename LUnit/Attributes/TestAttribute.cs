using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Collections;
using System.Reflection;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable VirtualMemberNeverOverriden.Global

namespace LCore.LUnit
    {
    /// <summary>
    /// Override this attribute to define a test case for a particular
    /// method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class TestAttribute : Attribute, ITestAttribute
        {
        /// <summary>
        /// Implement this method to execute the test.
        /// Make assertions here.
        /// </summary>
        public abstract void RunTest(MethodInfo Method);


        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        public Type[] GenericTypes { get; set; }
        
        }
    }