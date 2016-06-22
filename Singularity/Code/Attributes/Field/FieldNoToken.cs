using System;

namespace Singularity.Annotations
    {
    public interface IFieldNoToken
        {
        }

    public class FieldNoTokenAttribute : Attribute, IFieldNoToken
        {
        }
    }