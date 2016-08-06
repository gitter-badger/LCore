using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    /// <summary>
    /// Implement this interface to specify generics used on a method for tests.
    /// </summary>
    public interface ITestMethodGenericsAttribute : ILUnitAttribute, ISubClassPersistentAttribute
        {
        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        Type[] GenericTypes { get; }
        }
    }