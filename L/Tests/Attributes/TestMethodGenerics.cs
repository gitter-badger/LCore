using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.Tests
    {
    /// <summary>
    /// Denotes that a method's tests use particular generic types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodGenerics : Attribute, ISubClassPersistentAttribute
        {
        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        public Type[] GenericTypes;

        /// <summary>
        /// Create a new TestMethodGenerics
        /// </summary>
        public TestMethodGenerics(params Type[] GenericTypes)
            {
            this.GenericTypes = GenericTypes;
            }
        }
    }