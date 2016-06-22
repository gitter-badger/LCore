using System;
using Singularity.Annotations;

namespace Singularity.Models
{
    public interface IModelUser : IEmailable
    {
        bool? IsAdmin { get; set; }
    }
}