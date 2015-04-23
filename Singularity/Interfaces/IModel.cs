
using System;
using System.Collections.Generic;
using LCore;
using Singularity;
using Singularity.Models;
using Singularity.Controllers;
using System.Linq;

namespace Singularity
    {
    public interface IModel
        {
        }
    public interface IComplexType : IModel
        {
        }

    public interface IModelUser : IModel
        {
        Boolean? IsAdmin { get; set; }
        }

    public interface IModelRole : IModel
        {
        }
    }