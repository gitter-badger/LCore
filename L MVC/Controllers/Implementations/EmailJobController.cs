using LMVC.Models;
using System.Web.Mvc;
using LMVC.Account;

namespace LMVC.Controllers
    {
    [Authorize]
    public class EmailJobController : ManageController<EmailJob>
        {
        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Display;

        public override string PageGroup => SingularityControllerHelper.Menu_Admin;
        public EmailJobController(IAuthenticationService Auth) : base(Auth) {}
        }
    }
