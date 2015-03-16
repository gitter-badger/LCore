
using System;
using System.Collections.Generic;
using LCore;
using MVCL;
using MVCL.Models;
using MVCL.Controllers;
using System.Linq;

namespace MVCL
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