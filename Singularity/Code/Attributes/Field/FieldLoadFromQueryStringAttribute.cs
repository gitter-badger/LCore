using System;
using LCore.Extensions;

namespace Singularity.Annotations
    {
    public interface IFieldLoadFromQueryStringAttribute : ITopLevelAttribute
        {

        }

    public class FieldLoadFromQueryStringAttribute : Attribute, IFieldLoadFromQueryStringAttribute
        {
        }
    }