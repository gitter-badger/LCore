using System;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public interface IFieldNoToken : ISubClassPersistentAttribute
        {
        }

    public class FieldNoTokenAttribute : Attribute, IFieldNoToken
        {
        }
    }