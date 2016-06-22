using Singularity.Models;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class EmailHistoryController : ManageController<EmailHistory>
        {
        public override string PageGroup => ControllerHelper.Menu_Admin;

        public override ModelPermissions OverridePermissions => new ModelPermissions
        {
            View = true,
            Export = true
            };
        }
    }
