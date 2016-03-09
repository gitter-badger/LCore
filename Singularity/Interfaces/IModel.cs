
using System;
using System.Collections.Generic;
using LCore;
using Singularity;
using Singularity.Models;
using Singularity.Controllers;
using System.Linq;
using Singularity.Annotations;

namespace Singularity.Models
    {
    public interface IModel
        {
        }
    public interface IComplexType : IModel
        {
        }

    public interface IModelUser : IModel, IEmailable
        {
        Boolean? IsAdmin { get; set; }
        }

    public interface IModelRole : IModel
        {
        bool AllowAccess(IModel Model);
        }
    }