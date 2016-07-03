using System;
using System.Collections;
using System.Collections.Generic;

namespace LCore.Extensions
    {
    /// <summary>
    /// Base type of ISubClassPersistentAttribute and ITopLevelAttribute.
    /// Used to indicate that default persistence has been set:
    /// ISubClassPersistentAttribute: true
    /// ITopLevelAttribute: false
    /// </summary>
    public interface IPersistAttribute
        {
        }
    }