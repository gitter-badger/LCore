using Singularity.Models;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    [Authorize]
    public class EmailHistoryController : ManageController<EmailHistory>
        {
        public override string PageGroup => SingularityControllerHelper.Menu_Admin;

        public override IModelPermissions OverridePermissions => new ModelPermissions
        {
            View = true,
            Export = true
            };

        public EmailHistoryController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
