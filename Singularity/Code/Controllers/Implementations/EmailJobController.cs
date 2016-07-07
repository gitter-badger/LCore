using Singularity.Models;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    [Authorize]
    public class EmailJobController : ManageController<EmailJob>
        {
        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Display;

        public override string PageGroup => ControllerHelper.Menu_Admin;
        public EmailJobController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
