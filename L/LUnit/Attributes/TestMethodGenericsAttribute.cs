using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Denotes that a method's tests use particular generic types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodGenericsAttribute : Attribute, ITestMethodGenericsAttribute
        {
        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        public Type[] GenericTypes { get; }


        /// <summary>
        /// Create a new TestMethodGenerics
        /// </summary>
        public TestMethodGenericsAttribute(params Type[] GenericTypes)
            {
            this.GenericTypes = GenericTypes;
            }
        }
    }