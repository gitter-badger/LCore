
using Singularity.Controllers;
using Singularity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class SavedSearchController : ManageController<SavedSearch>
        {
        public override string PageGroup
            {
            get
                {
                return ControllerHelper.Menu_Admin;
                }
            }
        }
    }
