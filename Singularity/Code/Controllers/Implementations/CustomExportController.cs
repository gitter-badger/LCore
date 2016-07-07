using Singularity.Models;
using System.Web.Mvc;
using Singularity.Account;

namespace Singularity.Controllers
    {
    [Authorize]
    public class CustomExportController : ManageController<CustomExport>
        {
        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Edit;

        public override string PageGroup => ControllerHelper.Menu_Admin;

        public CustomExportController(IAuthenticationService Auth) : base(Auth) { }
        }
    }
