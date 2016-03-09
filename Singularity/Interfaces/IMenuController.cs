
using System;
using System.Collections.Generic;
using LCore;
using Singularity;
using Singularity.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    public interface IMenuController : INamed
        {
        IMenuItem[] GetMenuItems(ViewContext Context);
        }
    }