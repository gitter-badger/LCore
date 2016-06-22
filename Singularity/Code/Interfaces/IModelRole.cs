using System;

namespace Singularity.Models
    {
    public interface IModelRole : IModel
        {
        bool AllowAccess(IModel Model);
        }
    }