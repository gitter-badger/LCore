using Singularity.Models;
using System.Web.Mvc;
using Singularity.Account;

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

        public EmailHistoryController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
