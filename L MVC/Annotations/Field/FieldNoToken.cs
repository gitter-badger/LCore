using System;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public interface IFieldNoToken : ISubClassPersistentAttribute
        {
        }

    public class FieldNoTokenAttribute : Attribute, IFieldNoToken
        {
        }
    }