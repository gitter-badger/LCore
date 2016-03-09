
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
    public class EmailJobController : ManageController<EmailJob>
        {
        public override ControllerHelper.ViewType? ActionAfterCreate
            {
            get
                {
                return ControllerHelper.ViewType.Display;
                }
            }

        public override string PageGroup
            {
            get
                {
                return ControllerHelper.Menu_Admin;
                }
            }
        }
    }
