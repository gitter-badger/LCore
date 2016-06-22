using Singularity.Models;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    [Authorize]
    public class CustomExportController : ManageController<CustomExport>
        {
        public override ControllerHelper.ViewType? ActionAfterCreate => ControllerHelper.ViewType.Edit;

        public override string PageGroup => ControllerHelper.Menu_Admin;
        }
    }
