
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class ErrorsController : ManageController<Singularity.Models.Error>
        {
        public override string PageGroup
            {
            get
                {
                return ControllerHelper.Menu_Admin;
                }
            }
        /*
        public override TimeSpan ArchiveTimeSpan
            {
            get
                {
                return null;
                }
            }
         */
        }
    }
