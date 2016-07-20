using System;
using LCore.Extensions;

namespace LMVC.Annotations
    {
    public interface IFieldLoadFromQueryStringAttribute : ITopLevelAttribute
        {

        }

    public class FieldLoadFromQueryStringAttribute : Attribute, IFieldLoadFromQueryStringAttribute
        {
        }
    }