using System;
using System.Collections;
using System.Collections.Generic;
using LCore.Extensions;

namespace LCore.LUnit
    {
    public interface ITestMethodGenericsAttribute : ILUnitAttribute, ISubClassPersistentAttribute
        {
        /// <summary>
        /// Generic types defined on the current method
        /// </summary>
        Type[] GenericTypes { get; }
        }
    }