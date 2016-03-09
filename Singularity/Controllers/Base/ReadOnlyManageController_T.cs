using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections;
using System.Web.UI.WebControls;

using LCore;
using Singularity;
using Singularity.Models;
using Singularity.Context;
using Singularity.Filters;

namespace Singularity.Controllers
    {
    public abstract class ReadOnlyManageController<T> : ManageController<T>
        where T : class, IModel
        {
        public override ModelPermissions OverridePermissions
            {
            get
                {
                return new ModelPermissions()
                {
                    View = true,
                    ViewInactive = true,
                    Export = true,
                };
                }
            }
        }
    }
