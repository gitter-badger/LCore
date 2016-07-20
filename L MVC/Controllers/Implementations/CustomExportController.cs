using LMVC.Models;
using System.Web.Mvc;
using LMVC.Account;

namespace LMVC.Controllers
    {
    [Authorize]
    public class CustomExportController : ManageController<CustomExport>
        {
        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Edit;

        public override string PageGroup => SingularityControllerHelper.Menu_Admin;

        public CustomExportController(IAuthenticationService Auth) : base(Auth) { }
        }
    }
