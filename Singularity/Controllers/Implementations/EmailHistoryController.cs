
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
    public class EmailHistoryController : ManageController<EmailHistory>
        {
        public override string PageGroup
            {
            get
                {
                return ControllerHelper.Menu_Admin;
                }
            }

        public override ModelPermissions OverridePermissions
            {
            get
                {
                return new ModelPermissions()
                {
                    View = true,
                    Export = true,
                };
                }
            }
        }
    }
